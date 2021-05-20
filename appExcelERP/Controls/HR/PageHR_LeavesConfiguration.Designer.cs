namespace appExcelERP.Controls.HR
{
    partial class PageHR_LeavesConfiguration
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
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.gridLeaves = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.headerGroupYearlyLeaves = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.btnAddNewYearlyLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnEditYearlyLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnDeleteYearlyLeave = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label17 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboFinYear = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBranch = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFinYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranch)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.Location = new System.Drawing.Point(5, 5);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.gridLeaves);
            this.headerGroupMain.Panel.Controls.Add(this.headerGroupYearlyLeaves);
            this.headerGroupMain.Panel.Controls.Add(this.kryptonPanel1);
            this.headerGroupMain.Size = new System.Drawing.Size(650, 366);
            this.headerGroupMain.TabIndex = 1;
            this.headerGroupMain.ValuesPrimary.Heading = "Configure Leave(s)";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // gridLeaves
            // 
            this.gridLeaves.AllowUserToAddRows = false;
            this.gridLeaves.AllowUserToDeleteRows = false;
            this.gridLeaves.AllowUserToOrderColumns = true;
            this.gridLeaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridLeaves.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridLeaves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLeaves.Location = new System.Drawing.Point(0, 65);
            this.gridLeaves.Name = "gridLeaves";
            this.gridLeaves.ReadOnly = true;
            this.gridLeaves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLeaves.Size = new System.Drawing.Size(648, 248);
            this.gridLeaves.TabIndex = 3;
            this.gridLeaves.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLeaves_RowEnter);
            // 
            // headerGroupYearlyLeaves
            // 
            this.headerGroupYearlyLeaves.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewYearlyLeave,
            this.btnEditYearlyLeave,
            this.btnDeleteYearlyLeave});
            this.headerGroupYearlyLeaves.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerGroupYearlyLeaves.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupYearlyLeaves.Location = new System.Drawing.Point(0, 37);
            this.headerGroupYearlyLeaves.Name = "headerGroupYearlyLeaves";
            this.headerGroupYearlyLeaves.Size = new System.Drawing.Size(648, 28);
            this.headerGroupYearlyLeaves.TabIndex = 1;
            this.headerGroupYearlyLeaves.Values.Description = " ";
            this.headerGroupYearlyLeaves.Values.Heading = "Yearly Leaves Settings";
            this.headerGroupYearlyLeaves.Values.Image = null;
            // 
            // btnAddNewYearlyLeave
            // 
            this.btnAddNewYearlyLeave.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddNewYearlyLeave.Text = "&Add";
            this.btnAddNewYearlyLeave.UniqueName = "BBA117FD695B429FB794A562DB5DE4DE";
            this.btnAddNewYearlyLeave.Click += new System.EventHandler(this.btnAddNewYearlyLeave_Click);
            // 
            // btnEditYearlyLeave
            // 
            this.btnEditYearlyLeave.Image = global::appExcelERP.Properties.Resources.AddressEditor_16x;
            this.btnEditYearlyLeave.Text = "&Edit";
            this.btnEditYearlyLeave.UniqueName = "B3B02139D3E447B7AC97BC3F33E6573F";
            this.btnEditYearlyLeave.Click += new System.EventHandler(this.btnEditYearlyLeave_Click);
            // 
            // btnDeleteYearlyLeave
            // 
            this.btnDeleteYearlyLeave.Text = "&Deactivate";
            this.btnDeleteYearlyLeave.UniqueName = "94E4CE03626F48AFE7862F38066B9F66";
            this.btnDeleteYearlyLeave.Click += new System.EventHandler(this.btnDeleteYearlyLeave_Click);
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.label17);
            this.kryptonPanel1.Controls.Add(this.cboFinYear);
            this.kryptonPanel1.Controls.Add(this.label2);
            this.kryptonPanel1.Controls.Add(this.cboBranch);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(648, 37);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(373, 9);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 20);
            this.label17.TabIndex = 123;
            this.label17.Values.Text = "&Financial Year";
            // 
            // cboFinYear
            // 
            this.cboFinYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFinYear.DropDownWidth = 318;
            this.cboFinYear.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFinYear.FormattingEnabled = true;
            this.cboFinYear.Location = new System.Drawing.Point(466, 9);
            this.cboFinYear.Margin = new System.Windows.Forms.Padding(4);
            this.cboFinYear.Name = "cboFinYear";
            this.cboFinYear.Size = new System.Drawing.Size(178, 21);
            this.cboFinYear.TabIndex = 124;
            this.cboFinYear.SelectedValueChanged += new System.EventHandler(this.cboFinYear_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(69, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 121;
            this.label2.Values.Text = "&Branch";
            // 
            // cboBranch
            // 
            this.cboBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBranch.DropDownWidth = 318;
            this.cboBranch.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBranch.FormattingEnabled = true;
            this.cboBranch.Location = new System.Drawing.Point(115, 9);
            this.cboBranch.Margin = new System.Windows.Forms.Padding(4);
            this.cboBranch.Name = "cboBranch";
            this.cboBranch.Size = new System.Drawing.Size(250, 21);
            this.cboBranch.TabIndex = 122;
            this.cboBranch.SelectedValueChanged += new System.EventHandler(this.cboBranch_SelectedValueChanged);
            // 
            // PageHR_LeavesConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "PageHR_LeavesConfiguration";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(660, 376);
            this.Load += new System.EventHandler(this.PageHR_LeavesConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            this.headerGroupMain.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLeaves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboFinYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader headerGroupYearlyLeaves;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewYearlyLeave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnEditYearlyLeave;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBranch;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel label17;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboFinYear;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridLeaves;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnDeleteYearlyLeave;
    }
}
