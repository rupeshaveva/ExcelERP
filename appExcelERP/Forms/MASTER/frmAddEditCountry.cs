using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP;
using libERP.SERVICES;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms.Masters
{
    public partial class frmAddEditCountry : KryptonForm
    {
        public int CountryID { get; set; }

        public frmAddEditCountry()
        {
            InitializeComponent();
        }
        public frmAddEditCountry(int ID)
        {
            InitializeComponent();
            this.CountryID = ID;
        }

        private void frmAddEditCountry_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.CountryID == 0)
                    DoBlank();
                else
                    ScatterData();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCountry::frmAddEditCountry_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DoBlank()
        {
            txtCountryName.Text = txtCurrencyCode.Text = txtCurrencyName.Text =  txtDenomination.Text = string.Empty;
            txtDecimal.Text = "2";
        }
        private void ScatterData()
        {
            try
            {
                TBL_MP_Master_Country model = (new ServiceMASTERS()).GetCountryDBRecordByCountryID(this.CountryID);
                if (model != null)
                {
                    txtCountryName.Text = model.CountryName;
                    txtCurrencyName.Text = model.CurrencyName;
                    txtDenomination.Text = model.Denomination;
                    txtDecimal.Text = model.Upto_Decimal.ToString();
                    chkIsActive.Checked = model.IsActive;
                    txtCurrencyCode.Text = model.CurrencyCode;
                    txtISDCode.Text = model.ISDCode;
                   
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCountry::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region VALIDATIONS
        private void txtCountryName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCountryName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCountryName, "Country Name can't be left blank");
                e.Cancel = true;
            }
        }

        private void txtCurrencyName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrencyName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCurrencyName, "Currency can't be left blank");
                e.Cancel = true;
            }
        }

        private void txtCurrencyCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrencyCode.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCurrencyCode, "Currency Code can't be left blank");
                e.Cancel = true;
            }

        }


        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Country model = null;
            ServiceMASTERS countryService = new ServiceMASTERS();
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    if (this.CountryID == 0)
                        model = new TBL_MP_Master_Country();
                    else
                        model = countryService.GetCountryDBRecordByCountryID(this.CountryID);

                    //GATHER DATA FROM CONTROLS INTO MODEL
                    model.CountryName= txtCountryName.Text;
                     model.CurrencyName= txtCurrencyName.Text;
                    model.Denomination=txtDenomination.Text;
                    model.Upto_Decimal = int.Parse(txtDecimal.Text);
                    model.IsActive=chkIsActive.Checked;
                    model.CurrencyCode=txtCurrencyCode.Text;
                    model.ISDCode = txtISDCode.Text;
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;
                    model.FK_BranchID = Program.CURR_USER.BranchID;

                    if (CountryID == 0)
                        countryService.AddNewCountry(model);
                    else
                        countryService.EditCountry(model);

                    this.DialogResult = DialogResult.OK;


                }
            }

            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCountry::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDecimal_Validating(object sender, CancelEventArgs e)
        {
            if(txtDecimal.Text.Trim()==string.Empty)
            {
                errorProvider1.SetError(txtDecimal, "Decimal places Required");
                e.Cancel = true;
                return;
            }
            if (!txtDecimal.Text.All(Char.IsDigit))
            {
                errorProvider1.SetError(txtDecimal, "Enter Digits only [0-9]");
                e.Cancel = true;
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmAddEditCountry_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }
    }

}
