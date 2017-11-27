using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ExcelReader
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populatePriceFormats();
            populateteDatePresenceCheckFormats();
            populateOperations();
        }

        private void populateOperations()
        {
            OperationManager om = new OperationManager();

            foreach (var op in om.Operations)
            {
                listBox_operations.Items.Add(op.GetDescription());
            }

            listBox_operations.SelectionMode = SelectionMode.MultiSimple;

            if (listBox_operations.Items.Count > 0)
                listBox_operations.SelectedIndex = 0;
        }

        private void populatePriceFormats()
        {
            foreach (string format in FormatManager.descriptionFormat.Keys)
            {
                listBox_price_formats.Items.Add(format);
            }
            listBox_price_formats.SelectionMode = SelectionMode.MultiSimple;

            if (listBox_price_formats.Items.Count > 0)
                listBox_price_formats.SelectedIndex = 0;
        }

        private void populateteDatePresenceCheckFormats()
        {
            string DatePresenceCheck = Properties.Settings.Default["DatePresenceCheck"].ToString();
            string[] TagIds = DatePresenceCheck.Split(',');

            listBox_datepresencecheck_formats.Items.Clear();

            foreach (string s in TagIds)
            {
                listBox_datepresencecheck_formats.Items.Add(s);
            }

            listBox_datepresencecheck_formats.SelectionMode = SelectionMode.MultiSimple;

            if (listBox_datepresencecheck_formats.Items.Count > 0)
                listBox_datepresencecheck_formats.SelectedIndex = 0;
        }

        private void button_edit_price_formats_Click(object sender, EventArgs e)
        {
            EditPriceFormats epf = new EditPriceFormats();
            epf.ShowDialog();
            
            if (epf.changedSettings)
                populateteDatePresenceCheckFormats();
        }

        private void button_choose_file_Click(object sender, EventArgs e)
        {
            var FD = new OpenFileDialog();
            FD.Title = "Wybierz plik .xlsx";
            FD.Filter = "xlsx files (*.xlsx)|*.xlsx";

            if (FD.ShowDialog() == DialogResult.OK)
            {
                textBox_filepath.Text = FD.FileName;
            }
        }

        private void button_run_Click(object sender, EventArgs e)
        {
            if (listBox_operations.SelectedItems.Count == 0)
            {
                MessageBox.Show("Wybierz co najmniej jedną operację");
                return;
            }
            if (listBox_price_formats.SelectedItems.Count == 0)
            {
                MessageBox.Show("Wybierz co najmniej jeden akceptowany format ceny");
                return;
            }
            if (listBox_datepresencecheck_formats.SelectedItems.Count == 0)
            {
                MessageBox.Show("Wybierz co najmniej jeden sposób na zaznaczanie daty");
                return;
            }

            string filepath = textBox_filepath.Text;

            try
            {
                List<Record> records = readFile(filepath);

                OperationManager op = new OperationManager();
                string toWrite = op.dataTransformation(records, listBox_operations.SelectedItems, listBox_price_formats.SelectedItems);

                Results epf = new Results(toWrite);
                epf.ShowDialog();
            }
            catch (IOException ex)
            {
                MessageBox.Show($"{ex.Message}. Czy plik do odczytania jest zamknięty?");
            }
        }

        List<Record> readFile(string path)
        {
            XSSFWorkbook hssfworkbook = InitializeWorkbook(path);
            List<Record> records = new List<Record>();

            for (int i = 0; i < hssfworkbook.NumberOfSheets; i++)
            {
                try
                {
                    records.AddRange( TakeData(hssfworkbook, i, true) );
                }
                catch (NotAllColumnsException ex)
                {
                    MessageBox.Show($"W zakładce {hssfworkbook.GetSheetName(i)} nie ma wszystkich wymaganych kolumn. Zakładka ignorowana");
                }
                catch (LongSearchException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (DateGoodFormatButNotValidException ex)
                {
                    MessageBox.Show(ex.Message);
                    records.AddRange( TakeData(hssfworkbook, i, false) );
                }
            }

            return records;
        }

        private List<Record> TakeData(XSSFWorkbook hssfworkbook, int sheetnumber, bool throwdateexception)
        {
            List<Record> records = new List<Record>();

            var sheet = hssfworkbook.GetSheetAt(sheetnumber);

            // We search for the data in our document. start_i will be first non-empty row index, start_j will be first non-empty column index in first non-empty column.
            int start_i = 0;
            int start_j = 0;

            while (sheet.GetRow(start_i) == null)
            {
                if (start_i++ > 10000)
                    throw new LongSearchException($"W zakładce {hssfworkbook.GetSheetName(sheetnumber)} program przeszukał 10000 rzędów i nic nie znalazł. Dalsze szukanie mogłoby zawiesić program. Ignoruję zakładkę {hssfworkbook.GetSheetName(sheetnumber)}");
            }

            while (sheet.GetRow(start_i).GetCell(start_j) == null && start_j < 10000)
            {
                if (start_j++ > 10000)
                    throw new LongSearchException($"W zakładce {hssfworkbook.GetSheetName(sheetnumber)} program przeszukał 10000 kolumn i nic nie znalazł. Dalsze szukanie mogłoby zawiesić program. Ignoruję zakładkę {hssfworkbook.GetSheetName(sheetnumber)}");
            }

            string[] required_names = Record.PropertyNames;
            Dictionary<string, int> required_names_dictionary = new Dictionary<string, int>();
            foreach (var name in required_names)
            {
                required_names_dictionary.Add(name, -1);
            }

            Dictionary<string, int> datestrings = new Dictionary<string, int>();

            // Wyrażenie regularne, opisujące format dat w pliku .xlsl
            Regex dateRegex = new Regex(@"\b\d\d.\d\d.\d\d\d\d-\d\d.\d\d.\d\d\d\d\b");

            // Look through column of headers to find mapping
            // We assume, that in headers are only strings
            for (int j = start_j; j < sheet.GetRow(start_i).Cells.Count + start_j; j++)
            {
                var cell = sheet.GetRow(start_i).GetCell(j);

                if (cell != null)
                {
                    switch (cell.CellType)
                    {
                        case CellType.String:
                            string cellValue = sheet.GetRow(start_i).GetCell(j).StringCellValue.Trim();
                            if (dateRegex.Match(cellValue).Success)
                            {
                                var temp = new DateTime();
                                if (DateTime.TryParse(cellValue.Substring(0, 10), out temp) && DateTime.TryParse(cellValue.Substring(11, 10), out temp))
                                    datestrings.Add(cellValue, j);
                                else if (throwdateexception)
                                    throw new DateGoodFormatButNotValidException($"W zakładce {hssfworkbook.GetSheetName(sheetnumber)} jest kolumna, która jest sformatowana jako data, ale nie jest poprawną datą. Ta kolumna jest ignorowana");
                            }
                            else
                            {
                                required_names_dictionary[cellValue] = j;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            if (required_names_dictionary.Any(entry => entry.Value == -1))
            {
                throw new NotAllColumnsException("Nie mamy wszystkich wymaganych kolumn");
            }

            Dictionary<int, string> reversed_required_names_dictionary = required_names_dictionary.ToDictionary(kp => kp.Value, kp => kp.Key);
            Dictionary<int, string> reversed_datestrings = datestrings.ToDictionary(kp => kp.Value, kp => kp.Key);

            while (sheet.GetRow(++start_i) != null)
            {
                Record record = new Record();

                for (int j = start_j; j < sheet.GetRow(start_i).Cells.Count + start_j; j++)
                {
                    var cell = sheet.GetRow(start_i).GetCell(j);

                    if (cell != null)
                    {
                        string value_to_pass = "";

                        if (cell.CellType == CellType.Formula || cell.CellType == CellType.Numeric)
                            value_to_pass = cell.NumericCellValue.ToString();
                        else
                            value_to_pass = cell.StringCellValue.ToString();

                        if (reversed_required_names_dictionary.ContainsKey(j))
                            record.setPropertyOfNameAndValue(reversed_required_names_dictionary[j], value_to_pass);

                        if (reversed_datestrings.ContainsKey(j) && 
                            listBox_datepresencecheck_formats.SelectedItems.Contains(value_to_pass))
                            record.setPeriod(reversed_datestrings[j]);
                    }
                }

                if (record.isComplete())
                {
                    if (record.priceInGoodFormat(listBox_price_formats.SelectedItems))
                    {
                        records.Add(record);
                    }
                    else
                    {
                        MessageBox.Show($"W zakładce {hssfworkbook.GetSheetName(sheetnumber)} format ceny jest niepoprawny w co najmniej jednej komórce. Ignoruję zakładkę.");
                        return new List<Record>();
                    }
                }
            }

            return records;
        }



        static XSSFWorkbook InitializeWorkbook(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            XSSFWorkbook hssfworkbook = new XSSFWorkbook(file);

            return hssfworkbook;
        }

    }
}
