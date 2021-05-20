namespace appExcelERP.Controls.HR.Attendance
{
    partial class PageAttendanceChartView
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
            this.headerGroupOptions = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnPrepareMonthlySheet = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtAttendanceMonth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSearchActiveUsers = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.gridActiveEmployees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupActiveEmployees = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewUser = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditUser = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteUser = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtSearchActiveEmployees = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SplitContainerChartView = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).BeginInit();
            this.headerGroupOptions.Panel.SuspendLayout();
            this.headerGroupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActiveEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupActiveEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupActiveEmployees.Panel)).BeginInit();
            this.headerGroupActiveEmployees.Panel.SuspendLayout();
            this.headerGroupActiveEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerChartView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerChartView.Panel1)).BeginInit();
            this.SplitContainerChartView.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerChartView.Panel2)).BeginInit();
            this.SplitContainerChartView.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupOptions
            // 
            this.headerGroupOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupOptions.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupOptions.HeaderVisibleSecondary = false;
            this.headerGroupOptions.Location = new System.Drawing.Point(0, 0);
            this.headerGroupOptions.Name = "headerGroupOptions";
            // 
            // headerGroupOptions.Panel
            // 
            this.headerGroupOptions.Panel.Controls.Add(this.btnPrepareMonthlySheet);
            this.headerGroupOptions.Panel.Controls.Add(this.dtAttendanceMonth);
            this.headerGroupOptions.Panel.Controls.Add(this.label17);
            this.headerGroupOptions.Size = new System.Drawing.Size(1235, 63);
            this.headerGroupOptions.TabIndex = 3;
            this.headerGroupOptions.ValuesPrimary.Heading = "Attendance Chart Viewer";
            this.headerGroupOptions.ValuesPrimary.Image = null;
            this.headerGroupOptions.ValuesSecondary.Heading = " ";
            // 
            // btnPrepareMonthlySheet
            // 
            this.btnPrepareMonthlySheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrepareMonthlySheet.Location = new System.Drawing.Point(1019, 6);
            this.btnPrepareMonthlySheet.Name = "btnPrepareMonthlySheet";
            this.btnPrepareMonthlySheet.Size = new System.Drawing.Size(195, 25);
            this.btnPrepareMonthlySheet.TabIndex = 137;
            this.btnPrepareMonthlySheet.Values.Text = "Generate Attendace Chart";
            this.btnPrepareMonthlySheet.Click += new System.EventHandler(this.btnPrepareMonthlySheet_Click);
            // 
            // dtAttendanceMonth
            // 
            this.dtAttendanceMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtAttendanceMonth.CustomFormat = "MMMM yyyy";
            this.dtAttendanceMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAttendanceMonth.Location = new System.Drawing.Point(908, 10);
            this.dtAttendanceMonth.Name = "dtAttendanceMonth";
            this.dtAttendanceMonth.Size = new System.Drawing.Size(105, 21);
            this.dtAttendanceMonth.TabIndex = 120;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(862, 10);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 20);
            this.label17.TabIndex = 119;
            this.label17.Values.Text = "&Month";
            // 
            // btnSearchActiveUsers
            // 
            this.btnSearchActiveUsers.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchActiveUsers.Text = "&Search";
            this.btnSearchActiveUsers.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            this.btnSearchActiveUsers.Click += new System.EventHandler(this.btnSearchActiveUsers_Click);
            // 
            // gridActiveEmployees
            // 
            this.gridActiveEmployees.AllowUserToAddRows = false;
            this.gridActiveEmployees.AllowUserToDeleteRows = false;
            this.gridActiveEmployees.AllowUserToOrderColumns = true;
            this.gridActiveEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridActiveEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridActiveEmployees.ColumnHeadersHeight = 28;
            this.gridActiveEmployees.ColumnHeadersVisible = false;
            this.gridActiveEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridActiveEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridActiveEmployees.Location = new System.Drawing.Point(3, 31);
            this.gridActiveEmployees.MultiSelect = false;
            this.gridActiveEmployees.Name = "gridActiveEmployees";
            this.gridActiveEmployees.ReadOnly = true;
            this.gridActiveEmployees.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridActiveEmployees.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridActiveEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridActiveEmployees.Size = new System.Drawing.Size(371, 500);
            this.gridActiveEmployees.TabIndex = 11;
            this.gridActiveEmployees.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridActiveEmployees_RowEnter);
            // 
            // headerGroupActiveEmployees
            // 
            this.headerGroupActiveEmployees.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewUser,
            this.btnEditUser,
            this.btnDeleteUser});
            this.headerGroupActiveEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupActiveEmployees.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupActiveEmployees.Location = new System.Drawing.Point(0, 0);
            this.headerGroupActiveEmployees.Name = "headerGroupActiveEmployees";
            // 
            // headerGroupActiveEmployees.Panel
            // 
            this.headerGroupActiveEmployees.Panel.Controls.Add(this.gridActiveEmployees);
            this.headerGroupActiveEmployees.Panel.Controls.Add(this.txtSearchActiveEmployees);
            this.headerGroupActiveEmployees.Panel.Padding = new System.Windows.Forms.Padding(3);
            this.headerGroupActiveEmployees.Size = new System.Drawing.Size(379, 579);
            this.headerGroupActiveEmployees.TabIndex = 9;
            this.headerGroupActiveEmployees.ValuesPrimary.Heading = "Employees";
            this.headerGroupActiveEmployees.ValuesPrimary.Image = null;
            this.headerGroupActiveEmployees.ValuesSecondary.Description = ".";
            this.headerGroupActiveEmployees.ValuesSecondary.Heading = "";
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Text = "&Add New";
            this.btnAddNewUser.UniqueName = "D1F31FEC8B2446CD948D558A31F54422";
            this.btnAddNewUser.Visible = false;
            // 
            // btnEditUser
            // 
            this.btnEditUser.Text = "&Edit";
            this.btnEditUser.UniqueName = "15D7627576B34537FAAB735C262660C9";
            this.btnEditUser.Visible = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Text = "&Delete";
            this.btnDeleteUser.UniqueName = "6CA1CF28F7D144EAE09940A3A89BA948";
            this.btnDeleteUser.Visible = false;
            // 
            // txtSearchActiveEmployees
            // 
            this.txtSearchActiveEmployees.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchActiveUsers});
            this.txtSearchActiveEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchActiveEmployees.Location = new System.Drawing.Point(3, 3);
            this.txtSearchActiveEmployees.Name = "txtSearchActiveEmployees";
            this.txtSearchActiveEmployees.Size = new System.Drawing.Size(371, 28);
            this.txtSearchActiveEmployees.TabIndex = 10;
            // 
            // SplitContainerChartView
            // 
            this.SplitContainerChartView.Cursor = System.Windows.Forms.Cursors.Default;
            this.SplitContainerChartView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerChartView.Location = new System.Drawing.Point(0, 63);
            this.SplitContainerChartView.Name = "SplitContainerChartView";
            // 
            // SplitContainerChartView.Panel1
            // 
            this.SplitContainerChartView.Panel1.Controls.Add(this.headerGroupActiveEmployees);
            this.SplitContainerChartView.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.SplitContainerChartView.Size = new System.Drawing.Size(1235, 579);
            this.SplitContainerChartView.SplitterDistance = 379;
            this.SplitContainerChartView.TabIndex = 10;
            // 
            // PageAttendanceChartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerChartView);
            this.Controls.Add(this.headerGroupOptions);
            this.Name = "PageAttendanceChartView";
            this.Size = new System.Drawing.Size(1235, 642);
            this.Load += new System.EventHandler(this.PageAttendanceChartView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).EndInit();
            this.headerGroupOptions.Panel.ResumeLayout(false);
            this.headerGroupOptions.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).EndInit();
            this.headerGroupOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridActiveEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupActiveEmployees.Panel)).EndInit();
            this.headerGroupActiveEmployees.Panel.ResumeLayout(false);
            this.headerGroupActiveEmployees.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupActiveEmployees)).EndInit();
            this.headerGroupActiveEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerChartView.Panel1)).EndInit();
            this.SplitContainerChartView.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerChartView.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerChartView)).EndInit();
            this.SplitContainerChartView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOptions;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrepareMonthlySheet;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtAttendanceMonth;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchActiveUsers;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridActiveEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupActiveEmployees;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewUser;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditUser;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteUser;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchActiveEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer SplitContainerChartView;
    }
}
