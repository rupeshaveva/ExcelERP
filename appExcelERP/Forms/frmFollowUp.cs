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
using libERP.MODELS.COMMON;
using libERP.SERVICES;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Forms
{
    public partial class frmFollowUp : KryptonForm
    {
        private ServiceUOW _UOM = null;

        public int SchdeuleID { get; set; }
        public int FollowUpID { get; set; }

        public bool NextFollowUpRequired { get; set; }

        public frmFollowUp()
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
        }
       
        private void frmFollowUp_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateScheduelInfo();
               PopulatesFollowUpStatus();
                //cboFollowUpStatus.DataSource = _UOM.MasterService.GetAllFollowUpStatus();
                //cboFollowUpStatus.DisplayMember = "Description";
                //cboFollowUpStatus.ValueMember = "ID";

                if (this.FollowUpID == 0)
                {
                    dtScheduleStartDatetime.Value = dtScheduleEndDatetime.Value = dtReaminder.Value = AppCommon.GetServerDateTime();
                    this.NextFollowUpRequired = false;
                }
                else
                {
                    dtScheduleStartDatetime.Value = dtScheduleEndDatetime.Value = dtReaminder.Value = AppCommon.GetServerDateTime();
                    TBL_MP_CRM_ScheduleCallLogFollowUp model = _UOM.ScheduleCallLogService.GetFollowUpDBItembyFollowUpID(this.FollowUpID);
                    if (model != null)
                    {
                        txtRemarks.Text = model.FollowUpRemark;
                        cboFollowUpStatus.SelectedItem = ((List<SelectListItem>)cboFollowUpStatus.DataSource).Where(x => x.ID == model.FollowUpStatus).FirstOrDefault();
                        if ((bool)model.NextFollowupRequired)
                        {
                            this.NextFollowUpRequired = (bool)model.NextFollowupRequired;
                            txtSubject.Text = model.NextFollowUpSubject;
                            dtScheduleStartDatetime.Value = model.NextFollowUpStartDatetime.Value;
                            dtScheduleEndDatetime.Value = model.NextFollowUpEndDatetime.Value;
                            dtReaminder.Value = model.NextFollowUpRemainder.Value;

                            txtContactPerson.Text = model.NextFollowUpContactName;
                            txtContactNumber.Text = model.NextFollowUpContactNumber;
                            txtLocation.Text = model.NextFollowUpLocation;
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::frmFollowUp_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region populates


        private void PopulateScheduelInfo()
        {
            try
            {
                ScheduleCallAddEditModel model = _UOM.ScheduleCallLogService.GetSchdeuledCallAddEditModelForSchedule(this.SchdeuleID);
                if (model != null)
                {
                    headerGroupSchedule.ValuesPrimary.Heading = model.HeaderTitle;
                    lblScheduleInfo.Text = string.Format("{0}\nContact {1} {2}", model.DB_MODEL.Subject.ToUpper(), model.DB_MODEL.ContactPerson, model.DB_MODEL.ContactNumber);
                    txtContactPerson.Text = model.DB_MODEL.ContactPerson;
                    txtContactNumber.Text = model.DB_MODEL.ContactNumber;
                    txtLocation.Text = model.DB_MODEL.Location;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::PopulateScheduelInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulatesFollowUpStatus()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UOM.MasterService.GetAllFollowUpStatus());
                cboFollowUpStatus.DataSource = LST;
                cboFollowUpStatus.DisplayMember = "Description";
                cboFollowUpStatus.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::PopulatesFollowUpStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void cboFollowUpStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            pageClosed.Enabled = pageNextFollowUp.Enabled=false;
            NextFollowUpRequired = false;
            if (cboFollowUpStatus.SelectedItem != null)
            {
                int statusNextFollowUp = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.NextFollowUpRequired].DEFAULT_VALUE;
                int statusClose = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.FollowUpStatusClose].DEFAULT_VALUE;

                int val = ((SelectListItem)cboFollowUpStatus.SelectedItem).ID;
                if (val == statusClose)
                {
                    tabStatus.SelectedPage = pageClosed;
                    pageClosed.Enabled = true;
                    pageClosed.Select();
                    pageNextFollowUp.Enabled = false;
                    txtReasonClose.Focus();
                }
                if (val == statusNextFollowUp)
                {
                    NextFollowUpRequired = true;
                    tabStatus.SelectedPage = pageNextFollowUp;
                    pageClosed.Enabled = false;
                    pageNextFollowUp.Enabled = true;
                    pageNextFollowUp.Select();
                    txtSubject.Focus();
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if(this.ValidateChildren())
                {
                    TBL_MP_CRM_ScheduleCallLogFollowUp followupModel = null;
                    if (this.FollowUpID == 0)
                    {
                        // INSERT NEW FOLLOWUP
                        followupModel = new TBL_MP_CRM_ScheduleCallLogFollowUp();
                        followupModel.ScheduleID = this.SchdeuleID;
                        followupModel.EmployeeID = Program.CURR_USER.EmployeeID;
                        followupModel.FollowUpDateTime = AppCommon.GetServerDateTime();
                        followupModel.FollowUpRemark = txtRemarks.Text;
                        if (cboFollowUpStatus.SelectedItem != null)
                            followupModel.FollowUpStatus = ((SelectListItem)cboFollowUpStatus.SelectedItem).ID;
                        followupModel.NextFollowupRequired = this.NextFollowUpRequired;
                        if (this.NextFollowUpRequired)
                        {
                            followupModel.NextFollowUpSubject = txtSubject.Text;
                            followupModel.NextFollowUpStartDatetime = dtScheduleStartDatetime.Value;
                            followupModel.NextFollowUpEndDatetime = dtScheduleEndDatetime.Value;
                            followupModel.NextFollowUpRemainder = dtReaminder.Value;
                            followupModel.NextFollowUpContactName = txtContactPerson.Text;
                            followupModel.NextFollowUpContactNumber = txtContactNumber.Text;
                            followupModel.NextFollowUpLocation = txtLocation.Text;
                        }
                        int statusClose = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.FollowUpStatusClose].DEFAULT_VALUE;
                        if (followupModel.FollowUpStatus == statusClose)
                        {
                            followupModel.ReasonClose = txtReasonClose.Text;
                        }
                        else
                        {
                            followupModel.ReasonClose = "";
                        }

                        Cursor = Cursors.AppStarting;
                        this.FollowUpID = await _UOM.ScheduleCallLogService.AddNewFollowUp(followupModel,Program.CURR_USER.EmployeeID);
                        if (this.FollowUpID > 0) this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        // UPDATE EXSITING FOLLOWUP
                        Cursor = Cursors.AppStarting;
                        followupModel = _UOM.AppDBContext.TBL_MP_CRM_ScheduleCallLogFollowUp.Where(x => x.FollowUpID == this.FollowUpID).FirstOrDefault();
                        followupModel.FollowUpRemark = txtRemarks.Text;
                        if (cboFollowUpStatus.SelectedItem != null)
                            followupModel.FollowUpStatus = ((SelectListItem)cboFollowUpStatus.SelectedItem).ID;
                        followupModel.NextFollowupRequired = this.NextFollowUpRequired;
                        if (this.NextFollowUpRequired)
                        {
                            followupModel.NextFollowUpSubject = txtSubject.Text;
                            followupModel.NextFollowUpStartDatetime = dtScheduleStartDatetime.Value;
                            followupModel.NextFollowUpEndDatetime = dtScheduleEndDatetime.Value;
                            followupModel.NextFollowUpRemainder = dtReaminder.Value;
                            followupModel.NextFollowUpContactName = txtContactPerson.Text;
                            followupModel.NextFollowUpContactNumber = txtContactNumber.Text;
                            followupModel.NextFollowUpLocation = txtLocation.Text;
                        }
                        int statusClose = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.FollowUpStatusClose].DEFAULT_VALUE;
                        if (followupModel.FollowUpStatus == statusClose)
                        {
                            followupModel.ReasonClose = txtReasonClose.Text;
                        }
                        else
                        {
                            followupModel.ReasonClose = "";
                        }
                        await _UOM.ScheduleCallLogService.UpdateFollowUp(followupModel,Program.CURR_USER.EmployeeID);
                        Cursor = Cursors.Default;
                        this.DialogResult = DialogResult.OK;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #region validations

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (txtRemarks.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRemarks, "Followup Feedback is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::txtRemarks_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void txtSubject_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.NextFollowUpRequired)
                {
                    if (txtSubject.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(txtSubject, "Subject line is mandaroty");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::txtSubject_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dtScheduleEndDatetime_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!this.NextFollowUpRequired) return;
                if (dtScheduleEndDatetime.Value < dtScheduleStartDatetime.Value)
                {
                    errorProvider1.SetError(dtScheduleEndDatetime, "Cant be less than Start Datetime");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::dtScheduleEndDatetime_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void dtReaminder_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!this.NextFollowUpRequired) return;
                if (dtReaminder.Value >= dtScheduleStartDatetime.Value)
                {
                    errorProvider1.SetError(dtReaminder, "Remainder from must be less that Start datetime");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::dtReaminder_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtContactPerson_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (!this.NextFollowUpRequired) return;
                if (txtContactPerson.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtContactPerson, "Contact Person Name is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::txtContactPerson_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtContactNumber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!this.NextFollowUpRequired) return;
                if (txtContactNumber.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtContactNumber, "Contact Number is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::txtContactNumber_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtLocation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!this.NextFollowUpRequired) return;
                if (txtLocation.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtLocation, "Contact Location is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::txtLocation_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

         private void txtReasonClose_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int statusClose = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.FollowUpStatusClose].DEFAULT_VALUE;
                if ((int)cboFollowUpStatus.SelectedValue == statusClose)
                {
                    if (txtReasonClose.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(tabStatus, "Mandatory to Put Reasong for Closing");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::txtReasonClose_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

        private void cboFollowUpStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboFollowUpStatus.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboFollowUpStatus, "Invalid Follow up status");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmFollowUp::cboFollowUpStatus_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void kryptonLabel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
