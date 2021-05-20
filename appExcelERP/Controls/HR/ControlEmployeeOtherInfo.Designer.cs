namespace appExcelERP.Controls.HR
{
    partial class ControlEmployeeOtherInfo
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
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupQualificationInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewQualificationInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditQualificationInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridQualificationInfo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchQualification = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.HeaderGroupLastEmployerDetail = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewLastEmployerInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditLastEmployerInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridLastEmployerInfo = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtLastEmployerSearch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.headrGroupOtherDetail = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSearchQualification = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnSearchLastEmployer = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQualificationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQualificationInfo.Panel)).BeginInit();
            this.headerGroupQualificationInfo.Panel.SuspendLayout();
            this.headerGroupQualificationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridQualificationInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLastEmployerDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLastEmployerDetail.Panel)).BeginInit();
            this.HeaderGroupLastEmployerDetail.Panel.SuspendLayout();
            this.HeaderGroupLastEmployerDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLastEmployerInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headrGroupOtherDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headrGroupOtherDetail.Panel)).BeginInit();
            this.headrGroupOtherDetail.Panel.SuspendLayout();
            this.headrGroupOtherDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupQualificationInfo);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.HeaderGroupLastEmployerDetail);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(867, 521);
            this.splitContainerMain.SplitterDistance = 216;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 1;
            // 
            // headerGroupQualificationInfo
            // 
            this.headerGroupQualificationInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewQualificationInfo,
            this.btnEditQualificationInfo});
            this.headerGroupQualificationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupQualificationInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupQualificationInfo.HeaderVisibleSecondary = false;
            this.headerGroupQualificationInfo.Location = new System.Drawing.Point(0, 0);
            this.headerGroupQualificationInfo.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupQualificationInfo.Name = "headerGroupQualificationInfo";
            // 
            // headerGroupQualificationInfo.Panel
            // 
            this.headerGroupQualificationInfo.Panel.Controls.Add(this.gridQualificationInfo);
            this.headerGroupQualificationInfo.Panel.Controls.Add(this.txtSearchQualification);
            this.headerGroupQualificationInfo.Size = new System.Drawing.Size(867, 216);
            this.headerGroupQualificationInfo.TabIndex = 1;
            this.headerGroupQualificationInfo.ValuesPrimary.Heading = "Qualification Details";
            this.headerGroupQualificationInfo.ValuesPrimary.Image = null;
            // 
            // btnAddNewQualificationInfo
            // 
            this.btnAddNewQualificationInfo.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddNewQualificationInfo.Text = "&Add New";
            this.btnAddNewQualificationInfo.UniqueName = "27905A18D90B43757D8CE05FE9C7F091";
            this.btnAddNewQualificationInfo.Click += new System.EventHandler(this.btnAddNewQualificationInfo_Click);
            // 
            // btnEditQualificationInfo
            // 
            this.btnEditQualificationInfo.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x1;
            this.btnEditQualificationInfo.Text = "&Edit";
            this.btnEditQualificationInfo.UniqueName = "C4110562478A4DE28EAC8717836BB739";
            this.btnEditQualificationInfo.Click += new System.EventHandler(this.btnEditQualificationInfo_Click);
            // 
            // gridQualificationInfo
            // 
            this.gridQualificationInfo.AllowUserToAddRows = false;
            this.gridQualificationInfo.AllowUserToDeleteRows = false;
            this.gridQualificationInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridQualificationInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridQualificationInfo.ColumnHeadersHeight = 28;
            this.gridQualificationInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridQualificationInfo.Location = new System.Drawing.Point(0, 28);
            this.gridQualificationInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gridQualificationInfo.Name = "gridQualificationInfo";
            this.gridQualificationInfo.ReadOnly = true;
            this.gridQualificationInfo.RowHeadersVisible = false;
            this.gridQualificationInfo.RowTemplate.Height = 24;
            this.gridQualificationInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridQualificationInfo.Size = new System.Drawing.Size(865, 159);
            this.gridQualificationInfo.TabIndex = 7;
            this.gridQualificationInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridQualificationInfo_DataBindingComplete);
            this.gridQualificationInfo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridQualificationInfo_RowEnter);
            // 
            // txtSearchQualification
            // 
            this.txtSearchQualification.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchQualification});
            this.txtSearchQualification.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchQualification.Location = new System.Drawing.Point(0, 0);
            this.txtSearchQualification.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchQualification.Name = "txtSearchQualification";
            this.txtSearchQualification.Size = new System.Drawing.Size(865, 28);
            this.txtSearchQualification.TabIndex = 6;
           // 
            // HeaderGroupLastEmployerDetail
            // 
            this.HeaderGroupLastEmployerDetail.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewLastEmployerInfo,
            this.btnEditLastEmployerInfo});
            this.HeaderGroupLastEmployerDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderGroupLastEmployerDetail.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.HeaderGroupLastEmployerDetail.HeaderVisibleSecondary = false;
            this.HeaderGroupLastEmployerDetail.Location = new System.Drawing.Point(0, 0);
            this.HeaderGroupLastEmployerDetail.Margin = new System.Windows.Forms.Padding(2);
            this.HeaderGroupLastEmployerDetail.Name = "HeaderGroupLastEmployerDetail";
            // 
            // HeaderGroupLastEmployerDetail.Panel
            // 
            this.HeaderGroupLastEmployerDetail.Panel.Controls.Add(this.gridLastEmployerInfo);
            this.HeaderGroupLastEmployerDetail.Panel.Controls.Add(this.txtLastEmployerSearch);
            this.HeaderGroupLastEmployerDetail.Size = new System.Drawing.Size(867, 298);
            this.HeaderGroupLastEmployerDetail.TabIndex = 2;
            this.HeaderGroupLastEmployerDetail.ValuesPrimary.Heading = "Previous Employer(s)";
            this.HeaderGroupLastEmployerDetail.ValuesPrimary.Image = null;
            // 
            // btnAddNewLastEmployerInfo
            // 
            this.btnAddNewLastEmployerInfo.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddNewLastEmployerInfo.Text = "&Add New";
            this.btnAddNewLastEmployerInfo.UniqueName = "27905A18D90B43757D8CE05FE9C7F091";
            this.btnAddNewLastEmployerInfo.Click += new System.EventHandler(this.btnAddNewLastEmployerInfo_Click);
            // 
            // btnEditLastEmployerInfo
            // 
            this.btnEditLastEmployerInfo.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x1;
            this.btnEditLastEmployerInfo.Text = "&Edit";
            this.btnEditLastEmployerInfo.UniqueName = "C4110562478A4DE28EAC8717836BB739";
            this.btnEditLastEmployerInfo.Click += new System.EventHandler(this.btnEditLastEmployerInfo_Click);
            // 
            // gridLastEmployerInfo
            // 
            this.gridLastEmployerInfo.AllowUserToAddRows = false;
            this.gridLastEmployerInfo.AllowUserToDeleteRows = false;
            this.gridLastEmployerInfo.AllowUserToOrderColumns = true;
            this.gridLastEmployerInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLastEmployerInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLastEmployerInfo.ColumnHeadersHeight = 28;
            this.gridLastEmployerInfo.ColumnHeadersVisible = false;
            this.gridLastEmployerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLastEmployerInfo.Location = new System.Drawing.Point(0, 28);
            this.gridLastEmployerInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gridLastEmployerInfo.Name = "gridLastEmployerInfo";
            this.gridLastEmployerInfo.ReadOnly = true;
            this.gridLastEmployerInfo.RowHeadersVisible = false;
            this.gridLastEmployerInfo.RowTemplate.Height = 24;
            this.gridLastEmployerInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLastEmployerInfo.Size = new System.Drawing.Size(865, 241);
            this.gridLastEmployerInfo.TabIndex = 9;
            this.gridLastEmployerInfo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridLastEmployerInfo_DataBindingComplete);
            this.gridLastEmployerInfo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLastEmployerInfo_RowEnter);
            // 
            // txtLastEmployerSearch
            // 
            this.txtLastEmployerSearch.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchLastEmployer});
            this.txtLastEmployerSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLastEmployerSearch.Location = new System.Drawing.Point(0, 0);
            this.txtLastEmployerSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtLastEmployerSearch.Name = "txtLastEmployerSearch";
            this.txtLastEmployerSearch.Size = new System.Drawing.Size(865, 28);
            this.txtLastEmployerSearch.TabIndex = 8;
           // 
            // headrGroupOtherDetail
            // 
            this.headrGroupOtherDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headrGroupOtherDetail.Location = new System.Drawing.Point(0, 0);
            this.headrGroupOtherDetail.Margin = new System.Windows.Forms.Padding(2);
            this.headrGroupOtherDetail.Name = "headrGroupOtherDetail";
            // 
            // headrGroupOtherDetail.Panel
            // 
            this.headrGroupOtherDetail.Panel.Controls.Add(this.splitContainerMain);
            this.headrGroupOtherDetail.Size = new System.Drawing.Size(869, 574);
            this.headrGroupOtherDetail.TabIndex = 2;
            this.headrGroupOtherDetail.ValuesPrimary.Heading = "Other Info.";
            this.headrGroupOtherDetail.ValuesPrimary.Image = null;
            // 
            // btnSearchQualification
            // 
            this.btnSearchQualification.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchQualification.Text = "&Search";
            this.btnSearchQualification.UniqueName = "247BBDA056764D2A5FBBAD7ABC3853F4";
            this.btnSearchQualification.Click += new System.EventHandler(this.btnSearchQualification_Click);
            // 
            // btnSearchLastEmployer
            // 
            this.btnSearchLastEmployer.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchLastEmployer.Text = "&Search";
            this.btnSearchLastEmployer.UniqueName = "8510F281F1154E0E28A581AE5EB3C06F";
            this.btnSearchLastEmployer.Click += new System.EventHandler(this.btnSearchLastEmployer_Click);
            // 
            // ControlEmployeeOtherInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headrGroupOtherDetail);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlEmployeeOtherInfo";
            this.Size = new System.Drawing.Size(869, 574);
            this.Load += new System.EventHandler(this.ControlEmployeeOtherInfo_Load);
            this.Resize += new System.EventHandler(this.ControlEmployeeOtherInfo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQualificationInfo.Panel)).EndInit();
            this.headerGroupQualificationInfo.Panel.ResumeLayout(false);
            this.headerGroupQualificationInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQualificationInfo)).EndInit();
            this.headerGroupQualificationInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridQualificationInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLastEmployerDetail.Panel)).EndInit();
            this.HeaderGroupLastEmployerDetail.Panel.ResumeLayout(false);
            this.HeaderGroupLastEmployerDetail.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderGroupLastEmployerDetail)).EndInit();
            this.HeaderGroupLastEmployerDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLastEmployerInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headrGroupOtherDetail.Panel)).EndInit();
            this.headrGroupOtherDetail.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headrGroupOtherDetail)).EndInit();
            this.headrGroupOtherDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupQualificationInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewQualificationInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditQualificationInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup HeaderGroupLastEmployerDetail;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewLastEmployerInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditLastEmployerInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLastEmployerSearch;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headrGroupOtherDetail;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchQualification;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridQualificationInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLastEmployerInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchQualification;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchLastEmployer;
    }
}
