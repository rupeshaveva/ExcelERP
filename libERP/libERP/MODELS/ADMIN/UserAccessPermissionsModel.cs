using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.ADMIN
{
    public class UserAccessPermissionsModel
    {
        public int ID { get; set; }

        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public int ModuleID { get; set; }
        public string ModuleName { get; set; }

        public int FormID { get; set; }
        public string FormName { get; set; }
        public string Permissions { get; set; }

        public string SearchString { get { return (string.Format("{0} {1} {2} {3}", this.RoleName, ModuleName, FormName, Permissions)).ToUpper(); } }

    }
}
