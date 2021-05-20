namespace appExcelERP.Forms.InventoryItems
{
    partial class frmAddAssemblyChildItems
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupChooseItems = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddAssemblyChildItem = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridItems = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchItem = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.cboItemCategory = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.headerGroupSelectedItems = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRemoveChildItemsFromAssembly = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridChildItems = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChooseItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChooseItems.Panel)).BeginInit();
            this.headerGroupChooseItems.Panel.SuspendLayout();
            this.headerGroupChooseItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelectedItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelectedItems.Panel)).BeginInit();
            this.headerGroupSelectedItems.Panel.SuspendLayout();
            this.headerGroupSelectedItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChildItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupChooseItems);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupSelectedItems);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(771, 512);
            this.splitContainerMain.SplitterDistance = 277;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupChooseItems
            // 
            this.headerGroupChooseItems.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddAssemblyChildItem});
            this.headerGroupChooseItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupChooseItems.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupChooseItems.Location = new System.Drawing.Point(0, 0);
            this.headerGroupChooseItems.Name = "headerGroupChooseItems";
            // 
            // headerGroupChooseItems.Panel
            // 
            this.headerGroupChooseItems.Panel.Controls.Add(this.gridItems);
            this.headerGroupChooseItems.Panel.Controls.Add(this.txtSearchItem);
            this.headerGroupChooseItems.Panel.Controls.Add(this.cboItemCategory);
            this.headerGroupChooseItems.Size = new System.Drawing.Size(771, 277);
            this.headerGroupChooseItems.TabIndex = 0;
            this.headerGroupChooseItems.ValuesPrimary.Heading = "List of Non-Assembly Items to choose";
            this.headerGroupChooseItems.ValuesPrimary.Image = null;
            // 
            // btnAddAssemblyChildItem
            // 
            this.btnAddAssemblyChildItem.Text = "&Add to Selected Items List";
            this.btnAddAssemblyChildItem.UniqueName = "0CC3B57F21044DA23D9189055ED3C308";
            this.btnAddAssemblyChildItem.Click += new System.EventHandler(this.btnAddAssemblyChildItem_Click);
            // 
            // gridItems
            // 
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.AllowUserToOrderColumns = true;
            this.gridItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridItems.ColumnHeadersHeight = 28;
            this.gridItems.ColumnHeadersVisible = false;
            this.gridItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridItems.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridItems.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellSheet;
            this.gridItems.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridItems.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridItems.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridItems.Location = new System.Drawing.Point(0, 47);
            this.gridItems.Name = "gridItems";
            this.gridItems.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridItems.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridItems.Size = new System.Drawing.Size(769, 180);
            this.gridItems.TabIndex = 56;
            this.gridItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItems_CellClick);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1});
            this.txtSearchItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchItem.Location = new System.Drawing.Point(0, 21);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(769, 26);
            this.txtSearchItem.TabIndex = 55;
            this.txtSearchItem.TextChanged += new System.EventHandler(this.txtSearchItem_TextChanged);
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.Text = "&Search";
            this.buttonSpecAny1.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // cboItemCategory
            // 
            this.cboItemCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboItemCategory.DropDownWidth = 297;
            this.cboItemCategory.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemCategory.FormattingEnabled = true;
            this.cboItemCategory.Location = new System.Drawing.Point(0, 0);
            this.cboItemCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboItemCategory.Name = "cboItemCategory";
            this.cboItemCategory.Size = new System.Drawing.Size(769, 21);
            this.cboItemCategory.TabIndex = 54;
            this.cboItemCategory.SelectionChangeCommitted += new System.EventHandler(this.cboItemCategory_SelectionChangeCommitted);
            // 
            // headerGroupSelectedItems
            // 
            this.headerGroupSelectedItems.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRemoveChildItemsFromAssembly});
            this.headerGroupSelectedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupSelectedItems.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupSelectedItems.Location = new System.Drawing.Point(0, 0);
            this.headerGroupSelectedItems.Name = "headerGroupSelectedItems";
            // 
            // headerGroupSelectedItems.Panel
            // 
            this.headerGroupSelectedItems.Panel.Controls.Add(this.gridChildItems);
            this.headerGroupSelectedItems.Size = new System.Drawing.Size(771, 230);
            this.headerGroupSelectedItems.TabIndex = 0;
            this.headerGroupSelectedItems.ValuesPrimary.Heading = "Selected Items";
            this.headerGroupSelectedItems.ValuesPrimary.Image = null;
            // 
            // btnRemoveChildItemsFromAssembly
            // 
            this.btnRemoveChildItemsFromAssembly.Text = "&Remove from Selected Items List";
            this.btnRemoveChildItemsFromAssembly.UniqueName = "8246950A711149F867AB35876BB07641";
            this.btnRemoveChildItemsFromAssembly.Click += new System.EventHandler(this.btnRemoveChildItemsFromAssembly_Click);
            // 
            // gridChildItems
            // 
            this.gridChildItems.AllowUserToAddRows = false;
            this.gridChildItems.AllowUserToDeleteRows = false;
            this.gridChildItems.AllowUserToOrderColumns = true;
            this.gridChildItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridChildItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridChildItems.ColumnHeadersHeight = 28;
            this.gridChildItems.ColumnHeadersVisible = false;
            this.gridChildItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChildItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridChildItems.Location = new System.Drawing.Point(0, 0);
            this.gridChildItems.Name = "gridChildItems";
            this.gridChildItems.ReadOnly = true;
            this.gridChildItems.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChildItems.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridChildItems.RowTemplate.ReadOnly = true;
            this.gridChildItems.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridChildItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridChildItems.Size = new System.Drawing.Size(769, 180);
            this.gridChildItems.TabIndex = 0;
            this.gridChildItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridChildItems_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddAssemblyChildItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 512);
            this.Controls.Add(this.splitContainerMain);
            this.Name = "frmAddAssemblyChildItems";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddAssemblyChildItems";
            this.Load += new System.EventHandler(this.frmAddAssemblyChildItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChooseItems.Panel)).EndInit();
            this.headerGroupChooseItems.Panel.ResumeLayout(false);
            this.headerGroupChooseItems.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChooseItems)).EndInit();
            this.headerGroupChooseItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelectedItems.Panel)).EndInit();
            this.headerGroupSelectedItems.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelectedItems)).EndInit();
            this.headerGroupSelectedItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridChildItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupChooseItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddAssemblyChildItem;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSelectedItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveChildItemsFromAssembly;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboItemCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridItems;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchItem;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridChildItems;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}