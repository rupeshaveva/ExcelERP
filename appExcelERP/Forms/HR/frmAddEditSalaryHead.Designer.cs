namespace appExcelERP.Forms.HR
{
    partial class frmAddEditSalaryHead
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
            this.cboSalaryHeadNature = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblBranchState = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboSalaryHeadType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblBranchCountryName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblSalaryHead = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtSalaryHead = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.btnAddNewSalaryHead = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtSequence = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboSalaryHeadNature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalaryHeadType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSalaryHeadNature
            // 
            this.cboSalaryHeadNature.DropDownWidth = 121;
            this.cboSalaryHeadNature.FormattingEnabled = true;
            this.cboSalaryHeadNature.Location = new System.Drawing.Point(15, 171);
            this.cboSalaryHeadNature.Margin = new System.Windows.Forms.Padding(4);
            this.cboSalaryHeadNature.Name = "cboSalaryHeadNature";
            this.cboSalaryHeadNature.Size = new System.Drawing.Size(369, 25);
            this.cboSalaryHeadNature.TabIndex = 20;
            this.cboSalaryHeadNature.Validating += new System.ComponentModel.CancelEventHandler(this.cboSalaryHeadNature_Validating);
            // 
            // lblBranchState
            // 
            this.lblBranchState.Location = new System.Drawing.Point(14, 139);
            this.lblBranchState.Margin = new System.Windows.Forms.Padding(4);
            this.lblBranchState.Name = "lblBranchState";
            this.lblBranchState.Size = new System.Drawing.Size(143, 24);
            this.lblBranchState.TabIndex = 19;
            this.lblBranchState.Values.Text = "Salary Head Nature";
            // 
            // cboSalaryHeadType
            // 
            this.cboSalaryHeadType.DropDownWidth = 121;
            this.cboSalaryHeadType.FormattingEnabled = true;
            this.cboSalaryHeadType.Location = new System.Drawing.Point(14, 106);
            this.cboSalaryHeadType.Margin = new System.Windows.Forms.Padding(4);
            this.cboSalaryHeadType.Name = "cboSalaryHeadType";
            this.cboSalaryHeadType.Size = new System.Drawing.Size(369, 25);
            this.cboSalaryHeadType.TabIndex = 18;
            this.cboSalaryHeadType.Validating += new System.ComponentModel.CancelEventHandler(this.cboSalaryHeadType_Validating);
            // 
            // lblBranchCountryName
            // 
            this.lblBranchCountryName.Location = new System.Drawing.Point(14, 74);
            this.lblBranchCountryName.Margin = new System.Windows.Forms.Padding(4);
            this.lblBranchCountryName.Name = "lblBranchCountryName";
            this.lblBranchCountryName.Size = new System.Drawing.Size(129, 24);
            this.lblBranchCountryName.TabIndex = 17;
            this.lblBranchCountryName.Values.Text = "Salary Head Type";
            // 
            // lblSalaryHead
            // 
            this.lblSalaryHead.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaryHead.ForeColor = System.Drawing.Color.Black;
            this.lblSalaryHead.Location = new System.Drawing.Point(14, 9);
            this.lblSalaryHead.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSalaryHead.Name = "lblSalaryHead";
            this.lblSalaryHead.Size = new System.Drawing.Size(92, 24);
            this.lblSalaryHead.TabIndex = 15;
            this.lblSalaryHead.Values.Text = "Salary Head";
            // 
            // txtSalaryHead
            // 
            this.txtSalaryHead.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewSalaryHead});
            this.txtSalaryHead.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalaryHead.Location = new System.Drawing.Point(14, 38);
            this.txtSalaryHead.Margin = new System.Windows.Forms.Padding(5);
            this.txtSalaryHead.Name = "txtSalaryHead";
            this.txtSalaryHead.Size = new System.Drawing.Size(370, 27);
            this.txtSalaryHead.TabIndex = 16;
            this.txtSalaryHead.Validating += new System.ComponentModel.CancelEventHandler(this.txtSalaryHead_Validating);
            // 
            // btnAddNewSalaryHead
            // 
            this.btnAddNewSalaryHead.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewSalaryHead.UniqueName = "B879AB3AC3634A48568709F94BE74CD9";
            this.btnAddNewSalaryHead.Click += new System.EventHandler(this.btnAddNewSalaryHead_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(276, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 34);
            this.btnClose.TabIndex = 24;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(156, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 34);
            this.btnSave.TabIndex = 23;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSequence
            // 
            this.txtSequence.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSequence.Location = new System.Drawing.Point(276, 201);
            this.txtSequence.Margin = new System.Windows.Forms.Padding(4);
            this.txtSequence.MaxLength = 50;
            this.txtSequence.Name = "txtSequence";
            this.txtSequence.Size = new System.Drawing.Size(108, 27);
            this.txtSequence.TabIndex = 26;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(178, 204);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(4);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(78, 24);
            this.kryptonLabel2.TabIndex = 25;
            this.kryptonLabel2.Values.Text = "Sequence";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(13, 203);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(81, 24);
            this.chkIsActive.TabIndex = 27;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditSalaryHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(415, 317);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtSequence);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.cboSalaryHeadNature);
            this.Controls.Add(this.lblBranchState);
            this.Controls.Add(this.cboSalaryHeadType);
            this.Controls.Add(this.lblBranchCountryName);
            this.Controls.Add(this.lblSalaryHead);
            this.Controls.Add(this.txtSalaryHead);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditSalaryHead";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Salary Head";
            this.Load += new System.EventHandler(this.frmAddEditSalaryHead_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSalaryHeadNature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSalaryHeadType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSalaryHeadNature;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBranchState;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboSalaryHeadType;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBranchCountryName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSalaryHead;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSalaryHead;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewSalaryHead;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtSequence;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}