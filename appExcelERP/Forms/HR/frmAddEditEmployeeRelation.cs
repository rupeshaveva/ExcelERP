using ComponentFactory.Krypton.Toolkit;
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
    public partial class frmAddEditEmployeeRelation : KryptonForm
    {
        public int SelectedEmployeeID { get; set; }
        public int EmployeeRelationshipID { get; set; }
        public frmAddEditEmployeeRelation()
        {
            InitializeComponent();
        }
        public frmAddEditEmployeeRelation(int ID)
        {
            InitializeComponent();
            this.EmployeeRelationshipID = ID;
        }

        private void frmAddEditEmployeeRelation_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceEmployee _service = new ServiceEmployee();
                PopulateRelationshipDropdown();
                if (EmployeeRelationshipID == 0)
                {
                    txtRelativeName.Text = txtRemark.Text = string.Empty;
                    dtDateOfBirth.Checked = false;
                    if (this.SelectedEmployeeID != 0)
                    {
                        TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(SelectedEmployeeID);
                        this.Text = string.Format("{0} ({1}) - Add Relationship", emp.EmployeeName, emp.EmployeeCode);
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
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::frmAddEditEmployeeRelation_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void ScatterData()
        {
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                TBL_MP_Master_Employee_Relative model = _service.GetEmployeeRelativeDBRecordByID(this.EmployeeRelationshipID);
                if (model != null)
                {
                    txtRelativeName.Text = model.RelativeName;
                    txtRemark.Text = model.Remarks;
                    if (model.RelativeDOB != null)
                        dtDateOfBirth.Value = (DateTime)model.RelativeDOB;
                    else
                        dtDateOfBirth.Checked = false;

                    cboSelectRelation.SelectedItem = ((List<SelectListItem>)cboSelectRelation.DataSource).Where(x => x.ID == model.FK_UL_RelationID).FirstOrDefault();
                }
                TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(SelectedEmployeeID);
                this.Text = string.Format("{0} ({1}) - Add Relationship", emp.EmployeeName, emp.EmployeeCode);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void PopulateRelationshipDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllFamilyRelationships());
                cboSelectRelation.DataSource = lst;
                cboSelectRelation.DisplayMember = "Description";
                cboSelectRelation.ValueMember = "ID";
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
            TBL_MP_Master_Employee_Relative model = null;
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                if (!this.ValidateChildren()) return;

                if (this.EmployeeRelationshipID == 0)
                    model = new TBL_MP_Master_Employee_Relative();
                else
                    model = _service.GetEmployeeRelativeDBRecordByID(EmployeeRelationshipID);

                model.FK_EmployeeID = this.SelectedEmployeeID;
                model.FK_UL_RelationID = ((SelectListItem)cboSelectRelation.SelectedItem).ID;
                model.RelativeName = txtRelativeName.Text.Trim();
                if (dtDateOfBirth.Checked)
                    model.RelativeDOB = dtDateOfBirth.Value;
                else
                    model.RelativeDOB = null;
                model.Remarks = txtRemark.Text.Trim();

                if (this.EmployeeRelationshipID == 0)
                    this.EmployeeRelationshipID = _service.AddNewEmployeeRelative(model);
                else
                    _service.UpdateEmployeeRelative(model);


                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region VALIDATION
        private void cboSelectRelation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                int selID = ((SelectListItem)cboSelectRelation.SelectedItem).ID;
                if (selID == 0)
                {
                    errorProvider1.SetError(cboSelectRelation, "Relation is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::cboSelectRelation_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtRelativeName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtRelativeName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRelativeName, "Relative name is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeRelation::txtRelativeName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

       
    }
}
