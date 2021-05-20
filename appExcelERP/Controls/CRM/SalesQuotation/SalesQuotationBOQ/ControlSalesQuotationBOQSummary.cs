using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using libERP.SERVICES;
using libERP.MODELS.CRM;
using libERP.SERVICES.CRM;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    public partial class ControlSalesQuotationBOQSummary : UserControl
    {
        public SalesQuotationBOQViewModel BOQ_MODEL { get; set; }
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                gridBOQSheets.ReadOnly = _ReadOnly;
                headerGroupMain.Enabled = !_ReadOnly;
            }
        }

        public ControlSalesQuotationBOQSummary()
        {
            InitializeComponent();
        }
        public ControlSalesQuotationBOQSummary(SalesQuotationBOQViewModel model)
        {
            InitializeComponent();
            BOQ_MODEL = model;
        }
        public void PopulateBOQSummaryControl()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ServiceSalesQuotationBOQ _service = new ServiceSalesQuotationBOQ();
                _service.UpdateSalesQuotationBOQSummary(this.BOQ_MODEL);
                gridBOQSheets.DataSource = BOQ_MODEL.SUMMARY.datatableBOQSheets;

                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_SRNO].Width = 100;
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_MATERIAL_TOTAL].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_MATERIAL_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_MATERIAL_TOTAL].DefaultCellStyle.Format = "0.00";
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_MATERIAL_TOTAL].ValueType = typeof(double);
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_MATERIAL_TOTAL].Width = (int)(gridBOQSheets.Width * .15);

                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_INSTALLATION_TOTAL].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_INSTALLATION_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_INSTALLATION_TOTAL].DefaultCellStyle.Format = "0.00";
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_INSTALLATION_TOTAL].ValueType = typeof(double);
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_INSTALLATION_TOTAL].Width = (int)(gridBOQSheets.Width * .15);


                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_TOTAL].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_TOTAL].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_TOTAL].DefaultCellStyle.Format = "0.00";
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_TOTAL].ValueType = typeof(double);
                gridBOQSheets.Columns[_service.COL_BOQ_SUMMARY_TOTAL].Width = (int)(gridBOQSheets.Width * .15);

                
                
                headerGroupMaterialSupply.ValuesPrimary.Heading = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialAmountForAllSheets);
                

                // MATERIAL SUPPLY DISCOUNT
               
               
                txtMaterialDiscountValue.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialDiscount.ItemChargeValue);
                headerGroupMaterialDiscount.ValuesPrimary.Description = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialDiscountAmount);
                if (BOQ_MODEL.SUMMARY.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) rbtnMaterialDiscountPercent.Checked = true;
                if (BOQ_MODEL.SUMMARY.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM) rbtnMaterialDiscountLumsum.Checked = true;

                // MATERIAL SUPPLY GST
                
                txtMaterialCGSTPercent.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialGST.CGST_PERCENT);
                txtMaterialSGSTPercent.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialGST.SGST_PERCENT);
                txtMaterialIGSTPercent.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialGST.IGST_PERCENT);
                headerGroupMaterialGST.ValuesPrimary.Description= string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT);
                headerGroupMaterialGST.ValuesSecondary.Heading = string.Format("SGST: {0:0.00}   CGST: {1:0.00}   IGST: {2:0.00}", BOQ_MODEL.SUMMARY.MaterialGST.SGST_AMOUNT, BOQ_MODEL.SUMMARY.MaterialGST.CGST_AMOUNT, BOQ_MODEL.SUMMARY.MaterialGST.IGST_AMOUNT);
               
                headerGroupMaterialSupply.ValuesSecondary.Description = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.MaterialFinalAmount);

                // INSTALLTATION AND SERVICES
               
                headerGroupInstallation.ValuesPrimary.Heading = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationAmountForAllSheets);
                // INSTALLATION DISCOUNT
                
                txtInstallationDiscountValue.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationDiscount.ItemChargeValue);
                headerGroupInstallationDiscount.ValuesPrimary.Description = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationDiscountAmount);
                if (BOQ_MODEL.SUMMARY.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) rbtnInstallationDiscountPercent.Checked = true;
                if (BOQ_MODEL.SUMMARY.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM) rbtnInstallationDiscountLumsum.Checked = true;

                // INSTALLATION GST
               
                
                txtInstallationCGSTPercent.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationGST.CGST_PERCENT);
                txtInstallationSGSTPercent.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationGST.SGST_PERCENT);
                txtInstallationIGSTPercent.Text = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationGST.IGST_PERCENT);
                headerGroupInstallationGST.ValuesPrimary.Description = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT);
                headerGroupInstallationGST.ValuesSecondary.Heading = string.Format("SGST: {0:0.00}   CGST: {1:0.00}   IGST: {2:0.00}", BOQ_MODEL.SUMMARY.InstallationGST.SGST_AMOUNT, BOQ_MODEL.SUMMARY.InstallationGST.CGST_AMOUNT, BOQ_MODEL.SUMMARY.InstallationGST.IGST_AMOUNT);
                
                headerGroupInstallation.ValuesSecondary.Description = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.InstallationFinalAmount);

                headerGroupMain.ValuesSecondary.Heading = string.Format("{0:0.00}", BOQ_MODEL.SUMMARY.QuotationFinalAmount);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSummary::PopulateBOQSummaryControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (this.ValidateChildren())
                {
                    
                    // MATERIAL SUPPLY DISCOUNT
                    if (rbtnMaterialDiscountPercent.Checked) BOQ_MODEL.SUMMARY.MaterialDiscount.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                    if (rbtnMaterialDiscountLumsum.Checked) BOQ_MODEL.SUMMARY.MaterialDiscount.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                    BOQ_MODEL.SUMMARY.MaterialDiscount.ItemChargeValue = decimal.Parse(txtMaterialDiscountValue.Text.Trim());

                    // MATERIAL SUPPLY GST
                    BOQ_MODEL.SUMMARY.MaterialGST.CGST_PERCENT = decimal.Parse(txtMaterialCGSTPercent.Text.Trim());
                    BOQ_MODEL.SUMMARY.MaterialGST.SGST_PERCENT = decimal.Parse(txtMaterialSGSTPercent.Text.Trim());
                    BOQ_MODEL.SUMMARY.MaterialGST.IGST_PERCENT = decimal.Parse(txtMaterialIGSTPercent.Text.Trim());

                    // INSTALLATION DISCOUNT
                    if (rbtnInstallationDiscountPercent.Checked) BOQ_MODEL.SUMMARY.InstallationDiscount.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                    if (rbtnInstallationDiscountLumsum.Checked) BOQ_MODEL.SUMMARY.InstallationDiscount.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                    BOQ_MODEL.SUMMARY.InstallationDiscount.ItemChargeValue = decimal.Parse(txtInstallationDiscountValue.Text.Trim());

                    // INSTALLATION GST
                    BOQ_MODEL.SUMMARY.InstallationGST.CGST_PERCENT = decimal.Parse(txtInstallationCGSTPercent.Text.Trim());
                    BOQ_MODEL.SUMMARY.InstallationGST.SGST_PERCENT = decimal.Parse(txtInstallationSGSTPercent.Text.Trim());
                    BOQ_MODEL.SUMMARY.InstallationGST.IGST_PERCENT = decimal.Parse(txtInstallationIGSTPercent.Text.Trim());

                    PopulateBOQSummaryControl();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSummary::btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
