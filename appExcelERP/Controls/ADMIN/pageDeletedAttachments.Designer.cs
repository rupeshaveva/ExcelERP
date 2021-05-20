namespace appExcelERP.Controls.ADMIN
{
    partial class pageDeletedAttachments
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
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.cboDocumentFor = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.headerGroupDeleteInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUndeleteAtachment = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtDeleteRemark = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.txtSearchAttachments = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnSearch = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.gridAttachments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumentFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteInfo.Panel)).BeginInit();
            this.headerGroupDeleteInfo.Panel.SuspendLayout();
            this.headerGroupDeleteInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachments)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(534, 23);
            this.kryptonHeader1.TabIndex = 0;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "Deleted Attachments";
            this.kryptonHeader1.Values.Image = null;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 23);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.gridAttachments);
            this.splitContainerMain.Panel1.Controls.Add(this.txtSearchAttachments);
            this.splitContainerMain.Panel1.Controls.Add(this.cboDocumentFor);
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupDeleteInfo);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(534, 272);
            this.splitContainerMain.SplitterDistance = 178;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 1;
            // 
            // cboDocumentFor
            // 
            this.cboDocumentFor.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboDocumentFor.DropDownWidth = 178;
            this.cboDocumentFor.Location = new System.Drawing.Point(0, 0);
            this.cboDocumentFor.Name = "cboDocumentFor";
            this.cboDocumentFor.Size = new System.Drawing.Size(178, 21);
            this.cboDocumentFor.TabIndex = 7;
            this.cboDocumentFor.Text = "kryptonComboBox1";
            this.cboDocumentFor.SelectedValueChanged += new System.EventHandler(this.cboDocumentFor_SelectedValueChanged);
            // 
            // headerGroupDeleteInfo
            // 
            this.headerGroupDeleteInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUndeleteAtachment});
            this.headerGroupDeleteInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.headerGroupDeleteInfo.Enabled = false;
            this.headerGroupDeleteInfo.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDeleteInfo.Location = new System.Drawing.Point(0, 140);
            this.headerGroupDeleteInfo.Name = "headerGroupDeleteInfo";
            // 
            // headerGroupDeleteInfo.Panel
            // 
            this.headerGroupDeleteInfo.Panel.Controls.Add(this.txtDeleteRemark);
            this.headerGroupDeleteInfo.Size = new System.Drawing.Size(178, 132);
            this.headerGroupDeleteInfo.TabIndex = 0;
            this.headerGroupDeleteInfo.ValuesPrimary.Image = null;
            this.headerGroupDeleteInfo.ValuesSecondary.Heading = "";
            // 
            // btnUndeleteAtachment
            // 
            this.btnUndeleteAtachment.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnUndeleteAtachment.Text = "&Restore Attachment";
            this.btnUndeleteAtachment.UniqueName = "67EE336BEE3F405054AFDD062AF9EDD8";
            this.btnUndeleteAtachment.Click += new System.EventHandler(this.btnUndeleteAtachment_Click);
            // 
            // txtDeleteRemark
            // 
            this.txtDeleteRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeleteRemark.Location = new System.Drawing.Point(0, 0);
            this.txtDeleteRemark.Name = "txtDeleteRemark";
            this.txtDeleteRemark.Size = new System.Drawing.Size(176, 81);
            this.txtDeleteRemark.TabIndex = 0;
            this.txtDeleteRemark.Text = "kryptonRichTextBox1";
            // 
            // txtSearchAttachments
            // 
            this.txtSearchAttachments.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnSearch});
            this.txtSearchAttachments.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchAttachments.Location = new System.Drawing.Point(0, 21);
            this.txtSearchAttachments.Name = "txtSearchAttachments";
            this.txtSearchAttachments.Size = new System.Drawing.Size(178, 26);
            this.txtSearchAttachments.TabIndex = 8;
            this.txtSearchAttachments.TextChanged += new System.EventHandler(this.txtSearchAttachments_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Text = "&Search";
            this.btnSearch.UniqueName = "C58198C593DE4CA4E48B1974863367DC";
            // 
            // gridAttachments
            // 
            this.gridAttachments.AllowUserToAddRows = false;
            this.gridAttachments.AllowUserToDeleteRows = false;
            this.gridAttachments.AllowUserToOrderColumns = true;
            this.gridAttachments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridAttachments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridAttachments.ColumnHeadersVisible = false;
            this.gridAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttachments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAttachments.Location = new System.Drawing.Point(0, 47);
            this.gridAttachments.Name = "gridAttachments";
            this.gridAttachments.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAttachments.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridAttachments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttachments.Size = new System.Drawing.Size(178, 93);
            this.gridAttachments.TabIndex = 9;
            this.gridAttachments.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAttachments_RowEnter);
            // 
            // pageDeletedAttachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.kryptonHeader1);
            this.Name = "pageDeletedAttachments";
            this.Size = new System.Drawing.Size(534, 295);
            this.Load += new System.EventHandler(this.pageDeletedAttachments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumentFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteInfo.Panel)).EndInit();
            this.headerGroupDeleteInfo.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDeleteInfo)).EndInit();
            this.headerGroupDeleteInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttachments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDeleteInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUndeleteAtachment;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtDeleteRemark;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboDocumentFor;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAttachments;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchAttachments;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnSearch;
    }
}
