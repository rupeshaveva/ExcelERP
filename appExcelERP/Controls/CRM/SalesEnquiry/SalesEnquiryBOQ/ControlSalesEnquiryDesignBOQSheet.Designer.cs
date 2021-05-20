namespace appExcelERP.Controls.CRM
{
    partial class ControlSalesEnquiryDesignBOQSheet
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
            this.gridBOQSummary = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupDescription = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnViewItemInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnShowHideChildItems = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAddChildItems = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveSelectedItem = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnUpdateSheet = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridBOQItems = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchBOQItemsGrid = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDescription.Panel)).BeginInit();
            this.headerGroupDescription.Panel.SuspendLayout();
            this.headerGroupDescription.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBOQSummary
            // 
            this.gridBOQSummary.AllowUserToAddRows = false;
            this.gridBOQSummary.AllowUserToDeleteRows = false;
            this.gridBOQSummary.AllowUserToOrderColumns = true;
            this.gridBOQSummary.AllowUserToResizeColumns = false;
            this.gridBOQSummary.AllowUserToResizeRows = false;
            this.gridBOQSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBOQSummary.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridBOQSummary.ColumnHeadersVisible = false;
            this.gridBOQSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridBOQSummary.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridBOQSummary.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.gridBOQSummary.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.gridBOQSummary.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridBOQSummary.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridBOQSummary.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridBOQSummary.HideOuterBorders = true;
            this.gridBOQSummary.Location = new System.Drawing.Point(0, 412);
            this.gridBOQSummary.Name = "gridBOQSummary";
            this.gridBOQSummary.RowHeadersVisible = false;
            this.gridBOQSummary.Size = new System.Drawing.Size(759, 27);
            this.gridBOQSummary.TabIndex = 8;
            this.gridBOQSummary.Visible = false;
            // 
            // headerGroupDescription
            // 
            this.headerGroupDescription.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnViewItemInfo,
            this.btnShowHideChildItems,
            this.btnAddChildItems,
            this.btnRemoveSelectedItem,
            this.btnUpdateSheet});
            this.headerGroupDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupDescription.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDescription.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDescription.HeaderVisibleSecondary = false;
            this.headerGroupDescription.Location = new System.Drawing.Point(0, 0);
            this.headerGroupDescription.Margin = new System.Windows.Forms.Padding(0);
            this.headerGroupDescription.Name = "headerGroupDescription";
            // 
            // headerGroupDescription.Panel
            // 
            this.headerGroupDescription.Panel.Controls.Add(this.gridBOQItems);
            this.headerGroupDescription.Panel.Controls.Add(this.txtSearchBOQItemsGrid);
            this.headerGroupDescription.Panel.Padding = new System.Windows.Forms.Padding(3);
            this.headerGroupDescription.Size = new System.Drawing.Size(759, 412);
            this.headerGroupDescription.TabIndex = 12;
            this.headerGroupDescription.ValuesPrimary.Heading = "BOQ Items";
            this.headerGroupDescription.ValuesPrimary.Image = null;
            this.headerGroupDescription.ValuesSecondary.Heading = "Particulars of Sheet Item(s)";
            // 
            // btnViewItemInfo
            // 
            this.btnViewItemInfo.Image = global::appExcelERP.Properties.Resources.CSLightSwitch_16x;
            this.btnViewItemInfo.Text = "&Item Info.";
            this.btnViewItemInfo.UniqueName = "9DBAACC947DB40E2B7BD37E3533A1684";
            this.btnViewItemInfo.Click += new System.EventHandler(this.btnViewItemInfo_Click);
            // 
            // btnShowHideChildItems
            // 
            this.btnShowHideChildItems.Image = global::appExcelERP.Properties.Resources.DocumentOutline_16x;
            this.btnShowHideChildItems.Text = "Hide Child Items";
            this.btnShowHideChildItems.UniqueName = "FDBA3B603E3D4FBE8D9D0C87F706BC73";
            this.btnShowHideChildItems.Click += new System.EventHandler(this.btnShowHideChildItems_Click);
            // 
            // btnAddChildItems
            // 
            this.btnAddChildItems.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddChildItems.Text = "&Add Child Items";
            this.btnAddChildItems.UniqueName = "B59856C66D7C4AF67E81464AFDDEA05F";
            this.btnAddChildItems.Click += new System.EventHandler(this.btnAddChildItems_Click);
            // 
            // btnRemoveSelectedItem
            // 
            this.btnRemoveSelectedItem.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnRemoveSelectedItem.Text = "&Remove Selected Item";
            this.btnRemoveSelectedItem.UniqueName = "C801AEE9BEA94692789DE93CC425A435";
            this.btnRemoveSelectedItem.Click += new System.EventHandler(this.btnRemoveSelectedItem_Click);
            // 
            // btnUpdateSheet
            // 
            this.btnUpdateSheet.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x;
            this.btnUpdateSheet.Text = "&Modify Sheet";
            this.btnUpdateSheet.UniqueName = "7577C026225D4C41F38417C29F13AEB9";
            this.btnUpdateSheet.Click += new System.EventHandler(this.btnUpdateSheet_Click);
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
            this.gridBOQItems.Location = new System.Drawing.Point(3, 26);
            this.gridBOQItems.MultiSelect = false;
            this.gridBOQItems.Name = "gridBOQItems";
            this.gridBOQItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridBOQItems.Size = new System.Drawing.Size(751, 354);
            this.gridBOQItems.TabIndex = 15;
            this.gridBOQItems.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBOQItems_CellEndEdit);
            this.gridBOQItems.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBOQItems_CellLeave);
            this.gridBOQItems.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridBOQItems_DataBindingComplete);
            this.gridBOQItems.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBOQItems_RowEnter);
            this.gridBOQItems.Resize += new System.EventHandler(this.gridBOQItems_Resize);
            // 
            // txtSearchBOQItemsGrid
            // 
            this.txtSearchBOQItemsGrid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtSearchBOQItemsGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchBOQItemsGrid.Location = new System.Drawing.Point(3, 3);
            this.txtSearchBOQItemsGrid.MaxLength = 50;
            this.txtSearchBOQItemsGrid.Name = "txtSearchBOQItemsGrid";
            this.txtSearchBOQItemsGrid.Size = new System.Drawing.Size(751, 23);
            this.txtSearchBOQItemsGrid.TabIndex = 13;
            this.txtSearchBOQItemsGrid.TextChanged += new System.EventHandler(this.txtSearchBOQItemsGrid_TextChanged);
            // 
            // ControlSalesEnquiryDesignBOQSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.headerGroupDescription);
            this.Controls.Add(this.gridBOQSummary);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ControlSalesEnquiryDesignBOQSheet";
            this.Size = new System.Drawing.Size(759, 439);
            this.Load += new System.EventHandler(this.ControlSalesEnquiryDesignBOQSheet_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlSalesEnquiryDesignBOQSheet_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDescription.Panel)).EndInit();
            this.headerGroupDescription.Panel.ResumeLayout(false);
            this.headerGroupDescription.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDescription)).EndInit();
            this.headerGroupDescription.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBOQItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridBOQSummary;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDescription;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateSheet;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridBOQItems;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchBOQItemsGrid;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddChildItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveSelectedItem;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnShowHideChildItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnViewItemInfo;
    }
}
