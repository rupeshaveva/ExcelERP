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
    
    public partial class TBL_MP_Master_RoleForm
    {
        public int PK_RoleFormID { get; set; }
        public Nullable<int> FK_BranchId { get; set; }
        public int FK_RoleID { get; set; }
        public Nullable<int> FK_ModuleId { get; set; }
        public int FK_FormId { get; set; }
        public bool CanAddNew { get; set; }
        public bool CanDelete { get; set; }
        public bool CanModify { get; set; }
        public bool CanView { get; set; }
        public bool CanPrint { get; set; }
        public bool CanPrepare { get; set; }
        public bool CanCheck { get; set; }
        public bool CanAuthorize { get; set; }
        public bool CanApprove { get; set; }
        public Nullable<int> FK_ApprovalLevel { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDatetime { get; set; }
        public string DeleteRemarks { get; set; }
    
        public virtual Tbl_MP_Master_Module Tbl_MP_Master_Module { get; set; }
        public virtual Tbl_MP_Master_Module_Forms Tbl_MP_Master_Module_Forms { get; set; }
        public virtual TBL_MP_Master_Role TBL_MP_Master_Role { get; set; }
    }
}
