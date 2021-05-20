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
using appExcelERP.Forms;
using libERP.MODELS;
using libERP;
using ComponentFactory.Krypton.Toolkit;
using appExcelERP.Forms.Parties;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.HR;

namespace appExcelERP.Controls.CRM
{
    public partial class PageParties : UserControl
    {
        public DB_FORM_IDs FormOperationID { get; set; }

        public int SelectedPartyID { get; set; }
        public int SelectedContactID { get; set; }
        public int SelectedAddressID { get; set; }

        public string SelectedPartyType { get; set; }

        BindingList<SelectListItem> _filteredList = null;
        BindingList<SelectListItem> _PartiesList = null;

        BindingList<SelectListItem> _AddressesList = null;
        BindingList<SelectListItem> _filteredAddressesList = null;
        

        public PageParties()
        {
            InitializeComponent();
        }
        public PageParties(string showForPartyType)
        {
            InitializeComponent();
            this.SelectedPartyType = showForPartyType;
        }

        private void PageCustomers_Resize(object sender, EventArgs e)
        {
            kryptonSplitContainer1.SplitterDistance= (int)(this.Width*.3);
        }
        private void PageCustomers_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PopulateParties();
            OnPartyTypeChange();
            this.Cursor = Cursors.Default;
            SetPermissionwiseButtonStatus();

        }
        private void SetPermissionwiseButtonStatus()
        {
            try
            {
                WhosWhoModel model = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == this.FormOperationID).FirstOrDefault();
                if (model != null)
                {
                    if (!model.CanAddNew)
                        btnAddNewContact.Enabled = btnAddNewParty.Enabled = ButtonEnabled.False;
                    if (!model.CanModify)
                        btnEditContact.Enabled = btnEditParty.Enabled = ButtonEnabled.False;
                    if (!model.CanDelete)
                        btnDeleteContact.Enabled = btnDeleteParty.Enabled = ButtonEnabled.False;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageParties::SetPermissionwiseButtonStatus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region PARTY
        private void PopulateParties()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _PartiesList = new BindingList<SelectListItem>();
                _PartiesList = AppCommon.ConvertToBindingList((new ServiceParties()).GetAllParties(this.SelectedPartyType));
                gridParties.DataSource = _PartiesList;
                gridParties.Columns["ID"].Visible = gridParties.Columns["Code"].Visible = gridParties.Columns["IsActive"].Visible = gridParties.Columns["DescriptionToUpper"].Visible = false;
                gridParties.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupParties.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridParties.Rows.Count);


                string title = string.Empty;
                switch (this.SelectedPartyType)
                {
                    case "S": title = "SUPPLIERS LIST"; break;
                    case "C": title = "CUSTOMERS LIST"; break;
                    case "A": title = "AGENTS/CONTRACTORS LIST"; break;
                }
                headerGroupParties.ValuesPrimary.Heading = title;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageParties::PopulateParties", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.Cursor = Cursors.WaitCursor;

        }
        private void gridParties_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (gridParties.Rows.Count > 0)
                    {
                        txtRemarks.Text = String.Empty;
                        this.SelectedPartyID = (int)gridParties.Rows[e.RowIndex].Cells["ID"].Value;
                        string[] arrString = gridParties.Rows[e.RowIndex].Cells["Description"].Value.ToString().Split('\n');
                        headerContacts.Values.Heading = string.Format("{0} Contacts", arrString[0]);
                        bool active = bool.Parse(gridParties.Rows[e.RowIndex].Cells["IsActive"].Value.ToString());
                        if (!active)
                        {
                            btnDeleteParty.Text = "&Undelete Party";
                            btnEditParty.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                            headerContacts.Enabled = false;
                            Tbl_MP_Master_Party dbParty = (new ServiceParties()).GetPartyByPartyID(this.SelectedPartyID);
                            if (dbParty != null)
                            {
                                string strTitle = string.Empty;
                                if (dbParty.DeletedBy != null)
                                    strTitle = string.Format("DELETED BY {0} DT. {1}", ServiceEmployee.GetEmployeeNameByID((int)dbParty.DeletedBy), dbParty.DeleteDateTime.Value.ToString("dd MMM yy HH:mmtt"));
                                headerGroupDelete.ValuesPrimary.Heading = strTitle;
                                txtRemarks.Text = dbParty.DeleteRemarks;
                            }
                        }
                        else
                        {
                            headerGroupDelete.ValuesPrimary.Heading = "ACTIVE PARTY";
                            btnDeleteParty.Text = "&Delete Party";
                            btnEditParty.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                            headerContacts.Enabled = true;
                            Tbl_MP_Master_Party dbParty = (new ServiceParties()).GetPartyByPartyID(this.SelectedPartyID);
                            if (dbParty != null)
                            {
                                txtRemarks.Text = dbParty.DeleteRemarks;
                            }

                        }
                        OnPartySelectionchange();
                    }
                    SetPermissionwiseButtonStatus();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageParties::gridParties_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        public void OnPartySelectionchange()
        {
            try
            {
                PopulateContacts();
                PopulatePartyAddresses();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageParties::OnPartySelectionchange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmParty frm = new frmParty(this.SelectedPartyType);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateParties();
            }
        }
        private void btnEditCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                frmParty frm = new frmParty(this.SelectedPartyID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateParties();
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "pageParties::btnEditCustomers_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnDeleteParty_Click(object sender, EventArgs e)
        {
            try
            {
                switch (btnDeleteParty.Text)
                {
                    case "&Delete Party":
                        frmDelete frm = new frmDelete(APP_ENTITIES.PARTIES, this.SelectedPartyID);
                        if (frm.ShowDialog() == DialogResult.OK)
                            PopulateParties();
                        break;
                    case "&Undelete Party":
                        string strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMM yy hh:mmtt"));
                        (new ServiceParties()).UndeleteParty(this.SelectedPartyID, strRemarks);
                        PopulateParties();
                        break;
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "pageParties::btnDeleteParty_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridParties_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    if (gridParties.Rows[e.RowIndex].Cells["IsActive"] != null)
                    {
                        bool active = bool.Parse(gridParties.Rows[e.RowIndex].Cells["IsActive"].Value.ToString());
                        if (!active)
                        {
                            //gridParties.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(gridParties.Font, FontStyle.Strikeout);
                            gridParties.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGray;
                            //gridParties.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DimGray;
                        }
                        else
                        {
                            //gridParties.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(gridParties.Font, FontStyle.Regular);
                            gridParties.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                            //gridParties.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "pageParties::gridParties_CellFormatting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchCompany_TextChanged(object sender, EventArgs e)
        {


        }
        private void gridCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectedPartyID = (int)gridParties.Rows[e.RowIndex].Cells["ID"].Value;
            btnEditCustomers_Click(btnEditParty, null);
        }
        private void btnRefreshParties_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                PopulateParties();
                OnPartyTypeChange();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageParties::btnRefreshParties_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void btnSearchParties_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredList = new BindingList<SelectListItem>(_PartiesList.Where(p => p.DescriptionToUpper.Contains(txtSearchCompany.Text.ToUpper())).ToList());
                gridParties.DataSource = _filteredList;
                headerGroupParties.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridParties.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "txtSearchCompany_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion
        #region PARTY CONTACTS
        private void PopulateContacts()
        {
            try
            {
                gridContacts.DataSource = (new ServiceContacts()).GetAllContactsForParty(this.SelectedPartyID);
                foreach (DataGridViewColumn col in gridContacts.Columns)
                {
                    col.Visible = false;
                }
                gridContacts.Columns["DisplayColumn1"].Visible = gridContacts.Columns["DisplayColumn2"].Visible = true;
                gridContacts.Columns["DisplayColumn1"].DefaultCellStyle.WrapMode = gridContacts.Columns["DisplayColumn2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageParties::PopulateContacts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void gridContacts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (gridContacts.Rows.Count > 0)
                    {
                        this.SelectedContactID = (int)gridContacts.Rows[e.RowIndex].Cells["ContactID"].Value;
                    }
                    SetPermissionwiseButtonStatus();
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "pageParties::gridContacts_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            try
            {
                frmContact frm = new frmContact();
                frm.PartyID = this.SelectedPartyID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateContacts();
                }
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "pageParties::btnAddNewContact_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void btnEditContact_Click(object sender, EventArgs e)
        {
            try
            {
                frmContact frm = new frmContact(SelectedContactID);
                frm.PartyID = this.SelectedPartyID;
                if (frm.ShowDialog() == DialogResult.OK)
                    PopulateContacts();
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
                if (ex.InnerException != null) strErr += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(strErr, "pageParties::btnEditContact_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteContact_Click(object sender, EventArgs e)
        {
            try
            {
                switch (btnDeleteContact.Text)
                {
                    case "&Delete Contact":
                        frmDelete frm = new frmDelete(APP_ENTITIES.CONTACTS, this.SelectedContactID);
                        if (frm.ShowDialog() == DialogResult.OK)
                            PopulateContacts();
                        //gridContacts.Refresh();
                        break;
                    case "&Undelete Contact":
                        string strRemarks = string.Format("Undelete by {0} dt. {1}", Program.CURR_USER.UserFullName, AppCommon.GetServerDateTime().ToString("dd MMM yy hh:mmtt"));
                        new ServiceContacts().UndeleteContact(this.SelectedContactID, strRemarks);
                        PopulateContacts();
                        //gridContacts.Refresh();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageParties::btnDeleteParty_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         #endregion

        #region PARTY ADDRESSES
        private void PopulatePartyAddresses()
        {
            try
            {
                _AddressesList =AppCommon.ConvertToBindingList<SelectListItem>( (new ServiceParties()).GetAllAddressesOfParty(this.SelectedPartyID));
                gridAddresses.DataSource = _AddressesList;
                gridAddresses.Columns["ID"].Visible =
                gridAddresses.Columns["Code"].Visible =
                gridAddresses.Columns["DescriptionToUpper"].Visible =
                gridAddresses.Columns["IsActive"].Visible = false;


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceParties::GetAllAddressesOfParty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridAddresses_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedAddressID = int.Parse(gridAddresses.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageParties::btnAddAddress_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddAddress_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditAddress frm = new frmAddEditAddress();
                frm.SelectedPartyID = this.SelectedPartyID;
                frm.SelectedPartyType = this.SelectedPartyType;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulatePartyAddresses();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageParties::btnAddAddress_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditAddress_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditAddress frm = new frmAddEditAddress(this.SelectedAddressID);
                frm.SelectedPartyType = this.SelectedPartyType;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulatePartyAddresses();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageParties::btnEditAddress_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
         
        public void OnPartyTypeChange()
        {
            try
            {
                //EventArguementModel args = new EventArguementModel();
                //args.Message = cboPartyType.Text + " Info.";
                //args.ID = this.SelectedPartyID;
                //OnSelectionChanged(args);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageParties::OnPartyTypeChange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public event PageSelectionChangedEventHandler SelectionChanged;
        protected virtual void OnSelectionChanged(EventArguementModel e)
        {
            SelectionChanged(this, e);
        }
       
       
    }
}
