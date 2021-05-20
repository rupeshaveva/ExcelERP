using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.MODELS.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.CRM;
using libERP.SERVICES.HR;

namespace appExcelERP.Forms
{


    public partial class frmDelete : KryptonForm
    {
        public APP_ENTITIES ENTITY { get; set; }
        public int ENTITY_ID { get; set; }


        public frmDelete()
        {
            InitializeComponent();
        }

        public frmDelete(APP_ENTITIES entity, int ID)
        {
            InitializeComponent();
            this.ENTITY = entity;
            this.ENTITY_ID = ID;
        }

        private void PopulateDescription()
        {
            try
            {
                switch (this.ENTITY)
                {
                    case APP_ENTITIES.INVENTORY_ITEM:
                        TBL_MP_Master_Item dbItem = (new ServiceInventoryItems()).GetItemDBRecord(this.ENTITY_ID);
                        if (dbItem != null)
                        {
                            txtDescription.Text = string.Format("{0}\n{1}\nCODE: {2}", dbItem.Item_Name, dbItem.Long_Description, dbItem.ItemCode);
                        }
                        break;
                    case APP_ENTITIES.PARTIES:
                        Tbl_MP_Master_Party dbParty = (new ServiceParties()).GetPartyByPartyID(this.ENTITY_ID);
                        if (dbParty != null)
                        {
                            txtDescription.Text = string.Format("{0} ({1})\n{2}", dbParty.PartyName, dbParty.PartyType, dbParty.PartyCode);
                        }
                        break;
                    case APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT:
                        TBL_MP_Master_Item_Attachments dbItemAttachment = (new ServiceInventoryItems()).GetInventoryItemAttachmentDBRecord(this.ENTITY_ID);
                        if (dbItemAttachment != null)
                        {
                            txtDescription.Text = string.Format("ATTACHMENT: {0}\nITEM:{1}\n{2}", dbItemAttachment.Title.ToUpper(), dbItemAttachment.TBL_MP_Master_Item.Item_Name, dbItemAttachment.TBL_MP_Master_Item.Long_Description );
                        }
                        break;
                    case APP_ENTITIES.APPLICATION_MODULES:
                        Tbl_MP_Master_Module dbModule = (new ServiceModules()).GetModuleDBRecordByID(this.ENTITY_ID);
                        if (dbModule != null)
                        {
                            txtDescription.Text = string.Format("NAME: {0}\nDISPLAY: {1}", dbModule.ModuleName, dbModule.DisplayName);
                        }
                        break;
                    case APP_ENTITIES.MODULES_FORMS:
                        Tbl_MP_Master_Module_Forms dbForm = (new ServiceModules()).GetModuleFormDBRecordByID(this.ENTITY_ID);
                        if (dbForm != null)
                        {
                            txtDescription.Text = string.Format("NAME: {0}\nDISPLAY: {1}", dbForm.FormName, dbForm.DisplayName);
                        }
                        break;
                    case APP_ENTITIES.ROLES:
                        TBL_MP_Master_Role dbRole = (new ServiceRoles()).GetRoleDBRecordByID(this.ENTITY_ID);
                        if (dbRole != null)
                        {
                            txtDescription.Text = string.Format("ROLE NAME: {0}\nROLE NO.: {1}", dbRole.RoleName, dbRole.RoleNo);
                        }
                        break;
                    case APP_ENTITIES.SALES_LEAD_ATTACHMENT:
                        TBL_MP_CRM_SM_SalesLead_Attachment dbLeadAttachment = (new ServiceSalesLead()).GetSalesLeadAttachmentDBRecord(this.ENTITY_ID);
                        if (dbLeadAttachment != null)
                        {
                            txtDescription.Text = string.Format("ATTACHMENT: {0}\nITEM:{1}\n{2}", dbLeadAttachment.Title.ToUpper(), dbLeadAttachment.TBL_MP_CRM_SM_SalesLead.LeadNo, dbLeadAttachment.TBL_MP_Master_UserList.Description1);
                        }
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT:
                        TBL_MP_CRM_SalesEnquiry_Attachments dbEnquiryAttachment = (new ServiceSalesEnquiry()).GetSalesEnquiryAttachmentDBRecord(this.ENTITY_ID);
                        if (dbEnquiryAttachment != null)
                        {
                            txtDescription.Text = string.Format("ATTACHMENT: {0}\nITEM:{1}\n{2}", dbEnquiryAttachment.Title.ToUpper(), dbEnquiryAttachment.TBL_MP_CRM_SalesEnquiry.SalesEnquiry_No, dbEnquiryAttachment.TBL_MP_Master_UserList.Description1);
                        }
                        break;
                    case APP_ENTITIES.SALES_QUOTATION_ATTACHMENT:
                        TBL_MP_CRM_SalesQuotation_Attachments dbQuoteAttachment = (new ServiceSalesQuotation()).GetSalesQuotationAttachmentDBRecord(this.ENTITY_ID);
                        if (dbQuoteAttachment != null)
                        {
                            txtDescription.Text = string.Format("ATTACHMENT: {0}\nITEM:{1}\n{2}", dbQuoteAttachment.Title.ToUpper(), dbQuoteAttachment.TBL_MP_CRM_SalesQuotation.Quotation_No, dbQuoteAttachment.TBL_MP_Master_UserList.Description1);
                        }
                        break;
                    case APP_ENTITIES.SALES_ORDER_ATTACHMENT:
                        TBL_MP_CRM_SalesOrder_Attachment dbOrderAttachment = (new ServiceSalesOrder()).GetSalesOrderAttachmentDBRecord(this.ENTITY_ID);
                        if (dbOrderAttachment != null)
                        {
                            txtDescription.Text = string.Format("ATTACHMENT: {0}\nITEM:{1}\n{2}", dbOrderAttachment.Title.ToUpper(), dbOrderAttachment.TBL_MP_CRM_SalesOrder.SalesOrderNo, dbOrderAttachment.TBL_MP_Master_UserList.Description1);
                        }
                        break;
                    case APP_ENTITIES.EMPLOYEES_ATTACHMENT:
                        TBL_MP_Master_Employee_Attachment dbEmpAttachment = (new ServiceEmployee()).GetEmployeeAttachmentDBRecord(this.ENTITY_ID);
                        if (dbEmpAttachment != null)
                        {
                            txtDescription.Text = string.Format("ATTACHMENT: {0}\nITEM:{1}\n{2}", dbEmpAttachment.Title.ToUpper(), dbEmpAttachment.TBL_MP_Master_Employee.EmployeeCode, dbEmpAttachment.TBL_MP_Master_UserList.Description1);
                        }
                        break;
                    case APP_ENTITIES.CONTACTS:
                        Tbl_MP_Master_PartyContact_Detail dbContact = (new ServiceContacts()).GetContactID(this.ENTITY_ID);
                        if (dbContact != null)
                        {
                            txtDescription.Text = string.Format("Contact Person Name : {0}\nAddress:{1}\nMobile No:{2}\nAt.Telephone No:{3}\nEmail ID:{4}\n FAX NO:{5}", dbContact.ContactPersoneName, dbContact.Address, dbContact.MobileNo, dbContact.TelephoneNo, dbContact.EmailID, dbContact.FaxNo);
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmDelete::PopulateDescription", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {
            PopulateDescription();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool result = false;
            try
            {
                if (!this.ValidateChildren()) return;
                switch (this.ENTITY)
                {
                    case APP_ENTITIES.INVENTORY_ITEM:
                        result = (new ServiceInventoryItems()).DeleteInventoryItemMasterInfo(this.ENTITY_ID, txtRemarks.Text.Trim(),Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.PARTIES:
                        result = (new ServiceParties()).DeleteParty(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT:
                        result = (new ServiceInventoryItems()).DeleteInventoryItemAttachment(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.SALES_LEAD_ATTACHMENT:
                        result = (new ServiceSalesLead()).DeleteSalesLeadAttachment(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT:
                        result = (new ServiceSalesEnquiry()).DeleteSalesEnquiryAttachment(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.SALES_QUOTATION_ATTACHMENT:
                        result = (new ServiceSalesQuotation()).DeleteSalesQuotationAttachment(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.APPLICATION_MODULES:
                        result = (new ServiceModules()).DeleteModuleMasterInfo(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.MODULES_FORMS:
                        result = (new ServiceModules()).DeleteModuleFormMasterInfo(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.ROLES:
                        result = (new ServiceRoles()).DeleteRoleMasterInfo(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.EMPLOYEES_ATTACHMENT:
                        result = (new ServiceEmployee()).DeleteEmployeeAttachment(this.ENTITY_ID, txtRemarks.Text.Trim(), Program.CURR_USER.EmployeeID);
                        break;
                    case APP_ENTITIES.CONTACTS:
                        result = (new ServiceContacts()).DeletePartyContact(this.ENTITY_ID, Program.CURR_USER.EmployeeID);
                        break;
                }
                if (result)
                    this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmDelete::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            if (txtRemarks.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtRemarks, "Required");
                e.Cancel = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
