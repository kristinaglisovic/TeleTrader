namespace TeleTrader.Forms
{
    partial class SymbolForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSyName = new System.Windows.Forms.TextBox();
            this.labelMode = new System.Windows.Forms.Label();
            this.textBoxTicker = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxExch = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDateAdded = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.textBoxIsin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCurrency = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerPriceDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(47, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol Name";
            // 
            // textBoxSyName
            // 
            this.textBoxSyName.Location = new System.Drawing.Point(48, 107);
            this.textBoxSyName.Name = "textBoxSyName";
            this.textBoxSyName.Size = new System.Drawing.Size(265, 23);
            this.textBoxSyName.TabIndex = 1;
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMode.Location = new System.Drawing.Point(45, 41);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(72, 28);
            this.labelMode.TabIndex = 2;
            this.labelMode.Text = "MODE";
            // 
            // textBoxTicker
            // 
            this.textBoxTicker.Location = new System.Drawing.Point(48, 163);
            this.textBoxTicker.Name = "textBoxTicker";
            this.textBoxTicker.Size = new System.Drawing.Size(265, 23);
            this.textBoxTicker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(46, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ticker";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(50, 368);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(263, 23);
            this.textBoxPrice.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(47, 345);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Price";
            // 
            // comboBoxExch
            // 
            this.comboBoxExch.FormattingEnabled = true;
            this.comboBoxExch.Location = new System.Drawing.Point(48, 473);
            this.comboBoxExch.Name = "comboBoxExch";
            this.comboBoxExch.Size = new System.Drawing.Size(265, 23);
            this.comboBoxExch.TabIndex = 7;
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(48, 525);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(265, 23);
            this.comboBoxType.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(45, 450);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Exchange Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(45, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Type Name";
            // 
            // textBoxDateAdded
            // 
            this.textBoxDateAdded.Enabled = false;
            this.textBoxDateAdded.Location = new System.Drawing.Point(50, 313);
            this.textBoxDateAdded.Name = "textBoxDateAdded";
            this.textBoxDateAdded.Size = new System.Drawing.Size(263, 23);
            this.textBoxDateAdded.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(47, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Date Added";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 605);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(236, 605);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 40);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(46, 559);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(86, 15);
            this.labelError.TabIndex = 15;
            this.labelError.Text = "Error message";
            this.labelError.Visible = false;
            // 
            // textBoxIsin
            // 
            this.textBoxIsin.Location = new System.Drawing.Point(47, 209);
            this.textBoxIsin.Name = "textBoxIsin";
            this.textBoxIsin.Size = new System.Drawing.Size(266, 23);
            this.textBoxIsin.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(45, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Isin";
            // 
            // textBoxCurrency
            // 
            this.textBoxCurrency.Location = new System.Drawing.Point(48, 260);
            this.textBoxCurrency.Name = "textBoxCurrency";
            this.textBoxCurrency.Size = new System.Drawing.Size(265, 23);
            this.textBoxCurrency.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(46, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Currency Code";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(45, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "Price Date";
            // 
            // dateTimePickerPriceDate
            // 
            this.dateTimePickerPriceDate.Location = new System.Drawing.Point(50, 419);
            this.dateTimePickerPriceDate.Name = "dateTimePickerPriceDate";
            this.dateTimePickerPriceDate.Size = new System.Drawing.Size(263, 23);
            this.dateTimePickerPriceDate.TabIndex = 21;
            // 
            // SymbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 680);
            this.Controls.Add(this.dateTimePickerPriceDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxCurrency);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxIsin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textBoxDateAdded);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.comboBoxExch);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxTicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelMode);
            this.Controls.Add(this.textBoxSyName);
            this.Controls.Add(this.label1);
            this.Name = "SymbolForm";
            this.Text = "SymbolForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxSyName;
        private Label labelMode;
        private TextBox textBoxTicker;
        private Label label3;
        private TextBox textBoxPrice;
        private Label label4;
        private ComboBox comboBoxExch;
        private ComboBox comboBoxType;
        private Label label5;
        private Label label6;
        private TextBox textBoxDateAdded;
        private Label label7;
        private Button btnCancel;
        private Button btnSave;
        private Label labelError;
        private TextBox textBoxIsin;
        private Label label2;
        private TextBox textBoxCurrency;
        private Label label8;
        private Label label9;
        private DateTimePicker dateTimePickerPriceDate;
    }
}