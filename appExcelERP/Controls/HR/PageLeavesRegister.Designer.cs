namespace appExcelERP.Controls.HR
{
    partial class PageLeavesRegister
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
            this.hederGroupLeaveRegister = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnApproveReject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridLeaveRegister = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchLeaveRegister = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchLeaveRegister = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveRegister.Panel)).BeginInit();
            this.hederGroupLeaveRegister.Panel.SuspendLayout();
            this.hederGroupLeaveRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaveRegister)).BeginInit();
            this.SuspendLayout();
            // 
            // hederGroupLeaveRegister
            // 
            this.hederGroupLeaveRegister.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnApproveReject,
            this.btnRefresh});
            this.hederGroupLeaveRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hederGroupLeaveRegister.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.hederGroupLeaveRegister.Location = new System.Drawing.Point(0, 0);
            this.hederGroupLeaveRegister.Name = "hederGroupLeaveRegister";
            // 
            // hederGroupLeaveRegister.Panel
            // 
            this.hederGroupLeaveRegister.Panel.Controls.Add(this.gridLeaveRegister);
            this.hederGroupLeaveRegister.Panel.Controls.Add(this.txtSearchLeaveRegister);
            this.hederGroupLeaveRegister.Size = new System.Drawing.Size(842, 355);
            this.hederGroupLeaveRegister.TabIndex = 1;
            this.hederGroupLeaveRegister.ValuesPrimary.Heading = "Leave(s) Register";
            this.hederGroupLeaveRegister.ValuesPrimary.Image = null;
            // 
            // btnApproveReject
            // 
            this.btnApproveReject.Image = global::appExcelERP.Properties.Resources.Sequence_16x;
            this.btnApproveReject.Text = "&Approve/Reject Leave Info";
            this.btnApproveReject.UniqueName = "B240F2CCB1D94F5426AAB3027D1A95C3";
            this.btnApproveReject.Click += new System.EventHandler(this.btnApproveReject_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "9C673832B4B1475199B31DAA2EA319FA";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridLeaveRegister
            // 
            this.gridLeaveRegister.AllowUserToAddRows = false;
            this.gridLeaveRegister.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLeaveRegister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLeaveRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLeaveRegister.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLeaveRegister.CausesValidation = false;
            this.gridLeaveRegister.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLeaveRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLeaveRegister.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLeaveRegister.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridLeaveRegister.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridLeaveRegister.Location = new System.Drawing.Point(0, 28);
            this.gridLeaveRegister.MultiSelect = false;
            this.gridLeaveRegister.Name = "gridLeaveRegister";
            this.gridLeaveRegister.ReadOnly = true;
            this.gridLeaveRegister.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLeaveRegister.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLeaveRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLeaveRegister.Size = new System.Drawing.Size(840, 277);
            this.gridLeaveRegister.StandardTab = true;
            this.gridLeaveRegister.TabIndex = 16;
            this.gridLeaveRegister.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLeaveRegister_RowEnter);
            // 
            // txtSearchLeaveRegister
            // 
            this.txtSearchLeaveRegister.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchLeaveRegister});
            this.txtSearchLeaveRegister.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchLeaveRegister.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchLeaveRegister.Location = new System.Drawing.Point(0, 0);
            this.txtSearchLeaveRegister.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchLeaveRegister.Name = "txtSearchLeaveRegister";
            this.txtSearchLeaveRegister.Size = new System.Drawing.Size(840, 28);
            this.txtSearchLeaveRegister.TabIndex = 15;
            // 
            // btnSearchLeaveRegister
            // 
            this.btnSearchLeaveRegister.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchLeaveRegister.Text = "&Search";
            this.btnSearchLeaveRegister.UniqueName = "B02C7D97E15140A3C18FEDB1C1D24EDB";
            this.btnSearchLeaveRegister.Click += new System.EventHandler(this.btnSearchLeaveRegister_Click);
            // 
            // PageLeavesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hederGroupLeaveRegister);
            this.Name = "PageLeavesRegister";
            this.Size = new System.Drawing.Size(842, 355);
            this.Load += new System.EventHandler(this.PageLeavesRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveRegister.Panel)).EndInit();
            this.hederGroupLeaveRegister.Panel.ResumeLayout(false);
            this.hederGroupLeaveRegister.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLeaveRegister)).EndInit();
            this.hederGroupLeaveRegister.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaveRegister)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hederGroupLeaveRegister;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnApproveReject;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLeaveRegister;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchLeaveRegister;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchLeaveRegister;
    }
}
