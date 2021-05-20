namespace appExcelERP.Forms
{
    partial class frmSelectParty
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
            this.headerGroupCompany = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewCompany = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.cboCompanies = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewContact = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridContacts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany.Panel)).BeginInit();
            this.headerGroupCompany.Panel.SuspendLayout();
            this.headerGroupCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupCompany
            // 
            this.headerGroupCompany.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewCompany});
            this.headerGroupCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupCompany.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupCompany.HeaderVisibleSecondary = false;
            this.headerGroupCompany.Location = new System.Drawing.Point(10, 10);
            this.headerGroupCompany.Name = "headerGroupCompany";
            // 
            // headerGroupCompany.Panel
            // 
            this.headerGroupCompany.Panel.Controls.Add(this.cboCompanies);
            this.headerGroupCompany.Size = new System.Drawing.Size(546, 52);
            this.headerGroupCompany.TabIndex = 6;
            this.headerGroupCompany.ValuesPrimary.Heading = "Company Name";
            // 
            // btnAddNewCompany
            // 
            this.btnAddNewCompany.Text = "&Add New Company";
            this.btnAddNewCompany.UniqueName = "A1AE3A41EA7E4C02749AF846D9DFA57B";
            this.btnAddNewCompany.Click += new System.EventHandler(this.btnAddNewCompany_Click);
            // 
            // cboCompanies
            // 
            this.cboCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCompanies.DropDownWidth = 296;
            this.cboCompanies.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompanies.FormattingEnabled = true;
            this.cboCompanies.Location = new System.Drawing.Point(0, 0);
            this.cboCompanies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboCompanies.Name = "cboCompanies";
            this.cboCompanies.Size = new System.Drawing.Size(544, 21);
            this.cboCompanies.TabIndex = 6;
            this.cboCompanies.SelectedIndexChanged += new System.EventHandler(this.cboCompanies_SelectedIndexChanged);
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewContact,
            this.btnOK,
            this.btnCancel});
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(10, 70);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.gridContacts);
            this.kryptonHeaderGroup1.Panel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.kryptonHeaderGroup1.Panel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(546, 211);
            this.kryptonHeaderGroup1.TabIndex = 7;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Company Contacts";
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // btnAddNewContact
            // 
            this.btnAddNewContact.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnAddNewContact.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnAddNewContact.Text = "&Add New Contact";
            this.btnAddNewContact.UniqueName = "A1AE3A41EA7E4C02749AF846D9DFA57B";
            this.btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click);
            // 
            // btnOK
            // 
            this.btnOK.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnOK.Text = "&OK";
            this.btnOK.UniqueName = "C8CCD1FD24044BD3BB8410F928EC4008";
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "111DD6A13D7249C3C981E32A65D80CD7";
            // 
            // gridContacts
            // 
            this.gridContacts.AllowUserToAddRows = false;
            this.gridContacts.AllowUserToDeleteRows = false;
            this.gridContacts.AllowUserToOrderColumns = true;
            this.gridContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridContacts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridContacts.ColumnHeadersHeight = 28;
            this.gridContacts.ColumnHeadersVisible = false;
            this.gridContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridContacts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridContacts.Location = new System.Drawing.Point(5, 5);
            this.gridContacts.Name = "gridContacts";
            this.gridContacts.ReadOnly = true;
            this.gridContacts.RowHeadersVisible = false;
            this.gridContacts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridContacts.Size = new System.Drawing.Size(534, 150);
            this.gridContacts.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSelectParty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 289);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.Controls.Add(this.headerGroupCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelectParty";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Party";
            this.Load += new System.EventHandler(this.frmSelectParty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany.Panel)).EndInit();
            this.headerGroupCompany.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupCompany)).EndInit();
            this.headerGroupCompany.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridContacts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupCompany;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewCompany;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewContact;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnOK;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridContacts;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCompanies;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}