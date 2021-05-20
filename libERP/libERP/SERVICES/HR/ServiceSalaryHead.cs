using libERP.MODELS;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP;
namespace libERP.SERVICES.HR
{
    public class ServiceSalaryHead : DefaultService
    {
        public ServiceSalaryHead(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceSalaryHead()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }


        public List<SalaryHeadModel> GetAllSalaryHeads()
        {
            
            List <SalaryHeadModel> lst = new List<SalaryHeadModel>();
           
            try
            {
                List<SelectListItem> lstHeads = (new ServiceMASTERS()).GetAllSalaryHeads();
                List<SelectListItem> lstNature = (new ServiceMASTERS()).GetAllSalaryHeadsNature();
                List<SelectListItem> lstTypes = (new ServiceMASTERS()).GetAllSalaryHeadsType();
                SelectListItem selItem = null;
                
                List<libERP.TBl_MP_HR_SalaryHead> dbList = _dbContext.TBl_MP_HR_SalaryHead.Where(x=>x.IsActive==true).ToList();
                foreach (TBl_MP_HR_SalaryHead dbItem in dbList)
                {
                    SalaryHeadModel model = new SalaryHeadModel();
                    model.ID = dbItem.pK_SH_ID;
                    //SALARY HEAD INFO INCLUDING ID & NAME
                    model.SalaryHeadID = (int)dbItem.fK_Usrlst_SH_ID;
                    selItem = lstHeads.Where(x => x.ID == model.SalaryHeadID).FirstOrDefault();  //&& x.IsActive==true
                    if (selItem != null) model.SalaryHead = selItem.Description;

                    //SALARY NATURE INFO INCLUDING ID & NAME
                    model.SalaryHeadNatureID = (int)dbItem.fk_Usrlst_HdNature_ID;
                    selItem = lstNature.Where(x => x.ID == model.SalaryHeadNatureID).FirstOrDefault();
                    if (selItem != null) model.SalaryHeadNature = selItem.Description;

                    //SALARY TYPE INFO INCLUDING ID & NAME
                    model.SalaryHeadTypeID= (int)dbItem.fk_Usrlst_HdrType_ID;
                    selItem = lstTypes.Where(x => x.ID == model.SalaryHeadTypeID).FirstOrDefault();
                    if (selItem != null) model.SalaryHeadType = selItem.Description;
                
                    model.Sequence = dbItem.Sequence;
                    model.IsActive = dbItem.IsActive;

                    lst.Add(model);

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalaryHead::GetAllSalaryHeads", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lst;
        }
        public TBl_MP_HR_SalaryHead GetSalaryHeadDbRecord(int HeadID)
        {
            return _dbContext.TBl_MP_HR_SalaryHead.Where(x => x.pK_SH_ID == HeadID).FirstOrDefault();
        }

        public int AddNewSalaryHead(TBl_MP_HR_SalaryHead model)
        {
            int newID = 0;
            try
            {
                model.IsActive = true;
                _dbContext.TBl_MP_HR_SalaryHead.Add(model);
                _dbContext.SaveChanges();
                newID = model.pK_SH_ID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalaryHead::AddNewBankBranch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdatesalaryHead(TBl_MP_HR_SalaryHead model)
        {
            bool result = false;
            try
            {
                TBl_MP_HR_SalaryHead dbModel = _dbContext.TBl_MP_HR_SalaryHead.Where(x => x.pK_SH_ID == model.pK_SH_ID).FirstOrDefault();
                dbModel.fK_Usrlst_SH_ID = model.fK_Usrlst_SH_ID;
                dbModel.fk_Usrlst_HdrType_ID = model.fk_Usrlst_HdrType_ID;
                dbModel.fk_Usrlst_HdNature_ID = model.fk_Usrlst_HdNature_ID;
                dbModel.Sequence = model.Sequence;
                dbModel.IsActive = model.IsActive;
                  _dbContext.SaveChanges();
                result = true;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalaryHead::UpdatesalaryHead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteSalaryHead(int salaryHeadID)
        {
            bool result = true;
            try
            {
                TBl_MP_HR_SalaryHead model = _dbContext.TBl_MP_HR_SalaryHead.Where(x => x.pK_SH_ID == salaryHeadID).FirstOrDefault();
                if(model!=null) model.IsActive = false;
                TBL_MP_Admin_UserList model1 = _dbContext.TBL_MP_Admin_UserList.Where(x => x.PKID == salaryHeadID).FirstOrDefault();
                if (model1 != null) model1.IsActive = false;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalaryHead::DeleteSalaryHead", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }

        public List<TBl_MP_HR_SalaryHead> GetAllSalaryHeadsofType(int headTypeID)
        {
            try
            {
                return _dbContext.TBl_MP_HR_SalaryHead.Where(x => x.fk_Usrlst_HdrType_ID == headTypeID).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalaryHead::GetAllSalaryHeadsofType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        public List<SelectListItem> GetSelectListItemSalaryHeadsofType(int headTypeID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.vSalaryHeads where xx.SalaryHeadTypeID==headTypeID select new SelectListItem() { ID= xx.SalaryHeadID, Description= xx.SalaryHeadName}).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalaryHead::GetAllSalaryHeadsofType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }

    }
}
