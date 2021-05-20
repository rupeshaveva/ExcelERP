using libERP.MODELS;
using libERP.MODELS.ADMIN;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.ADMIN
{
    public class ServiceVoucherNoSetup: DefaultService
    {
        
        public ServiceVoucherNoSetup(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceVoucherNoSetup()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<SelectListItem> GetAllFormTypes()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.SALES_LEAD, Description = "Sales Lead (CRM)" });
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.SALES_ENQUIRY, Description = "Sales Enquiry (CRM)" });
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.SALES_QUOTATION, Description = "Sales Quotation (CRM)" });
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.SALES_ORDER, Description = "Sales Order" });
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.PROJECT, Description = "Project (PMC)" });
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.LEAVE_APPLICATIONS, Description = "Leave Applications (HR)" });
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.ADVANCE_REQUEST, Description = "Advance Requests (HR)" });
                lst.Add(new SelectListItem() { ID = (int)DB_FORM_IDs.LOAN_REQUEST, Description = "Loan Requests (HR)" });
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceVoucherNoSetup::GetAllFormTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<VoucherNoSetupModel> GetAllVoucherNoSetupForFormID(int formID)
        {
            List<VoucherNoSetupModel> lst = new List<VoucherNoSetupModel>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_Admin_VoucherNoSetup
                       where xx.fk_FormID == formID
                       select new VoucherNoSetupModel()
                       {
                           ID = xx.PK_VoucherSetupID,
                           FormID = xx.fk_FormID,
                           NoContinued = xx.Is_NoContinuedNextYear,
                           NoPadding = xx.NoPad,
                           NoSeperator = xx.NoSeperator,
                           Prefix = xx.NoPrefix,
                           PreviewVoucherNo = xx.VoucherNoPreview,
                           StartingNo = xx.NoStartingFrom,
                           Suffix = xx.NoPostfix,
                           YearID = xx.Fk_YearID

                       }).ToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceVoucherNoSetup::GetAllVoucherNoSetupForFormID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }

        public TBL_MP_Admin_VoucherNoSetup GetVoucherSetupDBRecordByID(int pkID)
        {
            TBL_MP_Admin_VoucherNoSetup model = null;
            try
            {
                model = _dbContext.TBL_MP_Admin_VoucherNoSetup.Where(x => x.PK_VoucherSetupID == pkID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceVoucherNoSetup::GetVoucherSetupDBRecordByID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewVoucherNoSetup(TBL_MP_Admin_VoucherNoSetup model)
        {
            int newID = 0;
            try
            {   
                _dbContext.TBL_MP_Admin_VoucherNoSetup.Add(model);
                _dbContext.SaveChanges();
                newID = model.PK_VoucherSetupID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceVoucherNoSetup::AddNewVoucherNoSetup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateVoucherNoSetup(TBL_MP_Admin_VoucherNoSetup model)
        {
            bool result = false;
            try
            {
                TBL_MP_Admin_VoucherNoSetup dbModel = _dbContext.TBL_MP_Admin_VoucherNoSetup.Where(x => x.PK_VoucherSetupID == model.PK_VoucherSetupID).FirstOrDefault();
                if (dbModel != null)
                {
                    dbModel.fk_FormID = model.fk_FormID;
                    dbModel.Fk_YearID = model.Fk_YearID;
                    dbModel.NoPrefix = model.NoPrefix;
                    dbModel.NoSeperator = model.NoSeperator;
                    dbModel.NoPad = model.NoPad;
                    dbModel.NoPostfix = model.NoPostfix;
                    dbModel.Is_NoContinuedNextYear = model.Is_NoContinuedNextYear;
                    dbModel.NoStartingFrom = model.NoStartingFrom;

                    dbModel.LastModifiedBy = model.LastModifiedBy;
                    dbModel.LastModifiedDate = model.LastModifiedDate;
                    _dbContext.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceVoucherNoSetup::UpdateVoucherNoSetup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }





    }
}
