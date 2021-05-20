namespace appExcelERP.Controls.HR
{
    partial class PageLoanRequestRegister
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
            this.gridLoanRequestRegister = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.hederGroupLoanRequest = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnApproveReject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtSearchLoanRequest = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchLoanRequestRegister = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoanRequestRegister)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanRequest.Panel)).BeginInit();
            this.hederGroupLoanRequest.Panel.SuspendLayout();
            this.hederGroupLoanRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridLoanRequestRegister
            // 
            this.gridLoanRequestRegister.AllowUserToAddRows = false;
            this.gridLoanRequestRegister.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoanRequestRegister.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLoanRequestRegister.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLoanRequestRegister.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLoanRequestRegister.CausesValidation = false;
            this.gridLoanRequestRegister.ColumnHeadersHeight = 25;
            this.gridLoanRequestRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLoanRequestRegister.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLoanRequestRegister.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridLoanRequestRegister.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridLoanRequestRegister.Location = new System.Drawing.Point(0, 28);
            this.gridLoanRequestRegister.MultiSelect = false;
            this.gridLoanRequestRegister.Name = "gridLoanRequestRegister";
            this.gridLoanRequestRegister.ReadOnly = true;
            this.gridLoanRequestRegister.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoanRequestRegister.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLoanRequestRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLoanRequestRegister.Size = new System.Drawing.Size(744, 386);
            this.gridLoanRequestRegister.StandardTab = true;
            this.gridLoanRequestRegister.TabIndex = 16;
            this.gridLoanRequestRegister.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoanRegister_RowEnter);
            // 
            // hederGroupLoanRequest
            // 
            this.hederGroupLoanRequest.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnApproveReject,
            this.btnRefresh});
            this.hederGroupLoanRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hederGroupLoanRequest.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.hederGroupLoanRequest.Location = new System.Drawing.Point(0, 0);
            this.hederGroupLoanRequest.Name = "hederGroupLoanRequest";
            // 
            // hederGroupLoanRequest.Panel
            // 
            this.hederGroupLoanRequest.Panel.Controls.Add(this.gridLoanRequestRegister);
            this.hederGroupLoanRequest.Panel.Controls.Add(this.txtSearchLoanRequest);
            this.hederGroupLoanRequest.Size = new System.Drawing.Size(746, 464);
            this.hederGroupLoanRequest.TabIndex = 3;
            this.hederGroupLoanRequest.ValuesPrimary.Heading = "Loan Requests Register";
            this.hederGroupLoanRequest.ValuesPrimary.Image = null;
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
            // txtSearchLoanRequest
            // 
            this.txtSearchLoanRequest.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchLoanRequestRegister});
            this.txtSearchLoanRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchLoanRequest.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchLoanRequest.Location = new System.Drawing.Point(0, 0);
            this.txtSearchLoanRequest.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchLoanRequest.Name = "txtSearchLoanRequest";
            this.txtSearchLoanRequest.Size = new System.Drawing.Size(744, 28);
            this.txtSearchLoanRequest.TabIndex = 15;
            // 
            // btnSearchLoanRequestRegister
            // 
            this.btnSearchLoanRequestRegister.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchLoanRequestRegister.Text = "&Search";
            this.btnSearchLoanRequestRegister.UniqueName = "9E10FBF83408481034A84AEF507FB199";
            this.btnSearchLoanRequestRegister.Click += new System.EventHandler(this.btnSearchLoanRequestRegister_Click);
            // 
            // PageLoanRequestRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hederGroupLoanRequest);
            this.Name = "PageLoanRequestRegister";
            this.Size = new System.Drawing.Size(746, 464);
            this.Load += new System.EventHandler(this.PageLoanRequestRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLoanRequestRegister)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanRequest.Panel)).EndInit();
            this.hederGroupLoanRequest.Panel.ResumeLayout(false);
            this.hederGroupLoanRequest.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hederGroupLoanRequest)).EndInit();
            this.hederGroupLoanRequest.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLoanRequestRegister;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup hederGroupLoanRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnApproveReject;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchLoanRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchLoanRequestRegister;
    }
}
