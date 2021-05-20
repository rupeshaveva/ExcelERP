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
using libERP.SERVICES.COMMON;
using libERP.SERVICES.CRM;
using libERP.MODELS.CRM;
using ComponentFactory.Krypton.Toolkit;
using appExcelERP.Forms;
using libERP.MODELS.COMMON;
using libERP;

namespace appExcelERP.Controls.CRM.SalesOrder
{
    public partial class ControlSalesOrderTermsAndCondition : UserControl
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
                   
                    btnAddTerms.Enabled = btnRemoveTerms.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                  
                }
                else
                {
                   
                    btnAddTerms.Enabled = btnRemoveTerms.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                 
                }
            }
        }

        public int SelectedOrderID { get; set; }
        BindingList<TermsAndConditionModel> _TermAndConditionList = null;
        BindingList<TermsAndConditionModel> _filteredTermAndConditionList = null;


        private String TERM_DESCRIPTION = String.Empty;

        public ControlSalesOrderTermsAndCondition()
        {
            InitializeComponent();
        }
        private void ControlSalesOrderTermsAndCondition_Load(object sender, EventArgs e)
        {
           
        }

        #region TERMS AND CONDITIONS
        public void PopulateTermsAndConditions()
        {
            try
            {
                _TermAndConditionList = AppCommon.ConvertToBindingList<TermsAndConditionModel>((new ServiceSalesOrder()).GetAllTermsAndConditionForOrder(this.SelectedOrderID));
                gridTermAndCondition.DataSource = _TermAndConditionList;
                gridTermAndCondition.Columns["TermID"].Visible = gridTermAndCondition.Columns["TitleID"].Visible = gridTermAndCondition.Columns["Sequence"].Visible= false;
                gridTermAndCondition.Columns["IsActive"].Width = (int)(gridTermAndCondition.Width * .03);
                gridTermAndCondition.Columns["SearchText"].Visible = false;
                gridTermAndCondition.Columns["TermDescription"].Width = (int)(gridTermAndCondition.Width * .5);
                gridTermAndCondition.Columns["TermTitle"].Width = (int)(gridTermAndCondition.Width * .2);
                headerGroupTermsAndCondition.ValuesSecondary.Heading = string.Format("{0} record(s) found", gridTermAndCondition.Rows.Count);
                btnRemoveTerms.Enabled = (gridTermAndCondition.Rows.Count == 0) ? ButtonEnabled.False : ButtonEnabled.True;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderTermsAndCondition::PopulateTermsAndConditions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridTermAndCondition_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TERM_DESCRIPTION = string.Empty;
                if (gridTermAndCondition.Columns[e.ColumnIndex].Name == "TermDescription") TERM_DESCRIPTION = gridTermAndCondition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderTermsAndCondition::gridTermAndCondition_CellEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridTermAndCondition_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (e.ColumnIndex != gridTermAndCondition.Columns["TermDescription"].Index) return;

                if (gridTermAndCondition.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != TERM_DESCRIPTION)
                {
                    int termOrderID = int.Parse(gridTermAndCondition.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                    (new ServiceSalesOrder()).UpdateOrderTermAndConditionDescription(termOrderID, gridTermAndCondition.Rows[e.RowIndex].Cells["TermDescription"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderTermsAndCondition::gridTermAndCondition_CellLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }
        private void gridTermAndCondition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!ReadOnly)
                    gridTermAndCondition.Rows[e.RowIndex].Cells["IsActive"].Value = !(bool)(gridTermAndCondition.Rows[e.RowIndex].Cells["IsActive"].Value);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderTermsAndCondition::gridTermAndCondition_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnAddTerms_Click(object sender, EventArgs e)
        {
            try
            {
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.SALES_ORDER_TERMS_AND_CONDITIONS);
                frm.Text = "TERMS AND CODITIONS FOR SALES ORDER (Multiselect)";
                frm.SingleSelect = false;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    BindingList<MultiSelectListItem> selectedtTermsAndConditions = frm.SelectedItems;
                    if (selectedtTermsAndConditions == null) return;
                    ServiceSalesOrder _service = new ServiceSalesOrder();
                    foreach (MultiSelectListItem item in selectedtTermsAndConditions.AsEnumerable())
                    {
                        TBL_MP_CRM_SalesOrder_TermsAndConditions model = new TBL_MP_CRM_SalesOrder_TermsAndConditions();
                        {
                            model.FK_SalesOrderID = this.SelectedOrderID;
                            model.TermTitle = item.Code;
                            model.Term_Description = item.Description.Replace(item.Code, "").Replace("\n", "");
                            model.PK_Order_TermID = 0;
                            model.Sequence = 0;
                            _service.AddNewOrderTermAndCondition(model);
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
                MessageBox.Show(errMessage, "ControlSalesOrderTermsAndCondition::btnAddTerms_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "ControlSalesOrderTermsAndCondition::btnRemoveTerms_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        IDs += string.Format("{0}{1}", row.Cells["TermID"].Value.ToString(), Program.DefaultStringSeperator);
                    }
                }
                if (IDs.Length > 0)
                {
                    IDs = IDs.Trim().TrimEnd(Program.DefaultStringSeperator);
                    (new ServiceSalesOrder()).RemoveOrderTermAndCondition(IDs, this.SelectedOrderID);
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
                _filteredTermAndConditionList = new BindingList<TermsAndConditionModel>(_TermAndConditionList.Where(p => p.SearchText.Contains(txtSearchTermAndCondition.Text.ToUpper())).ToList());
                gridTermAndCondition.DataSource = _filteredTermAndConditionList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderTermsAndCondition::txtSearchTermAndCondition_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        #endregion




    }
}
