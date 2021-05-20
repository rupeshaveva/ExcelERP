namespace appExcelERP.Controls.ADMIN
{
    partial class pageVoucherNoSetup
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
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupDocuments = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridDocumentTypes = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchDocumentType = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.headerGroupVoucherSetup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewVoucherSetup = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditVoucherNoSetup = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridVoucherSetupList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocuments.Panel)).BeginInit();
            this.headerGroupDocuments.Panel.SuspendLayout();
            this.headerGroupDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupVoucherSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupVoucherSetup.Panel)).BeginInit();
            this.headerGroupVoucherSetup.Panel.SuspendLayout();
            this.headerGroupVoucherSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherSetupList)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.splitContainerMain);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(843, 457);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Voucher Number Settings";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupDocuments);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupVoucherSetup);
            this.splitContainerMain.Size = new System.Drawing.Size(841, 419);
            this.splitContainerMain.SplitterDistance = 280;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupDocuments
            // 
            this.headerGroupDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupDocuments.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDocuments.Location = new System.Drawing.Point(0, 0);
            this.headerGroupDocuments.Name = "headerGroupDocuments";
            // 
            // headerGroupDocuments.Panel
            // 
            this.headerGroupDocuments.Panel.Controls.Add(this.gridDocumentTypes);
            this.headerGroupDocuments.Panel.Controls.Add(this.txtSearchDocumentType);
            this.headerGroupDocuments.Size = new System.Drawing.Size(280, 419);
            this.headerGroupDocuments.TabIndex = 0;
            this.headerGroupDocuments.ValuesPrimary.Heading = "Document Types";
            this.headerGroupDocuments.ValuesPrimary.Image = null;
            // 
            // gridDocumentTypes
            // 
            this.gridDocumentTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDocumentTypes.ColumnHeadersHeight = 28;
            this.gridDocumentTypes.ColumnHeadersVisible = false;
            this.gridDocumentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDocumentTypes.Location = new System.Drawing.Point(0, 27);
            this.gridDocumentTypes.Name = "gridDocumentTypes";
            this.gridDocumentTypes.ReadOnly = true;
            this.gridDocumentTypes.RowHeadersVisible = false;
            this.gridDocumentTypes.RowTemplate.Height = 24;
            this.gridDocumentTypes.Size = new System.Drawing.Size(278, 339);
            this.gridDocumentTypes.TabIndex = 1;
            this.gridDocumentTypes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDocumentTypes_RowEnter);
            // 
            // txtSearchDocumentType
            // 
            this.txtSearchDocumentType.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchDocumentType.Location = new System.Drawing.Point(0, 0);
            this.txtSearchDocumentType.Name = "txtSearchDocumentType";
            this.txtSearchDocumentType.Size = new System.Drawing.Size(278, 27);
            this.txtSearchDocumentType.TabIndex = 0;
            this.txtSearchDocumentType.Text = "kryptonTextBox1";
            this.txtSearchDocumentType.Visible = false;
            // 
            // headerGroupVoucherSetup
            // 
            this.headerGroupVoucherSetup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewVoucherSetup,
            this.btnEditVoucherNoSetup});
            this.headerGroupVoucherSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupVoucherSetup.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupVoucherSetup.Location = new System.Drawing.Point(0, 0);
            this.headerGroupVoucherSetup.Name = "headerGroupVoucherSetup";
            // 
            // headerGroupVoucherSetup.Panel
            // 
            this.headerGroupVoucherSetup.Panel.Controls.Add(this.gridVoucherSetupList);
            this.headerGroupVoucherSetup.Size = new System.Drawing.Size(556, 419);
            this.headerGroupVoucherSetup.TabIndex = 0;
            this.headerGroupVoucherSetup.ValuesPrimary.Image = null;
            // 
            // btnAddNewVoucherSetup
            // 
            this.btnAddNewVoucherSetup.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewVoucherSetup.Text = "&Add New";
            this.btnAddNewVoucherSetup.UniqueName = "29728FA2D28A416E21BA3BAE030E66D6";
            this.btnAddNewVoucherSetup.Click += new System.EventHandler(this.btnAddNewVoucherSetup_Click);
            // 
            // btnEditVoucherNoSetup
            // 
            this.btnEditVoucherNoSetup.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditVoucherNoSetup.Text = "&Edit";
            this.btnEditVoucherNoSetup.UniqueName = "F986DDD0200D44D4628A9AD9CE59F8C4";
            this.btnEditVoucherNoSetup.Click += new System.EventHandler(this.btnEditVoucherNoSetup_Click);
            // 
            // gridVoucherSetupList
            // 
            this.gridVoucherSetupList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridVoucherSetupList.ColumnHeadersHeight = 28;
            this.gridVoucherSetupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVoucherSetupList.Location = new System.Drawing.Point(0, 0);
            this.gridVoucherSetupList.Name = "gridVoucherSetupList";
            this.gridVoucherSetupList.ReadOnly = true;
            this.gridVoucherSetupList.RowHeadersVisible = false;
            this.gridVoucherSetupList.RowTemplate.Height = 24;
            this.gridVoucherSetupList.Size = new System.Drawing.Size(554, 361);
            this.gridVoucherSetupList.TabIndex = 2;
            this.gridVoucherSetupList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVoucherSetupList_RowEnter);
            // 
            // pageVoucherNoSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "pageVoucherNoSetup";
            this.Size = new System.Drawing.Size(843, 457);
            this.Load += new System.EventHandler(this.pageVoucherNoSetup_Load);
            this.Resize += new System.EventHandler(this.pageVoucherNoSetup_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocuments.Panel)).EndInit();
            this.headerGroupDocuments.Panel.ResumeLayout(false);
            this.headerGroupDocuments.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocuments)).EndInit();
            this.headerGroupDocuments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocumentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupVoucherSetup.Panel)).EndInit();
            this.headerGroupVoucherSetup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupVoucherSetup)).EndInit();
            this.headerGroupVoucherSetup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVoucherSetupList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDocuments;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDocumentTypes;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchDocumentType;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupVoucherSetup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewVoucherSetup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditVoucherNoSetup;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridVoucherSetupList;
    }
}
