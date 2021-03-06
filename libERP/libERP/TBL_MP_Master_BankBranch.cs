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
    
    public partial class TBL_MP_Master_BankBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_MP_Master_BankBranch()
        {
            this.TBL_MP_Master_Employee = new HashSet<TBL_MP_Master_Employee>();
            this.Tbl_MP_Master_Party_BankDetail = new HashSet<Tbl_MP_Master_Party_BankDetail>();
        }
    
        public int PK_BankBranchID { get; set; }
        public int FK_BankID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public string IFSCCode { get; set; }
        public int FK_CountryID { get; set; }
        public int FK_StateID { get; set; }
        public int FK_CityID { get; set; }
        public bool IsActive { get; set; }
    
        public virtual TBL_MP_Master_Bank TBL_MP_Master_Bank { get; set; }
        public virtual TBL_MP_Master_City TBL_MP_Master_City { get; set; }
        public virtual TBL_MP_Master_Country TBL_MP_Master_Country { get; set; }
        public virtual TBL_MP_Master_State TBL_MP_Master_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_MP_Master_Employee> TBL_MP_Master_Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_MP_Master_Party_BankDetail> Tbl_MP_Master_Party_BankDetail { get; set; }
    }
}
