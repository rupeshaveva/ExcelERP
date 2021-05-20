using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.COMMON
{
    public class ContactInfoModel
    {
        public int ContactID { get; set; }
        public int CompanyID { get; set; }

        public string ContactType { get; set; }

        public string ContactName {get; set; }
        public string ContactAddress { get; set; }

        public string TelephoneNo { get; set; }
        public string AlternateTelephoneNo { get; set; }
        public string MobileNumber { get; set; }
        public string AlternateMobileNumber { get; set; }
        public string FAXNumber { get; set; }

        public string EmailAddress { get; set; }

        public int? DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public int? DesignationID { get; set; }
        public string DesignationName { get; set; }


        public string DisplayColumn1 {
            get
            {
                return string.Format("{0}\n{1}{2}\n{3}",this.ContactName, this.DesignationName, this.DepartmentName, this.ContactAddress );
            }
        }
        public string DisplayColumn2
        {
            get
            {
                return string.Format("email: {0}\nPhone: {1},{2}\nMobile: {3},{4}\nFAX: {5}", this.EmailAddress, this.TelephoneNo,this.AlternateTelephoneNo, this.MobileNumber, this.AlternateMobileNumber, this.FAXNumber);
            }
        }


        public string SearchColumn { get { return this.DisplayColumn1 + this.DisplayColumn2; } }



    }

    public class SelectContactModel
    {
        public bool Selected { get; set; }
        public int ContactID { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
