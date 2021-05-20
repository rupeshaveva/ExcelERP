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
using libERP.MODELS;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Forms
{
    public partial class frmSelectParty : KryptonForm
    {
        public int SelectedPartyID { get; set; }
        public frmSelectParty()
        {
            InitializeComponent();
        }

        private void btnAddNewCompany_Click(object sender, EventArgs e)
        {
            frmParty frm = new frmParty("C");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PopulateCompaniesDropdown();
                cboCompanies.SelectedItem = ((List<SelectListItem>)cboCompanies.DataSource).Where(x => x.ID == frm.SelectedID).FirstOrDefault();
            }
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmContact frm = new frmContact();
            frm.PartyID = this.SelectedPartyID;
            if (frm.ShowDialog() == DialogResult.OK)
                PopulateContactsGrid();
        }

        private void frmSelectParty_Load(object sender, EventArgs e)
        {
            PopulateCompaniesDropdown();
        }

        private void PopulateCompaniesDropdown()
        {
            try
            {
                List<SelectListItem> LST = new List<SelectListItem>();
                LST.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                LST.AddRange((new ServiceParties()).GetAllParties("C"));
                cboCompanies.DataSource = LST;
                cboCompanies.ValueMember = "ID";
                cboCompanies.DisplayMember = "Description";
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        private void cboCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedPartyID = ((SelectListItem)cboCompanies.SelectedItem).ID;
            PopulateContactsGrid();
        }

        private void PopulateContactsGrid()
        {
            gridContacts.DataSource = (new ServiceContacts()).GetContactsOfPartyForSelection(this.SelectedPartyID);
            gridContacts.Columns["ContactID"].Visible = false;
            gridContacts.Columns["Selected"].Width = (int)(gridContacts.Width * .1);
            gridContacts.Columns["Description1"].Width = (int)(gridContacts.Width * .5);
            gridContacts.Columns["Description2"].Width = (int)(gridContacts.Width * .4);

            gridContacts.Columns["Description1"].DefaultCellStyle.WrapMode = gridContacts.Columns["Description2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;


        }

        private void cboCompanies_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboCompanies.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboCompanies, " Companies name is Invalid");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSelectParty::cboCompanies_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
