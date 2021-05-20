using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.CRM
{
    public class BOQParentItemModel
    {
        public bool HasChildItems { get; set; }
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public int UOMID { get; set; }
        public string UOMDescription { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }

        public List<BOQServiceItemModel> Services { get; set; }
        public List<BOQChildItemModel> ChildItems { get; set; }
    }

    public class BOQChildItemModel
    {
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public int UOMID { get; set; }
        public string UOMDescription { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public List<BOQServiceItemModel> Services { get; set; }

    }
    public class BOQServiceItemModel
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
    }
}
