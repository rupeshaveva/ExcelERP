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
    
    public partial class TBL_MP_Master_Role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_Master_Role()
        {
            this.TBL_MP_Master_RoleForm = new HashSet<TBL_MP_Master_RoleForm>();
            this.TBL_MP_Master_RoleModule = new HashSet<TBL_MP_Master_RoleModule>();
        }
    
        public int PK_RoleId { get; set; }
        public string RoleNo { get; set; }
        public string RoleName { get; set; }
        public Nullable<bool> IsMandetory { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDatetime { get; set; }
        public string DeleteRemarks { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_RoleForm> TBL_MP_Master_RoleForm { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_RoleModule> TBL_MP_Master_RoleModule { get; set; }
    }
}
