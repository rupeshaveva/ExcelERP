namespace appExcelERP.Forms.HR
{
    partial class frmAddEditEmployee
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
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.headerGroupEmployeeInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.cboEmployeeBoss = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cboEmploymentType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkHasResigned = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.cboDesignation = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboDepartment = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label16 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMobileNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEmail = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEmployeeName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtEmployeeCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployeeInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployeeInfo.Panel)).BeginInit();
            this.headerGroupEmployeeInfo.Panel.SuspendLayout();
            this.headerGroupEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployeeBoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmploymentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDesignation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel5.Location = new System.Drawing.Point(10, 206);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(100, 20);
            this.kryptonLabel5.TabIndex = 4;
            this.kryptonLabel5.Values.Text = "Employee\'s Boss";
            // 
            // headerGroupEmployeeInfo
            // 
            this.headerGroupEmployeeInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupEmployeeInfo.HeaderVisibleSecondary = false;
            this.headerGroupEmployeeInfo.Location = new System.Drawing.Point(9, 6);
            this.headerGroupEmployeeInfo.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupEmployeeInfo.Name = "headerGroupEmployeeInfo";
            // 
            // headerGroupEmployeeInfo.Panel
            // 
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.cboEmployeeBoss);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.kryptonLabel5);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.cboEmploymentType);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.kryptonLabel8);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.chkHasResigned);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.chkIsActive);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.cboDesignation);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.kryptonLabel4);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.cboDepartment);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.label16);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.txtMobileNo);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.kryptonLabel3);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.txtEmail);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.txtEmployeeName);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.txtEmployeeCode);
            this.headerGroupEmployeeInfo.Panel.Controls.Add(this.label1);
            this.headerGroupEmployeeInfo.Size = new System.Drawing.Size(440, 295);
            this.headerGroupEmployeeInfo.TabIndex = 0;
            this.headerGroupEmployeeInfo.ValuesPrimary.Heading = "Employee Info.";
            this.headerGroupEmployeeInfo.ValuesPrimary.Image = null;
            // 
            // cboEmployeeBoss
            // 
            this.cboEmployeeBoss.DropDownWidth = 283;
            this.cboEmployeeBoss.Location = new System.Drawing.Point(116, 204);
            this.cboEmployeeBoss.Name = "cboEmployeeBoss";
            this.cboEmployeeBoss.Size = new System.Drawing.Size(300, 21);
            this.cboEmployeeBoss.TabIndex = 16;
            // 
            // cboEmploymentType
            // 
            this.cboEmploymentType.DropDownWidth = 297;
            this.cboEmploymentType.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmploymentType.FormattingEnabled = true;
            this.cboEmploymentType.Location = new System.Drawing.Point(116, 176);
            this.cboEmploymentType.Name = "cboEmploymentType";
            this.cboEmploymentType.Size = new System.Drawing.Size(300, 21);
            this.cboEmploymentType.TabIndex = 15;
            this.cboEmploymentType.Validating += new System.ComponentModel.CancelEventHandler(this.cboEmploymentType_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel8.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel8.Location = new System.Drawing.Point(10, 177);
            this.kryptonLabel8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel8.TabIndex = 14;
            this.kryptonLabel8.Values.Text = "Employment type";
            // 
            // chkHasResigned
            // 
            this.chkHasResigned.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkHasResigned.Location = new System.Drawing.Point(325, 240);
            this.chkHasResigned.Margin = new System.Windows.Forms.Padding(1);
            this.chkHasResigned.Name = "chkHasResigned";
            this.chkHasResigned.Size = new System.Drawing.Size(102, 20);
            this.chkHasResigned.TabIndex = 13;
            this.chkHasResigned.Values.Text = "Has Resigned";
            // 
            // chkIsActive
            // 
            this.chkIsActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsActive.Location = new System.Drawing.Point(16, 240);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(1);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(73, 20);
            this.chkIsActive.TabIndex = 12;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // cboDesignation
            // 
            this.cboDesignation.DropDownWidth = 297;
            this.cboDesignation.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDesignation.FormattingEnabled = true;
            this.cboDesignation.Location = new System.Drawing.Point(91, 150);
            this.cboDesignation.Name = "cboDesignation";
            this.cboDesignation.Size = new System.Drawing.Size(325, 21);
            this.cboDesignation.TabIndex = 11;
            this.cboDesignation.Validating += new System.ComponentModel.CancelEventHandler(this.cboDesignation_Validating);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel4.Location = new System.Drawing.Point(10, 150);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel4.TabIndex = 10;
            this.kryptonLabel4.Values.Text = "D&esignation";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DropDownWidth = 297;
            this.cboDepartment.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(91, 124);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(325, 21);
            this.cboDepartment.TabIndex = 9;
            this.cboDepartment.Validating += new System.ComponentModel.CancelEventHandler(this.cboDepartment_Validating);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(10, 124);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 20);
            this.label16.TabIndex = 8;
            this.label16.Values.Text = "&Department";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.Location = new System.Drawing.Point(91, 95);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(325, 20);
            this.txtMobileNo.TabIndex = 7;
            this.txtMobileNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobileNo_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(15, 96);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(71, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Mobile No.";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(91, 67);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(325, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.Location = new System.Drawing.Point(44, 67);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(40, 20);
            this.kryptonLabel2.TabIndex = 4;
            this.kryptonLabel2.Values.Text = "Email";
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmployeeName.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeName.Location = new System.Drawing.Point(91, 38);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(325, 20);
            this.txtEmployeeName.TabIndex = 3;
            this.txtEmployeeName.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployeeName_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(20, 39);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "Full Name";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeCode.Location = new System.Drawing.Point(91, 10);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(325, 20);
            this.txtEmployeeCode.TabIndex = 1;
            this.txtEmployeeCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmployeeCode_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Emp. Code";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(343, 311);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(253, 311);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(460, 352);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.headerGroupEmployeeInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Employee";
            this.Load += new System.EventHandler(this.frmAddEditEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployeeInfo.Panel)).EndInit();
            this.headerGroupEmployeeInfo.Panel.ResumeLayout(false);
            this.headerGroupEmployeeInfo.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupEmployeeInfo)).EndInit();
            this.headerGroupEmployeeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployeeBoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmploymentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDesignation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupEmployeeInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMobileNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmail;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmployeeName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtEmployeeCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboDesignation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboDepartment;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label16;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkHasResigned;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboEmploymentType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboEmployeeBoss;
    }
}