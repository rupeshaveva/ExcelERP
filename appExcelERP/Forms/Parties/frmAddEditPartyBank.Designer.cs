namespace appExcelERP.Forms.Parties
{
    partial class frmAddEditPartyBank
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
            this.cboParties = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboAccountType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBankBranchName = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewBankBranch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBankName = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewBank = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAccountNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankBranchName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboParties
            // 
            this.cboParties.DropDownWidth = 395;
            this.cboParties.Location = new System.Drawing.Point(12, 48);
            this.cboParties.Name = "cboParties";
            this.cboParties.Size = new System.Drawing.Size(418, 25);
            this.cboParties.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 19);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 24);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "&Party";
            // 
            // cboAccountType
            // 
            this.cboAccountType.DropDownWidth = 395;
            this.cboAccountType.Location = new System.Drawing.Point(143, 200);
            this.cboAccountType.Name = "cboAccountType";
            this.cboAccountType.Size = new System.Drawing.Size(287, 25);
            this.cboAccountType.TabIndex = 15;
            this.cboAccountType.Validating += new System.ComponentModel.CancelEventHandler(this.cboAccountType_Validating);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(33, 200);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(104, 24);
            this.kryptonLabel5.TabIndex = 14;
            this.kryptonLabel5.Values.Text = "Account Type";
            // 
            // cboBankBranchName
            // 
            this.cboBankBranchName.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewBankBranch});
            this.cboBankBranchName.DropDownWidth = 395;
            this.cboBankBranchName.Location = new System.Drawing.Point(12, 166);
            this.cboBankBranchName.Name = "cboBankBranchName";
            this.cboBankBranchName.Size = new System.Drawing.Size(418, 25);
            this.cboBankBranchName.TabIndex = 13;
            this.cboBankBranchName.Validating += new System.ComponentModel.CancelEventHandler(this.cboBankBranchName_Validating);
            // 
            // btnAddNewBankBranch
            // 
            this.btnAddNewBankBranch.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewBankBranch.UniqueName = "776AA9FB31A145F07A81D402CA8D2088";
            this.btnAddNewBankBranch.Click += new System.EventHandler(this.btnAddNewBankBranch_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 137);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(141, 24);
            this.kryptonLabel4.TabIndex = 12;
            this.kryptonLabel4.Values.Text = "Bank Branch Name";
            // 
            // cboBankName
            // 
            this.cboBankName.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewBank});
            this.cboBankName.DropDownWidth = 395;
            this.cboBankName.Location = new System.Drawing.Point(12, 107);
            this.cboBankName.Name = "cboBankName";
            this.cboBankName.Size = new System.Drawing.Size(418, 25);
            this.cboBankName.TabIndex = 11;
            this.cboBankName.SelectedIndexChanged += new System.EventHandler(this.cboBankName_SelectedIndexChanged);
            this.cboBankName.Validating += new System.ComponentModel.CancelEventHandler(this.cboBankName_Validating);
            // 
            // btnAddNewBank
            // 
            this.btnAddNewBank.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewBank.UniqueName = "776AA9FB31A145F07A81D402CA8D2088";
            this.btnAddNewBank.Click += new System.EventHandler(this.btnAddNewBank_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 78);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(90, 24);
            this.kryptonLabel3.TabIndex = 10;
            this.kryptonLabel3.Values.Text = "Bank Name";
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Location = new System.Drawing.Point(143, 231);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(287, 27);
            this.txtAccountNo.TabIndex = 17;
            this.txtAccountNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtAccountNo_Validating);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(41, 230);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(96, 24);
            this.kryptonLabel6.TabIndex = 16;
            this.kryptonLabel6.Values.Text = "Account No.";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(12, 306);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(81, 24);
            this.chkIsActive.TabIndex = 20;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(324, 296);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 34);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(212, 296);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(106, 34);
            this.btnOK.TabIndex = 18;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditPartyBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 343);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtAccountNo);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.cboAccountType);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.cboBankBranchName);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.cboBankName);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.cboParties);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditPartyBank";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Edit Party Bank Details";
            this.Load += new System.EventHandler(this.frmAddEditPartyBank_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAccountType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankBranchName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBankName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboParties;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboAccountType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBankBranchName;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewBankBranch;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBankName;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewBank;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAccountNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}