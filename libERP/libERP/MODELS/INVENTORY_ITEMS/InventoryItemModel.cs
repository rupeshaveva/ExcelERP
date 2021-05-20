using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.INVENTORY_ITEMS
{
    public class InventoryItemModel
    {

        public int ItemID { get; set; }
        public string ItemCode { get; set; }
        public string HSNCode { get; set; }
        public string ItemName { get; set; }

        public int UOMID { get; set; }
        public string UOMName { get; set; }
        public bool IsAssembly { get; set; }
        public bool IsActive { get; set; }
        public string SearchText { get { return string.Format("{0}\nCODE: {1}  HSN: {2}  UOM: {3}\n",this.ItemName.ToUpper(),  this.ItemCode.ToUpper(), this.HSNCode, this.UOMName.ToUpper()); }  }
        public InventoryItemModel() { this.ItemCode = this.HSNCode = this.ItemName = this.UOMName = string.Empty; }
    }

    public class InventoryItemSpecificationModel
    {
        public int PKSpecificationID { get; set; }
        public int InventoryLevelID { get; set; }
        public string InventoryLevelDescription { get; set; }
        public int InventoryLevelValueID { get; set; }
        public string InventoryLevelValueDescription { get; set; }

    }

    public class InventoryLevelModel
    {
        public int CategoryID { get; set; }
        public int InventoryLevelID { get; set; }
        public string InventoryLevelName { get; set; }
        public int Sequence { get; set; }
        public List<InventoryLevelDetailModel> VALUES { get; set; }
        public bool IsActive { get; set; }
    }

    public class InventoryLevelDetailModel
    {
        public int InventoryLevelID { get; set; }
        public int InventoryLevelDetailID { get; set; }
        public string InventoryLevelDetailName { get; set; }
    }


}
