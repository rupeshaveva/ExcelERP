namespace appExcelERP.Controls.HR.Attendance
{
    partial class PageAttendanceSummaryView
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
            this.btnExportToExcel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAttendanceSummary = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtAttendanceMonth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtSearchOnsiteEmployee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnPrepareMonthlySheet = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSearchAttendanceSummary = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).BeginInit();
            this.headerGroupOptions.Panel.SuspendLayout();
            this.headerGroupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupOptions
            // 
            this.headerGroupOptions.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnExportToExcel});
            this.headerGroupOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupOptions.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupOptions.Location = new System.Drawing.Point(0, 0);
            this.headerGroupOptions.Name = "headerGroupOptions";
            // 
            // headerGroupOptions.Panel
            // 
            this.headerGroupOptions.Panel.Controls.Add(this.gridAttendanceSummary);
            this.headerGroupOptions.Panel.Controls.Add(this.kryptonPanel1);
            this.headerGroupOptions.Size = new System.Drawing.Size(1005, 451);
            this.headerGroupOptions.TabIndex = 4;
            this.headerGroupOptions.ValuesPrimary.Heading = "Attendance Summary Viewer (Monthly)";
            this.headerGroupOptions.ValuesPrimary.Image = null;
            this.headerGroupOptions.ValuesSecondary.Heading = " ";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::appExcelERP.Properties.Resources.ExportToExcel_16x;
            this.btnExportToExcel.UniqueName = "2D661F8B38A24E0FF2BBB05F8D638B99";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // gridAttendanceSummary
            // 
            this.gridAttendanceSummary.AllowUserToAddRows = false;
            this.gridAttendanceSummary.AllowUserToDeleteRows = false;
            this.gridAttendanceSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAttendanceSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAttendanceSummary.ColumnHeadersHeight = 50;
            this.gridAttendanceSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttendanceSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAttendanceSummary.Location = new System.Drawing.Point(0, 41);
            this.gridAttendanceSummary.Margin = new System.Windows.Forms.Padding(2);
            this.gridAttendanceSummary.Name = "gridAttendanceSummary";
            this.gridAttendanceSummary.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAttendanceSummary.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAttendanceSummary.RowTemplate.Height = 24;
            this.gridAttendanceSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttendanceSummary.Size = new System.Drawing.Size(1003, 362);
            this.gridAttendanceSummary.TabIndex = 141;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.dtAttendanceMonth);
            this.kryptonPanel1.Controls.Add(this.txtSearchOnsiteEmployee);
            this.kryptonPanel1.Controls.Add(this.label17);
            this.kryptonPanel1.Controls.Add(this.btnPrepareMonthlySheet);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1003, 41);
            this.kryptonPanel1.TabIndex = 140;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(579, 9);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(47, 20);
            this.kryptonLabel1.TabIndex = 138;
            this.kryptonLabel1.Values.Text = "Search";
            // 
            // dtAttendanceMonth
            // 
            this.dtAttendanceMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtAttendanceMonth.CustomFormat = "MMMM yyyy";
            this.dtAttendanceMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAttendanceMonth.Location = new System.Drawing.Point(54, 9);
            this.dtAttendanceMonth.Name = "dtAttendanceMonth";
            this.dtAttendanceMonth.Size = new System.Drawing.Size(105, 21);
            this.dtAttendanceMonth.TabIndex = 120;
            // 
            // txtSearchOnsiteEmployee
            // 
            this.txtSearchOnsiteEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchOnsiteEmployee.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchAttendanceSummary});
            this.txtSearchOnsiteEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchOnsiteEmployee.Location = new System.Drawing.Point(632, 9);
            this.txtSearchOnsiteEmployee.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchOnsiteEmployee.Name = "txtSearchOnsiteEmployee";
            this.txtSearchOnsiteEmployee.Size = new System.Drawing.Size(362, 28);
            this.txtSearchOnsiteEmployee.TabIndex = 138;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(8, 9);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 20);
            this.label17.TabIndex = 119;
            this.label17.Values.Text = "&Month";
            // 
            // btnPrepareMonthlySheet
            // 
            this.btnPrepareMonthlySheet.Location = new System.Drawing.Point(165, 7);
            this.btnPrepareMonthlySheet.Name = "btnPrepareMonthlySheet";
            this.btnPrepareMonthlySheet.Size = new System.Drawing.Size(158, 25);
            this.btnPrepareMonthlySheet.TabIndex = 137;
            this.btnPrepareMonthlySheet.Values.Text = "Generate Sheet";
            this.btnPrepareMonthlySheet.Click += new System.EventHandler(this.btnPrepareMonthlySheet_Click);
            // 
            // btnSearchAttendanceSummary
            // 
            this.btnSearchAttendanceSummary.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchAttendanceSummary.Text = "&Search";
            this.btnSearchAttendanceSummary.UniqueName = "AB2E498B479A4AF98CA7D232359651BE";
            this.btnSearchAttendanceSummary.Click += new System.EventHandler(this.btnSearchAttendanceSummary_Click);
            // 
            // PageAttendanceSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupOptions);
            this.Name = "PageAttendanceSummaryView";
            this.Size = new System.Drawing.Size(1005, 451);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).EndInit();
            this.headerGroupOptions.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).EndInit();
            this.headerGroupOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendanceSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOptions;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrepareMonthlySheet;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtAttendanceMonth;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAttendanceSummary;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchOnsiteEmployee;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnExportToExcel;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchAttendanceSummary;
    }
}
