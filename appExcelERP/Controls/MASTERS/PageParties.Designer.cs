namespace appExcelERP.Controls.CRM
{
    partial class PageParties
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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupParties = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewParty = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditParty = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteParty = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefreshParties = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridParties = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchCompany = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchParties = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.tabCustomerInfo = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageContactInfo = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.headerGroupDelete = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.gridContacts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerContacts = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnAddNewContact = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnEditContact = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnDeleteContact = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.tabPageAddresses = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.headerGroupPartyAddress = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddAddress = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditAddress = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAddresses = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonBreadCrumbItem1 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonBreadCrumbItem2 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonBreadCrumbItem3 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonContextMenu1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParties.Panel)).BeginInit();
            this.headerGroupParties.Panel.SuspendLayout();
            this.headerGroupParties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerInfo)).BeginInit();
            this.tabCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageContactInfo)).BeginInit();
            this.tabPageContactInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete.Panel)).BeginInit();
            this.headerGroupDelete.Panel.SuspendLayout();
            this.headerGroupDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAddresses)).BeginInit();
            this.tabPageAddresses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPartyAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPartyAddress.Panel)).BeginInit();
            this.headerGroupPartyAddress.Panel.SuspendLayout();
            this.headerGroupPartyAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddresses)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.headerGroupParties);
            this.kryptonSplitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.tabCustomerInfo);
            this.kryptonSplitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(873, 576);
            this.kryptonSplitContainer1.SplitterDistance = 289;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // headerGroupParties
            // 
            this.headerGroupParties.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewParty,
            this.btnEditParty,
            this.btnDeleteParty,
            this.btnRefreshParties});
            this.headerGroupParties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupParties.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupParties.Location = new System.Drawing.Point(1, 1);
            this.headerGroupParties.Name = "headerGroupParties";
            // 
            // headerGroupParties.Panel
            // 
            this.headerGroupParties.Panel.Controls.Add(this.gridParties);
            this.headerGroupParties.Panel.Controls.Add(this.txtSearchCompany);
            this.headerGroupParties.Panel.Margin = new System.Windows.Forms.Padding(3);
            this.headerGroupParties.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupParties.Size = new System.Drawing.Size(287, 574);
            this.headerGroupParties.TabIndex = 0;
            this.headerGroupParties.ValuesPrimary.Heading = "Existing Parties";
            this.headerGroupParties.ValuesPrimary.Image = null;
            // 
            // btnAddNewParty
            // 
            this.btnAddNewParty.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewParty.Text = "&AddNew Party";
            this.btnAddNewParty.UniqueName = "ECA728345C3C407638BE8DF211EAA356";
            this.btnAddNewParty.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // btnEditParty
            // 
            this.btnEditParty.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x;
            this.btnEditParty.Text = "&Edit Party";
            this.btnEditParty.UniqueName = "74BFDB91EB614DCD2C94CC6398E0C6B8";
            this.btnEditParty.Click += new System.EventHandler(this.btnEditCustomers_Click);
            // 
            // btnDeleteParty
            // 
            this.btnDeleteParty.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteParty.Text = "&Delete";
            this.btnDeleteParty.UniqueName = "C570BDA2E7E84D546995658A8EADFCEB";
            this.btnDeleteParty.Click += new System.EventHandler(this.btnDeleteParty_Click);
            // 
            // btnRefreshParties
            // 
            this.btnRefreshParties.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefreshParties.Text = "&Refresh";
            this.btnRefreshParties.UniqueName = "594D5670B7E040197A93B9D9E164533B";
            this.btnRefreshParties.Click += new System.EventHandler(this.btnRefreshParties_Click);
            // 
            // gridParties
            // 
            this.gridParties.AllowUserToAddRows = false;
            this.gridParties.AllowUserToDeleteRows = false;
            this.gridParties.AllowUserToOrderColumns = true;
            this.gridParties.AllowUserToResizeColumns = false;
            this.gridParties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridParties.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridParties.ColumnHeadersHeight = 28;
            this.gridParties.ColumnHeadersVisible = false;
            this.gridParties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridParties.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridParties.Location = new System.Drawing.Point(5, 31);
            this.gridParties.MultiSelect = false;
            this.gridParties.Name = "gridParties";
            this.gridParties.ReadOnly = true;
            this.gridParties.RowHeadersVisible = false;
            this.gridParties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridParties.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridParties.Size = new System.Drawing.Size(275, 488);
            this.gridParties.TabIndex = 6;
            this.gridParties.VirtualMode = true;
            this.gridParties.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCustomers_CellDoubleClick);
            this.gridParties.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridParties_CellFormatting);
            this.gridParties.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridParties_RowEnter);
            // 
            // txtSearchCompany
            // 
            this.txtSearchCompany.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchParties});
            this.txtSearchCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchCompany.Location = new System.Drawing.Point(5, 5);
            this.txtSearchCompany.Name = "txtSearchCompany";
            this.txtSearchCompany.Size = new System.Drawing.Size(275, 26);
            this.txtSearchCompany.TabIndex = 5;
            this.txtSearchCompany.TextChanged += new System.EventHandler(this.txtSearchCompany_TextChanged);
            // 
            // btnSearchParties
            // 
            this.btnSearchParties.Text = "&Search";
            this.btnSearchParties.UniqueName = "0E0F2D5E61DC4A53AE99701D5251BF01";
            this.btnSearchParties.Click += new System.EventHandler(this.btnSearchParties_Click);
            // 
            // tabCustomerInfo
            // 
            this.tabCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCustomerInfo.Location = new System.Drawing.Point(1, 1);
            this.tabCustomerInfo.Name = "tabCustomerInfo";
            this.tabCustomerInfo.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageContactInfo,
            this.tabPageAddresses});
            this.tabCustomerInfo.SelectedIndex = 1;
            this.tabCustomerInfo.Size = new System.Drawing.Size(577, 574);
            this.tabCustomerInfo.TabIndex = 1;
            this.tabCustomerInfo.Text = "kryptonNavigator1";
            // 
            // tabPageContactInfo
            // 
            this.tabPageContactInfo.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageContactInfo.Controls.Add(this.headerGroupDelete);
            this.tabPageContactInfo.Controls.Add(this.gridContacts);
            this.tabPageContactInfo.Controls.Add(this.headerContacts);
            this.tabPageContactInfo.Flags = 65534;
            this.tabPageContactInfo.LastVisibleSet = true;
            this.tabPageContactInfo.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageContactInfo.Name = "tabPageContactInfo";
            this.tabPageContactInfo.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageContactInfo.Size = new System.Drawing.Size(575, 547);
            this.tabPageContactInfo.Text = "Cotntact(s)";
            this.tabPageContactInfo.ToolTipTitle = "Page ToolTip";
            this.tabPageContactInfo.UniqueName = "EAA2003BBCA04D7EB790B4BFF8D3F458";
            // 
            // headerGroupDelete
            // 
            this.headerGroupDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerGroupDelete.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupDelete.HeaderVisibleSecondary = false;
            this.headerGroupDelete.Location = new System.Drawing.Point(5, 433);
            this.headerGroupDelete.Name = "headerGroupDelete";
            // 
            // headerGroupDelete.Panel
            // 
            this.headerGroupDelete.Panel.Controls.Add(this.txtRemarks);
            this.headerGroupDelete.Size = new System.Drawing.Size(565, 109);
            this.headerGroupDelete.TabIndex = 2;
            this.headerGroupDelete.ValuesPrimary.Image = null;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(0, 0);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(563, 85);
            this.txtRemarks.TabIndex = 0;
            this.txtRemarks.Text = "kryptonRichTextBox1";
            // 
            // gridContacts
            // 
            this.gridContacts.AllowUserToAddRows = false;
            this.gridContacts.AllowUserToDeleteRows = false;
            this.gridContacts.AllowUserToOrderColumns = true;
            this.gridContacts.AllowUserToResizeColumns = false;
            this.gridContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridContacts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridContacts.ColumnHeadersHeight = 28;
            this.gridContacts.ColumnHeadersVisible = false;
            this.gridContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridContacts.Location = new System.Drawing.Point(5, 33);
            this.gridContacts.MultiSelect = false;
            this.gridContacts.Name = "gridContacts";
            this.gridContacts.ReadOnly = true;
            this.gridContacts.RowHeadersVisible = false;
            this.gridContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridContacts.Size = new System.Drawing.Size(565, 509);
            this.gridContacts.TabIndex = 1;
            this.gridContacts.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContacts_RowEnter);
            // 
            // headerContacts
            // 
            this.headerContacts.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewContact,
            this.btnEditContact,
            this.btnDeleteContact});
            this.headerContacts.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerContacts.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerContacts.Location = new System.Drawing.Point(5, 5);
            this.headerContacts.Name = "headerContacts";
            this.headerContacts.Size = new System.Drawing.Size(565, 28);
            this.headerContacts.TabIndex = 0;
            this.headerContacts.Values.Description = "";
            this.headerContacts.Values.Heading = "All Contacts for selected Company";
            this.headerContacts.Values.Image = null;
            // 
            // btnAddNewContact
            // 
            this.btnAddNewContact.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewContact.Text = "&Add New Contact";
            this.btnAddNewContact.UniqueName = "12D40F9C11154C0501B70C7C3B3AA133";
            this.btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click);
            // 
            // btnEditContact
            // 
            this.btnEditContact.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x;
            this.btnEditContact.Text = "&Edit Contact";
            this.btnEditContact.UniqueName = "2475550F785147A320868328A2B27568";
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            // 
            // btnDeleteContact
            // 
            this.btnDeleteContact.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteContact.Text = "&Delete Contact";
            this.btnDeleteContact.UniqueName = "56533A823FDA4EB750B3286803DC75DB";
            this.btnDeleteContact.Click += new System.EventHandler(this.btnDeleteContact_Click);
            // 
            // tabPageAddresses
            // 
            this.tabPageAddresses.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAddresses.Controls.Add(this.headerGroupPartyAddress);
            this.tabPageAddresses.Flags = 65534;
            this.tabPageAddresses.LastVisibleSet = true;
            this.tabPageAddresses.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAddresses.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageAddresses.Name = "tabPageAddresses";
            this.tabPageAddresses.Size = new System.Drawing.Size(575, 547);
            this.tabPageAddresses.Text = "Addresses";
            this.tabPageAddresses.ToolTipTitle = "Page ToolTip";
            this.tabPageAddresses.UniqueName = "3BC9246BC4C6442DB5AB4099CD1479E2";
            // 
            // headerGroupPartyAddress
            // 
            this.headerGroupPartyAddress.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddAddress,
            this.btnEditAddress});
            this.headerGroupPartyAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupPartyAddress.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupPartyAddress.Location = new System.Drawing.Point(0, 0);
            this.headerGroupPartyAddress.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupPartyAddress.Name = "headerGroupPartyAddress";
            // 
            // headerGroupPartyAddress.Panel
            // 
            this.headerGroupPartyAddress.Panel.Controls.Add(this.gridAddresses);
            this.headerGroupPartyAddress.Size = new System.Drawing.Size(575, 547);
            this.headerGroupPartyAddress.TabIndex = 0;
            this.headerGroupPartyAddress.ValuesPrimary.Heading = "Party Addresses";
            this.headerGroupPartyAddress.ValuesPrimary.Image = null;
            // 
            // btnAddAddress
            // 
            this.btnAddAddress.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddAddress.Text = "&Add New";
            this.btnAddAddress.UniqueName = "5C190011F6D3491C838F9C6C3E3091A8";
            this.btnAddAddress.Click += new System.EventHandler(this.btnAddAddress_Click);
            // 
            // btnEditAddress
            // 
            this.btnEditAddress.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditAddress.Text = "&Edit";
            this.btnEditAddress.UniqueName = "27D6BF8052AA42790EA69463AE022A5A";
            this.btnEditAddress.Click += new System.EventHandler(this.btnEditAddress_Click);
            // 
            // gridAddresses
            // 
            this.gridAddresses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAddresses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAddresses.ColumnHeadersHeight = 28;
            this.gridAddresses.ColumnHeadersVisible = false;
            this.gridAddresses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAddresses.Location = new System.Drawing.Point(0, 0);
            this.gridAddresses.Margin = new System.Windows.Forms.Padding(2);
            this.gridAddresses.Name = "gridAddresses";
            this.gridAddresses.ReadOnly = true;
            this.gridAddresses.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAddresses.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAddresses.RowTemplate.Height = 24;
            this.gridAddresses.Size = new System.Drawing.Size(573, 497);
            this.gridAddresses.TabIndex = 2;
            this.gridAddresses.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAddresses_RowEnter);
            // 
            // kryptonBreadCrumbItem1
            // 
            this.kryptonBreadCrumbItem1.LongText = "Customers";
            this.kryptonBreadCrumbItem1.ShortText = "Customers";
            this.kryptonBreadCrumbItem1.Tag = "C";
            // 
            // kryptonBreadCrumbItem2
            // 
            this.kryptonBreadCrumbItem2.ShortText = "Suppliers";
            this.kryptonBreadCrumbItem2.Tag = "S";
            // 
            // kryptonBreadCrumbItem3
            // 
            this.kryptonBreadCrumbItem3.ShortText = "Agents/Consultants";
            this.kryptonBreadCrumbItem3.Tag = "A";
            // 
            // PageParties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PageParties";
            this.Size = new System.Drawing.Size(873, 576);
            this.Load += new System.EventHandler(this.PageCustomers_Load);
            this.Resize += new System.EventHandler(this.PageCustomers_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParties.Panel)).EndInit();
            this.headerGroupParties.Panel.ResumeLayout(false);
            this.headerGroupParties.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParties)).EndInit();
            this.headerGroupParties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabCustomerInfo)).EndInit();
            this.tabCustomerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageContactInfo)).EndInit();
            this.tabPageContactInfo.ResumeLayout(false);
            this.tabPageContactInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete.Panel)).EndInit();
            this.headerGroupDelete.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete)).EndInit();
            this.headerGroupDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAddresses)).EndInit();
            this.tabPageAddresses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPartyAddress.Panel)).EndInit();
            this.headerGroupPartyAddress.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPartyAddress)).EndInit();
            this.headerGroupPartyAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAddresses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupParties;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewParty;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditParty;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteParty;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabCustomerInfo;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageContactInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader headerContacts;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewContact;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnEditContact;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnDeleteContact;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridContacts;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem2;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridParties;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchCompany;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefreshParties;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchParties;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAddresses;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupPartyAddress;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddAddress;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAddresses;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
    }
}
