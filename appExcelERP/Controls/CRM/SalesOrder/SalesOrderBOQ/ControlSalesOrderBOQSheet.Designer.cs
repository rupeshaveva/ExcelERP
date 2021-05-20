namespace appExcelERP.Controls.CRM.SalesOrder.SalesOrderBOQ
{
    partial class ControlSalesOrderBOQSheet
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
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.splitContainerLeft = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.gridBOQItems = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchBOQItemsGrid = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gridItemSummary = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddParentItem = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditItem = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveItem = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAddNewChildItem = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnClearAllBoqItems = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnShowHideChildItems = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnShowHideCharges = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnShowHideChildren = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft.Panel1)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft.Panel2)).BeginInit();
            this.splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerLeft);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(566, 265);
            this.splitContainerMain.SplitterDistance = 401;
            this.splitContainerMain.SplitterWidth = 3;
            this.splitContainerMain.TabIndex = 1;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeft.Name = "splitContainerLeft";
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.gridBOQItems);
            this.splitContainerLeft.Panel1.Controls.Add(this.txtSearchBOQItemsGrid);
            this.splitContainerLeft.Panel1.Controls.Add(this.gridItemSummary);
            this.splitContainerLeft.Size = new System.Drawing.Size(401, 265);
            this.splitContainerLeft.SplitterDistance = 257;
            this.splitContainerLeft.TabIndex = 22;
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
            this.gridBOQItems.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderRowList;
            this.gridBOQItems.Location = new System.Drawing.Point(0, 20);
            this.gridBOQItems.MultiSelect = false;
            this.gridBOQItems.Name = "gridBOQItems";
            this.gridBOQItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridBOQItems.Size = new System.Drawing.Size(257, 208);
            this.gridBOQItems.TabIndex = 19;
            // 
            // txtSearchBOQItemsGrid
            // 
            this.txtSearchBOQItemsGrid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtSearchBOQItemsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchBOQItemsGrid.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBOQItemsGrid.MaxLength = 50;
            this.txtSearchBOQItemsGrid.Name = "txtSearchBOQItemsGrid";
            this.txtSearchBOQItemsGrid.Size = new System.Drawing.Size(257, 20);
            this.txtSearchBOQItemsGrid.TabIndex = 16;
            // 
            // gridItemSummary
            // 
            this.gridItemSummary.AllowUserToAddRows = false;
            this.gridItemSummary.AllowUserToDeleteRows = false;
            this.gridItemSummary.AllowUserToOrderColumns = true;
            this.gridItemSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridItemSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridItemSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridItemSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridItemSummary.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.gridItemSummary.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.gridItemSummary.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridItemSummary.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridItemSummary.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridItemSummary.Location = new System.Drawing.Point(0, 228);
            this.gridItemSummary.MultiSelect = false;
            this.gridItemSummary.Name = "gridItemSummary";
            this.gridItemSummary.ReadOnly = true;
            this.gridItemSummary.RowHeadersVisible = false;
            this.gridItemSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItemSummary.ShowEditingIcon = false;
            this.gridItemSummary.ShowRowErrors = false;
            this.gridItemSummary.Size = new System.Drawing.Size(257, 37);
            this.gridItemSummary.TabIndex = 20;
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddParentItem,
            this.btnEditItem,
            this.btnRemoveItem,
            this.btnAddNewChildItem,
            this.btnClearAllBoqItems,
            this.btnShowHideChildItems,
            this.btnShowHideCharges,
            this.btnShowHideChildren});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.splitContainerMain);
            this.headerGroupMain.Size = new System.Drawing.Size(568, 296);
            this.headerGroupMain.TabIndex = 22;
            this.headerGroupMain.ValuesPrimary.Heading = "";
            this.headerGroupMain.ValuesPrimary.Image = null;
            this.headerGroupMain.ValuesSecondary.Description = ".";
            this.headerGroupMain.ValuesSecondary.Heading = "";
            // 
            // btnAddParentItem
            // 
            this.btnAddParentItem.Image = global::appExcelERP.Properties.Resources.FieldAdded_16x;
            this.btnAddParentItem.Text = "&New Item";
            this.btnAddParentItem.UniqueName = "A9D7480B5A69448F61B04F4F34829685";
            // 
            // btnEditItem
            // 
            this.btnEditItem.Image = global::appExcelERP.Properties.Resources.FieldModify_16x;
            this.btnEditItem.Text = "&Edit Item";
            this.btnEditItem.UniqueName = "6BEA493EB95645ED13BA444D480EAA6C";
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Far;
            this.btnRemoveItem.Image = global::appExcelERP.Properties.Resources.FieldDeleted_16x;
            this.btnRemoveItem.Text = "&Remove Item";
            this.btnRemoveItem.UniqueName = "7CD5EA63FA7D49FF0C8DCED05BCF78B6";
            // 
            // btnAddNewChildItem
            // 
            this.btnAddNewChildItem.Image = global::appExcelERP.Properties.Resources.AddRow_16x;
            this.btnAddNewChildItem.Text = "New Child Item";
            this.btnAddNewChildItem.UniqueName = "A9FCD672D1C24845B4A591268AD40F7B";
            // 
            // btnClearAllBoqItems
            // 
            this.btnClearAllBoqItems.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnClearAllBoqItems.Text = "&Clear All Items";
            this.btnClearAllBoqItems.UniqueName = "66C20682EA49428891922B4ED59260AB";
            // 
            // btnShowHideChildItems
            // 
            this.btnShowHideChildItems.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnShowHideChildItems.Image = global::appExcelERP.Properties.Resources.DocumentOutline_16x;
            this.btnShowHideChildItems.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnShowHideChildItems.Text = "Hide Child Items";
            this.btnShowHideChildItems.UniqueName = "8A6D68AE037A4E61BFA9382EF79B6DF4";
            // 
            // btnShowHideCharges
            // 
            this.btnShowHideCharges.Image = global::appExcelERP.Properties.Resources.ScalarFunction_16x;
            this.btnShowHideCharges.Text = "Charges on Item";
            this.btnShowHideCharges.UniqueName = "F56B67ECA1A040FC31922B7EED2F0D47";
            // 
            // btnShowHideChildren
            // 
            this.btnShowHideChildren.Image = global::appExcelERP.Properties.Resources.CaseLookupColumn_16x;
            this.btnShowHideChildren.Text = "Charges on Sheet";
            this.btnShowHideChildren.ToolTipBody = "Item Charges Info. ";
            this.btnShowHideChildren.ToolTipTitle = "Show/Hide  Material Suppl;y & Installation Charges";
            this.btnShowHideChildren.UniqueName = "F414072C1E7544C012A14C20D1202B2C";
            // 
            // ControlSalesOrderBOQSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "ControlSalesOrderBOQSheet";
            this.Size = new System.Drawing.Size(568, 296);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft.Panel1)).EndInit();
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerLeft;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridBOQItems;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchBOQItemsGrid;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridItemSummary;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddParentItem;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditItem;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveItem;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewChildItem;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnClearAllBoqItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnShowHideChildItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnShowHideCharges;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnShowHideChildren;
    }
}
