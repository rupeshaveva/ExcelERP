namespace appExcelERP.Controls.HR.EmployeeSalary
{
    partial class frmAddEditPayrollItem
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
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnBASIC_SALARY = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbtnGROSS_SALARY = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPercentValue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.rbtnApplicableChargesPercent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.txtLumsumValue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.rbtnApplicableChargesLumsum = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSalaryHeadName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkIsSelected = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.rbtnBASIC_AND_DA_Salary = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupMain.HeaderVisiblePrimary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.panel1);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupMain.Panel.Controls.Add(this.txtPercentValue);
            this.headerGroupMain.Panel.Controls.Add(this.rbtnApplicableChargesPercent);
            this.headerGroupMain.Panel.Controls.Add(this.txtLumsumValue);
            this.headerGroupMain.Panel.Controls.Add(this.rbtnApplicableChargesLumsum);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonLabel3);
            this.headerGroupMain.Panel.Controls.Add(this.txtSalaryHeadName);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupMain.Panel.Controls.Add(this.chkIsSelected);
            this.headerGroupMain.Size = new System.Drawing.Size(620, 202);
            this.headerGroupMain.TabIndex = 186;
            this.headerGroupMain.ValuesPrimary.Heading = "Salary Head Name";
            this.headerGroupMain.ValuesPrimary.Image = null;
            this.headerGroupMain.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Text = "&Save";
            this.btnSave.UniqueName = "7F5AADB79C8549A200BBFF0712FCF8AB";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "EA9DD6A50160433D508389BC6BDB7766";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnBASIC_AND_DA_Salary);
            this.panel1.Controls.Add(this.rbtnBASIC_SALARY);
            this.panel1.Controls.Add(this.rbtnGROSS_SALARY);
            this.panel1.Location = new System.Drawing.Point(281, 92);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 32);
            this.panel1.TabIndex = 22;
            // 
            // rbtnBASIC_SALARY
            // 
            this.rbtnBASIC_SALARY.Location = new System.Drawing.Point(21, 4);
            this.rbtnBASIC_SALARY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnBASIC_SALARY.Name = "rbtnBASIC_SALARY";
            this.rbtnBASIC_SALARY.Size = new System.Drawing.Size(58, 24);
            this.rbtnBASIC_SALARY.TabIndex = 13;
            this.rbtnBASIC_SALARY.Values.Text = "Basic";
            // 
            // rbtnGROSS_SALARY
            // 
            this.rbtnGROSS_SALARY.Location = new System.Drawing.Point(101, 4);
            this.rbtnGROSS_SALARY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnGROSS_SALARY.Name = "rbtnGROSS_SALARY";
            this.rbtnGROSS_SALARY.Size = new System.Drawing.Size(62, 24);
            this.rbtnGROSS_SALARY.TabIndex = 14;
            this.rbtnGROSS_SALARY.Values.Text = "Gross";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(232, 94);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(42, 24);
            this.kryptonLabel2.TabIndex = 21;
            this.kryptonLabel2.Values.Text = "% of";
            // 
            // txtPercentValue
            // 
            this.txtPercentValue.Location = new System.Drawing.Point(165, 94);
            this.txtPercentValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPercentValue.Name = "txtPercentValue";
            this.txtPercentValue.Size = new System.Drawing.Size(63, 27);
            this.txtPercentValue.TabIndex = 20;
            this.txtPercentValue.Text = "0000000.00";
            this.txtPercentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnApplicableChargesPercent
            // 
            this.rbtnApplicableChargesPercent.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnApplicableChargesPercent.Location = new System.Drawing.Point(40, 94);
            this.rbtnApplicableChargesPercent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnApplicableChargesPercent.Name = "rbtnApplicableChargesPercent";
            this.rbtnApplicableChargesPercent.Size = new System.Drawing.Size(105, 24);
            this.rbtnApplicableChargesPercent.TabIndex = 16;
            this.rbtnApplicableChargesPercent.Values.Text = "Percentage";
            // 
            // txtLumsumValue
            // 
            this.txtLumsumValue.Location = new System.Drawing.Point(165, 130);
            this.txtLumsumValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLumsumValue.Name = "txtLumsumValue";
            this.txtLumsumValue.Size = new System.Drawing.Size(101, 27);
            this.txtLumsumValue.TabIndex = 18;
            this.txtLumsumValue.Text = "0000000.00";
            this.txtLumsumValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // rbtnApplicableChargesLumsum
            // 
            this.rbtnApplicableChargesLumsum.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnApplicableChargesLumsum.Location = new System.Drawing.Point(40, 130);
            this.rbtnApplicableChargesLumsum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbtnApplicableChargesLumsum.Name = "rbtnApplicableChargesLumsum";
            this.rbtnApplicableChargesLumsum.Size = new System.Drawing.Size(85, 24);
            this.rbtnApplicableChargesLumsum.TabIndex = 17;
            this.rbtnApplicableChargesLumsum.Values.Text = "Lumsum";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(135, 130);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(31, 24);
            this.kryptonLabel3.TabIndex = 19;
            this.kryptonLabel3.Values.Text = "Rs.";
            // 
            // txtSalaryHeadName
            // 
            this.txtSalaryHeadName.Location = new System.Drawing.Point(16, 33);
            this.txtSalaryHeadName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSalaryHeadName.Name = "txtSalaryHeadName";
            this.txtSalaryHeadName.Size = new System.Drawing.Size(567, 27);
            this.txtSalaryHeadName.TabIndex = 12;
            this.txtSalaryHeadName.Text = "birtyday Gift Voucher";
            this.txtSalaryHeadName.Validating += new System.ComponentModel.CancelEventHandler(this.txtSalaryHeadName_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(16, 4);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(165, 24);
            this.kryptonLabel1.TabIndex = 11;
            this.kryptonLabel1.Values.Text = "Name of Salary Head";
            // 
            // chkIsSelected
            // 
            this.chkIsSelected.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsSelected.Location = new System.Drawing.Point(16, 62);
            this.chkIsSelected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIsSelected.Name = "chkIsSelected";
            this.chkIsSelected.Size = new System.Drawing.Size(192, 24);
            this.chkIsSelected.TabIndex = 6;
            this.chkIsSelected.Values.Text = "Salary Head Applicable";
            this.chkIsSelected.CheckedChanged += new System.EventHandler(this.chkIsSelected_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // rbtnBASIC_AND_DA_Salary
            // 
            this.rbtnBASIC_AND_DA_Salary.Location = new System.Drawing.Point(192, 5);
            this.rbtnBASIC_AND_DA_Salary.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnBASIC_AND_DA_Salary.Name = "rbtnBASIC_AND_DA_Salary";
            this.rbtnBASIC_AND_DA_Salary.Size = new System.Drawing.Size(89, 24);
            this.rbtnBASIC_AND_DA_Salary.TabIndex = 15;
            this.rbtnBASIC_AND_DA_Salary.Values.Text = "Basic+DA";
            // 
            // frmAddEditPayrollItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(620, 202);
            this.Controls.Add(this.headerGroupMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPayrollItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Payslip Item";
            this.Load += new System.EventHandler(this.frmAddEditPayrollItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            this.headerGroupMain.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsSelected;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSalaryHeadName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnBASIC_SALARY;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnGROSS_SALARY;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPercentValue;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnApplicableChargesPercent;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLumsumValue;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnApplicableChargesLumsum;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnBASIC_AND_DA_Salary;
    }
}