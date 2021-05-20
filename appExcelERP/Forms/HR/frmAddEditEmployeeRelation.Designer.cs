namespace appExcelERP.Forms.HR
{
    partial class frmAddEditEmployeeRelation
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
            this.lblselectRelation = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblNameOfRelative = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDateOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblRemark = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboSelectRelation = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.txtRelativeName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.dtDateOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.txtRemark = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblselectRelation
            // 
            this.lblselectRelation.Location = new System.Drawing.Point(19, 9);
            this.lblselectRelation.Name = "lblselectRelation";
            this.lblselectRelation.Size = new System.Drawing.Size(226, 24);
            this.lblselectRelation.TabIndex = 0;
            this.lblselectRelation.Values.Text = "Relationship with the Employee";
            // 
            // lblNameOfRelative
            // 
            this.lblNameOfRelative.Location = new System.Drawing.Point(19, 66);
            this.lblNameOfRelative.Name = "lblNameOfRelative";
            this.lblNameOfRelative.Size = new System.Drawing.Size(131, 24);
            this.lblNameOfRelative.TabIndex = 1;
            this.lblNameOfRelative.Values.Text = "Name Of Relative";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Location = new System.Drawing.Point(104, 126);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(100, 24);
            this.lblDateOfBirth.TabIndex = 2;
            this.lblDateOfBirth.Values.Text = "Date Of Birth";
            // 
            // lblRemark
            // 
            this.lblRemark.Location = new System.Drawing.Point(19, 150);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(63, 24);
            this.lblRemark.TabIndex = 3;
            this.lblRemark.Values.Text = "Remark";
            // 
            // cboSelectRelation
            // 
            this.cboSelectRelation.DropDownWidth = 364;
            this.cboSelectRelation.Location = new System.Drawing.Point(19, 36);
            this.cboSelectRelation.Name = "cboSelectRelation";
            this.cboSelectRelation.Size = new System.Drawing.Size(405, 25);
            this.cboSelectRelation.TabIndex = 4;
            this.cboSelectRelation.Text = "kryptonComboBox1";
            this.cboSelectRelation.Validating += new System.ComponentModel.CancelEventHandler(this.cboSelectRelation_Validating);
            // 
            // txtRelativeName
            // 
            this.txtRelativeName.Location = new System.Drawing.Point(19, 91);
            this.txtRelativeName.Name = "txtRelativeName";
            this.txtRelativeName.Size = new System.Drawing.Size(405, 27);
            this.txtRelativeName.TabIndex = 5;
            this.txtRelativeName.Text = "kryptonTextBox1";
            this.txtRelativeName.Validating += new System.ComponentModel.CancelEventHandler(this.txtRelativeName_Validating);
            // 
            // dtDateOfBirth
            // 
            this.dtDateOfBirth.Location = new System.Drawing.Point(210, 124);
            this.dtDateOfBirth.Name = "dtDateOfBirth";
            this.dtDateOfBirth.ShowCheckBox = true;
            this.dtDateOfBirth.Size = new System.Drawing.Size(214, 25);
            this.dtDateOfBirth.TabIndex = 6;
            this.dtDateOfBirth.ValueNullable = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(19, 179);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(405, 156);
            this.txtRemark.TabIndex = 7;
            this.txtRemark.Text = "kryptonRichTextBox1";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(181, 345);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 31);
            this.btnOK.TabIndex = 9;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 345);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 31);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditEmployeeRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 396);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtDateOfBirth);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblselectRelation);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.txtRelativeName);
            this.Controls.Add(this.lblNameOfRelative);
            this.Controls.Add(this.cboSelectRelation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditEmployeeRelation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditEmployeeRelation";
            this.Load += new System.EventHandler(this.frmAddEditEmployeeRelation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSelectRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblselectRelation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblRemark;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDateOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNameOfRelative;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSelectRelation;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtRelativeName;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtDateOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txtRemark;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}