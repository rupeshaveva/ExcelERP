namespace appExcelERP.Controls.USER_INFO
{
    partial class PageMyPayslips
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
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupPayslipMonths = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridPayslips = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchPayslips = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchMyPayslip = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipMonths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipMonths.Panel)).BeginInit();
            this.headerGroupPayslipMonths.Panel.SuspendLayout();
            this.headerGroupPayslipMonths.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPayslips)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.headerGroupMain.Size = new System.Drawing.Size(871, 459);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Image = null;
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.headerGroupPayslipMonths);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(869, 435);
            this.kryptonSplitContainer1.SplitterDistance = 289;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // headerGroupPayslipMonths
            // 
            this.headerGroupPayslipMonths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupPayslipMonths.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.headerGroupPayslipMonths.HeaderVisibleSecondary = false;
            this.headerGroupPayslipMonths.Location = new System.Drawing.Point(0, 0);
            this.headerGroupPayslipMonths.Name = "headerGroupPayslipMonths";
            // 
            // headerGroupPayslipMonths.Panel
            // 
            this.headerGroupPayslipMonths.Panel.Controls.Add(this.gridPayslips);
            this.headerGroupPayslipMonths.Panel.Controls.Add(this.txtSearchPayslips);
            this.headerGroupPayslipMonths.Size = new System.Drawing.Size(289, 435);
            this.headerGroupPayslipMonths.TabIndex = 0;
            this.headerGroupPayslipMonths.ValuesPrimary.Heading = "Payslips Month";
            this.headerGroupPayslipMonths.ValuesPrimary.Image = null;
            // 
            // gridPayslips
            // 
            this.gridPayslips.AllowUserToAddRows = false;
            this.gridPayslips.AllowUserToDeleteRows = false;
            this.gridPayslips.AllowUserToOrderColumns = true;
            this.gridPayslips.AllowUserToResizeColumns = false;
            this.gridPayslips.AllowUserToResizeRows = false;
            this.gridPayslips.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPayslips.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridPayslips.ColumnHeadersVisible = false;
            this.gridPayslips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPayslips.Location = new System.Drawing.Point(0, 28);
            this.gridPayslips.Name = "gridPayslips";
            this.gridPayslips.ReadOnly = true;
            this.gridPayslips.RowHeadersVisible = false;
            this.gridPayslips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPayslips.Size = new System.Drawing.Size(287, 384);
            this.gridPayslips.TabIndex = 1;
            this.gridPayslips.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridPayslips_DataBindingComplete);
            this.gridPayslips.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPayslips_RowEnter);
            // 
            // txtSearchPayslips
            // 
            this.txtSearchPayslips.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchMyPayslip});
            this.txtSearchPayslips.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchPayslips.Location = new System.Drawing.Point(0, 0);
            this.txtSearchPayslips.Name = "txtSearchPayslips";
            this.txtSearchPayslips.Size = new System.Drawing.Size(287, 28);
            this.txtSearchPayslips.TabIndex = 0;
            // 
            // btnSearchMyPayslip
            // 
            this.btnSearchMyPayslip.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchMyPayslip.Text = "&Search";
            this.btnSearchMyPayslip.UniqueName = "A51DE04CBD4643D535B90ACE1004A581";
            this.btnSearchMyPayslip.Click += new System.EventHandler(this.btnSearchMyPayslip_Click);
            // 
            // PageMyPayslips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "PageMyPayslips";
            this.Size = new System.Drawing.Size(871, 459);
            this.Load += new System.EventHandler(this.PageMyPayslips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipMonths.Panel)).EndInit();
            this.headerGroupPayslipMonths.Panel.ResumeLayout(false);
            this.headerGroupPayslipMonths.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPayslipMonths)).EndInit();
            this.headerGroupPayslipMonths.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPayslips)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupPayslipMonths;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridPayslips;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchPayslips;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchMyPayslip;
    }
}
