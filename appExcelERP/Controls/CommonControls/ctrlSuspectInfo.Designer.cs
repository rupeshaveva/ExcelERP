namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlSuspectInfo
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
            this.headerGroupSuspectInfo = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnAddSuspectCategory = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnUpdate = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridData = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSuspectInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSuspectInfo.Panel)).BeginInit();
            this.headerGroupSuspectInfo.Panel.SuspendLayout();
            this.headerGroupSuspectInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupSuspectInfo
            // 
            this.headerGroupSuspectInfo.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddSuspectCategory,
            this.btnUpdate,
            this.btnCancel});
            this.headerGroupSuspectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupSuspectInfo.Location = new System.Drawing.Point(5, 5);
            this.headerGroupSuspectInfo.Name = "headerGroupSuspectInfo";
            // 
            // headerGroupSuspectInfo.Panel
            // 
            this.headerGroupSuspectInfo.Panel.AutoScroll = true;
            this.headerGroupSuspectInfo.Panel.Controls.Add(this.gridData);
            this.headerGroupSuspectInfo.Panel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.headerGroupSuspectInfo.Panel.Padding = new System.Windows.Forms.Padding(5);
            this.headerGroupSuspectInfo.Size = new System.Drawing.Size(448, 433);
            this.headerGroupSuspectInfo.TabIndex = 0;
            this.headerGroupSuspectInfo.ValuesPrimary.Heading = "Suspect Info.";
            this.headerGroupSuspectInfo.ValuesPrimary.Image = null;
            // 
            // btnAddSuspectCategory
            // 
            this.btnAddSuspectCategory.Text = "&Add New Suspect Category";
            this.btnAddSuspectCategory.UniqueName = "86160566171D4B6FBAA9248D6952FF66";
            this.btnAddSuspectCategory.Click += new System.EventHandler(this.btnAddSuspectCategory_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnUpdate.Text = "&Update Info.";
            this.btnUpdate.UniqueName = "B2BB9155E53A4392D7A039B5256DA2AE";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "D4B7C6A1923D42EB83B272631FA7EA8A";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeColumns = false;
            this.gridData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridData.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridData.GridStyles.StyleBackground = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.GridHeaderColumnSheet;
            this.gridData.GridStyles.StyleRow = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridData.Location = new System.Drawing.Point(77, 142);
            this.gridData.MultiSelect = false;
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.Size = new System.Drawing.Size(126, 28);
            this.gridData.TabIndex = 0;
            // 
            // ctrlSuspectInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupSuspectInfo);
            this.Name = "ctrlSuspectInfo";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(458, 443);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSuspectInfo.Panel)).EndInit();
            this.headerGroupSuspectInfo.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupSuspectInfo)).EndInit();
            this.headerGroupSuspectInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupSuspectInfo;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddSuspectCategory;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUpdate;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridData;
    }
}
