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
    
    public partial class TBL_MP_Master_Inventory_Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_Master_Inventory_Category()
        {
            this.TBL_MP_Master_Inventory_Level = new HashSet<TBL_MP_Master_Inventory_Level>();
            this.TBL_MP_Master_Item_Suppliers = new HashSet<TBL_MP_Master_Item_Suppliers>();
            this.TBL_MP_Master_Item = new HashSet<TBL_MP_Master_Item>();
        }
    
        public int Pk_InvCategory_ID { get; set; }
        public Nullable<int> FK_Userlist_ItemType_ID { get; set; }
        public string Inv_Category { get; set; }
        public string Category_ShortCode { get; set; }
        public string Category_Description { get; set; }
        public string HSNCode { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> FK_CompanyID { get; set; }
        public Nullable<int> FK_BranchID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_Inventory_Level> TBL_MP_Master_Inventory_Level { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_Item_Suppliers> TBL_MP_Master_Item_Suppliers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_Item> TBL_MP_Master_Item { get; set; }
    }
}