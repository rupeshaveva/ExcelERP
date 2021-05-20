using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.HR
{
    public class DesignationwiseSalaryHeadModel
    {
        public bool IsSelected { get; set; }
        public int ID { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public EMPLOYMENT_TYPE EmploymentType { get; set; }
        public int SalaryHeadID { get; set; }
        public string SalaryHeadName { get; set; }
        public ITEM_CHARGE_TYPE ApplicableChargesType { get; set; }
        public decimal ApplicableChargesValue { get; set; }
        public string ApplicableChargesAsString
        {
            get
            {
                string str = string.Empty;
                if (this.ApplicableChargesType == ITEM_CHARGE_TYPE.PERCENTAGE)
                {
                    str = string.Format("{0:0.00}%", this.ApplicableChargesValue);
                }
                else
                {
                    str = string.Format("Rs. {0:0.00}", this.ApplicableChargesValue);
                }
                return str;
            }
        }
        public decimal SalaryHeadAmount { get; set; }

        public string SearchString
        {
            get
            {
                return string.Format("{0}", SalaryHeadName.ToString());
            }
        }

    }
}
