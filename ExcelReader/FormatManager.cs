using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader
{
    interface IFormat
    {
        bool isInThisFormat(string input);
        double toDouble(string input);
    }

    class IntFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d+$");
            return r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input);
        }
    }

    class DoublePointFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d*\.\d?\d?$");
            return input != "." && r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input.Replace('.', ','));
        }
    }

    class DoubleCommaFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d*,\d?\d?$");
            return input != "," && r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input);
        }
    }

    class IntPLNFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d+pln$");
            return r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input.Substring(0, input.Length - 3));
        }
    }

    class DoublePointPLNFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d*\.\d?\d?pln$");
            return input != ".pln" && r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input.Replace('.', ',').Substring(0, input.Length - 3));
        }
    }

    class DoubleCommaPLNFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d*,\d?\d?pln$");
            return input != ",pln" && r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input.Substring(0, input.Length - 3));
        }
    }
    class IntZLFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d+z(l|ł)$");
            return r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input.Substring(0, input.Length - 2));
        }
    }

    class DoublePointZLFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d*\.\d?\d?z(l|ł)$");
            return input != ".zl" && input != ".zł" && r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input.Replace('.', ',').Substring(0, input.Length - 2));
        }
    }

    class DoubleCommaZLFormat : IFormat
    {
        public bool isInThisFormat(string input)
        {
            Regex r = new Regex(@"^\d*\.\d?\d?z(l|ł)$");
            return input != ".zl" && input != ".zł" && r.IsMatch(input);
        }

        public double toDouble(string input)
        {
            return Double.Parse(input.Replace('.', ',').Substring(0, input.Length - 2));
        }
    }



    class FormatManager
    {
        public static readonly Dictionary<string, IFormat> descriptionFormat = new Dictionary<string, IFormat>() {
            {"1000", new IntFormat() },
            {"1000.00", new DoublePointFormat() },
            {"1000,00", new DoubleCommaFormat() },
            {"1000pln", new IntPLNFormat() },
            {"1000.00pln", new DoublePointPLNFormat() },
            {"1000,00pln", new DoubleCommaPLNFormat() },
            {"1000zł", new IntZLFormat() },
            {"1000.00zł", new DoublePointZLFormat() },
            {"1000,00zł", new DoubleCommaZLFormat() }
        };

        public double? toDoubleIfPossible(string s, ListBox.SelectedObjectCollection selectedFormats)
        {
            double? ret = null;

            List<IFormat> selectedIFormats = new List<IFormat>();

            foreach (var f in selectedFormats)
            {
                selectedIFormats.Add(descriptionFormat[f.ToString()]);
            }


            StringBuilder sb = new StringBuilder();
            foreach (var f in selectedIFormats)
            {
                sb.AppendLine(f.ToString());
            }

            //MessageBox.Show(sb.ToString());

            foreach (IFormat format in selectedIFormats)
            {
                if (format.isInThisFormat(s))
                {
                    ret = format.toDouble(s);
                    break;
                }
            }

            return ret;
        }

    }
}
