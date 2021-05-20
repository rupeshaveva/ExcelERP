using libERP;
using libERP.MODELS;
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
    public partial class frmAddEditMedicalInfo : Form
    {
        public int EmployeeID { get; set; }
        public int EmployeeMedicalID { get; set; }
        public int selectedEmployeeMedicalID { get; set; }

        public frmAddEditMedicalInfo()
        {
            InitializeComponent();
        }
        public frmAddEditMedicalInfo(int ID)
        {
            InitializeComponent();
            EmployeeMedicalID = ID;
        }

        private void frmAddEditMedicalInfo_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceEmployee _service = new ServiceEmployee();
                PopulateRelationshipDropdown();
                if (EmployeeMedicalID == 0)
                {
                    txtMedicalName.Text = txtCardNo.Text = txtCardType.Text = txtCompanyName.Text = txtRemark.Text = String.Empty;
                    dtExpieryDate.Checked = false;
                    chkIsActive.Checked = true;

                    if (this.selectedEmployeeMedicalID != 0)
                    {
                        TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(selectedEmployeeMedicalID);
                        this.Text = string.Format("{0} ({1}) - Add Medical Info", emp.EmployeeName, emp.EmployeeCode);
                    }
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
                MessageBox.Show(errMessage, "frmAddEditMedicalInfo::frmAddEditMedicalInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ScatterData()
        {
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                TBL_MP_Master_Employee_MedicalDetail obj = (new ServiceEmployee()).GetEmployeeMedicalInfoDbRecord(this.EmployeeMedicalID);
                if (obj != null)
                {
                    //populate all textboxes,datepickers from obj 
                    txtMedicalName.Text = obj.MedicalName;
                    cboRelation.SelectedItem = ((List<SelectListItem>)cboRelation.DataSource).Where(x => x.ID == obj.FK_UL_RelationID).FirstOrDefault();
                    txtCardNo.Text = obj.CardNo;
                    txtCardType.Text = obj.CardType;
                    txtCompanyName.Text = obj.CompanyName;
                    txtRemark.Text = obj.Remark;
                    chkIsActive.Checked = obj.IsActive;
                    dtIssueDate.Value = obj.IssueDate;
                    dtExpieryDate.Value = obj.ExpiryDate;
                   
                }
                    TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(obj.fk_EmployeeId);
                    this.Text = string.Format("{0} ({1}) - Update Medical Info", emp.EmployeeName, emp.EmployeeCode);

                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMedicalInfo::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void PopulateRelationshipDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllFamilyRelationships());
                cboRelation.DataSource = lst;
                cboRelation.DisplayMember = "Description";
                cboRelation.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::PopulateRelationshipDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
             TBL_MP_Master_Employee_MedicalDetail model = null;
               
                ServiceEmployee serviceEmployee = new ServiceEmployee();
                try
                {
                    if (!this.ValidateChildren()) return;
                    if (this.EmployeeMedicalID == 0)
                        model = new TBL_MP_Master_Employee_MedicalDetail();
                    else
                        model = serviceEmployee.GetEmployeeMedicalInfoDbRecord(this.EmployeeMedicalID);


                    model.fk_EmployeeId= this.EmployeeID;

                    #region GATHER DATA INTO MODEL FROM VIEW
                    model.MedicalName = txtMedicalName.Text;
                    model.FK_UL_RelationID = ((SelectListItem)cboRelation.SelectedItem).ID;
                    model.CardNo = txtCardNo.Text;
                    model.CardType = txtCardType.Text;
                    model.CompanyName = txtCompanyName.Text;
                    model.IssueDate = dtIssueDate.Value;
                    model.ExpiryDate = dtExpieryDate.Value;
                    model.Remark = txtRemark.Text;
                    model.IsActive = chkIsActive.Checked;

                #endregion
                if (this.EmployeeMedicalID == 0)
                    {
                        this.EmployeeMedicalID = serviceEmployee.AddNewEmployeeMedicalnfo(model);
                    }
                    else
                    {

                        serviceEmployee.UpdateEmployeeMedicalnfo(model);
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    string errMessage = ex.Message;
                    if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                    MessageBox.Show(errMessage, "frmAddEditMedicalInfo::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void btnCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        #region VALIDATIONS
        private void txtMedicalName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtMedicalName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtMedicalName, "Medical Name Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMedicalInfo::txtMedicalName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dtTillValidDate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!dtExpieryDate.Checked)
                {
                    errorProvider1.SetError(dtExpieryDate, "date mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMedicalInfo::dtTillValidDate_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

      

        private void txtCardNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCardNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtCardNo, "Card No. Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMedicalInfo::txtCardNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCardType_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCardType.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtCardType, "Card Type Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMedicalInfo::txtCardType_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCompanyName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtCompanyName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtCompanyName, "Company Name Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditMedicalInfo::txtCompanyName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        #endregion

       
    }
}
