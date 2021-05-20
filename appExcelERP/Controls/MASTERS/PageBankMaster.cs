using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.COMMON;
using appExcelERP.Forms.MASTER;
using libERP.MODELS.MASTER;

namespace appExcelERP.Controls.MASTERS
{
    public partial class PageBankMaster : UserControl
    {
        public int SelectedBankID { get; set; }
        public int SelectedBranchID { get; set; }

        BindingList<SelectListItem> _BanksList = null;
        BindingList<SelectListItem> _filteredBanksList = null;

        BindingList<BankBranchModel> _BankBranchesList = null;
        BindingList<BankBranchModel> _filteredBankBranchesList = null;

        public PageBankMaster()
        {
            InitializeComponent();
        }
        private void PageBankMaster_Load(object sender, EventArgs e)
        {
            
            try
            {
                PopulateBanksGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::PageBankMaster_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void PageBankMaster_Resize(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance= (int)(this.Width*.4);
            
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SelectedBankID = 0;
                this.SelectedBranchID = 0;
                PopulateBanksGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
       
        #region MANAGE BANKS
        public void PopulateBanksGrid()
        {
            try
            {
                _BanksList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceBankMaster()).GetAllBanks());
                gridBanks.DataSource = _BanksList;
                gridBanks.Columns["ID"].Visible = gridBanks.Columns["Code"].Visible = gridBanks.Columns["IsActive"].Visible = gridBanks.Columns["DescriptionToUpper"].Visible = false;
                headerGroupBank.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridBanks.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::PopulateBanksGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNewBank_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditBank frm = new frmAddEditBank();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBanksGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::btnAddNewBank_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditBank_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditBank frm = new frmAddEditBank(this.SelectedBankID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBanksGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::btnEditBank_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchBank_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredBanksList = new BindingList<SelectListItem>(_BanksList.Where(p => p.Description.ToUpper().Contains(txtSearchBank.Text.ToUpper())).ToList());
                gridBanks.DataSource = _filteredBanksList;
                headerGroupBank.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridBanks.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::txtSearchBank_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridBanks_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedBankID= (int)(gridBanks.Rows[e.RowIndex].Cells["ID"].Value);
                PopulateBankBranchesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::gridBanks_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridBanks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in gridBanks.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridBanks.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridBanks.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::gridBanks_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        #endregion

        #region BANK BRANCHES
        public void PopulateBankBranchesGrid()
        {
            try
            {
                _BankBranchesList = AppCommon.ConvertToBindingList<BankBranchModel>((new ServiceBankMaster()).GetAllBankBranches(this.SelectedBankID));
                gridBankBranches.DataSource = _BankBranchesList;
                gridBankBranches.Columns["ISActive"].Visible =
                gridBankBranches.Columns["BankBranchID"].Visible =
                gridBankBranches.Columns["BankID"].Visible =
                gridBankBranches.Columns["SearchText"].Visible = false;
                headerGroupBranches.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridBankBranches.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::PopulateBankBranchesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnAddNewBranch_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditBankBranch frm = new frmAddEditBankBranch();
                frm.BankID = this.SelectedBankID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBankBranchesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::btnAddNewBranch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnEditBranch_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditBankBranch frm = new frmAddEditBankBranch(this.SelectedBranchID);
                frm.BankID = this.SelectedBankID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateBankBranchesGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::btnEditBranch_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchBranches_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _filteredBankBranchesList = new BindingList<BankBranchModel>(_BankBranchesList.Where(p => p.SearchText.ToUpper().Contains(txtSearchBranches.Text.ToUpper())).ToList());
                gridBankBranches.DataSource = _filteredBankBranchesList;
                headerGroupBranches.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridBankBranches.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::txtSearchBranches_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridBankBranches_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedBranchID = (int)(gridBankBranches.Rows[e.RowIndex].Cells["BankBranchID"].Value);
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::gridBankBranches_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridBankBranches_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in gridBankBranches.Rows)
                {
                    bool isActive = (bool)row.Cells["IsActive"].Value;
                    if (!isActive)
                    {
                        row.DefaultCellStyle.Font = new Font(gridBankBranches.Font, FontStyle.Strikeout);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        row.DefaultCellStyle.Font = new Font(gridBankBranches.Font, FontStyle.Regular);
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageBankMaster::gridBankBranches_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        
    }
}
