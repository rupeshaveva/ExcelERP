using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES.MASTER;
using libERP.MODELS;
using appExcelERP.Forms.UserList;
using libERP.SERVICES.CRM;
using appExcelERP.Forms.CRM;

namespace appExcelERP.Controls.CRM
{
    public partial class pageQuestionnaire : UserControl
    {
        public int selectedCategoryID { get; set; }
        public int selectedRelatedToID { get; set; }
        public int selectedQuestionnairID { get; set; }

        private BindingList<SelectListItem> _QuestionnaireList = null;
        private BindingList<SelectListItem> _filteredQuestionnaireList = null;
        
        public pageQuestionnaire()
        {
            InitializeComponent();
        }
        private void pageQuestionnaire_Load(object sender, EventArgs e)
        {
            try
            {
                this.selectedCategoryID = this.selectedRelatedToID = 0;
                PopulateCategoriesList();
                PopulateRelatedToList();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::pageQuestionnaire_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region QUESTION CATEGORIES
        public void PopulateCategoriesList()
        {
            try
            {
                listCategories.DataSource = (new ServiceMASTERS()).GetAllSalesQuestionCategories();
                listCategories.DisplayMember = "Description";
                listCategories.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::PopulateCategoriesList", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void listCategories_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.selectedCategoryID = ((SelectListItem)listCategories.SelectedItem).ID;
                PopulateQuestionnaireGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::listCategories_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }
        private void AddQuestionCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.Text = "Add a New Questionnaire Category";
                frm.MASTERCategoryID = (new ServiceSalesQuestionnaire()).QUESTION_CATEGORY_MASTER_ID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCategoriesList();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::AddQuestionCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditQuestionCategory_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList(this.selectedCategoryID);
                frm.Text = "Edit Questionnaire Category";
                frm.MASTERCategoryID = (new ServiceSalesQuestionnaire()).QUESTION_CATEGORY_MASTER_ID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateCategoriesList();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::btnEditQuestionCategory_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region QUESTION RELATED TO
        public void PopulateRelatedToList()
        {
            try
            {
                listRelatedTo.DataSource = (new ServiceMASTERS()).GetAllSalesQuestionRelatedCategories();
                listRelatedTo.DisplayMember = "Description";
                listRelatedTo.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::PopulateRelatedToList", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }
        private void listRelatedTo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.selectedRelatedToID = ((SelectListItem)listRelatedTo.SelectedItem).ID;
                PopulateQuestionnaireGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::listRelatedTo_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddRelatedTo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList();
                frm.Text = "Add New Related To Category for Questionnaire";
                frm.MASTERCategoryID = (new ServiceSalesQuestionnaire()).QUESTION_RELATEDTO_MASTER_ID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateRelatedToList();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::btnAddRelatedTo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditRelatedTo_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterUserList frm = new frmMasterUserList(this.selectedRelatedToID);
                frm.Text = "Edit Related To Category for Questionnaire";
                frm.MASTERCategoryID = (new ServiceSalesQuestionnaire()).QUESTION_RELATEDTO_MASTER_ID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateRelatedToList();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::btnEditRelatedTo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteRelatedTo_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Related To", this.selectedRelatedToID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceSalesQuestionnaire()).DeleteRelatedToQuestionnaire(this.selectedRelatedToID, Program.CURR_USER.EmployeeID))
                        PopulateRelatedToList();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::btnDeleteRelatedTo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Questionnaire
        public void PopulateQuestionnaireGrid()
        {
            try
            {
                gridQuestionnaire.DataSource = (new ServiceSalesQuestionnaire()).GetAllQuestionnaire(selectedCategoryID, selectedRelatedToID);
                gridQuestionnaire.Columns["ID"].Visible =
                gridQuestionnaire.Columns["Code"].Visible =
                gridQuestionnaire.Columns["DescriptionToUpper"].Visible =
                gridQuestionnaire.Columns["IsActive"].Visible = false;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::PopulateQuestionnaireGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridQuestionnaire_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedQuestionnairID = int.Parse(gridQuestionnaire.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::gridQuestionnaire_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewQuestionnaire_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditQuestionnaire frm = new frmAddEditQuestionnaire();
                frm.selectedCategoryID = this.selectedCategoryID;
                frm.selectedRelatedToID = this.selectedRelatedToID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateQuestionnaireGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::btnAddNewQuestionnaire_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditQuestionnair_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditQuestionnaire frm = new frmAddEditQuestionnaire(selectedQuestionnairID);
                frm.selectedCategoryID = this.selectedCategoryID;
                frm.selectedRelatedToID = this.selectedRelatedToID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateQuestionnaireGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::btnEditQuestionnair_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteQuestionnaire_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = string.Format("Are you sure to Remove Sales Quotation ", this.selectedQuestionnairID);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if ((new ServiceSalesQuestionnaire()).DeleteQuestionnaire(this.selectedQuestionnairID, Program.CURR_USER.EmployeeID))
                        PopulateQuestionnaireGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "pageQuestionnaire::btnDeleteQuestionnaire_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchQuestion_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredQuestionnaireList = new BindingList<SelectListItem>(_QuestionnaireList.Where(p => p.Description.Contains(txtSearchQuestion.Text.ToUpper())).ToList());
                gridQuestionnaire.DataSource = _filteredQuestionnaireList;
                headerGroupQuestionCategory.ValuesSecondary.Heading = string.Format("{0} record(s) found.", gridQuestionnaire.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "pageQuestionnaire::txtSearchQuestion_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion








    }
}
