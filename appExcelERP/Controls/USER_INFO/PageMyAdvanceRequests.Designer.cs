namespace appExcelERP.Controls.USER_INFO
{
    partial class PageMyAdvanceRequests
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
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewAdvanceRequest = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditAdvanceRequest = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteAdvanceRequests = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAdvanceRequests = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtAdvanceSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchMyAdvance = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdvanceRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewAdvanceRequest,
            this.btnEditAdvanceRequest,
            this.btnDeleteAdvanceRequests});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.gridAdvanceRequests);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtAdvanceSearch);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(634, 446);
            this.kryptonHeaderGroup1.TabIndex = 2;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "My Advance Request(s)";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // btnAddNewAdvanceRequest
            // 
            this.btnAddNewAdvanceRequest.Image = global::appExcelERP.Properties.Resources.RequestPlugin_16x;
            this.btnAddNewAdvanceRequest.Text = "&Add New Advance Request";
            this.btnAddNewAdvanceRequest.UniqueName = "B240F2CCB1D94F5426AAB3027D1A95C3";
            this.btnAddNewAdvanceRequest.Click += new System.EventHandler(this.btnAddNewAdvanceRequest_Click);
            // 
            // btnEditAdvanceRequest
            // 
            this.btnEditAdvanceRequest.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x1;
            this.btnEditAdvanceRequest.Text = "Edit Request";
            this.btnEditAdvanceRequest.UniqueName = "BD18FE032E1748130B90CFD8B6DFE3D1";
            this.btnEditAdvanceRequest.Click += new System.EventHandler(this.btnEditAdvanceRequest_Click);
            // 
            // btnDeleteAdvanceRequests
            // 
            this.btnDeleteAdvanceRequests.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteAdvanceRequests.Text = "&Delete Request";
            this.btnDeleteAdvanceRequests.UniqueName = "FFABE1C6D26D4599C7AA84BC8BFE6240";
            this.btnDeleteAdvanceRequests.Click += new System.EventHandler(this.btnDeleteAdvanceRequests_Click);
            // 
            // gridAdvanceRequests
            // 
            this.gridAdvanceRequests.AllowUserToAddRows = false;
            this.gridAdvanceRequests.AllowUserToDeleteRows = false;
            this.gridAdvanceRequests.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAdvanceRequests.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAdvanceRequests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAdvanceRequests.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAdvanceRequests.CausesValidation = false;
            this.gridAdvanceRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAdvanceRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdvanceRequests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAdvanceRequests.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridAdvanceRequests.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridAdvanceRequests.Location = new System.Drawing.Point(0, 28);
            this.gridAdvanceRequests.MultiSelect = false;
            this.gridAdvanceRequests.Name = "gridAdvanceRequests";
            this.gridAdvanceRequests.ReadOnly = true;
            this.gridAdvanceRequests.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAdvanceRequests.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridAdvanceRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAdvanceRequests.Size = new System.Drawing.Size(632, 368);
            this.gridAdvanceRequests.StandardTab = true;
            this.gridAdvanceRequests.TabIndex = 16;
            this.gridAdvanceRequests.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdvanceRequests_RowEnter);
            // 
            // txtAdvanceSearch
            // 
            this.txtAdvanceSearch.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchMyAdvance});
            this.txtAdvanceSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAdvanceSearch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvanceSearch.Location = new System.Drawing.Point(0, 0);
            this.txtAdvanceSearch.Margin = new System.Windows.Forms.Padding(5);
            this.txtAdvanceSearch.Name = "txtAdvanceSearch";
            this.txtAdvanceSearch.Size = new System.Drawing.Size(632, 28);
            this.txtAdvanceSearch.TabIndex = 15;
             // 
            // btnSearchMyAdvance
            // 
            this.btnSearchMyAdvance.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchMyAdvance.Text = "&Search";
            this.btnSearchMyAdvance.UniqueName = "679C440E996D4DAE7AB07658CE88E247";
            this.btnSearchMyAdvance.Click += new System.EventHandler(this.btnSearchMyAdvance_Click);
            // 
            // PageMyAdvanceRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PageMyAdvanceRequests";
            this.Size = new System.Drawing.Size(634, 446);
            this.Load += new System.EventHandler(this.PageMyAdvanceRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdvanceRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewAdvanceRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditAdvanceRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteAdvanceRequests;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAdvanceRequests;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAdvanceSearch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchMyAdvance;
    }
}
