namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlAttachments
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
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNew = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEdit = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDelete = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.listDocuments = new System.Windows.Forms.ListBox();
            this.listCategories = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.kryptonHeaderGroup1);
            this.splitContainerMain.Panel1.Controls.Add(this.listCategories);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(1195, 558);
            this.splitContainerMain.SplitterDistance = 397;
            this.splitContainerMain.TabIndex = 1;
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNew,
            this.btnEdit,
            this.btnDelete});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderVisibleSecondary = false;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(0, 4);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.listDocuments);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(397, 554);
            this.kryptonHeaderGroup1.TabIndex = 2;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Documents";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // btnAddNew
            // 
            this.btnAddNew.Image = global::appExcelERP.Properties.Resources.Attach_16x;
            this.btnAddNew.Text = "&Add New";
            this.btnAddNew.UniqueName = "9339FDEC1F5E4E151AA5AA47389A6B61";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UniqueName = "AE0416ED1B7343D135BF032DF11CBE74";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::appExcelERP.Properties.Resources.Cancel_16x;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UniqueName = "5A5CA492307848D51283BD9F3D37042D";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // listDocuments
            // 
            this.listDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDocuments.FormattingEnabled = true;
            this.listDocuments.ItemHeight = 16;
            this.listDocuments.Location = new System.Drawing.Point(0, 0);
            this.listDocuments.Name = "listDocuments";
            this.listDocuments.Size = new System.Drawing.Size(395, 525);
            this.listDocuments.TabIndex = 14;
            this.listDocuments.SelectedIndexChanged += new System.EventHandler(this.listDocuments_SelectedValueChanged);
            // 
            // listCategories
            // 
            this.listCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.listCategories.FormattingEnabled = true;
            this.listCategories.ItemHeight = 16;
            this.listCategories.Location = new System.Drawing.Point(0, 0);
            this.listCategories.Name = "listCategories";
            this.listCategories.Size = new System.Drawing.Size(397, 4);
            this.listCategories.TabIndex = 1;
            this.listCategories.Visible = false;
            // 
            // ctrlAttachments
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splitContainerMain);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ctrlAttachments";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1201, 564);
            this.Load += new System.EventHandler(this.ctrlAttachments_Load);
            this.Resize += new System.EventHandler(this.ctrlAttachments_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNew;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEdit;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDelete;
        private System.Windows.Forms.ListBox listDocuments;
        private System.Windows.Forms.ListBox listCategories;
    }
}
