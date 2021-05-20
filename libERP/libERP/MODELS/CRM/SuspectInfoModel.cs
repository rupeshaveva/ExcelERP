
using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.CRM
{
    public class SuspectingInfoModel
    {
        public APP_ENTITIES Entity { get; set; }
        public int PKId { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDiscription { get; set; }
        public int ContentLength { get { return (CategoryDiscription==null) ? 0: CategoryDiscription.Length; }  }
    }
}
