using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.SERVICES.COMMON;
using ComponentFactory.Krypton.Navigator;
using libERP.MODELS.CRM;
using libERP.SERVICES.CRM;
using libERP;
using appExcelERP.Controls.CRM.SalesQuotationBOQ;
using ComponentFactory.Krypton.Toolkit;

namespace appExcelERP.Controls.CRM.SalesOrder.SalesOrderBOQ
{
    public partial class ControlSalesOrderBOQ : UserControl
    {
        // Declare an event 
        public event SalesOrderBOQSummaryChangedEventHandler OnBOQChanged;
        KryptonPage pageBOQsummary = null;

        public SalesOrderBOQViewModel MODEL { get; set; }
        public int SalesOrderID { get; set; }
       //public ControlSalesQuotationBOQConfiguration _configureBOQControl = null;
        public ControlSalesOrderBOQSummary _BOQSummaryControl = null;
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                    btnSaveBOQ.Enabled = btnDuplicateDesignBOQ.Enabled = ButtonEnabled.False;
                else
                    btnSaveBOQ.Enabled = btnDuplicateDesignBOQ.Enabled = ButtonEnabled.True;
            }
        }

        public ControlSalesOrderBOQ()
        {
            InitializeComponent();
            MODEL = new SalesOrderBOQViewModel();
            MODEL.ORDER_ID = this.SalesOrderID;
            tabBOQSheets.Pages.Clear();
        }

        public void PopulateSalesOrderBOQ()
        {
            MODEL = null;
            tabBOQSheets.Pages.Clear();
            Application.DoEvents();
            try
            {
                // check if to be set readonly
                TBL_MP_CRM_SalesOrder dbOrder = (new ServiceSalesOrder()).GetSalesOrderDBInfoByID(SalesOrderID);
                this.ReadOnly = (dbOrder.FK_BOQRepresentativeID != Program.CURR_USER.EmployeeID);

                headerBOQMenu.Values.Heading = String.Empty;
                MODEL = (new ServiceSalesOrderBOQ()).GetBOQViewModelForOrder(this.SalesOrderID);
                if (MODEL == null)
                    MODEL = (new ServiceSalesOrderBOQ()).GenerateDefaultBOQForSalesOrder(this.SalesOrderID);

                if (MODEL != null)
                {

                    headerBOQMenu.Values.Heading = MODEL.BOQ_NUMBER;
                    // CREATE ALL SHEETS 
                    foreach (SalesOrderBOQSheet sheet in MODEL.SHEETS)
                    {
                        KryptonPage pageBOQSheet = new KryptonPage() { Text = sheet.SheetName, Name = string.Format("page{0}", tabBOQSheets.Pages.Count + 1) };
                        ControlSalesOrderBOQSheet _sheetControl = new ControlSalesOrderBOQSheet(sheet);
                        _sheetControl.OnValueChanged += _sheetControl_OnValueChanged;
                        _sheetControl.BOQ_MODEL = MODEL;
                        pageBOQSheet.Controls.Add(_sheetControl);
                        _sheetControl.Dock = DockStyle.Fill;
                        tabBOQSheets.Pages.Add(pageBOQSheet);
                        _sheetControl.ParentTabPage = pageBOQSheet;
                        _sheetControl.PopulateBOQItemsGrid();
                        _sheetControl.Visible = true;
                        _sheetControl.ReadOnly = this._ReadOnly;
                        //pageBOQSheet.Show();
                        _sheetControl.SetBOQItemsGridColumnSettings();
                        _sheetControl.SetBOQItemsGridColumnFormatting();
                        pageBOQSheet.Refresh();
                        tabBOQSheets.SelectedPage = pageBOQSheet;
                        Application.DoEvents();

                    }

                    // ADD BOQ SUMMARY TAB
                    pageBOQsummary = new KryptonPage() { Text = "SUMMARY", Name = "tabPageBOQSummary" };
                    _BOQSummaryControl = new ControlSalesOrderBOQSummary(MODEL);
                    _BOQSummaryControl.Dock = DockStyle.Fill;
                    pageBOQsummary.Controls.Add(_BOQSummaryControl);
                    tabBOQSheets.Pages.Add(pageBOQsummary);
                    _BOQSummaryControl.PopulateBOQSummaryControl();
                    _BOQSummaryControl.ReadOnly = this._ReadOnly;

                }

                // perform grid formatting and column settings again
                foreach (KryptonPage page in tabBOQSheets.Pages)
                {
                    if (page.Controls[0].GetType() == typeof(ControlSalesQuotationBOQSheet))
                    {
                        ControlSalesQuotationBOQSheet sheet = (ControlSalesQuotationBOQSheet)page.Controls[0];
                        sheet.SetBOQItemsGridColumnSettings();
                        sheet.SetBOQItemsGridColumnFormatting();
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderBOQ::PopulateSalesQuotationBOQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void _sheetControl_OnValueChanged(object sender)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _BOQSummaryControl.BOQ_MODEL = MODEL;
                _BOQSummaryControl.PopulateBOQSummaryControl();
                if (OnBOQChanged != null)
                {
                    OnBOQChanged(this, MODEL.SUMMARY);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderBOQ::_sheetControl_OnValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnDuplicateDesignBOQ_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = "This operation will remove all the Items & Charges applied on them.\nThis will reporoduce the same BOQ received from the Design Team";
                if (MessageBox.Show(strMessage, "Sure to proceed", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    (new ServiceSalesOrderBOQ()).UpdateSalesOrderBOQFromSalesQuotationBOQ(this.MODEL);
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderBOQ::btnDuplicateDesignBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSaveBOQ_Click(object sender, EventArgs e)
        {
            try
            {
                int IDX = tabBOQSheets.SelectedIndex;
                MODEL = (new ServiceSalesOrderBOQ()).SaveBOQToDatabase(MODEL, Program.CURR_USER.EmployeeID);
                PopulateSalesOrderBOQ();
                Application.DoEvents();
                tabBOQSheets.SelectedPage = tabBOQSheets.Pages[IDX];
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderBOQ::btnSaveBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExportBOQToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SalesQuotationBOQExportConfigurationModel model = new SalesQuotationBOQExportConfigurationModel();
                model.ExportParentItemsOnly = true;
                model.ExportParentAndChildItems = false;
                model.IncludeMaterialSupplyCharges = true;
                model.IncludeInstallationCharges = true;

                frmBOQExportToExcel frm = new frmBOQExportToExcel();
                frm.SETTING = model;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    string strFileName = MODEL.BOQ_NUMBER.Replace("/", "").Replace("#", "").Replace("-", "");
                    strFileName = string.Format("{0}{1}.xls", AppCommon.GetDefaultStorageFolderPath(), strFileName);
                    (new ServiceExcelApp()).ExportSalesOrderBOQToEXCEL(this.SalesOrderID, MODEL, frm.SETTING, strFileName);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderBOQ::btnExportBOQToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void tabBOQSheets_Selected(object sender, KryptonPageEventArgs e)
        {
            try
            {
                if (e.Item.Controls[0].GetType() == typeof(ControlSalesQuotationBOQSheet))
                {
                    ControlSalesQuotationBOQSheet sheet = (ControlSalesQuotationBOQSheet)e.Item.Controls[0];
                    sheet.SetBOQItemsGridColumnSettings();
                    sheet.SetBOQItemsGridColumnFormatting();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesOrderBOQ::tabBOQSheets_Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void tabBOQSheets_Selecting(object sender, KryptonPageCancelEventArgs e)
        {

        }
    }
}
