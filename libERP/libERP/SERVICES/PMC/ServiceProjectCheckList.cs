using libERP.MODELS;
using libERP.MODELS.PROJECTS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.PMC
{
    public class ServiceProjectCheckList : DefaultService
    {
        public ServiceProjectCheckList(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceProjectCheckList()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
        public ProjectCheckListModel GetDefaultProjectCheckList()
        {
            ProjectCheckListModel model = new ProjectCheckListModel();
            ProjectChecklistItem item = null;
            int index = 1;
            try
            {
                List<SelectListItem> checkPoints = (new ServiceMASTERS()).GetAllActiveProjectCheckPoints();
                foreach (SelectListItem pointItem in checkPoints)
                {
                    item = new ProjectChecklistItem()
                    {
                        SerialNo = index.ToString(),
                        Description = pointItem.Description,
                        YES=false, NO=false, NA=false,
                        Remark = string.Empty,
                        IsChecklistItem = false
                    };
                    model.LIST_ITEMS.Add(item);
                    List<SelectListItem> lstCheckList = (new ServiceCheckListMaster()).GetAllActiveCheckListItemsForCheckPoint(pointItem.ID);
                    foreach (SelectListItem listItem in lstCheckList)
                    {
                        item = new ProjectChecklistItem()
                        {
                            SerialNo = string.Empty,
                            Description = listItem.Description,
                            YES = true,
                            NO = false,
                            NA = false,
                            Remark = string.Empty,
                            IsChecklistItem = true
                        };
                        model.LIST_ITEMS.Add(item);
                    }

                    index++;
                }
                // ADDING OTHERS CHECKPINT
                item = new ProjectChecklistItem()
                {
                    SerialNo = index.ToString(),
                    Description = "Others",
                    YES = true,
                    NO = false,
                    NA = false,
                    Remark = string.Empty,
                    IsChecklistItem = true
                };
                model.LIST_ITEMS.Add(item);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProjectCheckList::GetDefaultProjectCheckList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public ProjectCheckListModel GetProjectCheckListForProjectID(int projectID)
        {
            ProjectCheckListModel model = new ProjectCheckListModel();
            try
            {
                TBL_MP_PMC_Project_CheckList dbModel = _dbContext.TBL_MP_PMC_Project_CheckList.Where(x => x.FK_ProjectID == projectID).FirstOrDefault();
                if (dbModel == null)
                    model = GetDefaultProjectCheckList();
                else
                {
                    string strJSON = dbModel.ProjectChecklist;
                    model = JsonConvert.DeserializeObject<ProjectCheckListModel>(strJSON);
                }
            }
            catch (Exception ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProjectCheckList::GetProjectCheckListForProjectID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public bool UpdateProjectCheckListForProjectID(int projectID, ProjectCheckListModel model)
        {
            bool result = false;
            try
            {
                string strJSON = JsonConvert.SerializeObject(model);
                TBL_MP_PMC_Project_CheckList dbModel = _dbContext.TBL_MP_PMC_Project_CheckList.Where(x => x.FK_ProjectID == projectID).FirstOrDefault();
                if (dbModel == null)
                {
                    dbModel = new TBL_MP_PMC_Project_CheckList();
                    dbModel.FK_ProjectID = projectID;
                    dbModel.ProjectChecklist = strJSON;
                    _dbContext.TBL_MP_PMC_Project_CheckList.Add(dbModel);
                    _dbContext.SaveChanges();
                }
                else
                {
                    dbModel.ProjectChecklist = strJSON;
                    _dbContext.SaveChanges();
                }
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceProjectCheckList::UpdateProjectCheckListForProjectID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
