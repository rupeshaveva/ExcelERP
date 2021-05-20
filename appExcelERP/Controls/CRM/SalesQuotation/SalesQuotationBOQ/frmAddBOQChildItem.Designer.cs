namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    partial class frmAddBOQChildItem
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSelectItems = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridBOQItems = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchItem = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQItems)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSelectItems,
            this.btnCancel});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(10, 10);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.gridBOQItems);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtSearchItem);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(656, 358);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // btnSelectItems
            // 
            this.btnSelectItems.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnSelectItems.Text = "Pick Items";
            this.btnSelectItems.UniqueName = "EDB876FBD0254451D79EC334E3DED776";
            this.btnSelectItems.Click += new System.EventHandler(this.btnSelectItems_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "CCA8DD47B7B7420B69ACEBC46870F185";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gridBOQItems
            // 
            this.gridBOQItems.AllowUserToAddRows = false;
            this.gridBOQItems.AllowUserToDeleteRows = false;
            this.gridBOQItems.AllowUserToOrderColumns = true;
            this.gridBOQItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBOQItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridBOQItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBOQItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridBOQItems.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridBOQItems.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.gridBOQItems.Location = new System.Drawing.Point(0, 20);
            this.gridBOQItems.MultiSelect = false;
            this.gridBOQItems.Name = "gridBOQItems";
            this.gridBOQItems.RowHeadersVisible = false;
            this.gridBOQItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBOQItems.Size = new System.Drawing.Size(654, 304);
            this.gridBOQItems.TabIndex = 16;
            this.gridBOQItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBOQItems_CellClick);
            this.gridBOQItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridBOQItems_DataBindingComplete);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchItem.Location = new System.Drawing.Point(0, 0);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(654, 20);
            this.txtSearchItem.TabIndex = 0;
            this.txtSearchItem.TextChanged += new System.EventHandler(this.txtSearchItem_TextChanged);
            // 
            // frmAddBOQChildItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 378);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddBOQChildItem";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Select Items from BOQ(DESIGN)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAddBOQChildItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSelectItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchItem;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridBOQItems;
    }
}