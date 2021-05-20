using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using libERP.MODELS.COMMON;
using System.ComponentModel.DataAnnotations;
using libERP.SERVICES.COMMON;
using System.IO;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeGeneralInfo : UserControl
    {
        public DB_FORM_IDs SelectedTAB { get; set; }
        public int SelectedEmployeeID = 0;
        public EmployeeGeneralInfoModel MODEL_GeneralInfo { get; set; }
        public EmployeeResignationInfoModel MODEL_RegsignationInfo { get; set; }

        public ControlEmployeeGeneralInfo()
        {
            InitializeComponent();
        }
        private void ControlEmployeeGeneralInfo_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateEmployeeCategories();
                PopulateDepartments();
                PopulateDesignations();
                PopulateBranches();
                PopulateLocations();
                PopulateEmployeesBoss();

                WhosWhoModel whoseWho = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.EMPLOYEE_GENERAL_INFO).FirstOrDefault();
                if (whoseWho != null)
                {
                     btnUpdateGeneralInfo.Visible =btnUpdateResignInfo.Visible= btnUploadPicture.Visible = whoseWho.CanModify;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::ControlEmployeeGeneralInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void ControlEmployeeGeneralInfo_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance = (int)(this.Width * .65);
        }
        public void PopulateEmployeeGeneralAndResignationInfo()
        {
            try
            {
                PopulateEmployeeGeneralInfo();
                PopulateEmployeeResignationInfo();
                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateEmployeeGeneralAndResignationInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void SetReadOnly()
        {
            try
            {
                btnUpdateGeneralInfo.Enabled = btnUpdateResignInfo.Enabled = btnUploadPicture.Enabled  = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region POPULATE DROPDOWNS
        private void PopulateEmployeeCategories()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() {ID=0, Description="(Select)"});
                lst.AddRange((new ServiceMASTERS()).GetAllEmployeeCategories());
                cboCategory.DataSource = lst;
                cboCategory.DisplayMember = "Description";
                cboCategory.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateEmployeeCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateDepartments()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllDepartments());
                cboDepartment.DataSource = lst;
                cboDepartment.DisplayMember = "Description";
                cboDepartment.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateDepartments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateDesignations()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllDesignation());
                cboDesignation.DataSource = lst;
                cboDesignation.DisplayMember = "Description";
                cboDesignation.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateDesignations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBranches()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllBraches());
                cboBranch.DataSource = lst;
                cboBranch.DisplayMember = "Description";
                cboBranch.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateBranches", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateLocations()
        {
            try
            {
                int indiaID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.DefaultCountryID).FirstOrDefault().DEFAULT_VALUE;
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllCitiesWithStateNamesForCountry(indiaID));
                cboJoiningLocation.DataSource = lst;
                cboJoiningLocation.DisplayMember = "Description";
                cboJoiningLocation.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateLocations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateEmployeesBoss()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceEmployee()).GetAllActiveEmployees());
                cboBoss.DataSource = lst;
                cboBoss.DisplayMember = "Description";
                cboBoss.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateEmployeesBoss", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Employee General Info
        private void PopulateEmployeeGeneralInfo()
        {
            this.Cursor = Cursors.WaitCursor;
            Application.UseWaitCursor = true;
            try
            {
                MODEL_GeneralInfo = (new ServiceEmployee()).GetEmployeeGeneralInfo(this.SelectedEmployeeID);
                if (MODEL_GeneralInfo != null)
                {
                    pictureBoxItemImage.Image = null;
                    txtEmployeeCode.Text = MODEL_GeneralInfo.EmployeeCode;
                    txtEmployeeID.Text = MODEL_GeneralInfo.EmployeeID.ToString();
                    txtEmployeeName.Text = MODEL_GeneralInfo.EmployeeFullName;
                    txtEmail.Text = MODEL_GeneralInfo.EmployeeEmailAddress;
                  txtOfficeEmailAddr.Text = MODEL_GeneralInfo.OfficialEmailAddress; //office email addr
                   txtOfficePhoneNo.Text = MODEL_GeneralInfo.OfficialPhoneNo;        //office phone no
                    txtPhoneNo.Text = MODEL_GeneralInfo.PhoneNo1;
                    txtAlternatePhoneNo.Text = MODEL_GeneralInfo.AltPhoneNo;

                    if (MODEL_GeneralInfo.ImageFileName != null)
                    {
                        string filePath = string.Format("{0}{1}", AppCommon.GetEmployeeImagePath(), MODEL_GeneralInfo.ImageFileName);
                        if (File.Exists(filePath))
                        {
                            byte[] array = File.ReadAllBytes(filePath);
                            Bitmap image;
                            using (MemoryStream stream = new MemoryStream(array))
                            {
                                image = new Bitmap(stream);
                            }
                            pictureBoxItemImage.Image = image;
                        }
                    }

                    cboCategory.SelectedItem = ((List<SelectListItem>)cboCategory.DataSource).Where(x => x.ID == MODEL_GeneralInfo.CategoryInfo.ID).FirstOrDefault();
                    cboDepartment.SelectedItem = ((List<SelectListItem>)cboDepartment.DataSource).Where(x => x.ID == MODEL_GeneralInfo.DepartmentInfo.ID).FirstOrDefault();
                    cboDesignation.SelectedItem = ((List<SelectListItem>)cboDesignation.DataSource).Where(x => x.ID == MODEL_GeneralInfo.DesignationInfo.ID).FirstOrDefault();
                    cboBranch.SelectedItem = ((List<SelectListItem>)cboBranch.DataSource).Where(x => x.ID == MODEL_GeneralInfo.EmployeeBranchInfo.ID).FirstOrDefault();
                    cboBoss.SelectedItem = ((List<SelectListItem>)cboBoss.DataSource).Where(x => x.ID == MODEL_GeneralInfo.EmployeeBossInfo.ID).FirstOrDefault();
                    if (MODEL_GeneralInfo.DateOfJoining != null)
                    {
                        dtJoiningDate.Value = MODEL_GeneralInfo.DateOfJoining.Value;
                        dtJoiningDate.Checked = true;
                    }
                    else
                    {
                        dtJoiningDate.Checked = false;
                    }

                    if (MODEL_GeneralInfo.ConfirmationDate != null)
                    {
                        dtConfirmationDate.Value = MODEL_GeneralInfo.ConfirmationDate.Value;
                        dtConfirmationDate.Checked = true;
                    }
                    else
                    {
                        dtConfirmationDate.Checked = false;
                    }
                    if (MODEL_GeneralInfo.DateOfAppointment != null)
                    {
                        dtAppointmentDate.Value = MODEL_GeneralInfo.DateOfAppointment.Value;
                        dtAppointmentDate.Checked = true;
                    }
                    else
                    {
                        dtAppointmentDate.Checked = false;
                    }

                    
                    txtNoticePeriods.Text = MODEL_GeneralInfo.NoticePeriod.ToString();
                    txtProbationPeriods.Text = MODEL_GeneralInfo.ProbationPeriod.ToString();
                    txtResidentialAddress.Text = MODEL_GeneralInfo.ResidentialAddress;
                    txtPermanentAddress.Text = MODEL_GeneralInfo.PermanentAddress;

                    for (int x = 0; x < checkListWeekOffs.Items.Count; x++)
                    {
                        checkListWeekOffs.SetItemChecked(x, false);
                    }
                    string[] arrWeekOffs = MODEL_GeneralInfo.WeekOffDays.Split(',');
                    for (int i = 0; i <= arrWeekOffs.GetUpperBound(0); i++)
                    {
                        for (int x = 0; x < checkListWeekOffs.Items.Count; x++)
                        {
                            if (checkListWeekOffs.Items[x].ToString() == arrWeekOffs[i])
                                checkListWeekOffs.SetItemChecked(x, true);
                        }
                    }
                    cboJoiningLocation.SelectedItem= ((List<SelectListItem>)cboJoiningLocation.DataSource).Where(x => x.ID == MODEL_GeneralInfo.JoiningLocationCityID).FirstOrDefault();
                }
                else
                {
                    txtEmployeeCode.Text = txtEmployeeID.Text = txtEmployeeName.Text = txtEmail.Text = 
                    txtPhoneNo.Text =  txtAlternatePhoneNo.Text = string.Empty;
                   txtOfficePhoneNo.Text = txtOfficePhoneNo.Text = string.Empty;
                 txtOfficeEmailAddr.Text = txtOfficeEmailAddr.Text = string.Empty;
                    cboCategory.SelectedItem = ((List<SelectListItem>)cboCategory.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboDepartment.SelectedItem = ((List<SelectListItem>)cboDepartment.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboDesignation.SelectedItem = ((List<SelectListItem>)cboDesignation.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboBranch.SelectedItem = ((List<SelectListItem>)cboBranch.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboBoss.SelectedItem = ((List<SelectListItem>)cboBoss.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    cboJoiningLocation.SelectedItem = ((List<SelectListItem>)cboJoiningLocation.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                    dtJoiningDate.Value =  dtConfirmationDate.Value =  dtAppointmentDate.Value = new DateTime(1900,1,1);
                    txtNoticePeriods.Text = txtProbationPeriods.Text = txtResidentialAddress.Text = txtPermanentAddress.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateEmployeeGeneralInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default   ;
            Application.UseWaitCursor = false;
        }
        private bool IsGeneralInfoControlsValid()
        {
            errorProvider1.Clear();
            bool result = true;
            try
            {
                if (txtEmployeeName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblEmployeeName, "Employee Name Mandatory");
                    result= result && false;
                }
                if (txtEmail.Text.Trim() != string.Empty)
                {
                    if (!new EmailAddressAttribute().IsValid(txtEmail.Text))
                    {
                        errorProvider1.SetError(txtEmail, "Invalid Email Address entered.");
                        result = result && false;
                    }
                }
                if (txtPhoneNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblPhoneNo, "Contact No. Mandatory");
                    result = result && false;
                }
                if (!(txtPhoneNo.Text.Trim().All(char.IsDigit) && txtPhoneNo.Text.Trim().Length == 10))
                {
                    errorProvider1.SetError(lblPhoneNo, "Enter Digit Only[0-9]");
                    result = result && false;
                }
                if (txtAlternatePhoneNo.Text.Trim() != string.Empty)
                {
                    if (!(txtAlternatePhoneNo.Text.All(char.IsDigit) && txtAlternatePhoneNo.Text.Length == 10))
                    {
                        errorProvider1.SetError(lblAltPhoneNo, "Enter Digit Only[0-9]");
                        result = result && false;
                    }
                }
                if (((SelectListItem)cboCategory.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblCategory, " Category mandatory");
                    result = result && false;
                }
                if (((SelectListItem)cboDepartment.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblDepartment, "Department mandatory");
                    result = result && false;
                }
                if (((SelectListItem)cboDesignation.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblDesignation, "designation mandatory");
                    result = result && false;
                }
                if (((SelectListItem)cboBranch.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblBranch, " Branch mandatory");
                    result = result && false;
                }
                if (((SelectListItem)cboBoss.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblemployeeBoss, " Boss name mandatory");
                    result = result && false;
                }
                if (txtNoticePeriods.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblNoticePeriod, "Notice Period Mandatory");
                    result = result && false;
                }
                if (txtProbationPeriods.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblProbationPeriod, "Probation Period Mandatory");
                    result = result && false;
                }
                if (((SelectListItem)cboJoiningLocation.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblJoiningLocation, "Joining Location mandatory");
                    result = result && false;
                }
                if (txtResidentialAddress.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblResidentialAddress, "Residential address Mandatory");
                    result = result && false;
                }
                if (txtPermanentAddress.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblPermanentAddress, "permanent address Mandatory");
                    result = result && false;
                }
              /* 
               if (txtOfficePhoneNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblOfficePhoneNo, "Office Phone No Mandatory");
                    result = result && false;
                }
                if (txtOfficeEmailAddr.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblOfficeEmailAddress, "Office Mail address Mandatory");
                    result = result && false;
                }
                */
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::IsGeneralInfoControlsValid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        private void  btnUpdateGeneralInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsGeneralInfoControlsValid()) return;
                
                MODEL_GeneralInfo.EmployeeFullName = txtEmployeeName.Text.Trim();
                MODEL_GeneralInfo.EmployeeEmailAddress = txtEmail.Text.Trim();
                MODEL_GeneralInfo.PhoneNo1 = txtPhoneNo.Text.Trim();
                MODEL_GeneralInfo.AltPhoneNo = txtAlternatePhoneNo.Text.Trim();
                MODEL_GeneralInfo.OfficialPhoneNo = txtOfficePhoneNo.Text.Trim();           //office phone no
               MODEL_GeneralInfo.OfficialEmailAddress = txtOfficeEmailAddr.Text.Trim();     //office email address
                MODEL_GeneralInfo.CategoryInfo.ID = ((SelectListItem)cboCategory.SelectedItem).ID;
                MODEL_GeneralInfo.DepartmentInfo.ID = ((SelectListItem)cboDepartment.SelectedItem).ID;
                MODEL_GeneralInfo.DesignationInfo.ID = ((SelectListItem)cboDesignation.SelectedItem).ID;
                MODEL_GeneralInfo.EmployeeBranchInfo.ID = ((SelectListItem)cboBranch.SelectedItem).ID;
                MODEL_GeneralInfo.EmployeeBossInfo.ID = ((SelectListItem)cboBoss.SelectedItem).ID;
                if (dtJoiningDate.Checked)
                    MODEL_GeneralInfo.DateOfJoining = dtJoiningDate.Value;
                else
                    MODEL_GeneralInfo.DateOfJoining = null;
                if(dtConfirmationDate.Checked)
                    MODEL_GeneralInfo.ConfirmationDate = dtConfirmationDate.Value;
                else
                    MODEL_GeneralInfo.ConfirmationDate = null;
                if(dtAppointmentDate.Checked)
                    MODEL_GeneralInfo.DateOfAppointment = dtAppointmentDate.Value;
                else
                    MODEL_GeneralInfo.DateOfAppointment = null;

                MODEL_GeneralInfo.NoticePeriod = float.Parse(txtNoticePeriods.Text.Trim());
                MODEL_GeneralInfo.ProbationPeriod = float.Parse(txtProbationPeriods.Text.Trim());
                MODEL_GeneralInfo.JoiningLocationCityID = ((SelectListItem)cboJoiningLocation.SelectedItem).ID;
                MODEL_GeneralInfo.ResidentialAddress = txtResidentialAddress.Text.Trim();
                MODEL_GeneralInfo.PermanentAddress = txtPermanentAddress.Text.Trim();
                // week-off
                string selWeekOffs = string.Empty;
                if (checkListWeekOffs.CheckedItems.Count != 0)
                {
                    for (int x = 0; x < checkListWeekOffs.CheckedItems.Count; x++)
                    {
                        selWeekOffs+= checkListWeekOffs.CheckedItems[x].ToString() + ",";
                    }
                    selWeekOffs = selWeekOffs.TrimEnd(',');
                }
                MODEL_GeneralInfo.WeekOffDays = selWeekOffs;

                bool result= (new ServiceEmployee()).SetEmployeeGeneralInfo(MODEL_GeneralInfo);
                string strMessage = string.Format("Geneal Information of {0} Updated", MODEL_GeneralInfo.EmployeeFullName);
                if (result)
                {
                    MessageBox.Show(strMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::btnUpdateGeneralInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region Employee Resignation Info
        private void PopulateEmployeeResignationInfo()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                MODEL_RegsignationInfo = (new ServiceEmployee()).GetEmployeeResignationInfo(this.SelectedEmployeeID);
                if (MODEL_RegsignationInfo != null)
                {
                    chkResigned.Checked = MODEL_RegsignationInfo.IsResigned;

                    if (MODEL_RegsignationInfo.ResignedDate != null)
                    {
                        dtResigningDate.Value = (DateTime)MODEL_RegsignationInfo.ResignedDate;
                        dtResigningDate.Checked = true;
                    }
                    else
                        dtResigningDate.Checked = false;

                    if (MODEL_RegsignationInfo.LeavingDate != null)
                    {
                        dtLeavingDate.Value = (DateTime)MODEL_RegsignationInfo.LeavingDate;
                        dtLeavingDate.Checked = true;
                    }
                    else
                        dtLeavingDate.Checked = false;

                    txtLeavingReason.Text = MODEL_RegsignationInfo.ReasonForResigning;
                    chkHoldSalary.Checked = MODEL_RegsignationInfo.HoldSalary;
                    

                }
                else
                {
                    dtResigningDate.Value = dtLeavingDate.Value = new DateTime(1900, 1, 1);
                    txtLeavingReason.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::PopulateEmployeeResignationInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnUpdateResignInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsResignationInfoControlsValid()) return;
                MODEL_RegsignationInfo.HoldSalary = chkHoldSalary.Checked;
                MODEL_RegsignationInfo.IsResigned = chkResigned.Checked;

                if (dtResigningDate.Checked)
                    MODEL_RegsignationInfo.ResignedDate = dtResigningDate.Value;
                else
                    MODEL_RegsignationInfo.ResignedDate = null;
                if (dtLeavingDate.Checked)
                    MODEL_RegsignationInfo.LeavingDate = dtLeavingDate.Value;
                else
                    MODEL_RegsignationInfo.LeavingDate = null;
                
                MODEL_RegsignationInfo.ReasonForResigning = txtLeavingReason.Text.Trim();
                

                bool result=(new ServiceEmployee()).SetEmployeeResignationInfo(MODEL_RegsignationInfo);
                string strMessage = string.Format("Resignation Information of {0} Updated", MODEL_RegsignationInfo.EmployeeFullName);
                if (result)
                {
                    MessageBox.Show(strMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::btnUpdateGeneralInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public bool IsResignationInfoControlsValid()
        {
            errorProvider1.Clear();
            bool result = false;
            try
            {
                if (chkResigned.Checked == true)
                {
                    if (!dtResigningDate.Checked)
                    {
                        errorProvider1.SetError(lblResignationDate, "Mandatory");
                        return result;
                    }
                    if (!dtLeavingDate.Checked)
                    {
                        errorProvider1.SetError(lblLeavingDate, "Mandatory");
                        return result;
                    }
                    //if (txtLeavingReason.Text.Trim() == string.Empty)
                    //{
                    //    errorProvider1.SetError(lblleavingReason, "Leaving Reason Mandatory");
                    //    return result;
                    //}
                }
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::IsResignationInfoControlsValid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        private void chkResigned_Click(object sender, EventArgs e)
        {
            try
            {
                dtLeavingDate.Enabled = txtLeavingReason.Enabled = dtResigningDate.Enabled = chkHoldSalary.Enabled = chkResigned.Checked;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::chkResigned_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void btnUploadPicture_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    (new ServiceEmployee()).UpdateEmployeeImageFileName(this.SelectedEmployeeID, openFileDialog.FileName);
                    PopulateEmployeeGeneralInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ControlEmployeeGeneralInfo::btnUploadPicture_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
