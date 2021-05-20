namespace appExcelERP.Controls.InventoryItemControls
{
    partial class controlAssemblyComposition
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
            this.headerGroupParent = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddRemoveItems = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnSaveAssembly = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridParentItems = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchParentItems = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParent.Panel)).BeginInit();
            this.headerGroupParent.Panel.SuspendLayout();
            this.headerGroupParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParentItems)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupParent
            // 
            this.headerGroupParent.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddRemoveItems,
            this.btnSaveAssembly});
            this.headerGroupParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupParent.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupParent.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupParent.Location = new System.Drawing.Point(0, 0);
            this.headerGroupParent.Name = "headerGroupParent";
            // 
            // headerGroupParent.Panel
            // 
            this.headerGroupParent.Panel.Controls.Add(this.gridParentItems);
            this.headerGroupParent.Panel.Controls.Add(this.txtSearchParentItems);
            this.headerGroupParent.Size = new System.Drawing.Size(736, 481);
            this.headerGroupParent.TabIndex = 0;
            this.headerGroupParent.ValuesPrimary.Heading = "Assembly Child Items";
            this.headerGroupParent.ValuesPrimary.Image = null;
            // 
            // btnAddRemoveItems
            // 
            this.btnAddRemoveItems.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddRemoveItems.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnAddRemoveItems.Text = "&Add/Remove Items";
            this.btnAddRemoveItems.UniqueName = "0A46B30586024B9D51AF1ADB4B236C67";
            this.btnAddRemoveItems.Click += new System.EventHandler(this.btnAddRemoveItems_Click);
            // 
            // btnSaveAssembly
            // 
            this.btnSaveAssembly.Image = global::appExcelERP.Properties.Resources.SaveAll_16x;
            this.btnSaveAssembly.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorStack;
            this.btnSaveAssembly.Text = "&Save Assembly Items";
            this.btnSaveAssembly.UniqueName = "E0A96E335A0341AA598BE3DFC1C0575C";
            this.btnSaveAssembly.Click += new System.EventHandler(this.btnSaveAssembly_Click);
            // 
            // gridParentItems
            // 
            this.gridParentItems.AllowUserToAddRows = false;
            this.gridParentItems.AllowUserToDeleteRows = false;
            this.gridParentItems.AllowUserToOrderColumns = true;
            this.gridParentItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridParentItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridParentItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridParentItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridParentItems.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridParentItems.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellSheet;
            this.gridParentItems.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridParentItems.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridParentItems.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridParentItems.Location = new System.Drawing.Point(0, 26);
            this.gridParentItems.Name = "gridParentItems";
            this.gridParentItems.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridParentItems.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridParentItems.Size = new System.Drawing.Size(734, 402);
            this.gridParentItems.TabIndex = 9;
            // 
            // txtSearchParentItems
            // 
            this.txtSearchParentItems.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny2});
            this.txtSearchParentItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchParentItems.Location = new System.Drawing.Point(0, 0);
            this.txtSearchParentItems.Name = "txtSearchParentItems";
            this.txtSearchParentItems.Size = new System.Drawing.Size(734, 26);
            this.txtSearchParentItems.TabIndex = 8;
            this.txtSearchParentItems.TextChanged += new System.EventHandler(this.txtSearchParentItems_TextChanged);
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.Text = "&Search";
            this.buttonSpecAny2.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // controlAssemblyComposition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupParent);
            this.Name = "controlAssemblyComposition";
            this.Size = new System.Drawing.Size(736, 481);
            this.Load += new System.EventHandler(this.controlAssemblyComposition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParent.Panel)).EndInit();
            this.headerGroupParent.Panel.ResumeLayout(false);
            this.headerGroupParent.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupParent)).EndInit();
            this.headerGroupParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridParentItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupParent;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridParentItems;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchParentItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddRemoveItems;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSaveAssembly;
    }
}
