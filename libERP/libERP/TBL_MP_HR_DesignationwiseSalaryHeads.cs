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
    
    public partial class TBL_MP_HR_DesignationwiseSalaryHeads
    {
        public int PK_ID { get; set; }
        public int FK_DesignationID { get; set; }
        public int FK_EmploymentTypeID { get; set; }
        public int FK_SalaryHeadID { get; set; }
        public int ApplicableChargesType { get; set; }
        public decimal ApplicableChargesValue { get; set; }
        public decimal SalaryHeadAmount { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual TBL_MP_Admin_UserList TBL_MP_Admin_UserList { get; set; }
    }
}
