
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.CRM
{
    public class LeadMasterInfoModel
    {
        public string LeadNo { get; set; }
        public DateTime? LeadDate { get; set; }
        public string LeadStatus { get; set; }
        public string LeadStatusDescription { get; set; }

        public string LeadName { get; set; }
        public string EmailId { get; set; }
        public string WebSite { get; set; }

        public string LeadRequirement { get; set; }
        public string LeadSource { get; set; }

        public string EstimatedValue { get; set; }
        public string EstimatedValueCurrency { get; set; }
        public DateTime? NextFollowUpDate { get; set; }

        public string GeneratedBy { get; set; }
        public string AssignedTo { get; set; }

        public string ProjectSector { get; set; }

        public string CreationInfo { get; set; }
        public string ModificationInfo { get; set; }

        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }


    } 
}
