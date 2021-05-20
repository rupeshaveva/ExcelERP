namespace appExcelERP.Controls.HR.Attendance
{
    partial class PageImportAttendance
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
            this.headerGroupProcess = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnPostOfficeAttendanceToExcelERP = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAttendance = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchEmployeeName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.headerGroupOfficeInput = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnFetchOfficeAttendance = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.dtEndDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtStartDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnSearchEmployeeName = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProcess.Panel)).BeginInit();
            this.headerGroupProcess.Panel.SuspendLayout();
            this.headerGroupProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOfficeInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOfficeInput.Panel)).BeginInit();
            this.headerGroupOfficeInput.Panel.SuspendLayout();
            this.headerGroupOfficeInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupProcess
            // 
            this.headerGroupProcess.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnPostOfficeAttendanceToExcelERP});
            this.headerGroupProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupProcess.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupProcess.HeaderVisiblePrimary = false;
            this.headerGroupProcess.Location = new System.Drawing.Point(0, 98);
            this.headerGroupProcess.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupProcess.Name = "headerGroupProcess";
            // 
            // headerGroupProcess.Panel
            // 
            this.headerGroupProcess.Panel.Controls.Add(this.gridAttendance);
            this.headerGroupProcess.Panel.Controls.Add(this.txtSearchEmployeeName);
            this.headerGroupProcess.Panel.Padding = new System.Windows.Forms.Padding(2);
            this.headerGroupProcess.Size = new System.Drawing.Size(726, 274);
            this.headerGroupProcess.TabIndex = 6;
            this.headerGroupProcess.ValuesPrimary.Heading = "";
            this.headerGroupProcess.ValuesPrimary.Image = null;
            this.headerGroupProcess.ValuesSecondary.Heading = "Process Status";
            // 
            // btnPostOfficeAttendanceToExcelERP
            // 
            this.btnPostOfficeAttendanceToExcelERP.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnPostOfficeAttendanceToExcelERP.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnPostOfficeAttendanceToExcelERP.Text = "Post Attendance to Excel ERP";
            this.btnPostOfficeAttendanceToExcelERP.UniqueName = "B405B452DD7E4526D4869BEE20661DA9";
            this.btnPostOfficeAttendanceToExcelERP.Click += new System.EventHandler(this.btnPostAttendanceToExcelERP_Click);
            // 
            // gridAttendance
            // 
            this.gridAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAttendance.ColumnHeadersHeight = 28;
            this.gridAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttendance.Location = new System.Drawing.Point(2, 30);
            this.gridAttendance.Margin = new System.Windows.Forms.Padding(2);
            this.gridAttendance.Name = "gridAttendance";
            this.gridAttendance.ReadOnly = true;
            this.gridAttendance.RowHeadersVisible = false;
            this.gridAttendance.RowTemplate.Height = 24;
            this.gridAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttendance.Size = new System.Drawing.Size(720, 211);
            this.gridAttendance.TabIndex = 2;
            // 
            // txtSearchEmployeeName
            // 
            this.txtSearchEmployeeName.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchEmployeeName});
            this.txtSearchEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchEmployeeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchEmployeeName.Location = new System.Drawing.Point(2, 2);
            this.txtSearchEmployeeName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchEmployeeName.Name = "txtSearchEmployeeName";
            this.txtSearchEmployeeName.Size = new System.Drawing.Size(720, 28);
            this.txtSearchEmployeeName.TabIndex = 1;
            // 
            // headerGroupOfficeInput
            // 
            this.headerGroupOfficeInput.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnFetchOfficeAttendance});
            this.headerGroupOfficeInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupOfficeInput.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupOfficeInput.Location = new System.Drawing.Point(0, 0);
            this.headerGroupOfficeInput.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupOfficeInput.Name = "headerGroupOfficeInput";
            // 
            // headerGroupOfficeInput.Panel
            // 
            this.headerGroupOfficeInput.Panel.Controls.Add(this.dtEndDate);
            this.headerGroupOfficeInput.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupOfficeInput.Panel.Controls.Add(this.dtStartDate);
            this.headerGroupOfficeInput.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupOfficeInput.Size = new System.Drawing.Size(726, 98);
            this.headerGroupOfficeInput.TabIndex = 5;
            this.headerGroupOfficeInput.ValuesPrimary.Heading = "Sync. Attendance data from SmartOffice to Excel-ERP";
            this.headerGroupOfficeInput.ValuesPrimary.Image = null;
            this.headerGroupOfficeInput.ValuesSecondary.Heading = "";
            // 
            // btnFetchOfficeAttendance
            // 
            this.btnFetchOfficeAttendance.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnFetchOfficeAttendance.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnFetchOfficeAttendance.Text = "&Fetch Attendance from SmartOffice";
            this.btnFetchOfficeAttendance.UniqueName = "EDDC9DB22D99491F1985D734A0BD11C1";
            this.btnFetchOfficeAttendance.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // dtEndDate
            // 
            this.dtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtEndDate.Location = new System.Drawing.Point(556, 8);
            this.dtEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtEndDate.Name = "dtEndDate";
            this.dtEndDate.Size = new System.Drawing.Size(156, 21);
            this.dtEndDate.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(496, 8);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Till Date";
            // 
            // dtStartDate
            // 
            this.dtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtStartDate.Location = new System.Drawing.Point(325, 8);
            this.dtStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Size = new System.Drawing.Size(161, 21);
            this.dtStartDate.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(253, 8);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(68, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "From Date";
            // 
            // btnSearchEmployeeName
            // 
            this.btnSearchEmployeeName.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchEmployeeName.Text = "&Search";
            this.btnSearchEmployeeName.UniqueName = "A3747606380440848EA26C227CDF6612";
            this.btnSearchEmployeeName.Click += new System.EventHandler(this.btnSearchEmployeeName_Click);
            // 
            // PageImportAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupProcess);
            this.Controls.Add(this.headerGroupOfficeInput);
            this.Name = "PageImportAttendance";
            this.Size = new System.Drawing.Size(726, 372);
            this.Load += new System.EventHandler(this.PageImportAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProcess.Panel)).EndInit();
            this.headerGroupProcess.Panel.ResumeLayout(false);
            this.headerGroupProcess.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProcess)).EndInit();
            this.headerGroupProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOfficeInput.Panel)).EndInit();
            this.headerGroupOfficeInput.Panel.ResumeLayout(false);
            this.headerGroupOfficeInput.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOfficeInput)).EndInit();
            this.headerGroupOfficeInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupProcess;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnPostOfficeAttendanceToExcelERP;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAttendance;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchEmployeeName;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOfficeInput;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnFetchOfficeAttendance;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtEndDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtStartDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchEmployeeName;
    }
}
