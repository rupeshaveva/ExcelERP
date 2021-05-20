namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlScheduleCallLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupSchedule = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewSchedule = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditSchedule = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteSchedule = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.splitContainerSchedulesGrid = new System.Windows.Forms.SplitContainer();
            this.gridRecentSchedules = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchRecentSchedules = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gridPastSchedules = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupFollowUps = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewFollowup = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditFollowup = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteFollowup = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridFollowUps = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchFollowUps = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule.Panel)).BeginInit();
            this.headerGroupSchedule.Panel.SuspendLayout();
            this.headerGroupSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSchedulesGrid)).BeginInit();
            this.splitContainerSchedulesGrid.Panel1.SuspendLayout();
            this.splitContainerSchedulesGrid.Panel2.SuspendLayout();
            this.splitContainerSchedulesGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecentSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPastSchedules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowUps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowUps.Panel)).BeginInit();
            this.headerGroupFollowUps.Panel.SuspendLayout();
            this.headerGroupFollowUps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUps)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(7, 7);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupSchedule);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupFollowUps);
            this.splitContainerMain.Size = new System.Drawing.Size(799, 406);
            this.splitContainerMain.SplitterDistance = 262;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupSchedule
            // 
            this.headerGroupSchedule.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewSchedule,
            this.btnEditSchedule,
            this.btnDeleteSchedule});
            this.headerGroupSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupSchedule.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupSchedule.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupSchedule.Location = new System.Drawing.Point(0, 0);
            this.headerGroupSchedule.Name = "headerGroupSchedule";
            // 
            // headerGroupSchedule.Panel
            // 
            this.headerGroupSchedule.Panel.Controls.Add(this.splitContainerSchedulesGrid);
            this.headerGroupSchedule.Size = new System.Drawing.Size(262, 406);
            this.headerGroupSchedule.TabIndex = 0;
            this.headerGroupSchedule.ValuesPrimary.Heading = "Scheduled Business Call(s)";
            this.headerGroupSchedule.ValuesPrimary.Image = null;
            this.headerGroupSchedule.ValuesSecondary.Heading = "";
            // 
            // btnAddNewSchedule
            // 
            this.btnAddNewSchedule.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnAddNewSchedule.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnAddNewSchedule.Text = "&New Schedule";
            this.btnAddNewSchedule.UniqueName = "B1E464CF6DD1402EF2968586ED9C05C6";
            this.btnAddNewSchedule.Click += new System.EventHandler(this.btnAddNewSchedule_Click);
            // 
            // btnEditSchedule
            // 
            this.btnEditSchedule.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnEditSchedule.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnEditSchedule.Text = "&Edit";
            this.btnEditSchedule.UniqueName = "01F8A64CAB3E415E478B613BA5F2A1F4";
            this.btnEditSchedule.Click += new System.EventHandler(this.btnEditSchedule_Click);
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnDeleteSchedule.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnDeleteSchedule.Text = "&Delete";
            this.btnDeleteSchedule.UniqueName = "E4D9E49456D64FB6368E8384F6229B9B";
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // splitContainerSchedulesGrid
            // 
            this.splitContainerSchedulesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSchedulesGrid.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSchedulesGrid.Name = "splitContainerSchedulesGrid";
            this.splitContainerSchedulesGrid.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSchedulesGrid.Panel1
            // 
            this.splitContainerSchedulesGrid.Panel1.Controls.Add(this.gridRecentSchedules);
            this.splitContainerSchedulesGrid.Panel1.Controls.Add(this.txtSearchRecentSchedules);
            this.splitContainerSchedulesGrid.Panel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // splitContainerSchedulesGrid.Panel2
            // 
            this.splitContainerSchedulesGrid.Panel2.Controls.Add(this.gridPastSchedules);
            this.splitContainerSchedulesGrid.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainerSchedulesGrid.Size = new System.Drawing.Size(260, 355);
            this.splitContainerSchedulesGrid.SplitterDistance = 165;
            this.splitContainerSchedulesGrid.TabIndex = 1;
            // 
            // gridRecentSchedules
            // 
            this.gridRecentSchedules.AllowUserToAddRows = false;
            this.gridRecentSchedules.AllowUserToDeleteRows = false;
            this.gridRecentSchedules.AllowUserToOrderColumns = true;
            this.gridRecentSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRecentSchedules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridRecentSchedules.ColumnHeadersHeight = 28;
            this.gridRecentSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRecentSchedules.Location = new System.Drawing.Point(1, 24);
            this.gridRecentSchedules.Name = "gridRecentSchedules";
            this.gridRecentSchedules.ReadOnly = true;
            this.gridRecentSchedules.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecentSchedules.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRecentSchedules.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRecentSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRecentSchedules.Size = new System.Drawing.Size(258, 140);
            this.gridRecentSchedules.TabIndex = 3;
            this.gridRecentSchedules.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRecentSchedules_RowEnter);
            // 
            // txtSearchRecentSchedules
            // 
            this.txtSearchRecentSchedules.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchRecentSchedules.Location = new System.Drawing.Point(1, 1);
            this.txtSearchRecentSchedules.Name = "txtSearchRecentSchedules";
            this.txtSearchRecentSchedules.Size = new System.Drawing.Size(258, 23);
            this.txtSearchRecentSchedules.TabIndex = 1;
            this.txtSearchRecentSchedules.TextChanged += new System.EventHandler(this.txtSearchRecentSchedules_TextChanged);
            // 
            // gridPastSchedules
            // 
            this.gridPastSchedules.AllowUserToAddRows = false;
            this.gridPastSchedules.AllowUserToDeleteRows = false;
            this.gridPastSchedules.AllowUserToOrderColumns = true;
            this.gridPastSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPastSchedules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridPastSchedules.ColumnHeadersHeight = 28;
            this.gridPastSchedules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPastSchedules.Location = new System.Drawing.Point(1, 1);
            this.gridPastSchedules.Name = "gridPastSchedules";
            this.gridPastSchedules.ReadOnly = true;
            this.gridPastSchedules.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPastSchedules.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridPastSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPastSchedules.Size = new System.Drawing.Size(258, 184);
            this.gridPastSchedules.TabIndex = 2;
            this.gridPastSchedules.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPastSchedules_RowEnter);
            // 
            // headerGroupFollowUps
            // 
            this.headerGroupFollowUps.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewFollowup,
            this.btnEditFollowup,
            this.btnDeleteFollowup});
            this.headerGroupFollowUps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupFollowUps.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupFollowUps.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupFollowUps.Location = new System.Drawing.Point(0, 0);
            this.headerGroupFollowUps.Name = "headerGroupFollowUps";
            // 
            // headerGroupFollowUps.Panel
            // 
            this.headerGroupFollowUps.Panel.Controls.Add(this.gridFollowUps);
            this.headerGroupFollowUps.Panel.Controls.Add(this.txtSearchFollowUps);
            this.headerGroupFollowUps.Panel.Padding = new System.Windows.Forms.Padding(1);
            this.headerGroupFollowUps.Size = new System.Drawing.Size(532, 406);
            this.headerGroupFollowUps.TabIndex = 1;
            this.headerGroupFollowUps.ValuesPrimary.Heading = "FollowUp(s) for selected Schedule";
            this.headerGroupFollowUps.ValuesPrimary.Image = null;
            this.headerGroupFollowUps.ValuesSecondary.Heading = "";
            // 
            // btnAddNewFollowup
            // 
            this.btnAddNewFollowup.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnAddNewFollowup.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnAddNewFollowup.Text = "&Add New Followup";
            this.btnAddNewFollowup.UniqueName = "82E14E702E92433177A42BA710FC6FC4";
            this.btnAddNewFollowup.Click += new System.EventHandler(this.btnAddNewFollowup_Click);
            // 
            // btnEditFollowup
            // 
            this.btnEditFollowup.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnEditFollowup.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnEditFollowup.Text = "&Edit Selected FollowUp";
            this.btnEditFollowup.UniqueName = "13FFB5BA3FD440F7DCB1D14DC4296791";
            this.btnEditFollowup.Click += new System.EventHandler(this.btnEditFollowup_Click);
            // 
            // btnDeleteFollowup
            // 
            this.btnDeleteFollowup.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnDeleteFollowup.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnDeleteFollowup.Text = "&Delete";
            this.btnDeleteFollowup.UniqueName = "A31D787EA4FB4BC595B50C42C50A6E71";
            this.btnDeleteFollowup.Click += new System.EventHandler(this.btnDeleteFollowup_Click);
            // 
            // gridFollowUps
            // 
            this.gridFollowUps.AllowUserToAddRows = false;
            this.gridFollowUps.AllowUserToDeleteRows = false;
            this.gridFollowUps.AllowUserToOrderColumns = true;
            this.gridFollowUps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFollowUps.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridFollowUps.ColumnHeadersHeight = 25;
            this.gridFollowUps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFollowUps.Location = new System.Drawing.Point(1, 24);
            this.gridFollowUps.Name = "gridFollowUps";
            this.gridFollowUps.ReadOnly = true;
            this.gridFollowUps.RowHeadersVisible = false;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFollowUps.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridFollowUps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFollowUps.Size = new System.Drawing.Size(528, 330);
            this.gridFollowUps.TabIndex = 5;
            this.gridFollowUps.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFollowUps_RowEnter);
            // 
            // txtSearchFollowUps
            // 
            this.txtSearchFollowUps.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchFollowUps.Location = new System.Drawing.Point(1, 1);
            this.txtSearchFollowUps.Name = "txtSearchFollowUps";
            this.txtSearchFollowUps.Size = new System.Drawing.Size(528, 23);
            this.txtSearchFollowUps.TabIndex = 0;
            this.txtSearchFollowUps.TextChanged += new System.EventHandler(this.txtSearchFollowUps_TextChanged);
            // 
            // ctrlScheduleCallLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "ctrlScheduleCallLog";
            this.Padding = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Size = new System.Drawing.Size(813, 420);
            this.Resize += new System.EventHandler(this.ctrlScheduleCallLog_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule.Panel)).EndInit();
            this.headerGroupSchedule.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule)).EndInit();
            this.headerGroupSchedule.ResumeLayout(false);
            this.splitContainerSchedulesGrid.Panel1.ResumeLayout(false);
            this.splitContainerSchedulesGrid.Panel1.PerformLayout();
            this.splitContainerSchedulesGrid.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSchedulesGrid)).EndInit();
            this.splitContainerSchedulesGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRecentSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPastSchedules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowUps.Panel)).EndInit();
            this.headerGroupFollowUps.Panel.ResumeLayout(false);
            this.headerGroupFollowUps.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowUps)).EndInit();
            this.headerGroupFollowUps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFollowUps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSchedule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewSchedule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditSchedule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteSchedule;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupFollowUps;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewFollowup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditFollowup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteFollowup;
        private System.Windows.Forms.SplitContainer splitContainerSchedulesGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridRecentSchedules;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchRecentSchedules;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridPastSchedules;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchFollowUps;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridFollowUps;
    }
}
