using libERP.MODELS;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.PMC;
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
    public partial class frmAddEditOnSiteAttendance : Form
    {
        public OnSiteAttendanceModel MODEL { get; set; }
        public frmAddEditOnSiteAttendance()
        {
            InitializeComponent();
        }
        private void frmAddEditOnSiteAttendance_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateEmployees();
                PopulateProjectNames();

                if (MODEL != null)
                {
                    dtAttendanceDate.Value = MODEL.AttendanceDate;
                    dtIntime.Value = MODEL.AttendanceInTime;
                    dtOutTime.Value = MODEL.AttendanceOutTime;

                    cboEmployee.SelectedItem =((List<SelectListItem>)cboEmployee.DataSource).Where(x=>x.ID== MODEL.EmployeeID).FirstOrDefault();
                    cboProject.SelectedItem = ((List<SelectListItem>)cboProject.DataSource).Where(x => x.ID == MODEL.ProjectID).FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditOnSiteAttendance::frmAddEditOnSiteAttendance_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PopulateEmployees()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceEmployee()).GetAllEmployees());
                cboEmployee.DataSource = lst;
                cboEmployee.DisplayMember = "Description";
                cboEmployee.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditOnSiteAttendance::PopulateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateProjectNames()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceProject()).GetAllActiveProjectsForSelection());
                cboProject.DataSource = lst;
                cboProject.DisplayMember = "Description";
                cboProject.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditOnSiteAttendance::PopulateProjectNames", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region VALIDATIONS
        private void cboEmployee_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboEmployee.SelectedItem == null)
                {
                    errorProvider1.SetError(cboEmployee, "Invalid Employee");
                    e.Cancel = true;
                    return;
                }
                if (((SelectListItem)cboEmployee.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboEmployee, "Invalid Employee");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditOnSiteAttendance::cboEmployee_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProject_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboProject.SelectedItem == null)
                {
                    errorProvider1.SetError(cboProject, "Invalid Project");
                    e.Cancel = true;
                    return;
                }
                if (((SelectListItem)cboProject.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboProject, "Invalid Project");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditOnSiteAttendance::cboProject_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        #region VALUE CHANGE
        private void dtAttendanceDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtIntime.Value = new DateTime(dtAttendanceDate.Value.Year, dtAttendanceDate.Value.Month, dtAttendanceDate.Value.Day, dtIntime.Value.Hour, dtIntime.Value.Minute, 0);
                dtOutTime.Value = new DateTime(dtAttendanceDate.Value.Year, dtAttendanceDate.Value.Month, dtAttendanceDate.Value.Day, dtOutTime.Value.Hour, dtOutTime.Value.Minute, 0);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditOnSiteAttendance::dtAttendanceDate_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtOutTime_ValueChanged(object sender, EventArgs e)
        {
            txtDuration.Text = AppCommon.GetDurationBetweenDates(dtOutTime.Value, dtIntime.Value);
        }
        private void dtIntime_ValueChanged(object sender, EventArgs e)
        {
            txtDuration.Text = AppCommon.GetDurationBetweenDates(dtOutTime.Value, dtIntime.Value);
        }
        #endregion
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.MODEL == null) MODEL = new OnSiteAttendanceModel();
                
                MODEL.AttendanceDate = dtAttendanceDate.Value;
                MODEL.EmployeeID = ((SelectListItem)cboEmployee.SelectedItem).ID;
                MODEL.ProjectID = ((SelectListItem)cboProject.SelectedItem).ID;
                EmployeeGeneralInfoModel emp= (new ServiceEmployee()).GetEmployeeGeneralInfo(MODEL.EmployeeID);
                if (emp != null)
                {
                    MODEL.EmployeeCode = emp.EmployeeCode;
                    MODEL.EmployeeName = emp.EmployeeFullName.ToUpper();
                }

                MODEL.AttendanceInTime = dtIntime.Value;
                MODEL.AttendanceOutTime = dtOutTime.Value;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditOnSiteAttendance::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
