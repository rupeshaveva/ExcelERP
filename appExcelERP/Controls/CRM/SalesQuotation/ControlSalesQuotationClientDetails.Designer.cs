namespace appExcelERP.Controls.CRM
{
    partial class ControlSalesQuotationClientDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridConsultantContacts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupClient = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddClientContacts = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridCompanyContacts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtClientInfo = new System.Windows.Forms.RichTextBox();
            this.headerGroupConsultant = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddConsultantContacts = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtConsultantInfo = new System.Windows.Forms.RichTextBox();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateContacts = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsultantContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupClient.Panel)).BeginInit();
            this.headerGroupClient.Panel.SuspendLayout();
            this.headerGroupClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanyContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupConsultant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupConsultant.Panel)).BeginInit();
            this.headerGroupConsultant.Panel.SuspendLayout();
            this.headerGroupConsultant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridConsultantContacts
            // 
            this.gridConsultantContacts.AllowUserToAddRows = false;
            this.gridConsultantContacts.AllowUserToDeleteRows = false;
            this.gridConsultantContacts.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridConsultantContacts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridConsultantContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridConsultantContacts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridConsultantContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConsultantContacts.ColumnHeadersVisible = false;
            this.gridConsultantContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConsultantContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridConsultantContacts.Location = new System.Drawing.Point(0, 83);
            this.gridConsultantContacts.MultiSelect = false;
            this.gridConsultantContacts.Name = "gridConsultantContacts";
            this.gridConsultantContacts.ReadOnly = true;
            this.gridConsultantContacts.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridConsultantContacts.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridConsultantContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridConsultantContacts.Size = new System.Drawing.Size(372, 162);
            this.gridConsultantContacts.TabIndex = 20;
            this.gridConsultantContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridConsultantContacts_CellClick);
            this.gridConsultantContacts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridConsultantContacts_DataBindingComplete);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.ContainerBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.HeaderSecondary;
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupClient);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupConsultant);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(722, 298);
            this.splitContainerMain.SplitterDistance = 341;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 0;
            // 
            // headerGroupClient
            // 
            this.headerGroupClient.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddClientContacts});
            this.headerGroupClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupClient.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupClient.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupClient.Location = new System.Drawing.Point(0, 0);
            this.headerGroupClient.Name = "headerGroupClient";
            // 
            // headerGroupClient.Panel
            // 
            this.headerGroupClient.Panel.Controls.Add(this.gridCompanyContacts);
            this.headerGroupClient.Panel.Controls.Add(this.txtClientInfo);
            this.headerGroupClient.Panel.Padding = new System.Windows.Forms.Padding(3);
            this.headerGroupClient.Size = new System.Drawing.Size(341, 298);
            this.headerGroupClient.TabIndex = 0;
            this.headerGroupClient.ValuesPrimary.Heading = "CLIENT:";
            this.headerGroupClient.ValuesPrimary.Image = null;
            this.headerGroupClient.ValuesSecondary.Heading = "";
            // 
            // btnAddClientContacts
            // 
            this.btnAddClientContacts.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnAddClientContacts.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Alternate;
            this.btnAddClientContacts.Text = "&Add New Client Contact ";
            this.btnAddClientContacts.UniqueName = "785DDFE4824F4533EA9FE47529E89212";
            this.btnAddClientContacts.Click += new System.EventHandler(this.btnAddClientContacts_Click);
            // 
            // gridCompanyContacts
            // 
            this.gridCompanyContacts.AllowUserToAddRows = false;
            this.gridCompanyContacts.AllowUserToDeleteRows = false;
            this.gridCompanyContacts.AllowUserToResizeColumns = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCompanyContacts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridCompanyContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCompanyContacts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridCompanyContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCompanyContacts.ColumnHeadersVisible = false;
            this.gridCompanyContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCompanyContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCompanyContacts.Location = new System.Drawing.Point(3, 83);
            this.gridCompanyContacts.MultiSelect = false;
            this.gridCompanyContacts.Name = "gridCompanyContacts";
            this.gridCompanyContacts.ReadOnly = true;
            this.gridCompanyContacts.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCompanyContacts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridCompanyContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCompanyContacts.Size = new System.Drawing.Size(333, 159);
            this.gridCompanyContacts.TabIndex = 19;
            this.gridCompanyContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCompanyContacts_CellClick);
            this.gridCompanyContacts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridCompanyContacts_DataBindingComplete);
            // 
            // txtClientInfo
            // 
            this.txtClientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtClientInfo.Location = new System.Drawing.Point(3, 3);
            this.txtClientInfo.Name = "txtClientInfo";
            this.txtClientInfo.Size = new System.Drawing.Size(333, 80);
            this.txtClientInfo.TabIndex = 0;
            this.txtClientInfo.Text = "";
            // 
            // headerGroupConsultant
            // 
            this.headerGroupConsultant.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddConsultantContacts});
            this.headerGroupConsultant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupConsultant.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupConsultant.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupConsultant.Location = new System.Drawing.Point(0, 0);
            this.headerGroupConsultant.Name = "headerGroupConsultant";
            // 
            // headerGroupConsultant.Panel
            // 
            this.headerGroupConsultant.Panel.Controls.Add(this.gridConsultantContacts);
            this.headerGroupConsultant.Panel.Controls.Add(this.txtConsultantInfo);
            this.headerGroupConsultant.Size = new System.Drawing.Size(374, 298);
            this.headerGroupConsultant.TabIndex = 1;
            this.headerGroupConsultant.ValuesPrimary.Heading = "CONSULTANT:";
            this.headerGroupConsultant.ValuesPrimary.Image = null;
            this.headerGroupConsultant.ValuesSecondary.Heading = "";
            // 
            // btnAddConsultantContacts
            // 
            this.btnAddConsultantContacts.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnAddConsultantContacts.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Alternate;
            this.btnAddConsultantContacts.Text = "&Add New Consultant Contact";
            this.btnAddConsultantContacts.UniqueName = "785DDFE4824F4533EA9FE47529E89212";
            this.btnAddConsultantContacts.Click += new System.EventHandler(this.btnAddConsultantContacts_Click);
            // 
            // txtConsultantInfo
            // 
            this.txtConsultantInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtConsultantInfo.Location = new System.Drawing.Point(0, 0);
            this.txtConsultantInfo.Name = "txtConsultantInfo";
            this.txtConsultantInfo.Size = new System.Drawing.Size(372, 83);
            this.txtConsultantInfo.TabIndex = 1;
            this.txtConsultantInfo.Text = "";
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateContacts});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.splitContainerMain);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(724, 350);
            this.kryptonHeaderGroup1.TabIndex = 2;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Client\'s & Consultant/Agent\'s Contacts Information";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = ".";
            // 
            // btnUpdateContacts
            // 
            this.btnUpdateContacts.Style = ComponentFactory.Krypton.Toolkit.PaletteButtonStyle.Standalone;
            this.btnUpdateContacts.Text = "&Update Contacts";
            this.btnUpdateContacts.UniqueName = "CF63CEAD1C024A34159D6D967A0DA0B7";
            this.btnUpdateContacts.Click += new System.EventHandler(this.btnUpdateContacts_Click);
            // 
            // ControlSalesQuotationClientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Name = "ControlSalesQuotationClientDetails";
            this.Size = new System.Drawing.Size(724, 350);
            ((System.ComponentModel.ISupportInitialize)(this.gridConsultantContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupClient.Panel)).EndInit();
            this.headerGroupClient.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupClient)).EndInit();
            this.headerGroupClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanyContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupConsultant.Panel)).EndInit();
            this.headerGroupConsultant.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupConsultant)).EndInit();
            this.headerGroupConsultant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridConsultantContacts;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupClient;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddClientContacts;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCompanyContacts;
        private System.Windows.Forms.RichTextBox txtClientInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupConsultant;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddConsultantContacts;
        private System.Windows.Forms.RichTextBox txtConsultantInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateContacts;
    }
}
