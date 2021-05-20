namespace appExcelERP.Forms.HR
{
    partial class frmAddEditHolidayAndWeekOff
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
            this.components = new System.ComponentModel.Container();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblRemark = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRemark = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.lblselectRelation = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtHolidayDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboFinancialYear = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.radioBtnHoliday = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.radioBtnWeekOff = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.dtDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.cboFinancialYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(198, 134);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 19;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(283, 134);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Values.Text = "&Cancel";
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(45, 59);
            this.lblRemark.Margin = new System.Windows.Forms.Padding(2);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(52, 20);
            this.lblRemark.TabIndex = 14;
            this.lblRemark.Values.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(101, 59);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(2);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(262, 71);
            this.txtRemark.TabIndex = 18;
            this.txtRemark.Text = "kryptonRichTextBox1";
            // 
            // lblselectRelation
            // 
            this.lblselectRelation.Location = new System.Drawing.Point(12, 9);
            this.lblselectRelation.Margin = new System.Windows.Forms.Padding(2);
            this.lblselectRelation.Name = "lblselectRelation";
            this.lblselectRelation.Size = new System.Drawing.Size(85, 20);
            this.lblselectRelation.TabIndex = 11;
            this.lblselectRelation.Values.Text = "Financial Year";
            // 
            // dtHolidayDate
            // 
            this.dtHolidayDate.Location = new System.Drawing.Point(16, 34);
            this.dtHolidayDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtHolidayDate.Name = "dtHolidayDate";
            this.dtHolidayDate.Size = new System.Drawing.Size(81, 20);
            this.dtHolidayDate.TabIndex = 12;
            this.dtHolidayDate.Values.Text = "Holiday Date";
            // 
            // cboFinancialYear
            // 
            this.cboFinancialYear.DropDownWidth = 364;
            this.cboFinancialYear.Location = new System.Drawing.Point(101, 9);
            this.cboFinancialYear.Margin = new System.Windows.Forms.Padding(2);
            this.cboFinancialYear.Name = "cboFinancialYear";
            this.cboFinancialYear.Size = new System.Drawing.Size(262, 21);
            this.cboFinancialYear.TabIndex = 15;
            this.cboFinancialYear.Text = "kryptonComboBox1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // radioBtnHoliday
            // 
            this.radioBtnHoliday.Location = new System.Drawing.Point(211, 34);
            this.radioBtnHoliday.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnHoliday.Name = "radioBtnHoliday";
            this.radioBtnHoliday.Size = new System.Drawing.Size(64, 20);
            this.radioBtnHoliday.TabIndex = 21;
            this.radioBtnHoliday.Values.Text = "Holiday";
            // 
            // radioBtnWeekOff
            // 
            this.radioBtnWeekOff.Location = new System.Drawing.Point(289, 34);
            this.radioBtnWeekOff.Margin = new System.Windows.Forms.Padding(2);
            this.radioBtnWeekOff.Name = "radioBtnWeekOff";
            this.radioBtnWeekOff.Size = new System.Drawing.Size(74, 20);
            this.radioBtnWeekOff.TabIndex = 22;
            this.radioBtnWeekOff.Values.Text = "Week Off";
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd/MM/yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDate.Location = new System.Drawing.Point(101, 34);
            this.dtDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(95, 21);
            this.dtDate.TabIndex = 24;
            // 
            // frmAddEditHolidayAndWeekOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(376, 174);
            this.Controls.Add(this.dtDate);
            this.Controls.Add(this.radioBtnWeekOff);
            this.Controls.Add(this.radioBtnHoliday);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblselectRelation);
            this.Controls.Add(this.dtHolidayDate);
            this.Controls.Add(this.cboFinancialYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditHolidayAndWeekOff";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/EditHolidayAndWeekOff";
            this.Load += new System.EventHandler(this.frmAddEditHolidayAndWeekOff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboFinancialYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRemark;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtRemark;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblselectRelation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel dtHolidayDate;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboFinancialYear;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioBtnWeekOff;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radioBtnHoliday;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtDate;
    }
}