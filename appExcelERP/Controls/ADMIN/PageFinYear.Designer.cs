namespace appExcelERP.Controls.ADMIN
{
    partial class PageFinYear
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupFinYears = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewFinYear = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditFinYear = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteFinYear = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridFinYears = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchFinYears = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchActiveUsers = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.headerGroupOptions = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnGenerateVoucherNoSetup = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnGenerateLeaveConfigurationForEmployees = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtProgress = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFinYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFinYears.Panel)).BeginInit();
            this.headerGroupFinYears.Panel.SuspendLayout();
            this.headerGroupFinYears.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFinYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).BeginInit();
            this.headerGroupOptions.Panel.SuspendLayout();
            this.headerGroupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.headerGroupMain.Size = new System.Drawing.Size(779, 422);
            this.headerGroupMain.TabIndex = 0;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.headerGroupFinYears);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.headerGroupOptions);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(777, 369);
            this.kryptonSplitContainer1.SplitterDistance = 259;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // headerGroupFinYears
            // 
            this.headerGroupFinYears.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewFinYear,
            this.btnEditFinYear,
            this.btnDeleteFinYear});
            this.headerGroupFinYears.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupFinYears.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupFinYears.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Form;
            this.headerGroupFinYears.Location = new System.Drawing.Point(0, 0);
            this.headerGroupFinYears.Name = "headerGroupFinYears";
            // 
            // headerGroupFinYears.Panel
            // 
            this.headerGroupFinYears.Panel.Controls.Add(this.gridFinYears);
            this.headerGroupFinYears.Panel.Controls.Add(this.txtSearchFinYears);
            this.headerGroupFinYears.Size = new System.Drawing.Size(259, 369);
            this.headerGroupFinYears.TabIndex = 0;
            this.headerGroupFinYears.ValuesPrimary.Heading = "Financial Years";
            this.headerGroupFinYears.ValuesPrimary.Image = null;
            // 
            // btnAddNewFinYear
            // 
            this.btnAddNewFinYear.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewFinYear.Text = "&Add New";
            this.btnAddNewFinYear.UniqueName = "678B57C1A71E438A8DA9D41703DD80F2";
            this.btnAddNewFinYear.Click += new System.EventHandler(this.btnAddNewFinYear_Click);
            // 
            // btnEditFinYear
            // 
            this.btnEditFinYear.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x1;
            this.btnEditFinYear.Text = "&Edit";
            this.btnEditFinYear.UniqueName = "047B7CAAD9B04F7D6A9D2A1E0A7EBBE7";
            this.btnEditFinYear.Click += new System.EventHandler(this.btnEditFinYear_Click);
            // 
            // btnDeleteFinYear
            // 
            this.btnDeleteFinYear.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteFinYear.Text = "&Delete";
            this.btnDeleteFinYear.UniqueName = "E3B4A33226434F446BB7706649F0E08E";
            this.btnDeleteFinYear.Click += new System.EventHandler(this.btnDeleteFinYear_Click);
            // 
            // gridFinYears
            // 
            this.gridFinYears.AllowUserToAddRows = false;
            this.gridFinYears.AllowUserToDeleteRows = false;
            this.gridFinYears.AllowUserToOrderColumns = true;
            this.gridFinYears.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFinYears.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridFinYears.ColumnHeadersHeight = 28;
            this.gridFinYears.ColumnHeadersVisible = false;
            this.gridFinYears.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFinYears.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridFinYears.Location = new System.Drawing.Point(0, 28);
            this.gridFinYears.MultiSelect = false;
            this.gridFinYears.Name = "gridFinYears";
            this.gridFinYears.ReadOnly = true;
            this.gridFinYears.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFinYears.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridFinYears.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFinYears.Size = new System.Drawing.Size(257, 292);
            this.gridFinYears.TabIndex = 12;
            this.gridFinYears.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFinYears_RowEnter);
            // 
            // txtSearchFinYears
            // 
            this.txtSearchFinYears.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchActiveUsers});
            this.txtSearchFinYears.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchFinYears.Location = new System.Drawing.Point(0, 0);
            this.txtSearchFinYears.Name = "txtSearchFinYears";
            this.txtSearchFinYears.Size = new System.Drawing.Size(257, 28);
            this.txtSearchFinYears.TabIndex = 11;
            this.txtSearchFinYears.TextChanged += new System.EventHandler(this.txtSearchFinYears_TextChanged);
            // 
            // btnSearchActiveUsers
            // 
            this.btnSearchActiveUsers.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchActiveUsers.Text = "&Search";
            this.btnSearchActiveUsers.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // headerGroupOptions
            // 
            this.headerGroupOptions.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnGenerateVoucherNoSetup,
            this.btnGenerateLeaveConfigurationForEmployees});
            this.headerGroupOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupOptions.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupOptions.Location = new System.Drawing.Point(0, 0);
            this.headerGroupOptions.Name = "headerGroupOptions";
            // 
            // headerGroupOptions.Panel
            // 
            this.headerGroupOptions.Panel.Controls.Add(this.txtProgress);
            this.headerGroupOptions.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupOptions.Size = new System.Drawing.Size(513, 369);
            this.headerGroupOptions.TabIndex = 0;
            this.headerGroupOptions.ValuesPrimary.Heading = "Options";
            this.headerGroupOptions.ValuesPrimary.Image = null;
            // 
            // btnGenerateVoucherNoSetup
            // 
            this.btnGenerateVoucherNoSetup.Text = "&Generate Voucher No Setup";
            this.btnGenerateVoucherNoSetup.UniqueName = "62BFE876863249C1F1A600D12EE70DB8";
            // 
            // btnGenerateLeaveConfigurationForEmployees
            // 
            this.btnGenerateLeaveConfigurationForEmployees.Text = "&Generate Leave Config. for Employees";
            this.btnGenerateLeaveConfigurationForEmployees.UniqueName = "AB0774C42C884FC99B89EF1D6D8BC60B";
            this.btnGenerateLeaveConfigurationForEmployees.Click += new System.EventHandler(this.btnGenerateLeaveConfigurationForEmployees_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgress.Location = new System.Drawing.Point(5, 5);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(501, 309);
            this.txtProgress.TabIndex = 0;
            this.txtProgress.Text = "kryptonRichTextBox1";
            // 
            // PageFinYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "PageFinYear";
            this.Size = new System.Drawing.Size(779, 422);
            this.Load += new System.EventHandler(this.PageFinYear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFinYears.Panel)).EndInit();
            this.headerGroupFinYears.Panel.ResumeLayout(false);
            this.headerGroupFinYears.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFinYears)).EndInit();
            this.headerGroupFinYears.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFinYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions.Panel)).EndInit();
            this.headerGroupOptions.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupOptions)).EndInit();
            this.headerGroupOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupFinYears;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewFinYear;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditFinYear;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteFinYear;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchFinYears;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchActiveUsers;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridFinYears;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupOptions;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnGenerateVoucherNoSetup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnGenerateLeaveConfigurationForEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtProgress;
    }
}
