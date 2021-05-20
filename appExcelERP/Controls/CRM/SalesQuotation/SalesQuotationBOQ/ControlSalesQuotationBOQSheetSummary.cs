using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.CRM;

namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    public partial class ControlSalesQuotationBOQSheetSummary : UserControl
    {
        public SalesQuotationBOQSheetSummary MODEL { get; set; }
        public ControlSalesQuotationBOQSheetSummary()
        {
            InitializeComponent();
        }
        public void PopulateSummaryInfoControl()
        {
            try
            {
                if (MODEL == null) return;

                //txtNetAmountBeforeTAX.Text=
                //txtGrossAmountAfterTAX.Text = string.Format("{0:0.00}", MODEL.GrossAmountAfterTax);
                headerGroupMain.ValuesPrimary.Heading = string.Format("{0:0.00}", MODEL.NetAmountBeforeTax);
                headerGroupMain.ValuesPrimary.Description = "NET AMOUNT(before TAX)";
                headerGroupMain.ValuesSecondary.Heading = string.Format("{0:0.00}", MODEL.InstallationAmount + MODEL.MaterialSupplyAmount);
                headerGroupMain.ValuesSecondary.Description = "GROSS AMOUNT(after TAX)";

                headerGroupMaterialSupply.ValuesSecondary.Description = string.Format("{0:0.00}", MODEL.MaterialSupplyAmount);
                txtMaterialSupplyAddOnCharges.Text = string.Format("{0:0.00}", MODEL.MaterialSupplyAddOnChargesAmount);
                txtMaterialSupplyProfitMargin.Text = string.Format("{0:0.00}", MODEL.MaterialSupplyProfitMarginAmount);
                txtMaterialSupplyDiscount.Text = string.Format("{0:0.00}", MODEL.MaterialSupplyDiscountAmount);
                txtMaterialSupplyCGSTAmount.Text = string.Format("{0:0.00}", MODEL.MaterialSupplyCGSTAmount);
                txtMaterialSupplySGSTAmount.Text = string.Format("{0:0.00}", MODEL.MaterialSupplySGSTAmount);
                txtMaterialSupplyIGSTAmount.Text = string.Format("{0:0.00}", MODEL.MaterialSupplyIGSTAmount);

                headerGroupInstallation.ValuesSecondary.Description = string.Format("{0:0.00}", MODEL.InstallationAmount);
                txtInstallationAddOncharges.Text = string.Format("{0:0.00}", MODEL.InstallationAddOnChargesAmount);
                txtInstallationProfitMargin.Text = string.Format("{0:0.00}", MODEL.InstallationProfitMarginAmount);
                txtInstallationDiscountAmount.Text = string.Format("{0:0.00}", MODEL.InstallationDiscountAmount);
                txtInstallationCGSTAmount.Text = string.Format("{0:0.00}", MODEL.InstallationCGSTAmount);
                txtInstallationSGSTAmount.Text = string.Format("{0:0.00}", MODEL.InstallationSGSTAmount);
                txtInstallationIGSTAmount.Text = string.Format("{0:0.00}", MODEL.InstallationIGSTAmount);


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheetSummary::PopulateSummaryInfoControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
