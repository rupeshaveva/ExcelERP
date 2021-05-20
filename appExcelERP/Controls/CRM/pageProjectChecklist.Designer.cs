namespace appExcelERP.Controls.CRM
{
    partial class pageProjectChecklist
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
            this.headerGroupProjectyCheckPoint = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonHeaderGroup3 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewCheckList = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditCheckLIst = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteCheckList = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridCheckList = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupChecklistPoint = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewCheckPoint = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditCheckPoint = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridCheckPoints = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProjectyCheckPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProjectyCheckPoint.Panel)).BeginInit();
            this.headerGroupProjectyCheckPoint.Panel.SuspendLayout();
            this.headerGroupProjectyCheckPoint.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3.Panel)).BeginInit();
            this.kryptonHeaderGroup3.Panel.SuspendLayout();
            this.kryptonHeaderGroup3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChecklistPoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChecklistPoint.Panel)).BeginInit();
            this.headerGroupChecklistPoint.Panel.SuspendLayout();
            this.headerGroupChecklistPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupProjectyCheckPoint
            // 
            this.headerGroupProjectyCheckPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupProjectyCheckPoint.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupProjectyCheckPoint.Location = new System.Drawing.Point(0, 0);
            this.headerGroupProjectyCheckPoint.Name = "headerGroupProjectyCheckPoint";
            // 
            // headerGroupProjectyCheckPoint.Panel
            // 
            this.headerGroupProjectyCheckPoint.Panel.Controls.Add(this.tableLayoutPanel1);
            this.headerGroupProjectyCheckPoint.Size = new System.Drawing.Size(679, 448);
            this.headerGroupProjectyCheckPoint.TabIndex = 0;
            this.headerGroupProjectyCheckPoint.ValuesPrimary.Heading = "Manage Project Checklist (Sales Notes)";
            this.headerGroupProjectyCheckPoint.ValuesPrimary.Image = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonHeaderGroup3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerGroupChecklistPoint, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(677, 403);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // kryptonHeaderGroup3
            // 
            this.kryptonHeaderGroup3.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewCheckList,
            this.btnEditCheckLIst,
            this.btnDeleteCheckList});
            this.kryptonHeaderGroup3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup3.Location = new System.Drawing.Point(341, 3);
            this.kryptonHeaderGroup3.Name = "kryptonHeaderGroup3";
            // 
            // kryptonHeaderGroup3.Panel
            // 
            this.kryptonHeaderGroup3.Panel.Controls.Add(this.gridCheckList);
            this.kryptonHeaderGroup3.Size = new System.Drawing.Size(333, 397);
            this.kryptonHeaderGroup3.TabIndex = 1;
            this.kryptonHeaderGroup3.ValuesPrimary.Heading = "Check list(s)";
            this.kryptonHeaderGroup3.ValuesPrimary.Image = null;
            // 
            // btnAddNewCheckList
            // 
            this.btnAddNewCheckList.Text = "&Add New";
            this.btnAddNewCheckList.UniqueName = "3BC3CA038F2F4D792C85AF44D56D6DD3";
            this.btnAddNewCheckList.Click += new System.EventHandler(this.btnAddNewCheckList_Click);
            // 
            // btnEditCheckLIst
            // 
            this.btnEditCheckLIst.Text = "&Edit";
            this.btnEditCheckLIst.UniqueName = "D4217DBD40654D5EE881A6F01913A382";
            this.btnEditCheckLIst.Click += new System.EventHandler(this.btnEditCheckLIst_Click);
            // 
            // btnDeleteCheckList
            // 
            this.btnDeleteCheckList.Text = "&Delete";
            this.btnDeleteCheckList.UniqueName = "D280873C46434A5EA7A8E9F8C44B0427";
            this.btnDeleteCheckList.Click += new System.EventHandler(this.btnDeleteCheckList_Click);
            // 
            // gridCheckList
            // 
            this.gridCheckList.AllowUserToAddRows = false;
            this.gridCheckList.AllowUserToDeleteRows = false;
            this.gridCheckList.AllowUserToOrderColumns = true;
            this.gridCheckList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCheckList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCheckList.ColumnHeadersHeight = 28;
            this.gridCheckList.ColumnHeadersVisible = false;
            this.gridCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCheckList.Location = new System.Drawing.Point(0, 0);
            this.gridCheckList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridCheckList.Name = "gridCheckList";
            this.gridCheckList.ReadOnly = true;
            this.gridCheckList.RowHeadersVisible = false;
            this.gridCheckList.RowTemplate.Height = 24;
            this.gridCheckList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCheckList.Size = new System.Drawing.Size(331, 344);
            this.gridCheckList.TabIndex = 3;
            this.gridCheckList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCheckList_RowEnter);
            // 
            // headerGroupChecklistPoint
            // 
            this.headerGroupChecklistPoint.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewCheckPoint,
            this.btnEditCheckPoint});
            this.headerGroupChecklistPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupChecklistPoint.Location = new System.Drawing.Point(3, 3);
            this.headerGroupChecklistPoint.Name = "headerGroupChecklistPoint";
            // 
            // headerGroupChecklistPoint.Panel
            // 
            this.headerGroupChecklistPoint.Panel.Controls.Add(this.gridCheckPoints);
            this.headerGroupChecklistPoint.Size = new System.Drawing.Size(332, 397);
            this.headerGroupChecklistPoint.TabIndex = 0;
            this.headerGroupChecklistPoint.ValuesPrimary.Heading = "Check Points";
            this.headerGroupChecklistPoint.ValuesPrimary.Image = null;
            // 
            // btnAddNewCheckPoint
            // 
            this.btnAddNewCheckPoint.Text = "&Add New";
            this.btnAddNewCheckPoint.UniqueName = "0FDCBA092F324A5068BE50A0B16154AF";
            this.btnAddNewCheckPoint.Click += new System.EventHandler(this.btnAddNewCheckPoint_Click);
            // 
            // btnEditCheckPoint
            // 
            this.btnEditCheckPoint.Text = "&Edit";
            this.btnEditCheckPoint.UniqueName = "9827BA02016943DE289D0BF4C08DE37C";
            this.btnEditCheckPoint.Click += new System.EventHandler(this.btnEditCheckPoint_Click);
            // 
            // gridCheckPoints
            // 
            this.gridCheckPoints.AllowUserToAddRows = false;
            this.gridCheckPoints.AllowUserToDeleteRows = false;
            this.gridCheckPoints.AllowUserToOrderColumns = true;
            this.gridCheckPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCheckPoints.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCheckPoints.ColumnHeadersHeight = 28;
            this.gridCheckPoints.ColumnHeadersVisible = false;
            this.gridCheckPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCheckPoints.Location = new System.Drawing.Point(0, 0);
            this.gridCheckPoints.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridCheckPoints.Name = "gridCheckPoints";
            this.gridCheckPoints.ReadOnly = true;
            this.gridCheckPoints.RowHeadersVisible = false;
            this.gridCheckPoints.RowTemplate.Height = 24;
            this.gridCheckPoints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCheckPoints.Size = new System.Drawing.Size(330, 344);
            this.gridCheckPoints.TabIndex = 2;
            this.gridCheckPoints.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCheckPoints_RowEnter);
            // 
            // pageProjectChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupProjectyCheckPoint);
            this.Name = "pageProjectChecklist";
            this.Size = new System.Drawing.Size(679, 448);
            this.Load += new System.EventHandler(this.pageProjectChecklist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProjectyCheckPoint.Panel)).EndInit();
            this.headerGroupProjectyCheckPoint.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupProjectyCheckPoint)).EndInit();
            this.headerGroupProjectyCheckPoint.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3.Panel)).EndInit();
            this.kryptonHeaderGroup3.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup3)).EndInit();
            this.kryptonHeaderGroup3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChecklistPoint.Panel)).EndInit();
            this.headerGroupChecklistPoint.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupChecklistPoint)).EndInit();
            this.headerGroupChecklistPoint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCheckPoints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupProjectyCheckPoint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup3;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupChecklistPoint;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewCheckList;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditCheckLIst;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewCheckPoint;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditCheckPoint;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCheckPoints;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteCheckList;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCheckList;
    }
}
