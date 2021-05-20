namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    partial class frmBOQExportToExcel
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
            this.kryptonHeaderGroup1 = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.rbtnParentAndChildItems = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.rbtnParentItemsOnly = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.chkIncludeMaterialSupplyCharges = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.chkIncludeInstallationCharges = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).BeginInit();
            this.kryptonHeaderGroup1.Panel.SuspendLayout();
            this.kryptonHeaderGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeaderGroup1
            // 
            this.kryptonHeaderGroup1.AutoSize = true;
            this.kryptonHeaderGroup1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnOK,
            this.btnCancel});
            this.kryptonHeaderGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonHeaderGroup1.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.kryptonHeaderGroup1.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.kryptonHeaderGroup1.Location = new System.Drawing.Point(5, 5);
            this.kryptonHeaderGroup1.Name = "kryptonHeaderGroup1";
            // 
            // kryptonHeaderGroup1.Panel
            // 
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.rbtnParentAndChildItems);
            this.kryptonHeaderGroup1.Panel.Controls.Add(this.rbtnParentItemsOnly);
            this.kryptonHeaderGroup1.Size = new System.Drawing.Size(297, 150);
            this.kryptonHeaderGroup1.TabIndex = 0;
            this.kryptonHeaderGroup1.ValuesPrimary.Heading = "Configure";
            this.kryptonHeaderGroup1.ValuesPrimary.Image = null;
            this.kryptonHeaderGroup1.ValuesSecondary.Heading = "";
            // 
            // btnOK
            // 
            this.btnOK.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnOK.Text = "&OK";
            this.btnOK.UniqueName = "7D5BC15ED5D34FEEAAB36D69F94CB3B2";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "F44F3E8C22094D02C8A1B458203907ED";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbtnParentAndChildItems
            // 
            this.rbtnParentAndChildItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnParentAndChildItems.Location = new System.Drawing.Point(139, 5);
            this.rbtnParentAndChildItems.Name = "rbtnParentAndChildItems";
            this.rbtnParentAndChildItems.Size = new System.Drawing.Size(136, 20);
            this.rbtnParentAndChildItems.TabIndex = 1;
            this.rbtnParentAndChildItems.Values.Text = "&Including child Items";
            // 
            // rbtnParentItemsOnly
            // 
            this.rbtnParentItemsOnly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.rbtnParentItemsOnly.Location = new System.Drawing.Point(12, 5);
            this.rbtnParentItemsOnly.Name = "rbtnParentItemsOnly";
            this.rbtnParentItemsOnly.Size = new System.Drawing.Size(117, 20);
            this.rbtnParentItemsOnly.TabIndex = 0;
            this.rbtnParentItemsOnly.Values.Text = "&Parent Items only";
            // 
            // chkIncludeMaterialSupplyCharges
            // 
            this.chkIncludeMaterialSupplyCharges.Location = new System.Drawing.Point(18, 63);
            this.chkIncludeMaterialSupplyCharges.Name = "chkIncludeMaterialSupplyCharges";
            this.chkIncludeMaterialSupplyCharges.Size = new System.Drawing.Size(199, 20);
            this.chkIncludeMaterialSupplyCharges.TabIndex = 1;
            this.chkIncludeMaterialSupplyCharges.Values.Text = "Include Material Supply Charges";
            // 
            // chkIncludeInstallationCharges
            // 
            this.chkIncludeInstallationCharges.Location = new System.Drawing.Point(18, 89);
            this.chkIncludeInstallationCharges.Name = "chkIncludeInstallationCharges";
            this.chkIncludeInstallationCharges.Size = new System.Drawing.Size(229, 20);
            this.chkIncludeInstallationCharges.TabIndex = 2;
            this.chkIncludeInstallationCharges.Values.Text = "Include Installation && Service Charges";
            // 
            // frmBOQExportToExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 160);
            this.Controls.Add(this.chkIncludeInstallationCharges);
            this.Controls.Add(this.chkIncludeMaterialSupplyCharges);
            this.Controls.Add(this.kryptonHeaderGroup1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBOQExportToExcel";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Sales Quotation BOQ to Excel";
            this.Load += new System.EventHandler(this.frmBOQExportToExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1.Panel)).EndInit();
            this.kryptonHeaderGroup1.Panel.ResumeLayout(false);
            this.kryptonHeaderGroup1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonHeaderGroup1)).EndInit();
            this.kryptonHeaderGroup1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup kryptonHeaderGroup1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnOK;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnParentAndChildItems;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnParentItemsOnly;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIncludeMaterialSupplyCharges;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIncludeInstallationCharges;
    }
}