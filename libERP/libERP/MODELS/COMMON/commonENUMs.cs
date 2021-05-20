using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.COMMON
{

    public enum SalaryHeadCalculatedOn
    {
        NONE=0,
        PERCENT_OF_BASIC=1,
        PERCENT_OF_GROSS = 2,
        PERCENT_OF_BASIC_AND_DA=3
    }



    public enum ATTENDANCE_TYPE
    {
        NONE=0,
        PRESENT=1,
        ABSENT=2,
        LEAVE=3,
        OUT_DOOR=4,
        HOLIDAY=5,
        WEEK_OFF=6,
        SANDWICH_LEAVE=7,
        MULTIPLE=8,
        COMP_OFF=9,
        LATE_COMING=10,
        EARLY_GOING=11
    }
  
    public enum APP_ENTITIES
    {
        none = 0,
        SALES_LEAD = 1,
        SALES_LEAD_APPROVED_OPEN,
        SALES_LEAD_ATTACHMENT,
        SALES_ENQUIRY,
        SALES_ENQUIRY_APPROVED_OPEN,
        SALES_ENQUIRY_ATTACHMENT,
        SALES_QUOTATION,
        SALES_QUOTATION_ATTACHMENT,
        SALES_QUOTATION_TERMS_AND_CONDITIONS,
        SALES_ORDER,
        SALES_ORDER_ATTACHMENT,
        SALES_ORDER_SELECT_QUOTATION,
        SALES_ORDER_TERMS_AND_CONDITIONS,
        EMPLOYEES,
        EMPLOYEES_ATTACHMENT,
        PARTIES,
        CONTACTS,
        ASSOCIATES_AND_CONTACTS,
        AGENTS,
        CUSTOMERS,
        SUPPLIERS,
        BOQ_SERVICES,
        UOM_LIST,
        INVENTORY_ITEMS_LIST,
        INVENTORY_ITEM,
        INVENTORY_ASSEMBLY_ITEMS,
        INVENTORY_ITEM_ATTACHMENT,
        APPLICATION_MODULES,
        MODULES_FORMS,
        ROLES,
        ROLE_MODELS,
        ROLE_MODULE_FORMS,
        SALES_QUOTATION_REVIEW_SELECT_QUOTATION,
        ACTIVE_PROJECT,
        PREVIOUS_PROJECTS,
        ALL_PROJECTS,
        PROJECT_LIST_FOR_ATTENDANCE

    }

    public enum PASSWORD_TYPE
    {
        NONE = 0,
        LOGIN_PASSWORD = 1,
        EMAIL_PASSWORD = 2
    }

    public enum PERSON_TYPE
    {
        NONE = 0,
        EMPLOYEE = 1,
        CONTACT = 2,
        PARTY = 3
    }
    public enum PERMISSIONS
    {
        NONE = 0,
        ADD_NEW,
        MODIFY,
        DELETE,
        UNDELETE,
        VIEW,
        PRINT,
        CHECK,
        AUTHORIZE,
        APPROVE,
        SEARCH

    }
    

    public enum APP_DEFAULT_VALUES
    {
        DefaultCurrencyID = 1,
        DefaultLeadStatusID = 2,

        ScheduleCallStatusInProgress = 3,
        ScheduleCallStatusOnHold = 4,
        ScheduleCallStatusClose = 5,
        NextFollowUpRequired = 6,
        FollowUpStatusClose = 7,

        QuestionMasterCategoryID=48,
        QuestionMasterRelatedToCategoryID=49,


        LeadSourceAgency = 8,

        LeadStatusClose = 9,
        LeadStatusLost = 10,
        LeadStatusConverted = 11,
        LeadStatusOpen = 12,

        DefaultCountryID = 13,
        EnquiryStatusOpen = 14,
        EnquirySourceLEAD = 15,
        DesignDepartmentID = 16,
        SalesDepartmentID = 17,
        ItemTypeCategoryID = 18,
        SalesQuotationStatusAdminCategory = 19,

        EnquiryStatusClose = 20,
        EnquiryStatusLost = 21,
        EnquiryStatusConverted = 22,


        QuotationStatusOpen = 23,
        QuotationStatusClose = 24,
        QuotationStatusHold = 25,
        QuotationStatusInProcess = 26,
        QuotationStatusConverted = 27,
        QuotationStatusLost = 28,
        TermAndConditionCategory = 29,
        TermAndConditionTitleAdminCategory = 30,
        TermAndConditionSalesQuotationCategory = 31,
        ProjectChecklistPointCategory = 32,
        SalesOrderStatusAdminCategory = 33,
        ProjectStatusAdminCategory = 34,
        POSource = 35,

        SOStatus_Open = 36,
        SOStatus_Closed=41,
        SOStatus_Processed=42,

        SOType_WithoutOrder =37,
        SOType_PrimaryOrder=38,
        SOType_GFCOrder=39,
        SOType_FOCOrder=40,

        ProjectStatus_Open=43,
        ProjectStatus_InProgress = 44,
        ProjectStatus_Processed = 45,
        ProjectStatus_Closed = 46,
        TermAndConditionSalesOrderCategory=47,


        #region HR
        EmployeeCategoryID = 50,
        FamilyRelationshipCategoryID = 51,
        BloodGroupCategoryID = 52,
        GenderAdminCategoryID = 53,
        MeritalstatusAdminCategoryID = 54,
        BankAccountTypeAdminCategoryID = 55,
        ModeOfPaymentAdminCategoryID = 56,
        SalaryHeadAdminCategoryID = 57,
        SalaryHeadNatureAdminCategoryID = 58,
        SalaryHeadTypeAdminCategoryID = 59,
        EmploymentTypeAdminCategoryID = 60,
        SalaryHeadEARNINGType = 61,
        SalaryHeadDEDUCTIONType = 62,
        VisaTypeMasterCategoryID=63,



        BasicSalaryHeadID = 64,
        daSalaryHeadID=93,




        LeaveFormTypeAdminCategoryID = 66,
        LeaveFormTypeLeaveID = 67,
        LeaveFormTypeOutDoorID = 68,
        LeaveType_Leave_CategoryID = 65,
        LeaveType_OutDoorCategoryID = 69,
        LeaveFormType_CompOffID= 82,
        LeaveFormType_LateComingID=83,
        LeaveFormTpe_EarlyLeavingID=84,
        LEAVE_TYPE_PL_CATEGORY_ID=85,
        LEAVE_TYPE_SL_CATEGORY_ID=86,
        LEAVE_TYPE_CL_CATEGORY_ID=87,
        LEAVE_TYPE_COMP_OFF_CATEGORY_ID=88,



        ApprovalStatusAdminCategoryID =70,
        ApprovalStatusPending_CategoryID=71,
        ApprovalStatusApproved_CategoryID=72,
        ApprovalStatusRejected_CategoryID=73,

        OUTDOOR_FULLSHIFT_CATEGORY_ID=74,
        OUTDOOR_FIRSTHALF_CATEGORY_ID=75,
        OUTDOOR_SECONDHALF_CATEGORY_ID=76,
        LEAVE_TYPE_HALFDAY_ID=77,

        EMPLOYEE_CATEGORY_OFFICE=78,
        EMPLOYEE_CATEGORY_ON_SITE=79,
        EMPLOYEE_CATEGORY_MANAGEMENT=80,
        EMPLOYEE_CATEGORY_ON_CASH_ROLL=81
        #endregion

    }

    public enum APP_MASTER_CATEGORIES
    {
        INDUSTRY_TYPE = 8,
        DEPARTMENT = 2,
        DESIGNATION = 3,
        SUMISSION_MODE = 22,
        CALL_SCHEDULE_ACTIONS = 1035,
        CALL_SCHEDULE_REMINDER = 8,
        SERVICES_CATEGORY = 31,
        UOM_CATEGORY = 13,
        VISA_TYPE = 2037,
        LEAVE_TYPE = 1040
    }

    public enum APP_ADMIN_CATEGORIES
    {
        SUSPECTING_INFO = 29,
        ATTACHMENT_DOCUMENT_TYPE = 2032,
        SALES_LEAD_STATUS = 16,
        CALL_SCHEDULE_STATUS = 8061,
        CALL_FOLLOWUP_STATUS = 7,
        //PROJECT_TYPE = 32,
        LEAD_SOURCE = 14,
        ENQUIRY_TYPE = 20,
        ENQUIRY_SOURCE = 21,
        ENQUIRY_STATUS = 9,
        QUOTATION_STATUS_ADMIN_CATEGORY = 12,
        QUOTATION_PRIORITY_ADMIN_CATEGORY = 13,
        PROJECT_STATUS = 1020,
        PROJECT_SECTOR = 5,
        PROJECT_TYPE = 32,
        ITEM_TYPE = 1
    }
    public enum NOTIFICATION_CATEGORIES
    {
        NOTIFICATION_CRM = 3
    }



    public enum APP_MODULES
    {
        ADMIN = 1,
        MASTERS = 2,
        CRM = 3,
        PMC = 4,
        PURCHASE = 5,
        STORES = 6,
        QAQC = 7,
        INVOICE = 8,
        ACCOUNTS = 9,
        HR = 10,
        SITE = 11,
        USER_INFO=12
    }

    public enum CRM_Pages
    {
        None,
        Questionnairs,
        FollowUps,
        SalesLeads,
        SalesEnquieries,
        SalesQuotations,
        SalesOrders,
        SalesReports,
        SalesDashboard,
        Parties,
        InventoryItems
    }


    public enum SALES_ENQUIRY_STATUS
    {
        OPEN = 1,
        AMMEND = 2,
        LOST = 4,
        CONVERTED = 6
    }

    //public enum CRM_SalseEnquiry_GeneratedBy
    //{
    //    [Description("Reference")]
    //    Reference = 1,
    //    [Description("Agent")]
    //    Agent = 2,
    //    [Description("Employee")]
    //    Employee = 3
    //}



    //public enum CRM_SalseEnquiry_Source 
    //{
    //    None = 0,
    //    Email = 11054,
    //    IndiaMart = 45042,
    //    NewsLetter = 11022,
    //    NewsPapper = 11004,
    //    SocialNetworks = 11023,
    //    Verbal = 29042
    //}

    public enum SCHEDULECALL_PRIORITY
    {
        NONE = 0,
        LOW = 1,
        MODERATE = 2,
        HIGH = 3
    }


    public enum INSTALLATION_RATE_TYPE
    {
        NONE = 0,
        PERCENTAGE = 1,
        LUMPSUM = 2
    }
    public enum ITEM_CHARGE_TYPE
    {
        NONE = 0,
        PERCENTAGE = 1,
        LUMPSUM = 2
    }
    public enum EMPLOYMENT_TYPE
    {
        NONE = 0,
        PERMAMENT = 7329,
        PROBATION = 7330
    }
    public enum SALARY_HEAD_TYPE
    {
        NONE=0,
        ALLOUNCE=1,
        DEDUCTION=2

    }

    public enum PROJECT_PLAN_TYPE
    {
        NONE=0,
        PROJECT_PLANNING=1,
        PROJECT_EXECUTION=2
    }
}
