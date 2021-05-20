using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{
    public class ServiceDesignationwiseDefaultRole : DefaultService
    {
        public ServiceDesignationwiseDefaultRole(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceDesignationwiseDefaultRole()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public int? GetDefaultRoleIdForDesignation(int designationID)
        {
            int? roleID = null;
            try
            {
                DesignationwiseDefaultRole model = _dbContext.DesignationwiseDefaultRoles.Where(x => x.FK_DesignationID == designationID).FirstOrDefault();
                if (model != null)
                    roleID = model.Default_RoleID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceDesignationwiseDefaultRole::GetDefaultRoleIdForDesignation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return roleID;
        }


    }
}
