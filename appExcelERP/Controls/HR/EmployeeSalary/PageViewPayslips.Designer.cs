namespace appExcelERP.Controls.HR.EmployeeSalary
{
    partial class PageViewPayslips
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnExportMonthlyPayrollTooExcel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.headerGroupPayslipSheet = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnApprovePayslip = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridPayslips = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchEmployee = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchPayslipViewer = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrepareMonthlySheet = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtPayslipMonth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipSheet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipSheet.Panel)).BeginInit();
            this.headerGroupPayslipSheet.Panel.SuspendLayout();
            this.headerGroupPayslipSheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayslips)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRefresh,
            this.btnExportMonthlyPayrollTooExcel});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.headerGroupPayslipSheet);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.panel1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(806, 362);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Payslip Viewer";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.UniqueName = "E20814971BC34198E1B3BD830DC063F5";
            // 
            // btnExportMonthlyPayrollTooExcel
            // 
            this.btnExportMonthlyPayrollTooExcel.Image = global::appExcelERP.Properties.Resources.ExportToExcel_16x1;
            this.btnExportMonthlyPayrollTooExcel.UniqueName = "18B8F33D7F0D4F87C9A24D7E5DEDB8EA";
            this.btnExportMonthlyPayrollTooExcel.Click += new System.EventHandler(this.btnExportMonthlyPayrollTooExcel_Click);
            // 
            // headerGroupPayslipSheet
            // 
            this.headerGroupPayslipSheet.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnApprovePayslip});
            this.headerGroupPayslipSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupPayslipSheet.HeaderVisiblePrimary = false;
            this.headerGroupPayslipSheet.Location = new System.Drawing.Point(0, 32);
            this.headerGroupPayslipSheet.Name = "headerGroupPayslipSheet";
            // 
            // headerGroupPayslipSheet.Panel
            // 
            this.headerGroupPayslipSheet.Panel.Controls.Add(this.gridPayslips);
            this.headerGroupPayslipSheet.Panel.Controls.Add(this.txtSearchEmployee);
            this.headerGroupPayslipSheet.Size = new System.Drawing.Size(804, 303);
            this.headerGroupPayslipSheet.TabIndex = 23;
            // 
            // btnApprovePayslip
            // 
            this.btnApprovePayslip.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnApprovePayslip.Text = "&Approve";
            this.btnApprovePayslip.UniqueName = "24C46A204A594F25399405A01D7DFE38";
            this.btnApprovePayslip.Click += new System.EventHandler(this.btnApprovePayslip_Click);
            // 
            // gridPayslips
            // 
            this.gridPayslips.AllowUserToAddRows = false;
            this.gridPayslips.AllowUserToDeleteRows = false;
            this.gridPayslips.AllowUserToOrderColumns = true;
            this.gridPayslips.AllowUserToResizeColumns = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPayslips.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridPayslips.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridPayslips.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridPayslips.CausesValidation = false;
            this.gridPayslips.ColumnHeadersHeight = 60;
            this.gridPayslips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPayslips.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPayslips.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridPayslips.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridPayslips.Location = new System.Drawing.Point(0, 28);
            this.gridPayslips.MultiSelect = false;
            this.gridPayslips.Name = "gridPayslips";
            this.gridPayslips.ReadOnly = true;
            this.gridPayslips.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPayslips.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridPayslips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPayslips.Size = new System.Drawing.Size(802, 246);
            this.gridPayslips.StandardTab = true;
            this.gridPayslips.TabIndex = 23;
            this.gridPayslips.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridPayslips_DataBindingComplete);
            this.gridPayslips.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPayslips_RowEnter);
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchPayslipViewer});
            this.txtSearchEmployee.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchEmployee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchEmployee.Location = new System.Drawing.Point(0, 0);
            this.txtSearchEmployee.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(802, 28);
            this.txtSearchEmployee.TabIndex = 19;
            this.txtSearchEmployee.TextChanged += new System.EventHandler(this.txtSearchEmployee_TextChanged);
            // 
            // btnSearchPayslipViewer
            // 
            this.btnSearchPayslipViewer.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchPayslipViewer.Text = "&Search";
            this.btnSearchPayslipViewer.UniqueName = "4685CDB8A5D04CACC6BA2713408ED6F2";
            this.btnSearchPayslipViewer.Click += new System.EventHandler(this.btnSearchPayslipViewer_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrepareMonthlySheet);
            this.panel1.Controls.Add(this.dtPayslipMonth);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 32);
            this.panel1.TabIndex = 22;
            // 
            // btnPrepareMonthlySheet
            // 
            this.btnPrepareMonthlySheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrepareMonthlySheet.Location = new System.Drawing.Point(662, 3);
            this.btnPrepareMonthlySheet.Name = "btnPrepareMonthlySheet";
            this.btnPrepareMonthlySheet.Size = new System.Drawing.Size(139, 25);
            this.btnPrepareMonthlySheet.TabIndex = 140;
            this.btnPrepareMonthlySheet.Values.Text = "Show Payslips ";
            this.btnPrepareMonthlySheet.Click += new System.EventHandler(this.btnPrepareMonthlySheet_Click);
            // 
            // dtPayslipMonth
            // 
            this.dtPayslipMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtPayslipMonth.CustomFormat = "MMMM yyyy";
            this.dtPayslipMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPayslipMonth.Location = new System.Drawing.Point(551, 7);
            this.dtPayslipMonth.Name = "dtPayslipMonth";
            this.dtPayslipMonth.Size = new System.Drawing.Size(105, 21);
            this.dtPayslipMonth.TabIndex = 139;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(505, 7);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 20);
            this.label17.TabIndex = 138;
            this.label17.Values.Text = "&Month";
            // 
            // PageViewPayslips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "PageViewPayslips";
            this.Size = new System.Drawing.Size(806, 362);
            this.Load += new System.EventHandler(this.PayViewPayslips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipSheet.Panel)).EndInit();
            this.headerGroupPayslipSheet.Panel.ResumeLayout(false);
            this.headerGroupPayslipSheet.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipSheet)).EndInit();
            this.headerGroupPayslipSheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPayslips)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchEmployee;
        private System.Windows.Forms.Panel panel1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupPayslipSheet;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnPrepareMonthlySheet;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtPayslipMonth;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridPayslips;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnApprovePayslip;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnExportMonthlyPayrollTooExcel;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchPayslipViewer;
    }
}
