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
    
    public partial class TBL_MP_HR_HolidaysAndWeekOff
    {
        public int PK_HolidayID { get; set; }
        public int FK_YearID { get; set; }
        public System.DateTime HolidayDate { get; set; }
        public int HolidayType { get; set; }
        public string Remarks { get; set; }
    }
}
