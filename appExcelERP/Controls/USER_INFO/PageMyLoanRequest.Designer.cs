namespace appExcelERP.Controls.USER_INFO
{
    partial class PageMyLoanRequest
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
            this.HeaderGroupLoanRequest = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewLoanRequest = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditLoanRequest = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteLoanRequest = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridLoanRequest = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchLoanRequest = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchMyLoan = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLoanRequest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLoanRequest.Panel)).BeginInit();
            this.HeaderGroupLoanRequest.Panel.SuspendLayout();
            this.HeaderGroupLoanRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLoanRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderGroupLoanRequest
            // 
            this.HeaderGroupLoanRequest.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewLoanRequest,
            this.btnEditLoanRequest,
            this.btnDeleteLoanRequest,
            this.btnRefresh});
            this.HeaderGroupLoanRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderGroupLoanRequest.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.HeaderGroupLoanRequest.Location = new System.Drawing.Point(0, 0);
            this.HeaderGroupLoanRequest.Name = "HeaderGroupLoanRequest";
            // 
            // HeaderGroupLoanRequest.Panel
            // 
            this.HeaderGroupLoanRequest.Panel.Controls.Add(this.gridLoanRequest);
            this.HeaderGroupLoanRequest.Panel.Controls.Add(this.txtSearchLoanRequest);
            this.HeaderGroupLoanRequest.Size = new System.Drawing.Size(642, 410);
            this.HeaderGroupLoanRequest.TabIndex = 3;
            this.HeaderGroupLoanRequest.ValuesPrimary.Heading = "My Loan Request(s)";
            this.HeaderGroupLoanRequest.ValuesPrimary.Image = null;
            // 
            // btnAddNewLoanRequest
            // 
            this.btnAddNewLoanRequest.Image = global::appExcelERP.Properties.Resources.RequestPlugin_16x;
            this.btnAddNewLoanRequest.Text = "&Add New Loan Request";
            this.btnAddNewLoanRequest.UniqueName = "B240F2CCB1D94F5426AAB3027D1A95C3";
            this.btnAddNewLoanRequest.Click += new System.EventHandler(this.btnAddNewLoanRequest_Click);
            // 
            // btnEditLoanRequest
            // 
            this.btnEditLoanRequest.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x1;
            this.btnEditLoanRequest.Text = "Edit Request";
            this.btnEditLoanRequest.UniqueName = "BD18FE032E1748130B90CFD8B6DFE3D1";
            this.btnEditLoanRequest.Click += new System.EventHandler(this.btnEditLoanRequest_Click);
            // 
            // btnDeleteLoanRequest
            // 
            this.btnDeleteLoanRequest.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteLoanRequest.Text = "&Delete Request";
            this.btnDeleteLoanRequest.UniqueName = "FFABE1C6D26D4599C7AA84BC8BFE6240";
            this.btnDeleteLoanRequest.Click += new System.EventHandler(this.btnDeleteLoanRequest_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "6F8947EF6367403CB0AEE158902B999C";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridLoanRequest
            // 
            this.gridLoanRequest.AllowUserToAddRows = false;
            this.gridLoanRequest.AllowUserToDeleteRows = false;
            this.gridLoanRequest.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoanRequest.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLoanRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLoanRequest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLoanRequest.CausesValidation = false;
            this.gridLoanRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLoanRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLoanRequest.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLoanRequest.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridLoanRequest.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridDataCellList;
            this.gridLoanRequest.Location = new System.Drawing.Point(0, 28);
            this.gridLoanRequest.MultiSelect = false;
            this.gridLoanRequest.Name = "gridLoanRequest";
            this.gridLoanRequest.ReadOnly = true;
            this.gridLoanRequest.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLoanRequest.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridLoanRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLoanRequest.Size = new System.Drawing.Size(640, 332);
            this.gridLoanRequest.StandardTab = true;
            this.gridLoanRequest.TabIndex = 16;
            this.gridLoanRequest.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLoanRequest_RowEnter);
            // 
            // txtSearchLoanRequest
            // 
            this.txtSearchLoanRequest.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchMyLoan});
            this.txtSearchLoanRequest.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchLoanRequest.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchLoanRequest.Location = new System.Drawing.Point(0, 0);
            this.txtSearchLoanRequest.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchLoanRequest.Name = "txtSearchLoanRequest";
            this.txtSearchLoanRequest.Size = new System.Drawing.Size(640, 28);
            this.txtSearchLoanRequest.TabIndex = 15;
            // 
            // btnSearchMyLoan
            // 
            this.btnSearchMyLoan.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchMyLoan.Text = "&Search";
            this.btnSearchMyLoan.UniqueName = "D4233FE8BE1348DE0FADDC91E5740B41";
            this.btnSearchMyLoan.Click += new System.EventHandler(this.btnSearchMyLoan_Click);
            // 
            // PageMyLoanRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HeaderGroupLoanRequest);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PageMyLoanRequest";
            this.Size = new System.Drawing.Size(642, 410);
            this.Load += new System.EventHandler(this.PageMyLoanRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLoanRequest.Panel)).EndInit();
            this.HeaderGroupLoanRequest.Panel.ResumeLayout(false);
            this.HeaderGroupLoanRequest.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLoanRequest)).EndInit();
            this.HeaderGroupLoanRequest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLoanRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup HeaderGroupLoanRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewLoanRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditLoanRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteLoanRequest;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLoanRequest;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchLoanRequest;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchMyLoan;
    }
}
