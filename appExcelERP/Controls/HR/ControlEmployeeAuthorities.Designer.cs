namespace appExcelERP.Controls.HR
{
    partial class ControlEmployeeAuthorities
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
            this.btnAddMoreAuthorities = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnRemoveAthorities = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.gridAuthorities = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAuthorities)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnAddMoreAuthorities,
            this.btnRemoveAthorities});
            this.headerGroupMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupMain.Location = new System.Drawing.Point(0, 0);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.gridAuthorities);
            this.headerGroupMain.Size = new System.Drawing.Size(797, 475);
            this.headerGroupMain.TabIndex = 0;
            this.headerGroupMain.ValuesPrimary.Heading = "Following Users are authorized to View/Moniter ";
            this.headerGroupMain.ValuesPrimary.Image = null;
            // 
            // btnAddMoreAuthorities
            // 
            this.btnAddMoreAuthorities.Image = global::appExcelERP.Properties.Resources.AddNewDictionary_16x;
            this.btnAddMoreAuthorities.Text = "&Add More Authorities";
            this.btnAddMoreAuthorities.UniqueName = "8AA1464DB0524D796B91B30777F9EE93";
            this.btnAddMoreAuthorities.Click += new System.EventHandler(this.btnAddMoreAuthorities_Click);
            // 
            // btnRemoveAthorities
            // 
            this.btnRemoveAthorities.Image = global::appExcelERP.Properties.Resources.RemoveGuide_16x;
            this.btnRemoveAthorities.Text = "&Remove Selected Authority";
            this.btnRemoveAthorities.UniqueName = "999E57C7FC714B58B4B5DAFCB61B2371";
            this.btnRemoveAthorities.Click += new System.EventHandler(this.btnRemoveAthorities_Click);
            // 
            // gridAuthorities
            // 
            this.gridAuthorities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAuthorities.Location = new System.Drawing.Point(0, 0);
            this.gridAuthorities.Name = "gridAuthorities";
            this.gridAuthorities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAuthorities.Size = new System.Drawing.Size(795, 424);
            this.gridAuthorities.TabIndex = 0;
            this.gridAuthorities.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAuthorities_RowEnter);
            // 
            // ControlEmployeeAuthorities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupMain);
            this.Name = "ControlEmployeeAuthorities";
            this.Size = new System.Drawing.Size(797, 475);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAuthorities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridAuthorities;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAddMoreAuthorities;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnRemoveAthorities;
    }
}
