namespace appExcelERP.Forms.HR
{
    partial class frmApproveRejectLoanRequest
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
            this.txtApprovedAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtApprovalRemarks = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtLoanRequestDescription = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.rbtnRejectLoanRequest = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbtnApproveLoanRequest = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtApprovalDate = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtLoanRequestNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelLeaveDescription = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtApprovedAmount
            // 
            this.txtApprovedAmount.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedAmount.Location = new System.Drawing.Point(302, 171);
            this.txtApprovedAmount.Name = "txtApprovedAmount";
            this.txtApprovedAmount.Size = new System.Drawing.Size(73, 20);
            this.txtApprovedAmount.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApprovedAmount.TabIndex = 39;
            this.txtApprovedAmount.Text = "0.00";
            this.txtApprovedAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtApprovedAmount.Validating += new System.ComponentModel.CancelEventHandler(this.txtApprovedAmount_Validating);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel3.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel3.Location = new System.Drawing.Point(242, 171);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel3.TabIndex = 38;
            this.kryptonLabel3.Values.Text = "Amount";
            // 
            // txtApprovalRemarks
            // 
            this.txtApprovalRemarks.Location = new System.Drawing.Point(14, 215);
            this.txtApprovalRemarks.Name = "txtApprovalRemarks";
            this.txtApprovalRemarks.Size = new System.Drawing.Size(363, 76);
            this.txtApprovalRemarks.TabIndex = 35;
            this.txtApprovalRemarks.Text = "kryptonRichTextBox2";
            // 
            // txtLoanRequestDescription
            // 
            this.txtLoanRequestDescription.Location = new System.Drawing.Point(12, 78);
            this.txtLoanRequestDescription.Name = "txtLoanRequestDescription";
            this.txtLoanRequestDescription.ReadOnly = true;
            this.txtLoanRequestDescription.Size = new System.Drawing.Size(363, 55);
            this.txtLoanRequestDescription.TabIndex = 31;
            this.txtLoanRequestDescription.Text = "kryptonRichTextBox1";
            // 
            // rbtnRejectLoanRequest
            // 
            this.rbtnRejectLoanRequest.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnRejectLoanRequest.Location = new System.Drawing.Point(189, 139);
            this.rbtnRejectLoanRequest.Name = "rbtnRejectLoanRequest";
            this.rbtnRejectLoanRequest.Size = new System.Drawing.Size(108, 20);
            this.rbtnRejectLoanRequest.TabIndex = 33;
            this.rbtnRejectLoanRequest.Values.Text = "&Reject Request";
            // 
            // rbtnApproveLoanRequest
            // 
            this.rbtnApproveLoanRequest.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.rbtnApproveLoanRequest.Location = new System.Drawing.Point(47, 139);
            this.rbtnApproveLoanRequest.Name = "rbtnApproveLoanRequest";
            this.rbtnApproveLoanRequest.Size = new System.Drawing.Size(123, 20);
            this.rbtnApproveLoanRequest.TabIndex = 32;
            this.rbtnApproveLoanRequest.Values.Text = "&Approve Request";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(294, 296);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 24);
            this.btnClose.TabIndex = 37;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(204, 296);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 36;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtApprovalDate
            // 
            this.dtApprovalDate.CustomFormat = "dd/MM/yyyy";
            this.dtApprovalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtApprovalDate.Location = new System.Drawing.Point(127, 171);
            this.dtApprovalDate.Name = "dtApprovalDate";
            this.dtApprovalDate.Size = new System.Drawing.Size(97, 20);
            this.dtApprovalDate.TabIndex = 29;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel2.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 171);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(114, 20);
            this.kryptonLabel2.TabIndex = 28;
            this.kryptonLabel2.Values.Text = "Dt. Approve/Reject";
            // 
            // txtLoanRequestNo
            // 
            this.txtLoanRequestNo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanRequestNo.Location = new System.Drawing.Point(12, 29);
            this.txtLoanRequestNo.Name = "txtLoanRequestNo";
            this.txtLoanRequestNo.ReadOnly = true;
            this.txtLoanRequestNo.Size = new System.Drawing.Size(363, 20);
            this.txtLoanRequestNo.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanRequestNo.TabIndex = 27;
            this.txtLoanRequestNo.Text = "sdfsdf";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 26;
            this.label1.Values.Text = "Loan Request No. && Date";
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
            this.labelLeaveDescription.TabIndex = 30;
            this.labelLeaveDescription.Values.Text = "Description";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonLabel1.ForeColor = System.Drawing.Color.Black;
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 194);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(165, 20);
            this.kryptonLabel1.TabIndex = 34;
            this.kryptonLabel1.Values.Text = "Approval/Rejection Remarks";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmApproveRejectLoanRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(393, 346);
            this.Controls.Add(this.txtApprovedAmount);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtApprovalRemarks);
            this.Controls.Add(this.txtLoanRequestDescription);
            this.Controls.Add(this.rbtnRejectLoanRequest);
            this.Controls.Add(this.rbtnApproveLoanRequest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtApprovalDate);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtLoanRequestNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLeaveDescription);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmApproveRejectLoanRequest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmApproveRejectLoanRequest";
            this.Load += new System.EventHandler(this.frmApproveRejectLoanRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtApprovedAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtApprovalRemarks;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtLoanRequestDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnRejectLoanRequest;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnApproveLoanRequest;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private System.Windows.Forms.DateTimePicker dtApprovalDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtLoanRequestNo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel labelLeaveDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}