namespace appExcelERP.Forms.CRM.SalesOrder
{
    partial class frmSO_Primary
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
            this.headerGroupQuotation = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSelectSalesQuotation = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.cboProjects = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewProject = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtQuotationNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboClient = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewCustomer = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtInstallationServicePoExpiryDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtInstallationServicePoValidDays = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtInstallationServicePoNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblPOSource = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtInstallationServicePoDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dtMaterialSupplyPoExpiryDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMaterialSupplyPoValidDays = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMaterialSupplyPoNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtMaterialSupplyPoDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label21 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSalesOrderNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboSalesOrderStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboPOSources = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtSalesOrderDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation.Panel)).BeginInit();
            this.headerGroupQuotation.Panel.SuspendLayout();
            this.headerGroupQuotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesOrderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPOSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupQuotation
            // 
            this.headerGroupQuotation.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSelectSalesQuotation});
            this.headerGroupQuotation.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupQuotation.HeaderVisibleSecondary = false;
            this.headerGroupQuotation.Location = new System.Drawing.Point(12, 262);
            this.headerGroupQuotation.Name = "headerGroupQuotation";
            // 
            // headerGroupQuotation.Panel
            // 
            this.headerGroupQuotation.Panel.Controls.Add(this.cboProjects);
            this.headerGroupQuotation.Panel.Controls.Add(this.kryptonLabel6);
            this.headerGroupQuotation.Panel.Controls.Add(this.txtQuotationNumber);
            this.headerGroupQuotation.Panel.Controls.Add(this.cboClient);
            this.headerGroupQuotation.Panel.Controls.Add(this.kryptonLabel9);
            this.headerGroupQuotation.Panel.Controls.Add(this.kryptonLabel10);
            this.headerGroupQuotation.Size = new System.Drawing.Size(409, 201);
            this.headerGroupQuotation.TabIndex = 186;
            this.headerGroupQuotation.ValuesPrimary.Heading = "";
            this.headerGroupQuotation.ValuesPrimary.Image = null;
            this.headerGroupQuotation.Validating += new System.ComponentModel.CancelEventHandler(this.headerGroupQuotation_Validating);
            // 
            // btnSelectSalesQuotation
            // 
            this.btnSelectSalesQuotation.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnSelectSalesQuotation.Text = "Select Quotation";
            this.btnSelectSalesQuotation.UniqueName = "94712FA5055842ECA6937FA0AF8091D2";
            this.btnSelectSalesQuotation.Click += new System.EventHandler(this.btnSelectSalesQuotation_Click);
            // 
            // cboProjects
            // 
            this.cboProjects.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewProject});
            this.cboProjects.DropDownWidth = 121;
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(4, 137);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(389, 24);
            this.cboProjects.TabIndex = 178;
            this.cboProjects.Validating += new System.ComponentModel.CancelEventHandler(this.cboProjects_Validating);
            // 
            // btnAddNewProject
            // 
            this.btnAddNewProject.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewProject.UniqueName = "323D61291D974FAB0B9CA89FCB57D8F2";
            this.btnAddNewProject.Click += new System.EventHandler(this.btnAddNewProject_Click);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(4, 111);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel6.TabIndex = 177;
            this.kryptonLabel6.Values.Text = "Select Project";
            // 
            // txtQuotationNumber
            // 
            this.txtQuotationNumber.Location = new System.Drawing.Point(4, 28);
            this.txtQuotationNumber.Name = "txtQuotationNumber";
            this.txtQuotationNumber.ReadOnly = true;
            this.txtQuotationNumber.Size = new System.Drawing.Size(389, 23);
            this.txtQuotationNumber.TabIndex = 1;
            this.txtQuotationNumber.TabStop = false;
            this.txtQuotationNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuotationNumber_Validating);
            // 
            // cboClient
            // 
            this.cboClient.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewCustomer});
            this.cboClient.DropDownWidth = 121;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(4, 84);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(389, 24);
            this.cboClient.TabIndex = 8;
            this.cboClient.Validating += new System.ComponentModel.CancelEventHandler(this.cboClient_Validating);
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewCustomer.UniqueName = "B3EB95F9D00E42EBE1B71C0039C18A52";
            this.btnAddNewCustomer.Click += new System.EventHandler(this.btnAddNewCustomer_Click);
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(4, 58);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel9.TabIndex = 7;
            this.kryptonLabel9.Values.Text = "Client Name";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(4, 6);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel10.TabIndex = 0;
            this.kryptonLabel10.Values.Text = "Quotation Info.";
            // 
            // dtInstallationServicePoExpiryDate
            // 
            this.dtInstallationServicePoExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.dtInstallationServicePoExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInstallationServicePoExpiryDate.Location = new System.Drawing.Point(307, 39);
            this.dtInstallationServicePoExpiryDate.Name = "dtInstallationServicePoExpiryDate";
            this.dtInstallationServicePoExpiryDate.Size = new System.Drawing.Size(91, 21);
            this.dtInstallationServicePoExpiryDate.TabIndex = 147;
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(238, 39);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel11.TabIndex = 146;
            this.kryptonLabel11.Values.Text = "Expiry Date";
            // 
            // txtInstallationServicePoValidDays
            // 
            this.txtInstallationServicePoValidDays.Location = new System.Drawing.Point(130, 37);
            this.txtInstallationServicePoValidDays.MaxLength = 3;
            this.txtInstallationServicePoValidDays.Name = "txtInstallationServicePoValidDays";
            this.txtInstallationServicePoValidDays.Size = new System.Drawing.Size(80, 23);
            this.txtInstallationServicePoValidDays.TabIndex = 145;
            this.txtInstallationServicePoValidDays.Validating += new System.ComponentModel.CancelEventHandler(this.txtInstallationServicePoValidDays_Validating);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(8, 39);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(126, 20);
            this.kryptonLabel12.TabIndex = 144;
            this.kryptonLabel12.Values.Text = "Completion Deadline";
            // 
            // txtInstallationServicePoNo
            // 
            this.txtInstallationServicePoNo.Location = new System.Drawing.Point(48, 11);
            this.txtInstallationServicePoNo.Name = "txtInstallationServicePoNo";
            this.txtInstallationServicePoNo.Size = new System.Drawing.Size(206, 23);
            this.txtInstallationServicePoNo.TabIndex = 139;
            this.txtInstallationServicePoNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtInstallationServicePoNo_Validating);
            // 
            // lblPOSource
            // 
            this.lblPOSource.Location = new System.Drawing.Point(9, 42);
            this.lblPOSource.Name = "lblPOSource";
            this.lblPOSource.Size = new System.Drawing.Size(67, 20);
            this.lblPOSource.TabIndex = 187;
            this.lblPOSource.Values.Text = "PO Source";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dtInstallationServicePoDate
            // 
            this.dtInstallationServicePoDate.CustomFormat = "dd/MM/yyyy";
            this.dtInstallationServicePoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInstallationServicePoDate.Location = new System.Drawing.Point(307, 10);
            this.dtInstallationServicePoDate.Name = "dtInstallationServicePoDate";
            this.dtInstallationServicePoDate.Size = new System.Drawing.Size(91, 21);
            this.dtInstallationServicePoDate.TabIndex = 136;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(9, 69);
            this.kryptonHeaderGroup1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtMaterialSupplyPoExpiryDate);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel7);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtMaterialSupplyPoValidDays);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel8);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtMaterialSupplyPoNo);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtMaterialSupplyPoDate);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label5);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(412, 92);
            this.kryptonHeaderGroup1.TabIndex = 182;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Material Supply PO";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // dtMaterialSupplyPoExpiryDate
            // 
            this.dtMaterialSupplyPoExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.dtMaterialSupplyPoExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMaterialSupplyPoExpiryDate.Location = new System.Drawing.Point(316, 40);
            this.dtMaterialSupplyPoExpiryDate.Name = "dtMaterialSupplyPoExpiryDate";
            this.dtMaterialSupplyPoExpiryDate.Size = new System.Drawing.Size(82, 21);
            this.dtMaterialSupplyPoExpiryDate.TabIndex = 143;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(244, 40);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel7.TabIndex = 142;
            this.kryptonLabel7.Values.Text = "Expiry Date";
            // 
            // txtMaterialSupplyPoValidDays
            // 
            this.txtMaterialSupplyPoValidDays.Location = new System.Drawing.Point(111, 37);
            this.txtMaterialSupplyPoValidDays.MaxLength = 3;
            this.txtMaterialSupplyPoValidDays.Name = "txtMaterialSupplyPoValidDays";
            this.txtMaterialSupplyPoValidDays.Size = new System.Drawing.Size(80, 23);
            this.txtMaterialSupplyPoValidDays.TabIndex = 141;
            this.txtMaterialSupplyPoValidDays.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaterialSupplyPoValidDays_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(7, 40);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel8.TabIndex = 140;
            this.kryptonLabel8.Values.Text = "Delivery Deadline";
            // 
            // txtMaterialSupplyPoNo
            // 
            this.txtMaterialSupplyPoNo.Location = new System.Drawing.Point(50, 10);
            this.txtMaterialSupplyPoNo.Name = "txtMaterialSupplyPoNo";
            this.txtMaterialSupplyPoNo.Size = new System.Drawing.Size(204, 23);
            this.txtMaterialSupplyPoNo.TabIndex = 139;
            this.txtMaterialSupplyPoNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaterialSupplyPoNo_Validating);
            // 
            // dtMaterialSupplyPoDate
            // 
            this.dtMaterialSupplyPoDate.CustomFormat = "dd/MM/yyyy";
            this.dtMaterialSupplyPoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMaterialSupplyPoDate.Location = new System.Drawing.Point(316, 12);
            this.dtMaterialSupplyPoDate.Name = "dtMaterialSupplyPoDate";
            this.dtMaterialSupplyPoDate.Size = new System.Drawing.Size(82, 21);
            this.dtMaterialSupplyPoDate.TabIndex = 136;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(280, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 133;
            this.label5.Values.Text = "Date";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel1.TabIndex = 138;
            this.kryptonLabel1.Values.Text = "PO No.";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(307, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 28);
            this.btnClose.TabIndex = 181;
            this.btnClose.Values.Text = "&Cancel";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(201, 469);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 28);
            this.btnSave.TabIndex = 180;
            this.btnSave.Values.Text = "&OK";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 176;
            this.label3.Values.Text = "SO No.";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(249, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 20);
            this.label21.TabIndex = 178;
            this.label21.Values.Text = "Status";
            // 
            // txtSalesOrderNo
            // 
            this.txtSalesOrderNo.Location = new System.Drawing.Point(75, 16);
            this.txtSalesOrderNo.Name = "txtSalesOrderNo";
            this.txtSalesOrderNo.Size = new System.Drawing.Size(197, 23);
            this.txtSalesOrderNo.TabIndex = 177;
            // 
            // cboSalesOrderStatus
            // 
            this.cboSalesOrderStatus.DropDownWidth = 200;
            this.cboSalesOrderStatus.FormattingEnabled = true;
            this.cboSalesOrderStatus.Location = new System.Drawing.Point(299, 41);
            this.cboSalesOrderStatus.Name = "cboSalesOrderStatus";
            this.cboSalesOrderStatus.Size = new System.Drawing.Size(122, 21);
            this.cboSalesOrderStatus.TabIndex = 179;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 11);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel4.TabIndex = 138;
            this.kryptonLabel4.Values.Text = "PO No.";
            // 
            // cboPOSources
            // 
            this.cboPOSources.DropDownWidth = 200;
            this.cboPOSources.FormattingEnabled = true;
            this.cboPOSources.Location = new System.Drawing.Point(75, 43);
            this.cboPOSources.Name = "cboPOSources";
            this.cboPOSources.Size = new System.Drawing.Size(156, 21);
            this.cboPOSources.TabIndex = 188;
            this.cboPOSources.Validating += new System.ComponentModel.CancelEventHandler(this.cboPOSources_Validating);
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(9, 165);
            this.kryptonHeaderGroup2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.dtInstallationServicePoExpiryDate);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel11);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.txtInstallationServicePoValidDays);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel12);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.txtInstallationServicePoNo);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.dtInstallationServicePoDate);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(412, 92);
            this.kryptonHeaderGroup2.TabIndex = 185;
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Installation/Services PO";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = null;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(271, 12);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel5.TabIndex = 133;
            this.kryptonLabel5.Values.Text = "Date";
            // 
            // dtSalesOrderDate
            // 
            this.dtSalesOrderDate.CustomFormat = "dd/MM/yyyy";
            this.dtSalesOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalesOrderDate.Location = new System.Drawing.Point(331, 16);
            this.dtSalesOrderDate.Name = "dtSalesOrderDate";
            this.dtSalesOrderDate.Size = new System.Drawing.Size(90, 21);
            this.dtSalesOrderDate.TabIndex = 184;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(274, 16);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel2.TabIndex = 183;
            this.kryptonLabel2.Values.Text = "SO Date";
            // 
            // frmSO_Primary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(438, 523);
            this.Controls.Add(this.headerGroupQuotation);
            this.Controls.Add(this.lblPOSource);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtSalesOrderNo);
            this.Controls.Add(this.cboSalesOrderStatus);
            this.Controls.Add(this.cboPOSources);
            this.Controls.Add(this.kryptonHeaderGroup2);
            this.Controls.Add(this.dtSalesOrderDate);
            this.Controls.Add(this.kryptonLabel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSO_Primary";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Sales Order (Primary)";
            this.Load += new System.EventHandler(this.frmSO_Primary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation.Panel)).EndInit();
            this.headerGroupQuotation.Panel.ResumeLayout(false);
            this.headerGroupQuotation.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation)).EndInit();
            this.headerGroupQuotation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesOrderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPOSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupQuotation;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSelectSalesQuotation;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQuotationNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboClient;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtInstallationServicePoExpiryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtInstallationServicePoValidDays;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtInstallationServicePoNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPOSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtMaterialSupplyPoExpiryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMaterialSupplyPoValidDays;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMaterialSupplyPoNo;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtMaterialSupplyPoDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label21;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSalesOrderNo;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSalesOrderStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboPOSources;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtInstallationServicePoDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtSalesOrderDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProjects;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewProject;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewCustomer;
    }
}