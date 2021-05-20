using libERP.MODELS.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Controls.HR.EmployeeSalary
{
    public partial class frmAddEditPayrollItem : Form
    {
        public EmployeePayslipItemModel MODEL { get; set; }
        #region Payroll
        public frmAddEditPayrollItem(EmployeePayslipItemModel item)
        {
            this.MODEL = item;
            InitializeComponent();
        }
        private void frmAddEditPayrollItem_Load(object sender, EventArgs e)
        {
            try
            {
                txtSalaryHeadName.ReadOnly = MODEL.IsStandard;
                txtSalaryHeadName.Text = MODEL.SalaryHeadName;
                chkIsSelected.Checked = MODEL.IsApplied;
                if (MODEL.IsApplied)
                {
                    if (MODEL.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM)
                    {
                        rbtnApplicableChargesLumsum.Checked = true;
                        txtLumsumValue.Text = string.Format("{0:0.00}", MODEL.SalaryHeadValue);
                        txtPercentValue.Text = "0.00";
                    }
                        
                    if (MODEL.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE)
                    {
                        txtLumsumValue.Text = string.Format("{0:0.00}", 0);
                        rbtnApplicableChargesPercent.Checked = true;
                        txtPercentValue.Text = string.Format("{0:0.00}", MODEL.SalaryHeadValue);
                        if (MODEL.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                            rbtnBASIC_SALARY.Checked = true;
                        if (MODEL.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                            rbtnGROSS_SALARY.Checked = true;
                        if (MODEL.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            rbtnBASIC_AND_DA_Salary.Checked = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPayrollItem::frmAddEditPayrollItem_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void chkIsSelected_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rbtnApplicableChargesPercent.Enabled = rbtnApplicableChargesLumsum.Enabled = txtPercentValue.Enabled = txtLumsumValue.Enabled= chkIsSelected.Checked;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPayrollItem::chkIsSelected_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validations
                if (!this.ValidateChildren(ValidationConstraints.Enabled)) return;
                MODEL.SalaryHeadName = txtSalaryHeadName.Text.Trim();
                MODEL.IsApplied = chkIsSelected.Checked;
                if (MODEL.IsApplied)
                {
                    if (rbtnApplicableChargesPercent.Checked)
                    {
                        MODEL.ChargesType = libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE;
                        MODEL.SalaryHeadValue = decimal.Parse(txtPercentValue.Text);
                        if (rbtnBASIC_SALARY.Checked) MODEL.HeadForCalculation = libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC;
                        if (rbtnGROSS_SALARY.Checked) MODEL.HeadForCalculation = libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS;
                        if (rbtnBASIC_AND_DA_Salary.Checked) MODEL.HeadForCalculation = libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA;

                    }

                    if (rbtnApplicableChargesLumsum.Checked)
                    {
                        MODEL.ChargesType = libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM;
                        MODEL.SalaryHeadValue = decimal.Parse(txtLumsumValue.Text.Trim());
                    } 
                }
                else
                {
                    MODEL.HeadForCalculation = libERP.MODELS.COMMON.SalaryHeadCalculatedOn.NONE;
                    MODEL.ChargesType = libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.NONE;
                    MODEL.SalaryHeadValue = 0;
                    MODEL.SalaryHeadAmount = 0;
                }
                

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPayrollItem::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion
        #region validations
        private void txtSalaryHeadName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSalaryHeadName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSalaryHeadName, "Salary Head Name Mandatory");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditPayrollItem::txtSalaryHeadName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtApplicableChargesValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (chkIsSelected.Checked == true)
                {
                    if (txtLumsumValue.Text.Trim() == String.Empty)
                    {
                        errorProvider1.SetError(txtLumsumValue, "Can't be Blank");
                        e.Cancel = true;
                    }
                    decimal d = 0;
                    d = decimal.Parse(txtLumsumValue.Text.Trim());

                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtLumsumValue, "Invalid Value");
                e.Cancel = true;
            }
        }
        #endregion

       
    }
}
