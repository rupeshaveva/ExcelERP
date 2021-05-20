using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.ADMIN
{
    public class RoleModuleForm
    {
        public bool Selected { get; set; }
        public string  Description { get; set; }
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int ModuleID { get; set; }
        public int FormID { get; set; }
        public string SearchString { get { return string.Format("{0}", Description.ToUpper()); } }
    }

    
}
