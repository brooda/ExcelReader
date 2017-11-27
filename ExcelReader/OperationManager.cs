using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader
{
    interface IOperation
    {
        string GetDescription();
        string Result(List<Record> records);
    }

    class PrintData : IOperation
    {
        public string GetDescription()
        {
            return "wypisz dane";
        }

        public string Result(List<Record> records)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Wypisywanie danych. Pierwszy rząd: Nazwa, ID, Cena, Pozycja, Poziom, Opis, NrZamowienia.\nW kolejnych rzędach daty emisji");

            foreach(Record r in records)
            {
                sb.AppendLine(r.ToString());
            }

            return sb.ToString();
        }
    }

    class MeanOnLevel : IOperation
    {
        public string GetDescription()
        {
            return "średni koszt w poziomach";
        }

        public string Result(List<Record> records)
        {
            var levelGroups = records.GroupBy(r => r._level);

            StringBuilder sb = new StringBuilder();

            foreach (var group in levelGroups)
            {
                double price = 0;
                string level = "";
                int days = 0;

                foreach (var g in group)
                {
                    level = g._level;
                    price += g._priceDouble.Value;
                    days += g.getPeriodsLength();
                }

                sb.AppendLine($"Dla poziomu {level} średni dzienny koszt to {(price/days).ToString("#.##")}");
            }

            return sb.ToString();
        }
    }


    class OperationManager
    {
        public List<IOperation> Operations { get; }

        public OperationManager()
        {
            Operations = new List<IOperation>();
            Operations.Add( new PrintData() );
            Operations.Add( new MeanOnLevel() );
        }

        public string dataTransformation(List<Record> records, ListBox.SelectedObjectCollection operations, ListBox.SelectedObjectCollection priceFormats)
        {
            StringBuilder sb = new StringBuilder();

            foreach (IOperation op in Operations)
            {
                if (operations.Contains(op.GetDescription()))
                {
                    sb.Append(op.Result(records));
                    sb.AppendLine();
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }



}
