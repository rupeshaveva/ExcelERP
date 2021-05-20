namespace appExcelERP.Forms.HR
{
    partial class frmAddEditLeaveApplication
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboEmployees = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtLeaveApplicationNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtLeaveApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.cboLeaveFormType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboLeaveType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromTime = new System.Windows.Forms.DateTimePicker();
            this.dtToTime = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblRemarks = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblLeaveBalanceInfo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNoOfDays = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboRequestTo = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveFormType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestTo)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 51);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel1.TabIndex = 4;
            this.kryptonLabel1.Values.Text = "Employee";
            // 
            // cboEmployees
            // 
            this.cboEmployees.DropDownWidth = 348;
            this.cboEmployees.Location = new System.Drawing.Point(82, 51);
            this.cboEmployees.Name = "cboEmployees";
            this.cboEmployees.Size = new System.Drawing.Size(385, 21);
            this.cboEmployees.TabIndex = 5;
            this.cboEmployees.Text = "kryptonComboBox1";
            this.cboEmployees.Validating += new System.ComponentModel.CancelEventHandler(this.cboEmployees_Validating);
            // 
            // txtLeaveApplicationNo
            // 
            this.txtLeaveApplicationNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveApplicationNo.Location = new System.Drawing.Point(14, 24);
            this.txtLeaveApplicationNo.Name = "txtLeaveApplicationNo";
            this.txtLeaveApplicationNo.ReadOnly = true;
            this.txtLeaveApplicationNo.Size = new System.Drawing.Size(300, 20);
            this.txtLeaveApplicationNo.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveApplicationNo.TabIndex = 1;
            this.txtLeaveApplicationNo.Text = "sdfsdf";
            this.txtLeaveApplicationNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLeaveApplicationNo_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Leave Application No.";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(426, 5);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Date";
            // 
            // dtLeaveApplicationDate
            // 
            this.dtLeaveApplicationDate.CustomFormat = "dd/MM/yyyy";
            this.dtLeaveApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLeaveApplicationDate.Location = new System.Drawing.Point(358, 25);
            this.dtLeaveApplicationDate.Name = "dtLeaveApplicationDate";
            this.dtLeaveApplicationDate.Size = new System.Drawing.Size(109, 20);
            this.dtLeaveApplicationDate.TabIndex = 3;
            // 
            // cboLeaveFormType
            // 
            this.cboLeaveFormType.DropDownWidth = 365;
            this.cboLeaveFormType.Location = new System.Drawing.Point(82, 78);
            this.cboLeaveFormType.Name = "cboLeaveFormType";
            this.cboLeaveFormType.Size = new System.Drawing.Size(137, 21);
            this.cboLeaveFormType.TabIndex = 7;
            this.cboLeaveFormType.Text = "kryptonComboBox2";
            this.cboLeaveFormType.SelectionChangeCommitted += new System.EventHandler(this.cboLeaveFormType_SelectionChangeCommitted);
            this.cboLeaveFormType.SelectedValueChanged += new System.EventHandler(this.cboLeaveFormType_SelectedValueChanged);
            this.cboLeaveFormType.Validating += new System.ComponentModel.CancelEventHandler(this.cboLeaveFormType_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 78);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Form Type";
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.DropDownWidth = 365;
            this.cboLeaveType.Location = new System.Drawing.Point(328, 78);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(139, 21);
            this.cboLeaveType.TabIndex = 9;
            this.cboLeaveType.Text = "kryptonComboBox3";
            this.cboLeaveType.SelectedValueChanged += new System.EventHandler(this.cboLeaveType_SelectedValueChanged);
            this.cboLeaveType.Validating += new System.ComponentModel.CancelEventHandler(this.cboLeaveType_Validating);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel4.Location = new System.Drawing.Point(251, 78);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Leave Type";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel5.Location = new System.Drawing.Point(14, 130);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(117, 20);
            this.kryptonLabel5.TabIndex = 10;
            this.kryptonLabel5.Values.Text = "From Date && Time";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(12, 149);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(97, 20);
            this.dtFromDate.TabIndex = 11;
            this.dtFromDate.ValueChanged += new System.EventHandler(this.dtFromDate_ValueChanged);
            this.dtFromDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtFromDate_Validating);
            // 
            // dtFromTime
            // 
            this.dtFromTime.CustomFormat = "hh:mm tt";
            this.dtFromTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromTime.Location = new System.Drawing.Point(115, 149);
            this.dtFromTime.Name = "dtFromTime";
            this.dtFromTime.ShowUpDown = true;
            this.dtFromTime.Size = new System.Drawing.Size(73, 20);
            this.dtFromTime.TabIndex = 12;
            this.dtFromTime.ValueChanged += new System.EventHandler(this.dtFromTime_ValueChanged);
            // 
            // dtToTime
            // 
            this.dtToTime.CustomFormat = "hh:mm tt";
            this.dtToTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToTime.Location = new System.Drawing.Point(305, 149);
            this.dtToTime.Name = "dtToTime";
            this.dtToTime.ShowUpDown = true;
            this.dtToTime.Size = new System.Drawing.Size(73, 20);
            this.dtToTime.TabIndex = 15;
            this.dtToTime.ValueChanged += new System.EventHandler(this.dtToTime_ValueChanged);
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd/MM/yyyy";
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(202, 149);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(97, 20);
            this.dtToDate.TabIndex = 14;
            this.dtToDate.ValueChanged += new System.EventHandler(this.dtToDate_ValueChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(276, 131);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(102, 20);
            this.kryptonLabel6.TabIndex = 13;
            this.kryptonLabel6.Values.Text = "To Date && Time";
            // 
            // lblRemarks
            // 
            this.lblRemarks.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblRemarks.Location = new System.Drawing.Point(12, 173);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(60, 20);
            this.lblRemarks.TabIndex = 16;
            this.lblRemarks.Values.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(12, 192);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(455, 64);
            this.txtRemarks.TabIndex = 17;
            this.txtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.txtRemarks_Validating);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(387, 292);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 19;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(297, 292);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 18;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLeaveBalanceInfo
            // 
            this.lblLeaveBalanceInfo.AutoSize = false;
            this.lblLeaveBalanceInfo.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblLeaveBalanceInfo.Location = new System.Drawing.Point(14, 104);
            this.lblLeaveBalanceInfo.Name = "lblLeaveBalanceInfo";
            this.lblLeaveBalanceInfo.Size = new System.Drawing.Size(450, 20);
            this.lblLeaveBalanceInfo.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.lblLeaveBalanceInfo.StateNormal.ShortText.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.lblLeaveBalanceInfo.StateNormal.ShortText.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Form;
            this.lblLeaveBalanceInfo.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.lblLeaveBalanceInfo.StateNormal.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.lblLeaveBalanceInfo.TabIndex = 20;
            this.lblLeaveBalanceInfo.Values.Text = "Balance Info.";
            this.lblLeaveBalanceInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.lblLeaveBalanceInfo_Paint);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtNoOfDays
            // 
            this.txtNoOfDays.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDays.Location = new System.Drawing.Point(389, 149);
            this.txtNoOfDays.Name = "txtNoOfDays";
            this.txtNoOfDays.ReadOnly = true;
            this.txtNoOfDays.Size = new System.Drawing.Size(78, 20);
            this.txtNoOfDays.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfDays.TabIndex = 22;
            this.txtNoOfDays.Text = "sdfsdf";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel7.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel7.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel7.Location = new System.Drawing.Point(389, 131);
            this.kryptonLabel7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel7.TabIndex = 21;
            this.kryptonLabel7.Values.Text = "DD:HH:MM";
            // 
            // cboRequestTo
            // 
            this.cboRequestTo.DropDownWidth = 348;
            this.cboRequestTo.Location = new System.Drawing.Point(145, 262);
            this.cboRequestTo.Name = "cboRequestTo";
            this.cboRequestTo.Size = new System.Drawing.Size(322, 21);
            this.cboRequestTo.TabIndex = 24;
            this.cboRequestTo.Text = "kryptonComboBox1";
            this.cboRequestTo.Validating += new System.ComponentModel.CancelEventHandler(this.cboRequestTo_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel8.Location = new System.Drawing.Point(63, 262);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(76, 20);
            this.kryptonLabel8.TabIndex = 23;
            this.kryptonLabel8.Values.Text = "Request To";
            // 
            // frmAddEditLeaveApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(486, 327);
            this.Controls.Add(this.cboRequestTo);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.txtNoOfDays);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.lblLeaveBalanceInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.dtToTime);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.dtFromTime);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.cboLeaveType);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.cboLeaveFormType);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.dtLeaveApplicationDate);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtLeaveApplicationNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmployees);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditLeaveApplication";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Application Form";
            this.Load += new System.EventHandler(this.frmAddEditLeaveApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveFormType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLeaveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboRequestTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLeaveApplicationNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboLeaveFormType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboLeaveType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblLeaveBalanceInfo;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNoOfDays;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboRequestTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        public System.Windows.Forms.DateTimePicker dtLeaveApplicationDate;
        public System.Windows.Forms.DateTimePicker dtFromDate;
        public System.Windows.Forms.DateTimePicker dtFromTime;
        public System.Windows.Forms.DateTimePicker dtToTime;
        public System.Windows.Forms.DateTimePicker dtToDate;
    }
}