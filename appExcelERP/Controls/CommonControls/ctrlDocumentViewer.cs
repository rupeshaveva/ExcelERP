using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gnostice.Documents.Controls.WinForms;
using System.IO;
using libERP.SERVICES;
using libERP;
using appExcelERP.Forms;
using System.ComponentModel.DataAnnotations;
 
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlDocumentViewer : UserControl
    {

        private ServiceUOW _UOM = null;

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnDownload.Enabled = btnEmail.Enabled =  ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
                else
                {
                    btnDownload.Enabled = btnEmail.Enabled =  ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
            }
        }

        public ctrlDocumentViewer()
        {
            _UOM = new ServiceUOW();
        }

        public int AttachmentID { get; set; }
        public APP_ENTITIES EntityType { get; set; }
        public int EntityID { get; set; }

        public string FileName { get; set; }
        public string FileTitle { get; set; }
        public ctrlDocumentViewer(APP_ENTITIES entity, int entityID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.EntityType = entity;
            this.EntityID = entityID;
            btnDownload.Enabled = btnEmail.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
        }
        public ctrlDocumentViewer(string fileName,APP_ENTITIES entity,int entityID, int attachmentID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.FileName = fileName;
            this.AttachmentID = attachmentID;
            this.EntityType = entity;
            this.EntityID = entityID;
            btnDownload.Enabled = btnEmail.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;

        }
        private void ctrlDocumentViewer_Load(object sender, EventArgs e)
        {
            btnDownload.Enabled = btnEmail.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
        }

        public void ShowDocument(string fileName, int attachmentID)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.FileName = fileName;
                this.AttachmentID = attachmentID;
                headerGroupDocument.ValuesPrimary.Heading = this.FileTitle;
                if (File.Exists(fileName))
                {
                    byte[] array = File.ReadAllBytes(fileName);
                    Stream stream = new MemoryStream(array);
                    if (stream.Length > 0)
                    {
                        if (!ReadOnly) { btnDownload.Enabled = btnEmail.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True; }
                        documentViewer1.LoadDocument(stream);
                        headerGroupDocument.ValuesSecondary.Heading = string.Format("Size : {0:0.00}KB", (decimal)stream.Length / (decimal)1024);
                        PopulateHistory();
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Found Zero length Stream from the file\n{0}",fileName),"Error reading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to locate document " + fileName, "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                String errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "DocumentViewer::ShowDocument", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void ctrlDocumentViewer_Resize(object sender, EventArgs e)
        {
                        

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }
        private void btnZoomIN_Click(object sender, EventArgs e)
        {
            documentViewer1.ZoomIn();
        }
        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            documentViewer1.ZoomOut();
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = string.Format("{0}{1}", this.FileTitle, Path.GetExtension(this.FileName));
            saveFileDialog1.Title = "Save Document";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy(this.FileName, saveFileDialog1.FileName,true);
                switch (this.EntityType)
                {
                    case APP_ENTITIES.SALES_LEAD:
                        TBL_MP_CRM_SM_SalesLead_Attachment attachment = _UOM.AppDBContext.TBL_MP_CRM_SM_SalesLead_Attachment.Where(x => x.PK_AttachmentID == this.AttachmentID).FirstOrDefault();
                        if (attachment != null)
                        {
                            _UOM.AppDBContext.SaveChanges();
                            
                            // MAINTAINING HISTORY OF EMAIL SENT
                            TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                            history.AttachmentID = this.AttachmentID;
                            history.EntityType = (int)this.EntityType;
                            history.EmployeeID = Program.CURR_USER.EmployeeID;
                            history.CreateDatetime = AppCommon.GetServerDateTime();
                            history.Description = string.Format("Downloaded by {0} dt. {1}", Program.CURR_USER.UserFullName, history.CreateDatetime.Value.ToString("dd MMMyy hh:mmtt"));
                            _UOM.AppDBContext.TBL_MP_CRM_SM_DocumentHistory.Add(history);
                            _UOM.AppDBContext.SaveChanges();

                            PopulateHistory();
                        }

                        break;
                }
            }
        }
        private void PopulateRemarks()
        {
            switch (this.EntityType)
            {
                case APP_ENTITIES.SALES_LEAD:
                    break;
            }
        }
        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string tempPath = string.Format("{0}{1}", AppCommon.GetDefaultStorageFolderPath(), "Temp");
                if (!System.IO.Directory.Exists(tempPath))
                    System.IO.Directory.CreateDirectory(tempPath);
                string newfileName = string.Format("{0}\\{1}{2}", tempPath, FileTitle, Path.GetExtension(this.FileName));
                File.Copy(this.FileName, newfileName,true);
                frmSendMail frm = new frmSendMail();
                frm.AttachedFiles.Add(this.FileTitle, newfileName);
                frm.SOURCE_ENTITY = this.EntityType;
                frm.SOURCE_ENTITY_ID = this.EntityID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // MAINTAINING HISTORY OF EMAIL SENT
                    TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                    history.AttachmentID = this.AttachmentID;
                    history.EntityType = (int)this.EntityType;
                    history.EmployeeID = Program.CURR_USER.EmployeeID;
                    history.CreateDatetime = AppCommon.GetServerDateTime();
                    history.Description = string.Format("{0} sent Email Atachment\nTO: {1} dt. {2}\nSUB: {3}\n\n{4}", Program.CURR_USER.UserFullName, frm.txtMailTo.Text, history.CreateDatetime, frm.txtSubject.Text, frm.txtMessage.Text);
                    _UOM.AppDBContext.TBL_MP_CRM_SM_DocumentHistory.Add(history);
                    _UOM.AppDBContext.SaveChanges();

                    PopulateHistory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void PopulateHistory()
        {
            try
            {
                gridHistory.DataSource = _UOM.SalesAttachmentService.GetDocumentHistory(this.AttachmentID, this.EntityType);

                gridHistory.Columns["DocumentHistoryID"].Visible = gridHistory.Columns["AttachmentID"].Visible = gridHistory.Columns["EmployeeID"].Visible = gridHistory.Columns["EntityType"].Visible = false;
                gridHistory.Columns["Description"].Width = (int)(gridHistory.Width * .85);
                gridHistory.Columns["CreateDatetime"].Width = (int)(gridHistory.Width * .15);
                gridHistory.Columns["CreateDatetime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                gridHistory.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlDocumentViewer::PopulateHistory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
        private void btnEnable_Click(object sender, EventArgs e)
        {
            documentViewer1.Enabled = true;
        }

        
    }
}
