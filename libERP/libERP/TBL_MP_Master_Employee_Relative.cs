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
    
    public partial class TBL_MP_Master_Employee_Relative
    {
        public int EmployeeRelationshipID { get; set; }
        public int FK_EmployeeID { get; set; }
        public int FK_UL_RelationID { get; set; }
        public string RelativeName { get; set; }
        public Nullable<System.DateTime> RelativeDOB { get; set; }
        public string Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeleteDatetime { get; set; }
    
        public virtual TBL_MP_Admin_UserList TBL_MP_Admin_UserList { get; set; }
        public virtual TBL_MP_Master_Employee TBL_MP_Master_Employee { get; set; }
    }
}