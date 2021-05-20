using libERP.MODELS.COMMON;
using libERP.MODELS.CRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.SERVICES.COMMON
{
    public delegate void PageSelectionChangedEventHandler(Object sender, EventArguementModel e);
    public delegate void UpdateProgressEventHandler(Object sender, ProgressEventArguementModel e);
    
    #region CRM 
    public class BOQItemChargesChangedEventArgs
    {
        public int ITEM_INDEX { get; set; }
    }
    public delegate void BOQItemChargesChangedEventHandler(Object sender, BOQItemChargesChangedEventArgs e);
    public delegate void BOQSheetChangedEventHandler(Object sender);
    public delegate void SalesQuotationBOQSummaryChangedEventHandler(Object sender, SalesQuotationBOQSummary summary);
    public delegate void SalesOrderBOQSummaryChangedEventHandler(Object sender, SalesOrderBOQSummary summary);
    #endregion

    #region HR 
    public delegate void ImportAttendanceRecordStartEventHandler(Object sender, EventArguementModel e);
    public delegate void ImportAttendanceRecordEndEventHandler(Object sender, EventArguementModel e);

    public delegate void SalaryGenerationForEmployeeStartedEventHandler(Object sender, EventArguementModel e);
    public delegate void SalaryGenerationForEmployeeEndEventHandler(Object sender, EventArguementModel e);

    public delegate void EmployeeLeaveConfigurationCompletedEventHandler(Object sender, EventArguementModel e);

    public delegate void LeaveRegisterPreparationForEmployeeCompletedEventHandler(Object sender, EventArguementModel e);

    #endregion

}
