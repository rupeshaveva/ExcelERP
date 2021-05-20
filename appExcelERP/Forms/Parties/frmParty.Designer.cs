namespace appExcelERP.Forms
{
    partial class frmParty
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
            this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPartyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPartyCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label21 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtWebSite = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label22 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboIndustryType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPANNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtGSTNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboIndustryType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(19, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 4;
            this.label6.Values.Text = "Party &Name";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Party Code";
            // 
            // txtPartyName
            // 
            this.txtPartyName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartyName.Location = new System.Drawing.Point(19, 73);
            this.txtPartyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(340, 23);
            this.txtPartyName.TabIndex = 5;
            this.txtPartyName.Validating += new System.ComponentModel.CancelEventHandler(this.txtPartyName_Validating);
            // 
            // txtPartyCode
            // 
            this.txtPartyCode.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartyCode.Location = new System.Drawing.Point(19, 30);
            this.txtPartyCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPartyCode.Name = "txtPartyCode";
            this.txtPartyCode.ReadOnly = true;
            this.txtPartyCode.Size = new System.Drawing.Size(126, 23);
            this.txtPartyCode.TabIndex = 1;
            this.txtPartyCode.TabStop = false;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(19, 127);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 20);
            this.label21.TabIndex = 8;
            this.label21.Values.Text = "&Website";
            // 
            // txtWebSite
            // 
            this.txtWebSite.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebSite.Location = new System.Drawing.Point(90, 127);
            this.txtWebSite.Margin = new System.Windows.Forms.Padding(4);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(269, 23);
            this.txtWebSite.TabIndex = 9;
            this.txtWebSite.Validating += new System.ComponentModel.CancelEventHandler(this.txtWebSite_Validating);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(19, 101);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 20);
            this.label22.TabIndex = 6;
            this.label22.Values.Text = "eMail ID";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(90, 101);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(269, 23);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(149, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 2;
            this.label3.Values.Text = "Industry Type";
            // 
            // cboIndustryType
            // 
            this.cboIndustryType.DropDownWidth = 296;
            this.cboIndustryType.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboIndustryType.FormattingEnabled = true;
            this.cboIndustryType.Location = new System.Drawing.Point(149, 29);
            this.cboIndustryType.Margin = new System.Windows.Forms.Padding(4);
            this.cboIndustryType.Name = "cboIndustryType";
            this.cboIndustryType.Size = new System.Drawing.Size(206, 21);
            this.cboIndustryType.TabIndex = 3;
            this.cboIndustryType.Validating += new System.ComponentModel.CancelEventHandler(this.cboIndustryType_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(19, 209);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel3.TabIndex = 12;
            this.kryptonLabel3.Values.Text = "PAN No.";
            // 
            // txtPANNumber
            // 
            this.txtPANNumber.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPANNumber.Location = new System.Drawing.Point(90, 209);
            this.txtPANNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPANNumber.Name = "txtPANNumber";
            this.txtPANNumber.Size = new System.Drawing.Size(269, 23);
            this.txtPANNumber.TabIndex = 13;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(5, 5);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtGSTNo);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel6);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtPANNumber);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cboIndustryType);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtPartyCode);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtPartyName);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label6);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtEmail);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label22);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label21);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtWebSite);
            this.kryptonHeaderGroup1.Panel.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(379, 289);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Company Information";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Text = "&Save";
            this.btnSave.UniqueName = "C8CCD1FD24044BD3BB8410F928EC4008";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "111DD6A13D7249C3C981E32A65D80CD7";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtGSTNo
            // 
            this.txtGSTNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGSTNo.Location = new System.Drawing.Point(90, 181);
            this.txtGSTNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtGSTNo.Name = "txtGSTNo";
            this.txtGSTNo.Size = new System.Drawing.Size(269, 23);
            this.txtGSTNo.TabIndex = 11;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel6.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel6.Location = new System.Drawing.Point(19, 181);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(45, 20);
            this.kryptonLabel6.TabIndex = 10;
            this.kryptonLabel6.Values.Text = "GSTIN";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(389, 299);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParty";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD/EDIT PARTY";
            this.Load += new System.EventHandler(this.frmParty_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmParty_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.cboIndustryType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPartyName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPartyCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label21;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWebSite;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label22;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboIndustryType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPANNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGSTNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
    }
}