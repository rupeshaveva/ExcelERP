namespace appExcelERP.Forms
{
    partial class frmSalesLead
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
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboProjectSector = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboAssignedTo = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboCurrency = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEstimatedValue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboLeadSources = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboSalesLeadStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLeadNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtLeadDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtLeadRequirements = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageLeadRequirements = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageLeadCloseReason = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtReasonLost = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.btnAddProjectSector = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.headerGroupCompany = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewCompany = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAddNewContact = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridContacts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.cboCompanies = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddLeadSource = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboAgencies = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddAgency = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtGeneratedBy = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectSector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAssignedTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeadSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesLeadStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageLeadRequirements)).BeginInit();
            this.tabPageLeadRequirements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageLeadCloseReason)).BeginInit();
            this.tabPageLeadCloseReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany.Panel)).BeginInit();
            this.headerGroupCompany.Panel.SuspendLayout();
            this.headerGroupCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(653, 573);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 28);
            this.btnSave.TabIndex = 23;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(759, 573);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 28);
            this.btnClose.TabIndex = 24;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(631, 282);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 20);
            this.label17.TabIndex = 13;
            this.label17.Target = this.cboProjectSector;
            this.label17.Values.Text = "&Project Sector";
            // 
            // cboProjectSector
            // 
            this.cboProjectSector.DropDownWidth = 296;
            this.cboProjectSector.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProjectSector.FormattingEnabled = true;
            this.cboProjectSector.Location = new System.Drawing.Point(636, 301);
            this.cboProjectSector.Margin = new System.Windows.Forms.Padding(4);
            this.cboProjectSector.Name = "cboProjectSector";
            this.cboProjectSector.Size = new System.Drawing.Size(192, 21);
            this.cboProjectSector.TabIndex = 14;
            this.cboProjectSector.Validating += new System.ComponentModel.CancelEventHandler(this.cboProjectSector_Validating);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(491, 10);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 20);
            this.label16.TabIndex = 19;
            this.label16.Values.Text = "&Assigned To";
            // 
            // cboAssignedTo
            // 
            this.cboAssignedTo.DropDownWidth = 297;
            this.cboAssignedTo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAssignedTo.FormattingEnabled = true;
            this.cboAssignedTo.Location = new System.Drawing.Point(493, 29);
            this.cboAssignedTo.Margin = new System.Windows.Forms.Padding(4);
            this.cboAssignedTo.Name = "cboAssignedTo";
            this.cboAssignedTo.Size = new System.Drawing.Size(217, 21);
            this.cboAssignedTo.TabIndex = 20;
            this.cboAssignedTo.Validating += new System.ComponentModel.CancelEventHandler(this.cboAssignedTo_Validating);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(282, 10);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 20);
            this.label12.TabIndex = 17;
            this.label12.Values.Text = "&Generated By";
            // 
            // cboCurrency
            // 
            this.cboCurrency.DropDownWidth = 56;
            this.cboCurrency.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCurrency.FormattingEnabled = true;
            this.cboCurrency.Location = new System.Drawing.Point(570, 301);
            this.cboCurrency.Margin = new System.Windows.Forms.Padding(4);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Size = new System.Drawing.Size(56, 21);
            this.cboCurrency.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(482, 282);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 10;
            this.label5.Values.Text = "Estimated &Value";
            // 
            // txtEstimatedValue
            // 
            this.txtEstimatedValue.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimatedValue.Location = new System.Drawing.Point(479, 301);
            this.txtEstimatedValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstimatedValue.Name = "txtEstimatedValue";
            this.txtEstimatedValue.Size = new System.Drawing.Size(82, 20);
            this.txtEstimatedValue.TabIndex = 11;
            this.txtEstimatedValue.Text = "99999999.00";
            this.txtEstimatedValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEstimatedValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtEstimatedValue_Validating);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 282);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 7;
            this.label4.Target = this.cboLeadSources;
            this.label4.Values.Text = "&Lead source";
            // 
            // cboLeadSources
            // 
            this.cboLeadSources.DropDownWidth = 296;
            this.cboLeadSources.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLeadSources.FormattingEnabled = true;
            this.cboLeadSources.Location = new System.Drawing.Point(17, 301);
            this.cboLeadSources.Margin = new System.Windows.Forms.Padding(4);
            this.cboLeadSources.Name = "cboLeadSources";
            this.cboLeadSources.Size = new System.Drawing.Size(168, 21);
            this.cboLeadSources.TabIndex = 8;
            this.cboLeadSources.SelectionChangeCommitted += new System.EventHandler(this.cboLeadSources_SelectionChangeCommitted);
            this.cboLeadSources.Validating += new System.ComponentModel.CancelEventHandler(this.cboLeadSources_Validating);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(726, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 4;
            this.label3.Target = this.cboSalesLeadStatus;
            this.label3.Values.Text = "Stat&us";
            // 
            // cboSalesLeadStatus
            // 
            this.cboSalesLeadStatus.DropDownWidth = 296;
            this.cboSalesLeadStatus.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSalesLeadStatus.FormattingEnabled = true;
            this.cboSalesLeadStatus.Location = new System.Drawing.Point(726, 29);
            this.cboSalesLeadStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboSalesLeadStatus.Name = "cboSalesLeadStatus";
            this.cboSalesLeadStatus.Size = new System.Drawing.Size(131, 21);
            this.cboSalesLeadStatus.TabIndex = 5;
        //    this.cboSalesLeadStatus.SelectedIndexChanged += new System.EventHandler(this.cboSalesLeadStatus_SelectedIndexChanged);
            this.cboSalesLeadStatus.SelectionChangeCommitted += new System.EventHandler(this.cboSalesLeadStatus_SelectionChangeCommitted);
            this.cboSalesLeadStatus.Validating += new System.ComponentModel.CancelEventHandler(this.cboSalesLeadStatus_Validating);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(171, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 2;
            this.label2.Values.Text = "Lead &Date";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Lead No.";
           // this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLeadNumber
            // 
            this.txtLeadNumber.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeadNumber.Location = new System.Drawing.Point(17, 29);
            this.txtLeadNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtLeadNumber.Name = "txtLeadNumber";
            this.txtLeadNumber.ReadOnly = true;
            this.txtLeadNumber.Size = new System.Drawing.Size(146, 20);
            this.txtLeadNumber.TabIndex = 1;
            this.txtLeadNumber.Text = "XL/SL/0006/2014-15";
            // 
            // dtLeadDate
            // 
            this.dtLeadDate.CustomFormat = "dd-MM-yyyy";
            this.dtLeadDate.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtLeadDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLeadDate.Location = new System.Drawing.Point(171, 29);
            this.dtLeadDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtLeadDate.Name = "dtLeadDate";
            this.dtLeadDate.Size = new System.Drawing.Size(99, 21);
            this.dtLeadDate.TabIndex = 3;
            // 
            // txtLeadRequirements
            // 
            this.txtLeadRequirements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLeadRequirements.Font = new System.Drawing.Font("Verdana", 10.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeadRequirements.Location = new System.Drawing.Point(0, 0);
            this.txtLeadRequirements.Name = "txtLeadRequirements";
            this.txtLeadRequirements.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtLeadRequirements.Size = new System.Drawing.Size(839, 212);
            this.txtLeadRequirements.TabIndex = 16;
            this.txtLeadRequirements.Text = "";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SquareEqualSmall;
            this.kryptonNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.errorProvider1.SetIconAlignment(this.kryptonNavigator1, System.Windows.Forms.ErrorIconAlignment.TopRight);
            this.kryptonNavigator1.Location = new System.Drawing.Point(17, 329);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageLeadRequirements,
            this.tabPageLeadCloseReason});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(841, 238);
            this.kryptonNavigator1.TabIndex = 40;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // tabPageLeadRequirements
            // 
            this.tabPageLeadRequirements.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageLeadRequirements.Controls.Add(this.txtLeadRequirements);
            this.tabPageLeadRequirements.Flags = 65534;
            this.tabPageLeadRequirements.LastVisibleSet = true;
            this.tabPageLeadRequirements.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageLeadRequirements.Name = "tabPageLeadRequirements";
            this.tabPageLeadRequirements.Size = new System.Drawing.Size(839, 212);
            this.tabPageLeadRequirements.Text = "Lead Requirements";
            this.tabPageLeadRequirements.ToolTipTitle = "Page ToolTip";
            this.tabPageLeadRequirements.UniqueName = "E750F7271DCA4F9A5A816784E85F070F";
            // 
            // tabPageLeadCloseReason
            // 
            this.tabPageLeadCloseReason.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageLeadCloseReason.Controls.Add(this.txtReasonLost);
            this.tabPageLeadCloseReason.Flags = 65534;
            this.tabPageLeadCloseReason.LastVisibleSet = true;
            this.tabPageLeadCloseReason.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageLeadCloseReason.Name = "tabPageLeadCloseReason";
            this.tabPageLeadCloseReason.Size = new System.Drawing.Size(839, 212);
            this.tabPageLeadCloseReason.Text = "Reason for Loosing ";
            this.tabPageLeadCloseReason.ToolTipTitle = "Page ToolTip";
            this.tabPageLeadCloseReason.UniqueName = "472670E573EE46E04691F167D74D191D";
            // 
            // txtReasonLost
            // 
            this.txtReasonLost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReasonLost.Location = new System.Drawing.Point(0, 0);
            this.txtReasonLost.Multiline = true;
            this.txtReasonLost.Name = "txtReasonLost";
            this.txtReasonLost.Size = new System.Drawing.Size(839, 212);
            this.txtReasonLost.TabIndex = 1;
            this.txtReasonLost.Validating += new System.ComponentModel.CancelEventHandler(this.txtReasonLost_Validating);
            // 
            // btnAddProjectSector
            // 
            this.btnAddProjectSector.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            this.btnAddProjectSector.Location = new System.Drawing.Point(834, 302);
            this.btnAddProjectSector.Name = "btnAddProjectSector";
            this.btnAddProjectSector.Size = new System.Drawing.Size(23, 19);
            this.btnAddProjectSector.TabIndex = 15;
            this.btnAddProjectSector.Values.Text = "...";
            this.btnAddProjectSector.Click += new System.EventHandler(this.btnAddProjectSector_Click);
            // 
            // headerGroupCompany
            // 
            this.headerGroupCompany.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewCompany,
            this.btnAddNewContact});
            this.headerGroupCompany.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupCompany.HeaderVisibleSecondary = false;
            this.headerGroupCompany.Location = new System.Drawing.Point(17, 55);
            this.headerGroupCompany.Name = "headerGroupCompany";
            // 
            // headerGroupCompany.Panel
            // 
            this.headerGroupCompany.Panel.Controls.Add(this.gridContacts);
            this.headerGroupCompany.Panel.Controls.Add(this.cboCompanies);
            this.headerGroupCompany.Panel.Margin = new System.Windows.Forms.Padding(3);
            this.headerGroupCompany.Panel.Padding = new System.Windows.Forms.Padding(10);
            this.headerGroupCompany.Size = new System.Drawing.Size(841, 221);
            this.headerGroupCompany.TabIndex = 6;
            this.headerGroupCompany.ValuesPrimary.Heading = "Client Info.";
            this.headerGroupCompany.ValuesPrimary.Image = null;
            // 
            // btnAddNewCompany
            // 
            this.btnAddNewCompany.Text = "Add New &Company";
            this.btnAddNewCompany.UniqueName = "A1AE3A41EA7E4C02749AF846D9DFA57B";
            this.btnAddNewCompany.Click += new System.EventHandler(this.btnAddNewCompany_Click);
            // 
            // btnAddNewContact
            // 
            this.btnAddNewContact.Text = "Add New Con&tact";
            this.btnAddNewContact.UniqueName = "ADBC6492DE004822ADA1CFC327605BF1";
            this.btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click_1);
            // 
            // gridContacts
            // 
            this.gridContacts.AllowUserToAddRows = false;
            this.gridContacts.AllowUserToDeleteRows = false;
            this.gridContacts.AllowUserToOrderColumns = true;
            this.gridContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridContacts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridContacts.ColumnHeadersHeight = 28;
            this.gridContacts.ColumnHeadersVisible = false;
            this.gridContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridContacts.Location = new System.Drawing.Point(13, 32);
            this.gridContacts.Name = "gridContacts";
            this.gridContacts.ReadOnly = true;
            this.gridContacts.RowHeadersVisible = false;
            this.gridContacts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridContacts.Size = new System.Drawing.Size(814, 147);
            this.gridContacts.TabIndex = 1;
            this.gridContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContacts_CellClick);
        //    this.gridContacts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridContacts_CellDoubleClick);
            this.gridContacts.Validating += new System.ComponentModel.CancelEventHandler(this.gridContacts_Validating);
            // 
            // cboCompanies
            // 
            this.cboCompanies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCompanies.DropDownWidth = 296;
            this.cboCompanies.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompanies.FormattingEnabled = true;
            this.cboCompanies.Location = new System.Drawing.Point(13, 10);
            this.cboCompanies.Margin = new System.Windows.Forms.Padding(4);
            this.cboCompanies.Name = "cboCompanies";
            this.cboCompanies.Size = new System.Drawing.Size(814, 21);
            this.cboCompanies.TabIndex = 0;
            this.cboCompanies.SelectedIndexChanged += new System.EventHandler(this.cboCompanies_SelectedIndexChanged);
            this.cboCompanies.Validating += new System.ComponentModel.CancelEventHandler(this.cboCompanies_Validating);
            // 
            // btnAddLeadSource
            // 
            this.btnAddLeadSource.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            this.btnAddLeadSource.Location = new System.Drawing.Point(189, 302);
            this.btnAddLeadSource.Name = "btnAddLeadSource";
            this.btnAddLeadSource.Size = new System.Drawing.Size(23, 19);
            this.btnAddLeadSource.TabIndex = 9;
            this.btnAddLeadSource.Values.Text = "...";
            this.btnAddLeadSource.Click += new System.EventHandler(this.btnAddLeadSource_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(217, 282);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(128, 20);
            this.kryptonLabel1.TabIndex = 36;
            this.kryptonLabel1.Values.Text = "&Agency or Consultant";
            // 
            // cboAgencies
            // 
            this.cboAgencies.DropDownWidth = 219;
            this.cboAgencies.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAgencies.FormattingEnabled = true;
            this.cboAgencies.Location = new System.Drawing.Point(217, 301);
            this.cboAgencies.Margin = new System.Windows.Forms.Padding(4);
            this.cboAgencies.Name = "cboAgencies";
            this.cboAgencies.Size = new System.Drawing.Size(229, 21);
            this.cboAgencies.TabIndex = 37;
            // 
            // btnAddAgency
            // 
            this.btnAddAgency.ButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Cluster;
            this.btnAddAgency.Location = new System.Drawing.Point(453, 301);
            this.btnAddAgency.Name = "btnAddAgency";
            this.btnAddAgency.Size = new System.Drawing.Size(23, 19);
            this.btnAddAgency.TabIndex = 38;
            this.btnAddAgency.Values.Text = "...";
            this.btnAddAgency.Click += new System.EventHandler(this.btnAddAgency_Click);
            // 
            // txtGeneratedBy
            // 
            this.txtGeneratedBy.Location = new System.Drawing.Point(279, 29);
            this.txtGeneratedBy.Name = "txtGeneratedBy";
            this.txtGeneratedBy.ReadOnly = true;
            this.txtGeneratedBy.Size = new System.Drawing.Size(206, 20);
            this.txtGeneratedBy.TabIndex = 39;
            this.txtGeneratedBy.TabStop = false;
            // 
            // frmSalesLead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(880, 613);
            this.Controls.Add(this.kryptonNavigator1);
            this.Controls.Add(this.txtGeneratedBy);
            this.Controls.Add(this.btnAddAgency);
            this.Controls.Add(this.cboAgencies);
            this.Controls.Add(this.btnAddLeadSource);
            this.Controls.Add(this.cboLeadSources);
            this.Controls.Add(this.headerGroupCompany);
            this.Controls.Add(this.btnAddProjectSector);
            this.Controls.Add(this.cboProjectSector);
            this.Controls.Add(this.cboAssignedTo);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.txtEstimatedValue);
            this.Controls.Add(this.txtLeadNumber);
            this.Controls.Add(this.cboSalesLeadStatus);
            this.Controls.Add(this.dtLeadDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesLead";
            this.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD/EDIT SALES LEAD";
            this.Load += new System.EventHandler(this.frmSalesLead_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectSector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAssignedTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCurrency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeadSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesLeadStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageLeadRequirements)).EndInit();
            this.tabPageLeadRequirements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageLeadCloseReason)).EndInit();
            this.tabPageLeadCloseReason.ResumeLayout(false);
            this.tabPageLeadCloseReason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany.Panel)).EndInit();
            this.headerGroupCompany.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany)).EndInit();
            this.headerGroupCompany.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAgencies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProjectSector;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label16;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboAssignedTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label12;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCurrency;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEstimatedValue;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLeadNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSalesLeadStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtLeadDate;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtLeadRequirements;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddProjectSector;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupCompany;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewCompany;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCompanies;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridContacts;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewContact;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddLeadSource;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboLeadSources;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAddAgency;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboAgencies;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGeneratedBy;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageLeadRequirements;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageLeadCloseReason;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtReasonLost;
    }
}