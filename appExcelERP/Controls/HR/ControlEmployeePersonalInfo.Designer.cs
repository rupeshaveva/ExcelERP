namespace appExcelERP.Controls.HR
{
    partial class ControlEmployeePersonalInfo
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
            this.components = new System.ComponentModel.Container();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupPersonalInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdatePersonalInfo = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBloodGroup = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboGender = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.chkSeniorCitizen = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtEmployeeBirthPlace = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtLanguage = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblLanguage = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDateOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtDateOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtAnniversary = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblBirthPlace = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblAnniversaryDate = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblGender = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblMaritalStatus = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBloodGroup = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboMaritalStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.headerGroupFamilyInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewFamilyMember = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditFamilyMember = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteFamilyMember = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridEmployeeRelatives = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPersonalInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPersonalInfo.Panel)).BeginInit();
            this.headerGroupPersonalInfo.Panel.SuspendLayout();
            this.headerGroupPersonalInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBloodGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaritalStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFamilyInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFamilyInfo.Panel)).BeginInit();
            this.headerGroupFamilyInfo.Panel.SuspendLayout();
            this.headerGroupFamilyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeRelatives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupPersonalInfo);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupFamilyInfo);
            this.splitContainerMain.Size = new System.Drawing.Size(550, 392);
            this.splitContainerMain.SplitterDistance = 259;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupPersonalInfo
            // 
            this.headerGroupPersonalInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdatePersonalInfo});
            this.headerGroupPersonalInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupPersonalInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupPersonalInfo.Location = new System.Drawing.Point(0, 0);
            this.headerGroupPersonalInfo.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupPersonalInfo.Name = "headerGroupPersonalInfo";
            // 
            // headerGroupPersonalInfo.Panel
            // 
            this.headerGroupPersonalInfo.Panel.Controls.Add(this.tableLayoutPanel1);
            this.headerGroupPersonalInfo.Panel.Controls.Add(this.tableLayoutPanel2);
            this.headerGroupPersonalInfo.Panel.Padding = new System.Windows.Forms.Padding(2);
            this.headerGroupPersonalInfo.Size = new System.Drawing.Size(259, 392);
            this.headerGroupPersonalInfo.TabIndex = 0;
            this.headerGroupPersonalInfo.ValuesPrimary.Heading = "Personal Info.";
            this.headerGroupPersonalInfo.ValuesPrimary.Image = null;
            this.headerGroupPersonalInfo.ValuesSecondary.Heading = "";
            // 
            // btnUpdatePersonalInfo
            // 
            this.btnUpdatePersonalInfo.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnUpdatePersonalInfo.Image = global::appExcelERP.Properties.Resources.JSWorker_16x;
            this.btnUpdatePersonalInfo.Text = "&Update Personal Info.";
            this.btnUpdatePersonalInfo.UniqueName = "415EC68478B542D12AAAC074F288FF6D";
            this.btnUpdatePersonalInfo.Click += new System.EventHandler(this.btnUpdatePersonalInfo_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(718, 333);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(6, 6);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.Controls.Add(this.lblBloodGroup, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.cboGender, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.chkSeniorCitizen, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.txtEmployeeBirthPlace, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtLanguage, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.lblLanguage, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.lblDateOfBirth, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtDateOfBirth, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtAnniversary, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblBirthPlace, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblAnniversaryDate, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblGender, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblMaritalStatus, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.cboBloodGroup, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.cboMaritalStatus, 1, 9);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 15;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(253, 337);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // lblBloodGroup
            // 
            this.lblBloodGroup.Location = new System.Drawing.Point(14, 148);
            this.lblBloodGroup.Margin = new System.Windows.Forms.Padding(2);
            this.lblBloodGroup.Name = "lblBloodGroup";
            this.lblBloodGroup.Size = new System.Drawing.Size(80, 20);
            this.lblBloodGroup.TabIndex = 18;
            this.lblBloodGroup.Values.Text = "Blood Group";
            // 
            // cboGender
            // 
            this.cboGender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboGender.DropDownWidth = 197;
            this.cboGender.Location = new System.Drawing.Point(14, 123);
            this.cboGender.Margin = new System.Windows.Forms.Padding(2);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(223, 21);
            this.cboGender.TabIndex = 18;
            this.cboGender.Text = "kryptonComboBox1";
            // 
            // chkSeniorCitizen
            // 
            this.chkSeniorCitizen.Location = new System.Drawing.Point(14, 343);
            this.chkSeniorCitizen.Margin = new System.Windows.Forms.Padding(2);
            this.chkSeniorCitizen.Name = "chkSeniorCitizen";
            this.chkSeniorCitizen.Size = new System.Drawing.Size(98, 20);
            this.chkSeniorCitizen.TabIndex = 14;
            this.chkSeniorCitizen.Values.Text = "Senior Citizen";
            // 
            // txtEmployeeBirthPlace
            // 
            this.txtEmployeeBirthPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmployeeBirthPlace.Location = new System.Drawing.Point(14, 75);
            this.txtEmployeeBirthPlace.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmployeeBirthPlace.Name = "txtEmployeeBirthPlace";
            this.txtEmployeeBirthPlace.Size = new System.Drawing.Size(223, 20);
            this.txtEmployeeBirthPlace.TabIndex = 18;
            this.txtEmployeeBirthPlace.Text = "kryptonTextBox1";
            // 
            // txtLanguage
            // 
            this.txtLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLanguage.Location = new System.Drawing.Point(14, 319);
            this.txtLanguage.Margin = new System.Windows.Forms.Padding(2);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(223, 20);
            this.txtLanguage.TabIndex = 13;
            this.txtLanguage.Text = "kryptonTextBox1";
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(14, 295);
            this.lblLanguage.Margin = new System.Windows.Forms.Padding(2);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(64, 20);
            this.lblLanguage.TabIndex = 12;
            this.lblLanguage.Values.Text = "Language";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Location = new System.Drawing.Point(14, 2);
            this.lblDateOfBirth.Margin = new System.Windows.Forms.Padding(2);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(82, 20);
            this.lblDateOfBirth.TabIndex = 11;
            this.lblDateOfBirth.Values.Text = "Date Of Birth";
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDateOfBirth.Location = new System.Drawing.Point(14, 26);
            this.dtDateOfBirth.Margin = new System.Windows.Forms.Padding(2);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.ShowCheckBox = true;
            this.dtDateOfBirth.Size = new System.Drawing.Size(223, 21);
            this.dtDateOfBirth.TabIndex = 12;
            this.dtDateOfBirth.ValueNullable = new System.DateTime(((long)(0)));
            // 
            // dtAnniversary
            // 
            this.dtAnniversary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtAnniversary.Location = new System.Drawing.Point(14, 270);
            this.dtAnniversary.Margin = new System.Windows.Forms.Padding(2);
            this.dtAnniversary.Name = "dtAnniversary";
            this.dtAnniversary.ShowCheckBox = true;
            this.dtAnniversary.Size = new System.Drawing.Size(223, 21);
            this.dtAnniversary.TabIndex = 11;
            this.dtAnniversary.ValueNullable = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // lblBirthPlace
            // 
            this.lblBirthPlace.Location = new System.Drawing.Point(14, 51);
            this.lblBirthPlace.Margin = new System.Windows.Forms.Padding(2);
            this.lblBirthPlace.Name = "lblBirthPlace";
            this.lblBirthPlace.Size = new System.Drawing.Size(68, 20);
            this.lblBirthPlace.TabIndex = 13;
            this.lblBirthPlace.Values.Text = "Birth Place";
            // 
            // lblAnniversaryDate
            // 
            this.lblAnniversaryDate.Location = new System.Drawing.Point(14, 246);
            this.lblAnniversaryDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblAnniversaryDate.Name = "lblAnniversaryDate";
            this.lblAnniversaryDate.Size = new System.Drawing.Size(103, 20);
            this.lblAnniversaryDate.TabIndex = 10;
            this.lblAnniversaryDate.Values.Text = "Anniversary Date";
            // 
            // lblGender
            // 
            this.lblGender.Location = new System.Drawing.Point(14, 99);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(50, 20);
            this.lblGender.TabIndex = 19;
            this.lblGender.Values.Text = "Gender";
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.Location = new System.Drawing.Point(14, 197);
            this.lblMaritalStatus.Margin = new System.Windows.Forms.Padding(2);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(86, 20);
            this.lblMaritalStatus.TabIndex = 8;
            this.lblMaritalStatus.Values.Text = "Merital Status";
            // 
            // cboBloodGroup
            // 
            this.cboBloodGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboBloodGroup.DropDownWidth = 197;
            this.cboBloodGroup.Location = new System.Drawing.Point(14, 172);
            this.cboBloodGroup.Margin = new System.Windows.Forms.Padding(2);
            this.cboBloodGroup.Name = "cboBloodGroup";
            this.cboBloodGroup.Size = new System.Drawing.Size(223, 21);
            this.cboBloodGroup.TabIndex = 7;
            this.cboBloodGroup.Text = "kryptonComboBox1";
            // 
            // cboMaritalStatus
            // 
            this.cboMaritalStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboMaritalStatus.DropDownWidth = 197;
            this.cboMaritalStatus.Location = new System.Drawing.Point(14, 221);
            this.cboMaritalStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cboMaritalStatus.Name = "cboMaritalStatus";
            this.cboMaritalStatus.Size = new System.Drawing.Size(223, 21);
            this.cboMaritalStatus.TabIndex = 20;
            this.cboMaritalStatus.Text = "kryptonComboBox1";
            // 
            // headerGroupFamilyInfo
            // 
            this.headerGroupFamilyInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewFamilyMember,
            this.btnEditFamilyMember,
            this.btnDeleteFamilyMember});
            this.headerGroupFamilyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupFamilyInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupFamilyInfo.Location = new System.Drawing.Point(0, 0);
            this.headerGroupFamilyInfo.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupFamilyInfo.Name = "headerGroupFamilyInfo";
            // 
            // headerGroupFamilyInfo.Panel
            // 
            this.headerGroupFamilyInfo.Panel.Controls.Add(this.gridEmployeeRelatives);
            this.headerGroupFamilyInfo.Size = new System.Drawing.Size(286, 392);
            this.headerGroupFamilyInfo.TabIndex = 1;
            this.headerGroupFamilyInfo.ValuesPrimary.Heading = "Family Info.";
            this.headerGroupFamilyInfo.ValuesPrimary.Image = null;
            this.headerGroupFamilyInfo.ValuesSecondary.Heading = "";
            // 
            // btnAddNewFamilyMember
            // 
            this.btnAddNewFamilyMember.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddNewFamilyMember.Text = "&Add New";
            this.btnAddNewFamilyMember.UniqueName = "AD802B4596064E8988B6D395CC74279E";
            this.btnAddNewFamilyMember.Click += new System.EventHandler(this.btnAddNewFamilyMember_Click);
            // 
            // btnEditFamilyMember
            // 
            this.btnEditFamilyMember.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditFamilyMember.Text = "&Edit";
            this.btnEditFamilyMember.UniqueName = "329A92EF29D54E60B6964F2920C26DC7";
            this.btnEditFamilyMember.Click += new System.EventHandler(this.btnEditFamilyMember_Click);
            // 
            // btnDeleteFamilyMember
            // 
            this.btnDeleteFamilyMember.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDeleteFamilyMember.Text = "&Delete";
            this.btnDeleteFamilyMember.UniqueName = "F2378B021B624CC3B4BBBA2803BC49BB";
            this.btnDeleteFamilyMember.Click += new System.EventHandler(this.btnDeleteFamilyMember_Click);
            // 
            // gridEmployeeRelatives
            // 
            this.gridEmployeeRelatives.AllowUserToAddRows = false;
            this.gridEmployeeRelatives.AllowUserToDeleteRows = false;
            this.gridEmployeeRelatives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridEmployeeRelatives.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridEmployeeRelatives.ColumnHeadersHeight = 28;
            this.gridEmployeeRelatives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmployeeRelatives.Location = new System.Drawing.Point(0, 0);
            this.gridEmployeeRelatives.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridEmployeeRelatives.Name = "gridEmployeeRelatives";
            this.gridEmployeeRelatives.ReadOnly = true;
            this.gridEmployeeRelatives.RowHeadersVisible = false;
            this.gridEmployeeRelatives.RowTemplate.Height = 24;
            this.gridEmployeeRelatives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmployeeRelatives.Size = new System.Drawing.Size(284, 360);
            this.gridEmployeeRelatives.TabIndex = 7;
            this.gridEmployeeRelatives.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmployeeRelatives_RowEnter);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ControlEmployeePersonalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ControlEmployeePersonalInfo";
            this.Size = new System.Drawing.Size(550, 392);
            this.Load += new System.EventHandler(this.ControlEmployeePersonalInfo_Load);
            this.Resize += new System.EventHandler(this.ControlEmployeePersonalInfo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPersonalInfo.Panel)).EndInit();
            this.headerGroupPersonalInfo.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPersonalInfo)).EndInit();
            this.headerGroupPersonalInfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBloodGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaritalStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFamilyInfo.Panel)).EndInit();
            this.headerGroupFamilyInfo.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFamilyInfo)).EndInit();
            this.headerGroupFamilyInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmployeeRelatives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupPersonalInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupFamilyInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdatePersonalInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewFamilyMember;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditFamilyMember;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteFamilyMember;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkSeniorCitizen;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLanguage;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLanguage;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtAnniversary;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblAnniversaryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMaritalStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBloodGroup;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBloodGroup;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboGender;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmployeeBirthPlace;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDateOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtDateOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBirthPlace;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblGender;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboMaritalStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridEmployeeRelatives;
    }
}
