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
    public partial class frmAddEditDesignationwiseSalaryHeadValue : Form
    {
        public DesignationwiseSalaryHeadModel MODEL { get; set; }

        public frmAddEditDesignationwiseSalaryHeadValue(DesignationwiseSalaryHeadModel selItem )
        {
            InitializeComponent();
            MODEL = selItem;
        }
        private void frmAddEditDesignationwiseSalaryHeadValue_Load(object sender, EventArgs e)
        {
            try
            {
                if (MODEL != null)
                {
                    headerGroupMain.ValuesPrimary.Heading = MODEL.SalaryHeadName.ToUpper();
                    chkIsSelected.Checked = MODEL.IsSelected;
                    if (MODEL.ApplicableChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE)
                        rbtnApplicableChargesPercent.Checked = true;
                    if (MODEL.ApplicableChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM)
                        rbtnApplicableChargesLumsum.Checked = true;

                    txtApplicableChargesValue.Text = string.Format("{0:0.00}", MODEL.ApplicableChargesValue);
                    rbtnApplicableChargesLumsum.Enabled = rbtnApplicableChargesPercent.Enabled = txtApplicableChargesValue.Enabled = chkIsSelected.Checked;

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditDesignationwiseSalaryHeadValue::frmAddEditDesignationwiseSalaryHeadValue_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.ValidateChildren(ValidationConstraints.Enabled)) return;

                if (rbtnApplicableChargesPercent.Checked) MODEL.ApplicableChargesType = libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE;
                if (rbtnApplicableChargesLumsum.Checked) MODEL.ApplicableChargesType = libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM;
                MODEL.ApplicableChargesValue = decimal.Parse(txtApplicableChargesValue.Text.Trim());
                MODEL.IsSelected = chkIsSelected.Checked;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditDesignationwiseSalaryHeadValue::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region VALIDATIONS
        private void txtApplicableChargesValue_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (chkIsSelected.Checked == true)
                {
                    if (txtApplicableChargesValue.Text.Trim() == String.Empty)
                    {
                        errorProvider1.SetError(txtApplicableChargesValue, "Can't be Blank");
                        e.Cancel = true;
                    }
                    decimal d = 0;
                    d = decimal.Parse(txtApplicableChargesValue.Text.Trim());

                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtApplicableChargesValue, "Invalid Value");
                e.Cancel = true;
            }
        }
         #endregion

        private void chkIsSelected_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rbtnApplicableChargesLumsum.Enabled = rbtnApplicableChargesPercent.Enabled = txtApplicableChargesValue.Enabled = chkIsSelected.Checked;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditDesignationwiseSalaryHeadValue::chkIsSelected_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
