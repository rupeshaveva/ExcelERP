namespace appExcelERP.Controls.CommonControls
{
    partial class ctrlProgressViewer
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.headerProgressViewer = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.lblProgressText = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(10, 145);
            this.progressBar1.MarqueeAnimationSpeed = 200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // headerProgressViewer
            // 
            this.headerProgressViewer.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerProgressViewer.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerProgressViewer.Location = new System.Drawing.Point(10, 10);
            this.headerProgressViewer.Name = "headerProgressViewer";
            this.headerProgressViewer.Size = new System.Drawing.Size(400, 26);
            this.headerProgressViewer.TabIndex = 4;
            this.headerProgressViewer.Values.Heading = "kryptonHeader1";
            this.headerProgressViewer.Values.Image = null;
            // 
            // lblProgressText
            // 
            this.lblProgressText.AutoSize = false;
            this.lblProgressText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgressText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProgressText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.lblProgressText.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.SuperTip;
            this.lblProgressText.Location = new System.Drawing.Point(10, 36);
            this.lblProgressText.Name = "lblProgressText";
            this.lblProgressText.Padding = new System.Windows.Forms.Padding(5);
            this.lblProgressText.Size = new System.Drawing.Size(400, 109);
            this.lblProgressText.Text = "Progress Message Text";
            // 
            // ctrlProgressViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblProgressText);
            this.Controls.Add(this.headerProgressViewer);
            this.Controls.Add(this.progressBar1);
            this.Name = "ctrlProgressViewer";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(420, 178);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ProgressBar progressBar1;
        public ComponentFactory.Krypton.Toolkit.KryptonHeader headerProgressViewer;
        public ComponentFactory.Krypton.Toolkit.KryptonWrapLabel lblProgressText;
    }
}
