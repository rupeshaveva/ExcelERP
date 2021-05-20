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
using appExcelERP.Controls.CommonControls;

using appExcelERP.Forms.UserList;
using libERP.SERVICES;
using libERP.MODELS.COMMON;
using libERP.MODELS;

namespace appExcelERP.Forms
{
    public partial class frmScheduleCall : KryptonForm
    {
        private ServiceUOW _UNIT = null;
        
        public ScheduleCallAddEditModel MODEL { get; set; }


        public frmScheduleCall()
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            MODEL = new ScheduleCallAddEditModel();
        }
        public frmScheduleCall(int scheduleID)
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            MODEL = new ScheduleCallAddEditModel();
            MODEL.ScheduleID = scheduleID;
        }

        private void frmScheduleCall_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void frmScheduleCall_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateScheduledCallAction();
                PopulatePrioritiesDropDown();
                //cboActions.DataSource = _UNIT.MasterService.GetAllScheduleCallActions();
               // cboActions.DisplayMember = "Description";
                //cboActions.ValueMember = "ID";

                cboCallStatus.DataSource = _UNIT.MasterService.GetAllScheduleCallsStatus();
                cboCallStatus.DisplayMember = "Description";
                cboCallStatus.ValueMember = "ID";
                
                MODEL.listAssignees = new BindingList<MultiSelectListItem>();

                if (MODEL.ScheduleID == 0)
                {
                    MODEL.PrepareForInsert();
                    txtCompanyName.Text = MODEL.DB_MODEL.CustomerName;
                    txtContactPersons.Text = MODEL.DB_MODEL.ContactPerson;
                    txtContactNumbers.Text = MODEL.DB_MODEL.ContactNumber;
                    txtContactLocation.Text = MODEL.DB_MODEL.Location;
                    headerGroupSchedule.ValuesPrimary.Heading = MODEL.HeaderTitle;

                    dtScheduleStartDatetime.Value = MODEL.DB_MODEL.StartAt.Value;
                    dtScheduleEndDatetime.Value = MODEL.DB_MODEL.EndsAt.Value;
                    dtReaminder.Value = MODEL.DB_MODEL.Reminder.Value;

                    PopulateAssigneeGrid();
                    int inProgressStatusID = Program.LIST_DEFAULTS[(int) APP_DEFAULT_VALUES.ScheduleCallStatusInProgress].DEFAULT_VALUE;
                    cboCallStatus.SelectedItem = ((List<SelectListItem>)cboCallStatus.DataSource).Where(x => x.ID == inProgressStatusID).FirstOrDefault();
                    cboCallStatus.Enabled = false;
                }
                else
                {
                    MODEL.PrepareForEdit();
                    txtSubject.Text = MODEL.DB_MODEL.Subject;
                    txtCompanyName.Text = MODEL.DB_MODEL.CustomerName;
                    txtContactPersons.Text = MODEL.DB_MODEL.ContactPerson;
                    txtContactNumbers.Text = MODEL.DB_MODEL.ContactNumber;
                    txtContactLocation.Text = MODEL.DB_MODEL.Location;
                    headerGroupSchedule.ValuesPrimary.Heading = MODEL.HeaderTitle;

                    dtScheduleStartDatetime.Value = MODEL.DB_MODEL.StartAt.Value;
                    dtScheduleEndDatetime.Value = MODEL.DB_MODEL.EndsAt.Value;
                    dtReaminder.Value = MODEL.DB_MODEL.Reminder.Value;

                    cboPriority.SelectedItem = ((List<SelectListItem>)cboPriority.DataSource).Where(x => x.ID == MODEL.DB_MODEL.Priority).FirstOrDefault();
                    cboActions.SelectedItem = ((List<SelectListItem>)cboActions.DataSource).Where(x => x.ID == MODEL.DB_MODEL.ActionID).FirstOrDefault();
                    cboCallStatus.SelectedItem = ((List<SelectListItem>)cboCallStatus.DataSource).Where(x => x.ID == MODEL.DB_MODEL.ScheduleStatus).FirstOrDefault();

                    txtRemarks.Text = MODEL.DB_MODEL.Remarks;
                    PopulateAssigneeGrid();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::frmScheduleCall_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
           
            this.Cursor = Cursors.Default;
        }

        private void PopulateScheduledCallAction()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllScheduleCallActions());
                cboActions.DataSource = LST;
                cboActions.ValueMember = "ID";
                cboActions.DisplayMember = "Description";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::PopulateScheduledCallAction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void PopulatePrioritiesDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UNIT.MasterService.GetAllScheduleCallPriorities());
                cboPriority.DataSource =LST ;
                cboPriority.ValueMember = "ID";
                cboPriority.DisplayMember = "Description";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::PopulatePrioritiesDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


           
        }



        private void btnAddNewAssignee_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.EMPLOYEES, MODEL.SOURCE_ENTITY, MODEL.SOURCE_ENTITY_ID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (MultiSelectListItem item in frm.SelectedItems)
                {
                    if (MODEL.listAssignees.Where(x => x.ID == item.ID).FirstOrDefault() == null)
                    {
                        MODEL.listAssignees.Add(item);
                    }
                }
                PopulateAssigneeGrid();
            }
            this.Cursor = Cursors.Default;
        }

        private void PopulateAssigneeGrid()
        {
            try
            {
                gridAssignees.DataSource = MODEL.listAssignees.OrderBy(x => x.Description).ToList();
                for (int i = 0; i < gridAssignees.Columns.Count; i++)
                {
                    gridAssignees.Columns[i].Visible = false;
                }
                gridAssignees.Columns["Selected"].Visible = true;
                gridAssignees.Columns["Description"].Visible = true;
                gridAssignees.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridAssignees.Columns["Selected"].Width = (int)(gridAssignees.Width * .1);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::PopulateAssigneeGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void gridAssignees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            gridAssignees.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridAssignees.Rows[e.RowIndex].Cells["Selected"].Value);
        }

        private void btnRemoveAssignee_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridAssignees.Rows)
            {
                int mID = int.Parse(row.Cells["ID"].Value.ToString());
                if ((bool)row.Cells["Selected"].Value==true)
                {
                    MODEL.listAssignees.Remove(MODEL.listAssignees.Where(x => x.ID == mID).FirstOrDefault());
                }
            }
            PopulateAssigneeGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region  VALIDATIONS
        private void txtSubject_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSubject.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSubject, "Subejct Can't be left blank");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::txtSubject_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                if (txtCompanyName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtCompanyName, "Company Name Can't be left blank");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {


                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::txtCompanyName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtContactPersons_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtContactPersons.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtContactPersons, "Atleast one Contact person");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::txtCompanyName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtContactNumbers_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtContactNumbers.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtContactNumbers, "Atleast one Contact Number");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::txtContactNumbers_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtContactLocation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtContactNumbers.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtContactLocation, "Location of Contact can't be left blank");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::txtContactLocation_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridAssignees_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (MODEL.listAssignees.Count == 0)
                {
                    errorProvider1.SetError(gridAssignees, "Selecte atleast one Assignee for this schedule");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::gridAssignees_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dtReaminder_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (dtReaminder.Value > dtScheduleStartDatetime.Value)
                {
                    errorProvider1.SetError(dtReaminder, "Must Remind before Schedules Start Datetime");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::dtReaminder_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dtScheduleEndDatetime_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (dtScheduleEndDatetime.Value < dtScheduleStartDatetime.Value)
                {
                    errorProvider1.SetError(dtScheduleEndDatetime, "Schdeule End datetime must be ahead of Start Datetime");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::dtScheduleEndDatetime_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void cboActions_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboActions.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboActions, "Invalid Action");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall ::cboActions_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboPriority_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboPriority.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboPriority, "Invalid Priority");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall ::cboPriority_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboCallStatus_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboCallStatus.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboCallStatus, "Invalid Status");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall ::cboCallStatus_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (this.ValidateChildren())
                {
                    GatherData();
                    if (MODEL.ScheduleID == 0)
                        MODEL.ScheduleID = await _UNIT.ScheduleCallLogService.AddNewScheduleCall(MODEL,Program.CURR_USER.EmployeeID);
                    else
                        await _UNIT.ScheduleCallLogService.UpdateScheduleCall(MODEL,Program.CURR_USER.EmployeeID);
                    if (_UNIT.ScheduleCallLogService.IsScuccess)
                        this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmScheduleCall::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GatherData()
        {
            MODEL.DB_MODEL.CustomerName = txtCompanyName.Text;
            MODEL.DB_MODEL.ContactPerson = txtContactPersons.Text;
            MODEL.DB_MODEL.ContactNumber = txtContactNumbers.Text;
            MODEL.DB_MODEL.Location = txtContactLocation.Text;

            MODEL.DB_MODEL.Priority = ((SelectListItem)cboPriority.SelectedItem).ID;
            MODEL.DB_MODEL.ActionID = ((SelectListItem)cboActions.SelectedItem).ID;
            MODEL.DB_MODEL.ScheduleStatus = ((SelectListItem)cboCallStatus.SelectedItem).ID;
            
            MODEL.DB_MODEL.Subject = txtSubject.Text;
            MODEL.DB_MODEL.StartAt = dtScheduleStartDatetime.Value;
            MODEL.DB_MODEL.EndsAt = dtScheduleEndDatetime.Value;
            MODEL.DB_MODEL.Reminder = dtReaminder.Value;
            MODEL.DB_MODEL.Remarks = txtRemarks.Text;

        }

        private void headerGroupSchedule_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabelAddNewAction_LinkClicked(object sender, EventArgs e)
        {
            frmMasterUserList frm = new frmMasterUserList();
            frm.Text = "Add Action of Business Schdeule Call";
            frm.MASTERCategoryID = (int)APP_MASTER_CATEGORIES.CALL_SCHEDULE_ACTIONS;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cboActions.DataSource = _UNIT.MasterService.GetAllScheduleCallActions();
                cboActions.DisplayMember = "Description";
                cboActions.ValueMember = "ID";
                cboActions.SelectedItem = ((List<SelectListItem>)cboActions.DataSource).Where(x => x.ID == frm.ID).FirstOrDefault();
            }
        }

        
    }
}
