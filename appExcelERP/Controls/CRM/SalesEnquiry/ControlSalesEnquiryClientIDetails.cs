using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using libERP;
using libERP.MODELS;
using appExcelERP.Forms;
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.CRM
{

    public partial class ControlSalesEnquiryClientIDetails : UserControl
    {
        public int SelectedEnquiryID { get; set; }
        public int SelectedClientID { get; set; }
        public int SelectedConsultantID { get; set; }

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnAddClientContacts.Enabled = btnAddConsultantContacts.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnUpdateContacts.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    gridCompanyContacts.Enabled = gridConsultantContacts.Enabled = txtClientInfo.Enabled = txtConsultantInfo.Enabled= false;
                }
                else
                {
                    btnAddClientContacts.Enabled = btnAddConsultantContacts.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnUpdateContacts.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    gridCompanyContacts.Enabled = gridConsultantContacts.Enabled = txtClientInfo.Enabled = txtConsultantInfo.Enabled = true;
                }
            }
        }
        
        public ControlSalesEnquiryClientIDetails()
        {
            InitializeComponent();
        }
        private void ControlSalesEnquiryClientIDetails_Load(object sender, EventArgs e)
        {

        }

        public void PopulateClientAndConsultantInfo()
        {
            try
            {
                gridCompanyContacts.DataSource = gridConsultantContacts.DataSource = null;
                txtClientInfo.Text = txtConsultantInfo.Text = string.Empty;
                headerGroupClient.ValuesPrimary.Heading = "CLIENT:";
                headerGroupConsultant.ValuesPrimary.Heading = "CONSULTANT:";
                PopulateClientInfo();
                PopulateConsultantInfo();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::PopulateClientAndConsultantInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region CLIENT INFO
        private void PopulateClientInfo()
        {
            try
            {
                headerGroupClient.ValuesPrimary.Heading = "CLIENT:";
                txtClientInfo.Text = string.Empty;
                TBL_MP_CRM_SalesEnquiry objEnquiry= (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(this.SelectedEnquiryID);
                if (objEnquiry == null) return;
                SelectedClientID = (int)objEnquiry.FK_Customer_ID;
                headerGroupClient.ValuesPrimary.Heading = string.Format("CLIENT: {0}", objEnquiry.Tbl_MP_Master_Party.PartyCode);
                string strInfo = objEnquiry.Tbl_MP_Master_Party.PartyName.ToUpper();
                strInfo+= string.Format("\nemail: {0} Website: {1}", objEnquiry.Tbl_MP_Master_Party.EmailID, objEnquiry.Tbl_MP_Master_Party.Website);
                strInfo += string.Format("\nGST NO: {0}", objEnquiry.Tbl_MP_Master_Party.GSTNO);
                txtClientInfo.Text = strInfo;
                gridCompanyContacts.DataSource= (new ServiceContacts()).GetMultiSelectListContactsForParty(this.SelectedClientID);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::PopulateClientInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddClientContacts_Click(object sender, EventArgs e)
        {
            try
            {
                frmContact frm = new frmContact();
                frm.PartyID = this.SelectedClientID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateClientInfo();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::btnAddClientContacts_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdateContacts_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string selectedIDs = string.Empty;
            try
            {
                foreach (DataGridViewRow row in gridCompanyContacts.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        selectedIDs += string.Format("{0}{1}", row.Cells["ID"].Value, Program.DefaultStringSeperator);
                    }
                }
                foreach (DataGridViewRow row in gridConsultantContacts.Rows)
                {
                    if ((bool)row.Cells["Selected"].Value == true)
                    {
                        selectedIDs += string.Format("{0}{1}", row.Cells["ID"].Value, Program.DefaultStringSeperator);
                    }
                }

                if (selectedIDs == string.Empty) return;
                selectedIDs = selectedIDs.TrimEnd(Program.DefaultStringSeperator);
                (new ServiceSalesEnquiry()).UpdateSalesEnquiryContactReferences(this.SelectedEnquiryID, selectedIDs);
                PopulateClientAndConsultantInfo();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::btnUpdateContacts_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridCompanyContacts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridCompanyContacts.Columns["ID"].Visible = gridCompanyContacts.Columns["DescriptionToUpper"].Visible = gridCompanyContacts.Columns["EntityType"].Visible = false;
                gridCompanyContacts.Columns["Selected"].Width = (int)(gridCompanyContacts.Width * .1);
                gridCompanyContacts.Columns["Code"].Width = (int)(gridCompanyContacts.Width * .45);
                gridCompanyContacts.Columns["Description"].Width = (int)(gridCompanyContacts.Width * .45);
                // MARK EXISTING CONTACTS AS SELECTED
                BindingList<SelectListItem> selectedContacts = (new ServiceSalesEnquiry()).GetAllCompanyContactsForSalesEnquiry(this.SelectedEnquiryID);
                foreach (DataGridViewRow dRow in gridCompanyContacts.Rows)
                {
                    SelectListItem currItem = selectedContacts.Where(x => x.ID == (int)dRow.Cells["ID"].Value).FirstOrDefault();
                    if (currItem != null) dRow.Cells["Selected"].Value = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::gridCompanyContacts_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridCompanyContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!ReadOnly)
                gridCompanyContacts.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridCompanyContacts.Rows[e.RowIndex].Cells["Selected"].Value);
        }
        #endregion
        #region CONSULTANT
        private void PopulateConsultantInfo()
        {
            try
            {
                headerGroupConsultant.ValuesPrimary.Heading = "CONSULTANT:";
                txtConsultantInfo.Text = string.Empty;
                TBL_MP_CRM_SalesEnquiry objEnquiry = (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(this.SelectedEnquiryID);
                if (objEnquiry == null) return;
                if (objEnquiry.Enquiry_Genrated_By != "A") return;
                this.SelectedConsultantID = (int)objEnquiry.FK_EnqGenerated_Agent_ID;
                Tbl_MP_Master_Party dbParty = (new ServiceParties()).GetPartyByPartyID(this.SelectedConsultantID);
                
                headerGroupConsultant.ValuesPrimary.Heading = string.Format("CONSULTANT: {0}", objEnquiry.Enquiry_Genrated_By_Name);
                string strInfo = objEnquiry.Enquiry_Genrated_By_Name.ToUpper();
                strInfo += string.Format("\nemail: {0} Website: {1}", dbParty.EmailID, dbParty.Website);
                strInfo += string.Format("\nGST NO: {0}", dbParty.GSTNO);
                txtConsultantInfo.Text = strInfo;
                gridConsultantContacts.DataSource = (new ServiceContacts()).GetMultiSelectListContactsForParty(this.SelectedConsultantID);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::PopulateConsultantInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddConsultantContacts_Click(object sender, EventArgs e)
        {
            try
            {
                frmContact frm = new frmContact();
                frm.PartyID = this.SelectedConsultantID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateConsultantInfo();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::btnAddConsultantContacts_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridConsultantContacts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridConsultantContacts.Columns["ID"].Visible = gridConsultantContacts.Columns["DescriptionToUpper"].Visible = gridConsultantContacts.Columns["EntityType"].Visible = false;
                gridConsultantContacts.Columns["Selected"].Width = (int)(gridConsultantContacts.Width * .1);
                gridConsultantContacts.Columns["Code"].Width = (int)(gridConsultantContacts.Width * .45);
                gridConsultantContacts.Columns["Description"].Width = (int)(gridConsultantContacts.Width * .45);
                // MARK EXISTING CONTACTS AS SELECTED
                BindingList<SelectListItem> selectedContacts = (new ServiceSalesEnquiry()).GetAllConsultantContactsForSalesEnquiry(this.SelectedEnquiryID);
                foreach (DataGridViewRow dRow in gridConsultantContacts.Rows)
                {
                    SelectListItem currItem = selectedContacts.Where(x => x.ID == (int)dRow.Cells["ID"].Value).FirstOrDefault();
                    if (currItem != null) dRow.Cells["Selected"].Value = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryClientIDetails::gridConsultantContacts_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridConsultantContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!ReadOnly)
                gridConsultantContacts.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridConsultantContacts.Rows[e.RowIndex].Cells["Selected"].Value);
        }
        #endregion




    }

}
