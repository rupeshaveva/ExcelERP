using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP;
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;
using libERP.MODELS;
using appExcelERP.Forms;

namespace appExcelERP.Controls.CRM.SalesOrder
{
    public partial class ControlSalesOrderContacts : UserControl
    {
        public int SelectedSalesOrderID { get; set; }
        public int SelectedClientID { get; set; }
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;

            }
        }
        public ControlSalesOrderContacts()
        {
            InitializeComponent();
        }
        public void PopulateClientInfo()
        {
            try
            {
                headerGroupMain.ValuesPrimary.Heading = "CLIENT CONTACTS:";
                txtClientInfo.Text = string.Empty;
                TBL_MP_CRM_SalesOrder objOrder = (new ServiceSalesOrder()).GetSalesOrderDBInfoByID(this.SelectedSalesOrderID);
                if (objOrder == null) return;
                SelectedClientID = (int)objOrder.FK_ClientID;
   
                string strInfo = string.Format("{0} ({1})", objOrder.Tbl_MP_Master_Party.PartyName.ToUpper(),objOrder.Tbl_MP_Master_Party.PartyCode);
                strInfo += string.Format("\nemail: {0} Website: {1}", objOrder.Tbl_MP_Master_Party.EmailID, objOrder.Tbl_MP_Master_Party.Website);
                strInfo += string.Format("\nGST NO: {0}", objOrder.Tbl_MP_Master_Party.GSTNO);
                txtClientInfo.Text = strInfo;
                gridCompanyContacts.DataSource = null;
                gridCompanyContacts.DataSource = (new ServiceContacts()).GetMultiSelectListContactsForParty(this.SelectedClientID);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderContacts::PopulateClientInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                BindingList<SelectListItem> selectedContacts = (new ServiceSalesOrder()).GetAllCompanyContactsForSalesOrder(this.SelectedSalesOrderID);
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
                MessageBox.Show(errMessage, "ControlSalesOrderContacts::gridCompanyContacts_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridCompanyContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!ReadOnly)
                    gridCompanyContacts.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridCompanyContacts.Rows[e.RowIndex].Cells["Selected"].Value);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderContacts::gridCompanyContacts_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            try
            {
                frmContact frm = new frmContact();
                frm.PartyID = this.SelectedClientID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gridCompanyContacts.DataSource = (new ServiceContacts()).GetMultiSelectListContactsForParty(this.SelectedClientID);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderContacts::btnAddNewContact_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if (selectedIDs == string.Empty) return;
                selectedIDs = selectedIDs.TrimEnd(Program.DefaultStringSeperator);

                (new ServiceSalesOrder()).UpdateSalesOrderContactReferences(this.SelectedSalesOrderID, selectedIDs);
                PopulateClientInfo();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderContacts::btnUpdateContacts_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
