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
    
    public partial class Tbl_MP_Master_Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_MP_Master_Module()
        {
            this.Tbl_MP_Master_Module_Forms = new HashSet<Tbl_MP_Master_Module_Forms>();
            this.TBL_MP_Master_RoleForm = new HashSet<TBL_MP_Master_RoleForm>();
            this.TBL_MP_Master_RoleModule = new HashSet<TBL_MP_Master_RoleModule>();
            this.TBL_User_CustomPermissions = new HashSet<TBL_User_CustomPermissions>();
        }
    
        public int pk_ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public int SequenceNo { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDatetime { get; set; }
        public string DeleteRemarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MP_Master_Module_Forms> Tbl_MP_Master_Module_Forms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_RoleForm> TBL_MP_Master_RoleForm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_RoleModule> TBL_MP_Master_RoleModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_User_CustomPermissions> TBL_User_CustomPermissions { get; set; }
    }
}
