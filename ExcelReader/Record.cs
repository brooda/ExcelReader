using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader
{
    class Record
    {
        public static readonly string[] PropertyNames = new string[] { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "Nr Zamówienia" };

        public string _name { get; private set; }
        public string _id { get; private set; }
        public string _price { get; private set; }
        public string _position { get; private set; }
        public string _level { get; private set; }
        public string _description { get; private set; }
        public string _no_order { get; private set; }

        public double? _priceDouble { get; private set; }

        public List<Period> _periods { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{_name}\t{_id}\t{_price}\t{_position}\t{_level}\t{_description}\t{_no_order}");

            foreach (var p in _periods)
            {
                sb.AppendLine(p.ToString());
            }

            sb.AppendLine();

            return sb.ToString();
        }

        public Record()
        {
            _periods = new List<Period>();
            _name = null;
            _id = null;
            _price = null;
            _position = null;
            _level = null;
            _description = null;
            _no_order = null;
        }


        public void setPropertyOfNameAndValue(string property, string value)
        {
            if (property == PropertyNames[0])
                _name = value;
            else if (property == PropertyNames[1])
                _id = value;
            else if (property == PropertyNames[2])
                _price = value;
            else if (property == PropertyNames[3])
                _position = value;
            else if (property == PropertyNames[4])
                _level = value;
            else if (property == PropertyNames[5])
                _description = value;
            else if (property == PropertyNames[6])
                _no_order = value;
        }

        public void setPeriod(string period)
        {
            _periods.Add(new Period(DateTime.Parse(period.Substring(0, 10)), DateTime.Parse(period.Substring(11, 10))));
        }

        public bool isComplete()
        {
            return _name != null && _id != null && _position != null && _level != null && _no_order != null;
        }

        public bool priceInGoodFormat(ListBox.SelectedObjectCollection selectedItems)
        {
            FormatManager fm = new FormatManager();

            _priceDouble = fm.toDoubleIfPossible(_price, selectedItems);

            return _priceDouble != null;
        }

        public int getPeriodsLength()
        {
            int ret = 0;

            foreach (Period p in _periods)
            {
                ret += p.getLengthInDays();
            }

            return ret;
        }

    }


    class Period
    {
        private DateTime _start;
        private DateTime _end;

        public Period(DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
        }

        public override string ToString()
        {
            return _start.ToShortDateString() + "-" + _end.ToShortDateString();
        }

        public int getLengthInDays()
        {
            return (_end.Date - _start.Date).Days + 1;
        }
    }
}