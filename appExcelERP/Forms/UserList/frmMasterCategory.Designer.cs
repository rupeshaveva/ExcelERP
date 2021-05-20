namespace appExcelERP.Forms.UserList
{
    partial class frmMasterCategory
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
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblCategoryName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtCategoryName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(192, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Values.Text = "&Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(96, 97);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 10;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Location = new System.Drawing.Point(12, 12);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(193, 20);
            this.lblCategoryName.TabIndex = 6;
            this.lblCategoryName.Values.Text = "Master Category Name (MASTER)";
            // 
            // chkIsActive
            // 
            this.chkIsActive.CheckPosition = ComponentFactory.Krypton.Toolkit.VisualOrientation.Right;
            this.chkIsActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsActive.Location = new System.Drawing.Point(209, 58);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(1);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(73, 20);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Values.Text = "Is &Active";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCategoryName.Location = new System.Drawing.Point(12, 34);
            this.txtCategoryName.MaxLength = 100;
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(270, 20);
            this.txtCategoryName.TabIndex = 7;
            this.txtCategoryName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCategoryName_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmMasterCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 137);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtCategoryName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMasterCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit MASTER Category";
            this.Load += new System.EventHandler(this.frmMasterCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCategoryName;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCategoryName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}