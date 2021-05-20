using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{
   public class ServiceCompanyMaster : DefaultService
    {
        public ServiceCompanyMaster(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceCompanyMaster()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        public bool UpdateCompanyInfo(TBL_MP_Admin_Company_Master model)
        {
            bool result = false;
            bool exists = false;
            try
            {
                TBL_MP_Admin_Company_Master dbModel = _dbContext.TBL_MP_Admin_Company_Master.FirstOrDefault();
                if (dbModel == null)
                    dbModel = new TBL_MP_Admin_Company_Master();
                else
                    exists = true;
                //gather into properties
                dbModel.CompanyCode = model.CompanyCode;
                dbModel.Company_name = model.Company_name;
                dbModel.Abbreviation = model.Abbreviation;
                dbModel.FK_CountryID = model.FK_CountryID;
                dbModel.FK_StateID = model.FK_StateID;
                dbModel.FK_CityID = model.FK_CityID;
                dbModel.FK_AreaID = model.FK_AreaID;
                dbModel.Email = model.Email;
                dbModel.Website = model.Website;
                dbModel.PhoneNo = model.PhoneNo;
                dbModel.FaxNo = model.FaxNo;
                dbModel.ECC_NO = model.ECC_NO;
                dbModel.TIN_NO = model.TIN_NO;

                dbModel.PAN_NO = model.PAN_NO;
                dbModel.GST_NO = model.IEC_CODE;
                dbModel.IEC_CODE = model.IEC_CODE;
                dbModel.ShiftTimeFrom = model.ShiftTimeFrom;
                dbModel.ShiftTimeTo = model.ShiftTimeTo;
 
                if (!exists)
                {
                    _dbContext.TBL_MP_Admin_Company_Master.Add(dbModel);
                }

                _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCompanyMaster::UpdateCompanyInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public TBL_MP_Admin_Company_Master GetCompanyInfo()
        {
            TBL_MP_Admin_Company_Master model = null;
            try
            {
                model = _dbContext.TBL_MP_Admin_Company_Master.FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCompanyMaster::GetCompanyInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
    }
}
