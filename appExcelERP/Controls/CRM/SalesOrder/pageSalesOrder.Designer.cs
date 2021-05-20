namespace appExcelERP.Controls.CRM.SalesOrder
{
    partial class pageSalesOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageSalesOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddPrimarySO = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAddWithoutOrderSO = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditOrder = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteOrder = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnGenerateRevision = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnToggleGrid = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupOrderList = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridSalesOrders = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchSalesOrder = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboSalesOrderStatuses = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tabSalesOrder = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageGeneralInfo = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageClientContact = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageAttachment = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageScheduleCalls = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageAssociates = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageTNC = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOrderList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOrderList.Panel)).BeginInit();
            this.headerGroupOrderList.Panel.SuspendLayout();
            this.headerGroupOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesOrderStatuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSalesOrder)).BeginInit();
            this.tabSalesOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageClientContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageScheduleCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAssociates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageTNC)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddPrimarySO,
            this.btnAddWithoutOrderSO,
            this.btnEditOrder,
            this.btnDeleteOrder,
            this.btnGenerateRevision,
            this.btnRefresh,
            this.btnToggleGrid});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.splitContainerMain);
            this.headerGroupMain.Size = new System.Drawing.Size(840, 436);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Sales Order(s)";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnAddPrimarySO
            // 
            this.btnAddPrimarySO.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPrimarySO.Image")));
            this.btnAddPrimarySO.Text = "&Primary (SO)";
            this.btnAddPrimarySO.UniqueName = "D25BC3CAA8404A98CCAA915CCE421717";
            this.btnAddPrimarySO.Click += new System.EventHandler(this.btnAddPrimarySO_Click);
            // 
            // btnAddWithoutOrderSO
            // 
            this.btnAddWithoutOrderSO.Image = ((System.Drawing.Image)(resources.GetObject("btnAddWithoutOrderSO.Image")));
            this.btnAddWithoutOrderSO.Text = "Without Order (SO)";
            this.btnAddWithoutOrderSO.UniqueName = "905458C1A8E04E6331A0C82D734B744B";
            this.btnAddWithoutOrderSO.Click += new System.EventHandler(this.btnAddWithoutOrderSO_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditOrder.Text = "&Edit SO";
            this.btnEditOrder.UniqueName = "D35CEFFCD619427ACAAA957A1AAB5236";
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteOrder.Text = "&Delete";
            this.btnDeleteOrder.UniqueName = "D846D0914BA84789BBACAB924EC026FF";
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // btnGenerateRevision
            // 
            this.btnGenerateRevision.Image = global::appExcelERP.Properties.Resources.GenerateFile_16x;
            this.btnGenerateRevision.Text = "&Generate Revision";
            this.btnGenerateRevision.UniqueName = "6AA599DD396D40187BBA4A7D764D4672";
            this.btnGenerateRevision.Click += new System.EventHandler(this.btnGenerateRevision_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "EABB53B394AF44E9EBBA413F304B0A33";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnToggleGrid
            // 
            this.btnToggleGrid.Image = global::appExcelERP.Properties.Resources.Collapse_16x;
            this.btnToggleGrid.UniqueName = "2534290957964791D5A1F3F33D6C6A2F";
            this.btnToggleGrid.Click += new System.EventHandler(this.btnToggleGrid_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupOrderList);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabSalesOrder);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(838, 407);
            this.splitContainerMain.SplitterDistance = 235;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupOrderList
            // 
            this.headerGroupOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupOrderList.HeaderVisiblePrimary = false;
            this.headerGroupOrderList.Location = new System.Drawing.Point(0, 0);
            this.headerGroupOrderList.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupOrderList.Name = "headerGroupOrderList";
            // 
            // headerGroupOrderList.Panel
            // 
            this.headerGroupOrderList.Panel.Controls.Add(this.gridSalesOrders);
            this.headerGroupOrderList.Panel.Controls.Add(this.txtSearchSalesOrder);
            this.headerGroupOrderList.Panel.Controls.Add(this.cboSalesOrderStatuses);
            this.headerGroupOrderList.Size = new System.Drawing.Size(235, 407);
            this.headerGroupOrderList.TabIndex = 0;
            this.headerGroupOrderList.ValuesSecondary.Heading = "10 Sales Order(s)";
            // 
            // gridSalesOrders
            // 
            this.gridSalesOrders.AllowUserToAddRows = false;
            this.gridSalesOrders.AllowUserToDeleteRows = false;
            this.gridSalesOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSalesOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSalesOrders.ColumnHeadersHeight = 28;
            this.gridSalesOrders.ColumnHeadersVisible = false;
            this.gridSalesOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSalesOrders.Location = new System.Drawing.Point(0, 41);
            this.gridSalesOrders.Margin = new System.Windows.Forms.Padding(2);
            this.gridSalesOrders.Name = "gridSalesOrders";
            this.gridSalesOrders.ReadOnly = true;
            this.gridSalesOrders.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSalesOrders.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSalesOrders.RowTemplate.Height = 24;
            this.gridSalesOrders.Size = new System.Drawing.Size(233, 343);
            this.gridSalesOrders.TabIndex = 2;
            this.gridSalesOrders.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalesOrders_RowEnter);
            // 
            // txtSearchSalesOrder
            // 
            this.txtSearchSalesOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchSalesOrder.Location = new System.Drawing.Point(0, 21);
            this.txtSearchSalesOrder.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchSalesOrder.Name = "txtSearchSalesOrder";
            this.txtSearchSalesOrder.Size = new System.Drawing.Size(233, 20);
            this.txtSearchSalesOrder.TabIndex = 1;
            this.txtSearchSalesOrder.TextChanged += new System.EventHandler(this.txtSearchSalesOrder_TextChanged);
            // 
            // cboSalesOrderStatuses
            // 
            this.cboSalesOrderStatuses.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboSalesOrderStatuses.DropDownWidth = 330;
            this.cboSalesOrderStatuses.Location = new System.Drawing.Point(0, 0);
            this.cboSalesOrderStatuses.Margin = new System.Windows.Forms.Padding(2);
            this.cboSalesOrderStatuses.Name = "cboSalesOrderStatuses";
            this.cboSalesOrderStatuses.Size = new System.Drawing.Size(233, 21);
            this.cboSalesOrderStatuses.TabIndex = 0;
            this.cboSalesOrderStatuses.Text = "kryptonComboBox1";
            this.cboSalesOrderStatuses.SelectionChangeCommitted += new System.EventHandler(this.cboSalesOrderStatuses_SelectionChangeCommitted);
            // 
            // tabSalesOrder
            // 
            this.tabSalesOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSalesOrder.Location = new System.Drawing.Point(0, 0);
            this.tabSalesOrder.Margin = new System.Windows.Forms.Padding(2);
            this.tabSalesOrder.Name = "tabSalesOrder";
            this.tabSalesOrder.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageGeneralInfo,
            this.tabPageClientContact,
            this.tabPageAttachment,
            this.tabPageScheduleCalls,
            this.tabPageAssociates,
            this.tabPageTNC});
            this.tabSalesOrder.SelectedIndex = 0;
            this.tabSalesOrder.Size = new System.Drawing.Size(596, 407);
            this.tabSalesOrder.TabIndex = 0;
            this.tabSalesOrder.Text = "kryptonNavigator1";
            this.tabSalesOrder.TabClicked += new System.EventHandler<ComponentFactory.Krypton.Navigator.KryptonPageEventArgs>(this.tabSales_TabClicked);
            // 
            // tabPageGeneralInfo
            // 
            this.tabPageGeneralInfo.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageGeneralInfo.Flags = 65534;
            this.tabPageGeneralInfo.LastVisibleSet = true;
            this.tabPageGeneralInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageGeneralInfo.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageGeneralInfo.Name = "tabPageGeneralInfo";
            this.tabPageGeneralInfo.Size = new System.Drawing.Size(594, 380);
            this.tabPageGeneralInfo.Text = "General Info";
            this.tabPageGeneralInfo.ToolTipTitle = "Page ToolTip";
            this.tabPageGeneralInfo.UniqueName = "F30660EFF3A143AFB596884581D64E82";
            // 
            // tabPageClientContact
            // 
            this.tabPageClientContact.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageClientContact.Flags = 65534;
            this.tabPageClientContact.LastVisibleSet = true;
            this.tabPageClientContact.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageClientContact.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageClientContact.Name = "tabPageClientContact";
            this.tabPageClientContact.Size = new System.Drawing.Size(75, 81);
            this.tabPageClientContact.Text = "Contacts";
            this.tabPageClientContact.ToolTipTitle = "Page ToolTip";
            this.tabPageClientContact.UniqueName = "1CB74192B4B14D725DA8F19D15D2FB1A";
            // 
            // tabPageAttachment
            // 
            this.tabPageAttachment.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAttachment.Flags = 65534;
            this.tabPageAttachment.LastVisibleSet = true;
            this.tabPageAttachment.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAttachment.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageAttachment.Name = "tabPageAttachment";
            this.tabPageAttachment.Size = new System.Drawing.Size(634, 384);
            this.tabPageAttachment.Text = "Attachments";
            this.tabPageAttachment.ToolTipTitle = "Page ToolTip";
            this.tabPageAttachment.UniqueName = "70E47E36199C4447F2B977DDAE58B294";
            // 
            // tabPageScheduleCalls
            // 
            this.tabPageScheduleCalls.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageScheduleCalls.Flags = 65534;
            this.tabPageScheduleCalls.LastVisibleSet = true;
            this.tabPageScheduleCalls.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageScheduleCalls.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageScheduleCalls.Name = "tabPageScheduleCalls";
            this.tabPageScheduleCalls.Size = new System.Drawing.Size(758, 384);
            this.tabPageScheduleCalls.Text = "Schedul Calls";
            this.tabPageScheduleCalls.ToolTipTitle = "Page ToolTip";
            this.tabPageScheduleCalls.UniqueName = "7860E1760044437B95BED49ADF54731A";
            // 
            // tabPageAssociates
            // 
            this.tabPageAssociates.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAssociates.Flags = 65534;
            this.tabPageAssociates.LastVisibleSet = true;
            this.tabPageAssociates.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAssociates.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageAssociates.Name = "tabPageAssociates";
            this.tabPageAssociates.Size = new System.Drawing.Size(75, 81);
            this.tabPageAssociates.Text = "Associates";
            this.tabPageAssociates.ToolTipTitle = "Page ToolTip";
            this.tabPageAssociates.UniqueName = "8481FE0FAFFA4B9C28A60776F9170181";
            // 
            // tabPageTNC
            // 
            this.tabPageTNC.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageTNC.Flags = 65534;
            this.tabPageTNC.LastVisibleSet = true;
            this.tabPageTNC.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageTNC.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageTNC.Name = "tabPageTNC";
            this.tabPageTNC.Size = new System.Drawing.Size(633, 380);
            this.tabPageTNC.Text = "Terms && Conditions";
            this.tabPageTNC.ToolTipTitle = "Page ToolTip";
            this.tabPageTNC.UniqueName = "AA249AA9910948FA6B901B3E8CAB3E28";
            // 
            // pageSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.headerGroupMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "pageSalesOrder";
            this.Size = new System.Drawing.Size(840, 436);
            this.Load += new System.EventHandler(this.pageSalesOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOrderList.Panel)).EndInit();
            this.headerGroupOrderList.Panel.ResumeLayout(false);
            this.headerGroupOrderList.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOrderList)).EndInit();
            this.headerGroupOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesOrderStatuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSalesOrder)).EndInit();
            this.tabSalesOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageClientContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageScheduleCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAssociates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageTNC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddPrimarySO;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditOrder;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteOrder;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnGenerateRevision;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnToggleGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOrderList;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridSalesOrders;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchSalesOrder;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSalesOrderStatuses;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabSalesOrder;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageGeneralInfo;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAttachment;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageScheduleCalls;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAssociates;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageTNC;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddWithoutOrderSO;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageClientContact;
    }
}
