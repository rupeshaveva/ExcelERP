namespace appExcelERP.Forms.PMC
{
    partial class frmAddEditProject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtProjectNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtProjectName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtProjectStartDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtProjectDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtProjectEndDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMyCompanyAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboProjectStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.headerGroupBillingInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewBillingAddress = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridClientBillingAddress = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.cboBillingClient = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewBillingClient = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.headerGroupSiteInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnCopyBillingInfoToSiteInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAddNewSiteAddress = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridClientSiteAddress = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.cboSiteClient = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewSiteClient = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectStatus)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBillingInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBillingInfo.Panel)).BeginInit();
            this.headerGroupBillingInfo.Panel.SuspendLayout();
            this.headerGroupBillingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientBillingAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBillingClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSiteInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSiteInfo.Panel)).BeginInit();
            this.headerGroupSiteInfo.Panel.SuspendLayout();
            this.headerGroupSiteInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientSiteAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSiteClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel1.Location = new System.Drawing.Point(4, 4);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(124, 21);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Project Code";
            // 
            // txtProjectNo
            // 
            this.txtProjectNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectNo.Location = new System.Drawing.Point(132, 4);
            this.txtProjectNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjectNo.Name = "txtProjectNo";
            this.txtProjectNo.Size = new System.Drawing.Size(292, 20);
            this.txtProjectNo.TabIndex = 1;
            this.txtProjectNo.TabStop = false;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.AutoSize = false;
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel2.Location = new System.Drawing.Point(428, 4);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(98, 21);
            this.kryptonLabel2.StateNormal.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel2.StateNormal.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonLabel2.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonLabel2.StateNormal.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Entry Date";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel3.Location = new System.Drawing.Point(4, 29);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(124, 22);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "Project Name";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel4.Location = new System.Drawing.Point(4, 55);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(124, 21);
            this.kryptonLabel4.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Text = "Tentative Start Date";
            // 
            // txtProjectName
            // 
            this.txtProjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtProjectName, 3);
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectName.Location = new System.Drawing.Point(132, 29);
            this.txtProjectName.Margin = new System.Windows.Forms.Padding(2);
            this.txtProjectName.MaxLength = 300;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(721, 20);
            this.txtProjectName.TabIndex = 8;
            this.txtProjectName.Validating += new System.ComponentModel.CancelEventHandler(this.txtProjectName_Validating);
            // 
            // dtProjectStartDate
            // 
            this.dtProjectStartDate.Location = new System.Drawing.Point(132, 55);
            this.dtProjectStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtProjectStartDate.Name = "dtProjectStartDate";
            this.dtProjectStartDate.Size = new System.Drawing.Size(180, 21);
            this.dtProjectStartDate.TabIndex = 9;
            // 
            // dtProjectDate
            // 
            this.dtProjectDate.Location = new System.Drawing.Point(530, 4);
            this.dtProjectDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtProjectDate.Name = "dtProjectDate";
            this.dtProjectDate.Size = new System.Drawing.Size(179, 21);
            this.dtProjectDate.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.06024F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.6988F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel1.Controls.Add(this.label21, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtProjectStartDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtProjectName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtProjectNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtProjectDate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtProjectEndDate, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMyCompanyAddress, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboProjectStatus, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2, 2, 8, 2);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0838F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.64246F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0838F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0838F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.78212F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(863, 179);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(5, 106);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 20);
            this.label21.TabIndex = 179;
            this.label21.Values.Text = "Status";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.AutoSize = false;
            this.kryptonLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel7.Location = new System.Drawing.Point(4, 80);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(124, 21);
            this.kryptonLabel7.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel7.TabIndex = 11;
            this.kryptonLabel7.Values.Text = "Tentative End Date";
            // 
            // dtProjectEndDate
            // 
            this.dtProjectEndDate.Location = new System.Drawing.Point(132, 80);
            this.dtProjectEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtProjectEndDate.Name = "dtProjectEndDate";
            this.dtProjectEndDate.Size = new System.Drawing.Size(179, 21);
            this.dtProjectEndDate.TabIndex = 12;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.AutoSize = false;
            this.tableLayoutPanel1.SetColumnSpan(this.kryptonLabel5, 2);
            this.kryptonLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(428, 55);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(425, 21);
            this.kryptonLabel5.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel5.TabIndex = 13;
            this.kryptonLabel5.Values.Text = "Company Address";
            // 
            // txtMyCompanyAddress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtMyCompanyAddress, 2);
            this.txtMyCompanyAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMyCompanyAddress.Location = new System.Drawing.Point(429, 81);
            this.txtMyCompanyAddress.Multiline = true;
            this.txtMyCompanyAddress.Name = "txtMyCompanyAddress";
            this.txtMyCompanyAddress.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.txtMyCompanyAddress, 2);
            this.txtMyCompanyAddress.Size = new System.Drawing.Size(423, 93);
            this.txtMyCompanyAddress.TabIndex = 14;
            this.txtMyCompanyAddress.TabStop = false;
            this.txtMyCompanyAddress.Text = "kryptonTextBox2";
            // 
            // cboProjectStatus
            // 
            this.cboProjectStatus.DropDownWidth = 200;
            this.cboProjectStatus.FormattingEnabled = true;
            this.cboProjectStatus.Location = new System.Drawing.Point(133, 106);
            this.cboProjectStatus.Name = "cboProjectStatus";
            this.cboProjectStatus.Size = new System.Drawing.Size(178, 21);
            this.cboProjectStatus.TabIndex = 180;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.headerGroupBillingInfo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.headerGroupSiteInfo, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 191);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(864, 279);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // headerGroupBillingInfo
            // 
            this.headerGroupBillingInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewBillingAddress});
            this.headerGroupBillingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupBillingInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupBillingInfo.HeaderVisibleSecondary = false;
            this.headerGroupBillingInfo.Location = new System.Drawing.Point(2, 2);
            this.headerGroupBillingInfo.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupBillingInfo.Name = "headerGroupBillingInfo";
            // 
            // headerGroupBillingInfo.Panel
            // 
            this.headerGroupBillingInfo.Panel.Controls.Add(this.gridClientBillingAddress);
            this.headerGroupBillingInfo.Panel.Controls.Add(this.cboBillingClient);
            this.headerGroupBillingInfo.Panel.Padding = new System.Windows.Forms.Padding(8);
            this.headerGroupBillingInfo.Size = new System.Drawing.Size(428, 275);
            this.headerGroupBillingInfo.TabIndex = 0;
            this.headerGroupBillingInfo.ValuesPrimary.Heading = "Billing Info";
            this.headerGroupBillingInfo.ValuesPrimary.Image = null;
            // 
            // btnAddNewBillingAddress
            // 
            this.btnAddNewBillingAddress.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewBillingAddress.Text = "NewBilling Address";
            this.btnAddNewBillingAddress.ToolTipBody = "Add a NewBilling Address for selected Client";
            this.btnAddNewBillingAddress.UniqueName = "7B9C25B113F74943BAA43A1625280F07";
            this.btnAddNewBillingAddress.Click += new System.EventHandler(this.btnAddNewBillingAddress_Click);
            // 
            // gridClientBillingAddress
            // 
            this.gridClientBillingAddress.AllowUserToAddRows = false;
            this.gridClientBillingAddress.AllowUserToDeleteRows = false;
            this.gridClientBillingAddress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridClientBillingAddress.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridClientBillingAddress.ColumnHeadersHeight = 28;
            this.gridClientBillingAddress.ColumnHeadersVisible = false;
            this.gridClientBillingAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClientBillingAddress.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridClientBillingAddress.Location = new System.Drawing.Point(8, 32);
            this.gridClientBillingAddress.Margin = new System.Windows.Forms.Padding(2);
            this.gridClientBillingAddress.MultiSelect = false;
            this.gridClientBillingAddress.Name = "gridClientBillingAddress";
            this.gridClientBillingAddress.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClientBillingAddress.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridClientBillingAddress.RowTemplate.Height = 24;
            this.gridClientBillingAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridClientBillingAddress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClientBillingAddress.Size = new System.Drawing.Size(410, 206);
            this.gridClientBillingAddress.TabIndex = 15;
            this.gridClientBillingAddress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClientBillingAddress_CellClick);
            this.gridClientBillingAddress.Validating += new System.ComponentModel.CancelEventHandler(this.gridClientBillingAddress_Validating);
            // 
            // cboBillingClient
            // 
            this.cboBillingClient.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewBillingClient});
            this.cboBillingClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboBillingClient.DropDownWidth = 430;
            this.cboBillingClient.Location = new System.Drawing.Point(8, 8);
            this.cboBillingClient.Margin = new System.Windows.Forms.Padding(2);
            this.cboBillingClient.Name = "cboBillingClient";
            this.cboBillingClient.Size = new System.Drawing.Size(410, 24);
            this.cboBillingClient.TabIndex = 13;
            this.cboBillingClient.Text = "kryptonComboBox5";
            this.cboBillingClient.SelectionChangeCommitted += new System.EventHandler(this.cboBillingClient_SelectionChangeCommitted);
            this.cboBillingClient.Validating += new System.ComponentModel.CancelEventHandler(this.cboBillingClient_Validating);
            // 
            // btnAddNewBillingClient
            // 
            this.btnAddNewBillingClient.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewBillingClient.ToolTipBody = "Add a New Client";
            this.btnAddNewBillingClient.UniqueName = "350B98F4328B4612F397D0E218BA247D";
            this.btnAddNewBillingClient.Click += new System.EventHandler(this.btnAddNewBillingClient_Click);
            // 
            // headerGroupSiteInfo
            // 
            this.headerGroupSiteInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnCopyBillingInfoToSiteInfo,
            this.btnAddNewSiteAddress});
            this.headerGroupSiteInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupSiteInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupSiteInfo.HeaderVisibleSecondary = false;
            this.headerGroupSiteInfo.Location = new System.Drawing.Point(434, 2);
            this.headerGroupSiteInfo.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupSiteInfo.Name = "headerGroupSiteInfo";
            // 
            // headerGroupSiteInfo.Panel
            // 
            this.headerGroupSiteInfo.Panel.Controls.Add(this.gridClientSiteAddress);
            this.headerGroupSiteInfo.Panel.Controls.Add(this.cboSiteClient);
            this.headerGroupSiteInfo.Panel.Padding = new System.Windows.Forms.Padding(8);
            this.headerGroupSiteInfo.Size = new System.Drawing.Size(428, 275);
            this.headerGroupSiteInfo.TabIndex = 1;
            this.headerGroupSiteInfo.ValuesPrimary.Heading = "Site Info";
            this.headerGroupSiteInfo.ValuesPrimary.Image = null;
            // 
            // btnCopyBillingInfoToSiteInfo
            // 
            this.btnCopyBillingInfoToSiteInfo.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnCopyBillingInfoToSiteInfo.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnCopyBillingInfoToSiteInfo.Text = "Same as Billing Info.";
            this.btnCopyBillingInfoToSiteInfo.UniqueName = "1B887E4378B8425AA392A56B3E8D2A83";
            this.btnCopyBillingInfoToSiteInfo.Click += new System.EventHandler(this.btnCopyBillingInfoToSiteInfo_Click);
            // 
            // btnAddNewSiteAddress
            // 
            this.btnAddNewSiteAddress.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewSiteAddress.Text = "New Site Address";
            this.btnAddNewSiteAddress.ToolTipBody = "Add a New Site Address for selected Client";
            this.btnAddNewSiteAddress.UniqueName = "BA2B3731CBF4461DBCA6D2FE6E59C485";
            this.btnAddNewSiteAddress.Click += new System.EventHandler(this.btnAddNewSiteAddress_Click);
            // 
            // gridClientSiteAddress
            // 
            this.gridClientSiteAddress.AllowUserToAddRows = false;
            this.gridClientSiteAddress.AllowUserToDeleteRows = false;
            this.gridClientSiteAddress.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridClientSiteAddress.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridClientSiteAddress.ColumnHeadersHeight = 28;
            this.gridClientSiteAddress.ColumnHeadersVisible = false;
            this.gridClientSiteAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClientSiteAddress.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridClientSiteAddress.Location = new System.Drawing.Point(8, 32);
            this.gridClientSiteAddress.Margin = new System.Windows.Forms.Padding(2);
            this.gridClientSiteAddress.MultiSelect = false;
            this.gridClientSiteAddress.Name = "gridClientSiteAddress";
            this.gridClientSiteAddress.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridClientSiteAddress.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridClientSiteAddress.RowTemplate.Height = 24;
            this.gridClientSiteAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridClientSiteAddress.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridClientSiteAddress.Size = new System.Drawing.Size(410, 204);
            this.gridClientSiteAddress.TabIndex = 17;
            this.gridClientSiteAddress.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridClientSiteAddress_CellClick);
            this.gridClientSiteAddress.Validating += new System.ComponentModel.CancelEventHandler(this.gridClientSiteAddress_Validating);
            // 
            // cboSiteClient
            // 
            this.cboSiteClient.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewSiteClient});
            this.cboSiteClient.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboSiteClient.DropDownWidth = 430;
            this.cboSiteClient.Location = new System.Drawing.Point(8, 8);
            this.cboSiteClient.Margin = new System.Windows.Forms.Padding(2);
            this.cboSiteClient.Name = "cboSiteClient";
            this.cboSiteClient.Size = new System.Drawing.Size(410, 24);
            this.cboSiteClient.TabIndex = 13;
            this.cboSiteClient.Text = "kryptonComboBox6";
            this.cboSiteClient.SelectionChangeCommitted += new System.EventHandler(this.cboSiteClient_SelectionChangeCommitted);
            this.cboSiteClient.Validating += new System.ComponentModel.CancelEventHandler(this.cboSiteClient_Validating);
            // 
            // btnAddNewSiteClient
            // 
            this.btnAddNewSiteClient.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewSiteClient.ToolTipBody = "Add a New Client";
            this.btnAddNewSiteClient.UniqueName = "1EFE3DEB442C4D3712A584C6710C8659";
            this.btnAddNewSiteClient.Click += new System.EventHandler(this.btnAddNewSiteClient_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(654, 473);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 26);
            this.btnOK.TabIndex = 17;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(766, 473);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 26);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(879, 509);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditProject";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditProject";
            this.Load += new System.EventHandler(this.frmAddEditProject_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectStatus)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBillingInfo.Panel)).EndInit();
            this.headerGroupBillingInfo.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBillingInfo)).EndInit();
            this.headerGroupBillingInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridClientBillingAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBillingClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSiteInfo.Panel)).EndInit();
            this.headerGroupSiteInfo.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSiteInfo)).EndInit();
            this.headerGroupSiteInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridClientSiteAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSiteClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtProjectName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtProjectNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtProjectStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtProjectDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupBillingInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSiteInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCopyBillingInfoToSiteInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBillingClient;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSiteClient;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridClientBillingAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridClientSiteAddress;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewBillingAddress;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewBillingClient;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewSiteAddress;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewSiteClient;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtProjectEndDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMyCompanyAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label21;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProjectStatus;
    }
}