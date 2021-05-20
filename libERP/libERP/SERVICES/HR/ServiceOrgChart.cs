using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.SERVICES.HR
{
    public class ServiceOrgChart : DefaultService 
    {
        public ServiceOrgChart(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceOrgChart()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

       
    }
}
