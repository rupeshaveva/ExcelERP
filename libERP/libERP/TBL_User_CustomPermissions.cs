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
    
    public partial class TBL_User_CustomPermissions
    {
        public int pk_CustomPermissionID { get; set; }
        public int fk_EmployeeId { get; set; }
        public int fk_ModuleId { get; set; }
        public int fk_FormId { get; set; }
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
    
        public virtual TBL_MP_Master_Employee TBL_MP_Master_Employee { get; set; }
        public virtual Tbl_MP_Master_Module Tbl_MP_Master_Module { get; set; }
        public virtual Tbl_MP_Master_Module_Forms Tbl_MP_Master_Module_Forms { get; set; }
    }
}
