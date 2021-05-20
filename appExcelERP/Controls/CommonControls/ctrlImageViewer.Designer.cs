namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlImageViewer
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
            this.pictBoxDocument = new System.Windows.Forms.PictureBox();
            this.headerGroupPicture = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnStretch = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnAutosize = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnZoom = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.buttonSpecHeaderGroup4 = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPicture.Panel)).BeginInit();
            this.headerGroupPicture.Panel.SuspendLayout();
            this.headerGroupPicture.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictBoxDocument
            // 
            this.pictBoxDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictBoxDocument.Location = new System.Drawing.Point(0, 0);
            this.pictBoxDocument.Name = "pictBoxDocument";
            this.pictBoxDocument.Size = new System.Drawing.Size(382, 203);
            this.pictBoxDocument.TabIndex = 0;
            this.pictBoxDocument.TabStop = false;
            // 
            // headerGroupPicture
            // 
            this.headerGroupPicture.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnStretch,
            this.btnAutosize,
            this.btnZoom,
            this.buttonSpecHeaderGroup4});
            this.headerGroupPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupPicture.Location = new System.Drawing.Point(5, 5);
            this.headerGroupPicture.Name = "headerGroupPicture";
            // 
            // headerGroupPicture.Panel
            // 
            this.headerGroupPicture.Panel.Controls.Add(this.pictBoxDocument);
            this.headerGroupPicture.Size = new System.Drawing.Size(384, 256);
            this.headerGroupPicture.TabIndex = 1;
            this.headerGroupPicture.ValuesPrimary.Image = null;
            // 
            // btnStretch
            // 
            this.btnStretch.Text = "&Stretch";
            this.btnStretch.UniqueName = "74EFE627345A4838BAB7D4A5033D3CD6";
            this.btnStretch.Click += new System.EventHandler(this.btnStretch_Click);
            // 
            // btnAutosize
            // 
            this.btnAutosize.Text = "&Autosize";
            this.btnAutosize.UniqueName = "A905AB042127462ADF991825F0176121";
            this.btnAutosize.Click += new System.EventHandler(this.btnAutosize_Click);
            // 
            // btnZoom
            // 
            this.btnZoom.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Checked;
            this.btnZoom.Text = "&Zoom";
            this.btnZoom.UniqueName = "5C520DF3FD244DCBB2BDA1554D340663";
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // buttonSpecHeaderGroup4
            // 
            this.buttonSpecHeaderGroup4.UniqueName = "D54C7143B1C44F59FC87EE410CCDA0A0";
            // 
            // ctrlImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.headerGroupPicture);
            this.Name = "ctrlImageViewer";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(394, 266);
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPicture.Panel)).EndInit();
            this.headerGroupPicture.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPicture)).EndInit();
            this.headerGroupPicture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictBoxDocument;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupPicture;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnStretch;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnAutosize;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnZoom;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup buttonSpecHeaderGroup4;
    }
}
