
using libERP.SERVICES.ADMIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum DB_FORM_IDs
{
    NONE=0,
    #region ADMIN
    ADMIN_USER_LIST_AN_DEFAULTS = 1,
    ADMN_MODULE=3,
    ADMIN_ROLES=4,
    APP_USERS=5,
    RESTORE_ATTACHMENT=6,
    ADMIN_VOUCEHRNO_SETUP=59,
    FINANCIAL_YEAR_SETUP=80,
    COMPANY_INFO=16,

    #endregion

    #region MASTERS
    LOCATION = 7,
    SUPPLIERS=8,
    CUSTOMERS=9,
    AGENTS=10,
    INVENTORY_ITEMS=11,
    TNC_MASTER=34,
    BANK_MASTER = 65,
    #endregion

    #region CRM
    SALES_QUESTIONNAIRE =63,

    SALES_LEAD = 12,
    SALES_LEAD_GENERAL_INFO= 22,
    SALES_LEAD_SUSPECT_INFO=23,
    SALES_LEAD_ATTACHMENTS=24,
    SALES_LEAD_SCHEDULE_CALLS=25,
    SALES_LEAD_ASSOCIATES=26,

    SALES_ENQUIRY= 14,
    SALES_ENQUIRY_GENERAL_INFO=17,
    SALES_ENQUIRY_DESIGN_BOQ=18,
    SALES_ENQUIRY_ATTACHMENTS=19,
    SALES_ENQUIRY_ASSOCIATES=20,
    SALES_ENQUIRY_CLIENT_INFO=21,
    SALES_ENQUIRY_SCHEDULE_CALL=27,


    SALES_QUOTATION =15,
    SALES_QUOTATION_GENERAL_INFO=28,
    SALES_QUOTATION_BOQ=30,
    SALES_QUOTATION_ATTACHMENTS=31,
    SALES_QUOTATION_ASSOCIATES=32,
    SALES_QUOTATION_CLIENT_INFO=29,
    SALES_QUOTATION_SCHEDULE_CALL=33,
    SALES_QUOTATION_TNC=35,
    SALES_QUOTATION_REVIEW=60,

    SALES_ORDER = 37,
    SALES_ORDER_GENERAL_INFO=38,
    SALES_ORDER_TNC=39,
    SALES_ORDER_SCHEDULE_CALL=40,
    SALES_ORDER_BOQ=41,
    SALES_ORDER_ATTACHMENTS=42,
    SALES_ORDER_ASSOCIATES=43,
    SALES_ORDER_SALES_NOTE=44,
    SALES_ORDER_CLIENT_CONTACT=62,

    SALES_QUOTATION_REVIEW_ATTACHMENTS = 101,
    #endregion

    #region PROJECTS
    PROJECT_CHECHLIST = 36,
    PROJECT=45,
    PROJECT_MANAGEMENT=46,
    PROJECT_BUDGETING=47,
    PROJECT_REPORTS=48,
    PROJECT_GENERAL_INFO=49,
    PROJECT_CONFIGURATION=50,
    PROJECT_PLANNING=51,
    PROJECT_CALENDAR=52,
    PROJECT_MATERIAL_TAKE_OFF=53,
    PROJECT_VARIATION_TO_CONTRACT=54,
    PROJECT_EXTRA_WORKSHEET_QUOTATION=55,
    PROJECT_CLOSER_CHECKLIST=56,
    PROJECT_SALES_ORDER=57,
    #endregion

    #region PURCHASE
    #endregion

    #region STORES
    #endregion

    #region HR
    
    HR = 10,
    EMPLOYEE = 13,
    SALARY_HEADS = 66,
    
    CTC_CONFIGURATION = 69,

    EMPLOYEE_GENERAL_INFO = 64,
    EMPLOYEE_ATTACHMENT = 67,
    EMPLOYEE_OTHER_DETAIL = 68,
    EMPLOYEE_PERSONAL_DETAILS = 71,
    EMPLOYEE_ADDITIONAL_DETAILS = 72,
    EMPLOYEE_BANK_DETAILS = 73,
    EMPLOYEE_LEAVE_CONFIGURATION=81,
    EMPLOYEE_CTC_INFO = 75,
    EMPLOYEE_AUTHORITIES=98,

    HR_LEAVE_CONFIGURATION = 74,
    ATTENDANCE_ENTRY_MANUAL = 70,
    ATTENDANCE = 78,
    ATTENDANCE_IMPORT = 91,
    ATTENDANCE_CHART_VIEW=92,
    ATTENDANCE_GRID_VIEW=93,
    ATTENDANCE_SUMMARY_VIEW=94,

    PAYROLL=95,
    PAYROLL_GENERATE = 96,
    PAYROLL_VIEW = 97,

    ORGANIZATION_CHART =76,
    HOLIDAYS_AND_WEEKOFFS=77,
    
    LEAVE_APPLICATIONS = 79,
    ADVANCE_REQUEST=82,
    LOAN_REQUEST=83,
    LOAN_DISBURSEMENT=84,
    
    #endregion

    #region USER INFO
    MYATTENDANCE=85,
    MYLEAVES=86,
    MYADVANCEREQUESTS=87,
    MYPERSONALINFO=88,
    MYLOANREQUESTS=89,
    MYPAYSLIPS=99
    #endregion

}

namespace libERP.SERVICES.COMMON
{

    public class WhosWhoModel
    {
        public string ControlName { get; set; }
        public DB_FORM_IDs FormID { get; set; }
        public bool CanAddNew { get; set; }
        public bool CanApprove { get; set; }
        public bool CanAuthorize { get; set; }
        public bool CanCheck { get; set; }
        public bool CanDelete { get; set; }
        public bool CanModify { get; set; }
        public bool CanPrepare { get; set; }
        public bool CanPrint { get; set; }
        public bool CanView { get; set; }
    }
    public class ServiceWhoseWho
    {
        public List<WhosWhoModel> ListControlAccess { get; set; }
        public ServiceWhoseWho() {
            this.ListControlAccess = new List<WhosWhoModel>();
            GenerateControlAccessList();
        }
        private void GenerateControlAccessList()
        {
            try
            {
                #region MASTERS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageLocations", FormID = DB_FORM_IDs.LOCATION }); // LOCATIONS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "PageParties", FormID = DB_FORM_IDs.SUPPLIERS }); // SUPPLIERS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "PageParties", FormID = DB_FORM_IDs.CUSTOMERS }); //CUSTOMERS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "PageParties", FormID = DB_FORM_IDs.AGENTS }); //AGENTS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageInventoryItems", FormID = DB_FORM_IDs.INVENTORY_ITEMS }); //INVENTORY ITEMS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageTermsAndconditions", FormID = DB_FORM_IDs.TNC_MASTER }); //INVENTORY ITEMS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "PageBankMaster", FormID = DB_FORM_IDs.BANK_MASTER });
                #endregion
                #region ADMIN    
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "PageUserLists", FormID = DB_FORM_IDs.ADMIN_USER_LIST_AN_DEFAULTS}); // APPLICATION_DATA_LIST
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageModules", FormID = DB_FORM_IDs.ADMN_MODULE }); // APPLICATION_MODULES
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageRoleManager", FormID = DB_FORM_IDs.ADMIN_ROLES }); //APPLICATION_ROLES
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "PageUserManager", FormID = DB_FORM_IDs.APP_USERS }); //APPLICATION_USERS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageDeletedAttachments", FormID = DB_FORM_IDs.RESTORE_ATTACHMENT }); //RESTORE_ATTACHMENTS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageVoucehrNoSetup", FormID = DB_FORM_IDs.ADMIN_VOUCEHRNO_SETUP }); // COMPANY INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageVoucehrNoSetup", FormID = DB_FORM_IDs.FINANCIAL_YEAR_SETUP }); // COMPANY INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageCompanyInfo", FormID = DB_FORM_IDs.COMPANY_INFO }); // COMPANY INFO
                #endregion
                #region CRM 
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageQuestionnaire", FormID = DB_FORM_IDs.SALES_QUESTIONNAIRE });
                #region SALES LEAD AND TAB PAGES
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageSalesLead", FormID = DB_FORM_IDs.SALES_LEAD });  // SALES LEAD
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_LEAD_GENERAL_INFO }); // SALES LEAD - GENERAL INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabSuspectInfo", FormID = DB_FORM_IDs.SALES_LEAD_SUSPECT_INFO }); // SALES LEAD - SUSPECT INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabAttachments", FormID = DB_FORM_IDs.SALES_LEAD_ATTACHMENTS }); // SALES LEAD - ATTACHMENTS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabSchdeuleCall", FormID = DB_FORM_IDs.SALES_LEAD_SCHEDULE_CALLS}); // SALES LEAD - SCHEDULE CALL
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabAssociates", FormID = DB_FORM_IDs.SALES_LEAD_ASSOCIATES});  // SALES LEAD - ASSOCIATES

                #endregion

                #region SALES ENQUIRY
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageSalesEnquiry", FormID = DB_FORM_IDs.SALES_ENQUIRY }); // SALES ENQUIRY
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_ENQUIRY_GENERAL_INFO });   // SALES ENQUIRY - GENERAL INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabDesignBOQ", FormID = DB_FORM_IDs.SALES_ENQUIRY_DESIGN_BOQ });     // SALES ENQUIRY - DESIGN BOQ
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabAttachments", FormID = DB_FORM_IDs.SALES_ENQUIRY_ATTACHMENTS });   // SALES ENQUIRY - ATTACHMENTS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabAssociates", FormID = DB_FORM_IDs.SALES_ENQUIRY_ASSOCIATES });    // SALES ENQUIRY - ASSOCIATES
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabClientInfo", FormID = DB_FORM_IDs.SALES_ENQUIRY_CLIENT_INFO });    // SALES ENQUIRY - CLIENT INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabSchdeuleCall", FormID = DB_FORM_IDs.SALES_ENQUIRY_SCHEDULE_CALL });  // SALES ENQUIRY - SCHEDULE CALL
                #endregion  
                #region SALES QUOTATION
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageSaleseQuotation", FormID = DB_FORM_IDs.SALES_QUOTATION }); // SALES QUOTATION
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_QUOTATION_GENERAL_INFO });   // SALES QUOTATION - GENERAL INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabQuotationBOQ", FormID = DB_FORM_IDs.SALES_QUOTATION_BOQ });  // SALES QUOTATION - BOQ
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabAttachments", FormID = DB_FORM_IDs.SALES_QUOTATION_ATTACHMENTS });   // SALES QUOTATION - ATTACHMENTS
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabAssociates", FormID = DB_FORM_IDs.SALES_QUOTATION_ASSOCIATES });    // SALES QUOTATION - ASSOCIATES
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabClientInfo", FormID = DB_FORM_IDs.SALES_QUOTATION_CLIENT_INFO });    // SALES QUOTATION - CLIENT INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabSchdeuleCall", FormID = DB_FORM_IDs.SALES_QUOTATION_SCHEDULE_CALL });  // SALES QUOTATION - SCHEDULE CALL
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabTermsAndCondition", FormID = DB_FORM_IDs.SALES_QUOTATION_TNC });  // SALES QUOTATION - SCHEDULE CALL
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageSalesQuotationReview", FormID = DB_FORM_IDs.SALES_QUOTATION_REVIEW });
                #endregion
                #region SALES ORDER

                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageSalesOrder", FormID = DB_FORM_IDs.SALES_ORDER });  // SALES ORDER
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_ORDER_GENERAL_INFO });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_ORDER_TNC });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_ORDER_SCHEDULE_CALL });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_ORDER_BOQ });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_ORDER_ATTACHMENTS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabGeneralInfo", FormID = DB_FORM_IDs.SALES_ORDER_ASSOCIATES });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "", FormID = DB_FORM_IDs.SALES_ORDER_SALES_NOTE });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "", FormID = DB_FORM_IDs.SALES_ORDER_CLIENT_CONTACT });

                #endregion

                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageProjectChecklist", FormID = DB_FORM_IDs.PROJECT_CHECHLIST});

                #endregion
                #region HR   

                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageHR", FormID = DB_FORM_IDs.HR });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageEmployee", FormID = DB_FORM_IDs.EMPLOYEE });

                #region HE- EMPLOYEE INFO       
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPageGerneralInfo", FormID = DB_FORM_IDs.EMPLOYEE_GENERAL_INFO });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPagePersonalInfo", FormID = DB_FORM_IDs.EMPLOYEE_PERSONAL_DETAILS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPageOtherDetails", FormID = DB_FORM_IDs.EMPLOYEE_OTHER_DETAIL });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPageAdditionalDetails", FormID = DB_FORM_IDs.EMPLOYEE_ADDITIONAL_DETAILS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPageBankDetails", FormID = DB_FORM_IDs.EMPLOYEE_BANK_DETAILS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabpageCTC", FormID = DB_FORM_IDs.EMPLOYEE_CTC_INFO });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPageAttachments", FormID = DB_FORM_IDs.EMPLOYEE_ATTACHMENT });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPageEmpLeaveConfig", FormID = DB_FORM_IDs.EMPLOYEE_LEAVE_CONFIGURATION });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "tabPageEmpAuthorities", FormID = DB_FORM_IDs.EMPLOYEE_AUTHORITIES });
                #endregion

                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageSalaryHeads", FormID = DB_FORM_IDs.SALARY_HEADS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageManualAttendance", FormID = DB_FORM_IDs.ATTENDANCE_ENTRY_MANUAL });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageAttendance", FormID = DB_FORM_IDs.ATTENDANCE});
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageImportAttendance", FormID = DB_FORM_IDs.ATTENDANCE_IMPORT });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageAttendanceChartView", FormID = DB_FORM_IDs.ATTENDANCE_CHART_VIEW });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageAttendanceGridView", FormID = DB_FORM_IDs.ATTENDANCE_GRID_VIEW });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageAttendanceSummaryView", FormID = DB_FORM_IDs.ATTENDANCE_SUMMARY_VIEW });

                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pagePayroll", FormID = DB_FORM_IDs.PAYROLL });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pagePayrollGenerate", FormID = DB_FORM_IDs.PAYROLL_GENERATE });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pagePayrollView", FormID = DB_FORM_IDs.PAYROLL_VIEW });

                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageHR_ManageLeave", FormID = DB_FORM_IDs.HR_LEAVE_CONFIGURATION });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageLeavesRegister", FormID = DB_FORM_IDs.LEAVE_APPLICATIONS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageAdvanceRequest", FormID = DB_FORM_IDs.ADVANCE_REQUEST });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageLoanRequest", FormID = DB_FORM_IDs.LOAN_REQUEST });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageLoanDisbursement", FormID = DB_FORM_IDs.LOAN_DISBURSEMENT });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageCTCConfiguration", FormID = DB_FORM_IDs.CTC_CONFIGURATION });
                                                                                                                    

                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageOrgChart", FormID = DB_FORM_IDs.ORGANIZATION_CHART });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageHolidaysAndWeekOff", FormID = DB_FORM_IDs.HOLIDAYS_AND_WEEKOFFS});

                #endregion
                #region PROJECT MANAGEMENT
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageProject", FormID = DB_FORM_IDs.PROJECT }); 
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageProjectManagement", FormID = DB_FORM_IDs.PROJECT_MANAGEMENT }); 
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageProjectBudgeting", FormID = DB_FORM_IDs.PROJECT_BUDGETING }); 
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageProjectReports", FormID = DB_FORM_IDs.PROJECT_REPORTS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectGeneralInfo", FormID = DB_FORM_IDs.PROJECT_GENERAL_INFO });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectConfiguration", FormID = DB_FORM_IDs.PROJECT_CONFIGURATION });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectPlanning", FormID = DB_FORM_IDs.PROJECT_PLANNING });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectCalendar", FormID = DB_FORM_IDs.PROJECT_CALENDAR });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectMaterialTakeOff", FormID = DB_FORM_IDs.PROJECT_MATERIAL_TAKE_OFF });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectVariationToContract", FormID = DB_FORM_IDs.PROJECT_VARIATION_TO_CONTRACT });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectExtraWorksheetQuotation", FormID = DB_FORM_IDs.PROJECT_EXTRA_WORKSHEET_QUOTATION });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectCloserCheckLIst", FormID = DB_FORM_IDs.PROJECT_CLOSER_CHECKLIST });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "controlProjectSalesOrder", FormID = DB_FORM_IDs.PROJECT_SALES_ORDER });

                #endregion

                #region USER INFO
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageMyAttendance", FormID = DB_FORM_IDs.MYATTENDANCE });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageMyLeaves", FormID = DB_FORM_IDs.MYLEAVES });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageMyAdvanceRequest", FormID = DB_FORM_IDs.MYADVANCEREQUESTS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageMyPersonalInfo", FormID = DB_FORM_IDs.MYPERSONALINFO });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageMyLoanRequest", FormID = DB_FORM_IDs.MYLOANREQUESTS });
                this.ListControlAccess.Add(new WhosWhoModel() { ControlName = "pageMyPayslips", FormID = DB_FORM_IDs.MYPAYSLIPS });
                #endregion

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceWhoseWho::GenerateListControlAccess", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateControlAccessListForRole(int roleID, int employeeID)
        {
            try
            {
                foreach (WhosWhoModel model in this.ListControlAccess)
                {
                    TBL_MP_Master_RoleForm roleForm = (new ServiceRoles()).GetRoleFormDBRecordByRoleIDnFormID(roleID, (int)model.FormID);
                    if (roleForm != null)
                    {
                        model.CanAddNew = roleForm.CanAddNew;
                        model.CanApprove = roleForm.CanApprove;
                        model.CanAuthorize = roleForm.CanAuthorize;
                        model.CanCheck = roleForm.CanCheck;
                        model.CanDelete = roleForm.CanDelete;
                        model.CanModify = roleForm.CanModify;
                        model.CanPrepare = roleForm.CanPrepare;
                        model.CanPrint = roleForm.CanPrint;
                        model.CanView = roleForm.CanView;
                    }
                    else
                        model.CanAddNew = model.CanApprove = model.CanAuthorize = model.CanCheck = model.CanDelete = model.CanModify = model.CanPrepare = model.CanPrint = model.CanView = false;
                }

                //if custom privleges are set for particular employee
                foreach (WhosWhoModel model in this.ListControlAccess)
                {
                    TBL_User_CustomPermissions EmproleForm = (new ServiceRoles()).GetEmpRoleFormDBRecordByRoleIDnFormID(employeeID, (int)model.FormID);
                    if (EmproleForm != null)
                    {
                        model.CanAddNew = EmproleForm.CanAddNew;
                        model.CanApprove = EmproleForm.CanApprove;
                        model.CanAuthorize = EmproleForm.CanAuthorize;
                        model.CanCheck = EmproleForm.CanCheck;
                        model.CanDelete = EmproleForm.CanDelete;
                        model.CanModify = EmproleForm.CanModify;
                        model.CanPrepare = EmproleForm.CanPrepare;
                        model.CanPrint = EmproleForm.CanPrint;
                        model.CanView = EmproleForm.CanView;
                    }
                    //else
                    //    model.CanAddNew = model.CanApprove = model.CanAuthorize = model.CanCheck = model.CanDelete = model.CanModify = model.CanPrepare = model.CanPrint = model.CanView = false;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceWhoseWho::UpdateControlAccessListForRole", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          
    }


}
