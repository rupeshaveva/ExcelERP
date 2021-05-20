namespace appExcelERP.Controls.MASTERS
{
    partial class PageTermsAndConditions
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
            ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewTnC;
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupTnCCategory = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddCategory = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditCategory = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteCategory = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridCategories = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchCategory = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.headerGroupTnCList = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnEditTnC = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteTnC = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridTermsList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchTerms = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            btnAddNewTnC = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCCategory.Panel)).BeginInit();
            this.headerGroupTnCCategory.Panel.SuspendLayout();
            this.headerGroupTnCCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCList.Panel)).BeginInit();
            this.headerGroupTnCList.Panel.SuspendLayout();
            this.headerGroupTnCList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTermsList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewTnC
            // 
            btnAddNewTnC.Image = global::appExcelERP.Properties.Resources.Add_16x;
            btnAddNewTnC.Text = "&Add New";
            btnAddNewTnC.UniqueName = "37F2E55CA57142991F9D6F31C0A7E4F1";
            btnAddNewTnC.Click += new System.EventHandler(this.btnAddNewTnC_Click);
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRefresh});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.kryptonHeaderGroup1.Panel.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(902, 478);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "7C10C07898434CDBD4A3C32B9676DE19";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(5, 5);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.headerGroupTnCCategory);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.headerGroupTnCList);
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(890, 439);
            this.kryptonSplitContainer1.SplitterDistance = 314;
            this.kryptonSplitContainer1.TabIndex = 0;
            // 
            // headerGroupTnCCategory
            // 
            this.headerGroupTnCCategory.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddCategory,
            this.btnEditCategory,
            this.btnDeleteCategory});
            this.headerGroupTnCCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupTnCCategory.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupTnCCategory.Location = new System.Drawing.Point(0, 0);
            this.headerGroupTnCCategory.Name = "headerGroupTnCCategory";
            // 
            // headerGroupTnCCategory.Panel
            // 
            this.headerGroupTnCCategory.Panel.Controls.Add(this.gridCategories);
            this.headerGroupTnCCategory.Panel.Controls.Add(this.txtSearchCategory);
            this.headerGroupTnCCategory.Size = new System.Drawing.Size(314, 439);
            this.headerGroupTnCCategory.TabIndex = 0;
            this.headerGroupTnCCategory.ValuesPrimary.Heading = "T&C - CATEGORIES";
            this.headerGroupTnCCategory.ValuesPrimary.Image = null;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddCategory.Text = "&Add New";
            this.btnAddCategory.UniqueName = "6D9AB3C2D26B4475D4921CE91B6A3E70";
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnEditCategory
            // 
            this.btnEditCategory.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x;
            this.btnEditCategory.Text = "&Edit";
            this.btnEditCategory.UniqueName = "14ADCE04488641D9549A888F3078020B";
            this.btnEditCategory.Click += new System.EventHandler(this.btnEditCategory_Click);
            // 
            // btnDeleteCategory
            // 
            this.btnDeleteCategory.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteCategory.Text = "&Delete";
            this.btnDeleteCategory.UniqueName = "78D3D937C3794635C98D5CC8C4FC338C";
            this.btnDeleteCategory.Click += new System.EventHandler(this.btnDeleteCategory_Click);
            // 
            // gridCategories
            // 
            this.gridCategories.AllowUserToAddRows = false;
            this.gridCategories.AllowUserToDeleteRows = false;
            this.gridCategories.AllowUserToOrderColumns = true;
            this.gridCategories.AllowUserToResizeColumns = false;
            this.gridCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCategories.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCategories.ColumnHeadersVisible = false;
            this.gridCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCategories.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCategories.Location = new System.Drawing.Point(0, 20);
            this.gridCategories.MultiSelect = false;
            this.gridCategories.Name = "gridCategories";
            this.gridCategories.ReadOnly = true;
            this.gridCategories.RowHeadersVisible = false;
            this.gridCategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCategories.Size = new System.Drawing.Size(312, 369);
            this.gridCategories.TabIndex = 8;
            this.gridCategories.VirtualMode = true;
            this.gridCategories.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCategories_RowEnter);
            // 
            // txtSearchCategory
            // 
            this.txtSearchCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchCategory.Location = new System.Drawing.Point(0, 0);
            this.txtSearchCategory.Name = "txtSearchCategory";
            this.txtSearchCategory.Size = new System.Drawing.Size(312, 20);
            this.txtSearchCategory.TabIndex = 7;
            this.txtSearchCategory.TextChanged += new System.EventHandler(this.txtSearchCategory_TextChanged);
            // 
            // headerGroupTnCList
            // 
            this.headerGroupTnCList.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            btnAddNewTnC,
            this.btnEditTnC,
            this.btnDeleteTnC});
            this.headerGroupTnCList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupTnCList.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupTnCList.Location = new System.Drawing.Point(0, 0);
            this.headerGroupTnCList.Name = "headerGroupTnCList";
            // 
            // headerGroupTnCList.Panel
            // 
            this.headerGroupTnCList.Panel.Controls.Add(this.gridTermsList);
            this.headerGroupTnCList.Panel.Controls.Add(this.txtSearchTerms);
            this.headerGroupTnCList.Size = new System.Drawing.Size(571, 439);
            this.headerGroupTnCList.TabIndex = 1;
            this.headerGroupTnCList.ValuesPrimary.Heading = "LIST - TERMS & CONDITIONS";
            this.headerGroupTnCList.ValuesPrimary.Image = null;
            // 
            // btnEditTnC
            // 
            this.btnEditTnC.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x;
            this.btnEditTnC.Text = "&Edit";
            this.btnEditTnC.UniqueName = "93C53045E4F3462A58AE5CB88F9A0046";
            this.btnEditTnC.Click += new System.EventHandler(this.btnEditTnC_Click);
            // 
            // btnDeleteTnC
            // 
            this.btnDeleteTnC.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteTnC.Text = "&Delete";
            this.btnDeleteTnC.UniqueName = "E62AD1BD21694E9F8D90A1688DCCC5A5";
            this.btnDeleteTnC.Click += new System.EventHandler(this.btnDeleteTnC_Click);
            // 
            // gridTermsList
            // 
            this.gridTermsList.AllowUserToAddRows = false;
            this.gridTermsList.AllowUserToDeleteRows = false;
            this.gridTermsList.AllowUserToOrderColumns = true;
            this.gridTermsList.AllowUserToResizeColumns = false;
            this.gridTermsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTermsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridTermsList.ColumnHeadersVisible = false;
            this.gridTermsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTermsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridTermsList.Location = new System.Drawing.Point(0, 20);
            this.gridTermsList.MultiSelect = false;
            this.gridTermsList.Name = "gridTermsList";
            this.gridTermsList.ReadOnly = true;
            this.gridTermsList.RowHeadersVisible = false;
            this.gridTermsList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridTermsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTermsList.Size = new System.Drawing.Size(569, 369);
            this.gridTermsList.TabIndex = 8;
            this.gridTermsList.VirtualMode = true;
            this.gridTermsList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridTermsList_DataBindingComplete);
            this.gridTermsList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermsList_RowEnter);
            // 
            // txtSearchTerms
            // 
            this.txtSearchTerms.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchTerms.Location = new System.Drawing.Point(0, 0);
            this.txtSearchTerms.Name = "txtSearchTerms";
            this.txtSearchTerms.Size = new System.Drawing.Size(569, 20);
            this.txtSearchTerms.TabIndex = 7;
            this.txtSearchTerms.TextChanged += new System.EventHandler(this.txtSearchTerms_TextChanged);
            // 
            // PageTermsAndConditions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "PageTermsAndConditions";
            this.Size = new System.Drawing.Size(902, 478);
            this.Load += new System.EventHandler(this.PageTermsAndConditions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCCategory.Panel)).EndInit();
            this.headerGroupTnCCategory.Panel.ResumeLayout(false);
            this.headerGroupTnCCategory.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCCategory)).EndInit();
            this.headerGroupTnCCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCList.Panel)).EndInit();
            this.headerGroupTnCList.Panel.ResumeLayout(false);
            this.headerGroupTnCList.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTnCList)).EndInit();
            this.headerGroupTnCList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTermsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupTnCCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupTnCList;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddCategory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditCategory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteCategory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditTnC;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteTnC;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCategories;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchCategory;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridTermsList;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchTerms;
    }
}
