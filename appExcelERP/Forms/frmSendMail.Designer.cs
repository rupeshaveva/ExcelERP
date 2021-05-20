namespace appExcelERP.Forms
{
    partial class frmSendMail
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
            this.btnSendMail = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.lblAssociates = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.txtMessage = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.lblContacts = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.lblEmployees = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.lblParties = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
            this.headerGroupAttachments = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewAttachment = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveAttachment = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAttachments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSubject = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtMailTo = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonBreadCrumbItem1 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonBreadCrumbItem2 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonBreadCrumbItem3 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonContextMenuItems1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuHeading1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading();
            this.kryptonContextMenuItems2 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItems3 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuItems4 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonBreadCrumbItem4 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.kryptonBreadCrumbItem5 = new ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachments.Panel)).BeginInit();
            this.headerGroupAttachments.Panel.SuspendLayout();
            this.headerGroupAttachments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSendMail,
            this.btnCancel});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(7, 6);
            this.kryptonHeaderGroup1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.lblAssociates);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtMessage);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.lblContacts);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.lblEmployees);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.lblParties);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.headerGroupAttachments);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtSubject);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.txtMailTo);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(547, 709);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Compose email";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // btnSendMail
            // 
            this.btnSendMail.Image = global::appExcelERP.Properties.Resources.MailOpen_16x;
            this.btnSendMail.Text = "&Send eMail";
            this.btnSendMail.UniqueName = "D05F11C9853447E7838B332F69F99E75";
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "11CE816D9480473026A43100676C2F93";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblAssociates
            // 
            this.lblAssociates.Location = new System.Drawing.Point(442, 7);
            this.lblAssociates.Margin = new System.Windows.Forms.Padding(4);
            this.lblAssociates.Name = "lblAssociates";
            this.lblAssociates.Size = new System.Drawing.Size(82, 24);
            this.lblAssociates.TabIndex = 10;
            this.lblAssociates.Values.Text = "&Associates";
            this.lblAssociates.LinkClicked += new System.EventHandler(this.ReceipentSelectionLink_Clicked);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(17, 148);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(507, 388);
            this.txtMessage.TabIndex = 8;
            this.txtMessage.Text = "";
            this.txtMessage.Validating += new System.ComponentModel.CancelEventHandler(this.txtMessage_Validating);
            // 
            // lblContacts
            // 
            this.lblContacts.Location = new System.Drawing.Point(361, 63);
            this.lblContacts.Margin = new System.Windows.Forms.Padding(4);
            this.lblContacts.Name = "lblContacts";
            this.lblContacts.Size = new System.Drawing.Size(71, 24);
            this.lblContacts.TabIndex = 3;
            this.lblContacts.Values.Text = "&Contacts";
            this.lblContacts.LinkClicked += new System.EventHandler(this.ReceipentSelectionLink_Clicked);
            // 
            // lblEmployees
            // 
            this.lblEmployees.Location = new System.Drawing.Point(437, 63);
            this.lblEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.lblEmployees.Name = "lblEmployees";
            this.lblEmployees.Size = new System.Drawing.Size(85, 24);
            this.lblEmployees.TabIndex = 4;
            this.lblEmployees.Values.Text = "&Employees";
            this.lblEmployees.LinkClicked += new System.EventHandler(this.ReceipentSelectionLink_Clicked);
            // 
            // lblParties
            // 
            this.lblParties.Location = new System.Drawing.Point(298, 63);
            this.lblParties.Margin = new System.Windows.Forms.Padding(4);
            this.lblParties.Name = "lblParties";
            this.lblParties.Size = new System.Drawing.Size(57, 24);
            this.lblParties.TabIndex = 2;
            this.lblParties.Values.Text = "&Parties";
            this.lblParties.LinkClicked += new System.EventHandler(this.ReceipentSelectionLink_Clicked);
            // 
            // headerGroupAttachments
            // 
            this.headerGroupAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerGroupAttachments.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewAttachment,
            this.btnRemoveAttachment});
            this.headerGroupAttachments.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupAttachments.HeaderVisibleSecondary = false;
            this.headerGroupAttachments.Location = new System.Drawing.Point(17, 543);
            this.headerGroupAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.headerGroupAttachments.Name = "headerGroupAttachments";
            // 
            // headerGroupAttachments.Panel
            // 
            this.headerGroupAttachments.Panel.Controls.Add(this.gridAttachments);
            this.headerGroupAttachments.Size = new System.Drawing.Size(507, 126);
            this.headerGroupAttachments.TabIndex = 9;
            this.headerGroupAttachments.ValuesPrimary.Heading = "Attachments";
            // 
            // btnAddNewAttachment
            // 
            this.btnAddNewAttachment.Image = global::appExcelERP.Properties.Resources.RequestPlugin_16x;
            this.btnAddNewAttachment.Text = "&Add New Attachment";
            this.btnAddNewAttachment.UniqueName = "76FD6E39EFDE4B5359AC6C839956BC0C";
            this.btnAddNewAttachment.Click += new System.EventHandler(this.btnAddNewAttachment_Click);
            // 
            // btnRemoveAttachment
            // 
            this.btnRemoveAttachment.Image = global::appExcelERP.Properties.Resources.VirtualMachineError_16x;
            this.btnRemoveAttachment.Text = "Remove selected";
            this.btnRemoveAttachment.UniqueName = "97BA8DCF87EB4A0E0E9ADD485D62674E";
            this.btnRemoveAttachment.Click += new System.EventHandler(this.btnRemoveAttachment_Click);
            // 
            // gridAttachments
            // 
            this.gridAttachments.AllowUserToAddRows = false;
            this.gridAttachments.AllowUserToDeleteRows = false;
            this.gridAttachments.AllowUserToOrderColumns = true;
            this.gridAttachments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAttachments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAttachments.ColumnHeadersHeight = 28;
            this.gridAttachments.ColumnHeadersVisible = false;
            this.gridAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttachments.Location = new System.Drawing.Point(0, 0);
            this.gridAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.gridAttachments.MultiSelect = false;
            this.gridAttachments.Name = "gridAttachments";
            this.gridAttachments.RowHeadersVisible = false;
            this.gridAttachments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttachments.Size = new System.Drawing.Size(505, 93);
            this.gridAttachments.TabIndex = 0;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel3.Location = new System.Drawing.Point(17, 121);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(110, 24);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Message &Body";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Location = new System.Drawing.Point(17, 91);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(507, 27);
            this.txtSubject.TabIndex = 6;
            this.txtSubject.Validating += new System.ComponentModel.CancelEventHandler(this.txtSubject_Validating);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel2.Location = new System.Drawing.Point(17, 66);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(62, 24);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "&Subject";
            // 
            // txtMailTo
            // 
            this.txtMailTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMailTo.Location = new System.Drawing.Point(17, 33);
            this.txtMailTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMailTo.Name = "txtMailTo";
            this.txtMailTo.Size = new System.Drawing.Size(507, 27);
            this.txtMailTo.TabIndex = 1;
            this.txtMailTo.Validating += new System.ComponentModel.CancelEventHandler(this.txtMailTo_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonLabel1.Location = new System.Drawing.Point(17, 7);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(264, 24);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Send Email to following Receipient(s)";
            // 
            // kryptonBreadCrumbItem1
            // 
            this.kryptonBreadCrumbItem1.ShortText = "Choose from Parties";
            // 
            // kryptonBreadCrumbItem2
            // 
            this.kryptonBreadCrumbItem2.ShortText = "Choose from Employees";
            // 
            // kryptonBreadCrumbItem3
            // 
            this.kryptonBreadCrumbItem3.ShortText = "ListItem";
            // 
            // kryptonContextMenuHeading1
            // 
            this.kryptonContextMenuHeading1.ExtraText = "";
            // 
            // kryptonBreadCrumbItem4
            // 
            this.kryptonBreadCrumbItem4.ShortText = "Parties";
            // 
            // kryptonBreadCrumbItem5
            // 
            this.kryptonBreadCrumbItem5.ShortText = "Employees";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(561, 721);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSendMail";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSendMail_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmSendMail_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachments.Panel)).EndInit();
            this.headerGroupAttachments.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupAttachments)).EndInit();
            this.headerGroupAttachments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSendMail;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupAttachments;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem1;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem2;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem3;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewAttachment;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveAttachment;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems3;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems4;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem4;
        private ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItem kryptonBreadCrumbItem5;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblContacts;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblEmployees;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblParties;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAttachments;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSubject;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtMailTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel lblAssociates;
        public ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtMessage;
    }
}