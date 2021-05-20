using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.HR
{
   public  class ServiceDesignationWiseSalary : DefaultService
    {

        public ServiceDesignationWiseSalary(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceDesignationWiseSalary()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<DesignationwiseSalaryHeadModel> GetAllAllouncesSalaryHeadsForDesignation(int designationID, EMPLOYMENT_TYPE EmploymentType)
        {
            List<DesignationwiseSalaryHeadModel> lstAllounces = new List<DesignationwiseSalaryHeadModel>();
            try
            {
                List<SelectListItem> lstDesignations = (new ServiceMASTERS()).GetAllDesignation();
                List<SelectListItem> lstSalaryHeads = (new ServiceMASTERS()).GetAllSalaryHeads();

                int ALLOUNCE_CATAGAORY_ID = 0;
                ALLOUNCE_CATAGAORY_ID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.SalaryHeadEARNINGType).FirstOrDefault().DEFAULT_VALUE;
                List<TBl_MP_HR_SalaryHead> lstSalaryHeadsAllounces = (new ServiceSalaryHead()).GetAllSalaryHeadsofType(ALLOUNCE_CATAGAORY_ID);
                foreach (TBl_MP_HR_SalaryHead salaryHeadItem in lstSalaryHeadsAllounces)
                {
                    // GETTING ALL SALARY HEADS INTO LIST COLLECTION lstAllounces
                    DesignationwiseSalaryHeadModel model = new DesignationwiseSalaryHeadModel();
                    model.EmploymentType = EmploymentType;
                    model.DesignationID = designationID;
                    if (lstDesignations.Where(x => x.ID == designationID).FirstOrDefault() != null)
                    {
                        model.DesignationName = lstDesignations.Where(x => x.ID == designationID).FirstOrDefault().Description;
                    }
                    model.SalaryHeadID = salaryHeadItem.pK_SH_ID;
                    model.SalaryHeadName = lstSalaryHeads.Where(x => x.ID == salaryHeadItem.fK_Usrlst_SH_ID).FirstOrDefault().Description;
                    model.ApplicableChargesType = ITEM_CHARGE_TYPE.LUMPSUM;
                    model.ApplicableChargesValue = 0;
                    model.ID = 0;
                    model.SalaryHeadAmount = 0;
                    model.IsSelected = false;
                    lstAllounces.Add(model);
                }

                // UPDATE LIST COLLECTION FROM THE DATABASE
                foreach (DesignationwiseSalaryHeadModel item in lstAllounces)
                {
                    TBL_MP_HR_DesignationwiseSalaryHeads found =
                        (from xx in _dbContext.TBL_MP_HR_DesignationwiseSalaryHeads
                         where xx.FK_DesignationID == designationID &&
                         xx.FK_EmploymentTypeID == (int)EmploymentType &&
                         xx.FK_SalaryHeadID == item.SalaryHeadID &&
                         xx.IsDeleted==false
                         select xx).FirstOrDefault();

                    if (found != null)
                    {
                        item.ApplicableChargesType = (ITEM_CHARGE_TYPE)found.ApplicableChargesType;
                        item.ApplicableChargesValue = found.ApplicableChargesValue;
                        item.ID = found.PK_ID;
                        item.SalaryHeadAmount = found.SalaryHeadAmount;
                        if(!found.IsDeleted) item.IsSelected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceDesignationWiseSalary::GetAllAllouncesSalaryHeadsForDesignation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAllounces;

        }
        public List<DesignationwiseSalaryHeadModel> GetAllDeductionsSalaryHeadsForDesignation(int designationID, EMPLOYMENT_TYPE EmploymentType)
        {
            List<DesignationwiseSalaryHeadModel> lstDeduction = new List<DesignationwiseSalaryHeadModel>();
            try
            {
                List<SelectListItem> lstDesignations = (new ServiceMASTERS()).GetAllDesignation();
                List<SelectListItem> lstSalaryHeads = (new ServiceMASTERS()).GetAllSalaryHeads();

                int DEDUCTION_CATEGORY_ID = 0;
                DEDUCTION_CATEGORY_ID = _dbContext.APP_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.SalaryHeadDEDUCTIONType).FirstOrDefault().DEFAULT_VALUE;
                List<TBl_MP_HR_SalaryHead> lstSalaryHeadsDeduction = (new ServiceSalaryHead()).GetAllSalaryHeadsofType(DEDUCTION_CATEGORY_ID);
                foreach (TBl_MP_HR_SalaryHead salaryHeadItem in lstSalaryHeadsDeduction)
                {
                    DesignationwiseSalaryHeadModel model = new DesignationwiseSalaryHeadModel();
                    model.EmploymentType = EmploymentType;
                    model.SalaryHeadID = salaryHeadItem.pK_SH_ID;
                    model.SalaryHeadName = lstSalaryHeads.Where(x => x.ID == salaryHeadItem.fK_Usrlst_SH_ID).FirstOrDefault().Description;
                    model.DesignationID = designationID;
                    if (lstDesignations.Where(x => x.ID == designationID).FirstOrDefault() != null)
                    {
                        model.DesignationName = lstDesignations.Where(x => x.ID == designationID).FirstOrDefault().Description;
                    }
                    model.ApplicableChargesType = ITEM_CHARGE_TYPE.LUMPSUM;
                    model.ApplicableChargesValue = 0;
                    model.ID = 0;
                    model.SalaryHeadAmount = 0;
                    model.IsSelected = false;
                    lstDeduction.Add(model);
                }
                // UPDATE LIST COLLECTION FROM THE DATABASE
                foreach (DesignationwiseSalaryHeadModel item in lstDeduction)
                {
                    TBL_MP_HR_DesignationwiseSalaryHeads found =
                        (from xx in _dbContext.TBL_MP_HR_DesignationwiseSalaryHeads
                         where xx.FK_DesignationID == designationID &&
                         xx.FK_EmploymentTypeID == (int)EmploymentType &&
                         xx.FK_SalaryHeadID == item.SalaryHeadID &&
                         xx.IsDeleted==false
                         select xx).FirstOrDefault();

                    if (found != null)
                    {
                        item.ApplicableChargesType = (ITEM_CHARGE_TYPE)found.ApplicableChargesType;
                        item.ApplicableChargesValue = found.ApplicableChargesValue;
                        item.ID = found.PK_ID;
                        item.SalaryHeadAmount = found.SalaryHeadAmount;
                     if (!found.IsDeleted) item.IsSelected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceDesignationWiseSalary::GetAllDeductionsSalaryHeadsForDesignation", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lstDeduction;
        }
        
        public bool UpdateDesignationwiseSalaryHead(DesignationwiseSalaryHeadModel model)
        {
            bool result = false;
            TBL_MP_HR_DesignationwiseSalaryHeads dbModel = null;
            try
            {
                if (model.ID == 0)
                    dbModel = new TBL_MP_HR_DesignationwiseSalaryHeads();
                else
                    dbModel = _dbContext.TBL_MP_HR_DesignationwiseSalaryHeads.Where(x => x.PK_ID == model.ID).FirstOrDefault();

                if (model.IsSelected)
                {
                    dbModel.FK_DesignationID = model.DesignationID;
                    dbModel.FK_EmploymentTypeID = (int)model.EmploymentType;
                    dbModel.FK_SalaryHeadID = model.SalaryHeadID;
                    dbModel.ApplicableChargesType = (int)model.ApplicableChargesType;
                    dbModel.ApplicableChargesValue = model.ApplicableChargesValue;
                    dbModel.SalaryHeadAmount = model.SalaryHeadAmount;
                    dbModel.IsDeleted = !model.IsSelected;
                   
                }
                else
                {
                    dbModel.ApplicableChargesType = (int)ITEM_CHARGE_TYPE.LUMPSUM;
                    dbModel.ApplicableChargesValue = 0;
                    dbModel.SalaryHeadAmount = 0;
                    dbModel.IsDeleted = true;
                }
                

                if (dbModel.PK_ID == 0)
                    _dbContext.TBL_MP_HR_DesignationwiseSalaryHeads.Add(dbModel);

                _dbContext.SaveChanges();
                result = true;


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceDesignationWiseSalary::UpdateDesignationwiseSalaryHead", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        
    
     
    }
}
