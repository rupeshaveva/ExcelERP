using libERP.MODELS;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.MASTER
{
    public class ServiceCheckListMaster : DefaultService
    {
        public ServiceCheckListMaster() { _dbContext = new EXCEL_ERP_TESTEntities(); }
        public ServiceCheckListMaster(EXCEL_ERP_TESTEntities conn) { _dbContext = conn; }
       
        public List<SelectListItem> GetAllCheckListItemsForCheckPoint(int checkpointID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.CheckList_Master.AsEnumerable()
                       where xx.FK_CheckPointID == checkpointID
                       select new SelectListItem()
                       {
                           ID = xx.PK_ItemID,
                           Description = string.Format("{0} ({1}) ", xx.Description, (xx.IsDeleted==false) ? "Active" : "Deactivated")
                       }
                       ).ToList();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCheckListMaster::GetAllCheckListItemsForCheckPoint", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lst;
        }
        public List<SelectListItem> GetAllActiveCheckListItemsForCheckPoint(int checkpointID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.CheckList_Master.AsEnumerable()
                       where xx.FK_CheckPointID == checkpointID && xx.IsDeleted==false 
                       select new SelectListItem()
                       {
                           ID = xx.PK_ItemID,
                           Description =  xx.Description
                       }
                       ).ToList();

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCheckListMaster::GetAllActiveCheckListItemsForCheckPoint", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lst;
        }
        public CheckList_Master GetCheckListItemDBInfo(int id)
        {
            CheckList_Master model = null;
            try
            {
                model = _dbContext.CheckList_Master.Where(x => x.PK_ItemID == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCheckListMaster::GetCheckListItemDBInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public int AddNewCheckListItem(CheckList_Master model)
        {
            int newID = 0;
            try
            {
                model.IsDeleted = false;
                _dbContext.CheckList_Master.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_ItemID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCheckListMaster::AddNewCheckListItem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateCheckListItem(CheckList_Master model)
        {
            bool result = false;
            try
            {
                CheckList_Master dbModel = _dbContext.CheckList_Master.Where(x => x.PK_ItemID == model.PK_ItemID).FirstOrDefault();
                if (dbModel != null)
                {

                    dbModel.FK_CheckPointID = model.FK_CheckPointID;
                    dbModel.Description = model.Description;
                    _dbContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCheckListMaster::UpdateCheckListItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteCheckListItem(int itemID)
        {
            bool result = false;
            try
            {
                CheckList_Master dbModel = _dbContext.CheckList_Master.Where(x => x.PK_ItemID == itemID).FirstOrDefault();
                if (dbModel != null)
                {

                    dbModel.IsDeleted = true;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceCheckListMaster::DeleteCheckListItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
