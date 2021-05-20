namespace appExcelERP.Forms.Parties
{
    partial class frmAddEditAddress
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
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtAddress = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.cboCountries = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewCountry = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboStates = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewState = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.cboCities = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewCity = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtPINCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cboParties = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnAddNewParty = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.chkIsActive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(14, 9);
            this.kryptonLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(38, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "&Party";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(14, 51);
            this.kryptonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "&Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(14, 70);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(314, 69);
            this.txtAddress.TabIndex = 3;
            // 
            // cboCountries
            // 
            this.cboCountries.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewCountry});
            this.cboCountries.DropDownWidth = 395;
            this.cboCountries.Location = new System.Drawing.Point(96, 144);
            this.cboCountries.Margin = new System.Windows.Forms.Padding(2);
            this.cboCountries.Name = "cboCountries";
            this.cboCountries.Size = new System.Drawing.Size(232, 24);
            this.cboCountries.TabIndex = 5;
            this.cboCountries.SelectionChangeCommitted += new System.EventHandler(this.cboCountries_SelectionChangeCommitted);
            // 
            // btnAddNewCountry
            // 
            this.btnAddNewCountry.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewCountry.UniqueName = "776AA9FB31A145F07A81D402CA8D2088";
            this.btnAddNewCountry.Click += new System.EventHandler(this.btnAddNewCountry_Click);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(14, 145);
            this.kryptonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(54, 20);
            this.kryptonLabel3.TabIndex = 4;
            this.kryptonLabel3.Values.Text = "&Country";
            // 
            // cboStates
            // 
            this.cboStates.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewState});
            this.cboStates.DropDownWidth = 395;
            this.cboStates.Location = new System.Drawing.Point(96, 169);
            this.cboStates.Margin = new System.Windows.Forms.Padding(2);
            this.cboStates.Name = "cboStates";
            this.cboStates.Size = new System.Drawing.Size(232, 24);
            this.cboStates.TabIndex = 7;
            this.cboStates.SelectionChangeCommitted += new System.EventHandler(this.cboStates_SelectionChangeCommitted);
            // 
            // btnAddNewState
            // 
            this.btnAddNewState.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewState.UniqueName = "776AA9FB31A145F07A81D402CA8D2088";
            this.btnAddNewState.Click += new System.EventHandler(this.btnAddNewState_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(14, 171);
            this.kryptonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel4.TabIndex = 6;
            this.kryptonLabel4.Values.Text = "&State/Province";
            // 
            // cboCities
            // 
            this.cboCities.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewCity});
            this.cboCities.DropDownWidth = 395;
            this.cboCities.Location = new System.Drawing.Point(96, 195);
            this.cboCities.Margin = new System.Windows.Forms.Padding(2);
            this.cboCities.Name = "cboCities";
            this.cboCities.Size = new System.Drawing.Size(232, 24);
            this.cboCities.TabIndex = 9;
            this.cboCities.SelectionChangeCommitted += new System.EventHandler(this.cboCities_SelectionChangeCommitted);
            // 
            // btnAddNewCity
            // 
            this.btnAddNewCity.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewCity.UniqueName = "776AA9FB31A145F07A81D402CA8D2088";
            this.btnAddNewCity.Click += new System.EventHandler(this.btnAddNewCity_Click);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(14, 197);
            this.kryptonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(31, 20);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "City";
            // 
            // txtPINCode
            // 
            this.txtPINCode.Location = new System.Drawing.Point(96, 223);
            this.txtPINCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtPINCode.Name = "txtPINCode";
            this.txtPINCode.Size = new System.Drawing.Size(232, 20);
            this.txtPINCode.TabIndex = 11;
            this.txtPINCode.TextChanged += new System.EventHandler(this.txtPINCode_TextChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(14, 223);
            this.kryptonLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(30, 20);
            this.kryptonLabel6.TabIndex = 10;
            this.kryptonLabel6.Values.Text = "PIN";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(164, 258);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 28);
            this.btnOK.TabIndex = 12;
            this.btnOK.Values.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(248, 258);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Values.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboParties
            // 
            this.cboParties.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.btnAddNewParty});
            this.cboParties.DropDownWidth = 395;
            this.cboParties.Location = new System.Drawing.Point(14, 28);
            this.cboParties.Margin = new System.Windows.Forms.Padding(2);
            this.cboParties.Name = "cboParties";
            this.cboParties.Size = new System.Drawing.Size(314, 24);
            this.cboParties.TabIndex = 1;
            // 
            // btnAddNewParty
            // 
            this.btnAddNewParty.Image = global::appExcelERP.Properties.Resources.Add_16x;
            this.btnAddNewParty.UniqueName = "776AA9FB31A145F07A81D402CA8D2088";
            this.btnAddNewParty.Click += new System.EventHandler(this.btnAddNewParty_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.Location = new System.Drawing.Point(14, 266);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(2);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(69, 20);
            this.chkIsActive.TabIndex = 14;
            this.chkIsActive.Values.Text = "Is Active";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(342, 306);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPINCode);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.cboCities);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.cboStates);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.cboCountries);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.cboParties);
            this.Controls.Add(this.kryptonLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditAddress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add / Edit Addresses";
            this.Load += new System.EventHandler(this.frmAddresses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboCountries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAddress;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCountries;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewCountry;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboStates;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewState;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboCities;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewCity;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtPINCode;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOK;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cboParties;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny btnAddNewParty;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chkIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}