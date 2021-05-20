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
using libERP.SERVICES;
using appExcelERP.Forms.UserList;
using appExcelERP.Forms.Masters;
using libERP.SERVICES.CRM;
using libERP.MODELS.COMMON;
using libERP.SERVICES.MASTER;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.MASTERS
{
    public partial class PageTermsAndConditions : UserControl
    {
        public int FormOperationID { get; set; }
        private int SelectedCategoryID = 0;

        private int SelectedTermID = 0;
        private string SelectedCategoryName = string.Empty;

        BindingList<SelectListItem> _categoryList = null;
        BindingList<SelectListItem> _filteredCategoryList = null;


        BindingList<SelectListItem> _termsList = null;
        BindingList<SelectListItem> _filteredTermsList = null;

        public PageTermsAndConditions()
        {
            InitializeComponent();
        }

        private void PageTermsAndConditions_Load(object sender, EventArgs e)
        {
            kryptonSplitContainer1.SplitterDistance= (int)(this.Width*.35);
            PopulateAllTnCCategories();
        }
        #region TERMS AND CONDITION CATEGORY
         private void PopulateAllTnCCategories()
        {
            try
            {
                _categoryList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceTermsAndConditions()).GetAllActiveTermAndConditionCategories());
                gridCategories.DataSource = _categoryList;
                gridCategories.Columns["ID"].Visible = gridCategories.Columns["Code"].Visible = gridCategories.Columns["IsActive"].Visible = gridCategories.Columns["DescriptionToUpper"].Visible = false;
                gridCategories.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupTnCCategory.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridCategories.Rows.Count);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::PopulateAllTnCCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void gridCategories_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedCategoryID = (int)gridCategories.Rows[e.RowIndex].Cells["ID"].Value;
                this.SelectedCategoryName = gridCategories.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                headerGroupTnCList.ValuesPrimary.Heading = string.Format("{0} - LIST OF TERMS & CONDITIONS", this.SelectedCategoryName);
                PopulateTermsListForCategory();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::gridCategories_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredCategoryList = new BindingList<SelectListItem>(_categoryList.Where(p => p.DescriptionToUpper.Contains(txtSearchCategory.Text.ToUpper())).ToList());
                gridCategories.DataSource = _filteredCategoryList;
                headerGroupTnCCategory.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridCategories.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::txtSearchCategory_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int tncAdminCategoryID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.TermAndConditionCategory].DEFAULT_VALUE;
                frmADMINUserList frm = new frmADMINUserList();
                frm.ADMINCategoryID = tncAdminCategoryID;
                frm.SHORT_CODE_REQUIRED = (new ServiceMASTERS()).IsShortCodeRequiredForAdminCategory(tncAdminCategoryID);
                frm.Text = string.Format("ADD NEW TERM & CONDITION CATEGORY");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAllTnCCategories();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::btnAddCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            try
            {
                int tncAdminCategoryID = Program.LIST_DEFAULTS[(int)APP_DEFAULT_VALUES.TermAndConditionCategory].DEFAULT_VALUE;
                frmADMINUserList frm = new frmADMINUserList(SelectedCategoryID);
                frm.ADMINCategoryID = tncAdminCategoryID;
                frm.SHORT_CODE_REQUIRED = (new ServiceMASTERS()).IsShortCodeRequiredForAdminCategory(tncAdminCategoryID);
                frm.Text = string.Format("EDIT TERM & CONDITION CATEGORY");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateAllTnCCategories();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::btnEditCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove\n{0}\npermanently", this.SelectedCategoryName);
                if (MessageBox.Show(strMessage, "CAUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    (new ServiceTermsAndConditions()).DeactivateTermAndConditionCategory(this.SelectedCategoryID);
                    PopulateAllTnCCategories();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::btnDeleteCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TERMS AND CONDITION LIST
        private void PopulateTermsListForCategory()
        {
            try
            {
                _termsList =AppCommon.ConvertToBindingList<SelectListItem>((new ServiceTermsAndConditions()).GetAllTermsAndConditionsForCategory(this.SelectedCategoryID));
                gridTermsList.DataSource = _termsList;
                gridTermsList.Columns["ID"].Visible =  gridTermsList.Columns["IsActive"].Visible = gridTermsList.Columns["DescriptionToUpper"].Visible = false;
                gridTermsList.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                headerGroupTnCList.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridTermsList.Rows.Count);

                if (gridTermsList.Rows.Count == 0)
                    btnEditTnC.Enabled = btnDeleteTnC.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                else
                    btnEditTnC.Enabled = btnDeleteTnC.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::PopulateTnCListForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridTermsList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridTermsList.Rows)
                {
                    if ((bool)row.Cells["IsActive"].Value == false)
                    {
                        row.DefaultCellStyle.Font = new Font(gridTermsList.Font.FontFamily, gridTermsList.Font.Size + 1, FontStyle.Strikeout);
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::gridTermsList_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void gridTermsList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedTermID = (int)gridTermsList.Rows[e.RowIndex].Cells["ID"].Value;
                bool isActive= (bool)gridTermsList.Rows[e.RowIndex].Cells["IsActive"].Value;
                btnDeleteTnC.Text = (isActive) ? "Delete" : "Undelete";

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::gridTermsList_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchTerms_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredTermsList = new BindingList<SelectListItem>(_termsList.Where(p => p.DescriptionToUpper.Contains(txtSearchTerms.Text.ToUpper())).ToList());
                gridTermsList.DataSource = _filteredTermsList;
                headerGroupTnCList.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridTermsList.Rows.Count);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::txtSearchTerms_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;

        }
        private void btnAddNewTnC_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditTermsAndCondition frm = new frmAddEditTermsAndCondition();
                frm.CategoryID = this.SelectedCategoryID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateTermsListForCategory();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::btnAddNewTnC_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditTnC_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditTermsAndCondition frm = new frmAddEditTermsAndCondition(this.SelectedTermID);
                frm.CategoryID = this.SelectedCategoryID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateTermsListForCategory();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::btnEditTnC_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteTnC_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = "Are you sure to remove select TERM & CONDITION";

                if (btnDeleteTnC.Text == "Delete")
                {
                    strMessage = "Are you sure to remove selected TERM & CONDITION";
                    if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        (new ServiceTermsAndConditions()).DeactivateTermAndCondition(this.SelectedTermID);
                        PopulateTermsListForCategory();
                    }
                    return;
                }
                if (btnDeleteTnC.Text == "Undelete")
                {
                    strMessage = "Are you sure to Activate selected TERM & CONDITION";
                    if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        (new ServiceTermsAndConditions()).ActivateTermAndCondition(this.SelectedTermID);
                        PopulateTermsListForCategory();
                    }
                    return;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "PageTermsAndConditions::btnDeleteTnC_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateAllTnCCategories();
        }
    }
}
