namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlDocumentViewer
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
            Gnostice.Documents.FormatterSettings formatterSettings1 = new Gnostice.Documents.FormatterSettings();
            Gnostice.Documents.Spreadsheet.SpreadSheetFormatterSettings spreadSheetFormatterSettings1 = new Gnostice.Documents.Spreadsheet.SpreadSheetFormatterSettings();
            Gnostice.Documents.PageSettings pageSettings1 = new Gnostice.Documents.PageSettings();
            Gnostice.Documents.Margins margins1 = new Gnostice.Documents.Margins();
            Gnostice.Documents.Spreadsheet.SheetOptions sheetOptions1 = new Gnostice.Documents.Spreadsheet.SheetOptions();
            Gnostice.Documents.Spreadsheet.SheetOptions sheetOptions2 = new Gnostice.Documents.Spreadsheet.SheetOptions();
            Gnostice.Documents.TXTFormatterSettings txtFormatterSettings1 = new Gnostice.Documents.TXTFormatterSettings();
            Gnostice.Documents.PageSettings pageSettings2 = new Gnostice.Documents.PageSettings();
            Gnostice.Documents.Margins margins2 = new Gnostice.Documents.Margins();
            Gnostice.Graphics.RenderingSettings renderingSettings1 = new Gnostice.Graphics.RenderingSettings();
            Gnostice.Graphics.ImageRenderingSettings imageRenderingSettings1 = new Gnostice.Graphics.ImageRenderingSettings();
            Gnostice.Graphics.LineArtRenderingSettings lineArtRenderingSettings1 = new Gnostice.Graphics.LineArtRenderingSettings();
            Gnostice.Graphics.ResolutionSettings resolutionSettings1 = new Gnostice.Graphics.ResolutionSettings();
            Gnostice.Graphics.TextRenderingSettings textRenderingSettings1 = new Gnostice.Graphics.TextRenderingSettings();
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.tabPageDocument = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.headerGroupDocument = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnZoomIN = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnZoomOut = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDownload = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEmail = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnEnable = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.documentViewer1 = new Gnostice.Documents.Controls.WinForms.DocumentViewer();
            this.tabPageHistory = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.gridHistory = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageDocument)).BeginInit();
            this.tabPageDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocument.Panel)).BeginInit();
            this.headerGroupDocument.Panel.SuspendLayout();
            this.headerGroupDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPageHistory)).BeginInit();
            this.tabPageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.None;
            this.kryptonNavigator1.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Header.HeaderValuesPrimary.MapHeading = ComponentFactory.Krypton.Navigator.MapKryptonPageText.TextTitleDescription;
            this.kryptonNavigator1.Location = new System.Drawing.Point(1, 1);
            this.kryptonNavigator1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.tabPageDocument,
            this.tabPageHistory});
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(1131, 444);
            this.kryptonNavigator1.TabIndex = 2;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // tabPageDocument
            // 
            this.tabPageDocument.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageDocument.Controls.Add(this.headerGroupDocument);
            this.tabPageDocument.Flags = 65534;
            this.tabPageDocument.ImageSmall = global::appExcelERP.Properties.Resources.IDRLibraryFile_16x;
            this.tabPageDocument.LastVisibleSet = true;
            this.tabPageDocument.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageDocument.MinimumSize = new System.Drawing.Size(67, 62);
            this.tabPageDocument.Name = "tabPageDocument";
            this.tabPageDocument.Size = new System.Drawing.Size(1129, 413);
            this.tabPageDocument.Text = "Document Viewer";
            this.tabPageDocument.ToolTipTitle = "Page ToolTip";
            this.tabPageDocument.UniqueName = "614CC1589E9F4BD0C1953843A713BF19";
            // 
            // headerGroupDocument
            // 
            this.headerGroupDocument.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnZoomIN,
            this.btnZoomOut,
            this.btnDownload,
            this.btnEmail,
            this.btnEnable});
            this.headerGroupDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupDocument.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDocument.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupDocument.Location = new System.Drawing.Point(0, 0);
            this.headerGroupDocument.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerGroupDocument.Name = "headerGroupDocument";
            // 
            // headerGroupDocument.Panel
            // 
            this.headerGroupDocument.Panel.Controls.Add(this.documentViewer1);
            this.headerGroupDocument.Size = new System.Drawing.Size(1129, 413);
            this.headerGroupDocument.TabIndex = 1;
            this.headerGroupDocument.ValuesPrimary.Heading = "";
            this.headerGroupDocument.ValuesPrimary.Image = null;
            // 
            // btnZoomIN
            // 
            this.btnZoomIN.Image = global::appExcelERP.Properties.Resources.ZoomIn_16x;
            this.btnZoomIN.Text = "Zoom IN";
            this.btnZoomIN.UniqueName = "55E9C0B0DAF04FA75993F47416A05341";
            this.btnZoomIN.Click += new System.EventHandler(this.btnZoomIN_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::appExcelERP.Properties.Resources.ZoomOut_16x;
            this.btnZoomOut.Text = "Zoom Out";
            this.btnZoomOut.UniqueName = "583433D20C594393178F1BDF2A554EEF";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnDownload.Image = global::appExcelERP.Properties.Resources.ASX_TransferDownload_blue_16x;
            this.btnDownload.Text = "&Download";
            this.btnDownload.UniqueName = "74E942F5B9FB4DFB1BA1BEC639378DDC";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnEmail.Image = global::appExcelERP.Properties.Resources.HttpSend_16x;
            this.btnEmail.Text = "Send as &mail attachment";
            this.btnEmail.UniqueName = "C93CEE1C496847ED3686E6F0F304DBFF";
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.Image = global::appExcelERP.Properties.Resources.EnableLog_16x;
            this.btnEnable.Text = "&Enable";
            this.btnEnable.UniqueName = "052B0A8D02224250538B9CE7060BAD5E";
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // documentViewer1
            // 
            this.documentViewer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.documentViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.documentViewer1.BorderWidth = 10;
            this.documentViewer1.CurrentPage = 0;
            this.documentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentViewer1.Enabled = false;
            this.documentViewer1.HScrollBar.LargeChange = 40;
            this.documentViewer1.HScrollBar.SmallChange = 20;
            this.documentViewer1.HScrollBar.Value = 0;
            this.documentViewer1.HScrollBar.Visibility = Gnostice.Documents.Controls.WinForms.ScrollBarVisibility.Always;
            this.documentViewer1.Location = new System.Drawing.Point(0, 0);
            this.documentViewer1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.documentViewer1.Name = "documentViewer1";
            // 
            // 
            // 
            this.documentViewer1.NavigationPane.ActivePage = null;
            this.documentViewer1.NavigationPane.Location = new System.Drawing.Point(0, 0);
            this.documentViewer1.NavigationPane.Name = "";
            this.documentViewer1.NavigationPane.TabIndex = 0;
            this.documentViewer1.NavigationPane.Visibility = Gnostice.Documents.Controls.WinForms.Visibility.Auto;
            this.documentViewer1.NavigationPane.Visible = false;
            this.documentViewer1.NavigationPane.WidthPercentage = 20;
            this.documentViewer1.PageLayout = null;
            this.documentViewer1.PageRotation = Gnostice.Documents.Controls.WinForms.RotationAngle.Zero;
            spreadSheetFormatterSettings1.FormattingMode = Gnostice.DOM.FormattingMode.PreferDocumentSettings;
            spreadSheetFormatterSettings1.PageOrder = Gnostice.Documents.Spreadsheet.LayoutDirection.BackwardN;
            pageSettings1.Height = 11.6929F;
            margins1.Bottom = 1F;
            margins1.Footer = 0F;
            margins1.Header = 0F;
            margins1.Left = 1F;
            margins1.Right = 1F;
            margins1.Top = 1F;
            pageSettings1.Margin = margins1;
            pageSettings1.Orientation = Gnostice.Graphics.Orientation.Portrait;
            pageSettings1.PageSize = Gnostice.Documents.PageSize.A4;
            pageSettings1.Width = 8.2677F;
            spreadSheetFormatterSettings1.PageSettings = pageSettings1;
            sheetOptions1.Print = false;
            sheetOptions1.View = true;
            spreadSheetFormatterSettings1.ShowGridlines = sheetOptions1;
            sheetOptions2.Print = false;
            sheetOptions2.View = true;
            spreadSheetFormatterSettings1.ShowHeadings = sheetOptions2;
            formatterSettings1.SpreadSheet = spreadSheetFormatterSettings1;
            txtFormatterSettings1.Font = new System.Drawing.Font("Calibri", 12F);
            pageSettings2.Height = 11.6929F;
            margins2.Bottom = 1F;
            margins2.Footer = 0F;
            margins2.Header = 0F;
            margins2.Left = 1F;
            margins2.Right = 1F;
            margins2.Top = 1F;
            pageSettings2.Margin = margins2;
            pageSettings2.Orientation = Gnostice.Graphics.Orientation.Portrait;
            pageSettings2.PageSize = Gnostice.Documents.PageSize.A4;
            pageSettings2.Width = 8.2677F;
            txtFormatterSettings1.PageSettings = pageSettings2;
            formatterSettings1.TXT = txtFormatterSettings1;
            this.documentViewer1.Preferences.FormatterSettings = formatterSettings1;
            this.documentViewer1.Preferences.KeyNavigation = true;
            imageRenderingSettings1.CompositingMode = Gnostice.Graphics.CompositingMode.SourceOver;
            imageRenderingSettings1.CompositingQuality = Gnostice.Graphics.CompositingQuality.Default;
            imageRenderingSettings1.InterpolationMode = Gnostice.Graphics.InterpolationMode.NearestNeighbor;
            imageRenderingSettings1.PixelOffsetMode = Gnostice.Graphics.PixelOffsetMode.HighQuality;
            renderingSettings1.Image = imageRenderingSettings1;
            lineArtRenderingSettings1.SmoothingMode = Gnostice.Graphics.SmoothingMode.AntiAlias;
            renderingSettings1.LineArt = lineArtRenderingSettings1;
            resolutionSettings1.DpiX = 96F;
            resolutionSettings1.DpiY = 96F;
            resolutionSettings1.ResolutionMode = Gnostice.Graphics.ResolutionMode.UseSource;
            renderingSettings1.Resolution = resolutionSettings1;
            textRenderingSettings1.TextContrast = 3;
            textRenderingSettings1.TextRenderingHint = Gnostice.Graphics.TextRenderingHint.AntiAlias;
            renderingSettings1.Text = textRenderingSettings1;
            this.documentViewer1.Preferences.RenderingSettings = renderingSettings1;
            this.documentViewer1.Preferences.Units = Gnostice.Graphics.MeasurementUnit.Inches;
            this.documentViewer1.Size = new System.Drawing.Size(1127, 349);
            this.documentViewer1.TabIndex = 0;
            this.documentViewer1.VScrollBar.LargeChange = 40;
            this.documentViewer1.VScrollBar.SmallChange = 20;
            this.documentViewer1.VScrollBar.Value = 0;
            this.documentViewer1.VScrollBar.Visibility = Gnostice.Documents.Controls.WinForms.ScrollBarVisibility.Always;
            this.documentViewer1.Zoom.ZoomMode = Gnostice.Documents.Controls.WinForms.ZoomMode.FitWidth;
            this.documentViewer1.Zoom.ZoomPercent = 100D;
            // 
            // tabPageHistory
            // 
            this.tabPageHistory.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.tabPageHistory.Controls.Add(this.gridHistory);
            this.tabPageHistory.Flags = 65534;
            this.tabPageHistory.ImageSmall = global::appExcelERP.Properties.Resources.HistoryTable_16x;
            this.tabPageHistory.LastVisibleSet = true;
            this.tabPageHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageHistory.MinimumSize = new System.Drawing.Size(67, 62);
            this.tabPageHistory.Name = "tabPageHistory";
            this.tabPageHistory.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPageHistory.Size = new System.Drawing.Size(1129, 413);
            this.tabPageHistory.Text = "&History";
            this.tabPageHistory.ToolTipTitle = "Page ToolTip";
            this.tabPageHistory.UniqueName = "0BE3A17D90A34EFEB4BCE30E3E0B56F1";
            // 
            // gridHistory
            // 
            this.gridHistory.AllowUserToAddRows = false;
            this.gridHistory.AllowUserToDeleteRows = false;
            this.gridHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridHistory.ColumnHeadersHeight = 28;
            this.gridHistory.ColumnHeadersVisible = false;
            this.gridHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistory.Location = new System.Drawing.Point(7, 6);
            this.gridHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridHistory.Name = "gridHistory";
            this.gridHistory.ReadOnly = true;
            this.gridHistory.RowHeadersVisible = false;
            this.gridHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistory.Size = new System.Drawing.Size(1115, 401);
            this.gridHistory.TabIndex = 0;
            // 
            // ctrlDocumentViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.kryptonNavigator1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ctrlDocumentViewer";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(1133, 446);
            this.Load += new System.EventHandler(this.ctrlDocumentViewer_Load);
            this.Resize += new System.EventHandler(this.ctrlDocumentViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageDocument)).EndInit();
            this.tabPageDocument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocument.Panel)).EndInit();
            this.headerGroupDocument.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDocument)).EndInit();
            this.headerGroupDocument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPageHistory)).EndInit();
            this.tabPageHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gnostice.Documents.Controls.WinForms.DocumentViewer documentViewer1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDocument;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnZoomIN;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnZoomOut;
        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageDocument;
        private ComponentFactory.Krypton.Navigator.KryptonPage tabPageHistory;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridHistory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEnable;
        public ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDownload;
        public ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnEmail;
    }
}
