namespace appExcelERP.Forms.HR
{
    partial class frmAddEditDesignationwiseSalaryHeadValue
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
            this.headerGroupMain = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.rbtnApplicableChargesPercent = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.txtApplicableChargesValue = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.rbtnApplicableChargesLumsum = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.chkIsSelected = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).BeginInit();
            this.headerGroupMain.Panel.SuspendLayout();
            this.headerGroupMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerGroupMain
            // 
            this.headerGroupMain.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnSave,
            this.btnCancel});
            this.headerGroupMain.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockActive;
            this.headerGroupMain.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.DockInactive;
            this.headerGroupMain.Location = new System.Drawing.Point(10, 9);
            this.headerGroupMain.Name = "headerGroupMain";
            // 
            // headerGroupMain.Panel
            // 
            this.headerGroupMain.Panel.Controls.Add(this.rbtnApplicableChargesPercent);
            this.headerGroupMain.Panel.Controls.Add(this.txtApplicableChargesValue);
            this.headerGroupMain.Panel.Controls.Add(this.rbtnApplicableChargesLumsum);
            this.headerGroupMain.Panel.Controls.Add(this.chkIsSelected);
            this.headerGroupMain.Size = new System.Drawing.Size(337, 150);
            this.headerGroupMain.TabIndex = 184;
            this.headerGroupMain.ValuesPrimary.Heading = "Salary HEad Name";
            this.headerGroupMain.ValuesPrimary.Image = null;
            this.headerGroupMain.ValuesSecondary.Heading = "";
            // 
            // btnSave
            // 
            this.btnSave.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnSave.Text = "&Save";
            this.btnSave.UniqueName = "7F5AADB79C8549A200BBFF0712FCF8AB";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UniqueName = "EA9DD6A50160433D508389BC6BDB7766";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbtnApplicableChargesPercent
            // 
            this.rbtnApplicableChargesPercent.Location = new System.Drawing.Point(74, 48);
            this.rbtnApplicableChargesPercent.Name = "rbtnApplicableChargesPercent";
            this.rbtnApplicableChargesPercent.Size = new System.Drawing.Size(56, 20);
            this.rbtnApplicableChargesPercent.TabIndex = 7;
            this.rbtnApplicableChargesPercent.Values.Text = "%wise";
            // 
            // txtApplicableChargesValue
            // 
            this.txtApplicableChargesValue.Location = new System.Drawing.Point(243, 48);
            this.txtApplicableChargesValue.Name = "txtApplicableChargesValue";
            this.txtApplicableChargesValue.Size = new System.Drawing.Size(76, 20);
            this.txtApplicableChargesValue.TabIndex = 9;
            this.txtApplicableChargesValue.Text = "0000000.00";
            this.txtApplicableChargesValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtApplicableChargesValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtApplicableChargesValue_Validating);
            // 
            // rbtnApplicableChargesLumsum
            // 
            this.rbtnApplicableChargesLumsum.Location = new System.Drawing.Point(155, 48);
            this.rbtnApplicableChargesLumsum.Name = "rbtnApplicableChargesLumsum";
            this.rbtnApplicableChargesLumsum.Size = new System.Drawing.Size(69, 20);
            this.rbtnApplicableChargesLumsum.TabIndex = 8;
            this.rbtnApplicableChargesLumsum.Values.Text = "Lumsum";
            // 
            // chkIsSelected
            // 
            this.chkIsSelected.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsSelected.Location = new System.Drawing.Point(26, 17);
            this.chkIsSelected.Name = "chkIsSelected";
            this.chkIsSelected.Size = new System.Drawing.Size(158, 20);
            this.chkIsSelected.TabIndex = 6;
            this.chkIsSelected.Values.Text = "Salary Head Applicable";
            this.chkIsSelected.CheckedChanged += new System.EventHandler(this.chkIsSelected_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditDesignationwiseSalaryHeadValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(359, 173);
            this.Controls.Add(this.headerGroupMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditDesignationwiseSalaryHeadValue";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Salary Head Details";
            this.Load += new System.EventHandler(this.frmAddEditDesignationwiseSalaryHeadValue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain.Panel)).EndInit();
            this.headerGroupMain.Panel.ResumeLayout(false);
            this.headerGroupMain.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerGroupMain)).EndInit();
            this.headerGroupMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup headerGroupMain;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnApplicableChargesPercent;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtApplicableChargesValue;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rbtnApplicableChargesLumsum;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsSelected;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnSave;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}