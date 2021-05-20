namespace appExcelERP.Controls.ADMIN
{
    partial class pageModules
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
            this.headerGroupModule = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewModule = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditModule = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteModule = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridModules = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchModule = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchModule = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.headerGroupDeleteModule = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRestoreModule = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtDeleteModuleInfo = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.headerGroupForms = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewForm = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditForm = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteForm = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridForms = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchForm = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchForm = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.headerGroupDeleteForm = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnRestoreForm = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtDeleteFormInfo = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupModule.Panel)).BeginInit();
            this.headerGroupModule.Panel.SuspendLayout();
            this.headerGroupModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteModule.Panel)).BeginInit();
            this.headerGroupDeleteModule.Panel.SuspendLayout();
            this.headerGroupDeleteModule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupForms.Panel)).BeginInit();
            this.headerGroupForms.Panel.SuspendLayout();
            this.headerGroupForms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridForms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteForm.Panel)).BeginInit();
            this.headerGroupDeleteForm.Panel.SuspendLayout();
            this.headerGroupDeleteForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRefresh});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.splitContainerMain);
            this.headerGroupMain.Size = new System.Drawing.Size(749, 412);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Manage Application Modules its and Features";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UniqueName = "C2AE5A8EB3884BD2E3A06B75D8685B6D";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupModule);
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupDeleteModule);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupForms);
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupDeleteForm);
            this.splitContainerMain.Size = new System.Drawing.Size(747, 381);
            this.splitContainerMain.SplitterDistance = 361;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupModule
            // 
            this.headerGroupModule.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewModule,
            this.btnEditModule,
            this.btnDeleteModule});
            this.headerGroupModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupModule.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupModule.Location = new System.Drawing.Point(0, 0);
            this.headerGroupModule.Name = "headerGroupModule";
            // 
            // headerGroupModule.Panel
            // 
            this.headerGroupModule.Panel.Controls.Add(this.gridModules);
            this.headerGroupModule.Panel.Controls.Add(this.txtSearchModule);
            this.headerGroupModule.Size = new System.Drawing.Size(361, 253);
            this.headerGroupModule.TabIndex = 4;
            this.headerGroupModule.ValuesPrimary.Heading = "MODULES";
            this.headerGroupModule.ValuesPrimary.Image = global::appExcelERP.Properties.Resources.list_16xMD;
            // 
            // btnAddNewModule
            // 
            this.btnAddNewModule.Text = "&Add New";
            this.btnAddNewModule.UniqueName = "D1F31FEC8B2446CD948D558A31F54422";
            this.btnAddNewModule.Click += new System.EventHandler(this.btnAddNewModule_Click);
            // 
            // btnEditModule
            // 
            this.btnEditModule.Text = "&Edit";
            this.btnEditModule.UniqueName = "15D7627576B34537FAAB735C262660C9";
            this.btnEditModule.Click += new System.EventHandler(this.btnEditModule_Click);
            // 
            // btnDeleteModule
            // 
            this.btnDeleteModule.Text = "&Delete";
            this.btnDeleteModule.UniqueName = "6CA1CF28F7D144EAE09940A3A89BA948";
            this.btnDeleteModule.Click += new System.EventHandler(this.btnDeleteModule_Click);
            // 
            // gridModules
            // 
            this.gridModules.AllowUserToAddRows = false;
            this.gridModules.AllowUserToDeleteRows = false;
            this.gridModules.AllowUserToOrderColumns = true;
            this.gridModules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridModules.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridModules.ColumnHeadersVisible = false;
            this.gridModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridModules.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridModules.Location = new System.Drawing.Point(0, 28);
            this.gridModules.Name = "gridModules";
            this.gridModules.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridModules.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridModules.Size = new System.Drawing.Size(359, 175);
            this.gridModules.TabIndex = 9;
            this.gridModules.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridModules_DataBindingComplete);
            this.gridModules.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridModules_RowEnter);
            // 
            // txtSearchModule
            // 
            this.txtSearchModule.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchModule});
            this.txtSearchModule.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchModule.Location = new System.Drawing.Point(0, 0);
            this.txtSearchModule.Name = "txtSearchModule";
            this.txtSearchModule.Size = new System.Drawing.Size(359, 28);
            this.txtSearchModule.TabIndex = 8;
            // 
            // btnSearchModule
            // 
            this.btnSearchModule.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchModule.Text = "&Search";
            this.btnSearchModule.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            this.btnSearchModule.Click += new System.EventHandler(this.btnSearchModule_Click);
            // 
            // headerGroupDeleteModule
            // 
            this.headerGroupDeleteModule.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRestoreModule});
            this.headerGroupDeleteModule.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerGroupDeleteModule.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupDeleteModule.HeaderVisibleSecondary = false;
            this.headerGroupDeleteModule.Location = new System.Drawing.Point(0, 253);
            this.headerGroupDeleteModule.Name = "headerGroupDeleteModule";
            // 
            // headerGroupDeleteModule.Panel
            // 
            this.headerGroupDeleteModule.Panel.Controls.Add(this.txtDeleteModuleInfo);
            this.headerGroupDeleteModule.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupDeleteModule.Size = new System.Drawing.Size(361, 128);
            this.headerGroupDeleteModule.TabIndex = 3;
            this.headerGroupDeleteModule.ValuesPrimary.Image = null;
            // 
            // btnRestoreModule
            // 
            this.btnRestoreModule.Text = "&Restore";
            this.btnRestoreModule.UniqueName = "347E899EFA84427600A86D4837962924";
            this.btnRestoreModule.Click += new System.EventHandler(this.btnRestoreModule_Click);
            // 
            // txtDeleteModuleInfo
            // 
            this.txtDeleteModuleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeleteModuleInfo.Location = new System.Drawing.Point(5, 5);
            this.txtDeleteModuleInfo.Name = "txtDeleteModuleInfo";
            this.txtDeleteModuleInfo.ReadOnly = true;
            this.txtDeleteModuleInfo.ShowSelectionMargin = true;
            this.txtDeleteModuleInfo.Size = new System.Drawing.Size(349, 89);
            this.txtDeleteModuleInfo.TabIndex = 0;
            this.txtDeleteModuleInfo.Text = "kryptonRichTextBox1";
            // 
            // headerGroupForms
            // 
            this.headerGroupForms.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewForm,
            this.btnEditForm,
            this.btnDeleteForm});
            this.headerGroupForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupForms.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupForms.Location = new System.Drawing.Point(0, 0);
            this.headerGroupForms.Name = "headerGroupForms";
            // 
            // headerGroupForms.Panel
            // 
            this.headerGroupForms.Panel.Controls.Add(this.gridForms);
            this.headerGroupForms.Panel.Controls.Add(this.txtSearchForm);
            this.headerGroupForms.Size = new System.Drawing.Size(381, 253);
            this.headerGroupForms.TabIndex = 5;
            this.headerGroupForms.ValuesPrimary.Heading = "Features in Selected Module";
            this.headerGroupForms.ValuesPrimary.Image = null;
            // 
            // btnAddNewForm
            // 
            this.btnAddNewForm.Text = "&Add New";
            this.btnAddNewForm.UniqueName = "D1F31FEC8B2446CD948D558A31F54422";
            this.btnAddNewForm.Click += new System.EventHandler(this.btnAddNewForm_Click);
            // 
            // btnEditForm
            // 
            this.btnEditForm.Text = "&Edit";
            this.btnEditForm.UniqueName = "15D7627576B34537FAAB735C262660C9";
            this.btnEditForm.Click += new System.EventHandler(this.btnEditForm_Click);
            // 
            // btnDeleteForm
            // 
            this.btnDeleteForm.Text = "&Delete";
            this.btnDeleteForm.UniqueName = "6CA1CF28F7D144EAE09940A3A89BA948";
            this.btnDeleteForm.Click += new System.EventHandler(this.btnDeleteForm_Click);
            // 
            // gridForms
            // 
            this.gridForms.AllowUserToAddRows = false;
            this.gridForms.AllowUserToDeleteRows = false;
            this.gridForms.AllowUserToOrderColumns = true;
            this.gridForms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridForms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridForms.ColumnHeadersVisible = false;
            this.gridForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridForms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridForms.Location = new System.Drawing.Point(0, 28);
            this.gridForms.Name = "gridForms";
            this.gridForms.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridForms.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridForms.Size = new System.Drawing.Size(379, 175);
            this.gridForms.TabIndex = 9;
            this.gridForms.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridForms_DataBindingComplete);
            this.gridForms.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridForms_RowEnter);
            // 
            // txtSearchForm
            // 
            this.txtSearchForm.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchForm});
            this.txtSearchForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchForm.Location = new System.Drawing.Point(0, 0);
            this.txtSearchForm.Name = "txtSearchForm";
            this.txtSearchForm.Size = new System.Drawing.Size(379, 28);
            this.txtSearchForm.TabIndex = 8;
            // 
            // btnSearchForm
            // 
            this.btnSearchForm.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchForm.Text = "&Search";
            this.btnSearchForm.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            this.btnSearchForm.Click += new System.EventHandler(this.btnSearchForm_Click);
            // 
            // headerGroupDeleteForm
            // 
            this.headerGroupDeleteForm.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnRestoreForm});
            this.headerGroupDeleteForm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerGroupDeleteForm.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupDeleteForm.HeaderVisibleSecondary = false;
            this.headerGroupDeleteForm.Location = new System.Drawing.Point(0, 253);
            this.headerGroupDeleteForm.Name = "headerGroupDeleteForm";
            // 
            // headerGroupDeleteForm.Panel
            // 
            this.headerGroupDeleteForm.Panel.Controls.Add(this.txtDeleteFormInfo);
            this.headerGroupDeleteForm.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupDeleteForm.Size = new System.Drawing.Size(381, 128);
            this.headerGroupDeleteForm.TabIndex = 4;
            this.headerGroupDeleteForm.ValuesPrimary.Image = null;
            // 
            // btnRestoreForm
            // 
            this.btnRestoreForm.Text = "&Restore";
            this.btnRestoreForm.UniqueName = "347E899EFA84427600A86D4837962924";
            this.btnRestoreForm.Click += new System.EventHandler(this.btnRestoreForm_Click);
            // 
            // txtDeleteFormInfo
            // 
            this.txtDeleteFormInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeleteFormInfo.Location = new System.Drawing.Point(5, 5);
            this.txtDeleteFormInfo.Name = "txtDeleteFormInfo";
            this.txtDeleteFormInfo.ReadOnly = true;
            this.txtDeleteFormInfo.ShowSelectionMargin = true;
            this.txtDeleteFormInfo.Size = new System.Drawing.Size(369, 89);
            this.txtDeleteFormInfo.TabIndex = 0;
            this.txtDeleteFormInfo.Text = "kryptonRichTextBox1";
            // 
            // pageModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "pageModules";
            this.Size = new System.Drawing.Size(749, 412);
            this.Load += new System.EventHandler(this.pageModules_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupModule.Panel)).EndInit();
            this.headerGroupModule.Panel.ResumeLayout(false);
            this.headerGroupModule.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupModule)).EndInit();
            this.headerGroupModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteModule.Panel)).EndInit();
            this.headerGroupDeleteModule.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteModule)).EndInit();
            this.headerGroupDeleteModule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupForms.Panel)).EndInit();
            this.headerGroupForms.Panel.ResumeLayout(false);
            this.headerGroupForms.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupForms)).EndInit();
            this.headerGroupForms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridForms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteForm.Panel)).EndInit();
            this.headerGroupDeleteForm.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteForm)).EndInit();
            this.headerGroupDeleteForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDeleteModule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRestoreModule;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtDeleteModuleInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupModule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewModule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditModule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteModule;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridModules;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchModule;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchModule;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDeleteForm;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRestoreForm;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtDeleteFormInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupForms;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewForm;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditForm;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteForm;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridForms;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchForm;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchForm;
    }
}
