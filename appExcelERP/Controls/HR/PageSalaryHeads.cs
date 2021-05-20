using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.HR;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using appExcelERP.Forms.HR;
using libERP.MODELS;

namespace appExcelERP.Controls.HR
{
    public partial class PageSalaryHeads : UserControl
    {
        public int SelecedPKID { get; set; }
        public string SelecedSalaryHeadName { get; set; }
        private BindingList<SalaryHeadModel> _SalaryHeadsList = null;
        private BindingList<SalaryHeadModel> _filteredSalaryHeadsList = null;
        public PageSalaryHeads()
        {
            InitializeComponent();
        }
        #region SALARY HEAD
        public void PopulateSalaryHeadsGrid()
        {
            try
            {
                _SalaryHeadsList = null;
                _SalaryHeadsList = AppCommon.ConvertToBindingList<SalaryHeadModel>((new ServiceSalaryHead()).GetAllSalaryHeads());
                gridSalaryHead.DataSource = _SalaryHeadsList;
                gridSalaryHead.Columns["ID"].Visible =
                gridSalaryHead.Columns["SalaryHeadID"].Visible =
                gridSalaryHead.Columns["SalaryHeadNatureID"].Visible =
                gridSalaryHead.Columns["SalaryHeadTypeID"].Visible =
                gridSalaryHead.Columns["IsActive"].Visible =
                gridSalaryHead.Columns["SearchText"].Visible = false;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageSalaryHeads::PopulateSalaryHeadsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridSalaryHead_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelecedPKID = (int)gridSalaryHead.Rows[e.RowIndex].Cells["ID"].Value;
                SelecedSalaryHeadName = gridSalaryHead.Rows[e.RowIndex].Cells["SalaryHead"].Value.ToString(); ;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageSalaryHeads::gridSalaryHead_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void PageSalaryHeads_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateSalaryHeadsGrid();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageSalaryHeads::PageSalaryHeads_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewSalaryHead_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditSalaryHead frm = new frmAddEditSalaryHead();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalaryHeadsGrid();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageSalaryHeads::btnAddNewSalaryHead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnEditSalaryHead_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditSalaryHead frm = new frmAddEditSalaryHead(this.SelecedPKID);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateSalaryHeadsGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageSalaryHeads::btnEditSalaryHead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnDeleteSalaryHead_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove\n{0} (Salary Head) ", this.SelecedSalaryHeadName.ToUpper());
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceSalaryHead()).DeleteSalaryHead(this.SelecedPKID))
                        PopulateSalaryHeadsGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageSalaryHeads::btnDeleteSalaryHead_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        private void btnSearchActiveUsers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredSalaryHeadsList = new BindingList<SalaryHeadModel>(_SalaryHeadsList.Where(p => p.SearchText.ToUpper().Contains(txtSearchSalaryHead.Text.ToUpper())).ToList());
                gridSalaryHead.DataSource = _filteredSalaryHeadsList;
                headerGroupMain.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridSalaryHead.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageSalaryHeads::btnSearchActiveUsers_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
