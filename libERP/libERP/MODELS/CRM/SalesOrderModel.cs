using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.CRM
{
    public class SalesOrderModel
    {
        public string SONo { get; set; }
        public DateTime? SODate { get; set; }
        public string SOStatus { get; set; }
        public string ProjectName { get; set; }
        public string POSource { get; set; }
        public string PONumber { get; set; }

        public DateTime? POReceivedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ClientType { get; set; }
        public string ClientName { get; set; }

        public string SiteCity { get; set; }
        public string BillAddress { get; set; }

        public string OrderStatus { get; set; }
        public string SiteAddress { get; set; }

        public string VerbalLOI { get; set; }
        public string LOI { get; set; }

        public string WorkOrder { get; set; }
        public DateTime? VerbalLOIExpectedDate { get; set; }

        public DateTime? VerbalLOIActualDate { get; set; }

        public DateTime? LOIExpectedDate { get; set; }

        public DateTime? LOIActualDate { get; set; }

        public DateTime? WorkOrderExpectedDate { get; set; }

        public DateTime? WorkOrderActualDate { get; set; }

        public string TotalAmount { get; set; }
        public string AmountInWords { get; set; }

        public string Remarks { get; set; }
    }
    public class SalesOrderModelm
    {
        public int PK_SalesOrderID { get; set; }
        public string SalesOrderNo { get; set; }
        public System.DateTime SalesOrderDate { get; set; }
        public int FK_POSource { get; set; }
        public int FK_SalesOrderStatus { get; set; }
        public int FK_SalesOrderType { get; set; }
        public Nullable<decimal> MaterialSupplyTotalAmount { get; set; }
        public Nullable<int> MaterialSupplyDiscountType { get; set; }
        public Nullable<decimal> MaterialSupplyDiscountValue { get; set; }
        public Nullable<decimal> MaterialSupplyDiscountamount { get; set; }
        public Nullable<decimal> MaterialSupplySGSTPercent { get; set; }
        public Nullable<decimal> MaterialSupplyCGSTPercent { get; set; }
        public Nullable<decimal> MaterialSupplyIGSTPercent { get; set; }
        public Nullable<decimal> MaterialSupplySGSTAmount { get; set; }
        public Nullable<decimal> MaterialSupplyCGSTAmount { get; set; }
        public Nullable<decimal> MaterialSupplyIGSTAmount { get; set; }
        public Nullable<decimal> MaterialSupplyFinalAmount { get; set; }
        public Nullable<decimal> InstallationTotalAmount { get; set; }
        public Nullable<int> InstallationDiscountType { get; set; }
        public Nullable<decimal> InstallationDiscountValue { get; set; }
        public Nullable<decimal> InstallationDiscountAmount { get; set; }
        public Nullable<decimal> InstallationSGSTPercent { get; set; }
        public Nullable<decimal> InstallationCGSTPercent { get; set; }
        public Nullable<decimal> InstallationIGSTPercent { get; set; }
        public Nullable<decimal> InstallationSGSTAmount { get; set; }
        public Nullable<decimal> InstallationCGSTAmount { get; set; }
        public Nullable<decimal> InstallationIGSTAmount { get; set; }
        public Nullable<decimal> InstallationFinalAmount { get; set; }
        public Nullable<decimal> OrderFinalAmount { get; set; }
        public string MaterialSupplyPONo { get; set; }
        public Nullable<System.DateTime> MaterialSupplyPODate { get; set; }
        public Nullable<int> MaterialSupplyPOValidDays { get; set; }
        public Nullable<System.DateTime> MaterialSupplyPOExpiryDate { get; set; }
        public string InstallationServicePONo { get; set; }
        public Nullable<System.DateTime> InstallationServicePODate { get; set; }
        public Nullable<int> InstallationServicePOValidDays { get; set; }
        public Nullable<System.DateTime> InstallationServicePOExpiryDate { get; set; }
        public Nullable<int> FK_QuotationID { get; set; }
        public int FK_ClientID { get; set; }
        public Nullable<int> FK_ProjectID { get; set; }
        public int FK_BranchID { get; set; }
        public int FK_YearID { get; set; }
        public int FK_CompanyID { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> FK_ApprovedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<int> FK_BOQRepresentativeID { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDateTime { get; set; }

        public bool IsApproved { get; set; }
    }

    }



