namespace appExcelERP.Forms.HR
{
    partial class frmApproveRejectAdvanceRequest
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
            this.txtApprovalRemarks = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtAdvanceRequestDescription = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.rbtnRejectAdvanceRequest = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbtnApproveAdvanceRequest = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtApprovalDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAdvanceRequestNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelLeaveDescription = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtApprovedAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtApprovalRemarks
            // 
            this.txtApprovalRemarks.Location = new System.Drawing.Point(17, 218);
            this.txtApprovalRemarks.Name = "txtApprovalRemarks";
            this.txtApprovalRemarks.Size = new System.Drawing.Size(363, 76);
            this.txtApprovalRemarks.TabIndex = 21;
            this.txtApprovalRemarks.Text = "kryptonRichTextBox2";
            // 
            // txtAdvanceRequestDescription
            // 
            this.txtAdvanceRequestDescription.Location = new System.Drawing.Point(15, 81);
            this.txtAdvanceRequestDescription.Name = "txtAdvanceRequestDescription";
            this.txtAdvanceRequestDescription.ReadOnly = true;
            this.txtAdvanceRequestDescription.Size = new System.Drawing.Size(363, 55);
            this.txtAdvanceRequestDescription.TabIndex = 17;
            this.txtAdvanceRequestDescription.Text = "kryptonRichTextBox1";
            // 
            // rbtnRejectAdvanceRequest
            // 
            this.rbtnRejectAdvanceRequest.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnRejectAdvanceRequest.Location = new System.Drawing.Point(192, 142);
            this.rbtnRejectAdvanceRequest.Name = "rbtnRejectAdvanceRequest";
            this.rbtnRejectAdvanceRequest.Size = new System.Drawing.Size(108, 20);
            this.rbtnRejectAdvanceRequest.TabIndex = 19;
            this.rbtnRejectAdvanceRequest.Values.Text = "&Reject Request";
            // 
            // rbtnApproveAdvanceRequest
            // 
            this.rbtnApproveAdvanceRequest.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnApproveAdvanceRequest.Location = new System.Drawing.Point(50, 142);
            this.rbtnApproveAdvanceRequest.Name = "rbtnApproveAdvanceRequest";
            this.rbtnApproveAdvanceRequest.Size = new System.Drawing.Size(123, 20);
            this.rbtnApproveAdvanceRequest.TabIndex = 18;
            this.rbtnApproveAdvanceRequest.Values.Text = "&Approve Request";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(297, 299);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 24);
            this.btnClose.TabIndex = 23;
            this.btnClose.Values.Text = "&Cancel";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(207, 299);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 22;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtApprovalDate
            // 
            this.dtApprovalDate.CustomFormat = "dd/MM/yyyy";
            this.dtApprovalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtApprovalDate.Location = new System.Drawing.Point(130, 174);
            this.dtApprovalDate.Name = "dtApprovalDate";
            this.dtApprovalDate.Size = new System.Drawing.Size(97, 20);
            this.dtApprovalDate.TabIndex = 15;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.Location = new System.Drawing.Point(15, 174);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(114, 20);
            this.kryptonLabel2.TabIndex = 14;
            this.kryptonLabel2.Values.Text = "Dt. Approve/Reject";
            // 
            // txtAdvanceRequestNo
            // 
            this.txtAdvanceRequestNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvanceRequestNo.Location = new System.Drawing.Point(15, 32);
            this.txtAdvanceRequestNo.Name = "txtAdvanceRequestNo";
            this.txtAdvanceRequestNo.ReadOnly = true;
            this.txtAdvanceRequestNo.Size = new System.Drawing.Size(363, 20);
            this.txtAdvanceRequestNo.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvanceRequestNo.TabIndex = 13;
            this.txtAdvanceRequestNo.Text = "sdfsdf";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 12;
            this.label1.Values.Text = "Advance Request No. && Date";
            // 
            // labelLeaveDescription
            // 
            this.labelLeaveDescription.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLeaveDescription.ForeColor = System.Drawing.Color.Black;
            this.labelLeaveDescription.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.labelLeaveDescription.Location = new System.Drawing.Point(15, 61);
            this.labelLeaveDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.labelLeaveDescription.Name = "labelLeaveDescription";
            this.labelLeaveDescription.Size = new System.Drawing.Size(77, 20);
            this.labelLeaveDescription.TabIndex = 16;
            this.labelLeaveDescription.Values.Text = "Description";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(17, 197);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(165, 20);
            this.kryptonLabel1.TabIndex = 20;
            this.kryptonLabel1.Values.Text = "Approval/Rejection Remarks";
            // 
            // txtApprovedAmount
            // 
            this.txtApprovedAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedAmount.Location = new System.Drawing.Point(305, 174);
            this.txtApprovedAmount.Name = "txtApprovedAmount";
            this.txtApprovedAmount.Size = new System.Drawing.Size(73, 20);
            this.txtApprovedAmount.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedAmount.TabIndex = 25;
            this.txtApprovedAmount.Text = "0.00";
            this.txtApprovedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtApprovedAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtApprovedAmount_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(245, 174);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel3.TabIndex = 24;
            this.kryptonLabel3.Values.Text = "Amount";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmApproveRejectAdvanceRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(399, 341);
            this.Controls.Add(this.txtApprovedAmount);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtApprovalRemarks);
            this.Controls.Add(this.txtAdvanceRequestDescription);
            this.Controls.Add(this.rbtnRejectAdvanceRequest);
            this.Controls.Add(this.rbtnApproveAdvanceRequest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtApprovalDate);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtAdvanceRequestNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLeaveDescription);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApproveRejectAdvanceRequest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Approve/Reject Advance Request";
            this.Load += new System.EventHandler(this.frmApproveRejectAdvanceRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtApprovalRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtAdvanceRequestDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnRejectAdvanceRequest;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnApproveAdvanceRequest;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private System.Windows.Forms.DateTimePicker dtApprovalDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAdvanceRequestNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelLeaveDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtApprovedAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}