namespace appExcelERP.Controls.HR
{
    partial class PageLoanDisbursement
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
            this.gridLoanDisbursement = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.hederGroupLoanDisbursement = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnApproveDisbursement = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAddNewLoan = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditLoan = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteLoan = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtSearchLoanDisbursementGrid = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchLoanDisbursement = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoanDisbursement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanDisbursement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanDisbursement.Panel)).BeginInit();
            this.hederGroupLoanDisbursement.Panel.SuspendLayout();
            this.hederGroupLoanDisbursement.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridLoanDisbursement
            // 
            this.gridLoanDisbursement.AllowUserToAddRows = false;
            this.gridLoanDisbursement.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoanDisbursement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLoanDisbursement.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLoanDisbursement.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLoanDisbursement.CausesValidation = false;
            this.gridLoanDisbursement.ColumnHeadersHeight = 25;
            this.gridLoanDisbursement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLoanDisbursement.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLoanDisbursement.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridLoanDisbursement.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridLoanDisbursement.Location = new System.Drawing.Point(0, 28);
            this.gridLoanDisbursement.MultiSelect = false;
            this.gridLoanDisbursement.Name = "gridLoanDisbursement";
            this.gridLoanDisbursement.ReadOnly = true;
            this.gridLoanDisbursement.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoanDisbursement.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLoanDisbursement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLoanDisbursement.Size = new System.Drawing.Size(640, 383);
            this.gridLoanDisbursement.StandardTab = true;
            this.gridLoanDisbursement.TabIndex = 16;
            this.gridLoanDisbursement.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoanDisbursement_RowEnter);
            // 
            // hederGroupLoanDisbursement
            // 
            this.hederGroupLoanDisbursement.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnApproveDisbursement,
            this.btnAddNewLoan,
            this.btnEditLoan,
            this.btnDeleteLoan,
            this.btnRefresh});
            this.hederGroupLoanDisbursement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hederGroupLoanDisbursement.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.hederGroupLoanDisbursement.Location = new System.Drawing.Point(0, 0);
            this.hederGroupLoanDisbursement.Name = "hederGroupLoanDisbursement";
            // 
            // hederGroupLoanDisbursement.Panel
            // 
            this.hederGroupLoanDisbursement.Panel.Controls.Add(this.gridLoanDisbursement);
            this.hederGroupLoanDisbursement.Panel.Controls.Add(this.txtSearchLoanDisbursementGrid);
            this.hederGroupLoanDisbursement.Size = new System.Drawing.Size(642, 461);
            this.hederGroupLoanDisbursement.TabIndex = 4;
            this.hederGroupLoanDisbursement.ValuesPrimary.Heading = "Loan Disbursement Register";
            this.hederGroupLoanDisbursement.ValuesPrimary.Image = null;
            // 
            // btnApproveDisbursement
            // 
            this.btnApproveDisbursement.Image = global::appExcelERP.Properties.Resources.EnableLog_16x;
            this.btnApproveDisbursement.Text = "&Approve";
            this.btnApproveDisbursement.UniqueName = "3A6E2FC295D749CFCE8BD4F2B298A9FD";
            this.btnApproveDisbursement.Click += new System.EventHandler(this.btnApproveDisbursement_Click);
            // 
            // btnAddNewLoan
            // 
            this.btnAddNewLoan.Image = global::appExcelERP.Properties.Resources.Sequence_16x;
            this.btnAddNewLoan.Text = "&Add New";
            this.btnAddNewLoan.UniqueName = "B240F2CCB1D94F5426AAB3027D1A95C3";
            this.btnAddNewLoan.Click += new System.EventHandler(this.btnAddNewLoan_Click);
            // 
            // btnEditLoan
            // 
            this.btnEditLoan.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditLoan.Text = "Edit";
            this.btnEditLoan.UniqueName = "F8F5F0B610F242902180C38DEBE7C8E2";
            this.btnEditLoan.Click += new System.EventHandler(this.btnEditLoan_Click);
            // 
            // btnDeleteLoan
            // 
            this.btnDeleteLoan.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteLoan.Text = "&Delete";
            this.btnDeleteLoan.UniqueName = "1A2995E9EC7C4F7056B6B7E990536629";
            this.btnDeleteLoan.Click += new System.EventHandler(this.btnDeleteLoan_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "9C673832B4B1475199B31DAA2EA319FA";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearchLoanDisbursementGrid
            // 
            this.txtSearchLoanDisbursementGrid.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchLoanDisbursement});
            this.txtSearchLoanDisbursementGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchLoanDisbursementGrid.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchLoanDisbursementGrid.Location = new System.Drawing.Point(0, 0);
            this.txtSearchLoanDisbursementGrid.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchLoanDisbursementGrid.Name = "txtSearchLoanDisbursementGrid";
            this.txtSearchLoanDisbursementGrid.Size = new System.Drawing.Size(640, 28);
            this.txtSearchLoanDisbursementGrid.TabIndex = 15;
            // 
            // btnSearchLoanDisbursement
            // 
            this.btnSearchLoanDisbursement.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchLoanDisbursement.Text = "&Search";
            this.btnSearchLoanDisbursement.UniqueName = "3158987B9B4B4AD63A83983483E9B7B7";
            this.btnSearchLoanDisbursement.Click += new System.EventHandler(this.btnSearchLoanDisbursement_Click);
            // 
            // PageLoanDisbursement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hederGroupLoanDisbursement);
            this.Name = "PageLoanDisbursement";
            this.Size = new System.Drawing.Size(642, 461);
            this.Load += new System.EventHandler(this.PageLoanDisbursement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLoanDisbursement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanDisbursement.Panel)).EndInit();
            this.hederGroupLoanDisbursement.Panel.ResumeLayout(false);
            this.hederGroupLoanDisbursement.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanDisbursement)).EndInit();
            this.hederGroupLoanDisbursement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLoanDisbursement;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hederGroupLoanDisbursement;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewLoan;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditLoan;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteLoan;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchLoanDisbursementGrid;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnApproveDisbursement;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchLoanDisbursement;
    }
}
