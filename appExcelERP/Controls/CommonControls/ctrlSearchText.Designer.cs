namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlSearchText
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
            this.TextSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.gridData = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // TextSearch
            // 
            this.TextSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextSearch.Location = new System.Drawing.Point(0, 0);
            this.TextSearch.Margin = new System.Windows.Forms.Padding(4);
            this.TextSearch.Name = "TextSearch";
            this.TextSearch.Size = new System.Drawing.Size(250, 20);
            this.TextSearch.TabIndex = 0;
            this.TextSearch.TextChanged += new System.EventHandler(this.Search_TextChanged);
            this.TextSearch.Enter += new System.EventHandler(this.TextSearch_Enter);
            this.TextSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextSearch_KeyUp);
            this.TextSearch.Leave += new System.EventHandler(this.TextSearch_Leave);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.ColumnHeadersVisible = false;
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridData.HideOuterBorders = true;
            this.gridData.Location = new System.Drawing.Point(0, 20);
            this.gridData.MultiSelect = false;
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.Size = new System.Drawing.Size(250, 123);
            this.gridData.TabIndex = 14;
            this.gridData.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_RowEnter);
            // 
            // ctrlSearchText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.TextSearch);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlSearchText";
            this.Size = new System.Drawing.Size(250, 143);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ComponentFactory.Krypton.Toolkit.KryptonTextBox TextSearch;
        public ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridData;
    }
}
