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
    
    public partial class CompanyMaster
    {
        public int pk_CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string Company_name { get; set; }
        public Nullable<int> fk_CountryID { get; set; }
        public Nullable<int> fk_state { get; set; }
        public Nullable<int> fk_City { get; set; }
        public Nullable<int> fk_area { get; set; }
        public string Email { get; set; }
        public string GST_NO { get; set; }
        public string PLA { get; set; }
        public string ECCNo { get; set; }
        public string TinNo { get; set; }
        public string PANNo { get; set; }
        public string RangeNO { get; set; }
        public string RangeAdd { get; set; }
        public string RangeCode { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionNo { get; set; }
        public string DivisionAdd { get; set; }
        public string Commissionerate { get; set; }
        public string CommissionerateAdd { get; set; }
        public string WebAdd { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string FaxNo { get; set; }
        public string PinCode { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public string LogoPath { get; set; }
        public Nullable<int> MaxID { get; set; }
        public string Abbreviation { get; set; }
        public byte[] Logo_Image_Binary { get; set; }
        public Nullable<int> FK_LicencedCustomerID { get; set; }
        public string IEC_CODE { get; set; }
        public byte[] LogoImage { get; set; }
        public string CINNO { get; set; }
        public byte[] ext_Logo { get; set; }
        public string ImportExcelLogo { get; set; }
    }
}
