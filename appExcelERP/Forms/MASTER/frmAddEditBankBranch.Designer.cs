namespace appExcelERP.Forms.MASTER
{
    partial class frmAddEditBankBranch
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
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSave = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.txtBranchName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblBankBranchName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblIFCCode = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtBranchIFSCCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.txtBankBranchAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.lblBankAddress = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBranchStates = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblBranchState = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBranchCountries = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblBranchCountryName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboBranchCity = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.lblBranchCity = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranchStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranchCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranchCity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(301, 254);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 28);
            this.btnClose.TabIndex = 14;
            this.btnClose.Values.Text = "&Cancel";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(211, 254);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 28);
            this.btnSave.TabIndex = 13;
            this.btnSave.Values.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.chkIsActive.Location = new System.Drawing.Point(314, 6);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(73, 20);
            this.chkIsActive.TabIndex = 1;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // txtBranchName
            // 
            this.txtBranchName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBranchName.Location = new System.Drawing.Point(13, 32);
            this.txtBranchName.MaxLength = 50;
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(368, 20);
            this.txtBranchName.TabIndex = 2;
            this.txtBranchName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBranchName_Validating);
            // 
            // lblBankBranchName
            // 
            this.lblBankBranchName.Location = new System.Drawing.Point(13, 10);
            this.lblBankBranchName.Name = "lblBankBranchName";
            this.lblBankBranchName.Size = new System.Drawing.Size(114, 20);
            this.lblBankBranchName.TabIndex = 0;
            this.lblBankBranchName.Values.Text = "&Bank Branch Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblIFCCode
            // 
            this.lblIFCCode.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIFCCode.ForeColor = System.Drawing.Color.Black;
            this.lblIFCCode.Location = new System.Drawing.Point(134, 139);
            this.lblIFCCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIFCCode.Name = "lblIFCCode";
            this.lblIFCCode.Size = new System.Drawing.Size(66, 20);
            this.lblIFCCode.TabIndex = 5;
            this.lblIFCCode.Values.Text = "IFSC Code";
            // 
            // txtBranchIFSCCode
            // 
            this.txtBranchIFSCCode.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchIFSCCode.Location = new System.Drawing.Point(202, 139);
            this.txtBranchIFSCCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBranchIFSCCode.Name = "txtBranchIFSCCode";
            this.txtBranchIFSCCode.Size = new System.Drawing.Size(179, 20);
            this.txtBranchIFSCCode.TabIndex = 6;
            // 
            // txtBankBranchAddress
            // 
            this.txtBankBranchAddress.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankBranchAddress.Location = new System.Drawing.Point(13, 80);
            this.txtBankBranchAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBankBranchAddress.Multiline = true;
            this.txtBankBranchAddress.Name = "txtBankBranchAddress";
            this.txtBankBranchAddress.Size = new System.Drawing.Size(368, 55);
            this.txtBankBranchAddress.TabIndex = 4;
            this.txtBankBranchAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtBankBranchAddress_Validating);
            // 
            // lblBankAddress
            // 
            this.lblBankAddress.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankAddress.ForeColor = System.Drawing.Color.Black;
            this.lblBankAddress.Location = new System.Drawing.Point(13, 58);
            this.lblBankAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBankAddress.Name = "lblBankAddress";
            this.lblBankAddress.Size = new System.Drawing.Size(128, 20);
            this.lblBankAddress.TabIndex = 3;
            this.lblBankAddress.Values.Text = "& Bank Branch Address";
            // 
            // cboBranchStates
            // 
            this.cboBranchStates.DropDownWidth = 121;
            this.cboBranchStates.FormattingEnabled = true;
            this.cboBranchStates.Location = new System.Drawing.Point(202, 193);
            this.cboBranchStates.Name = "cboBranchStates";
            this.cboBranchStates.Size = new System.Drawing.Size(178, 21);
            this.cboBranchStates.TabIndex = 10;
            this.cboBranchStates.SelectionChangeCommitted += new System.EventHandler(this.cboBranchStates_SelectionChangeCommitted);
            this.cboBranchStates.Validating += new System.ComponentModel.CancelEventHandler(this.cboBranchStates_Validating);
            // 
            // lblBranchState
            // 
            this.lblBranchState.Location = new System.Drawing.Point(64, 194);
            this.lblBranchState.Name = "lblBranchState";
            this.lblBranchState.Size = new System.Drawing.Size(140, 20);
            this.lblBranchState.TabIndex = 9;
            this.lblBranchState.Values.Text = "Name of &State/Province";
            // 
            // cboBranchCountries
            // 
            this.cboBranchCountries.DropDownWidth = 121;
            this.cboBranchCountries.FormattingEnabled = true;
            this.cboBranchCountries.Location = new System.Drawing.Point(202, 167);
            this.cboBranchCountries.Name = "cboBranchCountries";
            this.cboBranchCountries.Size = new System.Drawing.Size(178, 21);
            this.cboBranchCountries.TabIndex = 8;
            this.cboBranchCountries.SelectionChangeCommitted += new System.EventHandler(this.cboBranchCountries_SelectionChangeCommitted);
            this.cboBranchCountries.Validating += new System.ComponentModel.CancelEventHandler(this.cboBranchCountries_Validating);
            // 
            // lblBranchCountryName
            // 
            this.lblBranchCountryName.Location = new System.Drawing.Point(111, 168);
            this.lblBranchCountryName.Name = "lblBranchCountryName";
            this.lblBranchCountryName.Size = new System.Drawing.Size(90, 20);
            this.lblBranchCountryName.TabIndex = 7;
            this.lblBranchCountryName.Values.Text = "&Country Name";
            // 
            // cboBranchCity
            // 
            this.cboBranchCity.DropDownWidth = 121;
            this.cboBranchCity.FormattingEnabled = true;
            this.cboBranchCity.Location = new System.Drawing.Point(202, 219);
            this.cboBranchCity.Name = "cboBranchCity";
            this.cboBranchCity.Size = new System.Drawing.Size(178, 21);
            this.cboBranchCity.TabIndex = 12;
            this.cboBranchCity.Validating += new System.ComponentModel.CancelEventHandler(this.cboBranchCity_Validating);
            // 
            // lblBranchCity
            // 
            this.lblBranchCity.Location = new System.Drawing.Point(132, 219);
            this.lblBranchCity.Name = "lblBranchCity";
            this.lblBranchCity.Size = new System.Drawing.Size(67, 20);
            this.lblBranchCity.TabIndex = 11;
            this.lblBranchCity.Values.Text = "City Name";
            // 
            // frmAddEditBankBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(406, 301);
            this.Controls.Add(this.cboBranchCity);
            this.Controls.Add(this.lblBranchCity);
            this.Controls.Add(this.cboBranchStates);
            this.Controls.Add(this.lblBranchState);
            this.Controls.Add(this.cboBranchCountries);
            this.Controls.Add(this.lblBranchCountryName);
            this.Controls.Add(this.lblIFCCode);
            this.Controls.Add(this.txtBranchIFSCCode);
            this.Controls.Add(this.txtBankBranchAddress);
            this.Controls.Add(this.lblBankAddress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.txtBranchName);
            this.Controls.Add(this.lblBankBranchName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditBankBranch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditBankBranch";
            this.Load += new System.EventHandler(this.frmAddEditBankBranch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranchStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranchCountries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBranchCity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSave;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBranchName;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBankBranchName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblIFCCode;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBranchIFSCCode;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBankBranchAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBankAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBranchCity;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBranchCity;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBranchStates;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBranchState;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboBranchCountries;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblBranchCountryName;
    }
}