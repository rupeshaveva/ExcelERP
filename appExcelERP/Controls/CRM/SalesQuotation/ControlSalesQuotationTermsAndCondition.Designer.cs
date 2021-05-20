namespace appExcelERP.Controls.CRM
{
    partial class ControlSalesQuotationTermsAndCondition
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
            this.headerGroupTermsAndCondition = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddTerms = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveTerms = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridTermAndCondition = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchTermAndCondition = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.headerGroupNotes = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUpdateNotes = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtSpecialNotes = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition.Panel)).BeginInit();
            this.headerGroupTermsAndCondition.Panel.SuspendLayout();
            this.headerGroupTermsAndCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTermAndCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupNotes.Panel)).BeginInit();
            this.headerGroupNotes.Panel.SuspendLayout();
            this.headerGroupNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerGroupTermsAndCondition
            // 
            this.headerGroupTermsAndCondition.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddTerms,
            this.btnRemoveTerms});
            this.headerGroupTermsAndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupTermsAndCondition.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupTermsAndCondition.Location = new System.Drawing.Point(0, 0);
            this.headerGroupTermsAndCondition.Name = "headerGroupTermsAndCondition";
            // 
            // headerGroupTermsAndCondition.Panel
            // 
            this.headerGroupTermsAndCondition.Panel.Controls.Add(this.gridTermAndCondition);
            this.headerGroupTermsAndCondition.Panel.Controls.Add(this.txtSearchTermAndCondition);
            this.headerGroupTermsAndCondition.Size = new System.Drawing.Size(544, 189);
            this.headerGroupTermsAndCondition.TabIndex = 0;
            this.headerGroupTermsAndCondition.ValuesPrimary.Heading = "TERMS & CONDITIONS ";
            this.headerGroupTermsAndCondition.ValuesPrimary.Image = null;
            this.headerGroupTermsAndCondition.Paint += new System.Windows.Forms.PaintEventHandler(this.headerGroupTermsAndCondition_Paint);
            // 
            // btnAddTerms
            // 
            this.btnAddTerms.Text = "&Add more T&&C";
            this.btnAddTerms.UniqueName = "1023D470F0F34A2CB7B791E87ACAC7FF";
            this.btnAddTerms.Click += new System.EventHandler(this.btnAddTerms_Click);
            // 
            // btnRemoveTerms
            // 
            this.btnRemoveTerms.Text = "&Remove T&&C";
            this.btnRemoveTerms.UniqueName = "67CE8190AA91440524BF34668C025E28";
            this.btnRemoveTerms.Click += new System.EventHandler(this.btnRemoveTerms_Click);
            // 
            // gridTermAndCondition
            // 
            this.gridTermAndCondition.AllowUserToAddRows = false;
            this.gridTermAndCondition.AllowUserToDeleteRows = false;
            this.gridTermAndCondition.AllowUserToResizeColumns = false;
            this.gridTermAndCondition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTermAndCondition.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridTermAndCondition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTermAndCondition.ColumnHeadersVisible = false;
            this.gridTermAndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTermAndCondition.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.gridTermAndCondition.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridTermAndCondition.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.gridTermAndCondition.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridTermAndCondition.Location = new System.Drawing.Point(0, 20);
            this.gridTermAndCondition.MultiSelect = false;
            this.gridTermAndCondition.Name = "gridTermAndCondition";
            this.gridTermAndCondition.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTermAndCondition.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTermAndCondition.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTermAndCondition.Size = new System.Drawing.Size(542, 119);
            this.gridTermAndCondition.TabIndex = 19;
            this.gridTermAndCondition.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermAndCondition_CellClick);
            this.gridTermAndCondition.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermAndCondition_CellEnter);
            this.gridTermAndCondition.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermAndCondition_CellLeave);
            this.gridTermAndCondition.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTermAndCondition_CellValueChanged);
            // 
            // txtSearchTermAndCondition
            // 
            this.txtSearchTermAndCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchTermAndCondition.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTermAndCondition.Location = new System.Drawing.Point(0, 0);
            this.txtSearchTermAndCondition.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchTermAndCondition.Name = "txtSearchTermAndCondition";
            this.txtSearchTermAndCondition.Size = new System.Drawing.Size(542, 20);
            this.txtSearchTermAndCondition.TabIndex = 18;
            this.txtSearchTermAndCondition.TextChanged += new System.EventHandler(this.txtSearchTermAndCondition_TextChanged);
            // 
            // headerGroupNotes
            // 
            this.headerGroupNotes.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUpdateNotes});
            this.headerGroupNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupNotes.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupNotes.HeaderVisibleSecondary = false;
            this.headerGroupNotes.Location = new System.Drawing.Point(0, 0);
            this.headerGroupNotes.Name = "headerGroupNotes";
            // 
            // headerGroupNotes.Panel
            // 
            this.headerGroupNotes.Panel.Controls.Add(this.txtSpecialNotes);
            this.headerGroupNotes.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupNotes.Size = new System.Drawing.Size(544, 202);
            this.headerGroupNotes.TabIndex = 0;
            this.headerGroupNotes.ValuesPrimary.Heading = "SPECIAL NOTES (if any)";
            this.headerGroupNotes.ValuesPrimary.Image = null;
            // 
            // btnUpdateNotes
            // 
            this.btnUpdateNotes.Text = "Update &Notes";
            this.btnUpdateNotes.UniqueName = "C57C72FF9AC14FB13E92304E9E1979AC";
            this.btnUpdateNotes.Click += new System.EventHandler(this.btnUpdateNotes_Click);
            // 
            // txtSpecialNotes
            // 
            this.txtSpecialNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpecialNotes.Location = new System.Drawing.Point(5, 5);
            this.txtSpecialNotes.MaxLength = 10000;
            this.txtSpecialNotes.Name = "txtSpecialNotes";
            this.txtSpecialNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtSpecialNotes.Size = new System.Drawing.Size(532, 163);
            this.txtSpecialNotes.TabIndex = 0;
            this.txtSpecialNotes.Text = "";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupNotes);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.headerGroupTermsAndCondition);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(544, 398);
            this.splitContainerMain.SplitterDistance = 202;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 2;
            // 
            // ControlSalesQuotationTermsAndCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ControlSalesQuotationTermsAndCondition";
            this.Size = new System.Drawing.Size(544, 398);
            this.Load += new System.EventHandler(this.ControlSalesQuotationTermsAndCondition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition.Panel)).EndInit();
            this.headerGroupTermsAndCondition.Panel.ResumeLayout(false);
            this.headerGroupTermsAndCondition.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition)).EndInit();
            this.headerGroupTermsAndCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTermAndCondition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupNotes.Panel)).EndInit();
            this.headerGroupNotes.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupNotes)).EndInit();
            this.headerGroupNotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupTermsAndCondition;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupNotes;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddTerms;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveTerms;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdateNotes;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtSpecialNotes;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridTermAndCondition;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchTermAndCondition;
    }
}
