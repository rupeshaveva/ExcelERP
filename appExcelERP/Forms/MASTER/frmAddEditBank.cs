using ComponentFactory.Krypton.Toolkit;
using libERP;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.MASTER
{
    public partial class frmAddEditBank : KryptonForm
    {
        public int SelectedBankID { get; set; }

        public frmAddEditBank()
        {
            InitializeComponent();
        }
        public frmAddEditBank(int ID)
        {
            InitializeComponent();
            SelectedBankID = ID;
        }
        private void frmAddEditBank_Load(object sender, EventArgs e)
        {
            try
            {
                if (SelectedBankID == 0)
                {
                    txtBankName.Text = string.Empty;
                    chkIsActive.Checked = true;
                }
                else
                {
                    TBL_MP_Master_Bank model = (new ServiceBankMaster()).GetBankDbRecord(this.SelectedBankID);
                    if (model != null)
                    {
                        txtBankName.Text = model.BankName;
                        chkIsActive.Checked = model.IsActive;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBank::frmAddEditBank_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtBankName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(txtBankName.Text==string.Empty)
                {
                    errorProvider1.SetError(txtBankName, "Bank name mandatory");
                    e.Cancel=true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBank::txtBankName_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_Master_Bank model = null;
            ServiceBankMaster _service = new ServiceBankMaster();
            try
            {
                errorProvider1.Clear();
                if (!this.ValidateChildren()) return;

                if (this.SelectedBankID == 0)
                    model = new TBL_MP_Master_Bank();
                else
                    model = _service.GetBankDbRecord(this.SelectedBankID);

                model.BankName = txtBankName.Text.Trim().ToUpper();
                model.IsActive = chkIsActive.Checked;

                if (this.SelectedBankID == 0)
                   this.SelectedBankID= _service.AddNewBank(model);
                else
                    _service.UpdateBank(model);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditBank::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
