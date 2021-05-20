namespace appExcelERP.Forms
{
    partial class frmScheduleCall
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
            this.headerGroupSchedule = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.cboPriority = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtReaminder = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.gridAssignees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerAssignee = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnAddNewAssignee = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnRemoveAssignee = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.txtContactLocation = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtContactNumbers = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtContactPersons = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCompanyName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtScheduleEndDatetime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtScheduleStartDatetime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtSubject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboCallStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboActions = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.linkLabelAddNewAction = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule.Panel)).BeginInit();
            this.headerGroupSchedule.Panel.SuspendLayout();
            this.headerGroupSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAssignees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCallStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupSchedule
            // 
            this.headerGroupSchedule.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.headerGroupSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupSchedule.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupSchedule.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupSchedule.Location = new System.Drawing.Point(5, 5);
            this.headerGroupSchedule.Name = "headerGroupSchedule";
            // 
            // headerGroupSchedule.Panel
            // 
            this.headerGroupSchedule.Panel.Controls.Add(this.cboPriority);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel12);
            this.headerGroupSchedule.Panel.Controls.Add(this.txtRemarks);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel10);
            this.headerGroupSchedule.Panel.Controls.Add(this.dtReaminder);
            this.headerGroupSchedule.Panel.Controls.Add(this.gridAssignees);
            this.headerGroupSchedule.Panel.Controls.Add(this.headerAssignee);
            this.headerGroupSchedule.Panel.Controls.Add(this.txtContactLocation);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel9);
            this.headerGroupSchedule.Panel.Controls.Add(this.txtContactNumbers);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel8);
            this.headerGroupSchedule.Panel.Controls.Add(this.txtContactPersons);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel7);
            this.headerGroupSchedule.Panel.Controls.Add(this.txtCompanyName);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel6);
            this.headerGroupSchedule.Panel.Controls.Add(this.dtScheduleEndDatetime);
            this.headerGroupSchedule.Panel.Controls.Add(this.dtScheduleStartDatetime);
            this.headerGroupSchedule.Panel.Controls.Add(this.txtSubject);
            this.headerGroupSchedule.Panel.Controls.Add(this.cboCallStatus);
            this.headerGroupSchedule.Panel.Controls.Add(this.cboActions);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel3);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel5);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel4);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel11);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupSchedule.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupSchedule.Panel.Controls.Add(this.linkLabelAddNewAction);
            this.headerGroupSchedule.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.headerGroupSchedule_Panel_Paint);
            this.headerGroupSchedule.Size = new System.Drawing.Size(819, 632);
            this.headerGroupSchedule.TabIndex = 0;
            this.headerGroupSchedule.ValuesPrimary.Heading = "Schedule a Business Call";
            this.headerGroupSchedule.ValuesPrimary.Image = null;
            this.headerGroupSchedule.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Text = "&Save Scheduled Call Info.";
            this.btnSave.UniqueName = "2CBF555A240243C589BA9347A69E56DE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "DCB73C44FB0942607585EE4ABDDDF085";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboPriority
            // 
            this.cboPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPriority.DropDownWidth = 148;
            this.cboPriority.Location = new System.Drawing.Point(375, 23);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.Size = new System.Drawing.Size(111, 21);
            this.cboPriority.TabIndex = 4;
            this.cboPriority.Text = "kryptonComboBox1";
            this.cboPriority.Validating += new System.ComponentModel.CancelEventHandler(this.cboPriority_Validating);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel12.Location = new System.Drawing.Point(370, 3);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel12.TabIndex = 3;
            this.kryptonLabel12.Values.Text = "&Priority";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(13, 470);
            this.txtRemarks.MaxLength = 1000;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(793, 74);
            this.txtRemarks.TabIndex = 26;
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(13, 449);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(148, 20);
            this.kryptonLabel10.TabIndex = 25;
            this.kryptonLabel10.Values.Text = "&Remarks or Reason Close";
            // 
            // dtReaminder
            // 
            this.dtReaminder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtReaminder.CustomFormat = "dd/MM/yy hh:mmtt";
            this.dtReaminder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReaminder.Location = new System.Drawing.Point(668, 98);
            this.dtReaminder.Name = "dtReaminder";
            this.dtReaminder.ShowUpDown = true;
            this.dtReaminder.Size = new System.Drawing.Size(138, 21);
            this.dtReaminder.TabIndex = 14;
            this.dtReaminder.ValueNullable = new System.DateTime(((long)(0)));
            this.dtReaminder.Validating += new System.ComponentModel.CancelEventHandler(this.dtReaminder_Validating);
            // 
            // gridAssignees
            // 
            this.gridAssignees.AllowUserToAddRows = false;
            this.gridAssignees.AllowUserToDeleteRows = false;
            this.gridAssignees.AllowUserToOrderColumns = true;
            this.gridAssignees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridAssignees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAssignees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAssignees.ColumnHeadersVisible = false;
            this.gridAssignees.Location = new System.Drawing.Point(13, 323);
            this.gridAssignees.Name = "gridAssignees";
            this.gridAssignees.ReadOnly = true;
            this.gridAssignees.RowHeadersVisible = false;
            this.gridAssignees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAssignees.Size = new System.Drawing.Size(793, 126);
            this.gridAssignees.TabIndex = 24;
            this.gridAssignees.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAssignees_CellDoubleClick);
            this.gridAssignees.Validating += new System.ComponentModel.CancelEventHandler(this.gridAssignees_Validating);
            // 
            // headerAssignee
            // 
            this.headerAssignee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerAssignee.AutoSize = false;
            this.headerAssignee.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewAssignee,
            this.btnRemoveAssignee});
            this.headerAssignee.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.headerAssignee.Location = new System.Drawing.Point(13, 289);
            this.headerAssignee.Name = "headerAssignee";
            this.headerAssignee.Size = new System.Drawing.Size(793, 30);
            this.headerAssignee.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5, -1, -1, -1);
            this.headerAssignee.TabIndex = 23;
            this.headerAssignee.Values.Description = "";
            this.headerAssignee.Values.Heading = "Assignee(s)";
            this.headerAssignee.Values.Image = null;
            // 
            // btnAddNewAssignee
            // 
            this.btnAddNewAssignee.Text = "&Add Assignee(s)";
            this.btnAddNewAssignee.UniqueName = "509679CACB5544159BAC57B2129081AA";
            this.btnAddNewAssignee.Click += new System.EventHandler(this.btnAddNewAssignee_Click);
            // 
            // btnRemoveAssignee
            // 
            this.btnRemoveAssignee.Text = "&Remove";
            this.btnRemoveAssignee.UniqueName = "F26B7507F339454F75AB965FF6529027";
            this.btnRemoveAssignee.Click += new System.EventHandler(this.btnRemoveAssignee_Click);
            // 
            // txtContactLocation
            // 
            this.txtContactLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactLocation.Location = new System.Drawing.Point(471, 177);
            this.txtContactLocation.Name = "txtContactLocation";
            this.txtContactLocation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtContactLocation.Size = new System.Drawing.Size(335, 107);
            this.txtContactLocation.TabIndex = 22;
            this.txtContactLocation.Text = "";
            this.txtContactLocation.Validating += new System.ComponentModel.CancelEventHandler(this.txtContactLocation_Validating);
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(469, 157);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(103, 20);
            this.kryptonLabel9.TabIndex = 21;
            this.kryptonLabel9.Values.Text = "Contact Location";
            // 
            // txtContactNumbers
            // 
            this.txtContactNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNumbers.Location = new System.Drawing.Point(219, 177);
            this.txtContactNumbers.Name = "txtContactNumbers";
            this.txtContactNumbers.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtContactNumbers.Size = new System.Drawing.Size(246, 107);
            this.txtContactNumbers.TabIndex = 20;
            this.txtContactNumbers.Text = "";
            this.txtContactNumbers.Validating += new System.ComponentModel.CancelEventHandler(this.txtContactNumbers_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(216, 157);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(114, 20);
            this.kryptonLabel8.TabIndex = 19;
            this.kryptonLabel8.Values.Text = "Contact Number(s)";
            // 
            // txtContactPersons
            // 
            this.txtContactPersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactPersons.Location = new System.Drawing.Point(13, 177);
            this.txtContactPersons.Name = "txtContactPersons";
            this.txtContactPersons.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtContactPersons.Size = new System.Drawing.Size(197, 107);
            this.txtContactPersons.TabIndex = 18;
            this.txtContactPersons.Text = "";
            this.txtContactPersons.Validating += new System.ComponentModel.CancelEventHandler(this.txtContactPersons_Validating);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(13, 157);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel7.TabIndex = 17;
            this.kryptonLabel7.Values.Text = "Contact Person(s)";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyName.Location = new System.Drawing.Point(130, 126);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCompanyName.Size = new System.Drawing.Size(676, 20);
            this.txtCompanyName.TabIndex = 16;
            this.txtCompanyName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCompanyName_Validating);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(13, 126);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(119, 20);
            this.kryptonLabel6.TabIndex = 15;
            this.kryptonLabel6.Values.Text = "Name of Company";
            // 
            // dtScheduleEndDatetime
            // 
            this.dtScheduleEndDatetime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtScheduleEndDatetime.CustomFormat = "dd/MM/yy hh:mmtt";
            this.dtScheduleEndDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtScheduleEndDatetime.Location = new System.Drawing.Point(439, 98);
            this.dtScheduleEndDatetime.Name = "dtScheduleEndDatetime";
            this.dtScheduleEndDatetime.Size = new System.Drawing.Size(135, 21);
            this.dtScheduleEndDatetime.TabIndex = 12;
            this.dtScheduleEndDatetime.Validating += new System.ComponentModel.CancelEventHandler(this.dtScheduleEndDatetime_Validating);
            // 
            // dtScheduleStartDatetime
            // 
            this.dtScheduleStartDatetime.CustomFormat = "dd/MM/yy hh:mmtt";
            this.dtScheduleStartDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtScheduleStartDatetime.Location = new System.Drawing.Point(65, 98);
            this.dtScheduleStartDatetime.Name = "dtScheduleStartDatetime";
            this.dtScheduleStartDatetime.Size = new System.Drawing.Size(137, 21);
            this.dtScheduleStartDatetime.TabIndex = 10;
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(13, 71);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubject.Size = new System.Drawing.Size(793, 20);
            this.txtSubject.TabIndex = 8;
            this.txtSubject.Validating += new System.ComponentModel.CancelEventHandler(this.txtSubject_Validating);
            // 
            // cboCallStatus
            // 
            this.cboCallStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCallStatus.DropDownWidth = 148;
            this.cboCallStatus.Location = new System.Drawing.Point(653, 23);
            this.cboCallStatus.Name = "cboCallStatus";
            this.cboCallStatus.Size = new System.Drawing.Size(153, 21);
            this.cboCallStatus.TabIndex = 6;
            this.cboCallStatus.Text = "kryptonComboBox1";
            this.cboCallStatus.Validating += new System.ComponentModel.CancelEventHandler(this.cboCallStatus_Validating);
            // 
            // cboActions
            // 
            this.cboActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboActions.DropDownWidth = 210;
            this.cboActions.Location = new System.Drawing.Point(13, 23);
            this.cboActions.Name = "cboActions";
            this.cboActions.Size = new System.Drawing.Size(343, 21);
            this.cboActions.TabIndex = 1;
            this.cboActions.Text = "kryptonComboBox1";
            this.cboActions.Validating += new System.ComponentModel.CancelEventHandler(this.cboActions_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 51);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(158, 20);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Business Call Subject Line";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel5.Location = new System.Drawing.Point(381, 98);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel5.TabIndex = 11;
            this.kryptonLabel5.Values.Text = "Ends At";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 98);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel4.TabIndex = 9;
            this.kryptonLabel4.Values.Text = "Starts at";
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel11.Location = new System.Drawing.Point(598, 98);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel11.TabIndex = 13;
            this.kryptonLabel11.Values.Text = "Alert from";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 3);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(46, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Action";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(653, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(44, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Status";
            // 
            // linkLabelAddNewAction
            // 
            this.linkLabelAddNewAction.Location = new System.Drawing.Point(221, 3);
            this.linkLabelAddNewAction.Name = "linkLabelAddNewAction";
            this.linkLabelAddNewAction.Size = new System.Drawing.Size(109, 20);
            this.linkLabelAddNewAction.TabIndex = 2;
            this.linkLabelAddNewAction.Values.Text = "Add a New Action";
            this.linkLabelAddNewAction.LinkClicked += new System.EventHandler(this.linkLabelAddNewAction_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmScheduleCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(829, 642);
            this.Controls.Add(this.headerGroupSchedule);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScheduleCall";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Business Call Info.";
            this.Load += new System.EventHandler(this.frmScheduleCall_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmScheduleCall_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule.Panel)).EndInit();
            this.headerGroupSchedule.Panel.ResumeLayout(false);
            this.headerGroupSchedule.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule)).EndInit();
            this.headerGroupSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAssignees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCallStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSchedule;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCallStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboActions;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtScheduleEndDatetime;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtScheduleStartDatetime;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtContactNumbers;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtContactPersons;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCompanyName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAssignees;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader headerAssignee;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewAssignee;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnRemoveAssignee;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtContactLocation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel linkLabelAddNewAction;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtReaminder;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboPriority;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
    }
}