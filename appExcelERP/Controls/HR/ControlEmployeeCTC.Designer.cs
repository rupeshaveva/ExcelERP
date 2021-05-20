namespace appExcelERP.Controls.HR
{
    partial class ControlEmployeeCTC
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
            this.headerGroupSummary = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.txtYearlyCTC = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblYearlySalary = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMonthlySalary = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblMonthlySalary = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtTotalDeduction = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblTotalDeduction = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtTotalAllounce = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblTotalAllounce = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupAllounces = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateAllounces = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCollapseAllounces = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAllounces = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupDeduction = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateDeduction = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCollapseDeductions = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridDeductions = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSummary.Panel)).BeginInit();
            this.headerGroupSummary.Panel.SuspendLayout();
            this.headerGroupSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAllounces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAllounces.Panel)).BeginInit();
            this.headerGroupAllounces.Panel.SuspendLayout();
            this.headerGroupAllounces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllounces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeduction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeduction.Panel)).BeginInit();
            this.headerGroupDeduction.Panel.SuspendLayout();
            this.headerGroupDeduction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeductions)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupSummary
            // 
            this.headerGroupSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerGroupSummary.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupSummary.Location = new System.Drawing.Point(0, 254);
            this.headerGroupSummary.Name = "headerGroupSummary";
            // 
            // headerGroupSummary.Panel
            // 
            this.headerGroupSummary.Panel.Controls.Add(this.txtYearlyCTC);
            this.headerGroupSummary.Panel.Controls.Add(this.lblYearlySalary);
            this.headerGroupSummary.Panel.Controls.Add(this.txtMonthlySalary);
            this.headerGroupSummary.Panel.Controls.Add(this.lblMonthlySalary);
            this.headerGroupSummary.Panel.Controls.Add(this.txtTotalDeduction);
            this.headerGroupSummary.Panel.Controls.Add(this.lblTotalDeduction);
            this.headerGroupSummary.Panel.Controls.Add(this.txtTotalAllounce);
            this.headerGroupSummary.Panel.Controls.Add(this.lblTotalAllounce);
            this.headerGroupSummary.Size = new System.Drawing.Size(588, 109);
            this.headerGroupSummary.TabIndex = 2;
            this.headerGroupSummary.ValuesPrimary.Heading = "CTC Summary";
            this.headerGroupSummary.ValuesPrimary.Image = null;
            // 
            // txtYearlyCTC
            // 
            this.txtYearlyCTC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtYearlyCTC.Location = new System.Drawing.Point(477, 29);
            this.txtYearlyCTC.Name = "txtYearlyCTC";
            this.txtYearlyCTC.Size = new System.Drawing.Size(90, 20);
            this.txtYearlyCTC.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYearlyCTC.TabIndex = 13;
            this.txtYearlyCTC.Text = "kryptonTextBox5";
            this.txtYearlyCTC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblYearlySalary
            // 
            this.lblYearlySalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYearlySalary.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblYearlySalary.Location = new System.Drawing.Point(503, 6);
            this.lblYearlySalary.Name = "lblYearlySalary";
            this.lblYearlySalary.Size = new System.Drawing.Size(72, 20);
            this.lblYearlySalary.TabIndex = 12;
            this.lblYearlySalary.Values.Text = "Yearly CTC";
            // 
            // txtMonthlySalary
            // 
            this.txtMonthlySalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMonthlySalary.Location = new System.Drawing.Point(356, 29);
            this.txtMonthlySalary.Name = "txtMonthlySalary";
            this.txtMonthlySalary.Size = new System.Drawing.Size(90, 20);
            this.txtMonthlySalary.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonthlySalary.TabIndex = 11;
            this.txtMonthlySalary.Text = "kryptonTextBox4";
            this.txtMonthlySalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMonthlySalary
            // 
            this.lblMonthlySalary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonthlySalary.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblMonthlySalary.Location = new System.Drawing.Point(360, 6);
            this.lblMonthlySalary.Name = "lblMonthlySalary";
            this.lblMonthlySalary.Size = new System.Drawing.Size(86, 20);
            this.lblMonthlySalary.TabIndex = 10;
            this.lblMonthlySalary.Values.Text = "Monthly CTC";
            // 
            // txtTotalDeduction
            // 
            this.txtTotalDeduction.Location = new System.Drawing.Point(111, 29);
            this.txtTotalDeduction.Name = "txtTotalDeduction";
            this.txtTotalDeduction.Size = new System.Drawing.Size(93, 20);
            this.txtTotalDeduction.TabIndex = 9;
            this.txtTotalDeduction.Text = "kryptonTextBox3";
            this.txtTotalDeduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalDeduction
            // 
            this.lblTotalDeduction.Location = new System.Drawing.Point(111, 6);
            this.lblTotalDeduction.Name = "lblTotalDeduction";
            this.lblTotalDeduction.Size = new System.Drawing.Size(98, 20);
            this.lblTotalDeduction.TabIndex = 8;
            this.lblTotalDeduction.Values.Text = "Total Deduction";
            // 
            // txtTotalAllounce
            // 
            this.txtTotalAllounce.Location = new System.Drawing.Point(7, 29);
            this.txtTotalAllounce.Name = "txtTotalAllounce";
            this.txtTotalAllounce.Size = new System.Drawing.Size(98, 20);
            this.txtTotalAllounce.TabIndex = 7;
            this.txtTotalAllounce.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalAllounce
            // 
            this.lblTotalAllounce.Location = new System.Drawing.Point(11, 6);
            this.lblTotalAllounce.Name = "lblTotalAllounce";
            this.lblTotalAllounce.Size = new System.Drawing.Size(97, 20);
            this.lblTotalAllounce.TabIndex = 6;
            this.lblTotalAllounce.Values.Text = "Total Allowance";
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.headerGroupAllounces);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.headerGroupDeduction);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(588, 254);
            this.kryptonSplitContainer1.SplitterDistance = 296;
            this.kryptonSplitContainer1.TabIndex = 3;
            // 
            // headerGroupAllounces
            // 
            this.headerGroupAllounces.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateAllounces,
            this.btnCollapseAllounces});
            this.headerGroupAllounces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupAllounces.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupAllounces.Location = new System.Drawing.Point(0, 0);
            this.headerGroupAllounces.Name = "headerGroupAllounces";
            // 
            // headerGroupAllounces.Panel
            // 
            this.headerGroupAllounces.Panel.Controls.Add(this.gridAllounces);
            this.headerGroupAllounces.Size = new System.Drawing.Size(296, 254);
            this.headerGroupAllounces.TabIndex = 0;
            this.headerGroupAllounces.ValuesPrimary.Heading = "Allowance";
            this.headerGroupAllounces.ValuesPrimary.Image = null;
            this.headerGroupAllounces.ValuesSecondary.Heading = "Edit (Double Click)";
            // 
            // btnUpdateAllounces
            // 
            this.btnUpdateAllounces.Image = global::appExcelERP.Properties.Resources.SaveAll_16x;
            this.btnUpdateAllounces.Text = "&Update";
            this.btnUpdateAllounces.UniqueName = "BB000A9EBF934CC777808C5CA9E6EFFE";
            this.btnUpdateAllounces.Click += new System.EventHandler(this.btnUpdateAllounces_Click);
            // 
            // btnCollapseAllounces
            // 
            this.btnCollapseAllounces.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnCollapseAllounces.Image = global::appExcelERP.Properties.Resources.BranchRelationshipCousin_16x;
            this.btnCollapseAllounces.ImageStates.ImageCheckedPressed = global::appExcelERP.Properties.Resources.BranchRelationshipChild_16x;
            this.btnCollapseAllounces.UniqueName = "C6164EED3B7548234F890038D6AF765D";
            this.btnCollapseAllounces.Click += new System.EventHandler(this.btnCollapseAllounces_Click);
            // 
            // gridAllounces
            // 
            this.gridAllounces.AllowUserToAddRows = false;
            this.gridAllounces.AllowUserToDeleteRows = false;
            this.gridAllounces.AllowUserToOrderColumns = true;
            this.gridAllounces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAllounces.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAllounces.ColumnHeadersHeight = 28;
            this.gridAllounces.ColumnHeadersVisible = false;
            this.gridAllounces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAllounces.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAllounces.Location = new System.Drawing.Point(0, 0);
            this.gridAllounces.MultiSelect = false;
            this.gridAllounces.Name = "gridAllounces";
            this.gridAllounces.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAllounces.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAllounces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAllounces.Size = new System.Drawing.Size(294, 204);
            this.gridAllounces.TabIndex = 13;
            this.gridAllounces.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAllounces_CellDoubleClick);
            this.gridAllounces.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridAllounces_DataBindingComplete);
            // 
            // headerGroupDeduction
            // 
            this.headerGroupDeduction.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateDeduction,
            this.btnCollapseDeductions});
            this.headerGroupDeduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupDeduction.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDeduction.Location = new System.Drawing.Point(0, 0);
            this.headerGroupDeduction.Name = "headerGroupDeduction";
            // 
            // headerGroupDeduction.Panel
            // 
            this.headerGroupDeduction.Panel.Controls.Add(this.gridDeductions);
            this.headerGroupDeduction.Size = new System.Drawing.Size(287, 254);
            this.headerGroupDeduction.TabIndex = 1;
            this.headerGroupDeduction.ValuesPrimary.Heading = "Deductions";
            this.headerGroupDeduction.ValuesPrimary.Image = null;
            this.headerGroupDeduction.ValuesSecondary.Heading = "Edit (Double Click)";
            // 
            // btnUpdateDeduction
            // 
            this.btnUpdateDeduction.Image = global::appExcelERP.Properties.Resources.SaveAll_16x;
            this.btnUpdateDeduction.Text = "&Update";
            this.btnUpdateDeduction.UniqueName = "110A67F78DFA49DE07879875C1F82746";
            this.btnUpdateDeduction.Click += new System.EventHandler(this.btnUpdateDeduction_Click);
            // 
            // btnCollapseDeductions
            // 
            this.btnCollapseDeductions.Image = global::appExcelERP.Properties.Resources.BranchRelationshipCousin_16x;
            this.btnCollapseDeductions.UniqueName = "219693F4AEAC49F2B5A95815E76A4419";
            this.btnCollapseDeductions.Click += new System.EventHandler(this.btnCollapseDeductions_Click);
            // 
            // gridDeductions
            // 
            this.gridDeductions.AllowUserToAddRows = false;
            this.gridDeductions.AllowUserToDeleteRows = false;
            this.gridDeductions.AllowUserToOrderColumns = true;
            this.gridDeductions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDeductions.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridDeductions.ColumnHeadersHeight = 28;
            this.gridDeductions.ColumnHeadersVisible = false;
            this.gridDeductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDeductions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDeductions.Location = new System.Drawing.Point(0, 0);
            this.gridDeductions.MultiSelect = false;
            this.gridDeductions.Name = "gridDeductions";
            this.gridDeductions.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDeductions.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridDeductions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDeductions.Size = new System.Drawing.Size(285, 204);
            this.gridDeductions.TabIndex = 15;
            this.gridDeductions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDeductions_CellDoubleClick);
            this.gridDeductions.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridDeductions_DataBindingComplete);
            // 
            // ControlEmployeeCTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Controls.Add(this.headerGroupSummary);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlEmployeeCTC";
            this.Size = new System.Drawing.Size(588, 363);
            this.Load += new System.EventHandler(this.ControlEmployeeCTC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSummary.Panel)).EndInit();
            this.headerGroupSummary.Panel.ResumeLayout(false);
            this.headerGroupSummary.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSummary)).EndInit();
            this.headerGroupSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAllounces.Panel)).EndInit();
            this.headerGroupAllounces.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAllounces)).EndInit();
            this.headerGroupAllounces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAllounces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeduction.Panel)).EndInit();
            this.headerGroupDeduction.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeduction)).EndInit();
            this.headerGroupDeduction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDeductions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSummary;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtYearlyCTC;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblYearlySalary;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMonthlySalary;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMonthlySalary;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTotalDeduction;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalDeduction;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtTotalAllounce;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTotalAllounce;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupAllounces;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAllounces;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDeduction;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDeductions;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateAllounces;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateDeduction;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCollapseAllounces;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCollapseDeductions;
    }
}
