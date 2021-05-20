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

namespace appExcelERP.Forms.HR
{
    public partial class frmAddEditEmployeeWiseSalaryHeadValue : Form
    {
        public EmployeeSalaryHeadModel MODEL { get; set; }
       
        public frmAddEditEmployeeWiseSalaryHeadValue(EmployeeSalaryHeadModel selItem)
        {
            InitializeComponent();
            MODEL = selItem;
        }

        private void frmAddEditEmployeeWiseSalaryHeadValue_Load(object sender, EventArgs e)
        {
            try
            {
                if (MODEL != null)
                {
                    headerGroupMain.ValuesPrimary.Heading = MODEL.SalaryHeadName.ToUpper();
                    chkIsSelected.Checked = MODEL.IsSelected;
                    txtPercentValue.Text = txtLumsumValue.Text = string.Format("{0:0.00}", 0);
                    if (MODEL.ApplicableChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE)
                    {
                        rbtnApplicableChargesPercent.Checked = true;
                        if (MODEL.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                            rbtnBASIC_SALARY.Checked = true;
                        if (MODEL.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                            rbtnGROSS_SALARY.Checked = true;
                        if (MODEL.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            rbtnBASIC_AND_DASalary.Checked = true;

                        txtPercentValue.Text = string.Format("{0:0.00}", MODEL.ApplicableChargesValue);
                    }

                    if (MODEL.ApplicableChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM)
                    {
                        rbtnApplicableChargesLumsum.Checked = true;
                        txtLumsumValue.Text = string.Format("{0:0.00}", MODEL.ApplicableChargesValue);
                    }
                    
                    rbtnApplicableChargesLumsum.Enabled = rbtnApplicableChargesPercent.Enabled = txtLumsumValue.Enabled = chkIsSelected.Checked;
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeWiseSalaryHeadValue::frmAddEditEmployeeWiseSalaryHeadValue_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren(ValidationConstraints.Enabled)) return;

                if (rbtnApplicableChargesPercent.Checked)
                {
                    MODEL.ApplicableChargesType = libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE;
                    if (rbtnBASIC_SALARY.Checked) MODEL.HeadForCalculation = libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC;
                    if (rbtnGROSS_SALARY.Checked) MODEL.HeadForCalculation = libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS;
                    if (rbtnBASIC_AND_DASalary.Checked) MODEL.HeadForCalculation = libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA;

                    MODEL.ApplicableChargesValue = decimal.Parse(txtPercentValue.Text.Trim());
                }
                if (rbtnApplicableChargesLumsum.Checked)
                {
                    MODEL.ApplicableChargesType = libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM;
                    MODEL.ApplicableChargesValue = decimal.Parse(txtLumsumValue.Text.Trim());
                }

                MODEL.IsSelected= chkIsSelected.Checked;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeWiseSalaryHeadValue::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rbtnApplicableChargesLumsum.Enabled = rbtnApplicableChargesPercent.Enabled = txtLumsumValue.Enabled = chkIsSelected.Checked;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditEmployeeWiseSalaryHeadValue::chkIsActive_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtMaterialAddonChargesValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (chkIsSelected.Checked == true)
                {
                    if (txtLumsumValue.Text.Trim() == string.Empty)
                    {
                        errorProvider1.SetError(txtLumsumValue, "Can't be left blank");
                        e.Cancel = true;
                    }
                    decimal d = 0;
                    d = decimal.Parse(txtLumsumValue.Text.Trim());
                }
            }
            catch (Exception)
            {
                errorProvider1.SetError(txtLumsumValue, "Invalid Value");
                e.Cancel = true;
            }
        }

        private void SetValueCaption(object sender, EventArgs e)
        {
            lblValueCaption.Text = string.Empty; ;
            if (rbtnApplicableChargesPercent.Checked)
           
                lblValueCaption.Text = "%";
            if (rbtnApplicableChargesLumsum.Checked) lblValueCaption.Text = "Rs.";
        }
    }
}
