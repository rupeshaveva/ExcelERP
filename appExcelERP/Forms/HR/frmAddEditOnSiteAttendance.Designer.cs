namespace appExcelERP.Forms.HR
{
    partial class frmAddEditOnSiteAttendance
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
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtDuration = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblEmpCategoryInfo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtOutTime = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dtIntime = new System.Windows.Forms.DateTimePicker();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboProject = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dtAttendanceDate = new ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker();
            this.lblselectRelation = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblDateOfBirth = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboEmployee = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(9, 142);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(51, 20);
            this.kryptonLabel2.TabIndex = 7;
            this.kryptonLabel2.Values.Text = "InTime";
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(280, 141);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(93, 20);
            this.txtDuration.StateNormal.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.TabIndex = 11;
            this.txtDuration.Text = "sdfsdf";
            // 
            // lblEmpCategoryInfo
            // 
            this.lblEmpCategoryInfo.AutoSize = false;
            this.lblEmpCategoryInfo.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblEmpCategoryInfo.Location = new System.Drawing.Point(145, 82);
            this.lblEmpCategoryInfo.Name = "lblEmpCategoryInfo";
            this.lblEmpCategoryInfo.Size = new System.Drawing.Size(228, 20);
            this.lblEmpCategoryInfo.StateNormal.ShortText.Color1 = System.Drawing.Color.Red;
            this.lblEmpCategoryInfo.StateNormal.ShortText.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.Solid;
            this.lblEmpCategoryInfo.StateNormal.ShortText.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Form;
            this.lblEmpCategoryInfo.StateNormal.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.lblEmpCategoryInfo.StateNormal.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.lblEmpCategoryInfo.TabIndex = 4;
            this.lblEmpCategoryInfo.Values.Text = "Category Info.";
            // 
            // dtOutTime
            // 
            this.dtOutTime.CustomFormat = "hh:mm tt";
            this.dtOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOutTime.Location = new System.Drawing.Point(201, 143);
            this.dtOutTime.Name = "dtOutTime";
            this.dtOutTime.ShowUpDown = true;
            this.dtOutTime.Size = new System.Drawing.Size(73, 20);
            this.dtOutTime.TabIndex = 10;
            this.dtOutTime.ValueChanged += new System.EventHandler(this.dtOutTime_ValueChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel6.Location = new System.Drawing.Point(137, 142);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel6.TabIndex = 9;
            this.kryptonLabel6.Values.Text = "Out Time";
            // 
            // dtIntime
            // 
            this.dtIntime.CustomFormat = "hh:mm tt";
            this.dtIntime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIntime.Location = new System.Drawing.Point(60, 143);
            this.dtIntime.Name = "dtIntime";
            this.dtIntime.ShowUpDown = true;
            this.dtIntime.Size = new System.Drawing.Size(73, 20);
            this.dtIntime.TabIndex = 8;
            this.dtIntime.ValueChanged += new System.EventHandler(this.dtIntime_ValueChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(9, 82);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(84, 20);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Project Name";
            // 
            // cboProject
            // 
            this.cboProject.DropDownWidth = 364;
            this.cboProject.Location = new System.Drawing.Point(9, 104);
            this.cboProject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(365, 21);
            this.cboProject.TabIndex = 6;
            this.cboProject.Text = "kryptonComboBox1";
            this.cboProject.Validating += new System.ComponentModel.CancelEventHandler(this.cboProject_Validating);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(209, 179);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 12;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(293, 179);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dtAttendanceDate
            // 
            this.dtAttendanceDate.CustomFormat = "dd/MM/yyyy";
            this.dtAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAttendanceDate.Location = new System.Drawing.Point(276, 11);
            this.dtAttendanceDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtAttendanceDate.Name = "dtAttendanceDate";
            this.dtAttendanceDate.Size = new System.Drawing.Size(97, 21);
            this.dtAttendanceDate.TabIndex = 1;
            this.dtAttendanceDate.ValueNullable = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtAttendanceDate.ValueChanged += new System.EventHandler(this.dtAttendanceDate_ValueChanged);
            // 
            // lblselectRelation
            // 
            this.lblselectRelation.Location = new System.Drawing.Point(9, 34);
            this.lblselectRelation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblselectRelation.Name = "lblselectRelation";
            this.lblselectRelation.Size = new System.Drawing.Size(100, 20);
            this.lblselectRelation.TabIndex = 2;
            this.lblselectRelation.Values.Text = "Employee Name";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.Location = new System.Drawing.Point(172, 11);
            this.lblDateOfBirth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(102, 20);
            this.lblDateOfBirth.TabIndex = 0;
            this.lblDateOfBirth.Values.Text = "Attendance Date";
            // 
            // cboEmployee
            // 
            this.cboEmployee.DropDownWidth = 364;
            this.cboEmployee.Location = new System.Drawing.Point(9, 56);
            this.cboEmployee.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(365, 21);
            this.cboEmployee.TabIndex = 3;
            this.cboEmployee.Text = "kryptonComboBox1";
            this.cboEmployee.Validating += new System.ComponentModel.CancelEventHandler(this.cboEmployee_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditOnSiteAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(384, 225);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.lblEmpCategoryInfo);
            this.Controls.Add(this.dtOutTime);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.dtIntime);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtAttendanceDate);
            this.Controls.Add(this.lblselectRelation);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.cboEmployee);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditOnSiteAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "On Site Attendance Entry ";
            this.Load += new System.EventHandler(this.frmAddEditOnSiteAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtDuration;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblEmpCategoryInfo;
        private System.Windows.Forms.DateTimePicker dtOutTime;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private System.Windows.Forms.DateTimePicker dtIntime;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboProject;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonDateTimePicker dtAttendanceDate;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblselectRelation;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblDateOfBirth;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboEmployee;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}