using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.CRM
{
    public class TermsAndConditionModel
    {
        public int TermID { get; set; }
        public int TitleID { get; set; }
        public string TermTitle { get; set; }
        public string TermDescription { get; set; }
        public int Sequence{ get; set; }
        public bool IsActive { get; set; }

        public string SearchText { get { return string.Format("{0} {1}", this.TermTitle, this.TermDescription); } }

    }
}
