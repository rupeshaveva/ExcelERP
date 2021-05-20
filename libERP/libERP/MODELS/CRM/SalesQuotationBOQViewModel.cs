using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows.Forms;
using System.ComponentModel;
using libERP.MODELS.COMMON;

namespace libERP.MODELS.CRM
{
    public enum BOQ_ITEM_TYPE
    {
        NONE=0,
        PARENT_ITEM=1,
        CHILD_ITEM=2,
        CHILD_ITEM_IS_ASSEMBLY=3,
        CHILD_ITEM_OF_ASSEMBLY_ITEM=4,
        PARENT_ITEM_IS_ASSEMBLY_ITEM=5,

    }

    public class SalesQuotationBOQViewModel
    {
        public int QUOTATION_ID { get; set; }
        public int  BOQ_ID { get; set; }
        public string BOQ_NUMBER { get; set; }
        //public SalesQuotationBOQConfigurationModel CONFIGURATION { get; set; }
        public List<SalesQuotationBOQSheet> SHEETS { get; set; }
        public SalesQuotationBOQSummary SUMMARY { get; set; }

        public SalesQuotationBOQViewModel()
        {
            this.SHEETS = new List<SalesQuotationBOQSheet>();
            //this.CONFIGURATION = new SalesQuotationBOQConfigurationModel();
            this.SUMMARY = new SalesQuotationBOQSummary();
            
        }


    }
    public class SalesQuotationBOQSummary
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

        public SalesQuotationBOQSummary()
        {
            this.datatableBOQSheets = new DataTable();
            //MATERIAL
            this.MaterialAmountForAllSheets = 0;
            this.MaterialDiscount = new ItemChargeModel() {ItemChargeType= ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue=0 };
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

    public class SalesQuotationBOQSheetSummary
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
    public class SalesQuotationBOQSheet
    {
        public int SheetID { get; set; }
        public string SheetName { get; set; }
        public string SheetDescription { get; set; }
        public BindingList<EnquiryBOQItem> BOQ_ITEMS { get; set; }
        public BindingList<EnquiryBOQService> BOQ_SERVICES { get; set; }
        public DataTable datatableQuotationBOQ { get; set; }
        public DataTable datatableEnquiryBOQ { get; set; }
        public List<BOQItemChargesModel> ITEM_CHARGES { get; set; }
        public SalesQuotationBOQSheetSummary SUMMARY { get; set; }


    }
    
    public class BOQItemChargesModel
    {
        public int Index { get; set; }
        public decimal TotalQuantity { get; set; }
        
        public BOQItemChargesModel()
        {
            this.MaterialBasicPrice = 0;
            this.MaterialNetRate = 0;
            this.MaterialSupplyAmount = 0;

            this.MaterialAddOnCharges = new ItemChargeModel() { ItemChargeType= ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue=0 };
            this.MaterialAddOnChargesAmount = 0;

            this.MaterialProfitMargin = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.MaterialProfitMarginAmount = 0;

            this.MaterialDiscount = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.MaterialDiscountAmount = 0;

            this.MaterialGST = new GST_ChargesModel();


            
            this.InstallationRate = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.InstallationRateAmount = 0;

            this.InstallationAddOnCharges = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.InstallationAddOnChargesAmount = 0;

            this.InstallationProfitMargin = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.InstallationProfitMarginAmount = 0;

            this.InstallationDiscount = new ItemChargeModel() { ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM, ItemChargeValue = 0 };
            this.InstallationDiscountAmount = 0;

            this.InstallationGST = new GST_ChargesModel();
        }
        #region MATERIAL

        public decimal MaterialBasicPrice { get; set; }
        
        public ItemChargeModel MaterialAddOnCharges { get; set; }
        public decimal MaterialAddOnChargesAmount { get; set; }

        public ItemChargeModel MaterialProfitMargin { get; set; }
        public decimal MaterialProfitMarginAmount { get; set; }

        public decimal MaterialSellingCost { get; set; }

        public ItemChargeModel MaterialDiscount { get; set; }
        public decimal MaterialDiscountAmount { get; set; }
        
        public GST_ChargesModel MaterialGST { get; set; }


        public decimal MaterialNetRate { get; set; }
        public decimal MaterialSupplyAmount { get; set; }
        #endregion

        #region INSTALLATION

        public ItemChargeModel InstallationRate { get; set; }
        public decimal InstallationRateAmount { get; set; }

        public ItemChargeModel InstallationAddOnCharges { get; set; }
        public decimal InstallationAddOnChargesAmount { get; set; }

        public ItemChargeModel InstallationProfitMargin { get; set; }
        public decimal InstallationProfitMarginAmount { get; set; }

        public decimal InstallationSellingCost { get; set; }

        public ItemChargeModel InstallationDiscount { get; set; }
        public decimal InstallationDiscountAmount { get; set; }

        public GST_ChargesModel InstallationGST { get; set; }

        public decimal InstallationNetRate { get; set; }
        public decimal InstallationAmount { get; set; }

        #endregion

    }
    
    public class GST_ChargesModel
    {
        public decimal SGST_PERCENT { get; set; }
        public decimal SGST_AMOUNT { get; set; }

        public decimal CGST_PERCENT { get; set; }
        public decimal CGST_AMOUNT { get; set; }

        public decimal IGST_PERCENT { get; set; }
        public decimal IGST_AMOUNT { get; set; }

        public decimal GST_TOTAL_AMOUNT { get { return SGST_AMOUNT + CGST_AMOUNT + IGST_AMOUNT; } }

        public GST_ChargesModel()
        {
            SGST_PERCENT = CGST_PERCENT = IGST_PERCENT =  0;
            SGST_AMOUNT = CGST_AMOUNT = IGST_AMOUNT = 0;
        }

    }

    public class ItemChargeModel
    {
        public ITEM_CHARGE_TYPE ItemChargeType { get; set; }
        public decimal ItemChargeValue { get; set; }
    }

    public enum SALES_QUOTATION_BOQ_CHARGES_TYPE
    {
        NONE=0,
        ON_ENTIRE_BOQ =1,
        ON_ENTIRE_SHEET = 2,
        ON_PARENT_ITEMS=3,
        ON_CHILD_ITEMS=4
    }

    public class SalesQuotationBOQExportConfigurationModel
    {
        public bool ExportParentItemsOnly { get; set; }
        public bool ExportParentAndChildItems { get; set; }

        public bool IncludeMaterialSupplyCharges { get; set; }
        public bool IncludeInstallationCharges { get; set; }

        public SalesQuotationBOQExportConfigurationModel()
        {
            this.ExportParentItemsOnly = true;
            this.ExportParentAndChildItems = false;
            this.IncludeMaterialSupplyCharges = true;
            this.IncludeInstallationCharges = true;
        }
    }

    //public class SalesQuotationBOQConfigurationModel
    //{
    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE MATERIAL_SUPPLY_ADD_ON_CHARGES { get; set; }
    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE MATERIAL_SUPPLY_PROFIT_MARGIN_CHARGES { get; set; }
    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE MATERIAL_SUPPLY_DISCOUNT_CHARGES { get; set; }
    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE MATERIAL_SUPPLY_GST_CHARGES { get; set; }

    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE INSTALLATION_ADD_ON_CHARGES { get; set; }
    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE INSTALLATION_PROFIT_MARGIN_CHARGES { get; set; }
    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE INSTALLATION_DISCOUNT_CHARGES { get; set; }
    //    public SALES_QUOTATION_BOQ_CHARGES_TYPE INSTALLATION_GST_CHARGES { get; set; }

    //    public SalesQuotationBOQConfigurationModel()
    //    {
    //        MATERIAL_SUPPLY_ADD_ON_CHARGES = SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_CHILD_ITEMS;
    //        MATERIAL_SUPPLY_PROFIT_MARGIN_CHARGES = SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_PARENT_ITEMS;
    //        MATERIAL_SUPPLY_DISCOUNT_CHARGES = SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_ENTIRE_BOQ;
    //        MATERIAL_SUPPLY_GST_CHARGES = SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_PARENT_ITEMS;
    //        INSTALLATION_ADD_ON_CHARGES = INSTALLATION_PROFIT_MARGIN_CHARGES = INSTALLATION_DISCOUNT_CHARGES = INSTALLATION_GST_CHARGES = SALES_QUOTATION_BOQ_CHARGES_TYPE.NONE;
    //    }
    //}
        
}
