namespace appExcelERP.Controls.InventoryItemControls
{
    partial class ControlInventoryItemSuppliers
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
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddSuppliers = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveSupplier = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridSupplier = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchSupplier = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddSuppliers,
            this.btnRemoveSupplier});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.gridSupplier);
            this.headerGroupMain.Panel.Controls.Add(this.txtSearchSupplier);
            this.headerGroupMain.Size = new System.Drawing.Size(694, 374);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Suppliers";
            this.headerGroupMain.ValuesPrimary.Image = null;
            this.headerGroupMain.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonHeaderGroup1_Paint);
            // 
            // btnAddSuppliers
            // 
            this.btnAddSuppliers.Image = global::appExcelERP.Properties.Resources.RequestPlugin_16x;
            this.btnAddSuppliers.Text = "&Add Suppliers";
            this.btnAddSuppliers.UniqueName = "83FBE2E0FAEF4B1C97A9076E65A2E05A";
            this.btnAddSuppliers.Click += new System.EventHandler(this.btnAddSuppliers_Click);
            // 
            // btnRemoveSupplier
            // 
            this.btnRemoveSupplier.Image = global::appExcelERP.Properties.Resources.RemoveGuide_16x;
            this.btnRemoveSupplier.Text = "Remove Selected";
            this.btnRemoveSupplier.UniqueName = "768EEA2CDD3C4B5144AF3C98DC64C81D";
            this.btnRemoveSupplier.Click += new System.EventHandler(this.btnRemoveSupplier_Click);
            // 
            // gridSupplier
            // 
            this.gridSupplier.AllowUserToAddRows = false;
            this.gridSupplier.AllowUserToDeleteRows = false;
            this.gridSupplier.AllowUserToOrderColumns = true;
            this.gridSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSupplier.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSupplier.ColumnHeadersVisible = false;
            this.gridSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSupplier.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSupplier.Location = new System.Drawing.Point(0, 26);
            this.gridSupplier.Name = "gridSupplier";
            this.gridSupplier.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSupplier.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSupplier.Size = new System.Drawing.Size(692, 295);
            this.gridSupplier.TabIndex = 7;
            // 
            // txtSearchSupplier
            // 
            this.txtSearchSupplier.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearch});
            this.txtSearchSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchSupplier.Location = new System.Drawing.Point(0, 0);
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(692, 26);
            this.txtSearchSupplier.TabIndex = 6;
            this.txtSearchSupplier.TextChanged += new System.EventHandler(this.txtSearchSupplier_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Text = "&Search";
            this.btnSearch.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // ControlInventoryItemSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "ControlInventoryItemSuppliers";
            this.Size = new System.Drawing.Size(694, 374);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            this.headerGroupMain.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddSuppliers;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveSupplier;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridSupplier;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchSupplier;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearch;
    }
}
