using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.CRM
{
    public class SalesOrderBOQViewModel
    {
        public int ORDER_ID { get; set; }
        public int BOQ_ID { get; set; }
        public string BOQ_NUMBER { get; set; }
        //public SalesQuotationBOQConfigurationModel CONFIGURATION { get; set; }
        public List<SalesOrderBOQSheet> SHEETS { get; set; }
        public SalesOrderBOQSummary SUMMARY { get; set; }

        public SalesOrderBOQViewModel()
        {
            this.SHEETS = new List<SalesOrderBOQSheet>();
            //this.CONFIGURATION = new SalesQuotationBOQConfigurationModel();
            this.SUMMARY = new SalesOrderBOQSummary();

        }


    }
    public class SalesOrderBOQSummary
    {
        public DataTable datatableBOQSheets { get; set; }

        public decimal MaterialAmountForAllSheets { get; set; }
        public decimal InstallationAmountForAllSheets { get; set; }

        public ItemChargeModel MaterialDiscount { get; set; }
        public decimal MaterialDiscountAmount { get; set; }
        public GST_ChargesModel MaterialGST { get; set; }
        public decimal MaterialFinalAmount { get; set; }


        public ItemChargeModel InstallationDiscount { get; set; }
        public decimal InstallationDiscountAmount { get; set; }
        public GST_ChargesModel InstallationGST { get; set; }
        public decimal InstallationFinalAmount { get; set; }

        public decimal QuotationFinalAmount { get { return this.MaterialFinalAmount + this.InstallationFinalAmount; } }

        public SalesOrderBOQSummary()
        {
            this.datatableBOQSheets = new DataTable();
            //MATERIAL
            this.MaterialAmountForAllSheets = 0;
            this.MaterialDiscount = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.MaterialDiscountAmount = 0;
            this.MaterialGST = new GST_ChargesModel() { CGST_PERCENT = 0, IGST_PERCENT = 0, SGST_PERCENT = 0, CGST_AMOUNT = 0, IGST_AMOUNT = 0, SGST_AMOUNT = 0 };
            this.MaterialFinalAmount = 0;
            // INSTALLATIONS
            this.InstallationAmountForAllSheets = 0;
            this.InstallationDiscount = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.InstallationDiscountAmount = 0;
            this.InstallationGST = new GST_ChargesModel() { CGST_PERCENT = 0, IGST_PERCENT = 0, SGST_PERCENT = 0, CGST_AMOUNT = 0, IGST_AMOUNT = 0, SGST_AMOUNT = 0 };
            this.InstallationFinalAmount = 0;




        }
    }

    public class SalesOrderBOQSheetSummary
    {
        public string SheetName { get; set; }
        public string MOC { get; set; }

        public decimal NetAmountBeforeTax { get; set; }
        public decimal GrossAmountAfterTax { get; set; }

        // MATERIAL SUPPLY SUMMARY
        public decimal MaterialSupplyAmount { get; set; }
        public decimal MaterialSupplyDiscountAmount { get; set; }
        public decimal MaterialSupplyAddOnChargesAmount { get; set; }
        public decimal MaterialSupplyProfitMarginAmount { get; set; }

        public decimal MaterialSupplyCGSTAmount { get; set; }
        public decimal MaterialSupplySGSTAmount { get; set; }
        public decimal MaterialSupplyIGSTAmount { get; set; }

        // INSTALLATION SUMMARY
        public decimal InstallationAmount { get; set; }
        public decimal InstallationDiscountAmount { get; set; }
        public decimal InstallationAddOnChargesAmount { get; set; }
        public decimal InstallationProfitMarginAmount { get; set; }

        public decimal InstallationCGSTAmount { get; set; }
        public decimal InstallationSGSTAmount { get; set; }
        public decimal InstallationIGSTAmount { get; set; }


    }
    public class SalesOrderBOQSheet
    {
        public int SheetID { get; set; }
        public string SheetName { get; set; }
        public string SheetDescription { get; set; }
        public BindingList<EnquiryBOQItem> BOQ_ITEMS { get; set; }
        public BindingList<EnquiryBOQService> BOQ_SERVICES { get; set; }
        public DataTable datatableOrderBOQ { get; set; }
        public DataTable datatableQuotationBOQ { get; set; }
        public List<BOQItemChargesModel> ITEM_CHARGES { get; set; }
        public SalesOrderBOQSheetSummary SUMMARY { get; set; }


    }
}
