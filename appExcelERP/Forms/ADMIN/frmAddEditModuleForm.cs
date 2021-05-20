using libERP;
using libERP.MODELS;
using libERP.SERVICES;
using libERP.SERVICES.ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.ADMIN
{
    public partial class frmAddEditModuleForm : Form
    {
        public int ModuleID { get; set; }
        public int FormID { get; set; }


        public frmAddEditModuleForm()
        {
            InitializeComponent();
        }
        public frmAddEditModuleForm(int formID)
        {
            InitializeComponent();
            this.FormID = formID;
        }
        private void frmAddEditModuleForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtDisplayName.Text = txtFormName.Text = string.Empty;
                chkIsActive.Checked = true;

                cboModule.DataSource = (new ServiceModules()).GetAllActiveModules();
                cboModule.DisplayMember = "Description";
                cboModule.ValueMember = "ID";
                if(ModuleID!=0)
                    cboModule.SelectedItem = ((List<SelectListItem>)cboModule.DataSource).Where(x => x.ID == this.ModuleID).FirstOrDefault();
                this.Text = "Module Feature [ADD NEW]";

                if (this.FormID != 0)
                {
                    Tbl_MP_Master_Module_Forms form = (new ServiceModules()).GetModuleFormDBRecordByID(this.FormID);
                    if (form != null)
                    {
                        txtFormName.Text = form.FormName;
                        txtDisplayName.Text = form.DisplayName;
                        cboModule.SelectedItem = ((List<SelectListItem>)cboModule.DataSource).Where(x => x.ID == form.FK_ModuleId).FirstOrDefault();
                        chkIsActive.Checked = form.IsActive;
                    }
                    this.Text = "Module Feature [EDIT]";
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditModuleForm::frmAddEditModuleForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Tbl_MP_Master_Module_Forms form = null;
            try
            {
                errorProvider1.Clear();

                if (this.ValidateChildren())
                {
                    if (this.FormID == 0)
                    {
                        form = new Tbl_MP_Master_Module_Forms()
                        {
                            FormName = txtFormName.Text.Trim(),
                            DisplayName = txtDisplayName.Text.Trim(),
                            FK_ModuleId = ((SelectListItem)(cboModule.SelectedItem)).ID,
                            IsActive = chkIsActive.Checked
                        };
                        this.FormID = (new ServiceModules()).AddNewModuleForm(form);
                        if (this.FormID != 0) this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        form = (new ServiceModules()).GetModuleFormDBRecordByID(this.FormID);
                        if (form != null)
                        {
                            form.FormName = txtFormName.Text.Trim();
                            form.DisplayName = txtDisplayName.Text.Trim();
                            form.IsActive = chkIsActive.Checked;
                            form.FK_ModuleId = ((SelectListItem)(cboModule.SelectedItem)).ID;
                            bool res = (new ServiceModules()).UpdateModuleForm(form);
                            if (res) this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditModuleForm::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        #region VALIDATIONS
        private void txtFormName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtFormName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtFormName, "Mandatory!! and Unique");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditModuleForm::txtFormName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtDisplayName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtDisplayName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtDisplayName, "Mandatory!!");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditModuleForm::txtDisplayName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cboModule_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboModule.SelectedItem == null)
                {
                    errorProvider1.SetError(cboModule, "Mandatory!!");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditModuleForm::cboModule_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

       
    }
}
