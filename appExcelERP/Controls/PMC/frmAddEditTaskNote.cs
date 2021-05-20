using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Controls.PMC
{
    public partial class frmAddEditTaskNote : Form
    {
        public frmAddEditTaskNote()
        {
            InitializeComponent();
        }
        private void frmAddEditTaskNote_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = Program.CURR_USER.UserFullName.ToUpper() + " - Remarks";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTaskNote::frmAddEditTaskNote_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.ValidateChildren())
                    this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTaskNote::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtRemarks.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtRemarks,"Remarks is mandatory.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditTaskNote::txtRemarks_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtComplete_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if(txtComplete.Text.Trim()==string.Empty)
                {
                    errorProvider1.SetError(txtRemarks, "Remarks is mandatory.");
                    e.Cancel = true;
                    return;
                }
                float val = 0;
                float.TryParse(txtComplete.Text, out val);
                if(val>100)
                {
                    txtComplete.Text = "100";
                }

            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtComplete,string.Format("Invalid value.\n{0}",ex.Message));
                e.Cancel = true;

            }
        }

       

      
    }
}
