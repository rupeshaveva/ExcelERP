namespace appExcelERP.Forms.HR
{
    partial class frmAddEditEmployeeLeaveConfig
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
            this.headerEmployeeName = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.gridAllounces = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cboYear = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkLeaveEncashable = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkApplicableProbationPeriod = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.lblLimitDays = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLimitDays = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.chkLeaveCarryForward = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.cboLeaveType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblLeaveType = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMaxDaysallow = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblMaxDaysAllow = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtLeaveOpeningBalance = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllounces)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerEmployeeName
            // 
            this.headerEmployeeName.AutoSize = false;
            this.headerEmployeeName.Location = new System.Drawing.Point(12, 6);
            this.headerEmployeeName.Name = "headerEmployeeName";
            this.headerEmployeeName.Size = new System.Drawing.Size(396, 30);
            this.headerEmployeeName.TabIndex = 0;
            this.headerEmployeeName.Values.Description = "Employee Name";
            this.headerEmployeeName.Values.Heading = "";
            this.headerEmployeeName.Values.Image = null;
            // 
            // gridAllounces
            // 
            this.gridAllounces.AllowUserToAddRows = false;
            this.gridAllounces.AllowUserToDeleteRows = false;
            this.gridAllounces.AllowUserToOrderColumns = true;
            this.gridAllounces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAllounces.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.gridAllounces.ColumnHeadersVisible = false;
            this.gridAllounces.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAllounces.Location = new System.Drawing.Point(13, 168);
            this.gridAllounces.MultiSelect = false;
            this.gridAllounces.Name = "gridAllounces";
            this.gridAllounces.RowHeadersVisible = false;
            this.gridAllounces.Size = new System.Drawing.Size(395, 137);
            this.gridAllounces.TabIndex = 54;
            this.gridAllounces.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAllounces_CellDoubleClick);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(134, 148);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(280, 20);
            this.kryptonLabel3.TabIndex = 58;
            this.kryptonLabel3.Values.Text = "(Consider following Heads for Leave Encashment)";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(319, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(223, 380);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 56;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cboYear
            // 
            this.cboYear.DropDownWidth = 297;
            this.cboYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(145, 45);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(263, 21);
            this.cboYear.TabIndex = 44;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.Location = new System.Drawing.Point(58, 45);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel2.TabIndex = 43;
            this.kryptonLabel2.Values.Text = "Financial Year";
            // 
            // chkLeaveEncashable
            // 
            this.chkLeaveEncashable.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkLeaveEncashable.Location = new System.Drawing.Point(13, 148);
            this.chkLeaveEncashable.Name = "chkLeaveEncashable";
            this.chkLeaveEncashable.Size = new System.Drawing.Size(124, 20);
            this.chkLeaveEncashable.TabIndex = 53;
            this.chkLeaveEncashable.Values.Text = "Leave Encashable";
            // 
            // chkApplicableProbationPeriod
            // 
            this.chkApplicableProbationPeriod.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkApplicableProbationPeriod.Location = new System.Drawing.Point(13, 124);
            this.chkApplicableProbationPeriod.Name = "chkApplicableProbationPeriod";
            this.chkApplicableProbationPeriod.Size = new System.Drawing.Size(230, 20);
            this.chkApplicableProbationPeriod.TabIndex = 52;
            this.chkApplicableProbationPeriod.Values.Text = "Applicable during Probation period";
            // 
            // lblLimitDays
            // 
            this.lblLimitDays.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLimitDays.ForeColor = System.Drawing.Color.Black;
            this.lblLimitDays.Location = new System.Drawing.Point(117, 308);
            this.lblLimitDays.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblLimitDays.Name = "lblLimitDays";
            this.lblLimitDays.Size = new System.Drawing.Size(200, 20);
            this.lblLimitDays.TabIndex = 50;
            this.lblLimitDays.Values.Text = "Leaves can be Encashed, if exceeds ";
            // 
            // txtLimitDays
            // 
            this.txtLimitDays.Location = new System.Drawing.Point(323, 308);
            this.txtLimitDays.Name = "txtLimitDays";
            this.txtLimitDays.Size = new System.Drawing.Size(41, 20);
            this.txtLimitDays.TabIndex = 51;
            this.txtLimitDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLimitDays.Validating += new System.ComponentModel.CancelEventHandler(this.txtLimitDays_Validating);
            // 
            // chkLeaveCarryForward
            // 
            this.chkLeaveCarryForward.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.chkLeaveCarryForward.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkLeaveCarryForward.Location = new System.Drawing.Point(254, 98);
            this.chkLeaveCarryForward.Name = "chkLeaveCarryForward";
            this.chkLeaveCarryForward.Size = new System.Drawing.Size(148, 20);
            this.chkLeaveCarryForward.TabIndex = 49;
            this.chkLeaveCarryForward.Values.Text = "Carry Forward Leaves";
            // 
            // chkIsActive
            // 
            this.chkIsActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsActive.Location = new System.Drawing.Point(14, 378);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(1);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(73, 20);
            this.chkIsActive.TabIndex = 55;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.DropDownWidth = 297;
            this.cboLeaveType.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLeaveType.FormattingEnabled = true;
            this.cboLeaveType.Location = new System.Drawing.Point(13, 97);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(107, 21);
            this.cboLeaveType.TabIndex = 46;
            this.cboLeaveType.Validating += new System.ComponentModel.CancelEventHandler(this.cboLeaveType_Validating);
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveType.ForeColor = System.Drawing.Color.Black;
            this.lblLeaveType.Location = new System.Drawing.Point(13, 74);
            this.lblLeaveType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(71, 20);
            this.lblLeaveType.TabIndex = 45;
            this.lblLeaveType.Values.Text = "Leave Type";
            // 
            // txtMaxDaysallow
            // 
            this.txtMaxDaysallow.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxDaysallow.Location = new System.Drawing.Point(134, 97);
            this.txtMaxDaysallow.Name = "txtMaxDaysallow";
            this.txtMaxDaysallow.Size = new System.Drawing.Size(109, 20);
            this.txtMaxDaysallow.TabIndex = 48;
            this.txtMaxDaysallow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMaxDaysallow.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaxDaysallow_Validating);
            // 
            // lblMaxDaysAllow
            // 
            this.lblMaxDaysAllow.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDaysAllow.ForeColor = System.Drawing.Color.Black;
            this.lblMaxDaysAllow.Location = new System.Drawing.Point(134, 74);
            this.lblMaxDaysAllow.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblMaxDaysAllow.Name = "lblMaxDaysAllow";
            this.lblMaxDaysAllow.Size = new System.Drawing.Size(110, 20);
            this.lblMaxDaysAllow.TabIndex = 47;
            this.lblMaxDaysAllow.Values.Text = "Max Days Allowed";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtLeaveOpeningBalance
            // 
            this.txtLeaveOpeningBalance.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveOpeningBalance.Location = new System.Drawing.Point(323, 333);
            this.txtLeaveOpeningBalance.Name = "txtLeaveOpeningBalance";
            this.txtLeaveOpeningBalance.Size = new System.Drawing.Size(41, 20);
            this.txtLeaveOpeningBalance.TabIndex = 60;
            this.txtLeaveOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLeaveOpeningBalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtLeaveOpeningBalance_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(131, 333);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(186, 20);
            this.kryptonLabel1.TabIndex = 59;
            this.kryptonLabel1.Values.Text = "Leave Opening Balance (Earned) ";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel4.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel4.Location = new System.Drawing.Point(370, 308);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel4.TabIndex = 61;
            this.kryptonLabel4.Values.Text = "days.";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel5.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel5.Location = new System.Drawing.Point(369, 333);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel5.TabIndex = 62;
            this.kryptonLabel5.Values.Text = "days.";
            // 
            // frmAddEditEmployeeLeaveConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(419, 420);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtLeaveOpeningBalance);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.gridAllounces);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.chkLeaveEncashable);
            this.Controls.Add(this.chkApplicableProbationPeriod);
            this.Controls.Add(this.lblLimitDays);
            this.Controls.Add(this.txtLimitDays);
            this.Controls.Add(this.chkLeaveCarryForward);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.cboLeaveType);
            this.Controls.Add(this.lblLeaveType);
            this.Controls.Add(this.txtMaxDaysallow);
            this.Controls.Add(this.lblMaxDaysAllow);
            this.Controls.Add(this.headerEmployeeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditEmployeeLeaveConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Employee Leave Config";
            this.Load += new System.EventHandler(this.frmAddEditEmployeeLeaveConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAllounces)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader headerEmployeeName;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAllounces;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboYear;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkLeaveEncashable;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkApplicableProbationPeriod;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLimitDays;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLimitDays;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkLeaveCarryForward;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboLeaveType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLeaveType;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMaxDaysallow;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblMaxDaysAllow;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLeaveOpeningBalance;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
    }
}