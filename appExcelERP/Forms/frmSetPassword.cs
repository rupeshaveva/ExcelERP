using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;
using libERP.SERVICES;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;

namespace appExcelERP.Forms
{
    public partial class frmSetPassword : KryptonForm
    {
        PASSWORD_TYPE _passwordType = PASSWORD_TYPE.NONE;
        public frmSetPassword(PASSWORD_TYPE type)
        {
            InitializeComponent();
            _passwordType = type;

        }

        private void frmSetPassword_Load(object sender, EventArgs e)
        {
            switch (_passwordType)
            {
                case PASSWORD_TYPE.EMAIL_PASSWORD:
                    headerGroupPassword.ValuesPrimary.Heading = "Reset your Email Password";
                    break;
                case PASSWORD_TYPE.LOGIN_PASSWORD:
                    headerGroupPassword.ValuesPrimary.Heading = "Reset your Login Password";
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren())
                {
                    switch (_passwordType)
                    {
                        case PASSWORD_TYPE.LOGIN_PASSWORD:
                            (new ServiceEmployee()).UpdateLoginPassword(Program.CURR_USER.EmployeeID, txtPassword.Text);
                            break;
                        case PASSWORD_TYPE.EMAIL_PASSWORD:
                            (new ServiceEmployee()).UpdateEmailPassword(Program.CURR_USER.EmployeeID,txtPassword.Text);
                            break;

                    }
                }
                this.DialogResult = DialogResult.OK; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "btnChange_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtPassword, "Password can't be left blank.");
                e.Cancel = true;
            }
        }

        private void txtRetypePassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtRetypePassword.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtRetypePassword, "Password can't be left blank.");
                e.Cancel = true;
            }
            if (txtRetypePassword.Text.Trim() != txtPassword.Text.Trim())
            {
                errorProvider1.SetError(txtRetypePassword, "Password and Retype Password do not match");
                e.Cancel = true;
            }
        }


    }

}
