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
    
    public partial class TBL_MP_Master_Inventory_Level_Details
    {
        public int Pk_InvLevel_Dtls_ID { get; set; }
        public Nullable<int> Fk_Inv_Level_ID { get; set; }
        public string Inv_Level_Value { get; set; }
        public string Inv_Level_ShortCode { get; set; }
        public string Inv_Level_Description { get; set; }
        public bool IsActive { get; set; }
    
        public virtual TBL_MP_Master_Inventory_Level TBL_MP_Master_Inventory_Level { get; set; }
    }
}
