namespace appExcelERP
{
    partial class frmNewAttachment
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
            this.lblUserId = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtFileName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSelectFile = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.lblPassword = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboCategories = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTitle = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.headerGroupAttachment = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.cboCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachment.Panel)).BeginInit();
            this.headerGroupAttachment.Panel.SuspendLayout();
            this.headerGroupAttachment.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUserId.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(13, 10);
            this.lblUserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(152, 24);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Values.Text = "Select File to Upload";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileName.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSelectFile});
            this.txtFileName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(13, 36);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(389, 30);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFileName_Validating);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Text = "Choose Document";
            this.btnSelectFile.UniqueName = "FD1DED879AD048BBA58CCAF48AA28A7D";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPassword.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(13, 73);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(175, 24);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Values.Text = "&Category of Attachment";
            // 
            // cboCategories
            // 
            this.cboCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cboCategories.DropDownWidth = 389;
            this.cboCategories.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategories.FormattingEnabled = true;
            this.cboCategories.Location = new System.Drawing.Point(13, 101);
            this.cboCategories.Margin = new System.Windows.Forms.Padding(4);
            this.cboCategories.Name = "cboCategories";
            this.cboCategories.Size = new System.Drawing.Size(389, 25);
            this.cboCategories.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTitle.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(13, 150);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(389, 27);
            this.txtTitle.TabIndex = 6;
            this.txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.txtTitle_Validating);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 5;
            this.label1.Values.Text = "Document Title";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // headerGroupAttachment
            // 
            this.headerGroupAttachment.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnOK,
            this.btnCancel,
            this.buttonSpecHeaderGroup1});
            this.headerGroupAttachment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupAttachment.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupAttachment.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.headerGroupAttachment.Location = new System.Drawing.Point(10, 10);
            this.headerGroupAttachment.Name = "headerGroupAttachment";
            // 
            // headerGroupAttachment.Panel
            // 
            this.headerGroupAttachment.Panel.Controls.Add(this.lblUserId);
            this.headerGroupAttachment.Panel.Controls.Add(this.txtTitle);
            this.headerGroupAttachment.Panel.Controls.Add(this.txtFileName);
            this.headerGroupAttachment.Panel.Controls.Add(this.label1);
            this.headerGroupAttachment.Panel.Controls.Add(this.lblPassword);
            this.headerGroupAttachment.Panel.Controls.Add(this.cboCategories);
            this.headerGroupAttachment.Size = new System.Drawing.Size(427, 270);
            this.headerGroupAttachment.TabIndex = 9;
            this.headerGroupAttachment.ValuesPrimary.Heading = "Attach a New Document";
            this.headerGroupAttachment.ValuesSecondary.Heading = "";
            // 
            // btnOK
            // 
            this.btnOK.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnOK.Text = "&OK";
            this.btnOK.UniqueName = "C2D86E7AE4BC44B3ECBA23DB8EE01AEB";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "ECFD3E60A74A4A7F42AA48220409B5EA";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.buttonSpecHeaderGroup1.Type = ComponentFactory.Krypton.Toolkit.PaletteButtonSpecStyle.FormClose;
            this.buttonSpecHeaderGroup1.UniqueName = "8554DB1CEFFE4C06A6A56E2A17DD5AF5";
            this.buttonSpecHeaderGroup1.Click += new System.EventHandler(this.buttonSpecHeaderGroup1_Click);
            // 
            // frmNewAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(447, 290);
            this.Controls.Add(this.headerGroupAttachment);
            this.Font = new System.Drawing.Font("Verdana", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewAttachment";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Document to be uploaded.";
            this.Load += new System.EventHandler(this.frmNewAttachment_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmNewAttachment_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.cboCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachment.Panel)).EndInit();
            this.headerGroupAttachment.Panel.ResumeLayout(false);
            this.headerGroupAttachment.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachment)).EndInit();
            this.headerGroupAttachment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblUserId;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFileName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPassword;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCategories;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTitle;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSelectFile;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupAttachment;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnOK;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
    }
}