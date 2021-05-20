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
using ComponentFactory.Krypton.Toolkit;
using appExcelERP.Forms;
using libERP.MODELS.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CRM
{
    public partial class ControlSalesQuotationTermsAndCondition : UserControl
    {
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                {
                    btnUpdateNotes.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    btnAddTerms.Enabled= btnRemoveTerms.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                    txtSpecialNotes.Enabled = false;
                }
                else
                {
                    btnUpdateNotes.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    btnAddTerms.Enabled = btnRemoveTerms.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                    txtSpecialNotes.Enabled = true;
                }
            }
        }

        public int SelectedQuotationID { get; set; }
        BindingList<SelectListItem> _TermAndConditionList = null;
        BindingList<SelectListItem> _filteredTermAndConditionList = null;

        private String TERM_DESCRIPTION=String.Empty;

        public ControlSalesQuotationTermsAndCondition()
        {
            InitializeComponent();
        }
        private void ControlSalesQuotationTermsAndCondition_Load(object sender, EventArgs e)
        {
            splitContainerMain.SplitterDistance=(int) (this.Height*.25);
        }
        
        public void PopulateControl()
        {
            try
            {
                PopulateSpecialNotes();
                PopulateTermsAndConditions();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::PopulateControl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region SPECIAL NOTES
        private void PopulateSpecialNotes()
        {
            try
            {
                TBL_MP_CRM_SalesQuotation dbModel = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(this.SelectedQuotationID);
                if (dbModel != null)
                {
                    txtSpecialNotes.Text = dbModel.SpecialNotes;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::PopulateSpecialNotes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdateNotes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                (new ServiceSalesQuotation()).UpdateSpecialNotesForQuotation(this.SelectedQuotationID, txtSpecialNotes.Text);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::btnUpdateNotes_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            
            
        }
        #endregion

        #region TERMS AND CONDITIONS
        private void PopulateTermsAndConditions()
        {
            try
            {
                _TermAndConditionList = AppCommon.ConvertToBindingList<SelectListItem>((new ServiceSalesQuotation()).GetAllTermsAndConditionForQuotation(this.SelectedQuotationID));
                gridTermAndCondition.DataSource = _TermAndConditionList;
                gridTermAndCondition.Columns["ID"].Visible = gridTermAndCondition.Columns["DescriptionToUpper"].Visible = false;
                gridTermAndCondition.Columns["IsActive"].Width = (int)(gridTermAndCondition.Width * .08);
                gridTermAndCondition.Columns["Description"].Width=(int)(gridTermAndCondition.Width*.7);
                gridTermAndCondition.Columns["Code"].Width = (int)(gridTermAndCondition.Width * .2);
                gridTermAndCondition.Columns["Code"].ReadOnly = true;

                headerGroupTermsAndCondition.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridTermAndCondition.Rows.Count);
                btnRemoveTerms.Enabled = (gridTermAndCondition.Rows.Count == 0)? ButtonEnabled.False:ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::PopulateTermsAndConditions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridTermAndCondition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!ReadOnly)
                gridTermAndCondition.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridTermAndCondition.Rows[e.RowIndex].Cells["IsActive"].Value);
        }
        private void btnAddTerms_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.SALES_QUOTATION_TERMS_AND_CONDITIONS);
                frm.Text = "TERMS AND CODITIONS FOR SALES QUOTATION (Multiselect)";
                frm.SingleSelect = false;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    BindingList<MultiSelectListItem> selectedtTermsAndConditions = frm.SelectedItems;
                    if (selectedtTermsAndConditions == null) return;
                    ServiceSalesQuotation _service = new ServiceSalesQuotation();
                    foreach (MultiSelectListItem item in selectedtTermsAndConditions.AsEnumerable())
                    {
                        TBL_MP_CRM_SalesQuotation_TermsAndConditions model = new TBL_MP_CRM_SalesQuotation_TermsAndConditions();
                        {
                            model.FK_Quotation_ID = this.SelectedQuotationID;
                            model.Term_Title = item.Code;
                            model.Term_Description = item.Description.Replace(item.Code, "").Replace("\n", "");
                            model.PK_Quotation_TermID = 0;
                            model.Sequence = 0;
                            _service.AddNewQuotationTermAndCondition(model);
                        }
                    }
                    PopulateTermsAndConditions();
                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::btnAddTerms_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnRemoveTerms_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string IDs = string.Empty;
            try
            {
                string strMessage = string.Format("Are you sure to remove selected Terms & Conditions");
                if (MessageBox.Show(strMessage, "CAUTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RemoveSelectedTermsAndConditions();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::btnRemoveTerms_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private bool RemoveSelectedTermsAndConditions()
        {
            bool result = false;
            this.Cursor = Cursors.WaitCursor;
            string IDs = string.Empty;
            try
            {
                foreach (DataGridViewRow row in gridTermAndCondition.Rows)
                {
                    if ((bool)row.Cells["IsActive"].Value)
                    {
                        IDs += string.Format("{0}{1}", row.Cells["ID"].Value.ToString(), Program.DefaultStringSeperator);
                    }
                }
                if (IDs.Length > 0)
                {
                    IDs = IDs.Trim().TrimEnd(Program.DefaultStringSeperator);
                    (new ServiceSalesQuotation()).RemoveQuotationTermAndCondition(IDs, this.SelectedQuotationID);
                    PopulateTermsAndConditions();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::RemoveSelectedTermsAndConditions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
            return result;
        }
        private void txtSearchTermAndCondition_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _filteredTermAndConditionList = new BindingList<SelectListItem>(_TermAndConditionList.Where(p => p.DescriptionToUpper.Contains(txtSearchTermAndCondition.Text.ToUpper())).ToList());
                gridTermAndCondition.DataSource = _filteredTermAndConditionList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::txtSearchTermAndCondition_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridTermAndCondition_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TERM_DESCRIPTION = string.Empty;
            if (gridTermAndCondition.Columns[e.ColumnIndex].Name == "Description") TERM_DESCRIPTION = gridTermAndCondition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        private void gridTermAndCondition_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void gridTermAndCondition_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (e.ColumnIndex != gridTermAndCondition.Columns["Description"].Index) return;

                if (gridTermAndCondition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != TERM_DESCRIPTION)
                {
                    int termQuotationID = int.Parse(gridTermAndCondition.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    (new ServiceSalesQuotation()).UpdateQuotationTermAndConditionDescription(termQuotationID, gridTermAndCondition.Rows[e.RowIndex].Cells["Description"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationTermsAndCondition::gridTermAndCondition_CellLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }


        #endregion

        private void headerGroupTermsAndCondition_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
