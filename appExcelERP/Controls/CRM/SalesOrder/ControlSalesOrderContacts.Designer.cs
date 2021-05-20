namespace appExcelERP.Controls.CRM.SalesOrder
{
    partial class ControlSalesOrderContacts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateContacts = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridCompanyContacts = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtClientInfo = new System.Windows.Forms.RichTextBox();
            this.btnAddNewContact = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanyContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewContact,
            this.btnUpdateContacts});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.gridCompanyContacts);
            this.headerGroupMain.Panel.Controls.Add(this.txtClientInfo);
            this.headerGroupMain.Size = new System.Drawing.Size(969, 604);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnUpdateContacts
            // 
            this.btnUpdateContacts.Text = "&Update Contacts Selection";
            this.btnUpdateContacts.UniqueName = "37C0D9E6249C4E2743813D035172DB1B";
            this.btnUpdateContacts.Click += new System.EventHandler(this.btnUpdateContacts_Click);
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
            this.gridCompanyContacts.Location = new System.Drawing.Point(0, 98);
            this.gridCompanyContacts.Margin = new System.Windows.Forms.Padding(4);
            this.gridCompanyContacts.MultiSelect = false;
            this.gridCompanyContacts.Name = "gridCompanyContacts";
            this.gridCompanyContacts.ReadOnly = true;
            this.gridCompanyContacts.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCompanyContacts.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.gridCompanyContacts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCompanyContacts.Size = new System.Drawing.Size(967, 443);
            this.gridCompanyContacts.TabIndex = 21;
            this.gridCompanyContacts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCompanyContacts_CellClick);
            this.gridCompanyContacts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridCompanyContacts_DataBindingComplete);
            // 
            // txtClientInfo
            // 
            this.txtClientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtClientInfo.Location = new System.Drawing.Point(0, 0);
            this.txtClientInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtClientInfo.Name = "txtClientInfo";
            this.txtClientInfo.Size = new System.Drawing.Size(967, 98);
            this.txtClientInfo.TabIndex = 20;
            this.txtClientInfo.Text = "";
            // 
            // btnAddNewContact
            // 
            this.btnAddNewContact.Text = "&Add New Contact";
            this.btnAddNewContact.UniqueName = "C2B8ED184A66491F84A597051624ECED";
            this.btnAddNewContact.Click += new System.EventHandler(this.btnAddNewContact_Click);
            // 
            // ControlSalesOrderContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "ControlSalesOrderContacts";
            this.Size = new System.Drawing.Size(969, 604);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanyContacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateContacts;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridCompanyContacts;
        private System.Windows.Forms.RichTextBox txtClientInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewContact;
    }
}
