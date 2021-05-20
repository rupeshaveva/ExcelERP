using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS;
using libERP.SERVICES;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms
{
    public partial class frmAddEditCity : KryptonForm
    {


        public ServiceUOW _UNIT { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }

        public frmAddEditCity()
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
        }
        public frmAddEditCity(int cityID)
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            this.CityID = cityID;
        }
        private void frmAddEditCity_Load(object sender, EventArgs e)
        {
            PopulateCountryDropDown();
            if (this.CountryID != 0)
                cboCountries.SelectedItem = ((List<SelectListItem>)cboCountries.DataSource).Where(x => x.ID == this.CountryID).FirstOrDefault();
            PopulateStatesDropDowns();
            if (this.StateID != 0)
                cboStates.SelectedItem = ((List<SelectListItem>)cboStates.DataSource).Where(x => x.ID == this.StateID).FirstOrDefault();

            if (this.CityID != 0)
                ScatterData();
        }

        private void ScatterData()
        {
            TBL_MP_Master_City model= (new ServiceMASTERS()).GetCityDBRecordByCityID(this.CityID);
            if (model != null)
            {
                PopulateCountryDropDown();
                if (model.fk_CountryId != 0)
                {
                    cboCountries.SelectedItem = ((List<SelectListItem>)cboCountries.DataSource).Where(x => x.ID == model.fk_CountryId).FirstOrDefault();
                    this.CountryID = model.fk_CountryId;
                }
                PopulateStatesDropDowns();
                if (model.fk_StateId != 0)
                {
                    cboStates.SelectedItem = ((List<SelectListItem>)cboStates.DataSource).Where(x => x.ID == model.fk_StateId).FirstOrDefault();
                    this.StateID = model.fk_StateId;
                }
                txtCityName.Text = model.CityName;
                txtSTDCode.Text = model.STDCode;
                chkIsActive.Checked = model.IsActive;
            }
        }

        private void PopulateCountryDropDown()
        {
            try
            {
               
                cboCountries.DataSource = (new ServiceMASTERS()).GetAllCountries();
                cboCountries.DisplayMember = "Description";
                cboCountries.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditCity::PopulateCountryDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void cboCountries_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.CountryID = ((SelectListItem)cboCountries.SelectedItem).ID;
            PopulateStatesDropDowns();
        }
        private void PopulateStatesDropDowns()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllStatesForCountry(this.CountryID));
                cboStates.DataSource = LST;
                cboStates.DisplayMember = "Description";
                cboStates.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "frmAddEditCity::PopulateStatesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtCityName_Validating(object sender, CancelEventArgs e)
        {
            if (txtCityName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtCityName,"Can't be left Blank!!");
                e.Cancel = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    TBL_MP_Master_City model = null;
                    if (CityID == 0)
                    {
                        model = new TBL_MP_Master_City()
                        {
                            CityName = txtCityName.Text,
                            FK_BranchID = Program.CURR_USER.BranchID,
                            FK_CompanyID = Program.CURR_USER.CompanyID,
                            STDCode = txtSTDCode.Text
                        };
                        model.fk_CountryId = ((SelectListItem)cboCountries.SelectedItem).ID;
                        model.fk_StateId = ((SelectListItem)cboStates.SelectedItem).ID;
                        model.IsActive = chkIsActive.Checked;
                        _UNIT.AppDBContext.TBL_MP_Master_City.Add(model);
                        _UNIT.AppDBContext.SaveChanges();
                        this.CityID = model.pk_CityId;
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        model = _UNIT.AppDBContext.TBL_MP_Master_City.Where(x => x.pk_CityId == CityID).FirstOrDefault();
                        model.CityName = txtCityName.Text;
                        model.fk_CountryId = ((SelectListItem)cboCountries.SelectedItem).ID;
                        model.fk_StateId = ((SelectListItem)cboStates.SelectedItem).ID;
                        model.STDCode = txtSTDCode.Text;
                        model.IsActive = chkIsActive.Checked;
                        _UNIT.AppDBContext.SaveChanges();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCity::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
       

       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboStates_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboStates.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboStates, "state is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditCity::cboStates_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
