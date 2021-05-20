using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.COMMON
{
    public class FollowupModel
    {
        public int FollowupID { get; set; }
        public DateTime EntryDate { get; set; }
        public string ActionName { get; set; }
        public string ActionDescription { get { return string.Format("{0}\n{1}", this.ActionName, this.EntryDate.ToString("dd/MM/yy hh:mmtt")); } }
        public string Subject { get; set; }
        public string ReferenceInfo { get; set; }
        public string ActionPlanResult { get; set; }
        public string FollowUpStatus { get; set; }

        
    }
}
