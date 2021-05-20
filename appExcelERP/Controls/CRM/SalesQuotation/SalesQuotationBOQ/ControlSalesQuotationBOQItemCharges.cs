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
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{

    public partial class ControlSalesQuotationBOQItemCharges : UserControl
    {
        // Declare an event 
        public event BOQItemChargesChangedEventHandler OnValueChanged;

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly == true)
                {
                    headerGroupMain.Enabled = false;
                }
                else
                {
                    headerGroupMain.Enabled = true;
                }
            }
        }

        public BOQItemChargesModel ITEM_CHARGES_INFO { get; set; }
        //public SalesQuotationBOQConfigurationModel CONFIGURATION_INFO { get; set; }
        public BOQ_ITEM_TYPE ITEM_TYPE { get; set; }
        public decimal ITEM_QUANTITY
        {
            get
            {
                if (ITEM_CHARGES_INFO != null)
                    return ITEM_CHARGES_INFO.TotalQuantity;
                else
                    return 0;
            }
            set
            {
                if (ITEM_CHARGES_INFO != null) ITEM_CHARGES_INFO.TotalQuantity = value;
            }
        }

        public ControlSalesQuotationBOQItemCharges()
        {
            InitializeComponent();

        }
        private void ControlSalesQuotationBOQChildItem_Load(object sender, EventArgs e)
        {

        }
        private void ControlSalesQuotationBOQChildItem_Resize(object sender, EventArgs e)
        {
            //int width = (int)(this.splitContainerMain.Width * .5);
            //if (width > 15) splitContainerMain.SplitterDistance = width;
            splitContainerMain.SplitterDistance = (int)(this.splitContainerMain.Width * .5);
        }

        public void PopulateItemChargesControl()
        {
            ScatterDataIntoControls();
        }
        private void GatherDataIntoModelAndPerformCalculations()
        {
            try
            {
                // GATHER ALL VALUES BACK INTO CONFIGURATION_INFO(SalesQuotationBOQItemChargesModel)
                ITEM_CHARGES_INFO.TotalQuantity = decimal.Parse(txtQuantity.Text.Trim());
                ITEM_CHARGES_INFO.MaterialBasicPrice = decimal.Parse(txtBasicBrice.Text.Trim());

                #region MATERIAL SUPPLY CHARGES

                // MATERIAL ADD ON CHARGES
                ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeValue = decimal.Parse(txtMaterialAddonChargesValue.Text.Trim());
                if (rbtnMaterialAddOnChargesPercent.Checked)
                    ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                if (rbtnMaterialAddOnChargesLumsum.Checked)
                    ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;

                // MATERIAL PROFIT MARGIN
                ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeValue = decimal.Parse(txtMaterialProfitMarginValue.Text.Trim());
                if (rbtnMaterialProfitMarginPercent.Checked)
                    ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                if (rbtnMaterialProfitMarginLumsum.Checked)
                    ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;


                // MATERIAL DISCOUNT
                ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeValue = decimal.Parse(txtMaterialDiscountValue.Text.Trim());
                if (rbtnMaterialDiscountPercent.Checked)
                    ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                if (rbtnMaterialDiscountLumsum.Checked)
                    ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                // MATERIAL GST
                ITEM_CHARGES_INFO.MaterialGST.SGST_PERCENT = decimal.Parse(txtMaterialSGSTPercent.Text.Trim());
                ITEM_CHARGES_INFO.MaterialGST.CGST_PERCENT = decimal.Parse(txtMaterialCGSTPercent.Text.Trim());
                ITEM_CHARGES_INFO.MaterialGST.IGST_PERCENT = decimal.Parse(txtMaterialIGSTPercent.Text.Trim());

                #endregion
                #region INSTALLATION & SERVICES
                // INSTALLATION CHARGES
                ITEM_CHARGES_INFO.InstallationRate.ItemChargeValue = decimal.Parse(txtInstallationRateValue.Text.Trim());
                if (rbtnInstallationRatePercent.Checked)
                    ITEM_CHARGES_INFO.InstallationRate.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                if (rbtnInstallationRateLumsum.Checked)
                    ITEM_CHARGES_INFO.InstallationRate.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;

                // Installation ADD ON CHARGES
                ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeValue = decimal.Parse(txtInstallationAddonChargesValue.Text.Trim());
                if (rbtnInstallationAddonChargesPercent.Checked)
                {
                    ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                }
                if (rbtnInstallationAddonChargesLumsum.Checked)
                {
                    ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                }
                // Installation PROFIT MARGIN
                ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeValue = decimal.Parse(txtInstallationProfitMarginValue.Text.Trim());
                if (rbtnInstallationProfitMarginPercent.Checked)
                    ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                if (rbtnInstallationProfitMarginLumsum.Checked)
                    ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                // Installation DISCOUNT
                ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeValue = decimal.Parse(txtInstallationDiscountValue.Text.Trim());
                if (rbtnInstallationDiscountPercent.Checked)
                    ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeType = ITEM_CHARGE_TYPE.PERCENTAGE;
                if (rbtnInstallationDiscountLumsum.Checked)
                    ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                // Installation GST
                ITEM_CHARGES_INFO.InstallationGST.SGST_PERCENT = decimal.Parse(txtInstallationSGSTPercent.Text.Trim());
                ITEM_CHARGES_INFO.InstallationGST.CGST_PERCENT = decimal.Parse(txtInstallationCGSTPercent.Text.Trim());
                ITEM_CHARGES_INFO.InstallationGST.IGST_PERCENT = decimal.Parse(txtInstallationIGSTPercent.Text.Trim());
                #endregion



                (new ServiceSalesQuotationBOQ()).CalculateChargesOnBOQItem(ITEM_CHARGES_INFO);


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQItemCharges::GatherDataIntoModelAndPerformCalculations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void ScatterDataIntoControls()
        {
            try
            {
                if (ITEM_CHARGES_INFO == null) return;
                txtQuantity.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.TotalQuantity);
                txtBasicBrice.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialBasicPrice);

                // MATERIAL ADD ON CHARGES
                rbtnMaterialAddOnChargesPercent.Checked = (ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE);
                rbtnMaterialAddOnChargesLumsum.Checked = (ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM);
                txtMaterialAddonChargesValue.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeValue);
                headerGroupMaterialAddOnCharges.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialAddOnChargesAmount);

                // MATERIAL PROFIT MARGIN
                rbtnMaterialProfitMarginPercent.Checked = (ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE);
                rbtnMaterialProfitMarginLumsum.Checked = (ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM);
                txtMaterialProfitMarginValue.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeValue);
                headerGroupMaterialProfitMargin.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialProfitMarginAmount);

                headerMaterialSellingCost.Values.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialSellingCost);

                // MATERIAL DISCOUNT
                rbtnMaterialDiscountPercent.Checked = (ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE);
                rbtnMaterialDiscountLumsum.Checked = (ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM);
                txtMaterialDiscountValue.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeValue);
                headerGroupMaterialDiscount.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialDiscountAmount);

                // MATERIAL GST
                txtMaterialCGSTPercent.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialGST.CGST_PERCENT);
                txtMaterialSGSTPercent.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialGST.SGST_PERCENT);
                txtMaterialIGSTPercent.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialGST.IGST_PERCENT);
                headerGroupMaterialGST.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.MaterialGST.GST_TOTAL_AMOUNT);
                headerGroupMaterialGST.ValuesSecondary.Heading = string.Format(
                    "CGST: {0:0.00}  SCGST: {1:0.00}  IGST: {2:0.00}",
                    ITEM_CHARGES_INFO.MaterialGST.CGST_AMOUNT, ITEM_CHARGES_INFO.MaterialGST.SGST_AMOUNT, ITEM_CHARGES_INFO.MaterialGST.IGST_AMOUNT
                    );

                headerGroupMaterialSupply.ValuesSecondary.Heading = string.Format("Net Rate: {0:0.00}", ITEM_CHARGES_INFO.MaterialNetRate);
                headerGroupMaterialSupply.ValuesSecondary.Description = string.Format("Supply Amt: {0:0.00}", ITEM_CHARGES_INFO.MaterialSupplyAmount);

                // INSTALLATION AND SERVICES RATE
                rbtnInstallationRatePercent.Checked = (ITEM_CHARGES_INFO.InstallationRate.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE);
                rbtnInstallationRateLumsum.Checked = (ITEM_CHARGES_INFO.InstallationRate.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM);
                txtInstallationRateValue.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationRate.ItemChargeValue);
                headerGroupInstallationRate.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationRateAmount);

                // INSTALLATION AND SERVICES ADD ON CHARGES
                rbtnInstallationAddonChargesPercent.Checked = (ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE);
                rbtnInstallationAddonChargesLumsum.Checked = (ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM);
                txtInstallationAddonChargesValue.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeValue);
                headerGroupInstallationAddOnCharges.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationAddOnChargesAmount);

                // INSTALLATION AND SERVICES PROFIT MARGIN
                rbtnInstallationProfitMarginPercent.Checked = (ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE);
                rbtnInstallationProfitMarginLumsum.Checked = (ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM);
                txtInstallationProfitMarginValue.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeValue);
                headerGroupInstallationProfitMargin.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationProfitMarginAmount);

                headerInstallationSellingCost.Values.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationSellingCost);

                // INSTALLATION AND SERVICES DISCOUNT
                rbtnInstallationDiscountPercent.Checked = (ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE);
                rbtnInstallationDiscountLumsum.Checked = (ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM);
                txtInstallationDiscountValue.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeValue);
                headerGroupInstallationDiscount.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationDiscountAmount);


                // INSTALLATION AND SERVICES GST
                txtInstallationCGSTPercent.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationGST.CGST_PERCENT);
                txtInstallationSGSTPercent.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationGST.SGST_PERCENT);
                txtInstallationIGSTPercent.Text = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationGST.IGST_PERCENT);
                headerGroupInstallationGST.ValuesPrimary.Description = string.Format("{0:0.00}", ITEM_CHARGES_INFO.InstallationGST.GST_TOTAL_AMOUNT);
                headerGroupInstallationGST.ValuesSecondary.Heading = string.Format(
                    "CGST: {0:0.00}  SCGST: {1:0.00}  IGST: {2:0.00}",
                    ITEM_CHARGES_INFO.InstallationGST.CGST_AMOUNT, ITEM_CHARGES_INFO.InstallationGST.SGST_AMOUNT, ITEM_CHARGES_INFO.InstallationGST.IGST_AMOUNT
                    );

                headerGroupInstallationCharges.ValuesSecondary.Heading = string.Format("Net Rate: {0:0.00}", ITEM_CHARGES_INFO.InstallationNetRate);
                headerGroupInstallationCharges.ValuesSecondary.Description = string.Format("Total Amt: {0:0.00}", ITEM_CHARGES_INFO.InstallationAmount);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQItemCharges::ScatterDataIntoControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                GatherDataIntoModelAndPerformCalculations();
                ScatterDataIntoControls();
                if (OnValueChanged != null)
                    OnValueChanged(this, new BOQItemChargesChangedEventArgs() { ITEM_INDEX = ITEM_CHARGES_INFO.Index });
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQItemCharges::btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        




    }

}
