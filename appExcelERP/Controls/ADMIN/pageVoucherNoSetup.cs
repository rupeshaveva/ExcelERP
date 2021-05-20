using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Forms.ADMIN;
using libERP.SERVICES.ADMIN;

namespace appExcelERP.Controls.ADMIN
{
    public partial class pageVoucherNoSetup : UserControl
    {
        public int SelectedFormID { get; set; }
        public string SelectedFormName { get; set; }
        public int SelectedVoucherSetupID { get; set; }

        public pageVoucherNoSetup()
        {
            InitializeComponent();
        }
        private void pageVoucherNoSetup_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateDocumentTypesGrid();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::pageVoucherNoSetup_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pageVoucherNoSetup_Resize(object sender, EventArgs e)
        {
            try
            {
                splitContainerMain.SplitterDistance = (int)(this.Width * .25);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::pageVoucherNoSetup_Resize", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateDocumentTypesGrid()
        {
            try
            {
                this.SelectedFormID = 0;
                this.SelectedFormName = string.Empty;
                gridDocumentTypes.DataSource = (new ServiceVoucherNoSetup()).GetAllFormTypes();
                gridDocumentTypes.Columns["ID"].Visible =
                gridDocumentTypes.Columns["Description"].Visible =
                gridDocumentTypes.Columns["Code"].Visible =
                gridDocumentTypes.Columns["IsActive"].Visible = false;
                headerGroupDocuments.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridDocumentTypes.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::PopulateDocumentTypesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridDocumentTypes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedFormID = int.Parse(gridDocumentTypes.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                this.SelectedFormName = gridDocumentTypes.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                headerGroupVoucherSetup.ValuesPrimary.Heading = string.Format("{0}\nVoucher Setup List", this.SelectedFormName.ToUpper());
                PopulateVoucherNoSetupGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::gridDocumentTypes_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateVoucherNoSetupGrid()
        {
            try
            {
                this.SelectedVoucherSetupID = 0;
                gridVoucherSetupList.DataSource = (new ServiceVoucherNoSetup()).GetAllVoucherNoSetupForFormID(this.SelectedFormID);
                gridVoucherSetupList.Columns["ID"].Visible =
                gridVoucherSetupList.Columns["FormID"].Visible =
                gridVoucherSetupList.Columns["YearID"].Visible = false;
                headerGroupVoucherSetup.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridVoucherSetupList.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::PopulateDocumentTypesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridVoucherSetupList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedVoucherSetupID = int.Parse(gridVoucherSetupList.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::gridVoucherSetupList_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewVoucherSetup_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditVoucherNoSetup frm = new frmAddEditVoucherNoSetup();
                frm.FORM_NAME = this.SelectedFormName;
                frm.FORM_ID = this.SelectedFormID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateVoucherNoSetupGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::btnAddNewVoucherSetup_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditVoucherNoSetup_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditVoucherNoSetup frm = new frmAddEditVoucherNoSetup(this.SelectedVoucherSetupID);
                frm.FORM_NAME = this.SelectedFormName;
                frm.FORM_ID = this.SelectedFormID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateVoucherNoSetupGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageVoucherNoSetup::btnEditVoucherNoSetup_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
