using libERP;
using libERP.MODELS;
using libERP.SERVICES;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.COMMON;
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
    public partial class frmAddEditEmployee : Form
    {
        private ServiceUOW _UNIT = null;

        public int EmployeeID { get; set; }
        public int SelectedEmployeeID { get; set; }
        public int UserID { get; set; }

        public frmAddEditEmployee()
        {
            InitializeComponent();
        }
        public frmAddEditEmployee(int ID)
        {
            InitializeComponent();
            this.EmployeeID = ID;
        }
        private void frmAddEditEmployee_Load(object sender, EventArgs e)
        {
            try
            {

                PopulateDepartmentDropDown();
                PopulateDesignationDropDown();
                PopulateEmployeeBossDropDown();
                PopulateEmploymentTypeDropDown();

                if (this.EmployeeID == 0)
                {
                    //blank all text fields 

                    txtEmployeeCode.Text = (new ServiceEmployee()).GenerateNewEmployeeCode(Program.CURR_USER.FinYearID, Program.CURR_USER.BranchID, Program.CURR_USER.CompanyID);
                    txtEmployeeName.Text =
                    txtMobileNo.Text =
                   // txtPassword.Text =
                  //  txtUserName.Text =
                    txtEmail.Text = String.Empty;
                    chkIsActive.Checked = true;
                    chkHasResigned.Checked = false;
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
                MessageBox.Show(errMessage, "frmAddEditEmployee::frmAddEditEmployee_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ScatterData()
        {
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                TBL_MP_Master_Employee model = _service.GetEmployeeDbRecordByID(this.EmployeeID);
                if (model != null)
                {
                    txtEmployeeCode.Text = model.EmployeeCode;
                    txtEmployeeName.Text = model.EmployeeName;
                    txtEmail.Text = model.EmailAddress;
                    txtMobileNo.Text = model.PhoneNo1;
                    cboDepartment.SelectedItem = ((List<SelectListItem>)cboDepartment.DataSource).Where(x => x.ID == model.FK_DepartmentId).FirstOrDefault();
                    cboDesignation.SelectedItem = ((List<SelectListItem>)cboDesignation.DataSource).Where(x => x.ID == model.FK_DesignationId).FirstOrDefault();
                    cboEmploymentType.SelectedItem = ((List<SelectListItem>)cboEmploymentType.DataSource).Where(x => x.ID == model.FK_EmploymentTypeID).FirstOrDefault();

                    chkIsActive.Checked = (bool)model.isActive;
                    chkHasResigned.Checked = (bool)model.IsResigned;
                    //     txtUserName.Text = model.FK_LoginID;
                    //txtPassword.Text = model.FK_LoginPassword;
                    //txtUserName.Text = model.TBL_User_Master.
                    cboEmployeeBoss.SelectedItem = ((List<SelectListItem>)cboEmployeeBoss.DataSource).Where(x => x.ID == model.FK_BossID).FirstOrDefault();

                    TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(EmployeeID);
                    this.Text = string.Format("{0} ({1}) - Add Relationship", emp.EmployeeName, emp.EmployeeCode);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Employee model = null;
            ServiceEmployee serviceEmployee = new ServiceEmployee();
            try
            {
                if (!this.ValidateChildren()) return;
                if (this.EmployeeID == 0)
                    model = new TBL_MP_Master_Employee();
                else
                    model = serviceEmployee.GetEmployeeDbRecordByID(this.EmployeeID);

                #region GATHER DATA INTO MODEL FROM VIEW
                model.EmployeeCode = txtEmployeeCode.Text;
                model.EmployeeName = txtEmployeeName.Text;
                model.EmailAddress = txtEmail.Text;
                model.PhoneNo1 = txtMobileNo.Text;
                model.FK_DepartmentId = ((SelectListItem)cboDepartment.SelectedItem).ID;
                model.FK_DesignationId = ((SelectListItem)cboDesignation.SelectedItem).ID;
                model.FK_EmploymentTypeID = ((SelectListItem)cboEmploymentType.SelectedItem).ID;
                model.isActive = chkIsActive.Checked;
                model.IsResigned = chkHasResigned.Checked;

                model.FK_BossID= ((SelectListItem)cboEmployeeBoss.SelectedItem).ID;

                #endregion
                if (this.EmployeeID == 0)
                {
                    //CREATE EMPLOYEE
                    model.FK_CompanyID = Program.CURR_USER.CompanyID;
                    model.FK_YearID = Program.CURR_USER.FinYearID;
                    model.FK_BranchID = Program.CURR_USER.BranchID;
                    model.CreatedBy = Program.CURR_USER.EmployeeID;
                    model.CreatedDateTime = AppCommon.GetServerDateTime();
                    this.EmployeeID = serviceEmployee.AddNewEmployee(model);
                }
                else
                {
                    model.ModifiedBy = Program.CURR_USER.EmployeeID;
                    model.ModifiedDateTime = AppCommon.GetServerDateTime();
                    serviceEmployee.UpdateEmployee(model);
                }

                
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;
        }

       #region POPULATE DROPDOWNS
        private void PopulateDepartmentDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllDepartments());
                cboDepartment.DataSource = LST;
                cboDepartment.DisplayMember = "Description";
                cboDepartment.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::PopulateDepartmentDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateDesignationDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllDesignation());
                cboDesignation.DataSource = LST;
                cboDesignation.DisplayMember = "Description";
                cboDesignation.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::PopulateDesignationDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateEmployeeBossDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceEmployee()).GetAllActiveEmployees());
                cboEmployeeBoss.DataSource = LST;
                cboEmployeeBoss.DisplayMember = "Description";
                cboEmployeeBoss.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::PopulateEmployeeBossDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateEmploymentTypeDropDown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceMASTERS()).GetAllEmploymentType());
                cboEmploymentType.DataSource = LST;
                cboEmploymentType.DisplayMember = "Description";
                cboEmploymentType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::PopulateEmploymentTypeDropDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region VALIDATION
        private void txtEmployeeCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtEmployeeCode.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtEmployeeCode, "Employee code is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::txtEmployeeCode_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtEmployeeName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtEmployeeName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtEmployeeName, "Employee Name is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::txtEmployeeName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtEmail, "Email is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::txtEmail_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtMobileNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtMobileNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtMobileNo, "Mobile No. is mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee::txtMobileNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboDepartment_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboDepartment.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboDepartment, "Invalid Department");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee ::cboDepartment_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboDesignation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboDesignation.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboDesignation, "Invalid Designation");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee ::cboDesignation_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void txtUserName_Validating(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        if (txtUserName.Text.Trim() == string.Empty)
        //        {
        //            errorProvider1.SetError(txtUserName, "User Name is mandatory");
        //            e.Cancel = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = ex.Message;
        //        if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
        //        MessageBox.Show(errMessage, "frmAddEditEmployee::txtUserName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void txtPassword_Validating(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        if (txtPassword.Text.Trim() == string.Empty)
        //        {
        //            errorProvider1.SetError(txtPassword, "Password is mandatory");
        //            e.Cancel = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = ex.Message;
        //        if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
        //        MessageBox.Show(errMessage, "frmAddEditEmployee::txtPassword_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void cboEmployeeBoss_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboEmployeeBoss.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboEmployeeBoss, "mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee ::cboEmployeeBoss_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboEmploymentType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboEmploymentType.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboEmploymentType, "Invalid Employment Type");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployee ::cboEmploymentType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    

        #endregion

     
}
