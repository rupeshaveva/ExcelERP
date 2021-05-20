using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.CRM
{
    public class SalesEnquiryMaster
    {
        public string LeadNumber { get; set; }
        public string EnquiryNo { get; set; }

        public DateTime? EnquiryDate { get; set; }
        public string EnquiryStatus { get; set; }

        public string ProjectName { get; set; }
        public string ProjectSector { get; set; }

        public string EnquiryGeneratedBy { get; set; }
        public string ProjectType { get; set; }

        public string Description { get; set; }
        public string RefrenceCode { get; set; }

        public string EnquiryType { get; set; }
        public DateTime? EnquiryDueDate { get; set; }

        public string SubmissionDueDate { get; set; }
        public string SubmissionModeID { get; set; }

        public string EnquirySourceID { get; set; }
        public string ProjectStatusID { get; set; }

        public string ProjectValue { get; set; }
        public string SubmissionMode { get; set; }

        public string FromProjectValue { get; set; }

        public string ProjectCountry { get; set; }
        public string ProjectState { get; set; }

        public string ProjectCity { get; set; }
        public string ProjectStatus { get; set; }

        public string ProjectDetails { get; set; }

    }
}
