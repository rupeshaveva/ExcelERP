using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Services;
using appExcelERP.Models;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlTermsAndCondition : UserControl
    {
        public int SelectedID { get; set; }
        public APP_ENTITIES ENTITY { get; set; }

        BindingList<TermsAndConditionModel> _TermsAndConditionList = null;
        
        public ctrlTermsAndCondition()
        {
            InitializeComponent();
        }
        public ctrlTermsAndCondition(APP_ENTITIES currEntity)
        {
            InitializeComponent();
            this.ENTITY = currEntity;
        }

        public void PopulateAllTermsAndConditions()
        {
            try
            {
                switch (this.ENTITY)
                {
                    case APP_ENTITIES.SALES_QUOTATION:
                        //_TermsAndConditionList = AppCommon.ConvertToBindingList<TermsAndConditionModel>((new ServiceSalesQuotation()).GetAllTermsAndCondition(this.SelectedID));
                        break;
                    case APP_ENTITIES.SALES_ORDER:
                        //_TermsAndConditionList = AppCommon.ConvertToBindingList<TermsAndConditionModel>((new ServiceSalesOrders()).GetAllTermsAndCondition(this.SelectedID));
                        break;
                    case APP_ENTITIES.SALES_ENQUIRY:
                        _TermsAndConditionList = AppCommon.ConvertToBindingList<TermsAndConditionModel>((new ServiceSalesEnquiry()).GetAllTermsAndCondition(this.SelectedID));
                        break;
                }

                gridTerms.DataSource = _TermsAndConditionList;
                gridTerms.Columns["TermID"].Visible = gridTerms.Columns["TermTitle"].Visible = false;
                gridTerms.Columns["TermDescription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.gridTerms.CellBorderStyle = DataGridViewCellBorderStyle.None;
                headerGroupTermsAndCondition.ValuesSecondary.Description = string.Format("{0} record(s) found.", _TermsAndConditionList.Count());
                if (_TermsAndConditionList.Count > 0)
                {
                    headerGroupTermsAndCondition.ValuesPrimary.Heading = _TermsAndConditionList[0].TermTitle;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ctrlTermsAndCondition::PopulateAllTermsAndConditions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }

        private void btnAddNewTermAndCondition_Click(object sender, EventArgs e)
        {

        }
    }
}
