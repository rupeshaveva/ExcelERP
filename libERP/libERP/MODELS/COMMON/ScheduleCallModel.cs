using libERP.MODELS.CRM;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace libERP.MODELS.COMMON
{
    public class ScheduleCallModel
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
    public class FollowUpListModel
    {
        public int FollowUpID { get; set; }
        public string AttendedBy { get; set; }
        public string FollowUpDescription { get; set; }
        public string NextFollowUpDescription { get; set; }
        public int ScheduleID { get; set; }
        public int EmployeeID { get; set; }
        public int StatusID { get; set; }
        public string SearchText { get { return AttendedBy.ToUpper() + FollowUpDescription.ToUpper() + NextFollowUpDescription.ToString().ToUpper(); } }

        public FollowUpListModel()
        {
            this.AttendedBy = this.FollowUpDescription = this.NextFollowUpDescription = string.Empty;
        }

    }
    public class ScheduleCallAddEditModel
    {
        public APP_ENTITIES SOURCE_ENTITY { get; set; }
        public int SOURCE_ENTITY_ID { get; set; }
        public BindingList<MultiSelectListItem> listAssignees { get; set; }
        public int ScheduleID { get; set; }
        public string HeaderTitle { get; set; }
        public int currEmpID { get; set; }

        public TBL_MP_CRM_ScheduleCallLog DB_MODEL { get; set; }


        public void PrepareForInsert()
        {
            DB_MODEL = new TBL_MP_CRM_ScheduleCallLog();
            string strCaption = string.Empty;
            string strContactNames = string.Empty;
            string strContactNumbers = string.Empty;
            string strContactAddresses = string.Empty;

            try
            {
                switch (this.SOURCE_ENTITY)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        LeadMasterInfoModel leadInfo = (new ServiceSalesLead()).GetLeadMasterInfo(this.SOURCE_ENTITY_ID);
                        strCaption = string.Format("LEAD: {0} {1} dt. {2}", leadInfo.LeadNo, leadInfo.LeadName, leadInfo.LeadDate.Value.ToString("dd MMM yyyy"));
                        DB_MODEL.CustomerName = leadInfo.LeadName;

                        List<SelectContactModel> listContacts = (new ServiceSalesLead()).GetContactsForLeadID(this.SOURCE_ENTITY_ID);
                        DB_MODEL.ContactPerson = string.Empty;
                        foreach (SelectContactModel model in listContacts)
                        {
                            string[] names = model.Description1.Split('\n');
                            DB_MODEL.ContactPerson += names[0] + ", ";
                            DB_MODEL.ContactNumber += model.Description2 + ", ";
                            DB_MODEL.Location += model.Description1.Replace(names[0], "");
                        }

                        DB_MODEL.ContactPerson = DB_MODEL.ContactPerson.TrimEnd(' ').TrimEnd(',');
                        DB_MODEL.ContactNumber = DB_MODEL.ContactNumber.TrimEnd(' ').TrimEnd(',');

                        break;
                    case APP_ENTITIES.SALES_ENQUIRY:
                        TBL_MP_CRM_SalesEnquiry dbEnquiry = (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(this.SOURCE_ENTITY_ID);
                        strCaption = string.Format("ENQUIRY: {0} {1} dt. {2}", dbEnquiry.SalesEnquiry_No, dbEnquiry.Project_Name, dbEnquiry.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                        DB_MODEL.CustomerName = dbEnquiry.Tbl_MP_Master_Party.PartyName;
                        List<TBL_MP_CRM_SM_ContactReferences> listEnquiryContacts = (new ServiceSalesEnquiry()).GetAllCompanyContactsForSalesEnquiryDB(this.SOURCE_ENTITY_ID);
                        strContactNames = strContactNumbers = strContactAddresses = string.Empty;
                        foreach (TBL_MP_CRM_SM_ContactReferences refContact in listEnquiryContacts)
                        {
                            strContactNames += string.Format("{0}\n", refContact.Tbl_MP_Master_PartyContact_Detail.ContactPersoneName);
                            strContactAddresses += string.Format("{0}\n\n", refContact.Tbl_MP_Master_PartyContact_Detail.Address);
                            strContactNumbers += string.Format("Mobile: {0}  {1}", refContact.Tbl_MP_Master_PartyContact_Detail.MobileNo, refContact.Tbl_MP_Master_PartyContact_Detail.AltMobileNo);
                            strContactNumbers += string.Format("Tel: {0}  {1}\n", refContact.Tbl_MP_Master_PartyContact_Detail.TelephoneNo, refContact.Tbl_MP_Master_PartyContact_Detail.AltTelephoneNo);
                        }

                        DB_MODEL.ContactPerson = strContactNames.TrimEnd(' ').TrimEnd(',');
                        DB_MODEL.ContactNumber = strContactNumbers.TrimEnd(' ').TrimEnd(',');
                        DB_MODEL.Location = strContactAddresses;
                        break;
                    case APP_ENTITIES.SALES_QUOTATION:
                        TBL_MP_CRM_SalesQuotation dbQuote = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(this.SOURCE_ENTITY_ID);
                        strCaption = string.Format("ENQUIRY: {0} dt. {1}", dbQuote.Quotation_No, dbQuote.Quotation_Date.ToString("dd MMM yyyy"));
                        DB_MODEL.CustomerName = dbQuote.Tbl_MP_Master_Party.PartyName;
                        List<TBL_MP_CRM_SM_ContactReferences> listQuoteContacts = (new ServiceSalesQuotation()).GetAllCompanyContactsForSalesQuotationDB(this.SOURCE_ENTITY_ID);
                        strContactNames = strContactNumbers = strContactAddresses = string.Empty;
                        foreach (TBL_MP_CRM_SM_ContactReferences refContact in listQuoteContacts)
                        {
                            strContactNames += string.Format("{0}\n", refContact.Tbl_MP_Master_PartyContact_Detail.ContactPersoneName);
                            strContactAddresses += string.Format("{0}\n\n", refContact.Tbl_MP_Master_PartyContact_Detail.Address);
                            strContactNumbers += string.Format("Mobile: {0}  {1}", refContact.Tbl_MP_Master_PartyContact_Detail.MobileNo, refContact.Tbl_MP_Master_PartyContact_Detail.AltMobileNo);
                            strContactNumbers += string.Format("Tel: {0}  {1}\n", refContact.Tbl_MP_Master_PartyContact_Detail.TelephoneNo, refContact.Tbl_MP_Master_PartyContact_Detail.AltTelephoneNo);
                        }

                        DB_MODEL.ContactPerson = strContactNames.TrimEnd(' ').TrimEnd(',');
                        DB_MODEL.ContactNumber = strContactNumbers.TrimEnd(' ').TrimEnd(',');
                        DB_MODEL.Location = strContactAddresses;
                        break;
                    case APP_ENTITIES.SALES_ORDER:
                        TBL_MP_CRM_SalesOrder dbOrder = (new ServiceSalesOrder()).GetSalesOrderDBInfoByID(this.SOURCE_ENTITY_ID);
                        strCaption = string.Format("ORDER: {0} dt. {1}", dbOrder.SalesOrderNo, dbOrder.SalesOrderDate.ToString("dd MMM yyyy"));
                        DB_MODEL.CustomerName = dbOrder.Tbl_MP_Master_Party.PartyName;
                        List<TBL_MP_CRM_SM_ContactReferences> listOrderContacts = (new ServiceSalesOrder()).GetAllCompanyContactsForSalesOrderDB(this.SOURCE_ENTITY_ID);
                        strContactNames = strContactNumbers = strContactAddresses = string.Empty;
                        foreach (TBL_MP_CRM_SM_ContactReferences refContact in listOrderContacts)
                        {
                            strContactNames += string.Format("{0}\n", refContact.Tbl_MP_Master_PartyContact_Detail.ContactPersoneName);
                            strContactAddresses += string.Format("{0}\n\n", refContact.Tbl_MP_Master_PartyContact_Detail.Address);
                            strContactNumbers += string.Format("Mobile: {0}  {1}", refContact.Tbl_MP_Master_PartyContact_Detail.MobileNo, refContact.Tbl_MP_Master_PartyContact_Detail.AltMobileNo);
                            strContactNumbers += string.Format("Tel: {0}  {1}\n", refContact.Tbl_MP_Master_PartyContact_Detail.TelephoneNo, refContact.Tbl_MP_Master_PartyContact_Detail.AltTelephoneNo);
                        }

                        DB_MODEL.ContactPerson = strContactNames.TrimEnd(' ').TrimEnd(',');
                        DB_MODEL.ContactNumber = strContactNumbers.TrimEnd(' ').TrimEnd(',');
                        DB_MODEL.Location = strContactAddresses;
                        break;

                }

                DateTime currDatetime = AppCommon.GetServerDateTime();
                DB_MODEL.StartAt = currDatetime;
                DB_MODEL.EndsAt = currDatetime.AddDays(1);
                DB_MODEL.Reminder = currDatetime.AddHours(-1);
                HeaderTitle = strCaption;

                BindingList<MultiSelectListItem> allEmployees = AppCommon.ConvertToBindingList<MultiSelectListItem>((new ServiceMASTERS()).GetAllEmployeesMultiSelect());
                this.listAssignees = new BindingList<MultiSelectListItem>();
                MultiSelectListItem emp = allEmployees.Where(x => x.ID == currEmpID).FirstOrDefault();
                if (emp != null) this.listAssignees.Add(emp);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ScheduleCallAddEditModel::PrepareForInsert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        public void PrepareForEdit()
        {
            ScheduleCallAddEditModel editModel = (new ServiceScheduleCallLog()).GetSchdeuledCallAddEditModelForSchedule(this.ScheduleID);
            if (editModel != null)
            {
                this.SOURCE_ENTITY = editModel.SOURCE_ENTITY;
                this.SOURCE_ENTITY_ID = editModel.SOURCE_ENTITY_ID;
                this.DB_MODEL = editModel.DB_MODEL;
                this.listAssignees = editModel.listAssignees;
                this.HeaderTitle = editModel.HeaderTitle;
            }
        }


    }
}
