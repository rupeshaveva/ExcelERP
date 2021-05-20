using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.COMMON
{
    public class USER_SESSION
    {
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public int UserID { get; set; }
        public int EmployeeID { get; set; }

        public string EmailAddress { get; set; }


        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public int FinYearID { get; set; }
        public string FinanicalYearText { get; set; }

        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public string ShiftStartTime { get; set; }
        public string ShiftEndTime { get; set; }
        
    }
}
