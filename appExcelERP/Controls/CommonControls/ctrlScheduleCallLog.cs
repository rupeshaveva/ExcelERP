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
using libERP.MODELS;
using appExcelERP.Forms;
using libERP;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlScheduleCallLog : UserControl
    {
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnAddNewSchedule.Enabled = btnEditSchedule.Enabled = btnDeleteSchedule.Enabled = 
                    btnAddNewFollowup.Enabled= btnEditFollowup.Enabled= btnDeleteFollowup.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
                else
                {
                    btnAddNewSchedule.Enabled = btnEditSchedule.Enabled = btnDeleteSchedule.Enabled =
                    btnAddNewFollowup.Enabled = btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
            }
        }

        private bool _IsScheduleClosed = false;

        public APP_ENTITIES SOURCE_ENTITY { get; set; }
        public int SOURCE_ENTITY_ID { get; set; }

        public int SelectedScheduleID { get; set; }
        public int SelectedFollowUpID { get; set; }

        public BindingList<SelectListItem> listRecentSchedules { get; set; }
        public BindingList<SelectListItem> listPastSchedules { get; set; }
        public BindingList<FollowUpListModel> listFollowUps { get; set; }


        public ctrlScheduleCallLog(APP_ENTITIES entity)
        {
            InitializeComponent();
            this.SOURCE_ENTITY = entity;
        }
        private void ctrlScheduleCallLog_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance= (int)(this.Width*.4);
        }
        public void PopulateAllSchedules()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                headerGroupFollowUps.ValuesPrimary.Heading = string.Empty;
                gridFollowUps.DataSource = null;
                listRecentSchedules = new BindingList<SelectListItem>();
                listPastSchedules = new BindingList<SelectListItem>();

                btnEditSchedule.Enabled = btnDeleteSchedule.Enabled = btnAddNewFollowup.Enabled = btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                PopulatePastSchedules();
                PopulateRecentSchedules();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduleCallLog::PopulateAllSchedules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void btnAddNewSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                frmScheduleCall frm = new frmScheduleCall();
                frm.MODEL.SOURCE_ENTITY = this.SOURCE_ENTITY;
                frm.MODEL.SOURCE_ENTITY_ID = this.SOURCE_ENTITY_ID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAllSchedules();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduleCallLog::btnAddNewSchedule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnEditSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.AppStarting;
                frmScheduleCall frm = new frmScheduleCall(this.SelectedScheduleID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAllSchedules();
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduleCallLog::btnEditSchedule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void txtSearchRecentSchedules_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gridRecentSchedules.DataSource = new BindingList<SelectListItem>(listRecentSchedules.Where(p => p.DescriptionToUpper.Contains(txtSearchRecentSchedules.Text.ToUpper())).ToList()); ;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduleCallLog::txtSearchRecentSchedules_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        private void txtSearchFollowUps_TextChanged(object sender, EventArgs e)
        {
            try
            {
                gridFollowUps.DataSource = new BindingList<FollowUpListModel>(listFollowUps.Where(p => p.SearchText.Contains(txtSearchFollowUps.Text.ToUpper())).ToList()); ;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduleCallLog::txtSearchFollowUps_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        private void gridRecentSchedules_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedScheduleID = int.Parse(gridRecentSchedules.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                _IsScheduleClosed = (new ServiceScheduleCallLog()).IsSchdeuleClosed(this.SelectedScheduleID);
                headerGroupFollowUps.ValuesPrimary.Heading = gridRecentSchedules.Rows[e.RowIndex].Cells["Description"].Value.ToString().Replace("\n", " ");
                if (!ReadOnly)
                {
                    btnEditSchedule.Enabled = btnDeleteSchedule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    SetFollowupButtonStatus();
                }

                PopulateFollowUpsForRecentSchdeules();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::gridRecentSchedules_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridPastSchedules_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedScheduleID = int.Parse(gridPastSchedules.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                _IsScheduleClosed = (new ServiceScheduleCallLog()).IsSchdeuleClosed(this.SelectedScheduleID);

                headerGroupFollowUps.ValuesPrimary.Heading = gridPastSchedules.Rows[e.RowIndex].Cells["Description"].Value.ToString().Replace("\n", " ");
                //if(!ReadOnly)
                //    SetFollowupButtonStatus();
                PopulateFollowUpsForRecentSchdeules();
                if (!ReadOnly)
                {
                    btnAddNewFollowup.Enabled = btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnEditSchedule.Enabled = btnDeleteSchedule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::gridRecentSchedules_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridFollowUps_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedFollowUpID = int.Parse(gridFollowUps.Rows[e.RowIndex].Cells["FollowUpID"].Value.ToString());

                TBL_MP_CRM_ScheduleCallLogFollowUp followup = (new ServiceScheduleCallLog()).GetFollowUpDBItembyFollowUpID(this.SelectedFollowUpID);
                if (!ReadOnly && !_IsScheduleClosed)
                {
                    if (followup != null)
                    {
                        if (followup.EmployeeID == Program.CURR_USER.EmployeeID)
                            btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                        else
                            btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::gridFollowUps_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #region HELPER METHODS
        private void SetFollowupButtonStatus()
        {
            try
            {
                ScheduleCallAddEditModel model = (new ServiceScheduleCallLog()).GetSchdeuledCallAddEditModelForSchedule(this.SelectedScheduleID);
                if (model != null)
                {
                    MultiSelectListItem item = model.listAssignees.Where(x => x.ID == Program.CURR_USER.EmployeeID).FirstOrDefault();
                    if (!ReadOnly)
                    {
                        if (item == null)
                            btnAddNewFollowup.Enabled = btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = btnEditSchedule.Enabled = btnDeleteSchedule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                        else
                            btnAddNewFollowup.Enabled = btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = btnEditSchedule.Enabled = btnDeleteSchedule.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::SetFollowupButtonStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateRecentSchedules()
        {
            try
            {
                listRecentSchedules = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceScheduleCallLog()).GetActiveScheduleCallsFor(SOURCE_ENTITY, SOURCE_ENTITY_ID));
                gridRecentSchedules.DataSource = listRecentSchedules;
                gridRecentSchedules.Columns["ID"].Visible = gridRecentSchedules.Columns["IsActive"].Visible = gridRecentSchedules.Columns["Code"].Visible = gridRecentSchedules.Columns["DescriptionToUpper"].Visible = false;
                gridRecentSchedules.Columns["Description"].HeaderText = "Most Recent";
                gridRecentSchedules.ColumnHeadersDefaultCellStyle.Font = new Font(gridRecentSchedules.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::PopulateRecentSchedules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulatePastSchedules()
        {
            try
            {
                listPastSchedules = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceScheduleCallLog()).GetPastScheduleCallsFor(SOURCE_ENTITY, SOURCE_ENTITY_ID));
                gridPastSchedules.DataSource = listPastSchedules;
                gridPastSchedules.Columns["ID"].Visible = gridPastSchedules.Columns["IsActive"].Visible = gridPastSchedules.Columns["Code"].Visible = gridPastSchedules.Columns["DescriptionToUpper"].Visible = false;
                gridPastSchedules.Columns["Description"].HeaderText = "History";
                gridPastSchedules.ColumnHeadersDefaultCellStyle.Font = new Font(gridPastSchedules.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::PopulatePastSchedules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateFollowUpsForRecentSchdeules()
        {
            try
            {
                this.SelectedFollowUpID = 0;
                btnEditFollowup.Enabled = btnDeleteFollowup.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                listFollowUps = AppCommon.ConvertToBindingList<FollowUpListModel>((new ServiceScheduleCallLog()).GetAllFollowupsForSchedule(this.SelectedScheduleID));
                gridFollowUps.DataSource = listFollowUps;
                gridFollowUps.Columns["FollowupID"].Visible = gridFollowUps.Columns["ScheduleID"].Visible = gridFollowUps.Columns["EmployeeID"].Visible = gridFollowUps.Columns["StatusID"].Visible = false;
                gridFollowUps.Columns["AttendedBy"].Width = (int)(gridFollowUps.Width * .2);
                gridFollowUps.Columns["FollowUpDescription"].Width = (int)(gridFollowUps.Width * .4);
                gridFollowUps.Columns["NextFollowUpDescription"].Width = (int)(gridFollowUps.Width * .4);
                gridFollowUps.ColumnHeadersDefaultCellStyle.Font = new Font(gridFollowUps.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                gridFollowUps.Columns["AttendedBy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                gridFollowUps.Columns["FollowUpDescription"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                gridFollowUps.Columns["NextFollowUpDescription"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::PopulateFollowUpsForRecentSchdeules", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #endregion

        private void btnAddNewFollowup_Click(object sender, EventArgs e)
        {
            try
            {
                frmFollowUp frm = new frmFollowUp();
                frm.SchdeuleID = this.SelectedScheduleID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAllSchedules();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlScheduleCallLog::btnAddNewFollowup_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnEditFollowup_Click(object sender, EventArgs e)
        {
            int lastFollwUpID = (new ServiceScheduleCallLog()).GetLatestFollowUpIDForSchdeuleCall(this.SelectedScheduleID);
            if (this.SelectedFollowUpID == lastFollwUpID)
            {
                frmFollowUp frm = new frmFollowUp();
                frm.SchdeuleID = this.SelectedScheduleID;
                frm.FollowUpID = this.SelectedFollowUpID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAllSchedules();
                }
            }
            else
            {
                MessageBox.Show("You can Edit the Latest Follow-Up only.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnDeleteSchedule_Click(object sender, EventArgs e)
        {

            try
            {
                string strMessage = string.Format("Are you sure to Remove Scheduled Call ", this.SelectedScheduleID);
                if (MessageBox.Show(strMessage, "CAUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    (new ServiceScheduleCallLog()).DeletedScheduledcallLog(this.SelectedScheduleID,Program.CURR_USER.EmployeeID);
                    PopulateAllSchedules();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduleCallLog::btnDeleteSchedule_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteFollowup_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove\n\npermanently", this.SelectedFollowUpID);
                if (MessageBox.Show(strMessage, "CAUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    (new ServiceScheduleCallLog()).DeletedFollowUp(this.SelectedFollowUpID,Program.CURR_USER.EmployeeID);
                   // PopulateFollowUpsForRecentSchdeules();
                    PopulateAllSchedules();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlScheduleCallLog::btnDeleteFollowup_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
