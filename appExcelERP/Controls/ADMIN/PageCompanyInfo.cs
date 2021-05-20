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
using libERP.SERVICES.MASTER;
using libERP.SERVICES.HR;
using libERP;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.ADMIN
{
    public partial class PageCompanyInfo : UserControl
    {
        public PageCompanyInfo()
        {
            InitializeComponent();
        }
        private void PageCompanyInfo_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateCountry();
                PopulateState();
                PopulateCity();
                PopulateArea();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::PageCompanyInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSaveCompanyInfo_Click(object sender, EventArgs e)
        {
            btnCancelUpdates.Visible = btnSaveCompanyInfo.Visible = false;
            try
            {
                if (!this.ValidateChildren()) return;
                TBL_MP_Admin_Company_Master model = (new ServiceCompanyMaster()).GetCompanyInfo();
                if (model == null)
                {
                    model = new TBL_MP_Admin_Company_Master();
                }
                model.CompanyCode = txtCode.Text.Trim();
                model.Company_name = txtCompanyName.Text.Trim();
                model.Abbreviation = txtAbbrivation.Text.Trim();
                model.FK_CountryID = ((SelectListItem)cboCountry.SelectedItem).ID;
                model.FK_StateID= ((SelectListItem)cboState.SelectedItem).ID;
                model.FK_CityID= ((SelectListItem)cboState.SelectedItem).ID;
                model.FK_AreaID= ((SelectListItem)cboArea.SelectedItem).ID;
                model.Email = txtEmailAddress.Text.Trim();
                model.Website = txtWebsiteAddress.Text.Trim();
                model.PhoneNo = txtPhoneNo.Text.Trim();
                model.ECC_NO = txtECCNo.Text.Trim();
                model.TIN_NO = txtTinNo.Text.Trim();
                model.PAN_NO = txtPANNo.Text.Trim();
                model.GST_NO = txtGSTNo.Text.Trim();
                model.IEC_CODE = txtIECCode.Text.Trim();
                model.ShiftTimeFrom = dtShiftFromTime.Value.ToString("hh:mm tt");
                model.ShiftTimeTo = dtShiftToTime.Value.ToString("hh:mm tt");


               

                bool result = (new ServiceCompanyMaster()).UpdateCompanyInfo(model);
                if (result)
                {
                    MessageBox.Show("Successfully Updated ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::btnSaveCompanyInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCancelUpdates_Click(object sender, EventArgs e)
        {
            btnCancelUpdates.Visible = btnSaveCompanyInfo.Visible = false;
        }
        public void PopulateCompanyInformation()
        {
            try
            {
                TBL_MP_Admin_Company_Master model = (new ServiceCompanyMaster()).GetCompanyInfo();
                if (model != null)
                {
                    txtCode.Text = model.CompanyCode;
                    txtCompanyName.Text = model.Company_name;
                    txtAbbrivation.Text = model.Abbreviation;
                    txtCompanyAddress.Text = model.Address;
                    cboCountry.SelectedItem = ((List<SelectListItem>)cboCountry.DataSource).Where(x => x.ID == model.FK_CountryID).FirstOrDefault();
                    cboState.SelectedItem = ((List<SelectListItem>)cboState.DataSource).Where(x => x.ID == model.FK_StateID).FirstOrDefault();
                    cboCity.SelectedItem = ((List<SelectListItem>)cboCity.DataSource).Where(x => x.ID == model.FK_CityID).FirstOrDefault();
                    cboArea.SelectedItem = ((List<SelectListItem>)cboArea.DataSource).Where(x => x.ID == model.FK_AreaID).FirstOrDefault();
                    txtEmailAddress.Text = model.Email;
                    txtWebsiteAddress.Text = model.Website;
                    txtPhoneNo.Text = model.PhoneNo;
                    txtFaxNo.Text = model.FaxNo;
                    txtECCNo.Text = model.ECC_NO;
                    txtTinNo.Text = model.TIN_NO;
                    txtPANNo.Text = model.PAN_NO;
                    txtGSTNo.Text = model.GST_NO;
                    txtIECCode.Text = model.IEC_CODE;

                    if (model.ShiftTimeFrom != null)
                    {
                        dtShiftFromTime.Value = AppCommon.GetDateTimeFromTime(model.ShiftTimeFrom);
                    }
                    if (model.ShiftTimeTo != null)
                    {
                        dtShiftToTime.Value = AppCommon.GetDateTimeFromTime(model.ShiftTimeTo);
                    }


                }
                else
                {
                    txtCode.Text = txtCompanyName.Text = txtAbbrivation.Text = txtEmailAddress.Text = txtWebsiteAddress.Text = txtPhoneNo.Text =
                     txtFaxNo.Text = txtECCNo.Text = txtTinNo.Text = txtPANNo.Text = txtGSTNo.Text = string.Empty;
                    cboCountry.SelectedItem = ((List<SelectListItem>)cboCountry.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboState.SelectedItem = ((List<SelectListItem>)cboState.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboCity.SelectedItem = ((List<SelectListItem>)cboCity.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboArea.SelectedItem = ((List<SelectListItem>)cboArea.DataSource).Where(x => x.ID == 0).FirstOrDefault();

                }


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::PopulateCompanyInformation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region populate dropdown
        public void PopulateCountry()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllCountries());
                cboCountry.DataSource = LST;
                cboCountry.DisplayMember = "Description";
                cboCountry.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::PopulateCountry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateState()
        {
            try
            {

                int countryID = ((SelectListItem)cboCountry.SelectedItem).ID;
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllStatesForCountry(countryID));
                cboState.DataSource = LST;
                cboState.DisplayMember = "Description";
                cboState.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::PopulateState", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateCity()
        {
            try
            {
                int stateID = ((SelectListItem)cboState.SelectedItem).ID;
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllCitiesForState(stateID));
                cboCity.DataSource = LST;
                cboCity.DisplayMember = "Description";
                cboCity.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::PopulateCity", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateArea()
        {
            try
            {
                int cityID = ((SelectListItem)cboCity.SelectedItem).ID;
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllAreaForCity(cityID));
                cboArea.DataSource = LST;
                cboArea.DisplayMember = "Description";
                cboArea.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::PopulateCity", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
  
        #region VALIDATIONS
        private void cboCountry_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboCountry.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboCountry, " country mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::cboCountry_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboState_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboState.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboState, " State name is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::cboState_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboCity_Validating(object sender, CancelEventArgs e)
        {
            try 
            {
                if (((SelectListItem)cboCity.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboCity, " city is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::cboCity_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboArea_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboArea.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboArea, " Area is  mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::cboArea_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void cboCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateState();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::cboCountry_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboState_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateCity();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::cboState_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboCity_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateArea();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageCompanyInfo::cboCity_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
