using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using libERP.SERVICES;
using libERP;
using appExcelERP.Controls.CommonControls;
using libERP.MODELS.COMMON;
using libERP.MODELS;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.HR;
using libERP.SERVICES.CRM;

namespace appExcelERP.Controls.ADMIN
{
    public partial class pageDeletedAttachments : UserControl
    {
        public int FormOperationID { get; set; }


        public APP_ENTITIES SELECTED_ENTITY_TYPE { get; set; }

        BindingList<SelectListItem> _AttachmentsList = null;
        BindingList<SelectListItem> _filteredAttachmentsList = null;
        public int SelectedAttachmentID { get; set; }
        public string SelectedAttachmentPath { get; set; }

        ctrlDocumentViewer _docViewer = null;
        public pageDeletedAttachments()
        {
            InitializeComponent();
            this.SelectedAttachmentID = 0;
            Gnostice.Documents.Framework.ActivateLicense("1DD5-DBE6-E25F-15E6-7BFC-5062-64E8-58CE-71B6-CBA3-9ADF-F55A");
        }
        private void pageDeletedAttachments_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateDocumentForDropdown();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageDeletedAttachments::pageDeletedAttachments_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void PopulateDocumentForDropdown()
        {
            try
            {
                List<SelectListItem> lstDocsFor = new List<SelectListItem>();
                lstDocsFor.Add(new SelectListItem() { ID = 0, Description = "(Select Doc. Type)" });
                lstDocsFor.Add(new SelectListItem() { ID = (int)APP_ENTITIES.SALES_LEAD_ATTACHMENT, Description="Sales Lead Docs." });
                lstDocsFor.Add(new SelectListItem() { ID = (int)APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT, Description = "Sales Enquiry Docs." });
                lstDocsFor.Add(new SelectListItem() { ID = (int)APP_ENTITIES.SALES_QUOTATION_ATTACHMENT, Description = "Sales Quotation Docs." });
                lstDocsFor.Add(new SelectListItem() { ID = (int)APP_ENTITIES.SALES_ORDER_ATTACHMENT, Description = "Sales Order Docs." });
                lstDocsFor.Add(new SelectListItem() { ID = (int)APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT, Description = "Inventory Item Docs." });
                lstDocsFor.Add(new SelectListItem() { ID = (int)APP_ENTITIES.EMPLOYEES_ATTACHMENT, Description = "Employee Docs." });
               

                cboDocumentFor.DataSource = lstDocsFor;
                cboDocumentFor.DisplayMember = "Description";
                cboDocumentFor.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageDeletedAttachments::PopulateDocumentForDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboDocumentFor_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboDocumentFor.SelectedItem != null)
                {
                    this.SELECTED_ENTITY_TYPE = (APP_ENTITIES)((SelectListItem)cboDocumentFor.SelectedItem).ID;
                    PopulateDeletedAttachments();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageDeletedAttachments::cboDocumentFor_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PopulateDeletedAttachments()
        {
            this.Cursor = Cursors.WaitCursor;
            headerGroupDeleteInfo.Enabled = false;
            try
            {
                _AttachmentsList = null;
                switch (this.SELECTED_ENTITY_TYPE)
                {
                    case APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT:
                        _AttachmentsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceInventoryItems()).GetAllDeletedAttachments());
                        if (_AttachmentsList.Count > 0) headerGroupDeleteInfo.Enabled = true;
                        break;
                    case APP_ENTITIES.SALES_LEAD_ATTACHMENT:
                        _AttachmentsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceSalesLead()).GetAllDeletedLeadAttachments());
                        if (_AttachmentsList.Count > 0) headerGroupDeleteInfo.Enabled = true;
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT:
                        _AttachmentsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceSalesEnquiry()).GetAllDeletedSalesEnquiryAttachments());
                        if (_AttachmentsList.Count > 0) headerGroupDeleteInfo.Enabled = true;
                        break;
                    case APP_ENTITIES.SALES_QUOTATION_ATTACHMENT:
                        _AttachmentsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceSalesQuotation()).GetAllDeletedSalesQuotationAttachments());
                        if (_AttachmentsList.Count > 0) headerGroupDeleteInfo.Enabled = true;
                        break;
                    case APP_ENTITIES.SALES_ORDER_ATTACHMENT:
                        _AttachmentsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceSalesOrder()).GetAllDeletedSalesOrderAttachments());
                        if (_AttachmentsList.Count > 0) headerGroupDeleteInfo.Enabled = true;
                        break;
                    case APP_ENTITIES.EMPLOYEES_ATTACHMENT:
                        _AttachmentsList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceEmployee()).GetAllDeletedEmployeeAttachments());
                        if (_AttachmentsList.Count > 0) headerGroupDeleteInfo.Enabled = true;
                        break;

                }
                if (_AttachmentsList != null)
                {
                    gridAttachments.DataSource = _AttachmentsList;
                    gridAttachments.Columns["ID"].Visible = gridAttachments.Columns["Code"].Visible = gridAttachments.Columns["IsActive"].Visible = gridAttachments.Columns["DescriptionToUpper"].Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageDeletedAttachments::PopulateDeletedAttachments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.WaitCursor;
        }
        private void gridAttachments_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedAttachmentID = (int)gridAttachments.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedAttachmentPath = gridAttachments.Rows[e.RowIndex].Cells["Code"].Value.ToString();
                OnAttachmentSelectionChange();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageDeletedAttachments::gridAttachments_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void OnAttachmentSelectionChange()
        {
            try
            {
                if (this.SelectedAttachmentID != 0) btnUndeleteAtachment.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                switch (this.SELECTED_ENTITY_TYPE)
                {
                    case APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT:
                        TBL_MP_Master_Item_Attachments itemAttachment = (new ServiceInventoryItems()).GetInventoryItemAttachmentDBRecord(this.SelectedAttachmentID);
                        if (itemAttachment != null)
                        {
                            headerGroupDeleteInfo.ValuesPrimary.Heading = string.Format("DELETED BY {0} DT. {1}", ServiceEmployee.GetEmployeeNameByID((int)itemAttachment.DeletedBy),itemAttachment.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                            txtDeleteRemark.Text = itemAttachment.DeleteRemarks;
                        }
                    break;
                    case APP_ENTITIES.SALES_LEAD_ATTACHMENT:
                        TBL_MP_CRM_SM_SalesLead_Attachment LeadAttachment = (new ServiceSalesLead()).GetSalesLeadAttachmentDBRecord(this.SelectedAttachmentID);
                        if (LeadAttachment != null)
                        {
                            headerGroupDeleteInfo.ValuesPrimary.Heading = string.Format("DELETED BY {0} DT. {1}", ServiceEmployee.GetEmployeeNameByID((int)LeadAttachment.DeletedBy), LeadAttachment.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                            txtDeleteRemark.Text = LeadAttachment.DeleteRemarks;
                        }
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT:
                        TBL_MP_CRM_SalesEnquiry_Attachments EnqAttachment = (new ServiceSalesEnquiry()).GetSalesEnquiryAttachmentDBRecord(this.SelectedAttachmentID);
                        if (EnqAttachment != null)
                        {
                            headerGroupDeleteInfo.ValuesPrimary.Heading = string.Format("DELETED BY {0} DT. {1}", ServiceEmployee.GetEmployeeNameByID((int)EnqAttachment.DeletedBy), EnqAttachment.DeletedDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                            txtDeleteRemark.Text = EnqAttachment.DeleteRemarks;
                        }
                        break;
                    case APP_ENTITIES.SALES_QUOTATION_ATTACHMENT:
                        TBL_MP_CRM_SalesQuotation_Attachments QuotAttachment = (new ServiceSalesQuotation()).GetSalesQuotationAttachmentDBRecord(this.SelectedAttachmentID);
                        if (QuotAttachment != null)
                        {
                            headerGroupDeleteInfo.ValuesPrimary.Heading = string.Format("DELETED BY {0} DT. {1}", ServiceEmployee.GetEmployeeNameByID((int)QuotAttachment.DeletedBy), QuotAttachment.DeletedDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                            txtDeleteRemark.Text = QuotAttachment.DeleteRemarks;
                        }
                        break;
                    case APP_ENTITIES.SALES_ORDER_ATTACHMENT:
                        TBL_MP_CRM_SalesOrder_Attachment OrderAttachment = (new ServiceSalesOrder()).GetSalesOrderAttachmentDBRecord(this.SelectedAttachmentID);
                        if (OrderAttachment != null)
                        {
                            headerGroupDeleteInfo.ValuesPrimary.Heading = string.Format("DELETED BY {0} DT. {1}", ServiceEmployee.GetEmployeeNameByID((int)OrderAttachment.DeletedBy), OrderAttachment.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                            txtDeleteRemark.Text = OrderAttachment.DeleteRemarks;
                        }
                        break;
                    case APP_ENTITIES.EMPLOYEES_ATTACHMENT:
                        TBL_MP_Master_Employee_Attachment EmpAttachment = (new ServiceEmployee()).GetEmployeeAttachmentDBRecord(this.SelectedAttachmentID);
                        if (EmpAttachment != null)
                        {
                            headerGroupDeleteInfo.ValuesPrimary.Heading = string.Format("DELETED BY {0} DT. {1}", ServiceEmployee.GetEmployeeNameByID((int)EmpAttachment.DeletedBy), EmpAttachment.DeleteDatetime.Value.ToString("dd MMM yy hh:mmtt"));
                            txtDeleteRemark.Text = EmpAttachment.DeleteRemarks;
                        }
                        break;



                }
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("msg")) PopulateOutlookViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("pdf")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("jpg")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("jpeg")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("png")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("gif")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("docx")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("doc")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("xls")) PopulateDocumentViewer();
                if (this.SelectedAttachmentPath.Trim().ToLower().EndsWith("xlsx")) PopulateDocumentViewer();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageDeletedAttachments::OnAttachmentSelectionChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateOutlookViewer()
        {
            try
            {
                ctrlOutlookViewer _viewer = new ctrlOutlookViewer();
                splitContainerMain.Panel2.Controls.Clear();
                splitContainerMain.Panel2.Controls.Add(_viewer);
                _viewer.Dock = DockStyle.Fill;
                _viewer.ViewOutlookMessage(this.SelectedAttachmentPath);
             
                //_viewer.Enabled = false;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageDeletedAttachments::PopulateOutlookViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateDocumentViewer()
        {
            try
            {
                switch (this.SELECTED_ENTITY_TYPE)
                {
                    case APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT:
                        TBL_MP_Master_Item_Attachments itemAttachment = (new ServiceInventoryItems()).GetInventoryItemAttachmentDBRecord(this.SelectedAttachmentID);
                        _docViewer = new ctrlDocumentViewer(APP_ENTITIES.INVENTORY_ITEM, (int)itemAttachment.FK_Inventory_Item_ID);
                        _docViewer.FileTitle = itemAttachment.Title;
                        _docViewer.ReadOnly = true;
                        _docViewer.ShowDocument(this.SelectedAttachmentPath, this.SelectedAttachmentID);
                        splitContainerMain.Panel2.Controls.Clear();
                        splitContainerMain.Panel2.Controls.Add(_docViewer);
                        _docViewer.Dock = DockStyle.Fill;
                        break;
                    case APP_ENTITIES.SALES_LEAD_ATTACHMENT:
                        TBL_MP_CRM_SM_SalesLead_Attachment leadAttachment = (new ServiceSalesLead()).GetSalesLeadAttachmentDBRecord(this.SelectedAttachmentID);
                        _docViewer = new ctrlDocumentViewer(APP_ENTITIES.SALES_LEAD, (int)leadAttachment.FK_SalesLeadID);
                        _docViewer.FileTitle = leadAttachment.Title;
                        _docViewer.ReadOnly = true;
                        _docViewer.ShowDocument(this.SelectedAttachmentPath, this.SelectedAttachmentID);
                        splitContainerMain.Panel2.Controls.Clear();
                        splitContainerMain.Panel2.Controls.Add(_docViewer);
                        _docViewer.Dock = DockStyle.Fill;
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT:
                        TBL_MP_CRM_SalesEnquiry_Attachments EnqAttachment = (new ServiceSalesEnquiry()).GetSalesEnquiryAttachmentDBRecord(this.SelectedAttachmentID);
                        _docViewer = new ctrlDocumentViewer(APP_ENTITIES.SALES_ENQUIRY, (int)EnqAttachment.FK_SalesEnquiryID);
                        _docViewer.FileTitle = EnqAttachment.Title;
                        _docViewer.ReadOnly = true;
                        _docViewer.ShowDocument(this.SelectedAttachmentPath, this.SelectedAttachmentID);
                        splitContainerMain.Panel2.Controls.Clear();
                        splitContainerMain.Panel2.Controls.Add(_docViewer);
                        _docViewer.Dock = DockStyle.Fill;
                        break;
                    case APP_ENTITIES.SALES_QUOTATION_ATTACHMENT:
                        TBL_MP_CRM_SalesQuotation_Attachments QuotAttachment = (new ServiceSalesQuotation()).GetSalesQuotationAttachmentDBRecord(this.SelectedAttachmentID);
                        _docViewer = new ctrlDocumentViewer(APP_ENTITIES.SALES_QUOTATION, (int)QuotAttachment.FK_SalesQuotationID);
                        _docViewer.FileTitle = QuotAttachment.Title;
                        _docViewer.ReadOnly = true;
                        _docViewer.ShowDocument(this.SelectedAttachmentPath, this.SelectedAttachmentID);
                        splitContainerMain.Panel2.Controls.Clear();
                        splitContainerMain.Panel2.Controls.Add(_docViewer);
                        _docViewer.Dock = DockStyle.Fill;
                        break;
                    case APP_ENTITIES.SALES_ORDER_ATTACHMENT:
                        TBL_MP_CRM_SalesOrder_Attachment OrderAttachment = (new ServiceSalesOrder()).GetSalesOrderAttachmentDBRecord(this.SelectedAttachmentID);
                        _docViewer = new ctrlDocumentViewer(APP_ENTITIES.SALES_ORDER, (int)OrderAttachment.FK_SalesOrderID);
                        _docViewer.FileTitle = OrderAttachment.Title;
                        _docViewer.ReadOnly = true;
                        _docViewer.ShowDocument(this.SelectedAttachmentPath, this.SelectedAttachmentID);
                        splitContainerMain.Panel2.Controls.Clear();
                        splitContainerMain.Panel2.Controls.Add(_docViewer);
                        _docViewer.Dock = DockStyle.Fill;
                        break;
                    case APP_ENTITIES.EMPLOYEES_ATTACHMENT:
                        TBL_MP_Master_Employee_Attachment EmpAttachment = (new ServiceEmployee()).GetEmployeeAttachmentDBRecord(this.SelectedAttachmentID);
                        _docViewer = new ctrlDocumentViewer(APP_ENTITIES.EMPLOYEES, (int)EmpAttachment.FK_EmployeeId);
                        _docViewer.FileTitle = EmpAttachment.Title;
                        _docViewer.ReadOnly = true;
                        _docViewer.ShowDocument(this.SelectedAttachmentPath, this.SelectedAttachmentID);
                        splitContainerMain.Panel2.Controls.Clear();
                        splitContainerMain.Panel2.Controls.Add(_docViewer);
                        _docViewer.Dock = DockStyle.Fill;
                        break;
                }
                 
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageDeletedAttachments::PopulateDocumentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnUndeleteAtachment_Click(object sender, EventArgs e)
        {
            string strRemarks = string.Empty;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                switch (this.SELECTED_ENTITY_TYPE)
                {
                    case APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT:
                        strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMMyy hh:mmtt"));
                        (new ServiceInventoryItems()).UndeleteInventoryItemAttachment(this.SelectedAttachmentID, strRemarks);
                        break;
                    case APP_ENTITIES.SALES_LEAD_ATTACHMENT:
                        strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMMyy hh:mmtt"));
                        (new ServiceSalesLead()).UndeleteSalesLeadAttachment(this.SelectedAttachmentID, strRemarks);
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT:
                        strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMMyy hh:mmtt"));
                        (new ServiceSalesEnquiry()).UndeleteSalesEnquiryAttachment(this.SelectedAttachmentID, strRemarks);
                        break;
                    case APP_ENTITIES.SALES_QUOTATION_ATTACHMENT:
                        strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMMyy hh:mmtt"));
                        (new ServiceSalesQuotation()).UndeleteSalesQuotationAttachment(this.SelectedAttachmentID, strRemarks);
                        break;
                    case APP_ENTITIES.SALES_ORDER_ATTACHMENT:
                        strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMMyy hh:mmtt"));
                        (new ServiceSalesOrder()).UndeleteSalesOrderAttachment(this.SelectedAttachmentID, strRemarks);
                        break;
                    case APP_ENTITIES.EMPLOYEES_ATTACHMENT:
                        strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMMyy hh:mmtt"));
                        (new ServiceEmployee()).UndeleteEmployeeAttachment(this.SelectedAttachmentID, strRemarks);
                        break;
                }
                PopulateDeletedAttachments();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageDeletedAttachments::btnUndeleteAtachment_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
       private void txtSearchAttachments_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredAttachmentsList = new BindingList<SelectListItem>(_AttachmentsList.Where(p => p.DescriptionToUpper.Contains(txtSearchAttachments.Text.Trim().ToUpper())).ToList());
                gridAttachments.DataSource = _filteredAttachmentsList;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(ex.Message, "pageDeletedAttachments::txtSearchAttachments_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
