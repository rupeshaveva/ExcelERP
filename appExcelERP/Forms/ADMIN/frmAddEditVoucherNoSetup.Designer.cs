namespace appExcelERP.Forms.ADMIN
{
    partial class frmAddEditVoucherNoSetup
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
            this.NoStyle = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNoPadding = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.NoPrefix = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.NoPostFix = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Separator = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNoPrefix = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtNoPostFix = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtSeparator = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.chkIs_continuedNextYear = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNoStartingFrom = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtSeparatorSuffix = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtVoucherNoPreview = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.kryptonDockableNavigator1 = new ComponentFactory.Krypton.Docking.KryptonDockableNavigator();
            this.kryptonPage1 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.kryptonPage2 = new ComponentFactory.Krypton.Navigator.KryptonPage();
            this.cboYears = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).BeginInit();
            this.kryptonDockableNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYears)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // NoStyle
            // 
            this.NoStyle.Location = new System.Drawing.Point(226, 86);
            this.NoStyle.Name = "NoStyle";
            this.NoStyle.Size = new System.Drawing.Size(96, 24);
            this.NoStyle.TabIndex = 6;
            this.NoStyle.Values.Text = "No. Padding";
            // 
            // txtNoPadding
            // 
            this.txtNoPadding.Location = new System.Drawing.Point(224, 113);
            this.txtNoPadding.MaxLength = 1;
            this.txtNoPadding.Name = "txtNoPadding";
            this.txtNoPadding.Size = new System.Drawing.Size(100, 27);
            this.txtNoPadding.TabIndex = 7;
            this.txtNoPadding.Text = "4";
            this.txtNoPadding.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoPadding.TextChanged += new System.EventHandler(this.GenerateVoucherNoPreview);
            this.txtNoPadding.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoStyle_Validating);
            // 
            // NoPrefix
            // 
            this.NoPrefix.Location = new System.Drawing.Point(36, 86);
            this.NoPrefix.Name = "NoPrefix";
            this.NoPrefix.Size = new System.Drawing.Size(49, 24);
            this.NoPrefix.TabIndex = 2;
            this.NoPrefix.Values.Text = "Prefix";
            // 
            // NoPostFix
            // 
            this.NoPostFix.Location = new System.Drawing.Point(470, 86);
            this.NoPostFix.Name = "NoPostFix";
            this.NoPostFix.Size = new System.Drawing.Size(49, 24);
            this.NoPostFix.TabIndex = 10;
            this.NoPostFix.Values.Text = "Suffix";
            // 
            // Separator
            // 
            this.Separator.Location = new System.Drawing.Point(126, 86);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(78, 24);
            this.Separator.TabIndex = 4;
            this.Separator.Values.Text = "Seperator";
            // 
            // txtNoPrefix
            // 
            this.txtNoPrefix.Location = new System.Drawing.Point(10, 113);
            this.txtNoPrefix.MaxLength = 10;
            this.txtNoPrefix.Name = "txtNoPrefix";
            this.txtNoPrefix.Size = new System.Drawing.Size(100, 27);
            this.txtNoPrefix.TabIndex = 3;
            this.txtNoPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoPrefix.TextChanged += new System.EventHandler(this.GenerateVoucherNoPreview);
            this.txtNoPrefix.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoPrefix_Validating);
            // 
            // txtNoPostFix
            // 
            this.txtNoPostFix.Location = new System.Drawing.Point(444, 113);
            this.txtNoPostFix.MaxLength = 10;
            this.txtNoPostFix.Name = "txtNoPostFix";
            this.txtNoPostFix.Size = new System.Drawing.Size(100, 27);
            this.txtNoPostFix.TabIndex = 11;
            this.txtNoPostFix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoPostFix.TextChanged += new System.EventHandler(this.GenerateVoucherNoPreview);
            this.txtNoPostFix.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoPostFix_Validating);
            // 
            // txtSeparator
            // 
            this.txtSeparator.Location = new System.Drawing.Point(115, 113);
            this.txtSeparator.MaxLength = 1;
            this.txtSeparator.Name = "txtSeparator";
            this.txtSeparator.Size = new System.Drawing.Size(100, 27);
            this.txtSeparator.TabIndex = 5;
            this.txtSeparator.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSeparator.TextChanged += new System.EventHandler(this.GenerateVoucherNoPreview);
            this.txtSeparator.Validating += new System.ComponentModel.CancelEventHandler(this.txtSeparator_Validating);
            // 
            // chkIs_continuedNextYear
            // 
            this.chkIs_continuedNextYear.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIs_continuedNextYear.Location = new System.Drawing.Point(238, 224);
            this.chkIs_continuedNextYear.Name = "chkIs_continuedNextYear";
            this.chkIs_continuedNextYear.Size = new System.Drawing.Size(309, 24);
            this.chkIs_continuedNextYear.TabIndex = 14;
            this.chkIs_continuedNextYear.Values.Text = "Continue from Previous Year\'s Number";
            this.chkIs_continuedNextYear.CheckedChanged += new System.EventHandler(this.chkIs_continuedNextYear_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(310, 357);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 31);
            this.btnSave.TabIndex = 1;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(438, 357);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 31);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(235, 254);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(201, 24);
            this.kryptonLabel1.TabIndex = 15;
            this.kryptonLabel1.Values.Text = "Initial Number to Start from ";
            // 
            // txtNoStartingFrom
            // 
            this.txtNoStartingFrom.Location = new System.Drawing.Point(442, 251);
            this.txtNoStartingFrom.MaxLength = 4;
            this.txtNoStartingFrom.Name = "txtNoStartingFrom";
            this.txtNoStartingFrom.Size = new System.Drawing.Size(102, 27);
            this.txtNoStartingFrom.TabIndex = 16;
            this.txtNoStartingFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoStartingFrom.Validating += new System.ComponentModel.CancelEventHandler(this.txtNoStartingFrom_Validating);
            // 
            // txtSeparatorSuffix
            // 
            this.txtSeparatorSuffix.Location = new System.Drawing.Point(334, 113);
            this.txtSeparatorSuffix.MaxLength = 1;
            this.txtSeparatorSuffix.Name = "txtSeparatorSuffix";
            this.txtSeparatorSuffix.ReadOnly = true;
            this.txtSeparatorSuffix.Size = new System.Drawing.Size(100, 27);
            this.txtSeparatorSuffix.TabIndex = 9;
            this.txtSeparatorSuffix.TabStop = false;
            this.txtSeparatorSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(345, 86);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(78, 24);
            this.kryptonLabel2.TabIndex = 8;
            this.kryptonLabel2.Values.Text = "Seperator";
            // 
            // txtVoucherNoPreview
            // 
            this.txtVoucherNoPreview.Location = new System.Drawing.Point(10, 177);
            this.txtVoucherNoPreview.Name = "txtVoucherNoPreview";
            this.txtVoucherNoPreview.ReadOnly = true;
            this.txtVoucherNoPreview.Size = new System.Drawing.Size(534, 27);
            this.txtVoucherNoPreview.TabIndex = 13;
            this.txtVoucherNoPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.AutoSize = false;
            this.kryptonLabel3.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(17, 149);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(524, 24);
            this.kryptonLabel3.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.kryptonLabel3.TabIndex = 12;
            this.kryptonLabel3.Values.Text = "Voucher No. Preview";
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.HeaderVisibleSecondary = false;
            this.headerGroupMain.Location = new System.Drawing.Point(12, 12);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.kryptonDockableNavigator1);
            this.headerGroupMain.Panel.Controls.Add(this.cboYears);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonLabel4);
            this.headerGroupMain.Panel.Controls.Add(this.NoPrefix);
            this.headerGroupMain.Panel.Controls.Add(this.txtVoucherNoPreview);
            this.headerGroupMain.Panel.Controls.Add(this.NoStyle);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonLabel3);
            this.headerGroupMain.Panel.Controls.Add(this.txtNoPadding);
            this.headerGroupMain.Panel.Controls.Add(this.txtSeparatorSuffix);
            this.headerGroupMain.Panel.Controls.Add(this.NoPostFix);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupMain.Panel.Controls.Add(this.Separator);
            this.headerGroupMain.Panel.Controls.Add(this.txtNoStartingFrom);
            this.headerGroupMain.Panel.Controls.Add(this.txtNoPrefix);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupMain.Panel.Controls.Add(this.txtNoPostFix);
            this.headerGroupMain.Panel.Controls.Add(this.txtSeparator);
            this.headerGroupMain.Panel.Controls.Add(this.chkIs_continuedNextYear);
            this.headerGroupMain.Size = new System.Drawing.Size(566, 334);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Document Type";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // kryptonDockableNavigator1
            // 
            this.kryptonDockableNavigator1.Location = new System.Drawing.Point(26, 113);
            this.kryptonDockableNavigator1.Name = "kryptonDockableNavigator1";
            this.kryptonDockableNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.kryptonPage1,
            this.kryptonPage2});
            this.kryptonDockableNavigator1.SelectedIndex = 0;
            this.kryptonDockableNavigator1.Size = new System.Drawing.Size(10, 8);
            this.kryptonDockableNavigator1.TabIndex = 17;
            this.kryptonDockableNavigator1.Text = "kryptonDockableNavigator1";
            // 
            // kryptonPage1
            // 
            this.kryptonPage1.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage1.Flags = 65534;
            this.kryptonPage1.LastVisibleSet = true;
            this.kryptonPage1.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Name = "kryptonPage1";
            this.kryptonPage1.Size = new System.Drawing.Size(50, 50);
            this.kryptonPage1.Text = "kryptonPage1";
            this.kryptonPage1.ToolTipTitle = "Page ToolTip";
            this.kryptonPage1.UniqueName = "BCF98D1C0E5348E149AB1E2BD18C931F";
            // 
            // kryptonPage2
            // 
            this.kryptonPage2.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.kryptonPage2.Flags = 65534;
            this.kryptonPage2.LastVisibleSet = true;
            this.kryptonPage2.MinimumSize = new System.Drawing.Size(50, 50);
            this.kryptonPage2.Name = "kryptonPage2";
            this.kryptonPage2.Size = new System.Drawing.Size(100, 100);
            this.kryptonPage2.Text = "kryptonPage2";
            this.kryptonPage2.ToolTipTitle = "Page ToolTip";
            this.kryptonPage2.UniqueName = "66372054BA8C40228EBF84EBFE808606";
            // 
            // cboYears
            // 
            this.cboYears.DropDownWidth = 534;
            this.cboYears.Location = new System.Drawing.Point(10, 44);
            this.cboYears.Name = "cboYears";
            this.cboYears.Size = new System.Drawing.Size(534, 25);
            this.cboYears.TabIndex = 1;
            this.cboYears.Text = "kryptonComboBox1";
            this.cboYears.Validating += new System.ComponentModel.CancelEventHandler(this.cboYears_Validating);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(10, 16);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(313, 24);
            this.kryptonLabel4.TabIndex = 0;
            this.kryptonLabel4.Values.Text = "Select Financial Year for setting Voucher No.";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditVoucherNoSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 412);
            this.Controls.Add(this.headerGroupMain);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditVoucherNoSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Voucher No. Setup";
            this.Load += new System.EventHandler(this.frmAddEditVoucherNoSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            this.headerGroupMain.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDockableNavigator1)).EndInit();
            this.kryptonDockableNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboYears)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel NoStyle;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNoPadding;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel NoPrefix;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel NoPostFix;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel Separator;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNoPrefix;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNoPostFix;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSeparator;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIs_continuedNextYear;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNoStartingFrom;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSeparatorSuffix;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtVoucherNoPreview;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboYears;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Docking.KryptonDockableNavigator kryptonDockableNavigator1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage1;
        private ComponentFactory.Krypton.Navigator.KryptonPage kryptonPage2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}