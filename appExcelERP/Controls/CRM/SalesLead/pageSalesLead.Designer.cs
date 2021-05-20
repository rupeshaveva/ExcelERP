namespace appExcelERP.Controls.CRM
{
    partial class pageSalesLead
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.cboLeadStatuses = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.tabSalesLead = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageGeneralInfo = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageSuspect = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageAttachement = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageScheduledCalls = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageAssociate = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.gridLeads = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchLead = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewLead = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditLead = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteLead = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnGenerateRevision = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnShowHideLeads = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeadStatuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSalesLead)).BeginInit();
            this.tabSalesLead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageSuspect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageScheduledCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAssociate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.SystemColors.Control;
            this.panelStatus.Controls.Add(this.cboLeadStatuses);
            this.panelStatus.Controls.Add(this.kryptonLabel1);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatus.Location = new System.Drawing.Point(3, 3);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(0);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Padding = new System.Windows.Forms.Padding(5, 1, 1, 1);
            this.panelStatus.Size = new System.Drawing.Size(318, 23);
            this.panelStatus.TabIndex = 1;
            // 
            // cboLeadStatuses
            // 
            this.cboLeadStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLeadStatuses.DropDownWidth = 272;
            this.cboLeadStatuses.Location = new System.Drawing.Point(78, 1);
            this.cboLeadStatuses.Name = "cboLeadStatuses";
            this.cboLeadStatuses.Size = new System.Drawing.Size(239, 21);
            this.cboLeadStatuses.TabIndex = 1;
            this.cboLeadStatuses.Text = "kryptonComboBox1";
            this.cboLeadStatuses.SelectionChangeCommitted += new System.EventHandler(this.cboLeadStatuses_SelectionChangeCommitted);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel1.Location = new System.Drawing.Point(5, 1);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 21);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Lead Status";
            // 
            // tabSalesLead
            // 
            this.tabSalesLead.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.tabSalesLead.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SlantEqualBoth;
            this.tabSalesLead.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.tabSalesLead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSalesLead.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSalesLead.Location = new System.Drawing.Point(0, 0);
            this.tabSalesLead.Name = "tabSalesLead";
            this.tabSalesLead.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageGeneralInfo,
            this.tabPageSuspect,
            this.tabPageAttachement,
            this.tabPageScheduledCalls,
            this.tabPageAssociate});
            this.tabSalesLead.SelectedIndex = 4;
            this.tabSalesLead.Size = new System.Drawing.Size(1323, 598);
            this.tabSalesLead.TabIndex = 13;
            this.tabSalesLead.TabClicked += new System.EventHandler<ComponentFactory.Krypton.Navigator.KryptonPageEventArgs>(this.tabSalesLead_TabClicked);
            // 
            // tabPageGeneralInfo
            // 
            this.tabPageGeneralInfo.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageGeneralInfo.Flags = 65534;
            this.tabPageGeneralInfo.ImageSmall = global::appExcelERP.Properties.Resources.MageProductIcon_16x_24;
            this.tabPageGeneralInfo.LastVisibleSet = true;
            this.tabPageGeneralInfo.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageGeneralInfo.Name = "tabPageGeneralInfo";
            this.tabPageGeneralInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralInfo.Size = new System.Drawing.Size(601, 340);
            this.tabPageGeneralInfo.Text = "General Info";
            this.tabPageGeneralInfo.ToolTipTitle = "Page ToolTip";
            this.tabPageGeneralInfo.UniqueName = "742C400235B2408D029F937412FF2133";
            // 
            // tabPageSuspect
            // 
            this.tabPageSuspect.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageSuspect.Flags = 65534;
            this.tabPageSuspect.ImageSmall = global::appExcelERP.Properties.Resources.list_16xMD;
            this.tabPageSuspect.LastVisibleSet = true;
            this.tabPageSuspect.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageSuspect.Name = "tabPageSuspect";
            this.tabPageSuspect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSuspect.Size = new System.Drawing.Size(601, 341);
            this.tabPageSuspect.Text = "Suspect Info";
            this.tabPageSuspect.ToolTipTitle = "Page ToolTip";
            this.tabPageSuspect.UniqueName = "4AA98DBB86A24CF65B8EC30CF1CDCCF5";
            // 
            // tabPageAttachement
            // 
            this.tabPageAttachement.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAttachement.Flags = 65534;
            this.tabPageAttachement.ImageSmall = global::appExcelERP.Properties.Resources.DocumentLibraryFolder_16x1;
            this.tabPageAttachement.LastVisibleSet = true;
            this.tabPageAttachement.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageAttachement.Name = "tabPageAttachement";
            this.tabPageAttachement.Size = new System.Drawing.Size(601, 340);
            this.tabPageAttachement.Text = "Attached Documents";
            this.tabPageAttachement.ToolTipTitle = "Page ToolTip";
            this.tabPageAttachement.UniqueName = "A5A597E97B744ACFE4947FF743B51579";
            // 
            // tabPageScheduledCalls
            // 
            this.tabPageScheduledCalls.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageScheduledCalls.Flags = 65534;
            this.tabPageScheduledCalls.ImageSmall = global::appExcelERP.Properties.Resources.FeedbackBubble_16x;
            this.tabPageScheduledCalls.LastVisibleSet = true;
            this.tabPageScheduledCalls.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageScheduledCalls.Name = "tabPageScheduledCalls";
            this.tabPageScheduledCalls.Size = new System.Drawing.Size(1321, 560);
            this.tabPageScheduledCalls.Text = "Scheduled Call log(s)";
            this.tabPageScheduledCalls.ToolTipTitle = "Page ToolTip";
            this.tabPageScheduledCalls.UniqueName = "06B711B936B247FD6B9243EBF3C82CA9";
            // 
            // tabPageAssociate
            // 
            this.tabPageAssociate.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAssociate.Flags = 65534;
            this.tabPageAssociate.ImageSmall = global::appExcelERP.Properties.Resources.FilterUser_16x;
            this.tabPageAssociate.LastVisibleSet = true;
            this.tabPageAssociate.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageAssociate.Name = "tabPageAssociate";
            this.tabPageAssociate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssociate.Size = new System.Drawing.Size(1321, 572);
            this.tabPageAssociate.Text = "Associates";
            this.tabPageAssociate.ToolTipTitle = "Page ToolTip";
            this.tabPageAssociate.UniqueName = "0D8B1AD459684F30B9B9CBA44D52A429";
            // 
            // gridLeads
            // 
            this.gridLeads.AllowUserToAddRows = false;
            this.gridLeads.AllowUserToDeleteRows = false;
            this.gridLeads.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLeads.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLeads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLeads.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLeads.CausesValidation = false;
            this.gridLeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLeads.ColumnHeadersVisible = false;
            this.gridLeads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLeads.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLeads.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridLeads.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridLeads.Location = new System.Drawing.Point(3, 46);
            this.gridLeads.MultiSelect = false;
            this.gridLeads.Name = "gridLeads";
            this.gridLeads.ReadOnly = true;
            this.gridLeads.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLeads.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLeads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLeads.Size = new System.Drawing.Size(318, 549);
            this.gridLeads.StandardTab = true;
            this.gridLeads.TabIndex = 14;
            this.gridLeads.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLeads_RowEnter);
            // 
            // txtSearchLead
            // 
            this.txtSearchLead.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchLead.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchLead.Location = new System.Drawing.Point(3, 26);
            this.txtSearchLead.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchLead.Name = "txtSearchLead";
            this.txtSearchLead.Size = new System.Drawing.Size(318, 20);
            this.txtSearchLead.TabIndex = 3;
            this.txtSearchLead.Leave += new System.EventHandler(this.txtSearchLead_Leave);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.CausesValidation = false;
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.gridLeads);
            this.splitContainerMain.Panel1.Controls.Add(this.txtSearchLead);
            this.splitContainerMain.Panel1.Controls.Add(this.panelStatus);
            this.splitContainerMain.Panel1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabSalesLead);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(1652, 598);
            this.splitContainerMain.SplitterDistance = 324;
            this.splitContainerMain.TabIndex = 2;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.AllowButtonSpecToolTips = true;
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewLead,
            this.btnEditLead,
            this.btnDeleteLead,
            this.btnGenerateRevision,
            this.btnRefresh,
            this.btnShowHideLeads});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(3, 3);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.splitContainerMain);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(3);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(1660, 655);
            this.kryptonHeaderGroup1.TabIndex = 3;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "SALES LEAD";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "Records";
            // 
            // btnAddNewLead
            // 
            this.btnAddNewLead.Text = "&ADD NEW LEAD";
            this.btnAddNewLead.UniqueName = "9F92D728835642B8C2991465D94102BA";
            this.btnAddNewLead.Click += new System.EventHandler(this.btnAddLead_Click);
            // 
            // btnEditLead
            // 
            this.btnEditLead.Text = "&EDIT LEAD";
            this.btnEditLead.UniqueName = "760FCBE8D88E4A68FB8C8F026F3A24A7";
            this.btnEditLead.Click += new System.EventHandler(this.btnEditSalesLead_Click);
            // 
            // btnDeleteLead
            // 
            this.btnDeleteLead.Text = "&DELETE LEAD";
            this.btnDeleteLead.UniqueName = "F2271E83981740DAB0B8D5B13D1B0A4D";
            this.btnDeleteLead.Click += new System.EventHandler(this.btnDeleteLead_Click);
            // 
            // btnGenerateRevision
            // 
            this.btnGenerateRevision.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnGenerateRevision.Text = "&GENERATE REVISION";
            this.btnGenerateRevision.UniqueName = "8AA1A9E9DCF748F547B63AB989F768B3";
            this.btnGenerateRevision.Click += new System.EventHandler(this.btnGenerateRevision_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Text = "&REFRESH";
            this.btnRefresh.UniqueName = "07F499A43B3A40389CABC9CB18E8A41E";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnShowHideLeads
            // 
            this.btnShowHideLeads.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Checked;
            this.btnShowHideLeads.Image = global::appExcelERP.Properties.Resources.list_16xMD;
            this.btnShowHideLeads.UniqueName = "2979688FDF5144FC4B83C4662377302B";
            this.btnShowHideLeads.ButtonSpecPropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.btnShowHideLeads_ButtonSpecPropertyChanged);
            // 
            // pageSalesLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "pageSalesLead";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1666, 661);
            this.Load += new System.EventHandler(this.pageSalesLead_Load);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeadStatuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSalesLead)).EndInit();
            this.tabSalesLead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageSuspect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageScheduledCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAssociate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelStatus;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabSalesLead;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageGeneralInfo;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageSuspect;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAttachement;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageScheduledCalls;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAssociate;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLeads;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchLead;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewLead;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditLead;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteLead;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnShowHideLeads;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnGenerateRevision;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboLeadStatuses;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}
