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
    
    public partial class TBL_MP_Master_City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_Master_City()
        {
            this.TBL_MP_Admin_Branch_Master = new HashSet<TBL_MP_Admin_Branch_Master>();
            this.TBL_MP_CRM_SalesEnquiry = new HashSet<TBL_MP_CRM_SalesEnquiry>();
            this.TBL_MP_Master_BankBranch = new HashSet<TBL_MP_Master_BankBranch>();
            this.Tbl_MP_Master_Party_Address = new HashSet<Tbl_MP_Master_Party_Address>();
        }
    
        public int pk_CityId { get; set; }
        public int fk_CountryId { get; set; }
        public int fk_StateId { get; set; }
        public string STDCode { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> FK_CompanyID { get; set; }
        public Nullable<int> FK_BranchID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Admin_Branch_Master> TBL_MP_Admin_Branch_Master { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_CRM_SalesEnquiry> TBL_MP_CRM_SalesEnquiry { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_BankBranch> TBL_MP_Master_BankBranch { get; set; }
        public virtual TBL_MP_Master_Country TBL_MP_Master_Country { get; set; }
        public virtual TBL_MP_Master_State TBL_MP_Master_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MP_Master_Party_Address> Tbl_MP_Master_Party_Address { get; set; }
    }
}
