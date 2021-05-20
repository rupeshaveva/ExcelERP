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
    public partial class frmAddEditEmployeeLeaveConfig : Form
    {
        public int EmployeeID { get; set; }
        public int FinYearID { get; set; }
        public int PK_LeaveID { get; set; }
          public int SeledctedYearID { get; set; }

        public frmAddEditEmployeeLeaveConfig()
        {
            InitializeComponent();
        }
        public frmAddEditEmployeeLeaveConfig(int LeaveID)
        {
            InitializeComponent();
            PK_LeaveID = LeaveID;
        }

        private void frmAddEditEmployeeLeaveConfig_Load(object sender, EventArgs e)
        {
            try
            {
               
                PopulateFinancialYearDropdown();
                PopulateleaveTypeDropDown();
                PopulateAllounceSalaryHeads();
                if (PK_LeaveID == 0)
                {
                    if (EmployeeID != 0)
                    {
                        headerEmployeeName.Values.Description = ServiceEmployee.GetEmployeeNameByID(this.EmployeeID);
                    }
                    txtLimitDays.Text = txtMaxDaysallow.Text = String.Empty;
                    chkLeaveCarryForward.Checked = chkApplicableProbationPeriod.Checked = chkLeaveEncashable.Checked = false;
                    chkIsActive.Checked = true;
                   
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
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::frmAddEditEmployeeLeaveConfig_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::PopulateleaveTypeDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::PopulateFinancialYearDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::PopulateAllounceSalaryHeads", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ScatterData()
        {
            try
            {
                TBL_MP_Master_Employee_LeaveConfiguration model = (new ServiceEmployee()).GetEmpLeaveInfoDbRecord(this.PK_LeaveID);
                if (model != null)
                {
                    if (EmployeeID != 0)
                    {
                        headerEmployeeName.Values.Description = ServiceEmployee.GetEmployeeNameByID(model.FK_EmployeeID);
                    }
                    txtLimitDays.Text = model.CarryForwardLimitDays.ToString();
                    txtMaxDaysallow.Text = model.MaxDaysAllow.ToString();
                    cboLeaveType.SelectedItem = ((List<SelectListItem>)cboLeaveType.DataSource).Where(x => x.ID == model.FK_LeaveTypeID).FirstOrDefault();
                    chkApplicableProbationPeriod.Checked = model.ApplicableInProbation;
                    chkLeaveCarryForward.Checked = model.CarryForwardLeave;
                    chkLeaveEncashable.Checked = model.LeaveEnchashable;
                    txtLeaveOpeningBalance.Text = model.LeavesEarned.ToString();
                    chkIsActive.Checked = model.IsActive;
                   this.SeledctedYearID = model.FK_FinYearID;
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
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::cboLeaveType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::txtMaxDaysallow_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLimitDays_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (chkLeaveCarryForward.Checked)
                {
                    if (txtLimitDays.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(txtLimitDays, "Limit Days is  Mandatory");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::txtLimitDays_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Employee_LeaveConfiguration model = null;
            ServiceEmployee serviceEmpLeave = new ServiceEmployee();
            try
            {
                string strSalaryHeadIDs = string.Empty;
                string strSalaryHeadNames = string.Empty;

                if (!this.ValidateChildren()) return;
                if (this.PK_LeaveID == 0)
                {
                    model = new TBL_MP_Master_Employee_LeaveConfiguration();
                    model.FK_BranchID = Program.CURR_USER.BranchID;
                    model.FK_EmployeeID = this.EmployeeID;
                }
                else
                    model = serviceEmpLeave.GetEmpLeaveInfoDbRecord(this.PK_LeaveID);

                #region GATHER DATA INTO MODEL FROM VIEW

                model.FK_LeaveTypeID = ((SelectListItem)cboLeaveType.SelectedItem).ID;
                model.MaxDaysAllow = decimal.Parse(txtMaxDaysallow.Text.Trim());
                model.CarryForwardLeave = chkLeaveCarryForward.Checked;
                if(model.CarryForwardLeave)
                    model.CarryForwardLimitDays = decimal.Parse(txtLimitDays.Text.Trim());
                model.ApplicableInProbation = chkApplicableProbationPeriod.Checked;
                model.LeaveEnchashable = chkLeaveEncashable.Checked;
                model.IsActive = chkIsActive.Checked;
                model.FK_FinYearID = ((SelectListItem)cboYear.SelectedItem).ID;
                model.LeavesEarned = decimal.Parse(txtLeaveOpeningBalance.Text.Trim());

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
                if (strSalaryHeadNames.Trim() != string.Empty)
                    model.EncashableSalaryHeadNames = strSalaryHeadNames.Trim().TrimEnd(',');
                else
                    model.EncashableSalaryHeadNames = null;



                if (this.PK_LeaveID == 0)
                {
                    this.PK_LeaveID = serviceEmpLeave.AddNewEmpLeaveConfiguration(model);
                }
                else
                    serviceEmpLeave.UpdateEmpLeaveConfiguration(model);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void gridAllounces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gridAllounces.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridAllounces.Rows[e.RowIndex].Cells["IsActive"].Value);
        }
        private void txtLeaveOpeningBalance_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal earned = 0;
               decimal.TryParse(txtLeaveOpeningBalance.Text.Trim(), out earned);
                txtLeaveOpeningBalance.Text = earned.ToString();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeLeaveConfig::txtLeaveOpeningBalance_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
