//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace libERP
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MP_CRM_SalesOrder_TermsAndConditions
    {
        public int PK_Order_TermID { get; set; }
        public int FK_SalesOrderID { get; set; }
        public Nullable<int> FK_TermTitleID { get; set; }
        public string Term_Description { get; set; }
        public int Sequence { get; set; }
        public string TermTitle { get; set; }
    
        public virtual TBL_MP_Admin_UserList TBL_MP_Admin_UserList { get; set; }
        public virtual TBL_MP_CRM_SalesOrder TBL_MP_CRM_SalesOrder { get; set; }
    }
}
