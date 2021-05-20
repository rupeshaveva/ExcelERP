namespace appExcelERP.Forms
{
    partial class frmContact
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
            this.headerGroupContactInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.label22 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtFAXNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMobileNoAlternate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPhoneNoAlternate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMobileNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPhoneNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboDepartments = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboDesignations = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtContactName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupContactInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupContactInfo.Panel)).BeginInit();
            this.headerGroupContactInfo.Panel.SuspendLayout();
            this.headerGroupContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDesignations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupContactInfo
            // 
            this.headerGroupContactInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.headerGroupContactInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupContactInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupContactInfo.Location = new System.Drawing.Point(5, 5);
            this.headerGroupContactInfo.Name = "headerGroupContactInfo";
            // 
            // headerGroupContactInfo.Panel
            // 
            this.headerGroupContactInfo.Panel.Controls.Add(this.label22);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtEmail);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtFAXNo);
            this.headerGroupContactInfo.Panel.Controls.Add(this.kryptonLabel6);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtMobileNoAlternate);
            this.headerGroupContactInfo.Panel.Controls.Add(this.kryptonLabel5);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtPhoneNoAlternate);
            this.headerGroupContactInfo.Panel.Controls.Add(this.kryptonLabel4);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtMobileNo);
            this.headerGroupContactInfo.Panel.Controls.Add(this.kryptonLabel3);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtPhoneNo);
            this.headerGroupContactInfo.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupContactInfo.Panel.Controls.Add(this.cboDepartments);
            this.headerGroupContactInfo.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtAddress);
            this.headerGroupContactInfo.Panel.Controls.Add(this.cboDesignations);
            this.headerGroupContactInfo.Panel.Controls.Add(this.txtContactName);
            this.headerGroupContactInfo.Panel.Controls.Add(this.label6);
            this.headerGroupContactInfo.Panel.Controls.Add(this.label3);
            this.headerGroupContactInfo.Panel.Controls.Add(this.label8);
            this.headerGroupContactInfo.Size = new System.Drawing.Size(385, 389);
            this.headerGroupContactInfo.TabIndex = 0;
            this.headerGroupContactInfo.ValuesPrimary.Heading = "Party Name";
            this.headerGroupContactInfo.ValuesPrimary.Image = null;
            this.headerGroupContactInfo.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Text = "&Save Contact Info.";
            this.btnSave.UniqueName = "E9A6712BA1CC49107D818F65DA9D04D0";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "2F3016784A474AAFECA8684079B36EAF";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(13, 132);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 20);
            this.label22.TabIndex = 4;
            this.label22.Values.Text = "eMail ID";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(77, 132);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(291, 23);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtFAXNo
            // 
            this.txtFAXNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFAXNo.Location = new System.Drawing.Point(207, 306);
            this.txtFAXNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtFAXNo.Name = "txtFAXNo";
            this.txtFAXNo.Size = new System.Drawing.Size(161, 23);
            this.txtFAXNo.TabIndex = 79;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel6.Location = new System.Drawing.Point(147, 306);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel6.TabIndex = 78;
            this.kryptonLabel6.Values.Text = "FAX No.";
            // 
            // txtMobileNoAlternate
            // 
            this.txtMobileNoAlternate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNoAlternate.Location = new System.Drawing.Point(207, 278);
            this.txtMobileNoAlternate.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobileNoAlternate.Name = "txtMobileNoAlternate";
            this.txtMobileNoAlternate.Size = new System.Drawing.Size(161, 23);
            this.txtMobileNoAlternate.TabIndex = 17;
            this.txtMobileNoAlternate.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobileNoAlternate_Validating);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel5.Location = new System.Drawing.Point(207, 259);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel5.TabIndex = 16;
            this.kryptonLabel5.Values.Text = "Alternate No.";
            // 
            // txtPhoneNoAlternate
            // 
            this.txtPhoneNoAlternate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNoAlternate.Location = new System.Drawing.Point(207, 236);
            this.txtPhoneNoAlternate.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNoAlternate.Name = "txtPhoneNoAlternate";
            this.txtPhoneNoAlternate.Size = new System.Drawing.Size(161, 23);
            this.txtPhoneNoAlternate.TabIndex = 13;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel4.Location = new System.Drawing.Point(207, 215);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(83, 20);
            this.kryptonLabel4.TabIndex = 12;
            this.kryptonLabel4.Values.Text = "Alternate No.";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(13, 278);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(188, 23);
            this.txtMobileNo.TabIndex = 15;
            this.txtMobileNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobileNo_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 259);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel3.TabIndex = 14;
            this.kryptonLabel3.Values.Text = "Mobile Number";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNo.Location = new System.Drawing.Point(13, 236);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(188, 23);
            this.txtPhoneNo.TabIndex = 11;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 215);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(116, 20);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "Telephone Number";
            // 
            // cboDepartments
            // 
            this.cboDepartments.DropDownWidth = 296;
            this.cboDepartments.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartments.FormattingEnabled = true;
            this.cboDepartments.Location = new System.Drawing.Point(207, 192);
            this.cboDepartments.Margin = new System.Windows.Forms.Padding(4);
            this.cboDepartments.Name = "cboDepartments";
            this.cboDepartments.Size = new System.Drawing.Size(161, 21);
            this.cboDepartments.TabIndex = 69;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(207, 171);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel1.TabIndex = 9;
            this.kryptonLabel1.Values.Text = "Department";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(13, 73);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(355, 55);
            this.txtAddress.TabIndex = 3;
            // 
            // cboDesignations
            // 
            this.cboDesignations.DropDownWidth = 296;
            this.cboDesignations.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDesignations.FormattingEnabled = true;
            this.cboDesignations.Location = new System.Drawing.Point(13, 192);
            this.cboDesignations.Margin = new System.Windows.Forms.Padding(4);
            this.cboDesignations.Name = "cboDesignations";
            this.cboDesignations.Size = new System.Drawing.Size(188, 21);
            this.cboDesignations.TabIndex = 8;
            // 
            // txtContactName
            // 
            this.txtContactName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContactName.Location = new System.Drawing.Point(13, 29);
            this.txtContactName.Margin = new System.Windows.Forms.Padding(4);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(355, 23);
            this.txtContactName.TabIndex = 1;
            this.txtContactName.Validating += new System.ComponentModel.CancelEventHandler(this.txtContactName_Validating);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 0;
            this.label6.Values.Text = "&Name of Contact Person";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 7;
            this.label3.Values.Text = "Designation";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(13, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 2;
            this.label8.Values.Text = "&Address";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 399);
            this.Controls.Add(this.headerGroupContactInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmContact";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD/EDIT CONTACTS";
            this.Load += new System.EventHandler(this.frmContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupContactInfo.Panel)).EndInit();
            this.headerGroupContactInfo.Panel.ResumeLayout(false);
            this.headerGroupContactInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupContactInfo)).EndInit();
            this.headerGroupContactInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDesignations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupContactInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboDesignations;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtContactName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFAXNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMobileNoAlternate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPhoneNoAlternate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMobileNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPhoneNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboDepartments;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label22;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmail;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}