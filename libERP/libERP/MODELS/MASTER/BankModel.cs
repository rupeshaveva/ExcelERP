using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.MASTER
{
    public class BankBranchModel
    {
        public bool IsActive { get; set; }
        public int BankBranchID { get; set; }
        public int BankID { get; set; }
        public string BankBranchName { get; set; }
        public string BankBranchAddress { get; set; }
        public string BankBranchLocation{ get; set; }
        public string IFSCCode{ get; set; }
        public string SearchText { get { return this.BankBranchName + " " + this.BankBranchAddress + " " + this.BankBranchLocation + this.IFSCCode; } }

    }
}
