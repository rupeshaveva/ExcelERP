namespace appExcelERP.Controls.HR.Attendance
{
    partial class PageManualAttendance
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
            this.headerGroupOnSiteAttendanceInput = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRemoveOnsiteemployeeFromSheet = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAddNewOnSiteAttendance = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnSelectProject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnGenerateOnsiteSheet = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnClearManualAttendancesheet = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveMultiple = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.dtSiteAttendanceDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.headerGroupOnSiteAttendance = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnPostOnSiteAttendanceToERP = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridOnSiteAttendance = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateManualAttendance = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkBtnOnSite = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.chkBtnWarehouse = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.chkbtnPresent = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.chkbtnAbsent = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.chkbtnLeave = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.chkbtnOutdoor = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.dtOnSiteOutTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.cboProject = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtOnSiteInTime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSearchOnsiteEmployee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendanceInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendanceInput.Panel)).BeginInit();
            this.headerGroupOnSiteAttendanceInput.Panel.SuspendLayout();
            this.headerGroupOnSiteAttendanceInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendance.Panel)).BeginInit();
            this.headerGroupOnSiteAttendance.Panel.SuspendLayout();
            this.headerGroupOnSiteAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridOnSiteAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupOnSiteAttendanceInput
            // 
            this.headerGroupOnSiteAttendanceInput.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRemoveOnsiteemployeeFromSheet,
            this.btnAddNewOnSiteAttendance,
            this.btnSelectProject,
            this.btnGenerateOnsiteSheet,
            this.btnClearManualAttendancesheet,
            this.btnRemoveMultiple});
            this.headerGroupOnSiteAttendanceInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupOnSiteAttendanceInput.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupOnSiteAttendanceInput.Location = new System.Drawing.Point(0, 0);
            this.headerGroupOnSiteAttendanceInput.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupOnSiteAttendanceInput.Name = "headerGroupOnSiteAttendanceInput";
            // 
            // headerGroupOnSiteAttendanceInput.Panel
            // 
            this.headerGroupOnSiteAttendanceInput.Panel.Controls.Add(this.dtSiteAttendanceDate);
            this.headerGroupOnSiteAttendanceInput.Panel.Controls.Add(this.kryptonLabel4);
            this.headerGroupOnSiteAttendanceInput.Size = new System.Drawing.Size(1134, 94);
            this.headerGroupOnSiteAttendanceInput.TabIndex = 6;
            this.headerGroupOnSiteAttendanceInput.ValuesPrimary.Heading = "Prepare Attendance sheet of On-Site Employees";
            this.headerGroupOnSiteAttendanceInput.ValuesPrimary.Image = null;
            this.headerGroupOnSiteAttendanceInput.ValuesSecondary.Heading = "";
            // 
            // btnRemoveOnsiteemployeeFromSheet
            // 
            this.btnRemoveOnsiteemployeeFromSheet.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnRemoveOnsiteemployeeFromSheet.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnRemoveOnsiteemployeeFromSheet.Image = global::appExcelERP.Properties.Resources.RemoveGuide_16x;
            this.btnRemoveOnsiteemployeeFromSheet.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnRemoveOnsiteemployeeFromSheet.Text = "&Remove Selected ";
            this.btnRemoveOnsiteemployeeFromSheet.UniqueName = "EBC4BB9FF7644E745EB768BCF1F62B77";
            this.btnRemoveOnsiteemployeeFromSheet.Click += new System.EventHandler(this.btnRemoveOnsiteemployeeFromSheet_Click);
            // 
            // btnAddNewOnSiteAttendance
            // 
            this.btnAddNewOnSiteAttendance.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnAddNewOnSiteAttendance.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnAddNewOnSiteAttendance.Image = global::appExcelERP.Properties.Resources.JSWorker_16x;
            this.btnAddNewOnSiteAttendance.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Alternate;
            this.btnAddNewOnSiteAttendance.Text = "&Generate Employees Sheet";
            this.btnAddNewOnSiteAttendance.UniqueName = "D377441454B54803AB88FD5A2EC76783";
            this.btnAddNewOnSiteAttendance.Click += new System.EventHandler(this.btnAddNewOnSiteAttendance_Click);
            // 
            // btnSelectProject
            // 
            this.btnSelectProject.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSelectProject.Image = global::appExcelERP.Properties.Resources.JSWorker_16x;
            this.btnSelectProject.Text = "Generate Default Sheet (Site)";
            this.btnSelectProject.UniqueName = "78CAA29C3EBB4CB18EAAC27C2BCE7800";
            this.btnSelectProject.Click += new System.EventHandler(this.btnSelectProject_Click);
            // 
            // btnGenerateOnsiteSheet
            // 
            this.btnGenerateOnsiteSheet.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnGenerateOnsiteSheet.Image = global::appExcelERP.Properties.Resources.JSWorker_16x;
            this.btnGenerateOnsiteSheet.Text = "&Generate Default Sheet (All Sites)";
            this.btnGenerateOnsiteSheet.UniqueName = "DA198F42DC2A48726AA2AD034AD4B548";
            this.btnGenerateOnsiteSheet.Click += new System.EventHandler(this.btnGenerateOnsiteSheet_Click);
            // 
            // btnClearManualAttendancesheet
            // 
            this.btnClearManualAttendancesheet.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnClearManualAttendancesheet.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnClearManualAttendancesheet.Text = "&Clear Sheet";
            this.btnClearManualAttendancesheet.UniqueName = "33303F49580044B1B3A820C121D43AB8";
            this.btnClearManualAttendancesheet.Click += new System.EventHandler(this.btnClearManualAttendancesheet_Click);
            // 
            // btnRemoveMultiple
            // 
            this.btnRemoveMultiple.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnRemoveMultiple.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnRemoveMultiple.Image = global::appExcelERP.Properties.Resources.RemoveGuide_16x;
            this.btnRemoveMultiple.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnRemoveMultiple.Text = "Remove Selected Records";
            this.btnRemoveMultiple.UniqueName = "D79C12C3395849E54799C36B5EEED600";
            this.btnRemoveMultiple.Click += new System.EventHandler(this.btnRemoveMultiple_Click);
            // 
            // dtSiteAttendanceDate
            // 
            this.dtSiteAttendanceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtSiteAttendanceDate.Location = new System.Drawing.Point(957, 8);
            this.dtSiteAttendanceDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtSiteAttendanceDate.Name = "dtSiteAttendanceDate";
            this.dtSiteAttendanceDate.Size = new System.Drawing.Size(162, 21);
            this.dtSiteAttendanceDate.TabIndex = 1;
            this.dtSiteAttendanceDate.ValueChanged += new System.EventHandler(this.dtSiteAttendanceDate_ValueChanged);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel4.Location = new System.Drawing.Point(848, 8);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(105, 20);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "Attendance  Date";
            // 
            // headerGroupOnSiteAttendance
            // 
            this.headerGroupOnSiteAttendance.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnPostOnSiteAttendanceToERP});
            this.headerGroupOnSiteAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupOnSiteAttendance.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupOnSiteAttendance.HeaderVisiblePrimary = false;
            this.headerGroupOnSiteAttendance.Location = new System.Drawing.Point(0, 94);
            this.headerGroupOnSiteAttendance.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupOnSiteAttendance.Name = "headerGroupOnSiteAttendance";
            // 
            // headerGroupOnSiteAttendance.Panel
            // 
            this.headerGroupOnSiteAttendance.Panel.Controls.Add(this.gridOnSiteAttendance);
            this.headerGroupOnSiteAttendance.Panel.Controls.Add(this.kryptonHeaderGroup1);
            this.headerGroupOnSiteAttendance.Panel.Controls.Add(this.txtSearchOnsiteEmployee);
            this.headerGroupOnSiteAttendance.Size = new System.Drawing.Size(1134, 554);
            this.headerGroupOnSiteAttendance.TabIndex = 8;
            this.headerGroupOnSiteAttendance.ValuesPrimary.Heading = "sdasd";
            this.headerGroupOnSiteAttendance.ValuesPrimary.Image = null;
            this.headerGroupOnSiteAttendance.ValuesSecondary.Heading = "Process Status";
            // 
            // btnPostOnSiteAttendanceToERP
            // 
            this.btnPostOnSiteAttendanceToERP.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnPostOnSiteAttendanceToERP.Image = global::appExcelERP.Properties.Resources.GenerateChangeScript_16x;
            this.btnPostOnSiteAttendanceToERP.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnPostOnSiteAttendanceToERP.Text = "Post Attendance to Excel ERP";
            this.btnPostOnSiteAttendanceToERP.UniqueName = "B405B452DD7E4526D4869BEE20661DA9";
            this.btnPostOnSiteAttendanceToERP.Click += new System.EventHandler(this.btnPostOnSiteAttendanceToERP_Click);
            // 
            // gridOnSiteAttendance
            // 
            this.gridOnSiteAttendance.AllowUserToAddRows = false;
            this.gridOnSiteAttendance.AllowUserToDeleteRows = false;
            this.gridOnSiteAttendance.AllowUserToResizeRows = false;
            this.gridOnSiteAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridOnSiteAttendance.ColumnHeadersHeight = 28;
            this.gridOnSiteAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridOnSiteAttendance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridOnSiteAttendance.Location = new System.Drawing.Point(0, 20);
            this.gridOnSiteAttendance.Margin = new System.Windows.Forms.Padding(2);
            this.gridOnSiteAttendance.Name = "gridOnSiteAttendance";
            this.gridOnSiteAttendance.RowHeadersVisible = false;
            this.gridOnSiteAttendance.RowTemplate.Height = 24;
            this.gridOnSiteAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridOnSiteAttendance.Size = new System.Drawing.Size(856, 503);
            this.gridOnSiteAttendance.TabIndex = 8;
            this.gridOnSiteAttendance.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOnSiteAttendance_CellClick);
            this.gridOnSiteAttendance.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridOnSiteAttendance_DataBindingComplete);
            this.gridOnSiteAttendance.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridOnSiteAttendance_EditingControlShowing);
            this.gridOnSiteAttendance.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridOnSiteAttendance_RowEnter);
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateManualAttendance});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Right;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(856, 20);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.tableLayoutPanel1);
            this.kryptonHeaderGroup1.Panel.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(4);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(276, 503);
            this.kryptonHeaderGroup1.TabIndex = 7;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = " ";
            // 
            // btnUpdateManualAttendance
            // 
            this.btnUpdateManualAttendance.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnUpdateManualAttendance.Text = "&Update";
            this.btnUpdateManualAttendance.UniqueName = "86785CFB65764D55E3AC82030BEBBF60";
            this.btnUpdateManualAttendance.Click += new System.EventHandler(this.btnUpdateManualAttendance_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.60938F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.39063F));
            this.tableLayoutPanel1.Controls.Add(this.txtRemarks, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkBtnOnSite, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkBtnWarehouse, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkbtnPresent, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkbtnAbsent, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkbtnLeave, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkbtnOutdoor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtOnSiteOutTime, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.cboProject, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtOnSiteInTime, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.kryptonLabel6, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 10;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(266, 464);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // txtRemarks
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtRemarks, 2);
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(8, 225);
            this.txtRemarks.Name = "txtRemarks";
            this.tableLayoutPanel1.SetRowSpan(this.txtRemarks, 2);
            this.txtRemarks.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtRemarks.Size = new System.Drawing.Size(250, 231);
            this.txtRemarks.TabIndex = 18;
            this.txtRemarks.TabStop = false;
            this.txtRemarks.Text = "";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonLabel7.Location = new System.Drawing.Point(8, 68);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(121, 20);
            this.kryptonLabel7.TabIndex = 17;
            this.kryptonLabel7.Values.Text = "Location";
            // 
            // chkBtnOnSite
            // 
            this.chkBtnOnSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBtnOnSite.Location = new System.Drawing.Point(7, 93);
            this.chkBtnOnSite.Margin = new System.Windows.Forms.Padding(2);
            this.chkBtnOnSite.Name = "chkBtnOnSite";
            this.chkBtnOnSite.Size = new System.Drawing.Size(123, 25);
            this.chkBtnOnSite.TabIndex = 14;
            this.chkBtnOnSite.Values.Text = "On Site";
            this.chkBtnOnSite.Click += new System.EventHandler(this.chkBtnOnSite_Click);
            // 
            // chkBtnWarehouse
            // 
            this.chkBtnWarehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBtnWarehouse.Location = new System.Drawing.Point(134, 93);
            this.chkBtnWarehouse.Margin = new System.Windows.Forms.Padding(2);
            this.chkBtnWarehouse.Name = "chkBtnWarehouse";
            this.chkBtnWarehouse.Size = new System.Drawing.Size(125, 25);
            this.chkBtnWarehouse.TabIndex = 15;
            this.chkBtnWarehouse.Values.Text = "&Warehouse";
            this.chkBtnWarehouse.Click += new System.EventHandler(this.chkBtnWarehouse_Click);
            // 
            // chkbtnPresent
            // 
            this.chkbtnPresent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbtnPresent.Location = new System.Drawing.Point(7, 7);
            this.chkbtnPresent.Margin = new System.Windows.Forms.Padding(2);
            this.chkbtnPresent.Name = "chkbtnPresent";
            this.chkbtnPresent.Size = new System.Drawing.Size(123, 26);
            this.chkbtnPresent.TabIndex = 0;
            this.chkbtnPresent.Values.Text = "Present";
            this.chkbtnPresent.Click += new System.EventHandler(this.chkbtnPresent_Click);
            // 
            // chkbtnAbsent
            // 
            this.chkbtnAbsent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbtnAbsent.Location = new System.Drawing.Point(134, 7);
            this.chkbtnAbsent.Margin = new System.Windows.Forms.Padding(2);
            this.chkbtnAbsent.Name = "chkbtnAbsent";
            this.chkbtnAbsent.Size = new System.Drawing.Size(125, 26);
            this.chkbtnAbsent.TabIndex = 1;
            this.chkbtnAbsent.Values.Text = "&Absent";
            this.chkbtnAbsent.Click += new System.EventHandler(this.chkbtnAbsent_Click);
            // 
            // chkbtnLeave
            // 
            this.chkbtnLeave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbtnLeave.Location = new System.Drawing.Point(7, 37);
            this.chkbtnLeave.Margin = new System.Windows.Forms.Padding(2);
            this.chkbtnLeave.Name = "chkbtnLeave";
            this.chkbtnLeave.Size = new System.Drawing.Size(123, 26);
            this.chkbtnLeave.TabIndex = 2;
            this.chkbtnLeave.Values.Text = "&Leave";
            this.chkbtnLeave.Click += new System.EventHandler(this.chkbtnLeave_Click);
            // 
            // chkbtnOutdoor
            // 
            this.chkbtnOutdoor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkbtnOutdoor.Location = new System.Drawing.Point(134, 37);
            this.chkbtnOutdoor.Margin = new System.Windows.Forms.Padding(2);
            this.chkbtnOutdoor.Name = "chkbtnOutdoor";
            this.chkbtnOutdoor.Size = new System.Drawing.Size(125, 26);
            this.chkbtnOutdoor.TabIndex = 3;
            this.chkbtnOutdoor.Values.Text = "Out Door";
            this.chkbtnOutdoor.Click += new System.EventHandler(this.chkbtnOutdoor_Click);
            // 
            // dtOnSiteOutTime
            // 
            this.dtOnSiteOutTime.CustomFormat = "hh:mm tt";
            this.dtOnSiteOutTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtOnSiteOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOnSiteOutTime.Location = new System.Drawing.Point(134, 173);
            this.dtOnSiteOutTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtOnSiteOutTime.Name = "dtOnSiteOutTime";
            this.dtOnSiteOutTime.Size = new System.Drawing.Size(125, 21);
            this.dtOnSiteOutTime.TabIndex = 10;
            // 
            // cboProject
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cboProject, 2);
            this.cboProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboProject.DropDownWidth = 364;
            this.cboProject.Location = new System.Drawing.Point(7, 122);
            this.cboProject.Margin = new System.Windows.Forms.Padding(2);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(252, 21);
            this.cboProject.TabIndex = 13;
            this.cboProject.Text = "kryptonComboBox1";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel5.Location = new System.Drawing.Point(8, 148);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(53, 20);
            this.kryptonLabel5.TabIndex = 1;
            this.kryptonLabel5.Values.Text = "Time IN";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel3.Location = new System.Drawing.Point(135, 148);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Time Out";
            // 
            // dtOnSiteInTime
            // 
            this.dtOnSiteInTime.CustomFormat = "hh:mm tt";
            this.dtOnSiteInTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtOnSiteInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOnSiteInTime.Location = new System.Drawing.Point(7, 173);
            this.dtOnSiteInTime.Margin = new System.Windows.Forms.Padding(2);
            this.dtOnSiteInTime.Name = "dtOnSiteInTime";
            this.dtOnSiteInTime.Size = new System.Drawing.Size(123, 21);
            this.dtOnSiteInTime.TabIndex = 9;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.kryptonLabel6.Location = new System.Drawing.Point(8, 199);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel6.TabIndex = 16;
            this.kryptonLabel6.Values.Text = "Remarks";
            // 
            // txtSearchOnsiteEmployee
            // 
            this.txtSearchOnsiteEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchOnsiteEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchOnsiteEmployee.Location = new System.Drawing.Point(0, 0);
            this.txtSearchOnsiteEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchOnsiteEmployee.Name = "txtSearchOnsiteEmployee";
            this.txtSearchOnsiteEmployee.Size = new System.Drawing.Size(1132, 20);
            this.txtSearchOnsiteEmployee.TabIndex = 3;
            this.txtSearchOnsiteEmployee.TextChanged += new System.EventHandler(this.txtSearchOnsiteEmployee_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // PageManualAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupOnSiteAttendance);
            this.Controls.Add(this.headerGroupOnSiteAttendanceInput);
            this.Name = "PageManualAttendance";
            this.Size = new System.Drawing.Size(1134, 648);
            this.Load += new System.EventHandler(this.PageManualAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendanceInput.Panel)).EndInit();
            this.headerGroupOnSiteAttendanceInput.Panel.ResumeLayout(false);
            this.headerGroupOnSiteAttendanceInput.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendanceInput)).EndInit();
            this.headerGroupOnSiteAttendanceInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendance.Panel)).EndInit();
            this.headerGroupOnSiteAttendance.Panel.ResumeLayout(false);
            this.headerGroupOnSiteAttendance.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOnSiteAttendance)).EndInit();
            this.headerGroupOnSiteAttendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridOnSiteAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOnSiteAttendanceInput;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveOnsiteemployeeFromSheet;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewOnSiteAttendance;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSelectProject;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnGenerateOnsiteSheet;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnClearManualAttendancesheet;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtSiteAttendanceDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOnSiteAttendance;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnPostOnSiteAttendanceToERP;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridOnSiteAttendance;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateManualAttendance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkBtnOnSite;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkBtnWarehouse;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkbtnPresent;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkbtnAbsent;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkbtnLeave;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton chkbtnOutdoor;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtOnSiteOutTime;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProject;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtOnSiteInTime;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchOnsiteEmployee;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveMultiple;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}
