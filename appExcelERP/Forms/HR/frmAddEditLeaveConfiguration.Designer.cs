namespace appExcelERP.Forms.HR
{
    partial class frmAddEditLeaveConfiguration
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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboYear = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBranch = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
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
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.gridAllounces = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllounces)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboYear
            // 
            this.cboYear.DropDownWidth = 297;
            this.cboYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(146, 58);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(263, 21);
            this.cboYear.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.Location = new System.Drawing.Point(59, 58);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Financial Year";
            // 
            // cboBranch
            // 
            this.cboBranch.DropDownWidth = 297;
            this.cboBranch.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(14, 33);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(395, 21);
            this.cboBranch.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 10);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(139, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Select Company Branch";
            // 
            // chkLeaveEncashable
            // 
            this.chkLeaveEncashable.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkLeaveEncashable.Location = new System.Drawing.Point(14, 159);
            this.chkLeaveEncashable.Name = "chkLeaveEncashable";
            this.chkLeaveEncashable.Size = new System.Drawing.Size(124, 20);
            this.chkLeaveEncashable.TabIndex = 12;
            this.chkLeaveEncashable.Values.Text = "Leave Encashable";
            this.chkLeaveEncashable.CheckedChanged += new System.EventHandler(this.chkLeaveEncashable_CheckedChanged);
            // 
            // chkApplicableProbationPeriod
            // 
            this.chkApplicableProbationPeriod.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkApplicableProbationPeriod.Location = new System.Drawing.Point(14, 139);
            this.chkApplicableProbationPeriod.Name = "chkApplicableProbationPeriod";
            this.chkApplicableProbationPeriod.Size = new System.Drawing.Size(230, 20);
            this.chkApplicableProbationPeriod.TabIndex = 11;
            this.chkApplicableProbationPeriod.Values.Text = "Applicable during Probation period";
            // 
            // lblLimitDays
            // 
            this.lblLimitDays.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLimitDays.ForeColor = System.Drawing.Color.Black;
            this.lblLimitDays.Location = new System.Drawing.Point(335, 87);
            this.lblLimitDays.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblLimitDays.Name = "lblLimitDays";
            this.lblLimitDays.Size = new System.Drawing.Size(74, 20);
            this.lblLimitDays.TabIndex = 9;
            this.lblLimitDays.Values.Text = "Limit (Days)";
            // 
            // txtLimitDays
            // 
            this.txtLimitDays.Location = new System.Drawing.Point(348, 110);
            this.txtLimitDays.Name = "txtLimitDays";
            this.txtLimitDays.Size = new System.Drawing.Size(61, 20);
            this.txtLimitDays.TabIndex = 10;
            this.txtLimitDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLimitDays.Validating += new System.ComponentModel.CancelEventHandler(this.txtLimitDays_Validating);
            // 
            // chkLeaveCarryForward
            // 
            this.chkLeaveCarryForward.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkLeaveCarryForward.Location = new System.Drawing.Point(232, 110);
            this.chkLeaveCarryForward.Name = "chkLeaveCarryForward";
            this.chkLeaveCarryForward.Size = new System.Drawing.Size(106, 20);
            this.chkLeaveCarryForward.TabIndex = 8;
            this.chkLeaveCarryForward.Values.Text = "Carry Forward";
            // 
            // chkIsActive
            // 
            this.chkIsActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsActive.Location = new System.Drawing.Point(14, 416);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(1);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(73, 20);
            this.chkIsActive.TabIndex = 14;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.DropDownWidth = 297;
            this.cboLeaveType.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLeaveType.FormattingEnabled = true;
            this.cboLeaveType.Location = new System.Drawing.Point(14, 110);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(107, 21);
            this.cboLeaveType.TabIndex = 5;
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveType.ForeColor = System.Drawing.Color.Black;
            this.lblLeaveType.Location = new System.Drawing.Point(14, 87);
            this.lblLeaveType.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(71, 20);
            this.lblLeaveType.TabIndex = 4;
            this.lblLeaveType.Values.Text = "Leave Type";
            // 
            // txtMaxDaysallow
            // 
            this.txtMaxDaysallow.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxDaysallow.Location = new System.Drawing.Point(135, 110);
            this.txtMaxDaysallow.Name = "txtMaxDaysallow";
            this.txtMaxDaysallow.Size = new System.Drawing.Size(72, 20);
            this.txtMaxDaysallow.TabIndex = 7;
            this.txtMaxDaysallow.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaxDaysallow_Validating);
            // 
            // lblMaxDaysAllow
            // 
            this.lblMaxDaysAllow.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxDaysAllow.ForeColor = System.Drawing.Color.Black;
            this.lblMaxDaysAllow.Location = new System.Drawing.Point(135, 87);
            this.lblMaxDaysAllow.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.lblMaxDaysAllow.Name = "lblMaxDaysAllow";
            this.lblMaxDaysAllow.Size = new System.Drawing.Size(97, 20);
            this.lblMaxDaysAllow.TabIndex = 6;
            this.lblMaxDaysAllow.Values.Text = "Max Days Allow";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(223, 418);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 25);
            this.btnSave.TabIndex = 15;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(319, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Values.Text = "&Cancel";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(135, 165);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(280, 20);
            this.kryptonLabel3.TabIndex = 42;
            this.kryptonLabel3.Values.Text = "(Consider following Heads for Leave Encashment)";
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
            this.gridAllounces.Location = new System.Drawing.Point(14, 185);
            this.gridAllounces.MultiSelect = false;
            this.gridAllounces.Name = "gridAllounces";
            this.gridAllounces.RowHeadersVisible = false;
            this.gridAllounces.Size = new System.Drawing.Size(395, 219);
            this.gridAllounces.TabIndex = 13;
            this.gridAllounces.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAllounces_CellDoubleClick);
            // 
            // frmAddEditLeaveConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(423, 458);
            this.Controls.Add(this.gridAllounces);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.cboBranch);
            this.Controls.Add(this.kryptonLabel1);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditLeaveConfiguration";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration HR-Leave";
            this.Load += new System.EventHandler(this.frmAddEditLeaveConfiguration_Leave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllounces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboYear;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBranch;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
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
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAllounces;
    }
}