using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.CRM;
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
    public partial class frmAddEditLeaveApplication : Form
    {
        public int LeaveApplicationID { get; set; }
        public int EmployeeID { get; set; }

        public int SelectedLeavFormTypeID { get; set; }
        public int SelectedLeaveTypeID { get; set; }
       

        public frmAddEditLeaveApplication()
        {
            InitializeComponent();
        }
        public frmAddEditLeaveApplication(int appicationID)
        {
            InitializeComponent();
            this.LeaveApplicationID = appicationID;
        }
        private void frmAddEditLeaveApplication_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateEmployeeDropdown();
                if (EmployeeID != 0)
                {
                    cboEmployees.SelectedItem = ((List<SelectListItem>)cboEmployees.DataSource).Where(x => x.ID == EmployeeID).FirstOrDefault();
                }
                PopulateLeaveFormDropdown();
                if (this.SelectedLeavFormTypeID != 0)
                {
                    cboLeaveFormType.SelectedItem = ((List<SelectListItem>)cboLeaveFormType.DataSource).Where(x => x.ID == this.SelectedLeavFormTypeID).FirstOrDefault();
                }

                PopulateLeaveTypeDropdown();
                PopulateRequestToDropdown();
                if (LeaveApplicationID == 0)
                {
                    
                    
                    txtLeaveApplicationNo.Text = (new ServiceLeaveApplication()).GenerateNewLeaveApplicationNumber(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                    dtLeaveApplicationDate.Value = AppCommon.GetServerDateTime();
                    

                    tbl_Acct_Financial_Year dbYear = (new ServiceMASTERS()).GetFinancialYearDbRecordByID(Program.CURR_USER.FinYearID);
                    //dtLeaveApplicationDate.MinDate = dtFromDate.MinDate = dtFromTime.MinDate = dtToDate.MinDate= dtToTime.MinDate= dbYear.FromDate;
                    //dtLeaveApplicationDate.MaxDate = dtFromDate.MaxDate = dtFromTime.MaxDate = dtToDate.MaxDate = dtToTime.MaxDate = dbYear.ToDate;
                    dtLeaveApplicationDate.Value = dtFromDate.Value = dtFromTime.Value = dtToDate.Value = dtToTime.Value = AppCommon.GetServerDateTime();
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
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::frmAddEditLeaveApplication_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void PopulateLeaveFormDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceLeaveApplication()).GetAllLeaveFormTypes());
                cboLeaveFormType.DataSource = LST;
                cboLeaveFormType.DisplayMember = "Description";
                cboLeaveFormType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::PopulateLeaveFormDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateLeaveTypeDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceLeaveApplication()).GetAllLeaveTypesForLeaveForm(this.SelectedLeavFormTypeID));
                cboLeaveType.DataSource = LST;
                cboLeaveType.DisplayMember = "Description";
                cboLeaveType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::PopulateLeaveTypeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateEmployeeDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllActiveEmployees());
                cboEmployees.DataSource = LST;
                cboEmployees.DisplayMember = "Description";
                cboEmployees.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::PopulateEmployeeDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateRequestToDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllEmployees());
                cboRequestTo.DataSource = LST;
                cboRequestTo.DisplayMember = "Description";
                cboRequestTo.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::PopulateRequestToDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ScatterData()
        {
            ServiceLeaveApplication _service = new ServiceLeaveApplication();
            try
            {
                TBL_MP_HR_LeaveApplication model = _service.GetLeaveApplicationInfoDbRecord(this.LeaveApplicationID);
                if (model != null)
                {
                    txtLeaveApplicationNo.Text = model.ApplicationNo;
                    dtLeaveApplicationDate.Value = model.ApplicationDate;

                    cboEmployees.SelectedItem = ((List<SelectListItem>)cboEmployees.DataSource).Where(x => x.ID == model.FK_EmployeeID).FirstOrDefault();
                    cboRequestTo.SelectedItem = ((List<SelectListItem>)cboRequestTo.DataSource).Where(x => x.ID == model.FK_RequestTo).FirstOrDefault();
                    cboLeaveFormType.SelectedItem = ((List<SelectListItem>)cboLeaveFormType.DataSource).Where(x => x.ID == model.FK_UserList_LeaveFormTypeID).FirstOrDefault();
                    this.SelectedLeavFormTypeID = model.FK_UserList_LeaveFormTypeID;
                    int leaveFormID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTypeLeaveID).FirstOrDefault().DEFAULT_VALUE;
                    int outdoorFormID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTypeOutDoorID).FirstOrDefault().DEFAULT_VALUE;

                    if (model.FK_UserList_LeaveFormTypeID == leaveFormID || model.FK_UserList_LeaveFormTypeID == outdoorFormID)
                    {
                        PopulateLeaveTypeDropdown();
                        cboLeaveType.SelectedItem = ((List<SelectListItem>)cboLeaveType.DataSource).Where(x => x.ID == model.fK_UsrLst_LeaveTypeID).FirstOrDefault();
                    }
                    
                    dtFromDate.Value = model.FromDate;
                    dtToDate.Value = model.ToDate;
                    dtFromTime.Value = model.FromTime.Value;
                    dtToTime.Value = model.ToTime.Value;
                    txtRemarks.Text = model.Remarks;

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cboLeaveFormType_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }
        private void cboLeaveFormType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboLeaveType.Enabled = false;
                if (cboLeaveFormType.SelectedItem != null)
                {
                    SelectedLeavFormTypeID = ((SelectListItem)cboLeaveFormType.SelectedItem).ID;
                }
                cboLeaveType.DataSource = null;
                int leaveFormID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTypeLeaveID).FirstOrDefault().DEFAULT_VALUE;
                int outdoorFormID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LeaveFormTypeOutDoorID).FirstOrDefault().DEFAULT_VALUE;

                if (SelectedLeavFormTypeID == leaveFormID || SelectedLeavFormTypeID == outdoorFormID)
                {
                    PopulateLeaveTypeDropdown();
                    cboLeaveType.Enabled = true;
                }
                if (SelectedLeavFormTypeID == leaveFormID || SelectedLeavFormTypeID == outdoorFormID)
                {

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::cboLeaveFormType_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            TBL_MP_HR_LeaveApplication model = null;

            ServiceLeaveApplication serviceLeaveApp = new ServiceLeaveApplication();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.LeaveApplicationID == 0)
                    model = new TBL_MP_HR_LeaveApplication();
                else
                    model = serviceLeaveApp.GetLeaveApplicationInfoDbRecord(this.LeaveApplicationID);

                #region GATHER DATA INTO MODEL FROM VIEW

                model.ApplicationNo = txtLeaveApplicationNo.Text.Trim();
                model.ApplicationDate = dtLeaveApplicationDate.Value;
                model.FK_EmployeeID = ((SelectListItem)cboEmployees.SelectedItem).ID;
                model.FK_RequestTo = ((SelectListItem)cboRequestTo.SelectedItem).ID;
                model.FK_UserList_LeaveFormTypeID = ((SelectListItem)cboLeaveFormType.SelectedItem).ID;
                model.PreparedBy = Program.CURR_USER.EmployeeID;
                if(cboLeaveType.SelectedItem!=null)
                    model.fK_UsrLst_LeaveTypeID = ((SelectListItem)cboLeaveType.SelectedItem).ID;
                else
                    model.fK_UsrLst_LeaveTypeID = 0;

                model.FromDate =new DateTime(dtFromDate.Value.Year, dtFromDate.Value.Month, dtFromDate.Value.Day);
                model.ToDate = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day);
                model.FromTime = dtFromTime.Value;
                model.ToTime = dtToTime.Value;
                model.Duration = txtNoOfDays.Text.Trim();
                model.Remarks = txtRemarks.Text.Trim();
                model.CreateDateTime = AppCommon.GetServerDateTime();

                #endregion
                if (this.LeaveApplicationID == 0)
                {
                    model.FK_YearID = Program.CURR_USER.FinYearID;
                    model.FK_BranchID = Program.CURR_USER.BranchID;
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;

                    this.LeaveApplicationID = serviceLeaveApp.AddNewLeaveApplicationInfo(model);
                }
                else
                    serviceLeaveApp.UpdateLeaveApplicationInfo(model);

                // UPDATE ATTENDANCE AS PER LEAVE
                serviceLeaveApp.UpdateAttendanceForLeaveApplication(this.LeaveApplicationID);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        

        #region VALIDATIONS
        private void cboLeaveFormType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboLeaveFormType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboLeaveFormType, "Select Leave Form Type");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::cboLeaveFormType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (txtRemarks.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRemarks, "Mandatory!");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::txtRemarks_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtFromDate_Validating(object sender, CancelEventArgs e)
        {
        
            try
            {
                if (dtFromDate.Value > dtToDate.Value)
                {
                    errorProvider1.SetError(dtToDate, "To Date should be greater than from date");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::dtFromDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtLeaveApplicationNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtLeaveApplicationNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtLeaveApplicationNo, "Application No. not generated");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::dtFromDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboEmployees_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboEmployees.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboEmployees, "Select Employee");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::cboEmployees_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboRequestTo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboRequestTo.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboRequestTo, "Select Request To");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::cboRequestTo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void cboLeaveType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                ServiceLeaveApplication _service = new ServiceLeaveApplication();
                SelectListItem leaveForm = (SelectListItem)cboLeaveFormType.SelectedItem;
                if(leaveForm.ID== _service.LEAVE_TYPE_LEAVE_ID || leaveForm.ID== _service.LEAVE_TYPE_OUTDOOR_ID)
                { 
                    if (((SelectListItem)cboLeaveType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboLeaveType, "Select Leave Type");
                    e.Cancel = true;
                }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::cboLeaveType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtFromTime.Value = new DateTime(dtFromDate.Value.Year, dtFromDate.Value.Month, dtFromDate.Value.Day, dtFromTime.Value.Hour, dtFromTime.Value.Minute, 0);
                txtNoOfDays.Text = AppCommon.GetTimeDuration(dtFromTime.Value, dtToTime.Value).Text;
                //CalculateNoOfDays();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::dtFromDate_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtToTime.Value = new DateTime(dtToDate.Value.Year, dtToDate.Value.Month, dtToDate.Value.Day, dtToTime.Value.Hour, dtToTime.Value.Minute, 0);
                txtNoOfDays.Text = AppCommon.GetTimeDuration(dtFromTime.Value, dtToTime.Value).Text;
                //CalculateNoOfDays();
                //int HalfDayleaveID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.LEAVE_TYPE_HALFDAY_ID).FirstOrDefault().DEFAULT_VALUE;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::dtToDate_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtFromTime_ValueChanged(object sender, EventArgs e)
        {
            txtNoOfDays.Text = AppCommon.GetTimeDuration(dtFromTime.Value, dtToTime.Value).Text;
        }
        private void dtToTime_ValueChanged(object sender, EventArgs e)
        {
            txtNoOfDays.Text = AppCommon.GetTimeDuration(dtFromTime.Value, dtToTime.Value).Text;
        }
        private void cboLeaveType_SelectedValueChanged(object sender, EventArgs e)
        {
            ServiceLeaveApplication service = new ServiceLeaveApplication();
            try
            {
                DateTime inTime = new DateTime(dtFromTime.Value.Year, dtFromTime.Value.Month, dtFromTime.Value.Day, 8, 45, 0);
                DateTime outTime = new DateTime(dtToTime.Value.Year, dtToTime.Value.Month, dtToTime.Value.Day, 17, 15, 0);
                lblLeaveBalanceInfo.Text = string.Empty;

                if (cboLeaveType.SelectedItem != null)
                {
                    this.SelectedLeaveTypeID = ((SelectListItem)cboLeaveType.SelectedItem).ID;
                    EmployeeID = ((SelectListItem)cboEmployees.SelectedItem).ID;
                    btnSave.Enabled = true;
                    if (SelectedLeavFormTypeID == service.LEAVE_TYPE_LEAVE_ID)
                    {
                       
                        LeaveBalanceModel model = service.GetLeaveBalanceModelOfEmployeeForYear(EmployeeID, Program.CURR_USER.FinYearID, SelectedLeaveTypeID);
                        if (model != null)
                        {
                            lblLeaveBalanceInfo.Text = string.Format("Allowed [{0}] Earned [{1}] Taken [{2}] Balance [{3}]", model.Allowed, model.Earned, model.Taken, model.Balance);
                            if (model.Balance <= 0)
                            {
                                btnSave.Enabled = false;

                            }
                        }


                      //  if (SelectedLeaveTypeID == service.LEAVE_TYPE_HALFDAY_ID)
                     //   {
                       //     double cntDays = 0.5;
                       //   txtNoOfDays.Text = cntDays.ToString();
                      // }

                    }
                    if (SelectedLeavFormTypeID == service.LEAVE_TYPE_OUTDOOR_ID)
                    {
                        inTime = new DateTime(dtFromTime.Value.Year, dtFromTime.Value.Month, dtFromTime.Value.Day, 8, 45, 0);
                        outTime = new DateTime(dtToTime.Value.Year, dtToTime.Value.Month, dtToTime.Value.Day, 17, 15, 0);
                        int outDoorTypeID = ((SelectListItem)cboLeaveType.SelectedItem).ID;
                        if (outDoorTypeID == service.OUTDOOR_FULLSHIFT_ID)
                        {
                            inTime = new DateTime(dtFromTime.Value.Year, dtFromTime.Value.Month, dtFromTime.Value.Day, 8, 45, 0);
                            outTime = new DateTime(dtToTime.Value.Year, dtToTime.Value.Month, dtToTime.Value.Day, 17, 15, 0);
                        }
                        if (outDoorTypeID == service.OUTDOOR_FIRST_HALF_ID)
                        {
                            inTime = new DateTime(dtFromTime.Value.Year, dtFromTime.Value.Month, dtFromTime.Value.Day, 8, 45, 0);
                            outTime = new DateTime(dtToTime.Value.Year, dtToTime.Value.Month, dtToTime.Value.Day, 13, 00, 0);
                        }
                        if (outDoorTypeID == service.OUTDOOR_SECOND_HALF_ID)
                        {
                            inTime = new DateTime(dtFromTime.Value.Year, dtFromTime.Value.Month, dtFromTime.Value.Day, 13, 45, 0);
                            outTime = new DateTime(dtToTime.Value.Year, dtToTime.Value.Month, dtToTime.Value.Day, 17, 15, 0);
                        }
                    }
                    dtFromTime.Value = inTime;
                    dtToTime.Value = outTime;
                    txtNoOfDays.Text = AppCommon.GetTimeDuration(dtFromTime.Value, dtToTime.Value).Text;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLeaveApplication::cboLeaveType_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblLeaveBalanceInfo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
