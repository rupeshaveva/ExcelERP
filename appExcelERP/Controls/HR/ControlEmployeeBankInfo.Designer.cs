namespace appExcelERP.Controls.HR
{
    partial class ControlEmployeeBankInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateBankDetails = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUANNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblUANNo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPANNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblPANNo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtESICNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblESICNo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPFNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblPFNo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAccountNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCreditCardNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblAtmCardNo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblAccountNo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBankBranch = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblBankName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBank = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblAccountType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboAccountType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtAtmCardNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblCreditCardNo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblModeOfSalaryPayment = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboModeOfSalaryPayment = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblNextMedicalCheckUpDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblLastMedicalCheckUpDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtNextMedicalCheckUpDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtLastMedicalCheckUpDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModeOfSalaryPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateBankDetails});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(4);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(726, 448);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Employee Bank Details";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // btnUpdateBankDetails
            // 
            this.btnUpdateBankDetails.Text = "&Update";
            this.btnUpdateBankDetails.UniqueName = "CE1ABF35A0444E8819A5EC2F8A89BB3A";
            this.btnUpdateBankDetails.Click += new System.EventHandler(this.btnUpdateBankDetails_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.txtUANNo, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblUANNo, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPANNo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPANNo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtESICNo, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblESICNo, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPFNo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPFNo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtAccountNo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCreditCardNo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAtmCardNo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblAccountNo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboBankBranch, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBankName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboBank, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAccountType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboAccountType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAtmCardNo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCreditCardNo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblModeOfSalaryPayment, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboModeOfSalaryPayment, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblNextMedicalCheckUpDate, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblLastMedicalCheckUpDate, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.dtNextMedicalCheckUpDate, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.dtLastMedicalCheckUpDate, 3, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(716, 390);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtUANNo
            // 
            this.txtUANNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUANNo.Location = new System.Drawing.Point(539, 100);
            this.txtUANNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtUANNo.Name = "txtUANNo";
            this.txtUANNo.Size = new System.Drawing.Size(175, 20);
            this.txtUANNo.TabIndex = 19;
            this.txtUANNo.Text = "kryptonTextBox7";
            // 
            // lblUANNo
            // 
            this.lblUANNo.Location = new System.Drawing.Point(360, 100);
            this.lblUANNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblUANNo.Name = "lblUANNo";
            this.lblUANNo.Size = new System.Drawing.Size(59, 20);
            this.lblUANNo.TabIndex = 18;
            this.lblUANNo.Values.Text = "UAN No.";
            // 
            // txtPANNo
            // 
            this.txtPANNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPANNo.Location = new System.Drawing.Point(181, 100);
            this.txtPANNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPANNo.Name = "txtPANNo";
            this.txtPANNo.Size = new System.Drawing.Size(175, 20);
            this.txtPANNo.TabIndex = 17;
            this.txtPANNo.Text = "kryptonTextBox6";
            this.txtPANNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPANNo_Validating);
            // 
            // lblPANNo
            // 
            this.lblPANNo.Location = new System.Drawing.Point(2, 100);
            this.lblPANNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblPANNo.Name = "lblPANNo";
            this.lblPANNo.Size = new System.Drawing.Size(59, 20);
            this.lblPANNo.TabIndex = 16;
            this.lblPANNo.Values.Text = "PAN NO.";
            // 
            // txtESICNo
            // 
            this.txtESICNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtESICNo.Location = new System.Drawing.Point(539, 76);
            this.txtESICNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtESICNo.Name = "txtESICNo";
            this.txtESICNo.Size = new System.Drawing.Size(175, 20);
            this.txtESICNo.TabIndex = 15;
            this.txtESICNo.Text = "kryptonTextBox5";
            this.txtESICNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtESICNo_Validating);
            // 
            // lblESICNo
            // 
            this.lblESICNo.Location = new System.Drawing.Point(360, 76);
            this.lblESICNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblESICNo.Name = "lblESICNo";
            this.lblESICNo.Size = new System.Drawing.Size(57, 20);
            this.lblESICNo.TabIndex = 14;
            this.lblESICNo.Values.Text = "ESIC No.";
            // 
            // txtPFNo
            // 
            this.txtPFNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPFNo.Location = new System.Drawing.Point(181, 76);
            this.txtPFNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPFNo.Name = "txtPFNo";
            this.txtPFNo.Size = new System.Drawing.Size(175, 20);
            this.txtPFNo.TabIndex = 13;
            this.txtPFNo.Text = "kryptonTextBox4";
            // 
            // lblPFNo
            // 
            this.lblPFNo.Location = new System.Drawing.Point(2, 76);
            this.lblPFNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblPFNo.Name = "lblPFNo";
            this.lblPFNo.Size = new System.Drawing.Size(51, 20);
            this.lblPFNo.TabIndex = 12;
            this.lblPFNo.Values.Text = "P.F. No.";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAccountNo.Location = new System.Drawing.Point(539, 27);
            this.txtAccountNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(175, 20);
            this.txtAccountNo.TabIndex = 11;
            this.txtAccountNo.Text = "kryptonTextBox3";
            this.txtAccountNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtAccountNo_Validating);
            // 
            // txtCreditCardNo
            // 
            this.txtCreditCardNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCreditCardNo.Location = new System.Drawing.Point(539, 52);
            this.txtCreditCardNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCreditCardNo.Name = "txtCreditCardNo";
            this.txtCreditCardNo.Size = new System.Drawing.Size(175, 20);
            this.txtCreditCardNo.TabIndex = 10;
            this.txtCreditCardNo.Text = "kryptonTextBox2";
            // 
            // lblAtmCardNo
            // 
            this.lblAtmCardNo.Location = new System.Drawing.Point(2, 52);
            this.lblAtmCardNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblAtmCardNo.Name = "lblAtmCardNo";
            this.lblAtmCardNo.Size = new System.Drawing.Size(87, 20);
            this.lblAtmCardNo.TabIndex = 7;
            this.lblAtmCardNo.Values.Text = "ATM Card No.";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.Location = new System.Drawing.Point(360, 27);
            this.lblAccountNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(78, 20);
            this.lblAccountNo.TabIndex = 5;
            this.lblAccountNo.Values.Text = "Account No.";
            // 
            // cboBankBranch
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboBankBranch, 2);
            this.cboBankBranch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboBankBranch.DropDownWidth = 233;
            this.cboBankBranch.Location = new System.Drawing.Point(360, 2);
            this.cboBankBranch.Margin = new System.Windows.Forms.Padding(2);
            this.cboBankBranch.Name = "cboBankBranch";
            this.cboBankBranch.Size = new System.Drawing.Size(354, 21);
            this.cboBankBranch.TabIndex = 2;
            this.cboBankBranch.Text = "kryptonComboBox1";
            // 
            // lblBankName
            // 
            this.lblBankName.Location = new System.Drawing.Point(2, 2);
            this.lblBankName.Margin = new System.Windows.Forms.Padding(2);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(127, 20);
            this.lblBankName.TabIndex = 0;
            this.lblBankName.Values.Text = "Bank Name && Branch";
            // 
            // cboBank
            // 
            this.cboBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboBank.DropDownWidth = 233;
            this.cboBank.Location = new System.Drawing.Point(181, 2);
            this.cboBank.Margin = new System.Windows.Forms.Padding(2);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(175, 21);
            this.cboBank.TabIndex = 1;
            this.cboBank.Text = "kryptonComboBox1";
            this.cboBank.SelectedIndexChanged += new System.EventHandler(this.cboBank_SelectedIndexChanged);
            this.cboBank.Validating += new System.ComponentModel.CancelEventHandler(this.cboBank_Validating);
            // 
            // lblAccountType
            // 
            this.lblAccountType.Location = new System.Drawing.Point(2, 27);
            this.lblAccountType.Margin = new System.Windows.Forms.Padding(2);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(85, 20);
            this.lblAccountType.TabIndex = 3;
            this.lblAccountType.Values.Text = "Account Type";
            // 
            // cboAccountType
            // 
            this.cboAccountType.DropDownWidth = 233;
            this.cboAccountType.Location = new System.Drawing.Point(181, 27);
            this.cboAccountType.Margin = new System.Windows.Forms.Padding(2);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(175, 21);
            this.cboAccountType.TabIndex = 4;
            this.cboAccountType.Text = "kryptonComboBox1";
            this.cboAccountType.Validating += new System.ComponentModel.CancelEventHandler(this.cboAccountType_Validating);
            // 
            // txtAtmCardNo
            // 
            this.txtAtmCardNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAtmCardNo.Location = new System.Drawing.Point(181, 52);
            this.txtAtmCardNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtAtmCardNo.Name = "txtAtmCardNo";
            this.txtAtmCardNo.Size = new System.Drawing.Size(175, 20);
            this.txtAtmCardNo.TabIndex = 8;
            this.txtAtmCardNo.Text = "kryptonTextBox1";
            // 
            // lblCreditCardNo
            // 
            this.lblCreditCardNo.Location = new System.Drawing.Point(360, 52);
            this.lblCreditCardNo.Margin = new System.Windows.Forms.Padding(2);
            this.lblCreditCardNo.Name = "lblCreditCardNo";
            this.lblCreditCardNo.Size = new System.Drawing.Size(95, 20);
            this.lblCreditCardNo.TabIndex = 9;
            this.lblCreditCardNo.Values.Text = "Credit Card No.";
            // 
            // lblModeOfSalaryPayment
            // 
            this.lblModeOfSalaryPayment.Location = new System.Drawing.Point(360, 124);
            this.lblModeOfSalaryPayment.Margin = new System.Windows.Forms.Padding(2);
            this.lblModeOfSalaryPayment.Name = "lblModeOfSalaryPayment";
            this.lblModeOfSalaryPayment.Size = new System.Drawing.Size(146, 20);
            this.lblModeOfSalaryPayment.TabIndex = 20;
            this.lblModeOfSalaryPayment.Values.Text = "Mode Of Salary Payment";
            // 
            // cboModeOfSalaryPayment
            // 
            this.cboModeOfSalaryPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboModeOfSalaryPayment.DropDownWidth = 233;
            this.cboModeOfSalaryPayment.Location = new System.Drawing.Point(539, 124);
            this.cboModeOfSalaryPayment.Margin = new System.Windows.Forms.Padding(2);
            this.cboModeOfSalaryPayment.Name = "cboModeOfSalaryPayment";
            this.cboModeOfSalaryPayment.Size = new System.Drawing.Size(175, 21);
            this.cboModeOfSalaryPayment.TabIndex = 21;
            this.cboModeOfSalaryPayment.Text = "kryptonComboBox2";
            this.cboModeOfSalaryPayment.Validating += new System.ComponentModel.CancelEventHandler(this.cboModeOfSalaryPayment_Validating);
            // 
            // lblNextMedicalCheckUpDate
            // 
            this.lblNextMedicalCheckUpDate.Location = new System.Drawing.Point(360, 149);
            this.lblNextMedicalCheckUpDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblNextMedicalCheckUpDate.Name = "lblNextMedicalCheckUpDate";
            this.lblNextMedicalCheckUpDate.Size = new System.Drawing.Size(163, 20);
            this.lblNextMedicalCheckUpDate.TabIndex = 22;
            this.lblNextMedicalCheckUpDate.Values.Text = "Next Medical CheckUp Date";
            // 
            // lblLastMedicalCheckUpDate
            // 
            this.lblLastMedicalCheckUpDate.Location = new System.Drawing.Point(539, 149);
            this.lblLastMedicalCheckUpDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblLastMedicalCheckUpDate.Name = "lblLastMedicalCheckUpDate";
            this.lblLastMedicalCheckUpDate.Size = new System.Drawing.Size(159, 20);
            this.lblLastMedicalCheckUpDate.TabIndex = 23;
            this.lblLastMedicalCheckUpDate.Values.Text = "Last Medical CheckUp Date";
            // 
            // dtNextMedicalCheckUpDate
            // 
            this.dtNextMedicalCheckUpDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtNextMedicalCheckUpDate.Location = new System.Drawing.Point(360, 173);
            this.dtNextMedicalCheckUpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtNextMedicalCheckUpDate.Name = "dtNextMedicalCheckUpDate";
            this.dtNextMedicalCheckUpDate.ShowCheckBox = true;
            this.dtNextMedicalCheckUpDate.Size = new System.Drawing.Size(175, 21);
            this.dtNextMedicalCheckUpDate.TabIndex = 24;
            this.dtNextMedicalCheckUpDate.ValueNullable = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // dtLastMedicalCheckUpDate
            // 
            this.dtLastMedicalCheckUpDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtLastMedicalCheckUpDate.Location = new System.Drawing.Point(539, 173);
            this.dtLastMedicalCheckUpDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtLastMedicalCheckUpDate.Name = "dtLastMedicalCheckUpDate";
            this.dtLastMedicalCheckUpDate.ShowCheckBox = true;
            this.dtLastMedicalCheckUpDate.Size = new System.Drawing.Size(175, 21);
            this.dtLastMedicalCheckUpDate.TabIndex = 25;
            this.dtLastMedicalCheckUpDate.ValueNullable = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ControlEmployeeBankInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlEmployeeBankInfo";
            this.Size = new System.Drawing.Size(726, 448);
            this.Load += new System.EventHandler(this.ControlEmployeeBankInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModeOfSalaryPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtUANNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUANNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPANNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPANNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtESICNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblESICNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPFNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPFNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAccountNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCreditCardNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAtmCardNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAccountNo;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBankBranch;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBankName;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBank;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAccountType;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboAccountType;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAtmCardNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCreditCardNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblModeOfSalaryPayment;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboModeOfSalaryPayment;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNextMedicalCheckUpDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLastMedicalCheckUpDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtNextMedicalCheckUpDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtLastMedicalCheckUpDate;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateBankDetails;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
