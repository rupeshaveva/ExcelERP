namespace appExcelERP.Forms.CRM.SalesOrder
{
    partial class frmSO_WithoutOrder
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
            this.lblPOSource = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label21 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSalesOrderNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboSalesOrderStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.dtSalesOrderDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboClient = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddClient = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dtMaterialSupplyPoExpiryDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMaterialSupplyPoValidDays = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMaterialSupplyPoNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtMaterialSupplyPoDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.dtInstallationServicePoExpiryDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtInstallationServicePoValidDays = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtInstallationServicePoNo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtInstallationServicePoDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cboPOSource = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesOrderStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).BeginInit();
            this.kryptonHeaderGroup2.Panel.SuspendLayout();
            this.kryptonHeaderGroup2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPOSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPOSource
            // 
            this.lblPOSource.Location = new System.Drawing.Point(11, 41);
            this.lblPOSource.Name = "lblPOSource";
            this.lblPOSource.Size = new System.Drawing.Size(67, 20);
            this.lblPOSource.TabIndex = 4;
            this.lblPOSource.Values.Text = "PO Source";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 0;
            this.label3.Values.Text = "SO No.";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(246, 41);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 20);
            this.label21.TabIndex = 6;
            this.label21.Values.Text = "Status";
            // 
            // txtSalesOrderNo
            // 
            this.txtSalesOrderNo.Location = new System.Drawing.Point(74, 12);
            this.txtSalesOrderNo.Name = "txtSalesOrderNo";
            this.txtSalesOrderNo.ReadOnly = true;
            this.txtSalesOrderNo.Size = new System.Drawing.Size(197, 20);
            this.txtSalesOrderNo.TabIndex = 1;
            this.txtSalesOrderNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtSalesOrderNo_Validating);
            // 
            // cboSalesOrderStatus
            // 
            this.cboSalesOrderStatus.DropDownWidth = 200;
            this.cboSalesOrderStatus.FormattingEnabled = true;
            this.cboSalesOrderStatus.Location = new System.Drawing.Point(295, 41);
            this.cboSalesOrderStatus.Name = "cboSalesOrderStatus";
            this.cboSalesOrderStatus.Size = new System.Drawing.Size(122, 21);
            this.cboSalesOrderStatus.TabIndex = 7;
            this.cboSalesOrderStatus.Validating += new System.ComponentModel.CancelEventHandler(this.cboSalesOrderStatus_Validating);
            // 
            // dtSalesOrderDate
            // 
            this.dtSalesOrderDate.CustomFormat = "dd/MM/yyyy";
            this.dtSalesOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalesOrderDate.Location = new System.Drawing.Point(327, 12);
            this.dtSalesOrderDate.Name = "dtSalesOrderDate";
            this.dtSalesOrderDate.Size = new System.Drawing.Size(90, 21);
            this.dtSalesOrderDate.TabIndex = 3;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(273, 14);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "SO Date";
            // 
            // cboClient
            // 
            this.cboClient.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddClient});
            this.cboClient.DropDownWidth = 121;
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(11, 91);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(406, 24);
            this.cboClient.TabIndex = 9;
            this.cboClient.Validating += new System.ComponentModel.CancelEventHandler(this.cboClient_Validating);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddClient.UniqueName = "FA73FD0F1B07416C07BC069F9BB794F9";
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(11, 68);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(78, 20);
            this.kryptonLabel9.TabIndex = 8;
            this.kryptonLabel9.Values.Text = "Client Name";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(11, 120);
            this.kryptonHeaderGroup1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtMaterialSupplyPoExpiryDate);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel7);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtMaterialSupplyPoValidDays);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel8);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtMaterialSupplyPoNo);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.dtMaterialSupplyPoDate);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.label5);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(406, 92);
            this.kryptonHeaderGroup1.TabIndex = 10;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Material Supply PO";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            // 
            // dtMaterialSupplyPoExpiryDate
            // 
            this.dtMaterialSupplyPoExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.dtMaterialSupplyPoExpiryDate.Enabled = false;
            this.dtMaterialSupplyPoExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMaterialSupplyPoExpiryDate.Location = new System.Drawing.Point(296, 37);
            this.dtMaterialSupplyPoExpiryDate.Name = "dtMaterialSupplyPoExpiryDate";
            this.dtMaterialSupplyPoExpiryDate.Size = new System.Drawing.Size(92, 21);
            this.dtMaterialSupplyPoExpiryDate.TabIndex = 7;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(224, 37);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel7.TabIndex = 6;
            this.kryptonLabel7.Values.Text = "Expiry Date";
            // 
            // txtMaterialSupplyPoValidDays
            // 
            this.txtMaterialSupplyPoValidDays.Location = new System.Drawing.Point(108, 34);
            this.txtMaterialSupplyPoValidDays.MaxLength = 3;
            this.txtMaterialSupplyPoValidDays.Name = "txtMaterialSupplyPoValidDays";
            this.txtMaterialSupplyPoValidDays.Size = new System.Drawing.Size(80, 20);
            this.txtMaterialSupplyPoValidDays.TabIndex = 5;
            this.txtMaterialSupplyPoValidDays.TextChanged += new System.EventHandler(this.txtMaterialSupplyPoValidDays_TextChanged);
            this.txtMaterialSupplyPoValidDays.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaterialSupplyPoValidDays_Validating);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(4, 37);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel8.TabIndex = 4;
            this.kryptonLabel8.Values.Text = "Delivery Deadline";
            // 
            // txtMaterialSupplyPoNo
            // 
            this.txtMaterialSupplyPoNo.Location = new System.Drawing.Point(47, 7);
            this.txtMaterialSupplyPoNo.Name = "txtMaterialSupplyPoNo";
            this.txtMaterialSupplyPoNo.Size = new System.Drawing.Size(204, 20);
            this.txtMaterialSupplyPoNo.TabIndex = 1;
            // 
            // dtMaterialSupplyPoDate
            // 
            this.dtMaterialSupplyPoDate.CustomFormat = "dd/MM/yyyy";
            this.dtMaterialSupplyPoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtMaterialSupplyPoDate.Location = new System.Drawing.Point(296, 9);
            this.dtMaterialSupplyPoDate.Name = "dtMaterialSupplyPoDate";
            this.dtMaterialSupplyPoDate.Size = new System.Drawing.Size(92, 21);
            this.dtMaterialSupplyPoDate.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(260, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 2;
            this.label5.Values.Text = "Date";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(3, 9);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "PO No.";
            // 
            // kryptonHeaderGroup2
            // 
            this.kryptonHeaderGroup2.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup2.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup2.Location = new System.Drawing.Point(11, 216);
            this.kryptonHeaderGroup2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonHeaderGroup2.Name = "kryptonHeaderGroup2";
            // 
            // kryptonHeaderGroup2.Panel
            // 
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.dtInstallationServicePoExpiryDate);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel11);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.txtInstallationServicePoValidDays);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel12);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.txtInstallationServicePoNo);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.dtInstallationServicePoDate);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel5);
            this.kryptonHeaderGroup2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonHeaderGroup2.Size = new System.Drawing.Size(405, 92);
            this.kryptonHeaderGroup2.TabIndex = 11;
            this.kryptonHeaderGroup2.ValuesPrimary.Heading = "Installation/Services PO";
            this.kryptonHeaderGroup2.ValuesPrimary.Image = null;
            // 
            // dtInstallationServicePoExpiryDate
            // 
            this.dtInstallationServicePoExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.dtInstallationServicePoExpiryDate.Enabled = false;
            this.dtInstallationServicePoExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInstallationServicePoExpiryDate.Location = new System.Drawing.Point(296, 36);
            this.dtInstallationServicePoExpiryDate.Name = "dtInstallationServicePoExpiryDate";
            this.dtInstallationServicePoExpiryDate.Size = new System.Drawing.Size(91, 21);
            this.dtInstallationServicePoExpiryDate.TabIndex = 7;
            // 
            // kryptonLabel11
            // 
            this.kryptonLabel11.Location = new System.Drawing.Point(227, 36);
            this.kryptonLabel11.Name = "kryptonLabel11";
            this.kryptonLabel11.Size = new System.Drawing.Size(72, 20);
            this.kryptonLabel11.TabIndex = 6;
            this.kryptonLabel11.Values.Text = "Expiry Date";
            // 
            // txtInstallationServicePoValidDays
            // 
            this.txtInstallationServicePoValidDays.Location = new System.Drawing.Point(130, 34);
            this.txtInstallationServicePoValidDays.MaxLength = 3;
            this.txtInstallationServicePoValidDays.Name = "txtInstallationServicePoValidDays";
            this.txtInstallationServicePoValidDays.Size = new System.Drawing.Size(80, 20);
            this.txtInstallationServicePoValidDays.TabIndex = 5;
            this.txtInstallationServicePoValidDays.TextChanged += new System.EventHandler(this.txtInstallationServicePoValidDays_TextChanged);
            this.txtInstallationServicePoValidDays.Validating += new System.ComponentModel.CancelEventHandler(this.txtInstallationServicePoValidDays_Validating);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Location = new System.Drawing.Point(8, 36);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(126, 20);
            this.kryptonLabel12.TabIndex = 4;
            this.kryptonLabel12.Values.Text = "Completion Deadline";
            // 
            // txtInstallationServicePoNo
            // 
            this.txtInstallationServicePoNo.Location = new System.Drawing.Point(48, 8);
            this.txtInstallationServicePoNo.Name = "txtInstallationServicePoNo";
            this.txtInstallationServicePoNo.Size = new System.Drawing.Size(206, 20);
            this.txtInstallationServicePoNo.TabIndex = 1;
            // 
            // dtInstallationServicePoDate
            // 
            this.dtInstallationServicePoDate.CustomFormat = "dd/MM/yyyy";
            this.dtInstallationServicePoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInstallationServicePoDate.Location = new System.Drawing.Point(296, 7);
            this.dtInstallationServicePoDate.Name = "dtInstallationServicePoDate";
            this.dtInstallationServicePoDate.Size = new System.Drawing.Size(91, 21);
            this.dtInstallationServicePoDate.TabIndex = 3;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(260, 9);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel5.TabIndex = 2;
            this.kryptonLabel5.Values.Text = "Date";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(3, 8);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(49, 20);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "PO No.";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(308, 317);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(202, 317);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 28);
            this.btnOK.TabIndex = 12;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboPOSource
            // 
            this.cboPOSource.DropDownWidth = 200;
            this.cboPOSource.FormattingEnabled = true;
            this.cboPOSource.Location = new System.Drawing.Point(74, 41);
            this.cboPOSource.Name = "cboPOSource";
            this.cboPOSource.Size = new System.Drawing.Size(166, 21);
            this.cboPOSource.TabIndex = 5;
            this.cboPOSource.Validating += new System.ComponentModel.CancelEventHandler(this.cboPOSource_Validating);
            // 
            // frmSO_WithoutOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(435, 364);
            this.Controls.Add(this.cboPOSource);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.kryptonHeaderGroup2);
            this.Controls.Add(this.cboClient);
            this.Controls.Add(this.kryptonLabel9);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtSalesOrderNo);
            this.Controls.Add(this.cboSalesOrderStatus);
            this.Controls.Add(this.dtSalesOrderDate);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPOSource);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSO_WithoutOrder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit SO (without Order)";
            this.Load += new System.EventHandler(this.frmSO_WithoutOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSalesOrderStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2.Panel)).EndInit();
            this.kryptonHeaderGroup2.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup2)).EndInit();
            this.kryptonHeaderGroup2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPOSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPOSource;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label21;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSalesOrderNo;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSalesOrderStatus;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtSalesOrderDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboClient;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddClient;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtMaterialSupplyPoExpiryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMaterialSupplyPoValidDays;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMaterialSupplyPoNo;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtMaterialSupplyPoDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtInstallationServicePoExpiryDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtInstallationServicePoValidDays;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtInstallationServicePoNo;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtInstallationServicePoDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboPOSource;
    }
}