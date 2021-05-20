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
using ComponentFactory.Krypton.Toolkit;
using libERP;
using Newtonsoft.Json;
using ComponentFactory.Krypton.Navigator;
using appExcelERP.Controls.CRM.SalesQuotationBOQ;
using libERP.SERVICES.COMMON;
using libERP.MODELS.CRM;
using libERP.MODELS.COMMON;
using libERP.SERVICES.CRM;

namespace appExcelERP.Controls.CRM
{

    public partial class ControlSalesQuotationBOQ : UserControl
    {
        // Declare an event 
        public event SalesQuotationBOQSummaryChangedEventHandler OnBOQChanged;
        KryptonPage pageBOQsummary = null;

        public SalesQuotationBOQViewModel MODEL { get; set; }

        public int SalesQuotationID { get; set; }
        public APP_ENTITIES ENTITY { get; set; }


        //public ControlSalesQuotationBOQConfiguration _configureBOQControl = null;
        public ControlSalesQuotationBOQSummary _BOQSummaryControl = null;
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                    btnSaveBOQ.Enabled = btnDuplicateDesignBOQ.Enabled= ButtonEnabled.False;
                else
                    btnSaveBOQ.Enabled = btnDuplicateDesignBOQ.Enabled = ButtonEnabled.True;
            }
        }

        public ControlSalesQuotationBOQ()
        {
            InitializeComponent();
            ENTITY = APP_ENTITIES.SALES_QUOTATION;
            MODEL = new SalesQuotationBOQViewModel();
            MODEL.QUOTATION_ID = this.SalesQuotationID;
            tabBOQSheets.Pages.Clear();
        }

        public void PopulateSalesQuotationBOQ()
        {
            MODEL = null;
            tabBOQSheets.Pages.Clear();
            Application.DoEvents();
            try
            {
                // check if to be set readonly
                TBL_MP_CRM_SalesQuotation dbQuotation = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(SalesQuotationID);
                this.ReadOnly = (dbQuotation.FK_BOQRepresentativeID != Program.CURR_USER.EmployeeID);

                headerBOQMenu.Values.Heading = String.Empty;
                MODEL = (new ServiceSalesQuotationBOQ()).GetBOQViewModelForQuotation(this.SalesQuotationID);
                if(MODEL==null)
                    MODEL= (new ServiceSalesQuotationBOQ()).GenerateDefaultBOQForSalesQuotation(this.SalesQuotationID);

                if (MODEL != null) 
                {
                    
                    headerBOQMenu.Values.Heading = MODEL.BOQ_NUMBER;
                    // CREATE ALL SHEETS 
                    foreach (SalesQuotationBOQSheet sheet in MODEL.SHEETS)
                    {
                        KryptonPage pageBOQSheet = new KryptonPage() { Text = sheet.SheetName, Name = string.Format("page{0}", tabBOQSheets.Pages.Count + 1) };
                        ControlSalesQuotationBOQSheet _sheetControl = new ControlSalesQuotationBOQSheet(sheet);
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
                    _BOQSummaryControl = new ControlSalesQuotationBOQSummary(MODEL);
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
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQ::PopulateSalesQuotationBOQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQ::_sheetControl_OnValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    (new ServiceSalesQuotationBOQ()).UpdateSalesQuotationBOQFromSalesEnquiryBOQ(this.MODEL);
                }
                    
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQ::btnDuplicateDesignBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSaveBOQ_Click(object sender, EventArgs e)
        {
            try
            {
                int IDX = tabBOQSheets.SelectedIndex;
                MODEL = (new ServiceSalesQuotationBOQ()).SaveBOQToDatabase(MODEL,Program.CURR_USER.EmployeeID);
                PopulateSalesQuotationBOQ();
                Application.DoEvents();
                tabBOQSheets.SelectedPage = tabBOQSheets.Pages[IDX];
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQ::btnSaveBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    (new ServiceExcelApp()).ExportSalesQuotationBOQToEXCEL(this.SalesQuotationID, MODEL, frm.SETTING, strFileName);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQ::btnExportBOQToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQ::tabBOQSheets_Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void tabBOQSheets_Selecting(object sender, KryptonPageCancelEventArgs e)
        {

        }

    }

}
