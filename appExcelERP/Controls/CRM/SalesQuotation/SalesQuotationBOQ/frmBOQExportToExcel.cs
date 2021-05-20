
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using libERP.MODELS.CRM;

namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    public partial class frmBOQExportToExcel : KryptonForm
    {
        public SalesQuotationBOQExportConfigurationModel SETTING { get; set; }
        
        public frmBOQExportToExcel()
        {
            InitializeComponent();
        }
        private void frmBOQExportToExcel_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.SETTING != null)
                {
                    rbtnParentItemsOnly.Checked = SETTING.ExportParentItemsOnly;
                    rbtnParentAndChildItems.Checked = SETTING.ExportParentAndChildItems;
                    chkIncludeMaterialSupplyCharges.Checked = SETTING.IncludeMaterialSupplyCharges;
                    chkIncludeInstallationCharges.Checked = SETTING.IncludeInstallationCharges;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmBOQExportToExcel::frmBOQExportToExcel_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.SETTING.ExportParentItemsOnly = rbtnParentItemsOnly.Checked;
                this.SETTING.ExportParentAndChildItems = rbtnParentAndChildItems.Checked;
                this.SETTING.IncludeMaterialSupplyCharges = chkIncludeMaterialSupplyCharges.Checked;
                this.SETTING.IncludeInstallationCharges = chkIncludeInstallationCharges.Checked;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmBOQExportToExcel::btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
