using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.HR
{
  public  class SalaryHeadModel
    {

        public int ID { get; set; }
        
        public int SalaryHeadID { get; set; }
        public string SalaryHead { get; set; }
        public int SalaryHeadNatureID { get; set; }
        public string SalaryHeadNature { get; set; }
        public int SalaryHeadTypeID { get; set; }
        public string SalaryHeadType { get; set; }
        public int Sequence { get; set; }
        public bool IsActive { get; set; }

        public string SearchText { get { return string.Format("{0} {1} {2} {3}", this.SalaryHead, this.SalaryHeadType, this.SalaryHeadNature, this.Sequence); } }
    }
}
