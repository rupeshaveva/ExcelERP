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
    
    public partial class TBL_MP_CRM_SM_ContactReferences
    {
        public int ReferenceID { get; set; }
        public Nullable<int> EntityType { get; set; }
        public Nullable<int> EntityID { get; set; }
        public int ContactID { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual Tbl_MP_Master_PartyContact_Detail Tbl_MP_Master_PartyContact_Detail { get; set; }
    }
}