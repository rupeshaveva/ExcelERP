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
    
    public partial class Tbl_MP_Master_Party_BankDetail
    {
        public int PK_PartyBankID { get; set; }
        public int FK_PartyID { get; set; }
        public int FK_BankID { get; set; }
        public int FK_BankBranchID { get; set; }
        public string AccountNo { get; set; }
        public int FK_AccountType { get; set; }
        public bool IsActive { get; set; }
    
        public virtual TBL_MP_Admin_UserList TBL_MP_Admin_UserList { get; set; }
        public virtual TBL_MP_Master_Bank TBL_MP_Master_Bank { get; set; }
        public virtual TBL_MP_Master_BankBranch TBL_MP_Master_BankBranch { get; set; }
        public virtual Tbl_MP_Master_Party Tbl_MP_Master_Party { get; set; }
    }
}
