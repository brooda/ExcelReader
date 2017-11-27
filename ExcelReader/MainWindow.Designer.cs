namespace ExcelReader
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_price_formats = new System.Windows.Forms.GroupBox();
            this.listBox_price_formats = new System.Windows.Forms.ListBox();
            this.groupBox_datepresence = new System.Windows.Forms.GroupBox();
            this.button_edit_price_formats = new System.Windows.Forms.Button();
            this.listBox_datepresencecheck_formats = new System.Windows.Forms.ListBox();
            this.groupBox_operations = new System.Windows.Forms.GroupBox();
            this.listBox_operations = new System.Windows.Forms.ListBox();
            this.button_choose_file = new System.Windows.Forms.Button();
            this.textBox_filepath = new System.Windows.Forms.TextBox();
            this.button_run = new System.Windows.Forms.Button();
            this.groupBox_price_formats.SuspendLayout();
            this.groupBox_datepresence.SuspendLayout();
            this.groupBox_operations.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_price_formats
            // 
            this.groupBox_price_formats.Controls.Add(this.listBox_price_formats);
            this.groupBox_price_formats.Location = new System.Drawing.Point(2, 2);
            this.groupBox_price_formats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_price_formats.Name = "groupBox_price_formats";
            this.groupBox_price_formats.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_price_formats.Size = new System.Drawing.Size(261, 184);
            this.groupBox_price_formats.TabIndex = 2;
            this.groupBox_price_formats.TabStop = false;
            this.groupBox_price_formats.Text = "Możliwe formaty ceny";
            // 
            // listBox_price_formats
            // 
            this.listBox_price_formats.FormattingEnabled = true;
            this.listBox_price_formats.Location = new System.Drawing.Point(0, 18);
            this.listBox_price_formats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_price_formats.Name = "listBox_price_formats";
            this.listBox_price_formats.Size = new System.Drawing.Size(258, 160);
            this.listBox_price_formats.TabIndex = 0;
            // 
            // groupBox_datepresence
            // 
            this.groupBox_datepresence.Controls.Add(this.button_edit_price_formats);
            this.groupBox_datepresence.Controls.Add(this.listBox_datepresencecheck_formats);
            this.groupBox_datepresence.Location = new System.Drawing.Point(267, 2);
            this.groupBox_datepresence.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_datepresence.Name = "groupBox_datepresence";
            this.groupBox_datepresence.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_datepresence.Size = new System.Drawing.Size(264, 184);
            this.groupBox_datepresence.TabIndex = 3;
            this.groupBox_datepresence.TabStop = false;
            this.groupBox_datepresence.Text = "Możliwe sposoby zaznaczenia obecności daty";
            // 
            // button_edit_price_formats
            // 
            this.button_edit_price_formats.Location = new System.Drawing.Point(0, 143);
            this.button_edit_price_formats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_edit_price_formats.Name = "button_edit_price_formats";
            this.button_edit_price_formats.Size = new System.Drawing.Size(256, 37);
            this.button_edit_price_formats.TabIndex = 1;
            this.button_edit_price_formats.Text = "edytuj możliwości  zaznaczenia obecności daty";
            this.button_edit_price_formats.UseVisualStyleBackColor = true;
            this.button_edit_price_formats.Click += new System.EventHandler(this.button_edit_price_formats_Click);
            // 
            // listBox_datepresencecheck_formats
            // 
            this.listBox_datepresencecheck_formats.FormattingEnabled = true;
            this.listBox_datepresencecheck_formats.Location = new System.Drawing.Point(0, 18);
            this.listBox_datepresencecheck_formats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_datepresencecheck_formats.Name = "listBox_datepresencecheck_formats";
            this.listBox_datepresencecheck_formats.Size = new System.Drawing.Size(257, 121);
            this.listBox_datepresencecheck_formats.TabIndex = 0;
            // 
            // groupBox_operations
            // 
            this.groupBox_operations.Controls.Add(this.listBox_operations);
            this.groupBox_operations.Location = new System.Drawing.Point(2, 184);
            this.groupBox_operations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_operations.Name = "groupBox_operations";
            this.groupBox_operations.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox_operations.Size = new System.Drawing.Size(261, 128);
            this.groupBox_operations.TabIndex = 6;
            this.groupBox_operations.TabStop = false;
            this.groupBox_operations.Text = "Jakie operacje wykonać na zbiorze?";
            // 
            // listBox_operations
            // 
            this.listBox_operations.FormattingEnabled = true;
            this.listBox_operations.Location = new System.Drawing.Point(0, 18);
            this.listBox_operations.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox_operations.Name = "listBox_operations";
            this.listBox_operations.Size = new System.Drawing.Size(258, 108);
            this.listBox_operations.TabIndex = 0;
            // 
            // button_choose_file
            // 
            this.button_choose_file.Location = new System.Drawing.Point(268, 188);
            this.button_choose_file.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_choose_file.Name = "button_choose_file";
            this.button_choose_file.Size = new System.Drawing.Size(255, 37);
            this.button_choose_file.TabIndex = 7;
            this.button_choose_file.Text = "Wybierz ściezkę do pliku";
            this.button_choose_file.UseVisualStyleBackColor = true;
            this.button_choose_file.Click += new System.EventHandler(this.button_choose_file_Click);
            // 
            // textBox_filepath
            // 
            this.textBox_filepath.Location = new System.Drawing.Point(268, 230);
            this.textBox_filepath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_filepath.Name = "textBox_filepath";
            this.textBox_filepath.Size = new System.Drawing.Size(256, 20);
            this.textBox_filepath.TabIndex = 8;
            // 
            // button_run
            // 
            this.button_run.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button_run.Location = new System.Drawing.Point(268, 253);
            this.button_run.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_run.Name = "button_run";
            this.button_run.Size = new System.Drawing.Size(255, 59);
            this.button_run.TabIndex = 9;
            this.button_run.Text = "WYKONAJ OPERACJE";
            this.button_run.UseVisualStyleBackColor = false;
            this.button_run.Click += new System.EventHandler(this.button_run_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 314);
            this.Controls.Add(this.button_run);
            this.Controls.Add(this.textBox_filepath);
            this.Controls.Add(this.button_choose_file);
            this.Controls.Add(this.groupBox_operations);
            this.Controls.Add(this.groupBox_datepresence);
            this.Controls.Add(this.groupBox_price_formats);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainWindow";
            this.Text = "ExcelReader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_price_formats.ResumeLayout(false);
            this.groupBox_datepresence.ResumeLayout(false);
            this.groupBox_operations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_price_formats;
        private System.Windows.Forms.ListBox listBox_price_formats;
        private System.Windows.Forms.GroupBox groupBox_datepresence;
        private System.Windows.Forms.ListBox listBox_datepresencecheck_formats;
        private System.Windows.Forms.Button button_edit_price_formats;
        private System.Windows.Forms.GroupBox groupBox_operations;
        private System.Windows.Forms.ListBox listBox_operations;
        private System.Windows.Forms.Button button_choose_file;
        private System.Windows.Forms.TextBox textBox_filepath;
        private System.Windows.Forms.Button button_run;
    }
}

