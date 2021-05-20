namespace appExcelERP.Controls.MASTERS
{
    partial class PageBankMaster
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
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupBank = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewBank = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditBank = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridBanks = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchBank = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.headerGroupBranches = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewBranch = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditBranch = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridBankBranches = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchBranches = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBank.Panel)).BeginInit();
            this.headerGroupBank.Panel.SuspendLayout();
            this.headerGroupBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBanks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBranches.Panel)).BeginInit();
            this.headerGroupBranches.Panel.SuspendLayout();
            this.headerGroupBranches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBankBranches)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRefresh});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.splitContainerMain);
            this.headerGroupMain.Size = new System.Drawing.Size(803, 516);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Manage Banks";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "7D7ECA83090E4D68198EB13E0E4E46F1";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupBank);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupBranches);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(801, 484);
            this.splitContainerMain.SplitterDistance = 266;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupBank
            // 
            this.headerGroupBank.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewBank,
            this.btnEditBank});
            this.headerGroupBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupBank.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupBank.Location = new System.Drawing.Point(0, 0);
            this.headerGroupBank.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupBank.Name = "headerGroupBank";
            // 
            // headerGroupBank.Panel
            // 
            this.headerGroupBank.Panel.Controls.Add(this.gridBanks);
            this.headerGroupBank.Panel.Controls.Add(this.txtSearchBank);
            this.headerGroupBank.Size = new System.Drawing.Size(266, 484);
            this.headerGroupBank.TabIndex = 0;
            this.headerGroupBank.ValuesPrimary.Heading = "Bank Info.";
            this.headerGroupBank.ValuesPrimary.Image = null;
            // 
            // btnAddNewBank
            // 
            this.btnAddNewBank.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewBank.Text = "&Add New";
            this.btnAddNewBank.UniqueName = "5FCA681F98564DBE56BFE093D3D9A51A";
            this.btnAddNewBank.Click += new System.EventHandler(this.btnAddNewBank_Click);
            // 
            // btnEditBank
            // 
            this.btnEditBank.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditBank.Text = "&Edit";
            this.btnEditBank.UniqueName = "8875810EA31E4580639F67EBF20CDAE3";
            this.btnEditBank.Click += new System.EventHandler(this.btnEditBank_Click);
            // 
            // gridBanks
            // 
            this.gridBanks.AllowUserToAddRows = false;
            this.gridBanks.AllowUserToDeleteRows = false;
            this.gridBanks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBanks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridBanks.ColumnHeadersHeight = 28;
            this.gridBanks.ColumnHeadersVisible = false;
            this.gridBanks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBanks.Location = new System.Drawing.Point(0, 20);
            this.gridBanks.Margin = new System.Windows.Forms.Padding(2);
            this.gridBanks.Name = "gridBanks";
            this.gridBanks.ReadOnly = true;
            this.gridBanks.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBanks.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridBanks.RowTemplate.Height = 24;
            this.gridBanks.Size = new System.Drawing.Size(264, 414);
            this.gridBanks.TabIndex = 4;
            this.gridBanks.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridBanks_DataBindingComplete);
            this.gridBanks.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBanks_RowEnter);
            // 
            // txtSearchBank
            // 
            this.txtSearchBank.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchBank.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBank.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchBank.Name = "txtSearchBank";
            this.txtSearchBank.Size = new System.Drawing.Size(264, 20);
            this.txtSearchBank.TabIndex = 3;
            this.txtSearchBank.TextChanged += new System.EventHandler(this.txtSearchBank_TextChanged);
            // 
            // headerGroupBranches
            // 
            this.headerGroupBranches.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewBranch,
            this.btnEditBranch});
            this.headerGroupBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupBranches.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupBranches.Location = new System.Drawing.Point(0, 0);
            this.headerGroupBranches.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupBranches.Name = "headerGroupBranches";
            // 
            // headerGroupBranches.Panel
            // 
            this.headerGroupBranches.Panel.Controls.Add(this.gridBankBranches);
            this.headerGroupBranches.Panel.Controls.Add(this.txtSearchBranches);
            this.headerGroupBranches.Size = new System.Drawing.Size(528, 484);
            this.headerGroupBranches.TabIndex = 1;
            this.headerGroupBranches.ValuesPrimary.Heading = "Branches Info";
            this.headerGroupBranches.ValuesPrimary.Image = null;
            // 
            // btnAddNewBranch
            // 
            this.btnAddNewBranch.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewBranch.Text = "&Add New";
            this.btnAddNewBranch.UniqueName = "5FCA681F98564DBE56BFE093D3D9A51A";
            this.btnAddNewBranch.Click += new System.EventHandler(this.btnAddNewBranch_Click);
            // 
            // btnEditBranch
            // 
            this.btnEditBranch.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditBranch.Text = "&Edit";
            this.btnEditBranch.UniqueName = "8875810EA31E4580639F67EBF20CDAE3";
            this.btnEditBranch.Click += new System.EventHandler(this.btnEditBranch_Click);
            // 
            // gridBankBranches
            // 
            this.gridBankBranches.AllowUserToAddRows = false;
            this.gridBankBranches.AllowUserToDeleteRows = false;
            this.gridBankBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridBankBranches.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridBankBranches.ColumnHeadersHeight = 28;
            this.gridBankBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBankBranches.Location = new System.Drawing.Point(0, 20);
            this.gridBankBranches.Margin = new System.Windows.Forms.Padding(2);
            this.gridBankBranches.Name = "gridBankBranches";
            this.gridBankBranches.ReadOnly = true;
            this.gridBankBranches.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridBankBranches.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridBankBranches.RowTemplate.Height = 24;
            this.gridBankBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridBankBranches.Size = new System.Drawing.Size(526, 414);
            this.gridBankBranches.TabIndex = 6;
            this.gridBankBranches.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridBankBranches_DataBindingComplete);
            this.gridBankBranches.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridBankBranches_RowEnter);
            // 
            // txtSearchBranches
            // 
            this.txtSearchBranches.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchBranches.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBranches.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchBranches.Name = "txtSearchBranches";
            this.txtSearchBranches.Size = new System.Drawing.Size(526, 20);
            this.txtSearchBranches.TabIndex = 5;
            this.txtSearchBranches.TextChanged += new System.EventHandler(this.txtSearchBranches_TextChanged);
            // 
            // PageBankMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PageBankMaster";
            this.Size = new System.Drawing.Size(803, 516);
            this.Load += new System.EventHandler(this.PageBankMaster_Load);
            this.Resize += new System.EventHandler(this.PageBankMaster_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBank.Panel)).EndInit();
            this.headerGroupBank.Panel.ResumeLayout(false);
            this.headerGroupBank.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBank)).EndInit();
            this.headerGroupBank.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBanks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBranches.Panel)).EndInit();
            this.headerGroupBranches.Panel.ResumeLayout(false);
            this.headerGroupBranches.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupBranches)).EndInit();
            this.headerGroupBranches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBankBranches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupBank;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewBank;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditBank;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupBranches;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewBranch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditBranch;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridBanks;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchBank;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridBankBranches;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchBranches;
    }
}
