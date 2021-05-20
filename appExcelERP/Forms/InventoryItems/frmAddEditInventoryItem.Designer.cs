namespace appExcelERP.Forms
{
    partial class frmAddEditInventoryItem
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
            this.components = new System.ComponentModel.Container();
            this.txtItemCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboItemType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewItemType = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.txtItemID = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboUOM = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboItemCategory = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewCatogory = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblItemName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtItemName = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtHSNCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkIsAssembly = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.gridItemSpecifications = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.txtPartNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboPurchaseUOM = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtSpecificName = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateSpecificationMater = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnValidate = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemSpecifications)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPurchaseUOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtItemCode
            // 
            this.txtItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtItemCode.Location = new System.Drawing.Point(216, 87);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(238, 20);
            this.txtItemCode.TabIndex = 7;
            this.txtItemCode.TabStop = false;
            // 
            // cboItemType
            // 
            this.cboItemType.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewItemType});
            this.cboItemType.DropDownWidth = 297;
            this.cboItemType.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.Location = new System.Drawing.Point(110, 31);
            this.cboItemType.Margin = new System.Windows.Forms.Padding(4);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.Size = new System.Drawing.Size(345, 26);
            this.cboItemType.TabIndex = 2;
            this.cboItemType.SelectionChangeCommitted += new System.EventHandler(this.cboItemType_SelectionChangeCommitted);
            this.cboItemType.Validating += new System.ComponentModel.CancelEventHandler(this.cboItemType_Validating);
            // 
            // btnAddNewItemType
            // 
            this.btnAddNewItemType.Text = "Add New";
            this.btnAddNewItemType.UniqueName = "64A67C32F75C40A5EBB454A23F234D48";
            this.btnAddNewItemType.Click += new System.EventHandler(this.btnAddNewItemType_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtItemID.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(110, 87);
            this.txtItemID.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(99, 20);
            this.txtItemID.TabIndex = 6;
            this.txtItemID.TabStop = false;
            // 
            // cboUOM
            // 
            this.cboUOM.DropDownWidth = 296;
            this.cboUOM.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUOM.FormattingEnabled = true;
            this.cboUOM.Location = new System.Drawing.Point(110, 136);
            this.cboUOM.Margin = new System.Windows.Forms.Padding(4);
            this.cboUOM.Name = "cboUOM";
            this.cboUOM.Size = new System.Drawing.Size(89, 21);
            this.cboUOM.TabIndex = 11;
            this.cboUOM.Validating += new System.ComponentModel.CancelEventHandler(this.cboUOM_Validating);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(13, 34);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 20);
            this.label16.TabIndex = 1;
            this.label16.Values.Text = "Item &Type";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 5;
            this.label1.Values.Text = "ID-CODE";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(13, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 10;
            this.label2.Values.Text = "Base  &UOM";
            // 
            // cboItemCategory
            // 
            this.cboItemCategory.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewCatogory});
            this.cboItemCategory.DropDownWidth = 297;
            this.cboItemCategory.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemCategory.FormattingEnabled = true;
            this.cboItemCategory.Location = new System.Drawing.Point(110, 58);
            this.cboItemCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cboItemCategory.Name = "cboItemCategory";
            this.cboItemCategory.Size = new System.Drawing.Size(344, 26);
            this.cboItemCategory.TabIndex = 4;
            this.cboItemCategory.SelectionChangeCommitted += new System.EventHandler(this.cboItemCategory_SelectionChangeCommitted);
            this.cboItemCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cboItemCategory_Validating);
            // 
            // btnAddNewCatogory
            // 
            this.btnAddNewCatogory.Text = "Add New";
            this.btnAddNewCatogory.UniqueName = "F7349470218B47E2ADA8CE9250F5A0BB";
            this.btnAddNewCatogory.Click += new System.EventHandler(this.btnAddNewCatogory_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 61);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(88, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Item &Category";
            // 
            // lblItemName
            // 
            this.lblItemName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.ForeColor = System.Drawing.Color.Black;
            this.lblItemName.Location = new System.Drawing.Point(13, 192);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(71, 20);
            this.lblItemName.TabIndex = 16;
            this.lblItemName.Values.Text = "Item &Name";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(13, 215);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(441, 66);
            this.txtItemName.TabIndex = 17;
            this.txtItemName.Text = "";
            this.txtItemName.Validating += new System.ComponentModel.CancelEventHandler(this.txtItemName_Validating);
            // 
            // txtHSNCode
            // 
            this.txtHSNCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtHSNCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtHSNCode.Location = new System.Drawing.Point(110, 111);
            this.txtHSNCode.MaxLength = 10;
            this.txtHSNCode.Name = "txtHSNCode";
            this.txtHSNCode.Size = new System.Drawing.Size(344, 20);
            this.txtHSNCode.TabIndex = 9;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 111);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(70, 20);
            this.kryptonLabel3.TabIndex = 8;
            this.kryptonLabel3.Values.Text = "&HSN CODE";
            // 
            // chkIsAssembly
            // 
            this.chkIsAssembly.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.chkIsAssembly.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsAssembly.Location = new System.Drawing.Point(315, 6);
            this.chkIsAssembly.Margin = new System.Windows.Forms.Padding(1);
            this.chkIsAssembly.Name = "chkIsAssembly";
            this.chkIsAssembly.Size = new System.Drawing.Size(139, 20);
            this.chkIsAssembly.TabIndex = 0;
            this.chkIsAssembly.Values.Text = "Is an Assembly Item";
            this.chkIsAssembly.CheckedChanged += new System.EventHandler(this.chkIsAssembly_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(135, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(29, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridItemSpecifications
            // 
            this.gridItemSpecifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridItemSpecifications.Location = new System.Drawing.Point(0, 0);
            this.gridItemSpecifications.Name = "gridItemSpecifications";
            this.gridItemSpecifications.Size = new System.Drawing.Size(317, 376);
            this.gridItemSpecifications.TabIndex = 59;
            this.gridItemSpecifications.VirtualMode = true;
            this.gridItemSpecifications.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItemSpecifications_CellClick);
            this.gridItemSpecifications.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridItemSpecifications_EditingControlShowing);
            this.gridItemSpecifications.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridItemSpecifications_RowLeave);
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(12, 12);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtPartNumber);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cboPurchaseUOM);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtSpecificName);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label16);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cboUOM);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.chkIsAssembly);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtItemID);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtHSNCode);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cboItemType);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtItemCode);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtItemName);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.lblItemName);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.cboItemCategory);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(469, 426);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartNumber.Location = new System.Drawing.Point(109, 164);
            this.txtPartNumber.MaxLength = 150;
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.Size = new System.Drawing.Size(344, 20);
            this.txtPartNumber.TabIndex = 15;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 164);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(92, 20);
            this.kryptonLabel2.TabIndex = 14;
            this.kryptonLabel2.Values.Text = "PART &NUMBER";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.kryptonLabel5.Location = new System.Drawing.Point(264, 137);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(92, 20);
            this.kryptonLabel5.TabIndex = 12;
            this.kryptonLabel5.Values.Text = "Purchase &UOM";
            // 
            // cboPurchaseUOM
            // 
            this.cboPurchaseUOM.DropDownWidth = 296;
            this.cboPurchaseUOM.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPurchaseUOM.FormattingEnabled = true;
            this.cboPurchaseUOM.Location = new System.Drawing.Point(364, 136);
            this.cboPurchaseUOM.Margin = new System.Windows.Forms.Padding(4);
            this.cboPurchaseUOM.Name = "cboPurchaseUOM";
            this.cboPurchaseUOM.Size = new System.Drawing.Size(89, 21);
            this.cboPurchaseUOM.TabIndex = 13;
            this.cboPurchaseUOM.Validating += new System.ComponentModel.CancelEventHandler(this.cboPurchaseUOM_Validating);
            // 
            // txtSpecificName
            // 
            this.txtSpecificName.Location = new System.Drawing.Point(13, 307);
            this.txtSpecificName.Name = "txtSpecificName";
            this.txtSpecificName.ReadOnly = true;
            this.txtSpecificName.Size = new System.Drawing.Size(441, 85);
            this.txtSpecificName.TabIndex = 19;
            this.txtSpecificName.TabStop = false;
            this.txtSpecificName.Text = "";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 284);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel4.TabIndex = 18;
            this.kryptonLabel4.Values.Text = "Specifications";
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateSpecificationMater,
            this.btnValidate});
            this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup2.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(489, 13);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.gridItemSpecifications);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(319, 405);
            this.kryptonHeaderGroup2.TabIndex = 1;
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Specifications";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup2.ValuesSecondary.Heading = "";
            // 
            // btnUpdateSpecificationMater
            // 
            this.btnUpdateSpecificationMater.Text = "&Update";
            this.btnUpdateSpecificationMater.UniqueName = "341D09A6035840670E948152E09E92EB";
            this.btnUpdateSpecificationMater.Click += new System.EventHandler(this.btnUpdateSpecificationMater_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Text = "Check Duplicacy";
            this.btnValidate.UniqueName = "80B9B8D466F34FE3A892962AACBE5999";
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(488, 424);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(319, 14);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 25;
            // 
            // frmAddEditInventoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(816, 488);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.kryptonHeaderGroup2);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditInventoryItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Inventory Item";
            this.Load += new System.EventHandler(this.frmAddEditInventoryItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboItemCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemSpecifications)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboPurchaseUOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtItemCode;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboItemType;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtItemID;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboUOM;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label16;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewItemType;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboItemCategory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewCatogory;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblItemName;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtItemName;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtHSNCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsAssembly;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridItemSpecifications;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtSpecificName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateSpecificationMater;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboPurchaseUOM;
        public System.Windows.Forms.ProgressBar progressBar1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnValidate;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPartNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    }
}