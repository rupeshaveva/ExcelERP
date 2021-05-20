namespace appExcelERP.Controls.HR
{
    partial class PageSalaryHeads
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
            this.btnAddNewSalaryHead = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditSalaryHead = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteSalaryHead = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridSalaryHead = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchSalaryHead = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchActiveUsers = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryHead)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewSalaryHead,
            this.btnEditSalaryHead,
            this.btnDeleteSalaryHead});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.gridSalaryHead);
            this.headerGroupMain.Panel.Controls.Add(this.txtSearchSalaryHead);
            this.headerGroupMain.Size = new System.Drawing.Size(552, 453);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Salary Head ";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnAddNewSalaryHead
            // 
            this.btnAddNewSalaryHead.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddNewSalaryHead.Text = "&Add New";
            this.btnAddNewSalaryHead.UniqueName = "74BFF267A8D942437498373F0943E985";
            this.btnAddNewSalaryHead.Click += new System.EventHandler(this.btnAddNewSalaryHead_Click);
            // 
            // btnEditSalaryHead
            // 
            this.btnEditSalaryHead.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditSalaryHead.Text = "&Edit";
            this.btnEditSalaryHead.UniqueName = "7C6705CC4FEB485AAE823D5B2E046D49";
            this.btnEditSalaryHead.Click += new System.EventHandler(this.btnEditSalaryHead_Click);
            // 
            // btnDeleteSalaryHead
            // 
            this.btnDeleteSalaryHead.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteSalaryHead.Text = "&Delete";
            this.btnDeleteSalaryHead.UniqueName = "804C0FC09B0B466A4DAEECC43527696C";
            this.btnDeleteSalaryHead.Click += new System.EventHandler(this.btnDeleteSalaryHead_Click);
            // 
            // gridSalaryHead
            // 
            this.gridSalaryHead.AllowUserToAddRows = false;
            this.gridSalaryHead.AllowUserToDeleteRows = false;
            this.gridSalaryHead.AllowUserToOrderColumns = true;
            this.gridSalaryHead.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSalaryHead.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSalaryHead.ColumnHeadersHeight = 28;
            this.gridSalaryHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSalaryHead.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSalaryHead.Location = new System.Drawing.Point(0, 28);
            this.gridSalaryHead.Margin = new System.Windows.Forms.Padding(2);
            this.gridSalaryHead.MultiSelect = false;
            this.gridSalaryHead.Name = "gridSalaryHead";
            this.gridSalaryHead.ReadOnly = true;
            this.gridSalaryHead.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSalaryHead.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSalaryHead.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSalaryHead.Size = new System.Drawing.Size(550, 372);
            this.gridSalaryHead.TabIndex = 13;
            this.gridSalaryHead.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalaryHead_RowEnter);
            // 
            // txtSearchSalaryHead
            // 
            this.txtSearchSalaryHead.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchActiveUsers});
            this.txtSearchSalaryHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchSalaryHead.Location = new System.Drawing.Point(0, 0);
            this.txtSearchSalaryHead.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchSalaryHead.Name = "txtSearchSalaryHead";
            this.txtSearchSalaryHead.Size = new System.Drawing.Size(550, 28);
            this.txtSearchSalaryHead.TabIndex = 12;
            // 
            // btnSearchActiveUsers
            // 
            this.btnSearchActiveUsers.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchActiveUsers.Text = "&Search";
            this.btnSearchActiveUsers.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            this.btnSearchActiveUsers.Click += new System.EventHandler(this.btnSearchActiveUsers_Click);
            // 
            // PageSalaryHeads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PageSalaryHeads";
            this.Size = new System.Drawing.Size(552, 453);
            this.Load += new System.EventHandler(this.PageSalaryHeads_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            this.headerGroupMain.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSalaryHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewSalaryHead;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditSalaryHead;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteSalaryHead;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridSalaryHead;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchSalaryHead;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchActiveUsers;
    }
}
