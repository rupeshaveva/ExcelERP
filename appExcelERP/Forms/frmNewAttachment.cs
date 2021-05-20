
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES;
using libERP.MODELS;
using libERP.MODELS.COMMON;

namespace appExcelERP
{
    public partial class frmNewAttachment : KryptonForm
    {
        private ServiceUOW _UOM = null;

        public bool LoginSuccess { get; set; }
        public frmNewAttachment()
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.LoginSuccess = false;
        }
        public frmNewAttachment(int documentID)
        {
            _UOM = new ServiceUOW();
            InitializeComponent();
            this.LoginSuccess = false;
        }
        public bool OpenForEditing { get; set; }
        public string AttachedFilePath { get; set; }

        public string AttachedFileName {
            get
            {
                return Path.GetFileName(this.AttachedFilePath);
                
            }
        }

        public int CategoryID { get; set; }
        public string Title { get { return txtTitle.Text; } set { txtTitle.Text = value; } }

        private void frmNewAttachment_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            PopulateDocumentCategories();
            if (this.OpenForEditing)
            {
                cboCategories.SelectedItem = ((List<SelectListItem>)cboCategories.DataSource).Where(x => x.ID == this.CategoryID).FirstOrDefault();
            }
        }
        private void PopulateDocumentCategories()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange(_UOM.MasterService.GetMasterListForAdminCategories(APP_ADMIN_CATEGORIES.ATTACHMENT_DOCUMENT_TYPE));
                cboCategories.DataSource = LST;
                cboCategories.DisplayMember = "Description";
                cboCategories.ValueMember = "ID";
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmNewAttachment::PopulateDocumentCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.ValidateChildren())
                {
                    this.AttachedFilePath = txtFileName.Text;
                    this.CategoryID = (int)cboCategories.SelectedValue;
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmNewAttachment::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void txtFileName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFileName.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFileName, "File Name cannot be left blank.");
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (txtTitle.Text.Trim() == string.Empty)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Document Title cannot be left blank.");
            }

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
                //System.IO.StreamReader sr = new
                //   System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                //sr.Close();
            }
        }

        private void frmNewAttachment_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void buttonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cboCategories_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboCategories.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboCategories, " Category is Invalid");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmNewAttachment::cboCategories_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
