namespace appExcelERP.Controls.PMC
{
    partial class ControlProjectCloserChecklist
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
            this.btnUpdateCheckList = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridProjectCheckList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectCheckList)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateCheckList});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.gridProjectCheckList);
            this.headerGroupMain.Panel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.headerGroupMain.Size = new System.Drawing.Size(658, 383);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Project Closer CheckList";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnUpdateCheckList
            // 
            this.btnUpdateCheckList.Text = "&Update Project Closer CheckList";
            this.btnUpdateCheckList.UniqueName = "57115C2DED234C3901B7598C5E5851A3";
            this.btnUpdateCheckList.Click += new System.EventHandler(this.btnUpdateCheckList_Click);
            // 
            // gridProjectCheckList
            // 
            this.gridProjectCheckList.AllowUserToAddRows = false;
            this.gridProjectCheckList.AllowUserToDeleteRows = false;
            this.gridProjectCheckList.AllowUserToOrderColumns = true;
            this.gridProjectCheckList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProjectCheckList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridProjectCheckList.ColumnHeadersHeight = 28;
            this.gridProjectCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProjectCheckList.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Sheet;
            this.gridProjectCheckList.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridBackgroundSheet;
            this.gridProjectCheckList.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridProjectCheckList.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridProjectCheckList.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridProjectCheckList.Location = new System.Drawing.Point(5, 5);
            this.gridProjectCheckList.MultiSelect = false;
            this.gridProjectCheckList.Name = "gridProjectCheckList";
            this.gridProjectCheckList.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProjectCheckList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProjectCheckList.Size = new System.Drawing.Size(646, 344);
            this.gridProjectCheckList.TabIndex = 0;
            this.gridProjectCheckList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProjectCheckList_CellEndEdit);
            this.gridProjectCheckList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.gridProjectCheckList_CellPainting);
            this.gridProjectCheckList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridProjectCheckList_DataBindingComplete);
            // 
            // ControlProjectCloserChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "ControlProjectCloserChecklist";
            this.Size = new System.Drawing.Size(658, 383);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProjectCheckList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateCheckList;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridProjectCheckList;
    }
}
