namespace appExcelERP.Forms.HR
{
    partial class frmApproveRejectLeave
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
            this.dtLeaveApplicationDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLeaveApplicationNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelLeaveDescription = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.rbtnApproveLeave = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbtnRejectLeave = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.txtLeaveDescription = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtApprovalRemarks = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.SuspendLayout();
            // 
            // dtLeaveApplicationDate
            // 
            this.dtLeaveApplicationDate.CustomFormat = "dd/MM/yyyy";
            this.dtLeaveApplicationDate.Enabled = false;
            this.dtLeaveApplicationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLeaveApplicationDate.Location = new System.Drawing.Point(331, 30);
            this.dtLeaveApplicationDate.Name = "dtLeaveApplicationDate";
            this.dtLeaveApplicationDate.Size = new System.Drawing.Size(97, 20);
            this.dtLeaveApplicationDate.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(387, 10);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Date";
            // 
            // txtLeaveApplicationNo
            // 
            this.txtLeaveApplicationNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveApplicationNo.Location = new System.Drawing.Point(12, 29);
            this.txtLeaveApplicationNo.Name = "txtLeaveApplicationNo";
            this.txtLeaveApplicationNo.ReadOnly = true;
            this.txtLeaveApplicationNo.Size = new System.Drawing.Size(300, 20);
            this.txtLeaveApplicationNo.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeaveApplicationNo.TabIndex = 1;
            this.txtLeaveApplicationNo.Text = "sdfsdf";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 0;
            this.label1.Values.Text = "Leave Application No.";
            // 
            // labelLeaveDescription
            // 
            this.labelLeaveDescription.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeaveDescription.ForeColor = System.Drawing.Color.Black;
            this.labelLeaveDescription.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.labelLeaveDescription.Location = new System.Drawing.Point(12, 58);
            this.labelLeaveDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelLeaveDescription.Name = "labelLeaveDescription";
            this.labelLeaveDescription.Size = new System.Drawing.Size(77, 20);
            this.labelLeaveDescription.TabIndex = 4;
            this.labelLeaveDescription.Values.Text = "Description";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 213);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(177, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "Approval/Rejection Remarks";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(348, 308);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 11;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(258, 308);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 25);
            this.btnSave.TabIndex = 10;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // rbtnApproveLeave
            // 
            this.rbtnApproveLeave.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnApproveLeave.Location = new System.Drawing.Point(212, 208);
            this.rbtnApproveLeave.Name = "rbtnApproveLeave";
            this.rbtnApproveLeave.Size = new System.Drawing.Size(109, 20);
            this.rbtnApproveLeave.TabIndex = 6;
            this.rbtnApproveLeave.Values.Text = "&Approve Leave";
            // 
            // rbtnRejectLeave
            // 
            this.rbtnRejectLeave.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnRejectLeave.Location = new System.Drawing.Point(328, 208);
            this.rbtnRejectLeave.Name = "rbtnRejectLeave";
            this.rbtnRejectLeave.Size = new System.Drawing.Size(95, 20);
            this.rbtnRejectLeave.TabIndex = 7;
            this.rbtnRejectLeave.Values.Text = "&Reject Leave";
            // 
            // txtLeaveDescription
            // 
            this.txtLeaveDescription.Location = new System.Drawing.Point(12, 78);
            this.txtLeaveDescription.Name = "txtLeaveDescription";
            this.txtLeaveDescription.ReadOnly = true;
            this.txtLeaveDescription.Size = new System.Drawing.Size(416, 126);
            this.txtLeaveDescription.TabIndex = 5;
            this.txtLeaveDescription.Text = "kryptonRichTextBox1";
            // 
            // txtApprovalRemarks
            // 
            this.txtApprovalRemarks.Location = new System.Drawing.Point(12, 234);
            this.txtApprovalRemarks.Name = "txtApprovalRemarks";
            this.txtApprovalRemarks.Size = new System.Drawing.Size(416, 69);
            this.txtApprovalRemarks.TabIndex = 9;
            this.txtApprovalRemarks.Text = "kryptonRichTextBox2";
            // 
            // frmApproveRejectLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(442, 339);
            this.ControlBox = false;
            this.Controls.Add(this.txtApprovalRemarks);
            this.Controls.Add(this.txtLeaveDescription);
            this.Controls.Add(this.rbtnRejectLeave);
            this.Controls.Add(this.rbtnApproveLeave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtLeaveApplicationDate);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtLeaveApplicationNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLeaveDescription);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApproveRejectLeave";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approve/Reject Leave";
            this.Load += new System.EventHandler(this.frmApproveRejectLeave_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtLeaveApplicationDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLeaveApplicationNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelLeaveDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnApproveLeave;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnRejectLeave;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtLeaveDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtApprovalRemarks;
    }
}