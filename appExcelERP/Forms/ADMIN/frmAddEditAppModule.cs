
using libERP;
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
    public partial class frmAddEditAppModule : Form
    {
        public int ModuleID { get; set; }

        public frmAddEditAppModule()
        {
            InitializeComponent();
            this.ModuleID = 0;
        }
        public frmAddEditAppModule(int moduleID)
        {
            InitializeComponent();
            this.ModuleID = moduleID;
        }

        private void frmAddEditAppModule_Load(object sender, EventArgs e)
        {
            try
            {
                txtDisplayName.Text = txtModuleName.Text = txtSequence.Text = string.Empty;
                chkIsActive.Checked = true;
                txtSequence.Text = (new ServiceModules()).GetNewModuleSequenceNo().ToString();
                this.Text = "Application Module [ADD NEW]";
                if (this.ModuleID != 0)
                {
                    Tbl_MP_Master_Module module = (new ServiceModules()).GetModuleDBRecordByID(this.ModuleID);
                    if (module != null)
                    {
                        txtModuleName.Text = module.ModuleName;
                        txtDisplayName.Text = module.DisplayName;
                        txtSequence.Text = module.SequenceNo.ToString();
                        chkIsActive.Checked = module.IsActive;
                    }
                    this.Text = "Application Module [EDIT]";
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAppModule::frmAddEditAppModule_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Tbl_MP_Master_Module model = null;
            try
            {
                errorProvider1.Clear();

                if (this.ValidateChildren())
                {
                    if (this.ModuleID == 0)
                    {
                        model = new Tbl_MP_Master_Module()
                        {
                            ModuleName = txtModuleName.Text.Trim(),
                            DisplayName = txtDisplayName.Text.Trim(),
                            SequenceNo = int.Parse(txtSequence.Text.Trim()),
                            IsActive = chkIsActive.Checked
                        };
                        this.ModuleID = (new ServiceModules()).AddNewModule(model);
                        if (this.ModuleID != 0) this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        model = (new ServiceModules()).GetModuleDBRecordByID(this.ModuleID);
                        if (model != null)
                        {
                            model.ModuleName = txtModuleName.Text.Trim();
                            model.DisplayName = txtDisplayName.Text.Trim();
                            model.SequenceNo = int.Parse(txtSequence.Text.Trim());
                            model.IsActive = chkIsActive.Checked;
                            bool res = (new ServiceModules()).UpdateModule(model);
                            if (res) this.DialogResult = DialogResult.OK;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAppModule::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
        #region  VALIDATIONS
        private void txtModuleName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtModuleName.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtModuleName, "Mandatory!! and Unique");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAppModule::txtModuleName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "frmAddEditAppModule::txtDisplayName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSequence_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSequence.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSequence, "Mandatory!!");
                    e.Cancel = true;
                }
                if (!txtSequence.Text.All(Char.IsDigit))
                {
                    errorProvider1.SetError(txtSequence, "Enter Digits only [0-9]");
                    e.Cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                string errMessage = string.Format("{0}\n{1}", ex.Message, ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditAppModule::txtSequence_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         #endregion

       
    }
}
