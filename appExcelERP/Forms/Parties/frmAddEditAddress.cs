
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.MASTER;
using appExcelERP.Forms.Masters;
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms.Parties
{
    public partial class frmAddEditAddress : KryptonForm
    {
        public int PartyAddressID { get; set; }
        public int SelectedPartyID { get; set; }
        public string SelectedPartyType { get; set; }

        private int selectedCountryID = 0;
        private int selectedStateID = 0;
        private int selectedCityID = 0;


        public frmAddEditAddress()
        {
            InitializeComponent();
        }
        public frmAddEditAddress(int ID)
        {
            InitializeComponent();
            PartyAddressID = ID;
        }
        private void frmAddresses_Load(object sender, EventArgs e)
        {
            try
            {
                PopulatePartiesDropdown();
                PopulateCountryDropDown();
                chkIsActive.Checked = true;
                if (this.SelectedPartyID != 0)
                {
                    cboParties.SelectedItem = ((List<SelectListItem>)cboParties.DataSource).Where(x => x.ID == this.SelectedPartyID).FirstOrDefault();
                }
                if (PartyAddressID != 0)
                {
                    ScatterData();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::frmAddresses_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region POPULATE DROPDOWNS
        private void PopulatePartiesDropdown()
        {
            try
            {
                List<SelectListItem> lstUOMs = new List<SelectListItem>();
                lstUOMs.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstUOMs.AddRange((new ServiceParties()).GetAllParties(SelectedPartyType));
                cboParties.DataSource = lstUOMs;
                cboParties.DisplayMember = "Description";
                cboParties.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::PopulatePartiesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateCountryDropDown()
        {
            try
            {
                List<SelectListItem> lstUOMs = new List<SelectListItem>();
                lstUOMs.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstUOMs.AddRange((new ServiceMASTERS()).GetAllCountries());
                cboCountries.DataSource = lstUOMs;
                cboCountries.DisplayMember = "Description";
                cboCountries.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditAddress::PopulateCountryDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateStatesDropdown()
        {
            try
            {
                List<SelectListItem> lstUOMs = new List<SelectListItem>();
                lstUOMs.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstUOMs.AddRange((new ServiceMASTERS()).GetAllStatesForCountry(this.selectedCountryID));
                cboStates.DataSource = null;
                cboStates.DataSource = lstUOMs;
                cboStates.DisplayMember = "Description";
                cboStates.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::PopulateStatesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateCitiesDropdown()
        {
            try
            {
                List<SelectListItem> lstUOMs = new List<SelectListItem>();
                lstUOMs.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lstUOMs.AddRange((new ServiceMASTERS()).GetAllCitiesForState(this.selectedStateID));
                cboCities.DataSource = null;
                cboCities.DataSource =lstUOMs;
                cboCities.DisplayMember = "Description";
                cboCities.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::PopulateStatesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        private void cboCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.selectedCountryID = ((SelectListItem)cboCountries.SelectedItem).ID;
                PopulateStatesDropdown();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::cboProjectCounty_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboStates_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.selectedStateID = ((SelectListItem)cboStates.SelectedItem).ID;
                PopulateCitiesDropdown();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::cboProjectCounty_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboCities_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.selectedCityID = ((SelectListItem)cboCities.SelectedItem).ID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::cboProjectCity_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScatterData()
        {
            try
            {
                Tbl_MP_Master_Party_Address model = (new ServiceParties()).GetPartyAddressForAddressID(this.PartyAddressID);
                if (model != null)
                {
                    cboParties.SelectedItem = ((List<SelectListItem>)cboParties.DataSource).Where(x => x.ID == model.FK_PartyID).FirstOrDefault();
                    txtAddress.Text = model.Address;
                    cboCountries.SelectedItem= ((List<SelectListItem>)cboCountries.DataSource).Where(x => x.ID == model.FK_CountryID).FirstOrDefault();
                    selectedCountryID = model.FK_CountryID;
                    PopulateStatesDropdown();
                    cboStates.SelectedItem = ((List<SelectListItem>)cboStates.DataSource).Where(x => x.ID == model.FK_StateID).FirstOrDefault();
                    selectedStateID = model.FK_StateID;
                    PopulateCitiesDropdown();
                    cboCities.SelectedItem = ((List<SelectListItem>)cboCities.DataSource).Where(x => x.ID == model.FK_CityID).FirstOrDefault();
                    txtPINCode.Text = model.PIN_Code;
                    chkIsActive.Checked = model.IsActive;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren()) return;

                Tbl_MP_Master_Party_Address model = null;

                if (this.PartyAddressID == 0)
                    model = new Tbl_MP_Master_Party_Address();
                else
                    model = (new ServiceParties()).GetPartyAddressForAddressID(this.PartyAddressID);

                model.FK_PartyID = ((SelectListItem)cboParties.SelectedItem).ID;
                model.Address = txtAddress.Text;
                model.FK_CountryID = ((SelectListItem)cboCountries.SelectedItem).ID;
                model.FK_StateID = ((SelectListItem)cboStates.SelectedItem).ID;
                model.FK_CityID = ((SelectListItem)cboCities.SelectedItem).ID;
                model.PIN_Code = txtPINCode.Text;
                model.IsActive = chkIsActive.Checked;


                if (this.PartyAddressID == 0)
                    (new ServiceParties()).AddNewPartyAddress(model);
                else
                    (new ServiceParties()).UpdatePartyAddress(model);

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPINCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboParties_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboParties.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboParties, " Select Parties");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::cboParties_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewParty_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty(this.SelectedPartyType);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulatePartiesDropdown();
                    cboParties.SelectedItem = ((List<SelectListItem>)cboParties.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::btnAddNewParty_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewCountry_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCountry frm = new frmAddEditCountry();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCountryDropDown();
                    selectedCountryID = frm.CountryID;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::btnAddNewBank_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewState_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditState frm = new frmAddEditState();
                frm.SelectedCountryID = this.selectedCountryID;
                //   frm.CountryID = this.SelectedCountryID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    selectedStateID = frm.StateID;
                    PopulateStatesDropdown();
                    cboStates.SelectedItem = ((List<SelectListItem>)cboStates.DataSource).Where(x => x.ID == selectedStateID).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::btnAddNewState_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAddNewCity_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCity frm = new frmAddEditCity();
                frm.CountryID = this.selectedCountryID;
                frm.StateID = this.selectedStateID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    selectedCityID = frm.CityID;
                    PopulateCitiesDropdown();
                    cboCities.SelectedItem = ((List<SelectListItem>)cboCities.DataSource).Where(x => x.ID == selectedCityID).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAddress::btnAddNewCity_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
