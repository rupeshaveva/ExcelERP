using libERP;
using libERP.MODELS;
using libERP.SERVICES;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.MASTER
{
    public partial class frmAddEditState : Form
    {

        public int StateID { get; set; }
        public int SelectedCountryID { get; set; }

        public frmAddEditState()
        {
            InitializeComponent();
        }
        public frmAddEditState(int ID)
        {
            InitializeComponent();
            this.StateID = ID;
        }
        private void frmAddEditState_Load(object sender, EventArgs e)
        {
            try
            {

                PopulateCountryDropDown();
                if (this.StateID == 0)
                {
                    if (this.SelectedCountryID != 0)
                    {
                        SelectListItem item = ((List<SelectListItem>)cboCountries.DataSource).Where(x => x.ID == this.SelectedCountryID).FirstOrDefault();
                        cboCountries.SelectedItem = item;
                    }
                }
                else
                {
                    ScatterData();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditState::frmAddEditState_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditState::PopulateCountryDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void ScatterData()
        {
            try
            {
                TBL_MP_Master_State model = (new ServiceMASTERS()).GetStateDBRecordByStateID(this.StateID);
                if (model != null)
                {
                    txtStateName.Text = model.StateName;
                    SelectListItem item = ((List<SelectListItem>)cboCountries.DataSource).Where(x => x.ID == model.FK_CountryId).FirstOrDefault();
                    cboCountries.SelectedItem = item;
                    chkIsActive.Checked = model.IsActive;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "frmAddEditState::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_State model = null;
            ServiceMASTERS _service = new ServiceMASTERS();
            try
            {
                if (this.StateID == 0)
                    model = new TBL_MP_Master_State();
                else
                    model = _service.GetStateDBRecordByStateID(this.StateID);
                // gather data into model from controls
                model.StateName = txtStateName.Text.Trim();
                model.FK_CountryId = ((SelectListItem)cboCountries.SelectedItem).ID;
                model.IsActive = chkIsActive.Checked;
                model.FK_CompanyID = Program.CURR_USER.CompanyID;
                model.FK_BranchID = Program.CURR_USER.BranchID;

                if (StateID == 0)
                {
                   this.StateID= _service.AddNewState(model);
                }
                else
                    _service.EditState(model);

                this.DialogResult = DialogResult.OK;



            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditState::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtStateName_Validating(object sender, CancelEventArgs e)
        {
            if (txtStateName.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtStateName,"Can't be left blank");
                e.Cancel = true;
            }
        }

        private void cboCountries_Validating(object sender, CancelEventArgs e)
        {
            if (cboCountries.SelectedItem == null)
            {
                errorProvider1.SetError(cboCountries, "Select valid Country");
                e.Cancel = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
