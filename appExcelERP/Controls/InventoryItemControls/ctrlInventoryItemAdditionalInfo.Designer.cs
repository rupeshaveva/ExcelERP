namespace appExcelERP.Controls.InventoryItemControls
{
    partial class ctrlInventoryItemAdditionalInfo
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
            this.tablePanelInfoForm = new System.Windows.Forms.TableLayoutPanel();
            this.headerGroupDelete = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.txtDeleteInfo = new System.Windows.Forms.RichTextBox();
            this.panelLeft = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblBaseUOM = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtCreatedBy = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.panelRight = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblPurchaseUOM = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtModifiedBy = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.splitContainerGeneralInfo = new ComponentFactory.Krypton.Toolkit.KryptonSplitContainer();
            this.headerGroupItemImage = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnUploadPicture = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.pictureBoxItemImage = new System.Windows.Forms.PictureBox();
            this.tablePanelInfoForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete.Panel)).BeginInit();
            this.headerGroupDelete.Panel.SuspendLayout();
            this.headerGroupDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneralInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneralInfo.Panel1)).BeginInit();
            this.splitContainerGeneralInfo.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneralInfo.Panel2)).BeginInit();
            this.splitContainerGeneralInfo.Panel2.SuspendLayout();
            this.splitContainerGeneralInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupItemImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupItemImage.Panel)).BeginInit();
            this.headerGroupItemImage.Panel.SuspendLayout();
            this.headerGroupItemImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanelInfoForm
            // 
            this.tablePanelInfoForm.ColumnCount = 2;
            this.tablePanelInfoForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelInfoForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelInfoForm.Controls.Add(this.headerGroupDelete, 0, 1);
            this.tablePanelInfoForm.Controls.Add(this.panelLeft, 0, 0);
            this.tablePanelInfoForm.Controls.Add(this.panelRight, 1, 0);
            this.tablePanelInfoForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelInfoForm.Location = new System.Drawing.Point(0, 0);
            this.tablePanelInfoForm.Name = "tablePanelInfoForm";
            this.tablePanelInfoForm.RowCount = 2;
            this.tablePanelInfoForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tablePanelInfoForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tablePanelInfoForm.Size = new System.Drawing.Size(471, 337);
            this.tablePanelInfoForm.TabIndex = 10;
            // 
            // headerGroupDelete
            // 
            this.tablePanelInfoForm.SetColumnSpan(this.headerGroupDelete, 2);
            this.headerGroupDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupDelete.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupDelete.HeaderVisibleSecondary = false;
            this.headerGroupDelete.Location = new System.Drawing.Point(3, 238);
            this.headerGroupDelete.Name = "headerGroupDelete";
            // 
            // headerGroupDelete.Panel
            // 
            this.headerGroupDelete.Panel.Controls.Add(this.txtDeleteInfo);
            this.headerGroupDelete.Size = new System.Drawing.Size(465, 96);
            this.headerGroupDelete.TabIndex = 1;
            this.headerGroupDelete.ValuesPrimary.Image = null;
            // 
            // txtDeleteInfo
            // 
            this.txtDeleteInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeleteInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeleteInfo.Location = new System.Drawing.Point(0, 0);
            this.txtDeleteInfo.Name = "txtDeleteInfo";
            this.txtDeleteInfo.ReadOnly = true;
            this.txtDeleteInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtDeleteInfo.Size = new System.Drawing.Size(463, 72);
            this.txtDeleteInfo.TabIndex = 0;
            this.txtDeleteInfo.Text = "";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblBaseUOM);
            this.panelLeft.Controls.Add(this.txtCreatedBy);
            this.panelLeft.Controls.Add(this.kryptonLabel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(3, 3);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(1);
            this.panelLeft.Size = new System.Drawing.Size(229, 229);
            this.panelLeft.TabIndex = 0;
            // 
            // lblBaseUOM
            // 
            this.lblBaseUOM.AutoSize = false;
            this.lblBaseUOM.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBaseUOM.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblBaseUOM.Location = new System.Drawing.Point(1, 56);
            this.lblBaseUOM.Name = "lblBaseUOM";
            this.lblBaseUOM.Size = new System.Drawing.Size(227, 21);
            this.lblBaseUOM.TabIndex = 11;
            this.lblBaseUOM.Values.Text = "Base UOM";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCreatedBy.Location = new System.Drawing.Point(1, 22);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(227, 34);
            this.txtCreatedBy.TabIndex = 10;
            this.txtCreatedBy.TabStop = false;
            this.txtCreatedBy.Text = "kryptonRichTextBox1";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.AutoSize = false;
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(1, 1);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(227, 21);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Created";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.lblPurchaseUOM);
            this.panelRight.Controls.Add(this.txtModifiedBy);
            this.panelRight.Controls.Add(this.kryptonLabel2);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(238, 3);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(1);
            this.panelRight.Size = new System.Drawing.Size(230, 229);
            this.panelRight.TabIndex = 1;
            // 
            // lblPurchaseUOM
            // 
            this.lblPurchaseUOM.AutoSize = false;
            this.lblPurchaseUOM.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPurchaseUOM.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblPurchaseUOM.Location = new System.Drawing.Point(1, 56);
            this.lblPurchaseUOM.Name = "lblPurchaseUOM";
            this.lblPurchaseUOM.Size = new System.Drawing.Size(228, 21);
            this.lblPurchaseUOM.TabIndex = 13;
            this.lblPurchaseUOM.Values.Text = "Purchase UOM";
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtModifiedBy.Location = new System.Drawing.Point(1, 22);
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.ReadOnly = true;
            this.txtModifiedBy.Size = new System.Drawing.Size(228, 34);
            this.txtModifiedBy.TabIndex = 12;
            this.txtModifiedBy.TabStop = false;
            this.txtModifiedBy.Text = "kryptonRichTextBox2";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.AutoSize = false;
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(1, 1);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(228, 21);
            this.kryptonLabel2.TabIndex = 8;
            this.kryptonLabel2.Values.Text = "Modified";
            // 
            // splitContainerGeneralInfo
            // 
            this.splitContainerGeneralInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainerGeneralInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGeneralInfo.Location = new System.Drawing.Point(5, 5);
            this.splitContainerGeneralInfo.Name = "splitContainerGeneralInfo";
            this.splitContainerGeneralInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerGeneralInfo.Panel1
            // 
            this.splitContainerGeneralInfo.Panel1.Controls.Add(this.tablePanelInfoForm);
            // 
            // splitContainerGeneralInfo.Panel2
            // 
            this.splitContainerGeneralInfo.Panel2.Controls.Add(this.headerGroupItemImage);
            this.splitContainerGeneralInfo.SeparatorStyle = ComponentFactory.Krypton.Toolkit.SeparatorStyle.HighProfile;
            this.splitContainerGeneralInfo.Size = new System.Drawing.Size(471, 499);
            this.splitContainerGeneralInfo.SplitterDistance = 337;
            this.splitContainerGeneralInfo.TabIndex = 11;
            // 
            // headerGroupItemImage
            // 
            this.headerGroupItemImage.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnUploadPicture});
            this.headerGroupItemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupItemImage.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.headerGroupItemImage.HeaderVisibleSecondary = false;
            this.headerGroupItemImage.Location = new System.Drawing.Point(0, 0);
            this.headerGroupItemImage.Name = "headerGroupItemImage";
            // 
            // headerGroupItemImage.Panel
            // 
            this.headerGroupItemImage.Panel.Controls.Add(this.pictureBoxItemImage);
            this.headerGroupItemImage.Size = new System.Drawing.Size(471, 157);
            this.headerGroupItemImage.TabIndex = 2;
            this.headerGroupItemImage.ValuesPrimary.Heading = "Image";
            this.headerGroupItemImage.ValuesPrimary.Image = null;
            this.headerGroupItemImage.ValuesSecondary.Heading = "";
            // 
            // btnUploadPicture
            // 
            this.btnUploadPicture.Text = "&Upload Image";
            this.btnUploadPicture.UniqueName = "259998A223C64F9672A1DAD6FA1D5AC7";
            this.btnUploadPicture.Click += new System.EventHandler(this.btnUploadPicture_Click);
            // 
            // pictureBoxItemImage
            // 
            this.pictureBoxItemImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxItemImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxItemImage.Name = "pictureBoxItemImage";
            this.pictureBoxItemImage.Size = new System.Drawing.Size(469, 128);
            this.pictureBoxItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxItemImage.TabIndex = 0;
            this.pictureBoxItemImage.TabStop = false;
            // 
            // ctrlInventoryItemAdditionalInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainerGeneralInfo);
            this.Name = "ctrlInventoryItemAdditionalInfo";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(481, 509);
            this.Load += new System.EventHandler(this.ctrlInventoryItemAdditionalInfo_Load);
            this.Resize += new System.EventHandler(this.ctrlInventoryItemAdditionalInfo_Resize);
            this.tablePanelInfoForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete.Panel)).EndInit();
            this.headerGroupDelete.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete)).EndInit();
            this.headerGroupDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneralInfo.Panel1)).EndInit();
            this.splitContainerGeneralInfo.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneralInfo.Panel2)).EndInit();
            this.splitContainerGeneralInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGeneralInfo)).EndInit();
            this.splitContainerGeneralInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupItemImage.Panel)).EndInit();
            this.headerGroupItemImage.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupItemImage)).EndInit();
            this.headerGroupItemImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItemImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tablePanelInfoForm;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelLeft;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBaseUOM;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtCreatedBy;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel panelRight;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPurchaseUOM;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtModifiedBy;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonSplitContainer splitContainerGeneralInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupItemImage;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnUploadPicture;
        private System.Windows.Forms.PictureBox pictureBoxItemImage;
        private System.Windows.Forms.RichTextBox txtDeleteInfo;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDelete;
    }
}
