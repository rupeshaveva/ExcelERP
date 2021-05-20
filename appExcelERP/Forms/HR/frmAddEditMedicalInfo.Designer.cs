namespace appExcelERP.Forms.HR
{
    partial class frmAddEditMedicalInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddEditMedicalInfo));
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtRemark = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.dtExpieryDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCardNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCardType = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMedicalName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblselectRelation = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblNameOfRelative = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboRelation = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.dtIssueDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cboRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(142, 345);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 27);
            this.btnOK.TabIndex = 38;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(258, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 27);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(8, 226);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(380, 113);
            this.txtRemark.TabIndex = 37;
            this.txtRemark.Text = "kryptonRichTextBox1";
            // 
            // dtExpieryDate
            // 
            this.dtExpieryDate.Checked = false;
            this.dtExpieryDate.CustomFormat = "dd/MM/yyyy";
            this.dtExpieryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtExpieryDate.Location = new System.Drawing.Point(296, 183);
            this.dtExpieryDate.Name = "dtExpieryDate";
            this.dtExpieryDate.Size = new System.Drawing.Size(92, 21);
            this.dtExpieryDate.TabIndex = 36;
            this.dtExpieryDate.ValueNullable = ((object)(resources.GetObject("dtExpieryDate.ValueNullable")));
            this.dtExpieryDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtTillValidDate_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(214, 184);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel3.TabIndex = 34;
            this.kryptonLabel3.Values.Text = "Expiery Date";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(8, 206);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel4.TabIndex = 35;
            this.kryptonLabel4.Values.Text = "Remark";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(8, 157);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(380, 20);
            this.txtCompanyName.TabIndex = 33;
            this.txtCompanyName.Text = "kryptonTextBox1";
            this.txtCompanyName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyName_Validating);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(8, 137);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(99, 20);
            this.kryptonLabel5.TabIndex = 32;
            this.kryptonLabel5.Values.Text = "Company Name";
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(12, 106);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(136, 20);
            this.txtCardNo.TabIndex = 31;
            this.txtCardNo.Text = "kryptonTextBox1";
            this.txtCardNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCardNo_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 86);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel1.TabIndex = 28;
            this.kryptonLabel1.Values.Text = "Card No.";
            // 
            // txtCardType
            // 
            this.txtCardType.Location = new System.Drawing.Point(154, 106);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.Size = new System.Drawing.Size(234, 20);
            this.txtCardType.TabIndex = 30;
            this.txtCardType.Text = "kryptonTextBox1";
            this.txtCardType.Validating += new System.ComponentModel.CancelEventHandler(this.txtCardType_Validating);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(154, 86);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel2.TabIndex = 29;
            this.kryptonLabel2.Values.Text = "Card Type";
            // 
            // txtMedicalName
            // 
            this.txtMedicalName.Location = new System.Drawing.Point(12, 31);
            this.txtMedicalName.Name = "txtMedicalName";
            this.txtMedicalName.Size = new System.Drawing.Size(376, 20);
            this.txtMedicalName.TabIndex = 27;
            this.txtMedicalName.Text = "kryptonTextBox1";
            this.txtMedicalName.Validating += new System.ComponentModel.CancelEventHandler(this.txtMedicalName_Validating);
            // 
            // lblselectRelation
            // 
            this.lblselectRelation.Location = new System.Drawing.Point(12, 10);
            this.lblselectRelation.Name = "lblselectRelation";
            this.lblselectRelation.Size = new System.Drawing.Size(138, 20);
            this.lblselectRelation.TabIndex = 24;
            this.lblselectRelation.Values.Text = "Name of the benificiery";
            // 
            // lblNameOfRelative
            // 
            this.lblNameOfRelative.Location = new System.Drawing.Point(154, 57);
            this.lblNameOfRelative.Name = "lblNameOfRelative";
            this.lblNameOfRelative.Size = new System.Drawing.Size(55, 20);
            this.lblNameOfRelative.TabIndex = 25;
            this.lblNameOfRelative.Values.Text = "Relation";
            // 
            // cboRelation
            // 
            this.cboRelation.DropDownWidth = 175;
            this.cboRelation.Location = new System.Drawing.Point(215, 57);
            this.cboRelation.Name = "cboRelation";
            this.cboRelation.Size = new System.Drawing.Size(175, 21);
            this.cboRelation.TabIndex = 40;
            this.cboRelation.Text = "kryptonComboBox1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(315, 10);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(69, 20);
            this.chkIsActive.TabIndex = 41;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // dtIssueDate
            // 
            this.dtIssueDate.Checked = false;
            this.dtIssueDate.CustomFormat = "dd/MM/yyyy";
            this.dtIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIssueDate.Location = new System.Drawing.Point(115, 183);
            this.dtIssueDate.Name = "dtIssueDate";
            this.dtIssueDate.Size = new System.Drawing.Size(92, 21);
            this.dtIssueDate.TabIndex = 43;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(43, 184);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel6.TabIndex = 42;
            this.kryptonLabel6.Values.Text = "Issue Date";
            // 
            // frmAddEditMedicalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(408, 394);
            this.Controls.Add(this.dtIssueDate);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.cboRelation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.dtExpieryDate);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.txtCardNo);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtCardType);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtMedicalName);
            this.Controls.Add(this.lblselectRelation);
            this.Controls.Add(this.lblNameOfRelative);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditMedicalInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Medical Info";
            this.Load += new System.EventHandler(this.frmAddEditMedicalInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtRemark;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtExpieryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCardNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCardType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMedicalName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblselectRelation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNameOfRelative;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboRelation;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtIssueDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
    }
}