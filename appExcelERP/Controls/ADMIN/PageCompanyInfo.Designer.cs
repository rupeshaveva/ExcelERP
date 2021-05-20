namespace appExcelERP.Controls.ADMIN
{
    partial class PageCompanyInfo
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
            this.components = new System.ComponentModel.Container();
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSaveCompanyInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancelUpdates = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtEmailAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtCompanyAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboArea = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboCity = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboState = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboCountry = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAbbrivation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtWebsiteAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtECCNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtTinNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtPANNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtGSTNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtIECCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel18 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPhoneNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtFaxNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel19 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtShiftToTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel14 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel15 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtShiftFromTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSaveCompanyInfo,
            this.btnCancelUpdates});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.Location = new System.Drawing.Point(10, 10);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.tableLayoutPanel1);
            this.headerGroupMain.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupMain.Size = new System.Drawing.Size(815, 504);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "COMPANY INFO.";
            this.headerGroupMain.ValuesPrimary.Image = null;
            this.headerGroupMain.ValuesSecondary.Heading = "";
            // 
            // btnSaveCompanyInfo
            // 
            this.btnSaveCompanyInfo.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSaveCompanyInfo.Text = "&Update";
            this.btnSaveCompanyInfo.UniqueName = "94525501B81E4CF81E8BAE17CDBE7C9F";
            this.btnSaveCompanyInfo.Click += new System.EventHandler(this.btnSaveCompanyInfo_Click);
            // 
            // btnCancelUpdates
            // 
            this.btnCancelUpdates.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancelUpdates.Text = "&Cancel";
            this.btnCancelUpdates.UniqueName = "359382A6740B4A67779A0805D87F7614";
            this.btnCancelUpdates.Click += new System.EventHandler(this.btnCancelUpdates_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtEmailAddress, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtCompanyName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCompanyAddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboArea, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboCity, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboState, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboCountry, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel6, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel5, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel12, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAbbrivation, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel16, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel17, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtWebsiteAddress, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtECCNo, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtTinNo, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtPANNo, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtGSTNo, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel7, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel8, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel9, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel10, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtIECCode, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel18, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel11, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtPhoneNo, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtFaxNo, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel19, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.dtShiftToTime, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel14, 4, 10);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel15, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.dtShiftFromTime, 3, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 435);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtEmailAddress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtEmailAddress, 3);
            this.txtEmailAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmailAddress.Location = new System.Drawing.Point(323, 174);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(477, 20);
            this.txtEmailAddress.TabIndex = 32;
            this.txtEmailAddress.Text = "KRYPTONTEXTBOX2";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCompanyName, 3);
            this.txtCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompanyName.Location = new System.Drawing.Point(163, 29);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(474, 20);
            this.txtCompanyName.TabIndex = 3;
            this.txtCompanyName.Text = "KRYPTONTEXTBOX2";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(39, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Code";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(163, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(99, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Company Name";
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(3, 29);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(154, 20);
            this.txtCode.TabIndex = 2;
            this.txtCode.Text = "kryptonTextBox1";
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCompanyAddress, 4);
            this.txtCompanyAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompanyAddress.Location = new System.Drawing.Point(163, 55);
            this.txtCompanyAddress.Multiline = true;
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(637, 60);
            this.txtCompanyAddress.TabIndex = 4;
            this.txtCompanyAddress.Text = "KRYPTONTEXTBOX2";
            // 
            // cboArea
            // 
            this.cboArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboArea.DropDownWidth = 121;
            this.cboArea.Location = new System.Drawing.Point(643, 147);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(157, 21);
            this.cboArea.TabIndex = 12;
            this.cboArea.Text = "kryptonComboBox4";
            this.cboArea.Validating += new System.ComponentModel.CancelEventHandler(this.cboArea_Validating);
            // 
            // cboCity
            // 
            this.cboCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCity.DropDownWidth = 121;
            this.cboCity.Location = new System.Drawing.Point(483, 147);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(154, 21);
            this.cboCity.TabIndex = 11;
            this.cboCity.Text = "kryptonComboBox3";
            this.cboCity.SelectedValueChanged += new System.EventHandler(this.cboCity_SelectedValueChanged);
            this.cboCity.Validating += new System.ComponentModel.CancelEventHandler(this.cboCity_Validating);
            // 
            // cboState
            // 
            this.cboState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboState.DropDownWidth = 121;
            this.cboState.Location = new System.Drawing.Point(323, 147);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(154, 21);
            this.cboState.TabIndex = 10;
            this.cboState.Text = "kryptonComboBox2";
            this.cboState.SelectedValueChanged += new System.EventHandler(this.cboState_SelectedValueChanged);
            this.cboState.Validating += new System.ComponentModel.CancelEventHandler(this.cboState_Validating);
            // 
            // cboCountry
            // 
            this.cboCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCountry.DropDownWidth = 154;
            this.cboCountry.Location = new System.Drawing.Point(163, 147);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(154, 21);
            this.cboCountry.TabIndex = 9;
            this.cboCountry.Text = "kryptonComboBox1";
            this.cboCountry.SelectedValueChanged += new System.EventHandler(this.cboCountry_SelectedValueChanged);
            this.cboCountry.Validating += new System.ComponentModel.CancelEventHandler(this.cboCountry_Validating);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel6.Location = new System.Drawing.Point(764, 121);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel6.TabIndex = 8;
            this.kryptonLabel6.Values.Text = "Area";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel5.Location = new System.Drawing.Point(606, 121);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(31, 20);
            this.kryptonLabel5.TabIndex = 7;
            this.kryptonLabel5.Values.Text = "City";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel4.Location = new System.Drawing.Point(387, 121);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "State/Province";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel3.Location = new System.Drawing.Point(263, 121);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Country";
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(643, 3);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel12.TabIndex = 23;
            this.kryptonLabel12.Values.Text = "Abbrivation";
            // 
            // txtAbbrivation
            // 
            this.txtAbbrivation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAbbrivation.Location = new System.Drawing.Point(643, 29);
            this.txtAbbrivation.Name = "txtAbbrivation";
            this.txtAbbrivation.Size = new System.Drawing.Size(157, 20);
            this.txtAbbrivation.TabIndex = 24;
            this.txtAbbrivation.Text = "kryptonTextBox9";
            // 
            // kryptonLabel16
            // 
            this.kryptonLabel16.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel16.Location = new System.Drawing.Point(230, 174);
            this.kryptonLabel16.Name = "kryptonLabel16";
            this.kryptonLabel16.Size = new System.Drawing.Size(87, 20);
            this.kryptonLabel16.TabIndex = 30;
            this.kryptonLabel16.Values.Text = "Email Address";
            // 
            // kryptonLabel17
            // 
            this.kryptonLabel17.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel17.Location = new System.Drawing.Point(215, 200);
            this.kryptonLabel17.Name = "kryptonLabel17";
            this.kryptonLabel17.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel17.TabIndex = 31;
            this.kryptonLabel17.Values.Text = "Website Address";
            // 
            // txtWebsiteAddress
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtWebsiteAddress, 3);
            this.txtWebsiteAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWebsiteAddress.Location = new System.Drawing.Point(323, 200);
            this.txtWebsiteAddress.Name = "txtWebsiteAddress";
            this.txtWebsiteAddress.Size = new System.Drawing.Size(477, 20);
            this.txtWebsiteAddress.TabIndex = 33;
            this.txtWebsiteAddress.Text = "kryptonTextBox13";
            // 
            // txtECCNo
            // 
            this.txtECCNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtECCNo.Location = new System.Drawing.Point(3, 278);
            this.txtECCNo.Name = "txtECCNo";
            this.txtECCNo.Size = new System.Drawing.Size(154, 20);
            this.txtECCNo.TabIndex = 18;
            this.txtECCNo.Text = "kryptonTextBox4";
            // 
            // txtTinNo
            // 
            this.txtTinNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTinNo.Location = new System.Drawing.Point(163, 278);
            this.txtTinNo.Name = "txtTinNo";
            this.txtTinNo.Size = new System.Drawing.Size(154, 20);
            this.txtTinNo.TabIndex = 19;
            this.txtTinNo.Text = "kryptonTextBox5";
            // 
            // txtPANNo
            // 
            this.txtPANNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPANNo.Location = new System.Drawing.Point(323, 278);
            this.txtPANNo.Name = "txtPANNo";
            this.txtPANNo.Size = new System.Drawing.Size(154, 20);
            this.txtPANNo.TabIndex = 20;
            this.txtPANNo.Text = "kryptonTextBox6";
            // 
            // txtGSTNo
            // 
            this.txtGSTNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGSTNo.Location = new System.Drawing.Point(483, 278);
            this.txtGSTNo.Name = "txtGSTNo";
            this.txtGSTNo.Size = new System.Drawing.Size(154, 20);
            this.txtGSTNo.TabIndex = 21;
            this.txtGSTNo.Text = "kryptonTextBox7";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(3, 252);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel7.TabIndex = 13;
            this.kryptonLabel7.Values.Text = "ECC NO.";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(163, 252);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel8.TabIndex = 14;
            this.kryptonLabel8.Values.Text = "TIN NO.";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(323, 252);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(59, 20);
            this.kryptonLabel9.TabIndex = 15;
            this.kryptonLabel9.Values.Text = "PAN NO.";
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(483, 252);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel10.TabIndex = 16;
            this.kryptonLabel10.Values.Text = "GST NO.";
            // 
            // txtIECCode
            // 
            this.txtIECCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIECCode.Location = new System.Drawing.Point(643, 278);
            this.txtIECCode.Name = "txtIECCode";
            this.txtIECCode.Size = new System.Drawing.Size(157, 20);
            this.txtIECCode.TabIndex = 22;
            this.txtIECCode.Text = "kryptonTextBox8";
            // 
            // kryptonLabel18
            // 
            this.kryptonLabel18.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel18.Location = new System.Drawing.Point(249, 226);
            this.kryptonLabel18.Name = "kryptonLabel18";
            this.kryptonLabel18.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel18.TabIndex = 34;
            this.kryptonLabel18.Values.Text = "Phone No.";
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(643, 252);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(63, 20);
            this.kryptonLabel11.TabIndex = 17;
            this.kryptonLabel11.Values.Text = "IEC CODE";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhoneNo.Location = new System.Drawing.Point(323, 226);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(154, 20);
            this.txtPhoneNo.TabIndex = 35;
            this.txtPhoneNo.Text = "kryptonTextBox14";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFaxNo.Location = new System.Drawing.Point(643, 226);
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(157, 20);
            this.txtFaxNo.TabIndex = 36;
            this.txtFaxNo.Text = "kryptonTextBox15";
            // 
            // kryptonLabel19
            // 
            this.kryptonLabel19.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonLabel19.Location = new System.Drawing.Point(583, 226);
            this.kryptonLabel19.Name = "kryptonLabel19";
            this.kryptonLabel19.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel19.TabIndex = 37;
            this.kryptonLabel19.Values.Text = "FAX No.";
            // 
            // dtShiftToTime
            // 
            this.dtShiftToTime.CustomFormat = "hh:mm tt";
            this.dtShiftToTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtShiftToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShiftToTime.Location = new System.Drawing.Point(643, 330);
            this.dtShiftToTime.Name = "dtShiftToTime";
            this.dtShiftToTime.Size = new System.Drawing.Size(157, 21);
            this.dtShiftToTime.TabIndex = 39;
            // 
            // kryptonLabel14
            // 
            this.kryptonLabel14.Location = new System.Drawing.Point(643, 304);
            this.kryptonLabel14.Name = "kryptonLabel14";
            this.kryptonLabel14.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel14.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel14.TabIndex = 26;
            this.kryptonLabel14.Values.Text = "Shift - To Time";
            // 
            // kryptonLabel15
            // 
            this.kryptonLabel15.Location = new System.Drawing.Point(483, 304);
            this.kryptonLabel15.Name = "kryptonLabel15";
            this.kryptonLabel15.Size = new System.Drawing.Size(105, 20);
            this.kryptonLabel15.StateCommon.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kryptonLabel15.TabIndex = 29;
            this.kryptonLabel15.Values.Text = "Shift - From Time";
            // 
            // dtShiftFromTime
            // 
            this.dtShiftFromTime.CustomFormat = "hh:mm tt";
            this.dtShiftFromTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtShiftFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShiftFromTime.Location = new System.Drawing.Point(483, 330);
            this.dtShiftFromTime.Name = "dtShiftFromTime";
            this.dtShiftFromTime.Size = new System.Drawing.Size(154, 21);
            this.dtShiftFromTime.TabIndex = 38;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PageCompanyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "PageCompanyInfo";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(835, 524);
            this.Load += new System.EventHandler(this.PageCompanyInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSaveCompanyInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancelUpdates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmailAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCode;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCompanyAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboArea;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCity;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboState;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCountry;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAbbrivation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel16;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel17;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtWebsiteAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtECCNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTinNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPANNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGSTNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtIECCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel18;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPhoneNo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtFaxNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel19;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtShiftToTime;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel14;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel15;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtShiftFromTime;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
