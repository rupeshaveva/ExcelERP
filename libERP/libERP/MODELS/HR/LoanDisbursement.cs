using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.HR
{
    // model banana hai naa?

    public class LoanDisbursementModel
    {
        public LoanDisbursementModel()
        {
            this.DisbursementID = 0;
            this.DisbursementDate = DateTime.Now;
            this.AmountDue = this.AmountGiven = this.AmountReceived = 0;

        }
        public int DisbursementID { get; set; }
        public DateTime DisbursementDate { get; set; }
        public string EmployeeInfo { get; set; }
        public string LoanInfo { get; set; }
        public string DisbursementInfo { get; set; }
        public decimal AmountGiven { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal AmountDue { get; set; }
        public string StatusInfo { get; set; }
        public string SearchText { get { return string.Format("{0} {1} {2} {3} {4}",this.DisbursementDate,this.EmployeeInfo,this.LoanInfo,this.DisbursementInfo,this.AmountGiven); } }

    }
}
