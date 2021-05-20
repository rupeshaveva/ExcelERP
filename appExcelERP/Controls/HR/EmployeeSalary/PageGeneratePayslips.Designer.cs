namespace appExcelERP.Controls.HR.EmployeeSalary
{
    partial class PageGeneratePayslips
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
            this.btnGeneratePayslips = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupEmployees = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewUser = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditUser = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteUser = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridActiveEmployees = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchActiveEmployees = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearchActiveUsers = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.panelHeader = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.dtSalaryMonth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees.Panel)).BeginInit();
            this.headerGroupEmployees.Panel.SuspendLayout();
            this.headerGroupEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridActiveEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnGeneratePayslips});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.splitContainerMain);
            this.headerGroupMain.Panel.Controls.Add(this.panelHeader);
            this.headerGroupMain.Size = new System.Drawing.Size(763, 407);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Generate Employees Salary";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnGeneratePayslips
            // 
            this.btnGeneratePayslips.Image = global::appExcelERP.Properties.Resources.CSEventReceiverTable_16x;
            this.btnGeneratePayslips.Text = "&Generate Payslips";
            this.btnGeneratePayslips.UniqueName = "56A3691D0E8D4424DFB1836D1B0A7E82";
            this.btnGeneratePayslips.Click += new System.EventHandler(this.btnGeneratePayslips_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 35);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupEmployees);
            this.splitContainerMain.Size = new System.Drawing.Size(761, 322);
            this.splitContainerMain.SplitterDistance = 253;
            this.splitContainerMain.TabIndex = 1;
            // 
            // headerGroupEmployees
            // 
            this.headerGroupEmployees.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewUser,
            this.btnEditUser,
            this.btnDeleteUser});
            this.headerGroupEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupEmployees.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupEmployees.Location = new System.Drawing.Point(0, 0);
            this.headerGroupEmployees.Name = "headerGroupEmployees";
            // 
            // headerGroupEmployees.Panel
            // 
            this.headerGroupEmployees.Panel.Controls.Add(this.gridActiveEmployees);
            this.headerGroupEmployees.Panel.Controls.Add(this.txtSearchActiveEmployees);
            this.headerGroupEmployees.Panel.Padding = new System.Windows.Forms.Padding(3);
            this.headerGroupEmployees.Size = new System.Drawing.Size(253, 322);
            this.headerGroupEmployees.TabIndex = 10;
            this.headerGroupEmployees.ValuesPrimary.Heading = "Employees";
            this.headerGroupEmployees.ValuesPrimary.Image = null;
            this.headerGroupEmployees.ValuesSecondary.Description = ".";
            this.headerGroupEmployees.ValuesSecondary.Heading = "";
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Text = "&Add New";
            this.btnAddNewUser.UniqueName = "D1F31FEC8B2446CD948D558A31F54422";
            this.btnAddNewUser.Visible = false;
            // 
            // btnEditUser
            // 
            this.btnEditUser.Text = "&Edit";
            this.btnEditUser.UniqueName = "15D7627576B34537FAAB735C262660C9";
            this.btnEditUser.Visible = false;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Text = "&Delete";
            this.btnDeleteUser.UniqueName = "6CA1CF28F7D144EAE09940A3A89BA948";
            this.btnDeleteUser.Visible = false;
            // 
            // gridActiveEmployees
            // 
            this.gridActiveEmployees.AllowUserToAddRows = false;
            this.gridActiveEmployees.AllowUserToDeleteRows = false;
            this.gridActiveEmployees.AllowUserToOrderColumns = true;
            this.gridActiveEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridActiveEmployees.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridActiveEmployees.ColumnHeadersHeight = 28;
            this.gridActiveEmployees.ColumnHeadersVisible = false;
            this.gridActiveEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridActiveEmployees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridActiveEmployees.Location = new System.Drawing.Point(3, 31);
            this.gridActiveEmployees.MultiSelect = false;
            this.gridActiveEmployees.Name = "gridActiveEmployees";
            this.gridActiveEmployees.ReadOnly = true;
            this.gridActiveEmployees.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridActiveEmployees.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridActiveEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridActiveEmployees.Size = new System.Drawing.Size(245, 243);
            this.gridActiveEmployees.TabIndex = 11;
            this.gridActiveEmployees.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridActiveEmployees_RowEnter);
            // 
            // txtSearchActiveEmployees
            // 
            this.txtSearchActiveEmployees.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearchActiveUsers});
            this.txtSearchActiveEmployees.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchActiveEmployees.Location = new System.Drawing.Point(3, 3);
            this.txtSearchActiveEmployees.Name = "txtSearchActiveEmployees";
            this.txtSearchActiveEmployees.Size = new System.Drawing.Size(245, 28);
            this.txtSearchActiveEmployees.TabIndex = 10;
           // 
            // btnSearchActiveUsers
            // 
            this.btnSearchActiveUsers.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.NavigatorOverflow;
            this.btnSearchActiveUsers.Text = "&Search";
            this.btnSearchActiveUsers.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            this.btnSearchActiveUsers.Click += new System.EventHandler(this.btnSearchActiveUsers_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.dtSalaryMonth);
            this.panelHeader.Controls.Add(this.label17);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(761, 35);
            this.panelHeader.TabIndex = 0;
            // 
            // dtSalaryMonth
            // 
            this.dtSalaryMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtSalaryMonth.CustomFormat = "MMMM yyyy";
            this.dtSalaryMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalaryMonth.Location = new System.Drawing.Point(642, 9);
            this.dtSalaryMonth.Name = "dtSalaryMonth";
            this.dtSalaryMonth.Size = new System.Drawing.Size(105, 21);
            this.dtSalaryMonth.TabIndex = 139;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(459, 9);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(176, 20);
            this.label17.TabIndex = 138;
            this.label17.Values.Text = "Generate Salary for the &Month";
            // 
            // PageGeneratePayslips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "PageGeneratePayslips";
            this.Size = new System.Drawing.Size(763, 407);
            this.Load += new System.EventHandler(this.PageGeneratePayslips_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees.Panel)).EndInit();
            this.headerGroupEmployees.Panel.ResumeLayout(false);
            this.headerGroupEmployees.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployees)).EndInit();
            this.headerGroupEmployees.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridActiveEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelHeader;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnGeneratePayslips;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtSalaryMonth;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupEmployees;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewUser;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditUser;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteUser;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridActiveEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchActiveEmployees;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearchActiveUsers;
    }
}
