namespace appExcelERP.Forms
{
    partial class frmDelete
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
            this.txtDescription = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.headerGroupDelete = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtRemarks = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete.Panel)).BeginInit();
            this.headerGroupDelete.Panel.SuspendLayout();
            this.headerGroupDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(12, 12);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(373, 71);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.TabStop = false;
            this.txtDescription.Text = "kryptonRichTextBox1";
            // 
            // headerGroupDelete
            // 
            this.headerGroupDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerGroupDelete.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnOK,
            this.btnCancel});
            this.headerGroupDelete.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupDelete.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this.headerGroupDelete.Location = new System.Drawing.Point(13, 89);
            this.headerGroupDelete.Name = "headerGroupDelete";
            // 
            // headerGroupDelete.Panel
            // 
            this.headerGroupDelete.Panel.Controls.Add(this.txtRemarks);
            this.headerGroupDelete.Size = new System.Drawing.Size(372, 176);
            this.headerGroupDelete.TabIndex = 1;
            this.headerGroupDelete.ValuesPrimary.Heading = "Reason for Deleting this Record";
            this.headerGroupDelete.ValuesPrimary.Image = null;
            this.headerGroupDelete.ValuesSecondary.Heading = "";
            // 
            // btnOK
            // 
            this.btnOK.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnOK.Text = "&OK";
            this.btnOK.UniqueName = "4523322095404929DAB11BBA13444D70";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "002E5AE704E148E325B5069460916496";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(0, 0);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(370, 125);
            this.txtRemarks.TabIndex = 1;
            this.txtRemarks.Text = "";
            this.txtRemarks.Validating += new System.ComponentModel.CancelEventHandler(this.txtRemarks_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(397, 277);
            this.Controls.Add(this.headerGroupDelete);
            this.Controls.Add(this.txtDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDelete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Delete Record";
            this.Load += new System.EventHandler(this.frmDelete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete.Panel)).EndInit();
            this.headerGroupDelete.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupDelete)).EndInit();
            this.headerGroupDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtDescription;
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupDelete;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtRemarks;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnOK;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}