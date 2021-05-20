namespace appExcelERP.Forms
{
    partial class frmInventoryLevel
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewSpecification = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditSpecification = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteSpecification = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridLevels = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupLevelDetails = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewValue = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditValue = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteValue = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridLevelDetails = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLevels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLevelDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLevelDetails.Panel)).BeginInit();
            this.headerGroupLevelDetails.Panel.SuspendLayout();
            this.headerGroupLevelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLevelDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(3, 3);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.tableLayoutPanel1);
            this.headerGroupMain.Size = new System.Drawing.Size(622, 372);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Category Name";
            this.headerGroupMain.ValuesPrimary.Image = null;
            this.headerGroupMain.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Text = "&Save";
            this.btnSave.UniqueName = "44C0178F8A684A6EF6A8C07F6396B563";
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "34982DA25AEE41EC568AC0A7BEF9C4DC";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonHeaderGroup2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.headerGroupLevelDetails, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 340);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewSpecification,
            this.btnEditSpecification,
            this.btnDeleteSpecification});
            this.kryptonHeaderGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(3, 3);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.gridLevels);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(304, 334);
            this.kryptonHeaderGroup2.TabIndex = 0;
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Specifications";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = null;
            // 
            // btnAddNewSpecification
            // 
            this.btnAddNewSpecification.Text = "&Add New";
            this.btnAddNewSpecification.UniqueName = "1A4A3D1801D64A51EDA5B8547E6C0900";
            this.btnAddNewSpecification.Click += new System.EventHandler(this.btnAddNewSpecification_Click);
            // 
            // btnEditSpecification
            // 
            this.btnEditSpecification.Text = "&Edit";
            this.btnEditSpecification.UniqueName = "5A5E8E7BF87C4EE8E8875FEC9DA0A821";
            this.btnEditSpecification.Click += new System.EventHandler(this.btnEditSpecification_Click);
            // 
            // btnDeleteSpecification
            // 
            this.btnDeleteSpecification.Text = "&Delete";
            this.btnDeleteSpecification.UniqueName = "8E6B7E459241459A8F90F7351D9C59E8";
            this.btnDeleteSpecification.Click += new System.EventHandler(this.btnDeleteSpecification_Click);
            // 
            // gridLevels
            // 
            this.gridLevels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLevels.Location = new System.Drawing.Point(0, 0);
            this.gridLevels.Name = "gridLevels";
            this.gridLevels.Size = new System.Drawing.Size(302, 284);
            this.gridLevels.TabIndex = 0;
            this.gridLevels.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLevels_RowEnter);
            // 
            // headerGroupLevelDetails
            // 
            this.headerGroupLevelDetails.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewValue,
            this.btnEditValue,
            this.btnDeleteValue});
            this.headerGroupLevelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupLevelDetails.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupLevelDetails.Location = new System.Drawing.Point(313, 3);
            this.headerGroupLevelDetails.Name = "headerGroupLevelDetails";
            // 
            // headerGroupLevelDetails.Panel
            // 
            this.headerGroupLevelDetails.Panel.Controls.Add(this.gridLevelDetails);
            this.headerGroupLevelDetails.Size = new System.Drawing.Size(304, 334);
            this.headerGroupLevelDetails.TabIndex = 1;
            this.headerGroupLevelDetails.ValuesPrimary.Heading = "Possible Values";
            this.headerGroupLevelDetails.ValuesPrimary.Image = null;
            this.headerGroupLevelDetails.ValuesSecondary.Heading = "";
            // 
            // btnAddNewValue
            // 
            this.btnAddNewValue.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnAddNewValue.Text = "&Add New";
            this.btnAddNewValue.UniqueName = "77C2C9FB56524BFC6196665AB83189D4";
            this.btnAddNewValue.Click += new System.EventHandler(this.btnAddNewValue_Click);
            // 
            // btnEditValue
            // 
            this.btnEditValue.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnEditValue.Text = "&Edit";
            this.btnEditValue.UniqueName = "CA26443EA2EC4A418F9A962363705B34";
            this.btnEditValue.Click += new System.EventHandler(this.btnEditValue_Click);
            // 
            // btnDeleteValue
            // 
            this.btnDeleteValue.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnDeleteValue.Text = "&Delete";
            this.btnDeleteValue.UniqueName = "D9A155A46E574CA2BC9FDB04129888F9";
            this.btnDeleteValue.Click += new System.EventHandler(this.btnDeleteValue_Click);
            // 
            // gridLevelDetails
            // 
            this.gridLevelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLevelDetails.Location = new System.Drawing.Point(0, 0);
            this.gridLevelDetails.Name = "gridLevelDetails";
            this.gridLevelDetails.Size = new System.Drawing.Size(302, 283);
            this.gridLevelDetails.TabIndex = 0;
            this.gridLevelDetails.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLevelDetails_RowEnter);
            // 
            // frmInventoryLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 378);
            this.Controls.Add(this.headerGroupMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInventoryLevel";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Inventory Level";
            this.Load += new System.EventHandler(this.frmInventoryLevel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLevels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLevelDetails.Panel)).EndInit();
            this.headerGroupLevelDetails.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLevelDetails)).EndInit();
            this.headerGroupLevelDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLevelDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewSpecification;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditSpecification;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupLevelDetails;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewValue;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditValue;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteSpecification;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteValue;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLevels;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLevelDetails;
    }
}