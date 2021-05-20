namespace appExcelERP.Forms.HR
{
    partial class frmAddEditLoanDisbursement
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
            this.txtLoanAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboPreparedBy = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblRemarks = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtLoanDisbursementDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtInterestRate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.TxtEMIAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txttotalEMI = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboRequestTo = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtDeductionFromDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboLoanRequests = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEmployeeInfo = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtTotalAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboPreparedBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoanRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLoanAmount
            // 
            this.txtLoanAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanAmount.Location = new System.Drawing.Point(13, 171);
            this.txtLoanAmount.Name = "txtLoanAmount";
            this.txtLoanAmount.Size = new System.Drawing.Size(89, 20);
            this.txtLoanAmount.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanAmount.TabIndex = 7;
            this.txtLoanAmount.Text = "0.00";
            this.txtLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLoanAmount.TextChanged += new System.EventHandler(this.txtLoanAmount_TextChanged);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 148);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(89, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Loan Amount";
            // 
            // cboPreparedBy
            // 
            this.cboPreparedBy.DropDownWidth = 348;
            this.cboPreparedBy.Location = new System.Drawing.Point(182, 290);
            this.cboPreparedBy.Name = "cboPreparedBy";
            this.cboPreparedBy.Size = new System.Drawing.Size(325, 21);
            this.cboPreparedBy.TabIndex = 19;
            this.cboPreparedBy.Text = "kryptonComboBox1";
            this.cboPreparedBy.Validating += new System.ComponentModel.CancelEventHandler(this.cboPreparedBy_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel8.Location = new System.Drawing.Point(95, 291);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(81, 20);
            this.kryptonLabel8.TabIndex = 18;
            this.kryptonLabel8.Values.Text = "Prepared By";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(427, 360);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 23;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(337, 360);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 22;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(127, 218);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(380, 63);
            this.txtRemarks.TabIndex = 17;
            // 
            // lblRemarks
            // 
            this.lblRemarks.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblRemarks.Location = new System.Drawing.Point(127, 192);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 20);
            this.lblRemarks.TabIndex = 16;
            this.lblRemarks.Values.Text = "Remarks";
            // 
            // dtLoanDisbursementDate
            // 
            this.dtLoanDisbursementDate.CustomFormat = "dd/MM/yyyy";
            this.dtLoanDisbursementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLoanDisbursementDate.Location = new System.Drawing.Point(12, 32);
            this.dtLoanDisbursementDate.Name = "dtLoanDisbursementDate";
            this.dtLoanDisbursementDate.Size = new System.Drawing.Size(109, 20);
            this.dtLoanDisbursementDate.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 9);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel2.TabIndex = 0;
            this.kryptonLabel2.Values.Text = "Disburs Date";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label1.Location = new System.Drawing.Point(127, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 2;
            this.label1.Values.Text = "Select Loan Request";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterestRate.Location = new System.Drawing.Point(109, 171);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(45, 20);
            this.txtInterestRate.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterestRate.TabIndex = 9;
            this.txtInterestRate.Text = "0.00";
            this.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInterestRate.TextChanged += new System.EventHandler(this.txtInterestRate_TextChanged);
            this.txtInterestRate.Validating += new System.ComponentModel.CancelEventHandler(this.txtInterestRate_Validating);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(116, 148);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(30, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "(%)";
            // 
            // TxtEMIAmount
            // 
            this.TxtEMIAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEMIAmount.Location = new System.Drawing.Point(247, 171);
            this.TxtEMIAmount.Name = "TxtEMIAmount";
            this.TxtEMIAmount.Size = new System.Drawing.Size(113, 20);
            this.TxtEMIAmount.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEMIAmount.TabIndex = 13;
            this.TxtEMIAmount.Text = "0.00";
            this.TxtEMIAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(283, 148);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel6.TabIndex = 12;
            this.kryptonLabel6.Values.Text = "E.M.I (Rs.)";
            // 
            // txttotalEMI
            // 
            this.txttotalEMI.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalEMI.Location = new System.Drawing.Point(160, 171);
            this.txttotalEMI.Name = "txttotalEMI";
            this.txttotalEMI.Size = new System.Drawing.Size(81, 20);
            this.txttotalEMI.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalEMI.TabIndex = 11;
            this.txttotalEMI.Text = "0.00";
            this.txttotalEMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttotalEMI.TextChanged += new System.EventHandler(this.txttotalEMI_TextChanged);
            this.txttotalEMI.Validating += new System.ComponentModel.CancelEventHandler(this.txttotalEMI_Validating);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel7.Location = new System.Drawing.Point(160, 148);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(81, 20);
            this.kryptonLabel7.TabIndex = 10;
            this.kryptonLabel7.Values.Text = "Total E.M.I.s";
            // 
            // cboRequestTo
            // 
            this.cboRequestTo.DropDownWidth = 348;
            this.cboRequestTo.Location = new System.Drawing.Point(182, 317);
            this.cboRequestTo.Name = "cboRequestTo";
            this.cboRequestTo.Size = new System.Drawing.Size(325, 21);
            this.cboRequestTo.TabIndex = 21;
            this.cboRequestTo.Text = "kryptonComboBox1";
            this.cboRequestTo.Validating += new System.ComponentModel.CancelEventHandler(this.cboRequestTo_Validating);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 317);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(164, 20);
            this.kryptonLabel4.TabIndex = 20;
            this.kryptonLabel4.Values.Text = "Send Approval Request To";
            // 
            // dtDeductionFromDate
            // 
            this.dtDeductionFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtDeductionFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDeductionFromDate.Location = new System.Drawing.Point(411, 171);
            this.dtDeductionFromDate.Name = "dtDeductionFromDate";
            this.dtDeductionFromDate.Size = new System.Drawing.Size(96, 20);
            this.dtDeductionFromDate.TabIndex = 15;
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel9.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel9.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel9.Location = new System.Drawing.Point(378, 148);
            this.kryptonLabel9.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(129, 20);
            this.kryptonLabel9.TabIndex = 14;
            this.kryptonLabel9.Values.Text = "Deductions From dt.";
            // 
            // cboLoanRequests
            // 
            this.cboLoanRequests.DropDownWidth = 348;
            this.cboLoanRequests.Location = new System.Drawing.Point(127, 32);
            this.cboLoanRequests.Name = "cboLoanRequests";
            this.cboLoanRequests.Size = new System.Drawing.Size(382, 21);
            this.cboLoanRequests.TabIndex = 3;
            this.cboLoanRequests.Text = "kryptonComboBox1";
            this.cboLoanRequests.SelectedValueChanged += new System.EventHandler(this.cboLoanRequests_SelectedValueChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(127, 61);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(94, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Employee Info";
            // 
            // txtEmployeeInfo
            // 
            this.txtEmployeeInfo.Location = new System.Drawing.Point(127, 80);
            this.txtEmployeeInfo.Name = "txtEmployeeInfo";
            this.txtEmployeeInfo.ReadOnly = true;
            this.txtEmployeeInfo.Size = new System.Drawing.Size(382, 62);
            this.txtEmployeeInfo.TabIndex = 5;
            this.txtEmployeeInfo.TabStop = false;
            this.txtEmployeeInfo.Text = "kryptonRichTextBox1";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.Location = new System.Drawing.Point(13, 192);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(89, 20);
            this.txtTotalAmount.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAmount.TabIndex = 63;
            this.txtTotalAmount.TabStop = false;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditLoanDisbursement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(521, 406);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtEmployeeInfo);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.cboLoanRequests);
            this.Controls.Add(this.dtDeductionFromDate);
            this.Controls.Add(this.kryptonLabel9);
            this.Controls.Add(this.cboRequestTo);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txttotalEMI);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.TxtEMIAmount);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.txtLoanAmount);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.cboPreparedBy);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.dtLoanDisbursementDate);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditLoanDisbursement";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Loan Disbursement";
            this.Load += new System.EventHandler(this.frmAddEditLoanDisbursement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboPreparedBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoanRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLoanAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboPreparedBy;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRemarks;
        private System.Windows.Forms.DateTimePicker dtLoanDisbursementDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtInterestRate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox TxtEMIAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txttotalEMI;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboRequestTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.DateTimePicker dtDeductionFromDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboLoanRequests;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtEmployeeInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTotalAmount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}