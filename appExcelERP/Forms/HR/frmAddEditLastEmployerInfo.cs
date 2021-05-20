using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS.HR;
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
    public partial class frmAddEditLastEmployerInfo : KryptonForm
    {
        public int SelectedEmployeeID { get; set; }
        public int SelectID { get; set; }
        
        public frmAddEditLastEmployerInfo()
        {
            InitializeComponent();
        }
        public frmAddEditLastEmployerInfo(int id)
        {
            InitializeComponent();
            this.SelectID= id;
        }

        private void frmAddEditLastEmployerInfo_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceEmployee _service = new ServiceEmployee();

              
                if (this.SelectID == 0)
                {
                    txtName.Text = txtAddress.Text = txtContactNo.Text = string.Empty;
                    chkIsActive.Checked = false;
                    if (this.SelectedEmployeeID != 0)
                    {
                        TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(SelectedEmployeeID);
                        this.Text = string.Format("{0} ({1}) - Add Last Employer Info", emp.EmployeeName, emp.EmployeeCode);
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
                MessageBox.Show(errMessage, "frmAddEditLastEmployerInfo::frmAddEditLastEmployerInfo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ScatterData()
        {
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                TBL_MP_Master_Employee_LastEmployerDetail model = _service.GetLastEmployerInfoDBRecordByID(this.SelectID);
                if (model != null)
                {
                    txtName.Text = model.LastEmployerName;
                    txtAddress.Text = model.Address;
                    txtContactNo.Text =model.ContactNo.ToString();
                    chkIsActive.Checked = model.isActive;


                }
                TBL_MP_Master_Employee emp = _service.GetEmployeeDbRecordByID(SelectedEmployeeID);
                this.Text = string.Format("{0} ({1}) - Update X-Employer's Info.", emp.EmployeeName, emp.EmployeeCode);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLastEmployerInfo::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Employee_LastEmployerDetail model = null;
            ServiceEmployee _service = new ServiceEmployee();
            try
            {
                if (!this.ValidateChildren()) return;

                if (this.SelectID == 0)
                    model = new TBL_MP_Master_Employee_LastEmployerDetail();
                else
                    model = _service.GetLastEmployerInfoDBRecordByID(this.SelectID);

                model.LastEmployerID=SelectID;
                model.FK_EmployeeId = this.SelectedEmployeeID;
                model.LastEmployerName = txtName.Text.Trim();
                model.Address = txtAddress.Text.Trim();
                model.ContactNo = int.Parse(txtContactNo.Text.Trim());
                model.isActive = chkIsActive.Checked;

                if (this.SelectID == 0)
                    this.SelectID = _service.AddNewLastEmployerInfo(model);
                else
                    _service.UpdateLastEmployerInfo(model);


                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLastEmployerInfo::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        #region VALIDATIONS
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtName, "Name is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLastEmployerInfo::txtName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtAddress.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtAddress, "Address is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLastEmployerInfo::txtAddress_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /*
        private void txtContactNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtContactNo.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtContactNo, "Contact No is Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditLastEmployerInfo::txtContactNo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }*/
        #endregion

    }
}
