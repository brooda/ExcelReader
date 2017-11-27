using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelReader
{
    public partial class EditPriceFormats : Form
    {
        public bool changedSettings;

        public EditPriceFormats()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            changedSettings = false;
            textBox1.Text = Properties.Settings.Default["DatePresenceCheck"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["DatePresenceCheck"] = textBox1.Text;
            changedSettings = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
