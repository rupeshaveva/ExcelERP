namespace appExcelERP.Controls.HR
{
    partial class PageAdvanceRequestsRegister
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
            this.gridAdvanceRegister = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.hederGroupAdvanceRequest = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnApproveReject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtSearchAdvanceRequest = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchAdvanceRequestRegister = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnExportAdvanceRequest = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gridAdvanceRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupAdvanceRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupAdvanceRequest.Panel)).BeginInit();
            this.hederGroupAdvanceRequest.Panel.SuspendLayout();
            this.hederGroupAdvanceRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridAdvanceRegister
            // 
            this.gridAdvanceRegister.AllowUserToAddRows = false;
            this.gridAdvanceRegister.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAdvanceRegister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAdvanceRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAdvanceRegister.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAdvanceRegister.CausesValidation = false;
            this.gridAdvanceRegister.ColumnHeadersHeight = 25;
            this.gridAdvanceRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAdvanceRegister.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAdvanceRegister.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridAdvanceRegister.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridAdvanceRegister.Location = new System.Drawing.Point(0, 28);
            this.gridAdvanceRegister.MultiSelect = false;
            this.gridAdvanceRegister.Name = "gridAdvanceRegister";
            this.gridAdvanceRegister.ReadOnly = true;
            this.gridAdvanceRegister.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAdvanceRegister.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridAdvanceRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAdvanceRegister.Size = new System.Drawing.Size(837, 395);
            this.gridAdvanceRegister.StandardTab = true;
            this.gridAdvanceRegister.TabIndex = 16;
            this.gridAdvanceRegister.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAdvanceRegister_RowEnter);
            // 
            // hederGroupAdvanceRequest
            // 
            this.hederGroupAdvanceRequest.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnApproveReject,
            this.btnRefresh,
            this.btnExportAdvanceRequest});
            this.hederGroupAdvanceRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hederGroupAdvanceRequest.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.hederGroupAdvanceRequest.Location = new System.Drawing.Point(0, 0);
            this.hederGroupAdvanceRequest.Name = "hederGroupAdvanceRequest";
            // 
            // hederGroupAdvanceRequest.Panel
            // 
            this.hederGroupAdvanceRequest.Panel.Controls.Add(this.gridAdvanceRegister);
            this.hederGroupAdvanceRequest.Panel.Controls.Add(this.txtSearchAdvanceRequest);
            this.hederGroupAdvanceRequest.Size = new System.Drawing.Size(839, 473);
            this.hederGroupAdvanceRequest.TabIndex = 2;
            this.hederGroupAdvanceRequest.ValuesPrimary.Heading = "Advance Request Register";
            this.hederGroupAdvanceRequest.ValuesPrimary.Image = null;
            // 
            // btnApproveReject
            // 
            this.btnApproveReject.Image = global::appExcelERP.Properties.Resources.Sequence_16x;
            this.btnApproveReject.Text = "&Approve/Reject Request";
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
            // txtSearchAdvanceRequest
            // 
            this.txtSearchAdvanceRequest.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchAdvanceRequestRegister});
            this.txtSearchAdvanceRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchAdvanceRequest.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchAdvanceRequest.Location = new System.Drawing.Point(0, 0);
            this.txtSearchAdvanceRequest.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchAdvanceRequest.Name = "txtSearchAdvanceRequest";
            this.txtSearchAdvanceRequest.Size = new System.Drawing.Size(837, 28);
            this.txtSearchAdvanceRequest.TabIndex = 15;
            // 
            // btnSearchAdvanceRequestRegister
            // 
            this.btnSearchAdvanceRequestRegister.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchAdvanceRequestRegister.Text = "&Search";
            this.btnSearchAdvanceRequestRegister.UniqueName = "BA97B4B13826489CD7B022DA8A709354";
            this.btnSearchAdvanceRequestRegister.Click += new System.EventHandler(this.btnSearchAdvanceRequestRegister_Click);
            // 
            // btnExportAdvanceRequest
            // 
            this.btnExportAdvanceRequest.Image = global::appExcelERP.Properties.Resources.ExportToExcel_16x;
            this.btnExportAdvanceRequest.UniqueName = "83737E58111E404E6BAFF24817F532EB";
            this.btnExportAdvanceRequest.Click += new System.EventHandler(this.btnExportAdvanceRequest_Click);
            // 
            // PageAdvanceRequestsRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hederGroupAdvanceRequest);
            this.Name = "PageAdvanceRequestsRegister";
            this.Size = new System.Drawing.Size(839, 473);
            this.Load += new System.EventHandler(this.PageAdvanceRequestsRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAdvanceRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupAdvanceRequest.Panel)).EndInit();
            this.hederGroupAdvanceRequest.Panel.ResumeLayout(false);
            this.hederGroupAdvanceRequest.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupAdvanceRequest)).EndInit();
            this.hederGroupAdvanceRequest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAdvanceRegister;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hederGroupAdvanceRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnApproveReject;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchAdvanceRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchAdvanceRequestRegister;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnExportAdvanceRequest;
    }
}
