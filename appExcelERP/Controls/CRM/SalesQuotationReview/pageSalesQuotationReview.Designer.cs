namespace appExcelERP.Controls.CRM.SalesQuotationReview
{
    partial class pageSalesQuotationReview
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
            this.headerGroupReviewMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonSplitContainer1 = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.gridSalesDocuments = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupLeft = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblConclusion = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboQuotationsReviews = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewQuotationReview = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.tabREVIEWS = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageReviewNotes = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageAttachments = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageSchdeuleCalls = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageBOQ = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupReviewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupReviewMain.Panel)).BeginInit();
            this.headerGroupReviewMain.Panel.SuspendLayout();
            this.headerGroupReviewMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).BeginInit();
            this.kryptonSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).BeginInit();
            this.kryptonSplitContainer1.Panel2.SuspendLayout();
            this.kryptonSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLeft.Panel)).BeginInit();
            this.headerGroupLeft.Panel.SuspendLayout();
            this.headerGroupLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationsReviews)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabREVIEWS)).BeginInit();
            this.tabREVIEWS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageReviewNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageSchdeuleCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageBOQ)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupReviewMain
            // 
            this.headerGroupReviewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupReviewMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupReviewMain.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupReviewMain.Name = "headerGroupReviewMain";
            // 
            // headerGroupReviewMain.Panel
            // 
            this.headerGroupReviewMain.Panel.Controls.Add(this.kryptonSplitContainer1);
            this.headerGroupReviewMain.Size = new System.Drawing.Size(912, 521);
            this.headerGroupReviewMain.TabIndex = 0;
            this.headerGroupReviewMain.ValuesPrimary.Heading = "Sales Quotation Review";
            this.headerGroupReviewMain.ValuesPrimary.Image = null;
            // 
            // kryptonSplitContainer1
            // 
            this.kryptonSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.kryptonSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.kryptonSplitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonSplitContainer1.Name = "kryptonSplitContainer1";
            // 
            // kryptonSplitContainer1.Panel1
            // 
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.gridSalesDocuments);
            this.kryptonSplitContainer1.Panel1.Controls.Add(this.headerGroupLeft);
            // 
            // kryptonSplitContainer1.Panel2
            // 
            this.kryptonSplitContainer1.Panel2.Controls.Add(this.tabREVIEWS);
            this.kryptonSplitContainer1.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.kryptonSplitContainer1.Size = new System.Drawing.Size(910, 468);
            this.kryptonSplitContainer1.SplitterDistance = 219;
            this.kryptonSplitContainer1.SplitterWidth = 7;
            this.kryptonSplitContainer1.TabIndex = 1;
            // 
            // gridSalesDocuments
            // 
            this.gridSalesDocuments.AllowUserToAddRows = false;
            this.gridSalesDocuments.AllowUserToDeleteRows = false;
            this.gridSalesDocuments.AllowUserToResizeColumns = false;
            this.gridSalesDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSalesDocuments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSalesDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSalesDocuments.ColumnHeadersVisible = false;
            this.gridSalesDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSalesDocuments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSalesDocuments.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridSalesDocuments.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.gridSalesDocuments.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridSalesDocuments.Location = new System.Drawing.Point(0, 184);
            this.gridSalesDocuments.MultiSelect = false;
            this.gridSalesDocuments.Name = "gridSalesDocuments";
            this.gridSalesDocuments.ReadOnly = true;
            this.gridSalesDocuments.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSalesDocuments.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSalesDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSalesDocuments.Size = new System.Drawing.Size(219, 284);
            this.gridSalesDocuments.TabIndex = 21;
            // 
            // headerGroupLeft
            // 
            this.headerGroupLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupLeft.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupLeft.Location = new System.Drawing.Point(0, 0);
            this.headerGroupLeft.Margin = new System.Windows.Forms.Padding(2);
            this.headerGroupLeft.Name = "headerGroupLeft";
            // 
            // headerGroupLeft.Panel
            // 
            this.headerGroupLeft.Panel.Controls.Add(this.kryptonTextBox1);
            this.headerGroupLeft.Panel.Controls.Add(this.lblConclusion);
            this.headerGroupLeft.Panel.Controls.Add(this.cboQuotationsReviews);
            this.headerGroupLeft.Size = new System.Drawing.Size(219, 184);
            this.headerGroupLeft.TabIndex = 19;
            this.headerGroupLeft.ValuesPrimary.Image = null;
            this.headerGroupLeft.ValuesSecondary.Heading = "List of Documents in this Review";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTextBox1.Location = new System.Drawing.Point(0, 44);
            this.kryptonTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(217, 86);
            this.kryptonTextBox1.TabIndex = 4;
            this.kryptonTextBox1.Text = "kryptonTextBox1";
            // 
            // lblConclusion
            // 
            this.lblConclusion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConclusion.Location = new System.Drawing.Point(0, 24);
            this.lblConclusion.Margin = new System.Windows.Forms.Padding(2);
            this.lblConclusion.Name = "lblConclusion";
            this.lblConclusion.Size = new System.Drawing.Size(217, 20);
            this.lblConclusion.TabIndex = 3;
            this.lblConclusion.Values.Text = "Remarks";
            // 
            // cboQuotationsReviews
            // 
            this.cboQuotationsReviews.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewQuotationReview});
            this.cboQuotationsReviews.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboQuotationsReviews.DropDownWidth = 355;
            this.cboQuotationsReviews.Location = new System.Drawing.Point(0, 0);
            this.cboQuotationsReviews.Margin = new System.Windows.Forms.Padding(2);
            this.cboQuotationsReviews.Name = "cboQuotationsReviews";
            this.cboQuotationsReviews.Size = new System.Drawing.Size(217, 24);
            this.cboQuotationsReviews.TabIndex = 2;
            this.cboQuotationsReviews.Text = "kryptonComboBox1";
            // 
            // btnAddNewQuotationReview
            // 
            this.btnAddNewQuotationReview.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewQuotationReview.UniqueName = "82124A2840844C429CBFF742BE0A3117";
            this.btnAddNewQuotationReview.Click += new System.EventHandler(this.btnAddNewQuotationReview_Click);
            // 
            // tabREVIEWS
            // 
            this.tabREVIEWS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabREVIEWS.Location = new System.Drawing.Point(0, 0);
            this.tabREVIEWS.Margin = new System.Windows.Forms.Padding(2);
            this.tabREVIEWS.Name = "tabREVIEWS";
            this.tabREVIEWS.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageReviewNotes,
            this.tabPageAttachments,
            this.tabPageSchdeuleCalls,
            this.tabPageBOQ});
            this.tabREVIEWS.SelectedIndex = 1;
            this.tabREVIEWS.Size = new System.Drawing.Size(684, 468);
            this.tabREVIEWS.TabIndex = 0;
            this.tabREVIEWS.Text = "kryptonNavigator1";
            // 
            // tabPageReviewNotes
            // 
            this.tabPageReviewNotes.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageReviewNotes.Flags = 65534;
            this.tabPageReviewNotes.LastVisibleSet = true;
            this.tabPageReviewNotes.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageReviewNotes.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageReviewNotes.Name = "tabPageReviewNotes";
            this.tabPageReviewNotes.Size = new System.Drawing.Size(536, 444);
            this.tabPageReviewNotes.Text = "Review &Notes";
            this.tabPageReviewNotes.ToolTipTitle = "Page ToolTip";
            this.tabPageReviewNotes.UniqueName = "3CC4FBA5EE4E4DA2EF91CCC471C69C5E";
            // 
            // tabPageAttachments
            // 
            this.tabPageAttachments.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAttachments.Flags = 65534;
            this.tabPageAttachments.LastVisibleSet = true;
            this.tabPageAttachments.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageAttachments.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageAttachments.Name = "tabPageAttachments";
            this.tabPageAttachments.Size = new System.Drawing.Size(682, 441);
            this.tabPageAttachments.Text = "&Attachments";
            this.tabPageAttachments.ToolTipTitle = "Page ToolTip";
            this.tabPageAttachments.UniqueName = "8A7C56D116BF49898CB64DCAFFE823E2";
            // 
            // tabPageSchdeuleCalls
            // 
            this.tabPageSchdeuleCalls.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageSchdeuleCalls.Flags = 65534;
            this.tabPageSchdeuleCalls.LastVisibleSet = true;
            this.tabPageSchdeuleCalls.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageSchdeuleCalls.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageSchdeuleCalls.Name = "tabPageSchdeuleCalls";
            this.tabPageSchdeuleCalls.Size = new System.Drawing.Size(536, 444);
            this.tabPageSchdeuleCalls.Text = "&Schedule Calls";
            this.tabPageSchdeuleCalls.ToolTipTitle = "Page ToolTip";
            this.tabPageSchdeuleCalls.UniqueName = "876F358AA5824775B9A71AD1C2BCFB78";
            // 
            // tabPageBOQ
            // 
            this.tabPageBOQ.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageBOQ.Flags = 65534;
            this.tabPageBOQ.LastVisibleSet = true;
            this.tabPageBOQ.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageBOQ.MinimumSize = new System.Drawing.Size(38, 41);
            this.tabPageBOQ.Name = "tabPageBOQ";
            this.tabPageBOQ.Size = new System.Drawing.Size(682, 441);
            this.tabPageBOQ.Text = "BOQ";
            this.tabPageBOQ.ToolTipTitle = "Page ToolTip";
            this.tabPageBOQ.UniqueName = "D0D3AECEA0824BB8C480AAA0132336CD";
            // 
            // pageSalesQuotationReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupReviewMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "pageSalesQuotationReview";
            this.Size = new System.Drawing.Size(912, 521);
            this.Load += new System.EventHandler(this.pageSalesQuotationReview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupReviewMain.Panel)).EndInit();
            this.headerGroupReviewMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupReviewMain)).EndInit();
            this.headerGroupReviewMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel1)).EndInit();
            this.kryptonSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1.Panel2)).EndInit();
            this.kryptonSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonSplitContainer1)).EndInit();
            this.kryptonSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLeft.Panel)).EndInit();
            this.headerGroupLeft.Panel.ResumeLayout(false);
            this.headerGroupLeft.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupLeft)).EndInit();
            this.headerGroupLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationsReviews)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabREVIEWS)).EndInit();
            this.tabREVIEWS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageReviewNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageSchdeuleCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageBOQ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupReviewMain;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer kryptonSplitContainer1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridSalesDocuments;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupLeft;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblConclusion;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboQuotationsReviews;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewQuotationReview;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabREVIEWS;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageReviewNotes;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAttachments;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageSchdeuleCalls;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageBOQ;
    }
}
