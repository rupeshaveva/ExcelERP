namespace appExcelERP.Controls.HR
{
    partial class PageCTCConfiguration
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
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupDesignations = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridDesignations = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchDesignation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tabEmploymentCTC = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPagePermanentEmployee = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageProbationEmployee = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.btnsearchDesignation = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDesignations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDesignations.Panel)).BeginInit();
            this.headerGroupDesignations.Panel.SuspendLayout();
            this.headerGroupDesignations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesignations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEmploymentCTC)).BeginInit();
            this.tabEmploymentCTC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPagePermanentEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProbationEmployee)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupDesignations);
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabEmploymentCTC);
            this.splitContainerMain.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(792, 467);
            this.splitContainerMain.SplitterDistance = 264;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupDesignations
            // 
            this.headerGroupDesignations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupDesignations.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDesignations.Location = new System.Drawing.Point(5, 5);
            this.headerGroupDesignations.Name = "headerGroupDesignations";
            // 
            // headerGroupDesignations.Panel
            // 
            this.headerGroupDesignations.Panel.Controls.Add(this.gridDesignations);
            this.headerGroupDesignations.Panel.Controls.Add(this.txtSearchDesignation);
            this.headerGroupDesignations.Size = new System.Drawing.Size(254, 457);
            this.headerGroupDesignations.TabIndex = 0;
            this.headerGroupDesignations.ValuesPrimary.Heading = "Designations";
            this.headerGroupDesignations.ValuesPrimary.Image = null;
            // 
            // gridDesignations
            // 
            this.gridDesignations.AllowUserToAddRows = false;
            this.gridDesignations.AllowUserToDeleteRows = false;
            this.gridDesignations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDesignations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridDesignations.ColumnHeadersHeight = 28;
            this.gridDesignations.ColumnHeadersVisible = false;
            this.gridDesignations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDesignations.Location = new System.Drawing.Point(0, 28);
            this.gridDesignations.Margin = new System.Windows.Forms.Padding(2);
            this.gridDesignations.Name = "gridDesignations";
            this.gridDesignations.ReadOnly = true;
            this.gridDesignations.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDesignations.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDesignations.RowTemplate.Height = 24;
            this.gridDesignations.Size = new System.Drawing.Size(252, 384);
            this.gridDesignations.TabIndex = 4;
            this.gridDesignations.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesignations_RowEnter);
            // 
            // txtSearchDesignation
            // 
            this.txtSearchDesignation.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnsearchDesignation});
            this.txtSearchDesignation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchDesignation.Location = new System.Drawing.Point(0, 0);
            this.txtSearchDesignation.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchDesignation.Name = "txtSearchDesignation";
            this.txtSearchDesignation.Size = new System.Drawing.Size(252, 28);
            this.txtSearchDesignation.TabIndex = 3;
             // 
            // tabEmploymentCTC
            // 
            this.tabEmploymentCTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEmploymentCTC.Location = new System.Drawing.Point(5, 5);
            this.tabEmploymentCTC.Name = "tabEmploymentCTC";
            this.tabEmploymentCTC.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPagePermanentEmployee,
            this.tabPageProbationEmployee});
            this.tabEmploymentCTC.SelectedIndex = 0;
            this.tabEmploymentCTC.Size = new System.Drawing.Size(511, 457);
            this.tabEmploymentCTC.TabIndex = 0;
            this.tabEmploymentCTC.Text = "kryptonNavigator1";
            // 
            // tabPagePermanentEmployee
            // 
            this.tabPagePermanentEmployee.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPagePermanentEmployee.Flags = 65534;
            this.tabPagePermanentEmployee.LastVisibleSet = true;
            this.tabPagePermanentEmployee.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPagePermanentEmployee.Name = "tabPagePermanentEmployee";
            this.tabPagePermanentEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePermanentEmployee.Size = new System.Drawing.Size(509, 430);
            this.tabPagePermanentEmployee.Text = "Permanent Employees";
            this.tabPagePermanentEmployee.ToolTipTitle = "Page ToolTip";
            this.tabPagePermanentEmployee.UniqueName = "71ED6C44AD904C76DEBD8796145864ED";
            // 
            // tabPageProbationEmployee
            // 
            this.tabPageProbationEmployee.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageProbationEmployee.Flags = 65534;
            this.tabPageProbationEmployee.LastVisibleSet = true;
            this.tabPageProbationEmployee.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageProbationEmployee.Name = "tabPageProbationEmployee";
            this.tabPageProbationEmployee.Padding = new System.Windows.Forms.Padding(5);
            this.tabPageProbationEmployee.Size = new System.Drawing.Size(509, 430);
            this.tabPageProbationEmployee.Text = "Employees on Probation";
            this.tabPageProbationEmployee.ToolTipTitle = "Page ToolTip";
            this.tabPageProbationEmployee.UniqueName = "5A8936875B1F4CD1C5B01BC648E49179";
            // 
            // btnsearchDesignation
            // 
            this.btnsearchDesignation.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnsearchDesignation.Text = "&Search";
            this.btnsearchDesignation.UniqueName = "0C3CE34069DD497469BBB287DF3F1167";
            this.btnsearchDesignation.Click += new System.EventHandler(this.btnsearchDesignation_Click);
            // 
            // PageCTCConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "PageCTCConfiguration";
            this.Size = new System.Drawing.Size(792, 467);
            this.Load += new System.EventHandler(this.PageCTCConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDesignations.Panel)).EndInit();
            this.headerGroupDesignations.Panel.ResumeLayout(false);
            this.headerGroupDesignations.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDesignations)).EndInit();
            this.headerGroupDesignations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDesignations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabEmploymentCTC)).EndInit();
            this.tabEmploymentCTC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPagePermanentEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageProbationEmployee)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDesignations;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridDesignations;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchDesignation;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabEmploymentCTC;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPagePermanentEmployee;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageProbationEmployee;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnsearchDesignation;
    }
}
