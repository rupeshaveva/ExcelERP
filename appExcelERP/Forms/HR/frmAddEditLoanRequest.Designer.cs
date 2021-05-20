namespace appExcelERP.Forms.HR
{
    partial class frmAddEditLoanRequest
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtDisbursementDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRequestedLoanAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboRequestTo = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblRemarks = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtLoanRequestDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLoanRequestNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboEmployees = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtDisbursementDate
            // 
            this.dtDisbursementDate.CustomFormat = "dd/MM/yyyy";
            this.dtDisbursementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDisbursementDate.Location = new System.Drawing.Point(377, 89);
            this.dtDisbursementDate.Name = "dtDisbursementDate";
            this.dtDisbursementDate.Size = new System.Drawing.Size(88, 20);
            this.dtDisbursementDate.TabIndex = 25;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(260, 89);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(122, 20);
            this.kryptonLabel4.TabIndex = 24;
            this.kryptonLabel4.Values.Text = "Disbursement Date";
            // 
            // txtRequestedLoanAmount
            // 
            this.txtRequestedLoanAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestedLoanAmount.Location = new System.Drawing.Point(158, 89);
            this.txtRequestedLoanAmount.Name = "txtRequestedLoanAmount";
            this.txtRequestedLoanAmount.Size = new System.Drawing.Size(97, 20);
            this.txtRequestedLoanAmount.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestedLoanAmount.TabIndex = 23;
            this.txtRequestedLoanAmount.Text = "0.00";
            this.txtRequestedLoanAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRequestedLoanAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtRequestedLoanAmount_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 89);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(154, 20);
            this.kryptonLabel3.TabIndex = 22;
            this.kryptonLabel3.Values.Text = "Requested Loan Amount";
            // 
            // cboRequestTo
            // 
            this.cboRequestTo.DropDownWidth = 348;
            this.cboRequestTo.Location = new System.Drawing.Point(140, 182);
            this.cboRequestTo.Name = "cboRequestTo";
            this.cboRequestTo.Size = new System.Drawing.Size(325, 21);
            this.cboRequestTo.TabIndex = 29;
            this.cboRequestTo.Text = "kryptonComboBox1";
            this.cboRequestTo.Validating += new System.ComponentModel.CancelEventHandler(this.cboRequestTo_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel8.Location = new System.Drawing.Point(58, 183);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel8.TabIndex = 28;
            this.kryptonLabel8.Values.Text = "Request To";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(387, 212);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 31;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 212);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 30;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(140, 115);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(325, 61);
            this.txtRemarks.TabIndex = 27;
            this.txtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.txtRemarks_Validating);
            // 
            // lblRemarks
            // 
            this.lblRemarks.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblRemarks.Location = new System.Drawing.Point(74, 112);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 20);
            this.lblRemarks.TabIndex = 26;
            this.lblRemarks.Values.Text = "Remarks";
            // 
            // dtLoanRequestDate
            // 
            this.dtLoanRequestDate.CustomFormat = "dd/MM/yyyy";
            this.dtLoanRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLoanRequestDate.Location = new System.Drawing.Point(356, 30);
            this.dtLoanRequestDate.Name = "dtLoanRequestDate";
            this.dtLoanRequestDate.Size = new System.Drawing.Size(109, 20);
            this.dtLoanRequestDate.TabIndex = 19;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(377, 9);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel2.TabIndex = 18;
            this.kryptonLabel2.Values.Text = "Request Date";
            // 
            // txtLoanRequestNo
            // 
            this.txtLoanRequestNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanRequestNo.Location = new System.Drawing.Point(12, 29);
            this.txtLoanRequestNo.Name = "txtLoanRequestNo";
            this.txtLoanRequestNo.ReadOnly = true;
            this.txtLoanRequestNo.Size = new System.Drawing.Size(324, 20);
            this.txtLoanRequestNo.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanRequestNo.TabIndex = 17;
            this.txtLoanRequestNo.Text = "sdfsdf";
            this.txtLoanRequestNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLoanRequestNo_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 16;
            this.label1.Values.Text = "Loan Request Number";
            // 
            // cboEmployees
            // 
            this.cboEmployees.DropDownWidth = 348;
            this.cboEmployees.Location = new System.Drawing.Point(80, 56);
            this.cboEmployees.Name = "cboEmployees";
            this.cboEmployees.Size = new System.Drawing.Size(385, 21);
            this.cboEmployees.TabIndex = 21;
            this.cboEmployees.Text = "kryptonComboBox1";
            this.cboEmployees.Validating += new System.ComponentModel.CancelEventHandler(this.cboEmployees_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 56);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel1.TabIndex = 20;
            this.kryptonLabel1.Values.Text = "Employee";
            // 
            // frmAddEditLoanRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(487, 249);
            this.Controls.Add(this.dtDisbursementDate);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtRequestedLoanAmount);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.cboRequestTo);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.dtLoanRequestDate);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtLoanRequestNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmployees);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditLoanRequest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Loan Request";
            this.Load += new System.EventHandler(this.frmAddEditLoanRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker dtDisbursementDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRequestedLoanAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboRequestTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRemarks;
        private System.Windows.Forms.DateTimePicker dtLoanRequestDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLoanRequestNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}