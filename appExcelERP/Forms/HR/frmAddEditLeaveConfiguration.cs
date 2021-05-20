using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
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

namespace appExcelERP.Forms.HR
{
    public partial class frmAddEditLeaveConfiguration : Form
    {
        public int LeaveID { get; set; }
        public int SeledctedBranchID { get; set; }
        public int SeledctedYearID { get; set; }
        public int SelectedLeaveID { get; set; }

        public frmAddEditLeaveConfiguration()
        {
            InitializeComponent();
        }

        public frmAddEditLeaveConfiguration( int id)
        {
            InitializeComponent();
            this.LeaveID = id;
        }

        private void frmAddEditLeaveConfiguration_Leave_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateBranchesDropdown();
                PopulateFinancialYearDropdown();
                PopulateleaveTypeDropDown();
                PopulateAllounceSalaryHeads();
                if (LeaveID == 0)
                {
                    txtLimitDays.Text = txtMaxDaysallow.Text = String.Empty;
                    chkLeaveCarryForward.Checked = chkApplicableProbationPeriod.Checked= chkLeaveEncashable.Checked= false;
                    chkIsActive.Checked = true;
                    if (this.SeledctedBranchID != 0)
                        cboBranch.SelectedItem = ((List<SelectListItem>)cboBranch.DataSource).Where(x => x.ID == this.SeledctedBranchID).FirstOrDefault();
                    if (this.SeledctedYearID != 0)
                        cboYear.SelectedItem = ((List<SelectListItem>)cboYear.DataSource).Where(x => x.ID == this.SeledctedYearID).FirstOrDefault();


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
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::frmAddEditHR_Leave_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ScatterData()
        {
            try
            {
                TBL_MP_HR_LeaveConfiguration model = (new ServiceLeaveConfiguration()).GetLeaveInfoDbRecord(this.LeaveID);
                if (model != null)
                {
                    txtLimitDays.Text = model.CarryForwardLimitDays.ToString();
                    txtMaxDaysallow.Text = model.MaxDaysAllow.ToString();
                    cboLeaveType.SelectedItem = ((List<SelectListItem>)cboLeaveType.DataSource).Where(x => x.ID == model.FK_LeaveTypeID).FirstOrDefault();
                    chkApplicableProbationPeriod.Checked = model.ApplicableInProbation;
                    chkLeaveCarryForward.Checked = model.CarryForwardLeave;
                    chkLeaveEncashable.Checked = model.LeaveEnchashable;
                    chkIsActive.Checked = model.IsActive;
                    this.SeledctedBranchID = model.FK_BranchID;
                    this.SeledctedYearID = model.FK_FinYearID;
                    if (this.SeledctedBranchID != 0)
                        cboBranch.SelectedItem = ((List<SelectListItem>)cboBranch.DataSource).Where(x => x.ID == this.SeledctedBranchID).FirstOrDefault();
                    if (this.SeledctedYearID != 0)
                        cboYear.SelectedItem = ((List<SelectListItem>)cboYear.DataSource).Where(x => x.ID == this.SeledctedYearID).FirstOrDefault();
                    if (model.LeaveEnchashable)
                    {
                        string[] IDs = model.EncashableSalaryHeadIDs.Split(',');
                        foreach (string headID in IDs)
                        {
                            foreach (DataGridViewRow mRow in gridAllounces.Rows)
                            {
                                if (mRow.Cells["ID"].Value.ToString().Trim() == headID.Trim())
                                {
                                    mRow.Cells["IsActive"].Value = true;
                                }
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


        private void PopulateleaveTypeDropDown()
        {
            try
            {
                ServiceLeaveApplication service = new ServiceLeaveApplication();
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(service.GetAllLeaveTypesForLeaveForm(service.LEAVE_TYPE_LEAVE_ID));
                cboLeaveType.DataSource = LST;
                cboLeaveType.DisplayMember = "Description";
                cboLeaveType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::PopulateleaveTypeDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBranchesDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllBraches());
                cboBranch.DataSource = LST;
                cboBranch.DisplayMember = "Description";
                cboBranch.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::PopulateBranchesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateFinancialYearDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllFinancialYears());
                cboYear.DataSource = LST;
                cboYear.DisplayMember = "Description";
                cboYear.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::PopulateFinancialYearDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateAllounceSalaryHeads()
        {
            try
            {
                int ALLOUNCE_CATAGAORY_ID = 0;
                ALLOUNCE_CATAGAORY_ID = Program.LIST_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.SalaryHeadEARNINGType).FirstOrDefault().DEFAULT_VALUE;
                List<SelectListItem> lstSalaryHeadsAllounces = (new ServiceSalaryHead()).GetSelectListItemSalaryHeadsofType(ALLOUNCE_CATAGAORY_ID);
                gridAllounces.DataSource = lstSalaryHeadsAllounces;
                gridAllounces.Columns["ID"].Visible = 
                gridAllounces.Columns["Description"].Visible = 
                gridAllounces.Columns["Code"].Visible = false;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::PopulateAllounceSalaryHeads", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region VALIDATIONS
        private void cboLeaveType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboLeaveType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboLeaveType, "Select Leave Type");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::cboLeaveType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtMaxDaysallow_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtMaxDaysallow.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtMaxDaysallow, "Max allow days is Mandatory");
                    e.Cancel = true;
                }
                decimal maxAllowed = 0; decimal.TryParse(txtMaxDaysallow.Text.Trim(), out maxAllowed);
                //if (maxAllowed == 0)
                //{
                //    errorProvider1.SetError(txtMaxDaysallow, "Invalid Integer Value");
                //    e.Cancel = true;
                //}

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::txtMaxDaysallow_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLimitDays_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (chkLeaveCarryForward.Checked)
                {
                    int maxAllowed = 0;  int.TryParse(txtMaxDaysallow.Text.Trim(), out maxAllowed);
                    int limitDays = 0;  int.TryParse(txtLimitDays.Text.Trim(), out limitDays);
                    if (limitDays == 0)
                    {
                        errorProvider1.SetError(txtLimitDays, "Limit Days is  Mandatory");
                        e.Cancel = true;
                    }
                    //if (limitDays >= maxAllowed)
                    //{
                    //    errorProvider1.SetError(txtLimitDays, "Limit Days range invalid");
                    //    e.Cancel = true;
                    //}
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::txtLimitDays_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_HR_LeaveConfiguration model = null;
            ServiceLeaveConfiguration serviceLeave = new ServiceLeaveConfiguration();
            try
            {
                string strSalaryHeadIDs = string.Empty;
                string strSalaryHeadNames = string.Empty;

                if (!this.ValidateChildren()) return;
                if (this.LeaveID == 0)
                    model = new TBL_MP_HR_LeaveConfiguration();
                else
                    model = serviceLeave.GetLeaveInfoDbRecord(this.LeaveID);

                #region GATHER DATA INTO MODEL FROM VIEW

                model.FK_LeaveTypeID = ((SelectListItem)cboLeaveType.SelectedItem).ID;
                model.MaxDaysAllow = decimal.Parse(txtMaxDaysallow.Text.Trim());
                model.CarryForwardLeave = chkLeaveCarryForward.Checked;
                model.CarryForwardLimitDays = decimal.Parse(txtLimitDays.Text.Trim());
                model.ApplicableInProbation = chkApplicableProbationPeriod.Checked;
                model.LeaveEnchashable = chkLeaveEncashable.Checked;
                model.IsActive = chkIsActive.Checked;
                model.FK_BranchID = ((SelectListItem)cboBranch.SelectedItem).ID;
                model.FK_FinYearID = ((SelectListItem)cboYear.SelectedItem).ID;

                #endregion
                #region PREPARE SALARY HEADS STRING
                if (chkLeaveEncashable.Checked)
                {
                    foreach (DataGridViewRow mRow in gridAllounces.Rows)
                    {
                        if ((bool)mRow.Cells["IsActive"].Value == true)
                        {
                            strSalaryHeadIDs += mRow.Cells["ID"].Value.ToString() + ", ";
                            strSalaryHeadNames += mRow.Cells["Description"].Value.ToString() + ", ";
                        }
                    }
                }
                #endregion
                if (strSalaryHeadIDs.Trim() != string.Empty)
                    model.EncashableSalaryHeadIDs = strSalaryHeadIDs.Trim().TrimEnd(',');
                else
                    model.EncashableSalaryHeadIDs = null;
                if(strSalaryHeadNames.Trim()!=string.Empty)
                    model.EncashableSalaryHeadNames = strSalaryHeadNames.Trim().TrimEnd(',');
                else
                    model.EncashableSalaryHeadNames = null;



                if (this.LeaveID == 0)
                {
                    this.LeaveID = serviceLeave.AddNewLeaveConfiguration(model);
                }
                else
                    serviceLeave.UpdateLeaveConfiguration(model);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkLeaveEncashable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridAllounces.ReadOnly = !chkLeaveEncashable.Checked;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveConfiguration::btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void gridAllounces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(chkLeaveEncashable.Checked)
                gridAllounces.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridAllounces.Rows[e.RowIndex].Cells["IsActive"].Value);
        }

        
    }
}
