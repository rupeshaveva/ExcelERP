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
    
    public partial class TBL_MP_CRM_SM_DocumentHistory
    {
        public int DocumentHistoryID { get; set; }
        public int AttachmentID { get; set; }
        public Nullable<int> EntityType { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateDatetime { get; set; }
    }
}