namespace appExcelERP.Forms
{
    partial class frmGridMultiSelect
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerGroupSelection = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSaveSelection = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancelSelection = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridData = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelection.Panel)).BeginInit();
            this.headerGroupSelection.Panel.SuspendLayout();
            this.headerGroupSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupSelection
            // 
            this.headerGroupSelection.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSaveSelection,
            this.btnCancelSelection});
            this.headerGroupSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupSelection.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupSelection.Location = new System.Drawing.Point(13, 12);
            this.headerGroupSelection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerGroupSelection.Name = "headerGroupSelection";
            // 
            // headerGroupSelection.Panel
            // 
            this.headerGroupSelection.Panel.Controls.Add(this.gridData);
            this.headerGroupSelection.Panel.Controls.Add(this.txtSearch);
            this.headerGroupSelection.Size = new System.Drawing.Size(865, 515);
            this.headerGroupSelection.TabIndex = 0;
            this.headerGroupSelection.ValuesPrimary.Heading = "";
            this.headerGroupSelection.ValuesPrimary.Image = null;
            this.headerGroupSelection.ValuesSecondary.Heading = "";
            // 
            // btnSaveSelection
            // 
            this.btnSaveSelection.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSaveSelection.Text = "&Save Selection(s)";
            this.btnSaveSelection.UniqueName = "9B7702144A8B4A02C7A28FF5268E0058";
            this.btnSaveSelection.Click += new System.EventHandler(this.btnSaveSelection_Click);
            // 
            // btnCancelSelection
            // 
            this.btnCancelSelection.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancelSelection.Text = "&Cancel Selection";
            this.btnCancelSelection.UniqueName = "A0CE8FE2AC0740998BB5273A7432320D";
            this.btnCancelSelection.Click += new System.EventHandler(this.btnCancelSelection_Click);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.ColumnHeadersVisible = false;
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridData.Location = new System.Drawing.Point(0, 27);
            this.gridData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridData.MultiSelect = false;
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.Size = new System.Drawing.Size(863, 451);
            this.gridData.TabIndex = 16;
            this.gridData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellClick);
            this.gridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(863, 27);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmGridMultiSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 539);
            this.Controls.Add(this.headerGroupSelection);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGridMultiSelect";
            this.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Multiple Items from Grid";
            this.Load += new System.EventHandler(this.frmGridMultiSelect_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmGridMultiSelect_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelection.Panel)).EndInit();
            this.headerGroupSelection.Panel.ResumeLayout(false);
            this.headerGroupSelection.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSelection)).EndInit();
            this.headerGroupSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSelection;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSaveSelection;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancelSelection;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridData;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearch;
    }
}