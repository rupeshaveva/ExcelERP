namespace appExcelERP.Controls.USER_INFO
{
    partial class PageMyLeaves
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
            this.hederGroupLeaveApplications = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefreshLeaves = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridLeaveApplications = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchLeaveApplications = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchMyLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveApplications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveApplications.Panel)).BeginInit();
            this.hederGroupLeaveApplications.Panel.SuspendLayout();
            this.hederGroupLeaveApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaveApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // hederGroupLeaveApplications
            // 
            this.hederGroupLeaveApplications.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewLeave,
            this.btnEditLeave,
            this.btnDeleteLeave,
            this.btnRefreshLeaves});
            this.hederGroupLeaveApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hederGroupLeaveApplications.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.hederGroupLeaveApplications.Location = new System.Drawing.Point(0, 0);
            this.hederGroupLeaveApplications.Name = "hederGroupLeaveApplications";
            // 
            // hederGroupLeaveApplications.Panel
            // 
            this.hederGroupLeaveApplications.Panel.Controls.Add(this.gridLeaveApplications);
            this.hederGroupLeaveApplications.Panel.Controls.Add(this.txtSearchLeaveApplications);
            this.hederGroupLeaveApplications.Size = new System.Drawing.Size(639, 476);
            this.hederGroupLeaveApplications.TabIndex = 1;
            this.hederGroupLeaveApplications.ValuesPrimary.Heading = "My Leave(s) Book";
            this.hederGroupLeaveApplications.ValuesPrimary.Image = null;
            this.hederGroupLeaveApplications.Paint += new System.Windows.Forms.PaintEventHandler(this.hederGroupLeaveApplications_Paint);
            // 
            // btnAddNewLeave
            // 
            this.btnAddNewLeave.Image = global::appExcelERP.Properties.Resources.RequestPlugin_16x;
            this.btnAddNewLeave.Text = "&Apply for Leave";
            this.btnAddNewLeave.UniqueName = "B240F2CCB1D94F5426AAB3027D1A95C3";
            this.btnAddNewLeave.Click += new System.EventHandler(this.btnAddNewLeave_Click);
            // 
            // btnEditLeave
            // 
            this.btnEditLeave.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x1;
            this.btnEditLeave.Text = "Edit Application";
            this.btnEditLeave.UniqueName = "BD18FE032E1748130B90CFD8B6DFE3D1";
            this.btnEditLeave.Click += new System.EventHandler(this.btnEditLeave_Click);
            // 
            // btnDeleteLeave
            // 
            this.btnDeleteLeave.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteLeave.Text = "&Delete Application";
            this.btnDeleteLeave.UniqueName = "FFABE1C6D26D4599C7AA84BC8BFE6240";
            this.btnDeleteLeave.Click += new System.EventHandler(this.btnDeleteLeave_Click);
            // 
            // btnRefreshLeaves
            // 
            this.btnRefreshLeaves.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefreshLeaves.Text = "&Refresh";
            this.btnRefreshLeaves.UniqueName = "EDEE3A7F31B4478CFA828562427E545C";
            this.btnRefreshLeaves.Click += new System.EventHandler(this.btnRefreshLeaves_Click);
            // 
            // gridLeaveApplications
            // 
            this.gridLeaveApplications.AllowUserToAddRows = false;
            this.gridLeaveApplications.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLeaveApplications.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLeaveApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLeaveApplications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLeaveApplications.CausesValidation = false;
            this.gridLeaveApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLeaveApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLeaveApplications.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLeaveApplications.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridLeaveApplications.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridLeaveApplications.Location = new System.Drawing.Point(0, 28);
            this.gridLeaveApplications.MultiSelect = false;
            this.gridLeaveApplications.Name = "gridLeaveApplications";
            this.gridLeaveApplications.ReadOnly = true;
            this.gridLeaveApplications.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLeaveApplications.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLeaveApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLeaveApplications.Size = new System.Drawing.Size(637, 398);
            this.gridLeaveApplications.StandardTab = true;
            this.gridLeaveApplications.TabIndex = 16;
            this.gridLeaveApplications.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLeaveApplications_RowEnter);
            // 
            // txtSearchLeaveApplications
            // 
            this.txtSearchLeaveApplications.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchMyLeave});
            this.txtSearchLeaveApplications.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchLeaveApplications.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchLeaveApplications.Location = new System.Drawing.Point(0, 0);
            this.txtSearchLeaveApplications.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchLeaveApplications.Name = "txtSearchLeaveApplications";
            this.txtSearchLeaveApplications.Size = new System.Drawing.Size(637, 28);
            this.txtSearchLeaveApplications.TabIndex = 15;
            // 
            // btnSearchMyLeave
            // 
            this.btnSearchMyLeave.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchMyLeave.Text = "&Search";
            this.btnSearchMyLeave.UniqueName = "6B463FE05E46458EB98C44E5F91494BC";
            this.btnSearchMyLeave.Click += new System.EventHandler(this.btnSearchMyLeave_Click);
            // 
            // PageMyLeaves
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hederGroupLeaveApplications);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PageMyLeaves";
            this.Size = new System.Drawing.Size(639, 476);
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveApplications.Panel)).EndInit();
            this.hederGroupLeaveApplications.Panel.ResumeLayout(false);
            this.hederGroupLeaveApplications.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveApplications)).EndInit();
            this.hederGroupLeaveApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaveApplications)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hederGroupLeaveApplications;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewLeave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditLeave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteLeave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefreshLeaves;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLeaveApplications;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchLeaveApplications;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchMyLeave;
    }
}
