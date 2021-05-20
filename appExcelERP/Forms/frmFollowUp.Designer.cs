namespace appExcelERP.Forms
{
    partial class frmFollowUp
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
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.headerGroupFollowup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.tabStatus = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pageNextFollowUp = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtLocation = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSubject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtContactNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtScheduleStartDatetime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtContactPerson = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtReaminder = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.dtScheduleEndDatetime = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.pageClosed = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.txtReasonClose = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.cboFollowUpStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.headerGroupSchedule = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.lblScheduleInfo = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowup.Panel)).BeginInit();
            this.headerGroupFollowup.Panel.SuspendLayout();
            this.headerGroupFollowup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabStatus)).BeginInit();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageNextFollowUp)).BeginInit();
            this.pageNextFollowUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageClosed)).BeginInit();
            this.pageClosed.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFollowUpStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule.Panel)).BeginInit();
            this.headerGroupSchedule.Panel.SuspendLayout();
            this.headerGroupSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.kryptonHeaderGroup1.HeaderVisiblePrimary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(5, 5);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.headerGroupFollowup);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.headerGroupSchedule);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(647, 520);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Text = "&Save FollowUp Details";
            this.btnSave.UniqueName = "090185E89D1E430F3898BE29FB754866";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "4B7C4D7784A645DE6E91A65EC0BE1DC2";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // headerGroupFollowup
            // 
            this.headerGroupFollowup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupFollowup.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupFollowup.HeaderVisibleSecondary = false;
            this.headerGroupFollowup.Location = new System.Drawing.Point(0, 102);
            this.headerGroupFollowup.Name = "headerGroupFollowup";
            // 
            // headerGroupFollowup.Panel
            // 
            this.headerGroupFollowup.Panel.Controls.Add(this.tabStatus);
            this.headerGroupFollowup.Panel.Controls.Add(this.cboFollowUpStatus);
            this.headerGroupFollowup.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupFollowup.Panel.Controls.Add(this.txtRemarks);
            this.headerGroupFollowup.Panel.Controls.Add(this.kryptonLabel10);
            this.headerGroupFollowup.Size = new System.Drawing.Size(645, 389);
            this.headerGroupFollowup.TabIndex = 3;
            this.headerGroupFollowup.ValuesPrimary.Heading = "Followup Result";
            this.headerGroupFollowup.ValuesPrimary.Image = null;
            // 
            // tabStatus
            // 
            this.tabStatus.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.tabStatus.Location = new System.Drawing.Point(10, 138);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pageNextFollowUp,
            this.pageClosed});
            this.tabStatus.SelectedIndex = 0;
            this.tabStatus.Size = new System.Drawing.Size(623, 222);
            this.tabStatus.TabIndex = 31;
            this.tabStatus.Text = "kryptonNavigator1";
            // 
            // pageNextFollowUp
            // 
            this.pageNextFollowUp.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageNextFollowUp.Controls.Add(this.txtLocation);
            this.pageNextFollowUp.Controls.Add(this.kryptonLabel3);
            this.pageNextFollowUp.Controls.Add(this.kryptonLabel7);
            this.pageNextFollowUp.Controls.Add(this.txtSubject);
            this.pageNextFollowUp.Controls.Add(this.txtContactNumber);
            this.pageNextFollowUp.Controls.Add(this.dtScheduleStartDatetime);
            this.pageNextFollowUp.Controls.Add(this.kryptonLabel6);
            this.pageNextFollowUp.Controls.Add(this.kryptonLabel11);
            this.pageNextFollowUp.Controls.Add(this.txtContactPerson);
            this.pageNextFollowUp.Controls.Add(this.kryptonLabel1);
            this.pageNextFollowUp.Controls.Add(this.kryptonLabel4);
            this.pageNextFollowUp.Controls.Add(this.kryptonLabel5);
            this.pageNextFollowUp.Controls.Add(this.dtReaminder);
            this.pageNextFollowUp.Controls.Add(this.dtScheduleEndDatetime);
            this.pageNextFollowUp.Flags = 65534;
            this.pageNextFollowUp.LastVisibleSet = true;
            this.pageNextFollowUp.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageNextFollowUp.Name = "pageNextFollowUp";
            this.pageNextFollowUp.Padding = new System.Windows.Forms.Padding(3);
            this.pageNextFollowUp.Size = new System.Drawing.Size(621, 195);
            this.pageNextFollowUp.Text = "Next Followup Details";
            this.pageNextFollowUp.ToolTipTitle = "Page ToolTip";
            this.pageNextFollowUp.UniqueName = "81A6BDF0A8F14C588BAC7580815C7E9F";
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(169, 125);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLocation.Size = new System.Drawing.Size(438, 56);
            this.txtLocation.TabIndex = 38;
            this.txtLocation.Validating += new System.ComponentModel.CancelEventHandler(this.txtLocation_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(8, 5);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(138, 20);
            this.kryptonLabel3.TabIndex = 25;
            this.kryptonLabel3.Values.Text = "Followup Subject Line";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(105, 127);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel7.TabIndex = 37;
            this.kryptonLabel7.Values.Text = "Location";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(14, 26);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubject.Size = new System.Drawing.Size(593, 20);
            this.txtSubject.TabIndex = 26;
            this.txtSubject.Validating += new System.ComponentModel.CancelEventHandler(this.txtSubject_Validating);
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactNumber.Location = new System.Drawing.Point(169, 102);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContactNumber.Size = new System.Drawing.Size(438, 20);
            this.txtContactNumber.TabIndex = 36;
            this.txtContactNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtContactNumber_Validating);
            // 
            // dtScheduleStartDatetime
            // 
            this.dtScheduleStartDatetime.CustomFormat = "dd/MM/yy hh:mmtt";
            this.dtScheduleStartDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtScheduleStartDatetime.Location = new System.Drawing.Point(70, 52);
            this.dtScheduleStartDatetime.Name = "dtScheduleStartDatetime";
            this.dtScheduleStartDatetime.Size = new System.Drawing.Size(137, 21);
            this.dtScheduleStartDatetime.TabIndex = 28;
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(61, 102);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(101, 20);
            this.kryptonLabel6.TabIndex = 35;
            this.kryptonLabel6.Values.Text = "Contact Number";
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel11.Location = new System.Drawing.Point(410, 52);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel11.TabIndex = 31;
            this.kryptonLabel11.Values.Text = "Alert from";
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContactPerson.Location = new System.Drawing.Point(169, 79);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContactPerson.Size = new System.Drawing.Size(438, 20);
            this.txtContactPerson.TabIndex = 34;
            this.txtContactPerson.Validating += new System.ComponentModel.CancelEventHandler(this.txtContactPerson_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(69, 79);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel1.TabIndex = 33;
            this.kryptonLabel1.Values.Text = "Contact Person";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(16, 52);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel4.TabIndex = 27;
            this.kryptonLabel4.Values.Text = "Starts at";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel5.Location = new System.Drawing.Point(214, 52);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(52, 20);
            this.kryptonLabel5.TabIndex = 29;
            this.kryptonLabel5.Values.Text = "Ends At";
            // 
            // dtReaminder
            // 
            this.dtReaminder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtReaminder.CustomFormat = "dd/MM/yy hh:mmtt";
            this.dtReaminder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtReaminder.Location = new System.Drawing.Point(480, 52);
            this.dtReaminder.Name = "dtReaminder";
            this.dtReaminder.ShowUpDown = true;
            this.dtReaminder.Size = new System.Drawing.Size(127, 21);
            this.dtReaminder.TabIndex = 32;
            this.dtReaminder.ValueNullable = new System.DateTime(((long)(0)));
            this.dtReaminder.Validating += new System.ComponentModel.CancelEventHandler(this.dtReaminder_Validating);
            // 
            // dtScheduleEndDatetime
            // 
            this.dtScheduleEndDatetime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtScheduleEndDatetime.CustomFormat = "dd/MM/yy hh:mmtt";
            this.dtScheduleEndDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtScheduleEndDatetime.Location = new System.Drawing.Point(266, 52);
            this.dtScheduleEndDatetime.Name = "dtScheduleEndDatetime";
            this.dtScheduleEndDatetime.Size = new System.Drawing.Size(135, 21);
            this.dtScheduleEndDatetime.TabIndex = 30;
            this.dtScheduleEndDatetime.Validating += new System.ComponentModel.CancelEventHandler(this.dtScheduleEndDatetime_Validating);
            // 
            // pageClosed
            // 
            this.pageClosed.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageClosed.Controls.Add(this.txtReasonClose);
            this.pageClosed.Flags = 65534;
            this.pageClosed.LastVisibleSet = true;
            this.pageClosed.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageClosed.Name = "pageClosed";
            this.pageClosed.Padding = new System.Windows.Forms.Padding(5);
            this.pageClosed.Size = new System.Drawing.Size(621, 195);
            this.pageClosed.Text = "&Reason for Closing";
            this.pageClosed.ToolTipTitle = "Page ToolTip";
            this.pageClosed.UniqueName = "632DA5FE097D44F949B99A2C981D6F07";
            // 
            // txtReasonClose
            // 
            this.txtReasonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReasonClose.Location = new System.Drawing.Point(5, 5);
            this.txtReasonClose.MaxLength = 500;
            this.txtReasonClose.Name = "txtReasonClose";
            this.txtReasonClose.Size = new System.Drawing.Size(611, 185);
            this.txtReasonClose.TabIndex = 0;
            this.txtReasonClose.Text = "";
            this.txtReasonClose.Validating += new System.ComponentModel.CancelEventHandler(this.txtReasonClose_Validating);
            // 
            // cboFollowUpStatus
            // 
            this.cboFollowUpStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFollowUpStatus.DropDownWidth = 148;
            this.cboFollowUpStatus.Location = new System.Drawing.Point(446, 109);
            this.cboFollowUpStatus.Name = "cboFollowUpStatus";
            this.cboFollowUpStatus.Size = new System.Drawing.Size(187, 21);
            this.cboFollowUpStatus.TabIndex = 30;
            this.cboFollowUpStatus.Text = "kryptonComboBox1";
            this.cboFollowUpStatus.SelectedValueChanged += new System.EventHandler(this.cboFollowUpStatus_SelectedValueChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(396, 109);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(44, 20);
            this.kryptonLabel2.TabIndex = 29;
            this.kryptonLabel2.Values.Text = "Status";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(10, 24);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemarks.Size = new System.Drawing.Size(623, 81);
            this.txtRemarks.TabIndex = 28;
            this.txtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.txtRemarks_Validating);
            // 
            // kryptonLabel10
            // 
            this.kryptonLabel10.Location = new System.Drawing.Point(10, 3);
            this.kryptonLabel10.Name = "kryptonLabel10";
            this.kryptonLabel10.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel10.TabIndex = 27;
            this.kryptonLabel10.Values.Text = "&Remarks";
            // 
            // headerGroupSchedule
            // 
            this.headerGroupSchedule.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupSchedule.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupSchedule.HeaderVisibleSecondary = false;
            this.headerGroupSchedule.Location = new System.Drawing.Point(0, 0);
            this.headerGroupSchedule.Name = "headerGroupSchedule";
            // 
            // headerGroupSchedule.Panel
            // 
            this.headerGroupSchedule.Panel.Controls.Add(this.lblScheduleInfo);
            this.headerGroupSchedule.Panel.Padding = new System.Windows.Forms.Padding(10);
            this.headerGroupSchedule.Size = new System.Drawing.Size(645, 102);
            this.headerGroupSchedule.TabIndex = 0;
            this.headerGroupSchedule.ValuesPrimary.Heading = "Schdeule info.";
            this.headerGroupSchedule.ValuesPrimary.Image = null;
            // 
            // lblScheduleInfo
            // 
            this.lblScheduleInfo.AutoSize = false;
            this.lblScheduleInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScheduleInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblScheduleInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.lblScheduleInfo.Location = new System.Drawing.Point(10, 10);
            this.lblScheduleInfo.Name = "lblScheduleInfo";
            this.lblScheduleInfo.Size = new System.Drawing.Size(623, 58);
            this.lblScheduleInfo.Text = "kryptonWrapLabel1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmFollowUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(658, 533);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFollowUp";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Follow-Up Details";
            this.Load += new System.EventHandler(this.frmFollowUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowup.Panel)).EndInit();
            this.headerGroupFollowup.Panel.ResumeLayout(false);
            this.headerGroupFollowup.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupFollowup)).EndInit();
            this.headerGroupFollowup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabStatus)).EndInit();
            this.tabStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageNextFollowUp)).EndInit();
            this.pageNextFollowUp.ResumeLayout(false);
            this.pageNextFollowUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageClosed)).EndInit();
            this.pageClosed.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboFollowUpStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule.Panel)).EndInit();
            this.headerGroupSchedule.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSchedule)).EndInit();
            this.headerGroupSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSchedule;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupFollowup;
        private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblScheduleInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboFollowUpStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtReaminder;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtScheduleEndDatetime;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtScheduleStartDatetime;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSubject;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLocation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtContactNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtContactPerson;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabStatus;
        private ComponentFactory.Krypton.Navigator.KryptonPage pageNextFollowUp;
        private ComponentFactory.Krypton.Navigator.KryptonPage pageClosed;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtReasonClose;
    }
}