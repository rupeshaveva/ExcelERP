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
    
    public partial class vEmployee
    {
        public int PK_EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int FK_EmploymentTypeID { get; set; }
        public string EmploymentDesc { get; set; }
        public Nullable<int> FK_DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Nullable<int> fk_UL_Cat_Id { get; set; }
        public string CategoryDesc { get; set; }
        public Nullable<int> FK_DesignationId { get; set; }
        public string DesignationDesc { get; set; }
        public int FK_CompanyID { get; set; }
        public int FK_BranchID { get; set; }
        public int FK_YearID { get; set; }
    }
}
