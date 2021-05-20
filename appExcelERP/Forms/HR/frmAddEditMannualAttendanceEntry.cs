using libERP;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.SERVICES.MASTER;
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
    public partial class frmAddEditMannualAttendanceEntry : Form
    {
        public int EmployeeID { get; set; }
        public int AttendanceID { get; set; }

        private bool IsOnSiteEmployee = false;

        public frmAddEditMannualAttendanceEntry()
        {
            InitializeComponent();
        }
        public frmAddEditMannualAttendanceEntry(int id)
        {
            InitializeComponent();
            AttendanceID = id;
        }

        private void frmAddEditMannualAttendanceEntry_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateEmployees();
                PopulateProjectNames();
                if(this.AttendanceID ==0)
                {
                    dtAttendanceDate.Value = AppCommon.GetServerDateTime();
                    cboEmployee.SelectedIndex = 0;
                    cboProject.SelectedIndex = 0;
                    txtDuration.Text = string.Empty;
                }
                else
                {
                    TBL_MP_HR_ManualAttendance_Master model = (new ServiceAttendance()).GetAttendanceInfoDbRecordByID(this.AttendanceID);
                    if(model!=null)
                    {
                        dtAttendanceDate.Value = model.AttendDate;
                        cboEmployee.SelectedItem = ((List<SelectListItem>)cboEmployee.DataSource).Where(x => x.ID == model.FK_EmployeeID).FirstOrDefault();
                        cboProject.SelectedItem = ((List<SelectListItem>)cboProject.DataSource).Where(x => x.ID == model.FK_CostCenterId).FirstOrDefault();
                        dtIntime.Value = model.AttendInTime;
                        dtOutTime.Value = model.AttendOutTime;
                       
                        txtDuration.Text = model.Duration.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::frmAddEditMannualAttendanceEntry_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::PopulateEmployees", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::PopulateProjectNames", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_HR_ManualAttendance_Master model = null;

            ServiceAttendance serviceAttendance = new ServiceAttendance();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.AttendanceID == 0)
                    model = new TBL_MP_HR_ManualAttendance_Master();
                else
                    model = serviceAttendance.GetAttendanceInfoDbRecordByID(this.AttendanceID);


                #region GATHER DATA INTO MODEL FROM VIEW

                model.AttendDate = dtAttendanceDate.Value;
                model.FK_EmployeeID = this.EmployeeID;
                if (IsOnSiteEmployee)
                    model.FK_CostCenterId = ((SelectListItem)cboProject.SelectedItem).ID;
                else
                    model.FK_CostCenterId = null;
                model.AttendInTime = dtIntime.Value;
                model.AttendOutTime = dtOutTime.Value;
                model.Duration = txtDuration.Text;
                model.IsActive = true;
                
                #endregion
                if (this.AttendanceID == 0)
                {
                    this.AttendanceID = serviceAttendance.AddNewManualAttendance(model);
                }
                else
                {
                    serviceAttendance.UpdateMannualAttendance(model);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void cboEmployee_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                lblEmpCategoryInfo.Text = string.Empty;
                this.EmployeeID = 0;
                if (cboEmployee.SelectedItem != null)
                    this.EmployeeID = ((SelectListItem)cboEmployee.SelectedItem).ID;
                this.IsOnSiteEmployee = ServiceEmployee.IsOnSiteEmployee(this.EmployeeID);
                if (IsOnSiteEmployee == true)
                {
                    lblEmpCategoryInfo.Text = "Onsite Employee";
                    //cboProject.Enabled = true;
                }
                else
                {
                    //cboProject.Enabled = false;
                    lblEmpCategoryInfo.Text = "Office Employee";
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::cboEmployee_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region VALIDATION
        private void cboEmployee_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboEmployee.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboEmployee, "Employee is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::cboEmployee_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboProject_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (IsOnSiteEmployee == true)
                {
                    int selID = ((SelectListItem)cboProject.SelectedItem).ID;
                    if (selID == 0)
                    {
                        errorProvider1.SetError(cboProject, " Project is Mandatory");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::cboProject_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

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
                MessageBox.Show(errMessage, "frmAddEditMannualAttendanceEntry::dtAttendanceDate_ValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtOutTime_ValueChanged(object sender, EventArgs e)
        {
            txtDuration.Text = AppCommon.GetDurationBetweenDates(dtOutTime.Value,dtIntime.Value);
        }
        private void dtIntime_ValueChanged(object sender, EventArgs e)
        {
            txtDuration.Text = AppCommon.GetDurationBetweenDates(dtOutTime.Value, dtIntime.Value);
        }


    }
}
