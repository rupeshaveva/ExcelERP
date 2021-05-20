namespace appExcelERP.Forms
{
    partial class frmSetPassword
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
            this.headerGroupPassword = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnChange = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.txtRetypePassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPassword = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPassword.Panel)).BeginInit();
            this.headerGroupPassword.Panel.SuspendLayout();
            this.headerGroupPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupPassword
            // 
            this.headerGroupPassword.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnChange,
            this.btnCancel});
            this.headerGroupPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerGroupPassword.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupPassword.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupPassword.Location = new System.Drawing.Point(7, 6);
            this.headerGroupPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.headerGroupPassword.Name = "headerGroupPassword";
            // 
            // headerGroupPassword.Panel
            // 
            this.headerGroupPassword.Panel.Controls.Add(this.txtRetypePassword);
            this.headerGroupPassword.Panel.Controls.Add(this.kryptonLabel2);
            this.headerGroupPassword.Panel.Controls.Add(this.txtPassword);
            this.headerGroupPassword.Panel.Controls.Add(this.kryptonLabel1);
            this.headerGroupPassword.Size = new System.Drawing.Size(462, 187);
            this.headerGroupPassword.TabIndex = 0;
            this.headerGroupPassword.ValuesPrimary.Image = null;
            this.headerGroupPassword.ValuesSecondary.Heading = "";
            // 
            // btnChange
            // 
            this.btnChange.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnChange.Text = "C&hange";
            this.btnChange.UniqueName = "8707D99D587A4F52EB9813790921FA2D";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "E6030197C5144763198E794452C6A6AD";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRetypePassword
            // 
            this.txtRetypePassword.Location = new System.Drawing.Point(168, 65);
            this.txtRetypePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRetypePassword.Name = "txtRetypePassword";
            this.txtRetypePassword.PasswordChar = '●';
            this.txtRetypePassword.Size = new System.Drawing.Size(240, 27);
            this.txtRetypePassword.TabIndex = 3;
            this.txtRetypePassword.UseSystemPasswordChar = true;
            this.txtRetypePassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtRetypePassword_Validating);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(29, 65);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(127, 24);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "&Retype Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(168, 33);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(240, 27);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(47, 33);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(111, 24);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "New Password";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmSetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(476, 199);
            this.Controls.Add(this.headerGroupPassword);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetPassword";
            this.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmSetPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPassword.Panel)).EndInit();
            this.headerGroupPassword.Panel.ResumeLayout(false);
            this.headerGroupPassword.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupPassword)).EndInit();
            this.headerGroupPassword.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupPassword;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnChange;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRetypePassword;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPassword;
    }
}