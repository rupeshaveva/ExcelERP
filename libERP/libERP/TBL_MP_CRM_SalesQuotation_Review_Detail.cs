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
    
    public partial class TBL_MP_CRM_SalesQuotation_Review_Detail
    {
        public int PK_ReviewDetailID { get; set; }
        public int FK_ReviewID { get; set; }
        public int Entity_TYPE { get; set; }
        public int Entity_ID { get; set; }
        public string Remarks { get; set; }
    
        public virtual TBL_MP_CRM_SalesQuotation_Review TBL_MP_CRM_SalesQuotation_Review { get; set; }
    }
}
