using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.SERVICES.HR;
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
    public partial class frmAddEditEmployeeQualification : KryptonForm

    {
        public int SelectedEmployeeID { get; set; }
        public int EmployeeQualificationID { get; set; }

        public frmAddEditEmployeeQualification()
        {
            InitializeComponent();
        }
        public frmAddEditEmployeeQualification(int id)
        {
            InitializeComponent();
            this.EmployeeQualificationID = id;
        }
        private void frmAddEditEmployeeQualification_Load(object sender, EventArgs e)
        {

            try
            {
                ServiceEmployee _service = new ServiceEmployee();
             

                if (this.EmployeeQualificationID == 0)
                {
                    txtQualification.Text = txtNameOfInstitute.Text = txtGradeClass.Text=string.Empty;
                   
                    if (this.SelectedEmployeeID != 0)
                    {
                        TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(SelectedEmployeeID);
                        this.Text = string.Format("{0} ({1}) - Add Qualification", emp.EmployeeName, emp.EmployeeCode);
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
                MessageBox.Show(errMessage, "frmAddEditEmployeeQualification::frmAddEditEmployeeQualification_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ScatterData()
        {
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                TBL_MP_Master_Employee_Qualification model = _service.GetEmployeeQualificationDBRecordByID(this.EmployeeQualificationID);
                if (model != null)
                {
                    txtQualification.Text = model.Qualification;
                    txtNameOfInstitute.Text = model.NameOfInstitute;
                    txtGradeClass.Text = model.Grade;

                    TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(model.FK_EmployeeId);
                    this.Text = string.Format("{0} ({1}) - Update Qualification", emp.EmployeeName, emp.EmployeeCode);
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeQualification::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Employee_Qualification model = null;
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                if (!this.ValidateChildren()) return;

                if (this.EmployeeQualificationID == 0)
                    model = new TBL_MP_Master_Employee_Qualification();
                else
                    model = _service.GetEmployeeQualificationDBRecordByID(EmployeeQualificationID);


                model.Qualification = txtQualification.Text.Trim();
                model.NameOfInstitute = txtNameOfInstitute.Text.Trim();
                model.Grade = txtGradeClass.Text.Trim();

                if (this.EmployeeQualificationID == 0)
                {
                    model.FK_EmployeeId = SelectedEmployeeID;
                    this.EmployeeQualificationID = _service.AddNewEmployeeQualification(model);
                }
                else
                  _service.UpdateEmployeeQualification(model);


                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeQualification::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #region VALIDATION
        private void txtQualification_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtQualification.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtQualification, "Qualification is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeQualification::txtQualification_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtNameOfInstitute_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtNameOfInstitute.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtNameOfInstitute, "Name of Institute is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeQualification::txtNameOfInstitute_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #endregion

       

    
    }
}
