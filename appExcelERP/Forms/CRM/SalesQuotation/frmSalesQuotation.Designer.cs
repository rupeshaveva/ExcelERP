namespace appExcelERP.Forms
{
    partial class frmSalesQuotation
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
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboSalesRepresentative = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtQuotationDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.cboQuotationPriority = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label21 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtQuotationNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboQuotationStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtQuotationValidDays = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.headerGroupEnquiry = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSelectSalesEnquiries = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtProjectName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtEnquiryNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboProjectLocation = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboProjectSector = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboClient = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtQuotationExpiryDate = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.headerGroupQuotation = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tabRemarks = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageQuotationRemarks = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.tabPageQuotationCloseReason = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtReasonClosedLost = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboBOQRepresentative = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesRepresentative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEnquiry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEnquiry.Panel)).BeginInit();
            this.headerGroupEnquiry.Panel.SuspendLayout();
            this.headerGroupEnquiry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectSector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation.Panel)).BeginInit();
            this.headerGroupQuotation.Panel.SuspendLayout();
            this.headerGroupQuotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRemarks)).BeginInit();
            this.tabRemarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageQuotationRemarks)).BeginInit();
            this.tabPageQuotationRemarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageQuotationCloseReason)).BeginInit();
            this.tabPageQuotationCloseReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBOQRepresentative)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(16, 85);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(187, 20);
            this.kryptonLabel2.TabIndex = 8;
            this.kryptonLabel2.Values.Text = "Quotation Validity  (No. of Days)";
            // 
            // cboSalesRepresentative
            // 
            this.cboSalesRepresentative.DropDownWidth = 200;
            this.cboSalesRepresentative.FormattingEnabled = true;
            this.cboSalesRepresentative.Location = new System.Drawing.Point(137, 122);
            this.cboSalesRepresentative.Name = "cboSalesRepresentative";
            this.cboSalesRepresentative.Size = new System.Drawing.Size(358, 21);
            this.cboSalesRepresentative.TabIndex = 13;
            this.cboSalesRepresentative.Validating += new System.ComponentModel.CancelEventHandler(this.cboSalesRepresentative_Validating);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 0;
            this.label3.Values.Text = "Quotation Number";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(400, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 20);
            this.label5.TabIndex = 2;
            this.label5.Values.Text = "Quotation Date";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 12;
            this.label7.Values.Text = "Sales Representative";
            // 
            // dtQuotationDate
            // 
            this.dtQuotationDate.CustomFormat = "dd/MM/yyyy";
            this.dtQuotationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtQuotationDate.Location = new System.Drawing.Point(400, 31);
            this.dtQuotationDate.Name = "dtQuotationDate";
            this.dtQuotationDate.Size = new System.Drawing.Size(95, 21);
            this.dtQuotationDate.TabIndex = 3;
            // 
            // cboQuotationPriority
            // 
            this.cboQuotationPriority.AlwaysActive = false;
            this.cboQuotationPriority.DropDownWidth = 121;
            this.cboQuotationPriority.FormattingEnabled = true;
            this.cboQuotationPriority.Location = new System.Drawing.Point(340, 58);
            this.cboQuotationPriority.Name = "cboQuotationPriority";
            this.cboQuotationPriority.Size = new System.Drawing.Size(154, 21);
            this.cboQuotationPriority.TabIndex = 7;
            this.cboQuotationPriority.Validating += new System.ComponentModel.CancelEventHandler(this.cboQuotationPriority_Validating);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(289, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 6;
            this.label4.Values.Text = "Priority";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(16, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 20);
            this.label21.TabIndex = 4;
            this.label21.Values.Text = "Quotation Status";
            // 
            // txtQuotationNumber
            // 
            this.txtQuotationNumber.Location = new System.Drawing.Point(16, 31);
            this.txtQuotationNumber.Name = "txtQuotationNumber";
            this.txtQuotationNumber.Size = new System.Drawing.Size(374, 20);
            this.txtQuotationNumber.TabIndex = 1;
            this.txtQuotationNumber.TabStop = false;
            // 
            // cboQuotationStatus
            // 
            this.cboQuotationStatus.AlwaysActive = false;
            this.cboQuotationStatus.DropDownWidth = 200;
            this.cboQuotationStatus.FormattingEnabled = true;
            this.cboQuotationStatus.Location = new System.Drawing.Point(124, 58);
            this.cboQuotationStatus.Name = "cboQuotationStatus";
            this.cboQuotationStatus.Size = new System.Drawing.Size(154, 21);
            this.cboQuotationStatus.TabIndex = 5;
            this.cboQuotationStatus.SelectionChangeCommitted += new System.EventHandler(this.cboQuotationStatus_SelectionChangeCommitted);
            this.cboQuotationStatus.Validating += new System.ComponentModel.CancelEventHandler(this.cboQuotationStatus_Validating);
            // 
            // txtQuotationValidDays
            // 
            this.txtQuotationValidDays.Location = new System.Drawing.Point(211, 85);
            this.txtQuotationValidDays.MaxLength = 3;
            this.txtQuotationValidDays.Name = "txtQuotationValidDays";
            this.txtQuotationValidDays.Size = new System.Drawing.Size(67, 20);
            this.txtQuotationValidDays.TabIndex = 9;
            this.txtQuotationValidDays.Leave += new System.EventHandler(this.txtQuotationValidDays_Leave);
            this.txtQuotationValidDays.Validating += new System.ComponentModel.CancelEventHandler(this.txtQuotationValidDays_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(11, 14);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(100, 20);
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.Text = "Enquiry Number";
            // 
            // headerGroupEnquiry
            // 
            this.headerGroupEnquiry.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSelectSalesEnquiries});
            this.headerGroupEnquiry.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.headerGroupEnquiry.HeaderVisibleSecondary = false;
            this.headerGroupEnquiry.Location = new System.Drawing.Point(503, 8);
            this.headerGroupEnquiry.Name = "headerGroupEnquiry";
            // 
            // headerGroupEnquiry.Panel
            // 
            this.headerGroupEnquiry.Panel.Controls.Add(this.txtProjectName);
            this.headerGroupEnquiry.Panel.Controls.Add(this.txtEnquiryNumber);
            this.headerGroupEnquiry.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupEnquiry.Panel.Controls.Add(this.cboProjectLocation);
            this.headerGroupEnquiry.Panel.Controls.Add(this.kryptonLabel6);
            this.headerGroupEnquiry.Panel.Controls.Add(this.cboProjectSector);
            this.headerGroupEnquiry.Panel.Controls.Add(this.cboClient);
            this.headerGroupEnquiry.Panel.Controls.Add(this.kryptonLabel4);
            this.headerGroupEnquiry.Panel.Controls.Add(this.kryptonLabel5);
            this.headerGroupEnquiry.Panel.Controls.Add(this.kryptonLabel3);
            this.headerGroupEnquiry.Size = new System.Drawing.Size(454, 176);
            this.headerGroupEnquiry.TabIndex = 16;
            this.headerGroupEnquiry.ValuesPrimary.Heading = "";
            this.headerGroupEnquiry.ValuesPrimary.Image = null;
            // 
            // btnSelectSalesEnquiries
            // 
            this.btnSelectSalesEnquiries.Text = "Select Enquiry";
            this.btnSelectSalesEnquiries.UniqueName = "94712FA5055842ECA6937FA0AF8091D2";
            this.btnSelectSalesEnquiries.Click += new System.EventHandler(this.btnSelectSalesEnquiries_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(108, 39);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.ReadOnly = true;
            this.txtProjectName.Size = new System.Drawing.Size(333, 20);
            this.txtProjectName.TabIndex = 3;
            this.txtProjectName.TabStop = false;
            this.txtProjectName.Validating += new System.ComponentModel.CancelEventHandler(this.txtProjectName_Validating);
            // 
            // txtEnquiryNumber
            // 
            this.txtEnquiryNumber.Location = new System.Drawing.Point(108, 13);
            this.txtEnquiryNumber.Name = "txtEnquiryNumber";
            this.txtEnquiryNumber.ReadOnly = true;
            this.txtEnquiryNumber.Size = new System.Drawing.Size(333, 20);
            this.txtEnquiryNumber.TabIndex = 1;
            this.txtEnquiryNumber.TabStop = false;
            this.txtEnquiryNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtEnquiryNumber_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(140, 66);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(86, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Project Sector";
            // 
            // cboProjectLocation
            // 
            this.cboProjectLocation.DropDownWidth = 200;
            this.cboProjectLocation.FormattingEnabled = true;
            this.cboProjectLocation.Location = new System.Drawing.Point(229, 95);
            this.cboProjectLocation.Name = "cboProjectLocation";
            this.cboProjectLocation.Size = new System.Drawing.Size(212, 21);
            this.cboProjectLocation.TabIndex = 7;
            this.cboProjectLocation.Validating += new System.ComponentModel.CancelEventHandler(this.cboProjectLocation_Validating);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(128, 95);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(98, 20);
            this.kryptonLabel6.TabIndex = 6;
            this.kryptonLabel6.Values.Text = "Project Location";
            // 
            // cboProjectSector
            // 
            this.cboProjectSector.DropDownWidth = 200;
            this.cboProjectSector.FormattingEnabled = true;
            this.cboProjectSector.Location = new System.Drawing.Point(229, 66);
            this.cboProjectSector.Name = "cboProjectSector";
            this.cboProjectSector.Size = new System.Drawing.Size(212, 21);
            this.cboProjectSector.TabIndex = 5;
            this.cboProjectSector.Validating += new System.ComponentModel.CancelEventHandler(this.cboProjectSector_Validating);
            // 
            // cboClient
            // 
            this.cboClient.DropDownWidth = 121;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(14, 118);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(427, 21);
            this.cboClient.TabIndex = 8;
            this.cboClient.Validating += new System.ComponentModel.CancelEventHandler(this.cboClient_Validating);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 39);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel4.TabIndex = 2;
            this.kryptonLabel4.Values.Text = "Project Name";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 95);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel5.TabIndex = 7;
            this.kryptonLabel5.Values.Text = "Client Name";
            // 
            // txtQuotationExpiryDate
            // 
            this.txtQuotationExpiryDate.Location = new System.Drawing.Point(364, 85);
            this.txtQuotationExpiryDate.Name = "txtQuotationExpiryDate";
            this.txtQuotationExpiryDate.ReadOnly = true;
            this.txtQuotationExpiryDate.Size = new System.Drawing.Size(130, 20);
            this.txtQuotationExpiryDate.TabIndex = 11;
            this.txtQuotationExpiryDate.TabStop = false;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(289, 85);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel7.TabIndex = 10;
            this.kryptonLabel7.Values.Text = "Expiry Date";
            // 
            // headerGroupQuotation
            // 
            this.headerGroupQuotation.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.headerGroupQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupQuotation.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.headerGroupQuotation.Location = new System.Drawing.Point(10, 10);
            this.headerGroupQuotation.Name = "headerGroupQuotation";
            // 
            // headerGroupQuotation.Panel
            // 
            this.headerGroupQuotation.Panel.Controls.Add(this.tabRemarks);
            this.headerGroupQuotation.Panel.Controls.Add(this.cboBOQRepresentative);
            this.headerGroupQuotation.Panel.Controls.Add(this.kryptonLabel8);
            this.headerGroupQuotation.Panel.Controls.Add(this.headerGroupEnquiry);
            this.headerGroupQuotation.Panel.Controls.Add(this.label3);
            this.headerGroupQuotation.Panel.Controls.Add(this.txtQuotationExpiryDate);
            this.headerGroupQuotation.Panel.Controls.Add(this.txtQuotationNumber);
            this.headerGroupQuotation.Panel.Controls.Add(this.kryptonLabel7);
            this.headerGroupQuotation.Panel.Controls.Add(this.label21);
            this.headerGroupQuotation.Panel.Controls.Add(this.label4);
            this.headerGroupQuotation.Panel.Controls.Add(this.cboQuotationPriority);
            this.headerGroupQuotation.Panel.Controls.Add(this.dtQuotationDate);
            this.headerGroupQuotation.Panel.Controls.Add(this.txtQuotationValidDays);
            this.headerGroupQuotation.Panel.Controls.Add(this.cboQuotationStatus);
            this.headerGroupQuotation.Panel.Controls.Add(this.label5);
            this.headerGroupQuotation.Panel.Controls.Add(this.cboSalesRepresentative);
            this.headerGroupQuotation.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupQuotation.Panel.Controls.Add(this.label7);
            this.headerGroupQuotation.Size = new System.Drawing.Size(967, 456);
            this.headerGroupQuotation.TabIndex = 0;
            this.headerGroupQuotation.ValuesPrimary.Heading = "GENERAL INFO.";
            this.headerGroupQuotation.ValuesPrimary.Image = null;
            this.headerGroupQuotation.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnSave.Text = "&Save Quotation";
            this.btnSave.UniqueName = "F6FD08F5B7D74EFE6D884EC027274FA3";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "0A80D160FB304A1898A9BA0C22C3BBA0";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabRemarks
            // 
            this.tabRemarks.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SquareEqualSmall;
            this.tabRemarks.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.tabRemarks.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabRemarks.Location = new System.Drawing.Point(16, 190);
            this.tabRemarks.Name = "tabRemarks";
            this.tabRemarks.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageQuotationRemarks,
            this.tabPageQuotationCloseReason});
            this.tabRemarks.SelectedIndex = 0;
            this.tabRemarks.Size = new System.Drawing.Size(941, 196);
            this.tabRemarks.TabIndex = 17;
            this.tabRemarks.Text = "kryptonNavigator1";
            // 
            // tabPageQuotationRemarks
            // 
            this.tabPageQuotationRemarks.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageQuotationRemarks.Controls.Add(this.txtRemarks);
            this.tabPageQuotationRemarks.Flags = 65534;
            this.tabPageQuotationRemarks.LastVisibleSet = true;
            this.tabPageQuotationRemarks.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageQuotationRemarks.Name = "tabPageQuotationRemarks";
            this.tabPageQuotationRemarks.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageQuotationRemarks.Size = new System.Drawing.Size(939, 170);
            this.tabPageQuotationRemarks.Text = "Remarks";
            this.tabPageQuotationRemarks.ToolTipTitle = "Page ToolTip";
            this.tabPageQuotationRemarks.UniqueName = "E750F7271DCA4F9A5A816784E85F070F";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(5, 5);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(929, 160);
            this.txtRemarks.TabIndex = 0;
            this.txtRemarks.Text = "";
            // 
            // tabPageQuotationCloseReason
            // 
            this.tabPageQuotationCloseReason.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageQuotationCloseReason.Controls.Add(this.txtReasonClosedLost);
            this.tabPageQuotationCloseReason.Flags = 65534;
            this.tabPageQuotationCloseReason.LastVisibleSet = true;
            this.tabPageQuotationCloseReason.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageQuotationCloseReason.Name = "tabPageQuotationCloseReason";
            this.tabPageQuotationCloseReason.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageQuotationCloseReason.Size = new System.Drawing.Size(939, 183);
            this.tabPageQuotationCloseReason.Text = "(Close/Lost) Reason ";
            this.tabPageQuotationCloseReason.ToolTipTitle = "Page ToolTip";
            this.tabPageQuotationCloseReason.UniqueName = "472670E573EE46E04691F167D74D191D";
            // 
            // txtReasonClosedLost
            // 
            this.txtReasonClosedLost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReasonClosedLost.Location = new System.Drawing.Point(5, 5);
            this.txtReasonClosedLost.Multiline = true;
            this.txtReasonClosedLost.Name = "txtReasonClosedLost";
            this.txtReasonClosedLost.Size = new System.Drawing.Size(929, 173);
            this.txtReasonClosedLost.TabIndex = 0;
            this.txtReasonClosedLost.Validating += new System.ComponentModel.CancelEventHandler(this.txtReasonClosedLost_Validating);
            // 
            // cboBOQRepresentative
            // 
            this.cboBOQRepresentative.DropDownWidth = 200;
            this.cboBOQRepresentative.FormattingEnabled = true;
            this.cboBOQRepresentative.Location = new System.Drawing.Point(137, 153);
            this.cboBOQRepresentative.Name = "cboBOQRepresentative";
            this.cboBOQRepresentative.Size = new System.Drawing.Size(358, 21);
            this.cboBOQRepresentative.TabIndex = 15;
            this.cboBOQRepresentative.Validating += new System.ComponentModel.CancelEventHandler(this.cboBOQRepresentative_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(16, 154);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(120, 20);
            this.kryptonLabel8.TabIndex = 14;
            this.kryptonLabel8.Values.Text = "BOQ Representative ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSalesQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(987, 476);
            this.Controls.Add(this.headerGroupQuotation);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSalesQuotation";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmQuotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesRepresentative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEnquiry.Panel)).EndInit();
            this.headerGroupEnquiry.Panel.ResumeLayout(false);
            this.headerGroupEnquiry.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEnquiry)).EndInit();
            this.headerGroupEnquiry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectSector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation.Panel)).EndInit();
            this.headerGroupQuotation.Panel.ResumeLayout(false);
            this.headerGroupQuotation.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation)).EndInit();
            this.headerGroupQuotation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabRemarks)).EndInit();
            this.tabRemarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageQuotationRemarks)).EndInit();
            this.tabPageQuotationRemarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageQuotationCloseReason)).EndInit();
            this.tabPageQuotationCloseReason.ResumeLayout(false);
            this.tabPageQuotationCloseReason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboBOQRepresentative)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSalesRepresentative;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtQuotationDate;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboQuotationPriority;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label21;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQuotationNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboQuotationStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQuotationValidDays;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupEnquiry;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQuotationExpiryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSelectSalesEnquiries;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupQuotation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProjectLocation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProjectSector;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboClient;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabRemarks;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageQuotationRemarks;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageQuotationCloseReason;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtProjectName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEnquiryNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtRemarks;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtReasonClosedLost;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBOQRepresentative;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
    }
}