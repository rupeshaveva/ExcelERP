using libERP;
using libERP.MODELS;
using libERP.SERVICES.CRM;
using libERP.SERVICES.MASTER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Forms.CRM
{
    public partial class frmAddEditQuestionnaire : Form
    {
        public int QuestionnaireID { get; set; }
        public int selectedCategoryID { get; set; }
        public int selectedRelatedToID { get; set; }


        public frmAddEditQuestionnaire()
        {
            InitializeComponent();
        }
        public frmAddEditQuestionnaire(int questionID)
        {
            InitializeComponent();
            this.QuestionnaireID = questionID;
        }

        private void frmAddEditQuestionnaire_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateCategoriesDropdown();
                PopulateRelatedToDropdown();
                if (selectedCategoryID != 0)
                    cboCategory.SelectedItem = ((List<SelectListItem>)cboCategory.DataSource).Where(x => x.ID == selectedCategoryID).FirstOrDefault();
                if (selectedRelatedToID != 0)
                    cboRelatedTo.SelectedItem = ((List<SelectListItem>)cboRelatedTo.DataSource).Where(x => x.ID == selectedRelatedToID).FirstOrDefault();

                if (QuestionnaireID == 0)
                {
                    txtQuestionText.Text = txtImplecationText.Text = txtSolutionText.Text = string.Empty;
                }
                else
                {
                    ScatterData();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::frmAddEditQuestionnaire_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ScatterData()
        {
            try
            {
                TBL_MP_CRM_SalesQuestionnaire model = (new ServiceSalesQuestionnaire()).GetQuestionnaireDBRecord(this.QuestionnaireID);
                if (model != null)
                {
                    cboCategory.SelectedItem = ((List<SelectListItem>)cboCategory.DataSource).Where(x => x.ID == selectedCategoryID).FirstOrDefault();
                    cboRelatedTo.SelectedItem = ((List<SelectListItem>)cboRelatedTo.DataSource).Where(x => x.ID == selectedRelatedToID).FirstOrDefault();
                    txtQuestionText.Text = model.Question;
                    txtImplecationText.Text = model.Implication;
                    txtSolutionText.Text = model.Solution;
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::ScatterData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateCategoriesDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() {ID=0, Description="(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllSalesQuestionCategories());
                cboCategory.DataSource = lst;
                cboCategory.DisplayMember = "Description";
                cboCategory.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::PopulateCategoriesDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PopulateRelatedToDropdown()
        {
            try
            {
                List<SelectListItem> lst = new List<SelectListItem>();
                lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
                lst.AddRange((new ServiceMASTERS()).GetAllSalesQuestionRelatedCategories());
                cboRelatedTo.DataSource = lst;
                cboRelatedTo.DisplayMember = "Description";
                cboRelatedTo.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::PopulateRelatedToDropdown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region VALIDATION
        private void cboCategory_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (((SelectListItem)cboCategory.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboCategory, "Invalid Category");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::cboCategory_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboRelatedTo_Validating(object sender, CancelEventArgs e)
        {

            try
            {
                if (((SelectListItem)cboRelatedTo.SelectedItem).ID == 0)
                {
                    errorProvider1.SetError(cboRelatedTo, "Invalid  Related To ");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::cboRelatedTo_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuestionText_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtQuestionText.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtQuestionText, "Enter Question Text");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::txtQuestionText_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSolutionText_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtSolutionText.Text.Trim() == string.Empty)
                {
                    errorProvider1.SetError(txtSolutionText, "Enter solution Text");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddEditQuestionnaire::txtSolutionText_Validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            TBL_MP_CRM_SalesQuestionnaire model = null;
            ServiceSalesQuestionnaire service = new ServiceSalesQuestionnaire();
            try
            {
                errorProvider1.Clear();
                if (!this.ValidateChildren()) return;
                if (this.QuestionnaireID == 0)
                    model = new TBL_MP_CRM_SalesQuestionnaire();
                else
                    model = service.GetQuestionnaireDBRecord(this.QuestionnaireID);
                model.FK_CategoryID= ((SelectListItem)cboCategory.SelectedItem).ID;
                model.FK_RelatedToID= ((SelectListItem)cboRelatedTo.SelectedItem).ID;
                model.Question = txtQuestionText.Text;
                model.Implication = txtImplecationText.Text;
                model.Solution = txtSolutionText.Text;
                if (this.QuestionnaireID== 0)
                    this.QuestionnaireID = service.AddNewQuestionnaire(model);
                else
                    service.UpdateQuestionnaire(model);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmSO_Primary::btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }
    }
}
