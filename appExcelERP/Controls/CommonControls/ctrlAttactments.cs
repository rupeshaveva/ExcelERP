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
using libERP.MODELS;
using libERP;
using Gnostice.Documents.Controls.WinForms;
using System.IO;
//using DocumentServices.Modules.Readers.MsgReader;
 
using MsgReader;
using appExcelERP.Forms;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.CRM;
using libERP.SERVICES.HR;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlAttachments : UserControl
    {
        private ServiceUOW _UNIT;
        public APP_ENTITIES ENTITY { get; set; }
        public int SelectedEntityID { get; set; }
        public int SelectedAttachmentID { get; set; }
               
        private string _ServerFilePath = string.Empty;
        private string _FileTitle = string.Empty;

        List<SelectListItem> _documents = null;
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnAddNew.Enabled = btnEdit.Enabled = btnDelete.Enabled= ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
                else
                {
                    btnAddNew.Enabled = btnEdit.Enabled = btnDelete.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
            }
        }

        public Orientation CONTROL_ORIENTATION { get; set; }
        
        public ctrlAttachments()
        {
            _UNIT = new ServiceUOW();
        }
        public void SetReadOnly()
        {
            try
            {
                btnAddNew.Enabled = btnDelete.Enabled = btnEdit.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlAttachments::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        ctrlDocumentViewer _docViewer = null;
        public void InitializeDocumentViewer()
        {
            try
            {
                if (_docViewer == null)
                {
                    _docViewer = new ctrlDocumentViewer(_ServerFilePath, this.ENTITY, this.SelectedEntityID, this.SelectedAttachmentID);
                }
                
                _docViewer.FileTitle = _FileTitle;
                splitContainerMain.Panel2.Controls.Clear();
                splitContainerMain.Panel2.Controls.Add(_docViewer);
                _docViewer.Dock = DockStyle.Fill;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAttachment::InitializeDocumentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        public ctrlAttachments(APP_ENTITIES _entitry)
        {
            _UNIT = new ServiceUOW();
            InitializeComponent();
            this.ENTITY = _entitry;
            Gnostice.Documents.Framework.ActivateLicense("1DD5-DBE6-E25F-15E6-7BFC-5062-64E8-58CE-71B6-CBA3-9ADF-F55A");
            

        }
        public void PopulateAttachmentCategories()
        {
            
            listCategories.DataSource = _UNIT.MasterService.GetMasterListForAdminCategories(APP_ADMIN_CATEGORIES.ATTACHMENT_DOCUMENT_TYPE);
            listCategories.ValueMember = "ID";
            listCategories.DisplayMember = "Description";
        }
        public void PopulateDocuments()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _docViewer = null;
                InitializeDocumentViewer();
                _docViewer.ReadOnly = this.ReadOnly;
                btnEdit.Enabled = btnDelete.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                _docViewer.btnDownload.Enabled = _docViewer.btnEmail.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                _documents = (new ServiceMASTERS()).GetDocumentsOfEntityForID(this.ENTITY, this.SelectedEntityID);
                listDocuments.DataSource = _documents;
                listDocuments.ValueMember = "ID";
                listDocuments.DisplayMember = "Description";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlAttachments::PopulateDocuments", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void listDocuments_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                splitContainerMain.Panel2.Controls.Clear();
                SelectListItem selItem = (SelectListItem)listDocuments.SelectedItem;
                if (selItem != null)
                {
                    if (!ReadOnly)
                    {
                        btnEdit.Enabled = btnDelete.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    }
                    this.SelectedAttachmentID = selItem.ID;
                    SelectListItem item = _documents.Where(x => x.ID == this.SelectedAttachmentID).FirstOrDefault();
                    if (item != null)
                    {
                        _ServerFilePath = item.Code;
                        _FileTitle = item.Description;
                        if (_ServerFilePath.Trim().ToLower().EndsWith("msg")) PopulateOutlookViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("pdf")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("jpg")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("jpeg")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("png")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("gif")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("docx")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("doc")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("xls")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("xlsx")) PopulateDocumentViewer();
                        if (_ServerFilePath.Trim().ToLower().EndsWith("dwg")) PopulateDocumentViewer();
                    }

                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "listDocuments_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _viewer.ViewOutlookMessage(_ServerFilePath);
                //_viewer.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAttachments::PopulateOutlookViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateImageViewer()
        {
            try
            {
                ctrlImageViewer _viewer = new ctrlImageViewer(_ServerFilePath);
                splitContainerMain.Panel2.Controls.Clear();
                splitContainerMain.Panel2.Controls.Add(_viewer);
                _viewer.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAttachments::PopulateImageViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateDocumentViewer()
        {
            try
            {
                InitializeDocumentViewer();
                _docViewer.EntityID = this.SelectedEntityID;
                _docViewer.FileTitle = _FileTitle;
                _docViewer.ReadOnly = this.ReadOnly;
                _docViewer.btnDownload.Enabled = _docViewer.btnEmail.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                _docViewer.ShowDocument(this._ServerFilePath, this.SelectedAttachmentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAttachment::PopulateDocumentViewer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            
            
        }
         private void ctrlAttachments_Resize(object sender, EventArgs e)
        {
            int width = splitContainerMain.Width;
            splitContainerMain.SplitterDistance= (int)(width * .2);
        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Helper Methods
        public string GetTemporaryFolder()
        {
            var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
        }
        #endregion

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewAttachment frm = new frmNewAttachment();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    switch (ENTITY)
                    {
                        case APP_ENTITIES.INVENTORY_ITEM:
                            this.SelectedAttachmentID = (new ServiceInventoryItems()).AddNewInventoryItemsAttachment(
                                this.SelectedEntityID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.SALES_LEAD:
                            this.SelectedAttachmentID = (new ServiceSalesLead()).AddNewSalesLeadAttachment(
                                this.SelectedEntityID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.SALES_ENQUIRY:
                         this.SelectedAttachmentID = (new ServiceSalesEnquiry()).AddNewSalesEnquiryAttachment(
                               this.SelectedEntityID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.SALES_QUOTATION:
                            this.SelectedAttachmentID = (new ServiceSalesQuotation()).AddNewSalesQuotationAttachment(
                                this.SelectedEntityID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.SALES_ORDER:
                            
                            this.SelectedAttachmentID = (new ServiceSalesOrder()).AddNewSalesOrderAttachment(
                                this.SelectedEntityID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.EMPLOYEES:

                            this.SelectedAttachmentID = (new ServiceEmployee()).AddNewEmployeeAttachment(
                                this.SelectedEntityID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;


                    }
                    this.PopulateDocuments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAttachments::btnAddNew_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string serverPath = string.Empty;
                string strTitle = string.Empty;
                int DocCategoryID = 0;
                              
                // GET VALUES TO BE DISPLAYED IN ATTACHMENT EDIT FORM
                switch (this.ENTITY)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        TBL_MP_CRM_SM_SalesLead_Attachment objLead = (new ServiceSalesLead()).GetSalesLeadAttachmentDBRecord(SelectedAttachmentID);
                        if (objLead != null)
                        {
                            DocCategoryID = (int)objLead.FK_CategoryID;
                            strTitle = objLead.Title;
                        }
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY:
                        TBL_MP_CRM_SalesEnquiry_Attachments objEnquiry = (new ServiceSalesEnquiry()).GetSalesEnquiryAttachmentDBRecord(SelectedAttachmentID);
                        if(objEnquiry !=null)
                        {
                            DocCategoryID = (int)objEnquiry.FK_CategoryID;
                            strTitle = objEnquiry.Title;
                        }
                        break;
                    case APP_ENTITIES.SALES_QUOTATION:
                        TBL_MP_CRM_SalesQuotation_Attachments objQuotation = (new ServiceSalesQuotation()).GetSalesQuotationAttachmentDBRecord(SelectedAttachmentID);
                        if (objQuotation != null)
                        {
                            DocCategoryID = (int)objQuotation.FK_CategoryID;
                            strTitle = objQuotation.Title;
                        }
                        break;
                    case APP_ENTITIES.SALES_ORDER:
                        TBL_MP_CRM_SalesOrder_Attachment objOrder = (new ServiceSalesOrder()).GetSalesOrderAttachmentDBRecord(SelectedAttachmentID);
                        if (objOrder != null)
                        {
                            DocCategoryID = (int)objOrder.FK_CategoryID;
                            strTitle = objOrder.Title;
                        }
                        break;
                    case APP_ENTITIES.INVENTORY_ITEM:
                        TBL_MP_Master_Item_Attachments objItem = (new ServiceInventoryItems()).GetInventoryItemAttachmentDBRecord(SelectedAttachmentID);
                        if (objItem != null)
                        {
                            DocCategoryID = (int)objItem.FK_CategoryID;
                            strTitle = objItem.Title;
                        }
                        break;
                    case APP_ENTITIES.EMPLOYEES:
                        TBL_MP_Master_Employee_Attachment objEmp = (new ServiceEmployee()).GetEmployeeAttachmentDBRecord(SelectedAttachmentID);
                        if (objEmp != null)
                        {
                            DocCategoryID = (int)objEmp.FK_CategoryID;
                            strTitle = objEmp.Title;
                        }
                        break;
                }

                // OPEN ATTACHMENT FORM FOR EDITING 
                frmNewAttachment frm = new frmNewAttachment();
                frm.CategoryID = DocCategoryID;
                frm.Title = strTitle;
                frm.OpenForEditing=true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    switch (this.ENTITY)
                    {
                        case APP_ENTITIES.SALES_LEAD:
                            (new ServiceSalesLead()).UpdateSalesLeadAttachment(SelectedAttachmentID,frm.CategoryID,frm.Title,frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.SALES_ENQUIRY:
                            (new ServiceSalesEnquiry()).UpdateSalesEnquiryAttachment(SelectedAttachmentID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.SALES_QUOTATION:
                            (new ServiceSalesQuotation()).UpdateSalesQuotationAttachment(SelectedAttachmentID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.SALES_ORDER:
                            (new ServiceSalesOrder()).UpdateSalesOrderAttachment(SelectedAttachmentID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.INVENTORY_ITEM:
                            (new ServiceInventoryItems()).UpdateInventoryItemAttachment(SelectedAttachmentID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                        case APP_ENTITIES.EMPLOYEES:
                            (new ServiceEmployee()).UpdateEmployeeAttachment(SelectedAttachmentID, frm.CategoryID, frm.Title, frm.AttachedFilePath, Program.CURR_USER.EmployeeID);
                            break;
                    }
                    this.PopulateDocuments();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlAttachment::btnEdit_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
        }
        private void ctrlAttachments_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeDocumentViewer();
                splitContainerMain.Orientation = this.CONTROL_ORIENTATION;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ctrlAttachments::ctrlAttachments_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDelete frm = null;
            try
            {
                switch (this.ENTITY)
                {
                    case APP_ENTITIES.INVENTORY_ITEM:
                        frm = new frmDelete(APP_ENTITIES.INVENTORY_ITEM_ATTACHMENT, this.SelectedAttachmentID);
                        break;
                    case APP_ENTITIES.SALES_LEAD:
                        frm = new frmDelete(APP_ENTITIES.SALES_LEAD_ATTACHMENT, this.SelectedAttachmentID);
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY:
                        frm = new frmDelete(APP_ENTITIES.SALES_ENQUIRY_ATTACHMENT, this.SelectedAttachmentID);
                        break;
                    case APP_ENTITIES.SALES_QUOTATION:
                        frm = new frmDelete(APP_ENTITIES.SALES_QUOTATION_ATTACHMENT, this.SelectedAttachmentID);
                        break;
                    case APP_ENTITIES.SALES_ORDER:
                        frm = new frmDelete(APP_ENTITIES.SALES_ORDER_ATTACHMENT, this.SelectedAttachmentID);
                        break;
                    case APP_ENTITIES.EMPLOYEES:
                        frm = new frmDelete(APP_ENTITIES.EMPLOYEES_ATTACHMENT, this.SelectedAttachmentID);
                        break;

                }
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateDocuments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlAttachments::btnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}



