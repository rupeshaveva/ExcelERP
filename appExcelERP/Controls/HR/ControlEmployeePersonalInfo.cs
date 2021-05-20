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
using appExcelERP.Forms.HR;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeePersonalInfo : UserControl
    {
        public int SelectedEmployeeID { get; set; }
        public int SelectedEmployeeRelationshipID { get; set; }
        public EmployeePersonalInfoModel MODEL_PersonalInfo = null;

        public ControlEmployeePersonalInfo()
        {
            InitializeComponent();
        }
        public void SetReadOnly()
        {
            try
            {
                btnAddNewFamilyMember.Enabled = btnDeleteFamilyMember.Enabled = btnEditFamilyMember.Enabled=
                   btnUpdatePersonalInfo.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ControlEmployeePersonalInfo_Load(object sender, EventArgs e)
        {
            try
            {
                dtDateOfBirth.MinDate = new DateTime(1, 1, 1);
                dtDateOfBirth.MaxDate = DateTime.Now;

                dtAnniversary.MinDate = new DateTime(1, 1, 1);
                dtAnniversary.MaxDate = DateTime.Now;

                PopulateBloodGroupDropdown();
                PopulateGenderDropdown();
                PopulateMeritalstatusDropdown();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::ControlEmployeePersonalInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ControlEmployeePersonalInfo_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance=(int)(this.Width*.35);
        }
       

        #region  POPULATE DROPDOWNS
        private void PopulateGenderDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllGenders());
                cboGender.DataSource = lst;
                cboGender.DisplayMember = "Description";
                cboGender.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::PopulateGenderDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateMeritalstatusDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllMeritalStatus());
                cboMaritalStatus.DataSource = lst;
                cboMaritalStatus.DisplayMember = "Description";
                cboMaritalStatus.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::PopulateMeritalstatusDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateBloodGroupDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllBloodGroups());
                cboBloodGroup.DataSource = lst;
                cboBloodGroup.DisplayMember = "Description";
                cboBloodGroup.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::PopulateBloodGroupDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region PERSONAL INFO
        public void PopulateEmployeePersonalAndFamilyInfo()
        {
            try
            {
                PopulateEmployeePersonalInfo();
                PopulateEmployeeFamilyGrid();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::PopulateEmployeePersonalAndFamilyInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void SetPersonalInfoControlBlank()
        {
            try
            {
                txtEmployeeBirthPlace.Text = string.Empty;
                dtDateOfBirth.Checked = false;
                cboGender.SelectedItem = ((List<SelectListItem>)cboGender.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                cboBloodGroup.SelectedItem = ((List<SelectListItem>)cboBloodGroup.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                cboMaritalStatus.SelectedItem = ((List<SelectListItem>)cboMaritalStatus.DataSource).Where(x => x.ID == 0).FirstOrDefault();
                dtAnniversary.Checked = false;
                txtLanguage.Text = string.Empty;
                chkSeniorCitizen.Checked = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::SetPersonalInfoControlBlank", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void PopulateEmployeePersonalInfo()
        {
            try
            {
                SetPersonalInfoControlBlank();
                MODEL_PersonalInfo = (new ServiceEmployee()).GetEmployeePersonalInfo(this.SelectedEmployeeID);
                if (MODEL_PersonalInfo != null)
                {
                    if (MODEL_PersonalInfo.DateOfBirth != null) dtDateOfBirth.Value = (DateTime)MODEL_PersonalInfo.DateOfBirth;
                    txtEmployeeBirthPlace.Text = MODEL_PersonalInfo.BirthPlace;
                    if(MODEL_PersonalInfo.GenderInfo.ID>0 )
                        cboGender.SelectedItem = ((List<SelectListItem>)cboGender.DataSource).Where(x => x.ID == MODEL_PersonalInfo.GenderInfo.ID).FirstOrDefault();
                    
                    if (MODEL_PersonalInfo.BloodGroupInfo.ID > 0)
                        cboBloodGroup.SelectedItem = ((List<SelectListItem>)cboBloodGroup.DataSource).Where(x => x.ID == MODEL_PersonalInfo.BloodGroupInfo.ID).FirstOrDefault();
                    if (MODEL_PersonalInfo.MeritalStatusInfo.ID > 0)
                        cboMaritalStatus.SelectedItem = ((List<SelectListItem>)cboMaritalStatus.DataSource).Where(x => x.ID == MODEL_PersonalInfo.MeritalStatusInfo.ID).FirstOrDefault();

                    if (MODEL_PersonalInfo.AnniversaryDate != null) dtAnniversary.Value =(DateTime)MODEL_PersonalInfo.AnniversaryDate;
                    txtLanguage.Text = MODEL_PersonalInfo.Language;
                    chkSeniorCitizen.Checked = MODEL_PersonalInfo.SeniorCitizen;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::PopulateEmployeePersonalInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        private void btnUpdatePersonalInfo_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (this.ValidatePersonalInfoControl())
                {
                    MODEL_PersonalInfo.BirthPlace = txtEmployeeBirthPlace.Text.Trim();
                    MODEL_PersonalInfo.Language = txtLanguage.Text.Trim();
                    MODEL_PersonalInfo.SeniorCitizen = chkSeniorCitizen.Checked;
                    
                    if (dtDateOfBirth.Checked)
                        MODEL_PersonalInfo.DateOfBirth = dtDateOfBirth.Value;
                    else
                        MODEL_PersonalInfo.DateOfBirth = null;

                    if (dtAnniversary.Checked)
                        MODEL_PersonalInfo.AnniversaryDate = dtAnniversary.Value;
                    else
                        MODEL_PersonalInfo.AnniversaryDate = null;

                    MODEL_PersonalInfo.GenderInfo.ID = ((SelectListItem)cboGender.SelectedItem).ID;
                    MODEL_PersonalInfo.BloodGroupInfo.ID = ((SelectListItem)cboBloodGroup.SelectedItem).ID;
                    MODEL_PersonalInfo.MeritalStatusInfo.ID = ((SelectListItem)cboMaritalStatus.SelectedItem).ID;
                    
                    bool res=(new ServiceEmployee()).SetEmployeePersonalInfo(MODEL_PersonalInfo);
                    if (res)
                    {
                        string strMessage = string.Format("Personal Information of {0} Updated", MODEL_PersonalInfo.EmployeeFullName);
                        MessageBox.Show(strMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::btnUpdatePersonalInfo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ValidatePersonalInfoControl()
        {
            bool result = true;
            try
            {
                if (!dtDateOfBirth.Checked)
                {
                    errorProvider1.SetError(lblDateOfBirth, " Date of birthMandatory");
                    result = result && false;
                }
                //if (txtEmployeeBirthPlace.Text.Trim()==string.Empty)
                //{
                //    errorProvider1.SetError(lblBirthPlace, "Birth place mandatory");
                //    result = result && false;
                //}
                if (((SelectListItem)cboGender.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblGender, " Gender mandatory");
                    result = result && false;
                }
                if (((SelectListItem)cboBloodGroup.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblBloodGroup, " Blood group mandatory");
                    result = result && false;
                }
                if (((SelectListItem)cboMaritalStatus.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(lblMaritalStatus, " marital status mandatory");
                    result = result && false;
                }
                if (dtAnniversary.Checked)
                {
                    if (dtAnniversary.Value <= dtDateOfBirth.Value)
                    {
                        errorProvider1.SetError(lblAnniversaryDate, " Anniversary newer less than Birth Date");
                        result = result && false;
                    }
                }
                if (txtLanguage.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(lblLanguage, "Language mandatory");
                    result = result && false;
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::ValidatePersonalInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion
      
        #region EMPLOYEE RELATIVES & FAMILY
        private void PopulateEmployeeFamilyGrid()
        {
            try
            {
              
                gridEmployeeRelatives.DataSource = (new ServiceEmployee()).GetAllRelativesOfEmployee(this.SelectedEmployeeID);
               
                foreach (DataGridViewColumn col in gridEmployeeRelatives.Columns)
                {
                    col.Visible = false;
                }
                //gridEmployeeRelatives.ColumnHeadersHeight = 35;
                gridEmployeeRelatives.Columns["RelativeName"].Visible = true;
                //gridEmployeeRelatives.Columns["RelativeName"].HeaderText = "Relative Name";
               // gridEmployeeRelatives.Columns["RelativeName"].Width = 250;

                gridEmployeeRelatives.Columns["RelativeDOB"].Visible = true;
                //gridEmployeeRelatives.Columns["RelativeDOB"].HeaderText = "Relative DOB";
               // gridEmployeeRelatives.Columns["RelativeDOB"].Width = 250;

                gridEmployeeRelatives.Columns["Remarks"].Visible = true;
                //gridEmployeeRelatives.Columns["Remarks"].HeaderText = "Remarks";
              //  gridEmployeeRelatives.Columns["Remarks"].Width = 250;

                gridEmployeeRelatives.Columns["RelationshipName"].Visible = true;
                //gridEmployeeRelatives.Columns["RelationshipName"].HeaderText = "RelationshipName";
              //  gridEmployeeRelatives.Columns["RelationshipName"].Width = 250;





            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::PopulateEmployeeFamilyInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNewFamilyMember_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditEmployeeRelation FRM = new frmAddEditEmployeeRelation();
                FRM.SelectedEmployeeID = this.SelectedEmployeeID;
                if (FRM.ShowDialog() == DialogResult.OK)
                {
                    PopulateEmployeeFamilyGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::btnAddNewFamilyMember_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditFamilyMember_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditEmployeeRelation FRM = new frmAddEditEmployeeRelation(this.SelectedEmployeeRelationshipID);
                FRM.SelectedEmployeeID = this.SelectedEmployeeID;
                if (FRM.ShowDialog() == DialogResult.OK)
                {
                    PopulateEmployeeFamilyGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::btnEditFamilyMember_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridEmployeeRelatives_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedEmployeeRelationshipID = (int)gridEmployeeRelatives.Rows[e.RowIndex].Cells["EmplooyeeRelativeID"].Value;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceEmployee::gridEmployeeRelatives_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteFamilyMember_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Are you sure to Delete selected Relation Permanently";
                DialogResult res = MessageBox.Show(msg, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    (new ServiceEmployee()).DeleteEmployeeRelative(this.SelectedEmployeeRelationshipID);
                    PopulateEmployeeFamilyGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeePersonalInfo::btnDeleteFamilyMember_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    PopulateEmployeeFamilyGrid();
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
