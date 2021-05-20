using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.PROJECTS
{
    public class ProjectCheckListModel
    {
        public List<ProjectChecklistItem> LIST_ITEMS { get; set; }
        public ProjectCheckListModel() { LIST_ITEMS = new List<ProjectChecklistItem>(); }
    }

    public class ProjectChecklistItem
    {
        public string  SerialNo { get; set; }
        public string Description { get; set; }
        public bool YES { get; set; }
        public bool NO { get; set; }
        public bool NA { get; set; }
        public string Remark { get; set; }
        public bool  IsChecklistItem { get; set; }

    }
    public class ProjectGeneralInfo
    {
        public int ProjectID { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int BillingClientID { get; set; }
        public int BillingClientAddressID { get; set; }
        public int SiteClientID { get; set; }
        public int SiteClientAddressID { get; set; }
       // public int CompanyAddressID { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

    }

}
