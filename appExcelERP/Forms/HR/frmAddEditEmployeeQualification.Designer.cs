namespace appExcelERP.Forms.HR
{
    partial class frmAddEditEmployeeQualification
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
            this.txtQualification = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblNameOfRelative = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtNameOfInstitute = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtGradeClass = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQualification
            // 
            this.txtQualification.Location = new System.Drawing.Point(9, 33);
            this.txtQualification.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQualification.Name = "txtQualification";
            this.txtQualification.Size = new System.Drawing.Size(304, 20);
            this.txtQualification.TabIndex = 7;
            this.txtQualification.Text = "kryptonTextBox1";
            this.txtQualification.Validating += new System.ComponentModel.CancelEventHandler(this.txtQualification_Validating);
            // 
            // lblNameOfRelative
            // 
            this.lblNameOfRelative.Location = new System.Drawing.Point(9, 7);
            this.lblNameOfRelative.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblNameOfRelative.Name = "lblNameOfRelative";
            this.lblNameOfRelative.Size = new System.Drawing.Size(79, 20);
            this.lblNameOfRelative.TabIndex = 6;
            this.lblNameOfRelative.Values.Text = "Qualification";
            // 
            // txtNameOfInstitute
            // 
            this.txtNameOfInstitute.Location = new System.Drawing.Point(9, 88);
            this.txtNameOfInstitute.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNameOfInstitute.Name = "txtNameOfInstitute";
            this.txtNameOfInstitute.Size = new System.Drawing.Size(304, 20);
            this.txtNameOfInstitute.TabIndex = 9;
            this.txtNameOfInstitute.Text = "kryptonTextBox1";
            this.txtNameOfInstitute.Validating += new System.ComponentModel.CancelEventHandler(this.txtNameOfInstitute_Validating);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(9, 62);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(108, 20);
            this.kryptonLabel1.TabIndex = 8;
            this.kryptonLabel1.Values.Text = "Name Of Institute";
            // 
            // txtGradeClass
            // 
            this.txtGradeClass.Location = new System.Drawing.Point(9, 142);
            this.txtGradeClass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGradeClass.Name = "txtGradeClass";
            this.txtGradeClass.Size = new System.Drawing.Size(304, 20);
            this.txtGradeClass.TabIndex = 11;
            this.txtGradeClass.Text = "kryptonTextBox1";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(9, 116);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(79, 20);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "Grade/ Class";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 179);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(82, 25);
            this.btnOK.TabIndex = 12;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(212, 179);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditEmployeeQualification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(325, 213);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtGradeClass);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtNameOfInstitute);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.txtQualification);
            this.Controls.Add(this.lblNameOfRelative);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditEmployeeQualification";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Employee Qualification";
            this.Load += new System.EventHandler(this.frmAddEditEmployeeQualification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtQualification;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblNameOfRelative;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtNameOfInstitute;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtGradeClass;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}