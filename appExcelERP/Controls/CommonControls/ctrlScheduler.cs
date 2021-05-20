using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using libERP;
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlScheduler : UserControl
    {
        private ServiceUOW _UOM = null;
        

        public int SelectedID { get; set; }
        public int FollowupID { get; set; }
        public APP_ENTITIES ENTITY { get; set; }

        public ctrlScheduler()
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
        }
        public ctrlScheduler(APP_ENTITIES currentEntity)
        {
            InitializeComponent();
            this.ENTITY = currentEntity;
        }
        private void kryptonSplitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            
        }
        private void ctrlScheduler_Resize(object sender, EventArgs e)
        {
            kryptonSplitContainer1.SplitterDistance = (int)(this.Height * .3);
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void ctrlScheduler_Load(object sender, EventArgs e)
        {
            try
            {
                cboActions.DataSource = _UOM.MasterService.GetAllScheduleCallActions();
                cboActions.DisplayMember = "Description";
                cboActions.ValueMember = "ID";

                cboCallStatus.DataSource = _UOM.MasterService.GetAllScheduleCallsStatus();
                cboCallStatus.DisplayMember = "Description";
                cboCallStatus.ValueMember = "ID";

                cboReminders.DataSource = _UOM.MasterService.GetAllScheduleCallsReminders();
                cboReminders.DisplayMember = "Description";
                cboReminders.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduler::ctrlScheduler_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        public void PopulateAllFollowups()
        {
            try
            {
                gridFollowUps.DataSource = _UOM.FollowupService.GetAllFollowups(this.ENTITY, this.SelectedID);
                gridFollowUps.Columns["FollowupID"].Visible = gridFollowUps.Columns["ReferenceInfo"].Visible = gridFollowUps.Columns["ActionName"].Visible = gridFollowUps.Columns["EntryDate"].Visible = false;
                gridFollowUps.Columns["ActionDescription"].Width = (int)(gridFollowUps.Width * .15);
                gridFollowUps.Columns["Subject"].Width = (int)(gridFollowUps.Width * .3);
                gridFollowUps.Columns["ActionPlanResult"].Width = (int)(gridFollowUps.Width * .4);
                gridFollowUps.Columns["FollowUpStatus"].Width = (int)(gridFollowUps.Width * .15);
                gridFollowUps.Columns["Subject"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridFollowUps.Columns["ActionPlanResult"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridFollowUps.Columns["ActionDescription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                headerGroupForm.HeaderVisibleSecondary = false;
                DoBlanks();
                EnableEditing(false);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduler::PopulateAllFollowups", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnAddNewSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                DoBlanks();
                this.FollowupID = 0;


                EnableEditing(true);
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduler::btnAddNewSchedule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            EnableEditing(true);
        }
        public void ScatterData()
        {
            DoBlanks();
            TBL_MP_CRM_Followup_Master model = (new ServiceFollowUps()).GetFollowupInfoByFollowUpID(this.FollowupID);
            if (model != null)
            {
                cboActions.SelectedItem = ((List<SelectListItem>)cboActions.DataSource).Where(x => x.ID == model.FK_Action).FirstOrDefault();
                cboReminders.SelectedItem = ((List<SelectListItem>)cboReminders.DataSource).Where(x => x.ID == model.FK_Reminder).FirstOrDefault();
                cboCallStatus.SelectedItem = ((List<SelectListItem>)cboCallStatus.DataSource).Where(x => x.ID == model.FK_Status).FirstOrDefault();
                txtSubject.Text = model.Subject;

                dtScheduleStartDatetime.Value =AppCommon.ConvertToDateTime(model.FollowupStartDate, model.FollowupStartTime);
                dtScheduleEndDatetime.Value = AppCommon.ConvertToDateTime(model.FollowupEndDate, model.FollowupEndTime);

                txtCustomerName.Text = model.CustomerName;
                txtContactPerson.Text = model.ContactPersone;
                txtContactNumbers.Text = model.ContactNo;
                txtResultofActions.Text = model.ActionPlanResult;
                if ((bool)model.ISNextFollowupRequired)
                {
                    btnNextFollowUpRequired.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Checked;
                    
                    dtNExtScheduleStartDatetime.Value = AppCommon.ConvertToDateTime(model.NEXT_FollowupStartDate, model.NEXT_FollowupStartTime);
                    dtNextScheduleEndDatetime.Value = AppCommon.ConvertToDateTime(model.NEXT_FollowupEndDate, model.NEXT_FollowupEndTime);
                    txtNextResultOfAction.Text = model.NEXT_ActionPlanResult;
                }
                else
                {
                    btnNextFollowUpRequired.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;
                    dtNExtScheduleStartDatetime.Checked = false;
                    dtNextScheduleEndDatetime.Checked = false;


                }
                    
                
                
                

            }



        }
        public void DoBlanks()
        {
            try
            {
                cboActions.SelectedItem = null;
                cboReminders.SelectedItem = null;
                cboCallStatus.SelectedItem = null;
                txtSubject.Text = string.Empty;

                dtScheduleStartDatetime.Checked = false;
                dtScheduleEndDatetime.Checked = false;

                txtCustomerName.Text = string.Empty;
                txtContactPerson.Text = string.Empty;
                txtContactNumbers.Text = string.Empty;
                txtResultofActions.Text = string.Empty;

                btnNextFollowUpRequired.Checked = ComponentFactory.Krypton.Toolkit.ButtonCheckState.Unchecked;

                dtNExtScheduleStartDatetime.Checked = false;
                dtNextScheduleEndDatetime.Checked = false;
                txtNextResultOfAction.Text = string.Empty;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduler::DoBlanks", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        public void GatherData()
        {

        }
        private void gridFollowUps_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.FollowupID = (int)gridFollowUps.Rows[e.RowIndex].Cells["FollowupID"].Value;
                ScatterData();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduler::gridFollowUps_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void EnableEditing(bool choice)
        {
            headerGroupSchedule.Enabled = headerGroupFollowup.Enabled = headerGroupNextSchedule.Enabled = choice;
            headerGroupForm.HeaderVisibleSecondary = choice;
        }
        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            EnableEditing(false);
        }
        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            EnableEditing(false);
        }
        private void btnNextFollowUpRequired_Click(object sender, EventArgs e)
        {

        }
    }
}
