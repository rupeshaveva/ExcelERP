namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlTermsAndCondition
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
            this.btnAddNewTermAndCondition = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.buttonSpecHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.buttonSpecHeaderGroup2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridTerms = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition.Panel)).BeginInit();
            this.headerGroupTermsAndCondition.Panel.SuspendLayout();
            this.headerGroupTermsAndCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTerms)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupTermsAndCondition
            // 
            this.headerGroupTermsAndCondition.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddNewTermAndCondition,
            this.buttonSpecHeaderGroup1,
            this.buttonSpecHeaderGroup2});
            this.headerGroupTermsAndCondition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupTermsAndCondition.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlGroupBox;
            this.headerGroupTermsAndCondition.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupTermsAndCondition.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupTermsAndCondition.Location = new System.Drawing.Point(5, 5);
            this.headerGroupTermsAndCondition.Name = "headerGroupTermsAndCondition";
            // 
            // headerGroupTermsAndCondition.Panel
            // 
            this.headerGroupTermsAndCondition.Panel.Controls.Add(this.gridTerms);
            this.headerGroupTermsAndCondition.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupTermsAndCondition.Size = new System.Drawing.Size(583, 311);
            this.headerGroupTermsAndCondition.TabIndex = 0;
            this.headerGroupTermsAndCondition.ValuesSecondary.Description = "sample text";
            this.headerGroupTermsAndCondition.ValuesSecondary.Heading = "";
            // 
            // btnAddNewTermAndCondition
            // 
            this.btnAddNewTermAndCondition.Text = "&Add New Term && Condition";
            this.btnAddNewTermAndCondition.UniqueName = "AD8E814CB6CD4257E7B3CFE6D24EB873";
            this.btnAddNewTermAndCondition.Click += new System.EventHandler(this.btnAddNewTermAndCondition_Click);
            // 
            // buttonSpecHeaderGroup1
            // 
            this.buttonSpecHeaderGroup1.Text = "&Edit Selected Term";
            this.buttonSpecHeaderGroup1.UniqueName = "D039EF8FE0EE494ACFA4F4C206116AD8";
            // 
            // buttonSpecHeaderGroup2
            // 
            this.buttonSpecHeaderGroup2.Text = "&Delete Selected Term";
            this.buttonSpecHeaderGroup2.UniqueName = "61E6C2CA67274D3BBAAC046059191873";
            // 
            // gridTerms
            // 
            this.gridTerms.AllowUserToAddRows = false;
            this.gridTerms.AllowUserToOrderColumns = true;
            this.gridTerms.AllowUserToResizeColumns = false;
            this.gridTerms.AllowUserToResizeRows = false;
            this.gridTerms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTerms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridTerms.ColumnHeadersVisible = false;
            this.gridTerms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTerms.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridTerms.GridStyles.StyleDataCells = ComponentFactory.Krypton.Toolkit.GridStyle.Custom1;
            this.gridTerms.HideOuterBorders = true;
            this.gridTerms.Location = new System.Drawing.Point(5, 5);
            this.gridTerms.MultiSelect = false;
            this.gridTerms.Name = "gridTerms";
            this.gridTerms.ReadOnly = true;
            this.gridTerms.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTerms.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTerms.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridTerms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTerms.Size = new System.Drawing.Size(571, 247);
            this.gridTerms.StandardTab = true;
            this.gridTerms.TabIndex = 0;
            // 
            // ctrlTermsAndCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupTermsAndCondition);
            this.Name = "ctrlTermsAndCondition";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(593, 321);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition.Panel)).EndInit();
            this.headerGroupTermsAndCondition.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupTermsAndCondition)).EndInit();
            this.headerGroupTermsAndCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTerms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupTermsAndCondition;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddNewTermAndCondition;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup2;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridTerms;
    }
}
