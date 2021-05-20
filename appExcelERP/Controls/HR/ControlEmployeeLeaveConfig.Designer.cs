namespace appExcelERP.Controls.HR
{
    partial class ControlEmployeeLeaveConfig
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
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupFY = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridFY = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchFA = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gridLeaves = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupYearlyLeaves = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnAddNewYearlyLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnEditYearlyLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonDockingManager1 = new ComponentFactory.Krypton.Docking.KryptonDockingManager();
            this.btnSearchFA = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFY.Panel)).BeginInit();
            this.headerGroupFY.Panel.SuspendLayout();
            this.headerGroupFY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaves)).BeginInit();
            this.SuspendLayout();
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
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.headerGroupFY);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.gridLeaves);
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.headerGroupYearlyLeaves);
            this.kryptonSplitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(696, 420);
            this.kryptonSplitContainer1.SplitterDistance = 169;
            this.kryptonSplitContainer1.SplitterWidth = 7;
            this.kryptonSplitContainer1.TabIndex = 1;
            // 
            // headerGroupFY
            // 
            this.headerGroupFY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupFY.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupFY.Location = new System.Drawing.Point(0, 0);
            this.headerGroupFY.Name = "headerGroupFY";
            // 
            // headerGroupFY.Panel
            // 
            this.headerGroupFY.Panel.Controls.Add(this.gridFY);
            this.headerGroupFY.Panel.Controls.Add(this.txtSearchFA);
            this.headerGroupFY.Size = new System.Drawing.Size(169, 420);
            this.headerGroupFY.TabIndex = 0;
            this.headerGroupFY.ValuesPrimary.Heading = "Financial Years";
            this.headerGroupFY.ValuesPrimary.Image = null;
            // 
            // gridFY
            // 
            this.gridFY.AllowUserToAddRows = false;
            this.gridFY.AllowUserToDeleteRows = false;
            this.gridFY.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFY.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFY.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridFY.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridFY.CausesValidation = false;
            this.gridFY.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridFY.ColumnHeadersVisible = false;
            this.gridFY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridFY.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridFY.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridFY.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridFY.Location = new System.Drawing.Point(0, 28);
            this.gridFY.MultiSelect = false;
            this.gridFY.Name = "gridFY";
            this.gridFY.ReadOnly = true;
            this.gridFY.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFY.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridFY.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFY.Size = new System.Drawing.Size(167, 347);
            this.gridFY.StandardTab = true;
            this.gridFY.TabIndex = 16;
            this.gridFY.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridFY_RowEnter);
            // 
            // txtSearchFA
            // 
            this.txtSearchFA.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchFA});
            this.txtSearchFA.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchFA.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchFA.Location = new System.Drawing.Point(0, 0);
            this.txtSearchFA.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchFA.Name = "txtSearchFA";
            this.txtSearchFA.Size = new System.Drawing.Size(167, 28);
            this.txtSearchFA.TabIndex = 15;
           // 
            // gridLeaves
            // 
            this.gridLeaves.AllowUserToAddRows = false;
            this.gridLeaves.AllowUserToDeleteRows = false;
            this.gridLeaves.AllowUserToOrderColumns = true;
            this.gridLeaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLeaves.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLeaves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLeaves.Location = new System.Drawing.Point(3, 31);
            this.gridLeaves.Name = "gridLeaves";
            this.gridLeaves.ReadOnly = true;
            this.gridLeaves.RowHeadersVisible = false;
            this.gridLeaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLeaves.Size = new System.Drawing.Size(514, 386);
            this.gridLeaves.TabIndex = 5;
            this.gridLeaves.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLeaves_RowEnter);
            this.gridLeaves.DoubleClick += new System.EventHandler(this.gridLeaves_DoubleClick);
            // 
            // headerGroupYearlyLeaves
            // 
            this.headerGroupYearlyLeaves.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewYearlyLeave,
            this.btnEditYearlyLeave});
            this.headerGroupYearlyLeaves.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupYearlyLeaves.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupYearlyLeaves.Location = new System.Drawing.Point(3, 3);
            this.headerGroupYearlyLeaves.Name = "headerGroupYearlyLeaves";
            this.headerGroupYearlyLeaves.Size = new System.Drawing.Size(514, 28);
            this.headerGroupYearlyLeaves.TabIndex = 4;
            this.headerGroupYearlyLeaves.Values.Description = " ";
            this.headerGroupYearlyLeaves.Values.Heading = "Yearly Leaves Settings";
            this.headerGroupYearlyLeaves.Values.Image = null;
            // 
            // btnAddNewYearlyLeave
            // 
            this.btnAddNewYearlyLeave.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddNewYearlyLeave.Text = "&Add";
            this.btnAddNewYearlyLeave.UniqueName = "BBA117FD695B429FB794A562DB5DE4DE";
            this.btnAddNewYearlyLeave.Click += new System.EventHandler(this.btnAddNewYearlyLeave_Click);
            // 
            // btnEditYearlyLeave
            // 
            this.btnEditYearlyLeave.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditYearlyLeave.Text = "&Edit";
            this.btnEditYearlyLeave.UniqueName = "B3B02139D3E447B7AC97BC3F33E6573F";
            this.btnEditYearlyLeave.Click += new System.EventHandler(this.btnEditYearlyLeave_Click);
            // 
            // btnSearchFA
            // 
            this.btnSearchFA.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchFA.Text = "&Search";
            this.btnSearchFA.UniqueName = "D773DF9AB4DA4EB0918060A0431ED166";
            this.btnSearchFA.Click += new System.EventHandler(this.btnSearchFA_Click);
            // 
            // ControlEmployeeLeaveConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonSplitContainer1);
            this.Name = "ControlEmployeeLeaveConfig";
            this.Size = new System.Drawing.Size(696, 420);
            this.Load += new System.EventHandler(this.ControlEmployeeLeaveConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            this.kryptonSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFY.Panel)).EndInit();
            this.headerGroupFY.Panel.ResumeLayout(false);
            this.headerGroupFY.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFY)).EndInit();
            this.headerGroupFY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaves)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupFY;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridFY;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchFA;
        private ComponentFactory.Krypton.Docking.KryptonDockingManager kryptonDockingManager1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLeaves;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader headerGroupYearlyLeaves;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewYearlyLeave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnEditYearlyLeave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchFA;
    }
}
