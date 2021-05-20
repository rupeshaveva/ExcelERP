using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;
using libERP.SERVICES;
using appExcelERP.Forms;
using ComponentFactory.Krypton.Toolkit;
using appExcelERP.Forms.Masters;
using appExcelERP.Forms.MASTER;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.MASTERS
{
    public partial class pageLocations : UserControl
    {
        public DB_FORM_IDs FormOperationID { get; set; }

        public int SelectedCountryID { get; set; }
        public string SelectedCountryName { get; set; }

        BindingList<SelectListItem> _countriesList = null;
        BindingList<SelectListItem> _filteredCountriesList = null;

        public int SelectedStateID { get; set; }
        public string SelectedStateName { get; set; }
        BindingList<SelectListItem> _statesList = null;
        BindingList<SelectListItem> _filteredStatesList = null;

        public int SelectedCityID { get; set; }
        public string SelectedCityName { get; set; }
        BindingList<SelectListItem> _citiesList = null;
        BindingList<SelectListItem> _filteredCitiesList = null;



        public pageLocations()
        {
            InitializeComponent();
        }
        private void pageLocations_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateCountriesGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::pageLocations_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SetPermissionwiseButtonStatus()
        {
            try
            {
                WhosWhoModel model= Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == this.FormOperationID).FirstOrDefault();
                if (model != null)
                {
                    if (!model.CanAddNew)
                        btnAddNewCountry.Enabled = btnAddNewState.Enabled = btnAddNewCity.Enabled = ButtonEnabled.False;
                    if(!model.CanModify)
                        btnEditCountry.Enabled = btnEditState.Enabled = btnEditCity.Enabled = ButtonEnabled.False;
                    
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}",ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageLocations::SetPermissionwiseButtonStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region COUNTRIES
        private void PopulateCountriesGrid()
        {
            try
            {
                _statesList = null;
                _countriesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllCountriesGrid());
                gridCountries.DataSource = _countriesList;
                gridCountries.Columns["ID"].Visible = gridCountries.Columns["Code"].Visible = gridCountries.Columns["IsActive"].Visible = gridCountries.Columns["DescriptionToUpper"].Visible = false;
                headerGroupCountries.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCountries.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::PopulateCountriesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchCountry_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredCountriesList = new BindingList<SelectListItem>(_countriesList.Where(p => p.DescriptionToUpper.Contains(txtSearchCountry.Text.ToUpper())).ToList());
                gridCountries.DataSource = _filteredCountriesList;
                headerGroupCountries.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCountries.Rows.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::txtSearchCountry_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void gridCountries_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _statesList = null;
                _citiesList = null;
                this.SelectedCountryID = (int)gridCountries.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedCountryName = gridCountries.Rows[e.RowIndex].Cells["Description"].Value.ToString().Replace("\n", " ");
                
                headerGroupStates.ValuesPrimary.Heading = String.Format("(STATE/PROVINCES) {0}", SelectedCountryName.ToUpper());
                PopulateStatesGrid();
                SetPermissionwiseButtonStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::gridCountries_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddNewCountry_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCountry frm = new frmAddEditCountry();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCountriesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageLocations::btnAddNewCountry_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditCountry_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCountry frm = new frmAddEditCountry();
                frm.CountryID = this.SelectedCountryID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCountriesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageLocations::btnEditCountry_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region STATES/PROVINCES
        private void PopulateStatesGrid()
        {
            try
            {
                gridCities.DataSource = null;
                _statesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllStatesGridForCountry(this.SelectedCountryID));
                gridStates.DataSource = _statesList;
                gridStates.Columns["ID"].Visible = gridStates.Columns["Code"].Visible = gridStates.Columns["IsActive"].Visible = gridStates.Columns["DescriptionToUpper"].Visible = false;
                headerGroupStates.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridStates.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::PopulateStatesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchStates_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredStatesList = new BindingList<SelectListItem>(_statesList.Where(p => p.DescriptionToUpper.Contains(txtSearchStates.Text.ToUpper())).ToList());
                gridStates.DataSource = _filteredStatesList;
                headerGroupStates.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridStates.Rows.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::txtSearchStates_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridStates_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _citiesList = null;
                this.SelectedStateID = (int)gridStates.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedStateName = gridStates.Rows[e.RowIndex].Cells["Description"].Value.ToString().Replace("\n", " ");
                headerGroupCities.ValuesPrimary.Heading = string.Format("(CITIES) {0}",SelectedStateName.ToUpper());
                PopulateCitiesGrid();
                SetPermissionwiseButtonStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::gridCountries_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddNewState_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditState frm = new frmAddEditState();
                frm.SelectedCountryID = this.SelectedCountryID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateStatesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageLocations::btnAddNewState_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditState_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditState frm = new frmAddEditState(this.SelectedStateID);
               
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateStatesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageLocations::btnEditState_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CITIES
        private void PopulateCitiesGrid()
        {
            try
            {
                _citiesList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceMASTERS()).GetAllCitiesGridForState(this.SelectedStateID));
                gridCities.DataSource = _citiesList;
                gridCities.Columns["ID"].Visible = gridCities.Columns["Code"].Visible = gridCities.Columns["IsActive"].Visible = gridCities.Columns["DescriptionToUpper"].Visible = false;
                headerGroupCities.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCities.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::PopulateCitiesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchCities_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredCitiesList = new BindingList<SelectListItem>(_citiesList.Where(p => p.DescriptionToUpper.Contains(txtSearchCities.Text.ToUpper())).ToList());
                gridCities.DataSource = _filteredCitiesList;
                headerGroupCities.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridCities.Rows.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::txtSearchCities_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridCities_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedCityID = (int)gridCities.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedCityName = gridCities.Rows[e.RowIndex].Cells["Description"].Value.ToString().Replace("\n", " ");
                SetPermissionwiseButtonStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::gridCities_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddNewCity_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCity frm = new frmAddEditCity();
                frm.CountryID = this.SelectedCountryID;
                frm.StateID = this.SelectedStateID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCitiesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::btnAddNewCity_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEditCity_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditCity frm = new frmAddEditCity(this.SelectedCityID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCitiesGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageLocations::btnEditCity_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #endregion
         private void gridStates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
         private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateCountriesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageLocations::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
