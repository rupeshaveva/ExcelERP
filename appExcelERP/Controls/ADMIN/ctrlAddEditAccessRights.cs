using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Controls.ADMIN
{
    public partial class ctrlAddEditAccessRights : UserControl
    {
        string uniCodeCharacter = "\u2714";
        public ctrlAddEditAccessRights()
        {
            InitializeComponent();
        }

        private void ctrlAddEditAccessRights_Load(object sender, EventArgs e)
        {
            headerTitle.Values.Description = string.Format("{0}\n{1}","Sachin","Patwardhan");
        }
        #region Button Operations
        private void kryptonCheckButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanAddNewRecord.Checked)
                {
                    btnCanAddNewRecord.Text = "Can Add a new Record " + uniCodeCharacter;
                }
                else
                    btnCanAddNewRecord.Text = "Can Add a new Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::kryptonCheckButton1_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void btnCanModifyRecord_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanModifyRecord.Checked)
                    btnCanModifyRecord.Text = "Can Modify Record " + uniCodeCharacter;
                else
                    btnCanModifyRecord.Text = "Can Modify Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::btnCanModifyRecord_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }
        private void btnCanDeleteRecord_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanDeleteRecord.Checked)
                    btnCanDeleteRecord.Text = "Can Delete Record " + uniCodeCharacter;
                else
                    btnCanDeleteRecord.Text = "Can Delete Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::btnCanDeleteRecord_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
        }
        private void btnCanUndeleteRecord_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanUndeleteRecord.Checked)
                    btnCanUndeleteRecord.Text = "Can Undelete Record " + uniCodeCharacter;
                else
                    btnCanUndeleteRecord.Text = "Can Undelete Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::btnCanUndeleteRecord_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        private void btnCanSearchRecord_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanSearchRecord.Checked)
                    btnCanSearchRecord.Text = "Can Search Record " + uniCodeCharacter;
                else
                    btnCanSearchRecord.Text = "Can Search Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::btnCanSearchRecord_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        private void btnCanViewRecord_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanViewRecord.Checked)
                    btnCanViewRecord.Text = "Can View Record " + uniCodeCharacter;
                else
                    btnCanViewRecord.Text = "Can View Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::btnCanViewRecord_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        
        }
        private void btnCanPrintRecord_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanPrintRecord.Checked)
                    btnCanPrintRecord.Text = "Can Print Record " + uniCodeCharacter;
                else
                    btnCanPrintRecord.Text = "Can Print Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::btnCanPrintRecord_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        private void btnCanApproveRecord_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btnCanApproveRecord.Checked)
                    btnCanApproveRecord.Text = "Can Approve Record " + uniCodeCharacter;
                else
                    btnCanApproveRecord.Text = "Can Approve Record ";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageADMINLanding::btnCanApproveRecord_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
         
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancel.Visible = false;
        }
        #endregion
    }
}
