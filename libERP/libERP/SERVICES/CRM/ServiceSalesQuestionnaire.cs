using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.CRM
{
    public class ServiceSalesQuestionnaire: DefaultService
    {
        public int QUESTION_CATEGORY_MASTER_ID = 0;
        public int QUESTION_RELATEDTO_MASTER_ID = 0;
        public ServiceSalesQuestionnaire() { _dbContext = new EXCEL_ERP_TESTEntities(); PopulateQuestionnairePublicVariables(); }
        public ServiceSalesQuestionnaire(EXCEL_ERP_TESTEntities conn) { _dbContext = conn; PopulateQuestionnairePublicVariables(); }
        private void PopulateQuestionnairePublicVariables()
        {
            try
            {
                // POPULATING SO TYPES
                QUESTION_CATEGORY_MASTER_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuestionMasterCategoryID).FirstOrDefault().DEFAULT_VALUE;
                QUESTION_RELATEDTO_MASTER_ID = _dbContext.APP_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.QuestionMasterRelatedToCategoryID).FirstOrDefault().DEFAULT_VALUE;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuestionnaire::PopulateQuestionnairePublicVariables", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         public TBL_MP_CRM_SalesQuestionnaire GetQuestionnaireDBRecord(int qID)
        {
            TBL_MP_CRM_SalesQuestionnaire model = null;
            try
            {
                model = _dbContext.TBL_MP_CRM_SalesQuestionnaire.Where(x => x.PK_QuestionnaireID == qID).FirstOrDefault();
            }

            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuestionnaire::GetQuestionnaireDBRecord" +
                    "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewQuestionnaire(TBL_MP_CRM_SalesQuestionnaire model)
        {
            int newID = 0;
            try
            {
                model.IsDeleted = false;
                _dbContext.TBL_MP_CRM_SalesQuestionnaire.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_QuestionnaireID;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuestionnaire::AddNewQuestionnaire", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return newID;
        }
        public bool UpdateQuestionnaire(TBL_MP_CRM_SalesQuestionnaire model)
        {
            bool result = false;
            try
            {
                TBL_MP_CRM_SalesQuestionnaire dbModel = _dbContext.TBL_MP_CRM_SalesQuestionnaire.Where(x => x.PK_QuestionnaireID == model.PK_QuestionnaireID).FirstOrDefault();
                dbModel = model;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuestionnaire::UpdateQuestionnaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public List<SelectListItem> GetAllQuestionnaire(int catID, int relationID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_CRM_SalesQuestionnaire.AsEnumerable()
                       where xx.FK_CategoryID == catID && xx.FK_RelatedToID == relationID && xx.IsDeleted==false
                       select new SelectListItem()
                       {
                           ID = xx.PK_QuestionnaireID,
                           Description = string.Format("QUESTION:\n{0}\n\nIMPLECATION:\n{1}\n\nSOLUTION:\n{2}\n",
                                            xx.Question, xx.Implication, xx.Solution)
                       }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuestionnaire::GetAllQuestionnaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public bool DeleteRelatedToQuestionnaire(int quesID, int deletedBy)
        {
            try
            {
                TBL_MP_Master_UserList model = _dbContext.TBL_MP_Master_UserList.Where(x => x.pk_UserListId == quesID).FirstOrDefault();
                if (model != null)
                {
                    model.IsActive = false;
                    //model.IsDeleted = true;
                    //model.DeletedBy = deletedBy;
                    //model.DeleteDateTime = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuestionnaire::DeleteRelatedToQuestionnaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        public bool DeleteQuestionnaire(int questionID, int deletedBy)
        {
            try
            {
                TBL_MP_CRM_SalesQuestionnaire model = _dbContext.TBL_MP_CRM_SalesQuestionnaire.Where(x => x.PK_QuestionnaireID == questionID).FirstOrDefault();
                if (model != null)
                {

                    model.IsDeleted = true;
                    model.DeletedBy = deletedBy;
                    model.DeleteDateTime = AppCommon.GetServerDateTime();
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuestionnaire::DeleteQuestionnaire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
    }
}
