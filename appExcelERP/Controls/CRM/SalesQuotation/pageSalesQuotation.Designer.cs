namespace appExcelERP.Controls.CRM
{
    partial class pageSalesQuotation
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
            this.headerGroupQuotation = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddNewQuotation = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEditQuotation = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDeleteQuotation = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnGenerateRevision = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnSalesBOQ = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRefresh = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnShowHideList = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.splitContainerMain = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupQuotList = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridSalesQuotations = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.txtSearchQuotations = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboQuotationStatus = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tabQuotation = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageGeneralInfo = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageClientDetail = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageBOQ = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageAttachment = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageScheduledCalls = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageAssociates = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.tabPageTermAndConditions = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation.Panel)).BeginInit();
            this.headerGroupQuotation.Panel.SuspendLayout();
            this.headerGroupQuotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).BeginInit();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotList.Panel)).BeginInit();
            this.headerGroupQuotList.Panel.SuspendLayout();
            this.headerGroupQuotList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesQuotations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabQuotation)).BeginInit();
            this.tabQuotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageClientDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageBOQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageScheduledCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAssociates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageTermAndConditions)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupQuotation
            // 
            this.headerGroupQuotation.AllowButtonSpecToolTips = true;
            this.headerGroupQuotation.AutoSize = true;
            this.headerGroupQuotation.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewQuotation,
            this.btnEditQuotation,
            this.btnDeleteQuotation,
            this.btnGenerateRevision,
            this.btnSalesBOQ,
            this.btnRefresh,
            this.btnShowHideList});
            this.headerGroupQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupQuotation.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupQuotation.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupQuotation.HeaderVisibleSecondary = false;
            this.headerGroupQuotation.Location = new System.Drawing.Point(2, 2);
            this.headerGroupQuotation.Name = "headerGroupQuotation";
            // 
            // headerGroupQuotation.Panel
            // 
            this.headerGroupQuotation.Panel.Controls.Add(this.splitContainerMain);
            this.headerGroupQuotation.Panel.Padding = new System.Windows.Forms.Padding(3);
            this.headerGroupQuotation.Size = new System.Drawing.Size(1122, 489);
            this.headerGroupQuotation.TabIndex = 2;
            this.headerGroupQuotation.ValuesPrimary.Heading = "SALES QUOTATIONS";
            this.headerGroupQuotation.ValuesPrimary.Image = null;
            this.headerGroupQuotation.ValuesSecondary.Description = "sample text";
            this.headerGroupQuotation.ValuesSecondary.Heading = "";
            // 
            // btnAddNewQuotation
            // 
            this.btnAddNewQuotation.Image = global::appExcelERP.Properties.Resources.AddScreen_16x;
            this.btnAddNewQuotation.Text = "&NEW QUOTATION";
            this.btnAddNewQuotation.UniqueName = "9F92D728835642B8C2991465D94102BA";
            this.btnAddNewQuotation.Click += new System.EventHandler(this.btnAddNewQuotation_Click);
            // 
            // btnEditQuotation
            // 
            this.btnEditQuotation.Image = global::appExcelERP.Properties.Resources.CustomActionEditor_16x1;
            this.btnEditQuotation.Text = "&EDIT QUOTATION";
            this.btnEditQuotation.UniqueName = "760FCBE8D88E4A68FB8C8F026F3A24A7";
            this.btnEditQuotation.Click += new System.EventHandler(this.btnEditQuotation_Click);
            // 
            // btnDeleteQuotation
            // 
            this.btnDeleteQuotation.Image = global::appExcelERP.Properties.Resources.RemoveGuide_16x;
            this.btnDeleteQuotation.Text = "&DELETE QUOTATION";
            this.btnDeleteQuotation.UniqueName = "F2271E83981740DAB0B8D5B13D1B0A4D";
            this.btnDeleteQuotation.Click += new System.EventHandler(this.btnDeleteQuotation_Click);
            // 
            // btnGenerateRevision
            // 
            this.btnGenerateRevision.Image = global::appExcelERP.Properties.Resources.GenerateFile_16x;
            this.btnGenerateRevision.Text = "&GENERATE REVISION";
            this.btnGenerateRevision.UniqueName = "EFDF6A6677EC43C182B625248A8A3E90";
            this.btnGenerateRevision.Click += new System.EventHandler(this.btnGenerateRevision_Click);
            // 
            // btnSalesBOQ
            // 
            this.btnSalesBOQ.Image = global::appExcelERP.Properties.Resources.Sequence_16x;
            this.btnSalesBOQ.Text = "Sales BOQ";
            this.btnSalesBOQ.UniqueName = "85D5CF0B06E1485C88B2AAA84523B0D2";
            this.btnSalesBOQ.Click += new System.EventHandler(this.btnSalesBOQ_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::appExcelERP.Properties.Resources.QuickRefresh_16x;
            this.btnRefresh.Text = "&REFRESH";
            this.btnRefresh.UniqueName = "9C52E8E480AD4A292B8B8812CFDB7569";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnShowHideList
            // 
            this.btnShowHideList.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Checked;
            this.btnShowHideList.Image = global::appExcelERP.Properties.Resources.Collapse_16x;
            this.btnShowHideList.UniqueName = "921DCEF065B740C405AB1546439435C7";
            this.btnShowHideList.ButtonSpecPropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.btnShowHideList_ButtonSpecPropertyChanged);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.headerGroupQuotList);
            this.splitContainerMain.Panel1MinSize = 200;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabQuotation);
            this.splitContainerMain.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighInternalProfile;
            this.splitContainerMain.Size = new System.Drawing.Size(1114, 454);
            this.splitContainerMain.SplitterDistance = 277;
            this.splitContainerMain.SplitterWidth = 7;
            this.splitContainerMain.TabIndex = 2;
            // 
            // headerGroupQuotList
            // 
            this.headerGroupQuotList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupQuotList.HeaderVisiblePrimary = false;
            this.headerGroupQuotList.Location = new System.Drawing.Point(0, 0);
            this.headerGroupQuotList.Name = "headerGroupQuotList";
            // 
            // headerGroupQuotList.Panel
            // 
            this.headerGroupQuotList.Panel.Controls.Add(this.gridSalesQuotations);
            this.headerGroupQuotList.Panel.Controls.Add(this.txtSearchQuotations);
            this.headerGroupQuotList.Panel.Controls.Add(this.cboQuotationStatus);
            this.headerGroupQuotList.Size = new System.Drawing.Size(277, 454);
            this.headerGroupQuotList.TabIndex = 17;
            // 
            // gridSalesQuotations
            // 
            this.gridSalesQuotations.AllowUserToAddRows = false;
            this.gridSalesQuotations.AllowUserToDeleteRows = false;
            this.gridSalesQuotations.AllowUserToResizeColumns = false;
            this.gridSalesQuotations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridSalesQuotations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridSalesQuotations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSalesQuotations.ColumnHeadersVisible = false;
            this.gridSalesQuotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSalesQuotations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSalesQuotations.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridSalesQuotations.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.gridSalesQuotations.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridSalesQuotations.Location = new System.Drawing.Point(0, 41);
            this.gridSalesQuotations.MultiSelect = false;
            this.gridSalesQuotations.Name = "gridSalesQuotations";
            this.gridSalesQuotations.ReadOnly = true;
            this.gridSalesQuotations.RowHeadersVisible = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSalesQuotations.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSalesQuotations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSalesQuotations.Size = new System.Drawing.Size(275, 390);
            this.gridSalesQuotations.TabIndex = 17;
            this.gridSalesQuotations.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridSalesQuotations_DataBindingComplete);
            this.gridSalesQuotations.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSalesQuotations_RowEnter);
            // 
            // txtSearchQuotations
            // 
            this.txtSearchQuotations.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchQuotations.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchQuotations.Location = new System.Drawing.Point(0, 21);
            this.txtSearchQuotations.Margin = new System.Windows.Forms.Padding(5);
            this.txtSearchQuotations.Name = "txtSearchQuotations";
            this.txtSearchQuotations.Size = new System.Drawing.Size(275, 20);
            this.txtSearchQuotations.TabIndex = 6;
            this.txtSearchQuotations.TextChanged += new System.EventHandler(this.txtSearchQuotations_TextChanged);
            // 
            // cboQuotationStatus
            // 
            this.cboQuotationStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.cboQuotationStatus.DropDownWidth = 373;
            this.cboQuotationStatus.Location = new System.Drawing.Point(0, 0);
            this.cboQuotationStatus.Name = "cboQuotationStatus";
            this.cboQuotationStatus.Size = new System.Drawing.Size(275, 21);
            this.cboQuotationStatus.TabIndex = 3;
            this.cboQuotationStatus.SelectionChangeCommitted += new System.EventHandler(this.cboQuotationStatus_SelectionChangeCommitted);
            // 
            // tabQuotation
            // 
            this.tabQuotation.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.SameWidthAndHeight;
            this.tabQuotation.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.SlantEqualBoth;
            this.tabQuotation.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.OneNote;
            this.tabQuotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabQuotation.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabQuotation.Location = new System.Drawing.Point(0, 0);
            this.tabQuotation.Name = "tabQuotation";
            this.tabQuotation.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageGeneralInfo,
            this.tabPageClientDetail,
            this.tabPageBOQ,
            this.tabPageAttachment,
            this.tabPageScheduledCalls,
            this.tabPageAssociates,
            this.tabPageTermAndConditions});
            this.tabQuotation.SelectedIndex = 2;
            this.tabQuotation.Size = new System.Drawing.Size(830, 454);
            this.tabQuotation.TabIndex = 13;
            this.tabQuotation.TabClicked += new System.EventHandler<ComponentFactory.Krypton.Navigator.KryptonPageEventArgs>(this.tabQuotation_TabClicked);
            // 
            // tabPageGeneralInfo
            // 
            this.tabPageGeneralInfo.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageGeneralInfo.Flags = 65534;
            this.tabPageGeneralInfo.LastVisibleSet = true;
            this.tabPageGeneralInfo.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageGeneralInfo.Name = "tabPageGeneralInfo";
            this.tabPageGeneralInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneralInfo.Size = new System.Drawing.Size(899, 432);
            this.tabPageGeneralInfo.Text = "General Info.";
            this.tabPageGeneralInfo.ToolTipTitle = "Page ToolTip";
            this.tabPageGeneralInfo.UniqueName = "BCAC1791B9054A97678F004CA536B8DD";
            // 
            // tabPageClientDetail
            // 
            this.tabPageClientDetail.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageClientDetail.Flags = 65534;
            this.tabPageClientDetail.LastVisibleSet = true;
            this.tabPageClientDetail.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageClientDetail.Name = "tabPageClientDetail";
            this.tabPageClientDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClientDetail.Size = new System.Drawing.Size(899, 432);
            this.tabPageClientDetail.Text = "Client Details";
            this.tabPageClientDetail.ToolTipTitle = "Page ToolTip";
            this.tabPageClientDetail.UniqueName = "AFCD962AABDB4B3C3A9D742D42188406";
            // 
            // tabPageBOQ
            // 
            this.tabPageBOQ.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageBOQ.Flags = 65534;
            this.tabPageBOQ.LastVisibleSet = true;
            this.tabPageBOQ.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageBOQ.Name = "tabPageBOQ";
            this.tabPageBOQ.Size = new System.Drawing.Size(828, 428);
            this.tabPageBOQ.Text = "BOQ";
            this.tabPageBOQ.TextTitle = "Sales Enquiry";
            this.tabPageBOQ.ToolTipTitle = "Page ToolTip";
            this.tabPageBOQ.UniqueName = "BA2DF83910AD4113F39F762CE50EE44F";
            // 
            // tabPageAttachment
            // 
            this.tabPageAttachment.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAttachment.Flags = 65534;
            this.tabPageAttachment.LastVisibleSet = true;
            this.tabPageAttachment.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageAttachment.Name = "tabPageAttachment";
            this.tabPageAttachment.Size = new System.Drawing.Size(899, 432);
            this.tabPageAttachment.Text = "Attachments";
            this.tabPageAttachment.ToolTipTitle = "Page ToolTip";
            this.tabPageAttachment.UniqueName = "297ADBD0E29648E454843D3432B9DE78";
            // 
            // tabPageScheduledCalls
            // 
            this.tabPageScheduledCalls.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageScheduledCalls.Flags = 65534;
            this.tabPageScheduledCalls.LastVisibleSet = true;
            this.tabPageScheduledCalls.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageScheduledCalls.Name = "tabPageScheduledCalls";
            this.tabPageScheduledCalls.Size = new System.Drawing.Size(899, 432);
            this.tabPageScheduledCalls.Text = "Calls logs && FollowUps";
            this.tabPageScheduledCalls.ToolTipTitle = "Page ToolTip";
            this.tabPageScheduledCalls.UniqueName = "62163C82738E44E365AEC4C2EDAA9AFF";
            // 
            // tabPageAssociates
            // 
            this.tabPageAssociates.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageAssociates.Flags = 65534;
            this.tabPageAssociates.LastVisibleSet = true;
            this.tabPageAssociates.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageAssociates.Name = "tabPageAssociates";
            this.tabPageAssociates.Size = new System.Drawing.Size(654, 331);
            this.tabPageAssociates.Text = "Associates";
            this.tabPageAssociates.ToolTipTitle = "Page ToolTip";
            this.tabPageAssociates.UniqueName = "58CD8D6F9F344D3836AFC2B7999ECCC8";
            // 
            // tabPageTermAndConditions
            // 
            this.tabPageTermAndConditions.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageTermAndConditions.Flags = 65534;
            this.tabPageTermAndConditions.LastVisibleSet = true;
            this.tabPageTermAndConditions.MinimumSize = new System.Drawing.Size(50, 50);
            this.tabPageTermAndConditions.Name = "tabPageTermAndConditions";
            this.tabPageTermAndConditions.Size = new System.Drawing.Size(654, 332);
            this.tabPageTermAndConditions.Text = "Terms And Condition";
            this.tabPageTermAndConditions.ToolTipTitle = "Page ToolTip";
            this.tabPageTermAndConditions.UniqueName = "5E8BFBF5950046407DBA030287853285";
            // 
            // pageSalesQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.headerGroupQuotation);
            this.Name = "pageSalesQuotation";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(1126, 493);
            this.Load += new System.EventHandler(this.pageSalesQuotation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation.Panel)).EndInit();
            this.headerGroupQuotation.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotation)).EndInit();
            this.headerGroupQuotation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel1)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain.Panel2)).EndInit();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotList.Panel)).EndInit();
            this.headerGroupQuotList.Panel.ResumeLayout(false);
            this.headerGroupQuotList.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupQuotList)).EndInit();
            this.headerGroupQuotList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSalesQuotations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuotationStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabQuotation)).EndInit();
            this.tabQuotation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageGeneralInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageClientDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageBOQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageScheduledCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageAssociates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageTermAndConditions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupQuotation;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewQuotation;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEditQuotation;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDeleteQuotation;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRefresh;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerMain;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboQuotationStatus;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator tabQuotation;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageGeneralInfo;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageClientDetail;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageBOQ;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAttachment;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageAssociates;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageTermAndConditions;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnGenerateRevision;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupQuotList;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridSalesQuotations;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSearchQuotations;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnShowHideList;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageScheduledCalls;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSalesBOQ;
    }
}
