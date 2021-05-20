using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.INVENTORY_ITEMS
{
    public class AssemblyParentItem
    {
        public bool Selected { get; set; }
        public int ItemID { get; set; }
        public string ItemDescription { get; set; }
        public decimal DefaultQTY { get; set; }
        public bool IsAssembly { get; set; }

    }
}
