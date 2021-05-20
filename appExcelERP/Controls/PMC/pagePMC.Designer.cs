namespace appExcelERP.Controls.PMC
{
    partial class pagePMC
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
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewProject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditProject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteProject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnToggleProject = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.gridProjects = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchProject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboProjectStatuses = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tabProject = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageGeneralInfo = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageProjectConfiguration = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageProjectCalendar = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageProjectPlan = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageMaterialTakeOff = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageVariationToContract = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageProjectCloserChecklist = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageExtraWorksheetQuotation = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageSalesOrder = new ComponentFactory.Krypton.Navigator.KryptonPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectStatuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabProject)).BeginInit();
            this.tabProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectConfiguration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageMaterialTakeOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageVariationToContract)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectCloserChecklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageExtraWorksheetQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageSalesOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewProject,
            this.btnEditProject,
            this.btnDeleteProject,
            this.btnRefresh,
            this.btnToggleProject});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.splitContainerMain);
            this.headerGroupMain.Size = new System.Drawing.Size(899, 452);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Project Management";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnAddNewProject
            // 
            this.btnAddNewProject.Text = "&Add New Project";
            this.btnAddNewProject.UniqueName = "E0383E22BDB34C5072980283EC051296";
            this.btnAddNewProject.Click += new System.EventHandler(this.btnAddNewProject_Click);
            // 
            // btnEditProject
            // 
            this.btnEditProject.Text = "&Edit Project";
            this.btnEditProject.UniqueName = "DC07B0BCB8BA4AF4BDB10B2C23487B00";
            this.btnEditProject.Click += new System.EventHandler(this.btnEditProject_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Text = "&Delete Project";
            this.btnDeleteProject.UniqueName = "0DBC85C947964A47C38FBAA283F695D8";
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UniqueName = "48E8F9DAC662483F248FA8B8E7E0087A";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnToggleProject
            // 
            this.btnToggleProject.Image = global::appExcelERP.Properties.Resources.Collapse_16x;
            this.btnToggleProject.UniqueName = "DE804A1230B841105BAEA225641DEE20";
            this.btnToggleProject.Click += new System.EventHandler(this.btnToggleProject_Click);
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
            this.splitContainerMain.Panel1.Controls.Add(this.gridProjects);
            this.splitContainerMain.Panel1.Controls.Add(this.txtSearchProject);
            this.splitContainerMain.Panel1.Controls.Add(this.cboProjectStatuses);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabProject);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(897, 402);
            this.splitContainerMain.SplitterDistance = 264;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 0;
            // 
            // gridProjects
            // 
            this.gridProjects.AllowUserToAddRows = false;
            this.gridProjects.AllowUserToDeleteRows = false;
            this.gridProjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridProjects.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridProjects.ColumnHeadersHeight = 28;
            this.gridProjects.ColumnHeadersVisible = false;
            this.gridProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProjects.Location = new System.Drawing.Point(0, 41);
            this.gridProjects.Margin = new System.Windows.Forms.Padding(2);
            this.gridProjects.Name = "gridProjects";
            this.gridProjects.ReadOnly = true;
            this.gridProjects.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProjects.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProjects.RowTemplate.Height = 24;
            this.gridProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProjects.Size = new System.Drawing.Size(264, 361);
            this.gridProjects.TabIndex = 3;
            this.gridProjects.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProjects_RowEnter);
            // 
            // txtSearchProject
            // 
            this.txtSearchProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchProject.Location = new System.Drawing.Point(0, 21);
            this.txtSearchProject.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchProject.Name = "txtSearchProject";
            this.txtSearchProject.Size = new System.Drawing.Size(264, 20);
            this.txtSearchProject.TabIndex = 2;
            this.txtSearchProject.TextChanged += new System.EventHandler(this.txtSearchProject_TextChanged);
            // 
            // cboProjectStatuses
            // 
            this.cboProjectStatuses.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboProjectStatuses.DropDownWidth = 330;
            this.cboProjectStatuses.Location = new System.Drawing.Point(0, 0);
            this.cboProjectStatuses.Margin = new System.Windows.Forms.Padding(2);
            this.cboProjectStatuses.Name = "cboProjectStatuses";
            this.cboProjectStatuses.Size = new System.Drawing.Size(264, 21);
            this.cboProjectStatuses.TabIndex = 1;
            this.cboProjectStatuses.Text = "kryptonComboBox1";
            this.cboProjectStatuses.SelectionChangeCommitted += new System.EventHandler(this.cboProjectStatuses_SelectionChangeCommitted);
            // 
            // tabProject
            // 
            this.tabProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProject.Location = new System.Drawing.Point(0, 0);
            this.tabProject.Margin = new System.Windows.Forms.Padding(2);
            this.tabProject.Name = "tabProject";
            this.tabProject.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageGeneralInfo,
            this.tabPageProjectConfiguration,
            this.tabPageProjectCalendar,
            this.tabPageProjectPlan,
            this.tabPageMaterialTakeOff,
            this.tabPageVariationToContract,
            this.tabPageProjectCloserChecklist,
            this.tabPageExtraWorksheetQuotation,
            this.tabPageSalesOrder});
            this.tabProject.SelectedIndex = 8;
            this.tabProject.Size = new System.Drawing.Size(626, 402);
            this.tabProject.TabIndex = 0;
            this.tabProject.Text = "kryptonNavigator1";
            this.tabProject.TabClicked += new System.EventHandler<ComponentFactory.Krypton.Navigator.KryptonPageEventArgs>(this.tabProject_TabClicked);
            // 
            // tabPageGeneralInfo
            // 
            this.tabPageGeneralInfo.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageGeneralInfo.Flags = 65534;
            this.tabPageGeneralInfo.LastVisibleSet = true;
            this.tabPageGeneralInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageGeneralInfo.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageGeneralInfo.Name = "tabPageGeneralInfo";
            this.tabPageGeneralInfo.Size = new System.Drawing.Size(624, 375);
            this.tabPageGeneralInfo.Text = "General Info.";
            this.tabPageGeneralInfo.ToolTipTitle = "Page ToolTip";
            this.tabPageGeneralInfo.UniqueName = "83E525E8206E41C4ACA7AD2D3E31B405";
            // 
            // tabPageProjectConfiguration
            // 
            this.tabPageProjectConfiguration.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageProjectConfiguration.Flags = 65534;
            this.tabPageProjectConfiguration.LastVisibleSet = true;
            this.tabPageProjectConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageProjectConfiguration.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageProjectConfiguration.Name = "tabPageProjectConfiguration";
            this.tabPageProjectConfiguration.Size = new System.Drawing.Size(765, 375);
            this.tabPageProjectConfiguration.Text = "Configuration";
            this.tabPageProjectConfiguration.ToolTipTitle = "Page ToolTip";
            this.tabPageProjectConfiguration.UniqueName = "E1BF614383A64CC6B3BA1F1CA41EAD6A";
            // 
            // tabPageProjectCalendar
            // 
            this.tabPageProjectCalendar.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageProjectCalendar.Flags = 65534;
            this.tabPageProjectCalendar.LastVisibleSet = true;
            this.tabPageProjectCalendar.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageProjectCalendar.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageProjectCalendar.Name = "tabPageProjectCalendar";
            this.tabPageProjectCalendar.Size = new System.Drawing.Size(765, 375);
            this.tabPageProjectCalendar.Text = "Calendar";
            this.tabPageProjectCalendar.ToolTipTitle = "Page ToolTip";
            this.tabPageProjectCalendar.UniqueName = "0C99348802464DB651B7ABF1C13C2EC8";
            // 
            // tabPageProjectPlan
            // 
            this.tabPageProjectPlan.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageProjectPlan.Flags = 65534;
            this.tabPageProjectPlan.LastVisibleSet = true;
            this.tabPageProjectPlan.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageProjectPlan.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageProjectPlan.Name = "tabPageProjectPlan";
            this.tabPageProjectPlan.Size = new System.Drawing.Size(624, 375);
            this.tabPageProjectPlan.Text = "Project Plan";
            this.tabPageProjectPlan.TextDescription = "Project - Gantt Chart View ";
            this.tabPageProjectPlan.ToolTipTitle = "Page ToolTip";
            this.tabPageProjectPlan.UniqueName = "3D4EA411A7F74F802DA624A33D0A67A9";
            // 
            // tabPageMaterialTakeOff
            // 
            this.tabPageMaterialTakeOff.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageMaterialTakeOff.Flags = 65534;
            this.tabPageMaterialTakeOff.LastVisibleSet = true;
            this.tabPageMaterialTakeOff.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageMaterialTakeOff.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageMaterialTakeOff.Name = "tabPageMaterialTakeOff";
            this.tabPageMaterialTakeOff.Size = new System.Drawing.Size(765, 375);
            this.tabPageMaterialTakeOff.Text = "Material Take Off";
            this.tabPageMaterialTakeOff.ToolTipTitle = "Page ToolTip";
            this.tabPageMaterialTakeOff.UniqueName = "1FA1FA6B9F89435B31B9CB983E6B341C";
            // 
            // tabPageVariationToContract
            // 
            this.tabPageVariationToContract.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageVariationToContract.Flags = 65534;
            this.tabPageVariationToContract.LastVisibleSet = true;
            this.tabPageVariationToContract.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageVariationToContract.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageVariationToContract.Name = "tabPageVariationToContract";
            this.tabPageVariationToContract.Size = new System.Drawing.Size(765, 375);
            this.tabPageVariationToContract.Text = "Variation To Contract";
            this.tabPageVariationToContract.ToolTipTitle = "Page ToolTip";
            this.tabPageVariationToContract.UniqueName = "35398473792346EAA3A63D5E776A12FD";
            // 
            // tabPageProjectCloserChecklist
            // 
            this.tabPageProjectCloserChecklist.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageProjectCloserChecklist.Flags = 65534;
            this.tabPageProjectCloserChecklist.LastVisibleSet = true;
            this.tabPageProjectCloserChecklist.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageProjectCloserChecklist.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageProjectCloserChecklist.Name = "tabPageProjectCloserChecklist";
            this.tabPageProjectCloserChecklist.Size = new System.Drawing.Size(624, 375);
            this.tabPageProjectCloserChecklist.Text = "Project Closer Checklist";
            this.tabPageProjectCloserChecklist.ToolTipTitle = "Page ToolTip";
            this.tabPageProjectCloserChecklist.UniqueName = "522253CD29B44C1E37A1BA027A22211E";
            // 
            // tabPageExtraWorksheetQuotation
            // 
            this.tabPageExtraWorksheetQuotation.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageExtraWorksheetQuotation.Flags = 65534;
            this.tabPageExtraWorksheetQuotation.LastVisibleSet = true;
            this.tabPageExtraWorksheetQuotation.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageExtraWorksheetQuotation.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageExtraWorksheetQuotation.Name = "tabPageExtraWorksheetQuotation";
            this.tabPageExtraWorksheetQuotation.Size = new System.Drawing.Size(624, 375);
            this.tabPageExtraWorksheetQuotation.Text = "Quotations (Extra Worksheet) ";
            this.tabPageExtraWorksheetQuotation.ToolTipTitle = "Page ToolTip";
            this.tabPageExtraWorksheetQuotation.UniqueName = "28AAF03AA97A4455C89CDDFA2933812C";
            // 
            // tabPageSalesOrder
            // 
            this.tabPageSalesOrder.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageSalesOrder.Flags = 65534;
            this.tabPageSalesOrder.LastVisibleSet = true;
            this.tabPageSalesOrder.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageSalesOrder.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageSalesOrder.Name = "tabPageSalesOrder";
            this.tabPageSalesOrder.Size = new System.Drawing.Size(624, 375);
            this.tabPageSalesOrder.Text = "Sales Order(s)";
            this.tabPageSalesOrder.ToolTipTitle = "Page ToolTip";
            this.tabPageSalesOrder.UniqueName = "9BF3CA2F34844E2CE9A2BC3BF728F75C";
            // 
            // pagePMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.headerGroupMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "pagePMC";
            this.Size = new System.Drawing.Size(899, 452);
            this.Load += new System.EventHandler(this.pagePMC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProjectStatuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabProject)).EndInit();
            this.tabProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectConfiguration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageMaterialTakeOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageVariationToContract)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProjectCloserChecklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageExtraWorksheetQuotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageSalesOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProjectStatuses;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchProject;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridProjects;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabProject;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageGeneralInfo;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageMaterialTakeOff;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageProjectCalendar;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageProjectPlan;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageProjectConfiguration;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageVariationToContract;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageExtraWorksheetQuotation;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageProjectCloserChecklist;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageSalesOrder;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewProject;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditProject;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteProject;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnToggleProject;
    }
}
