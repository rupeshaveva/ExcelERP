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
    
    public partial class TBL_MP_CRM_SalesQuotation_Attachments
    {
        public int PK_AttachmentID { get; set; }
        public int FK_SalesQuotationID { get; set; }
        public int FK_CategoryID { get; set; }
        public string Title { get; set; }
        public string AttachmentFileName { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDatetime { get; set; }
        public string DeleteRemarks { get; set; }
    
        public virtual TBL_MP_CRM_SalesQuotation TBL_MP_CRM_SalesQuotation { get; set; }
        public virtual TBL_MP_Master_UserList TBL_MP_Master_UserList { get; set; }
    }
}
