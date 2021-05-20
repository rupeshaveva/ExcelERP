using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES;
using ComponentFactory.Krypton.Toolkit;
using libERP.SERVICES.CRM;

namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    public partial class frmAddBOQChildItem : Form
    {
        public DataTable DATATABLE_SOURCE { get; set; }

        public frmAddBOQChildItem()
        {
            InitializeComponent();
        }

        private void frmAddBOQChildItem_Load(object sender, EventArgs e)
        {
            try
            {
                gridBOQItems.DataSource = this.DATATABLE_SOURCE;


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddBOQChildItem::frmAddBOQChildItem_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridBOQItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                ServiceSalesEnquiryBOQ serviceEnquiryBOQ = new ServiceSalesEnquiryBOQ();
                gridBOQItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_DEFAULT_QTY].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_SERIAL_NO_SYS].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_PARENT_ITEM_ID].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_HAS_SERVICES].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_IS_ASSEMBLY].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_ID].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_CODE].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_UOM_ID].Visible =
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_UOM_NAME].Visible =
                false;
                Font F = this.Font;
                //gridBOQItems.Columns["ItemDescription"].DefaultCellStyle.Font = new Font(this.Font.FontFamily.Name, this.Font.Size, FontStyle.Regular);
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_DESCRIPTION].ReadOnly = gridBOQItems.Columns[serviceEnquiryBOQ.COL_UOM_NAME].ReadOnly = true;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_TOTAL_QTY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_TOTAL_QTY].DefaultCellStyle.Font = new Font(this.Font.FontFamily.Name, this.Font.Size, FontStyle.Bold);


                int descriptionWidth = (int)(this.Width * .4);
                gridBOQItems.Columns["Selected"].MinimumWidth = 50;
                gridBOQItems.Columns["Selected"].Width = 50;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_TOTAL_QTY].MinimumWidth = 80;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_TOTAL_QTY].Width = 80;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_DESCRIPTION].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_DESCRIPTION].MinimumWidth = descriptionWidth;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_DESCRIPTION].Width = descriptionWidth;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_DESCRIPTION].MinimumWidth = descriptionWidth;
                gridBOQItems.Columns[serviceEnquiryBOQ.COL_ITEM_DESCRIPTION].Width = descriptionWidth;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddBOQChildItem::gridBOQItems_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            //gridBOQItems.Refresh();
            //gridBOQItems.Columns["TotalQty"].MinimumWidth = 100;

            
        }
        private void gridBOQItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gridBOQItems.Rows[e.RowIndex].Cells["Selected"].Value = !(bool)(gridBOQItems.Rows[e.RowIndex].Cells["Selected"].Value);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddBOQChildItem::gridBOQItems_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string strFiler = string.Format("ItemDescription LIKE '%{0}%'", txtSearchItem.Text);
                (gridBOQItems.DataSource as DataTable).DefaultView.RowFilter = strFiler;
                gridBOQItems.Refresh();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmAddBOQChildItem::txtSearchItem_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void btnSelectItems_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
