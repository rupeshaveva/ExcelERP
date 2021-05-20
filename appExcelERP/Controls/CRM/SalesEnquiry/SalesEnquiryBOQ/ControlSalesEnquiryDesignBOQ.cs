using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using libERP.SERVICES;
using libERP;
using appExcelERP.Forms;
using libERP.MODELS;
using appExcelERP.Controls;
using Newtonsoft.Json;
using libERP.MODELS.CRM;
using libERP.MODELS.COMMON;
using libERP.SERVICES.CRM;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CRM
{
    public partial class ControlSalesEnquiryDesignBOQ : UserControl
    {
        public SalesEnquiryDesignBOQViewModel MODEL { get; set; }
        
        public int SalesEnquiryID { get; set; }
        public APP_ENTITIES ENTITY { get; set; }

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (_ReadOnly)
                    btnAddNewBOQSheet.Enabled = btnDuplicateBOQ.Enabled = btnRemoveBOQSheet.Enabled = btnSaveBOQ.Enabled = ButtonEnabled.False;
                else
                    btnAddNewBOQSheet.Enabled = btnDuplicateBOQ.Enabled = btnRemoveBOQSheet.Enabled = btnSaveBOQ.Enabled = ButtonEnabled.True;
            }
        }

        public ControlSalesEnquiryDesignBOQ()
        {
            InitializeComponent();
            ENTITY = APP_ENTITIES.SALES_ENQUIRY;
            MODEL = new SalesEnquiryDesignBOQViewModel();
            MODEL.ENQUIRY_ID = this.SalesEnquiryID;
            tabBOQSheets.Pages.Clear();
        }
        private void ControlSalesEnquiryDesignBOQ_Load(object sender, EventArgs e)
        {
            tabBOQSheets.Pages.Clear();

        }
        public void PopulateDesingBOQ()
        {
            MODEL = null;
            tabBOQSheets.Pages.Clear();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                headerBOQMenu.Values.Heading = String.Empty;
                TBL_MP_CRM_SalesEnquiry_BOQ dbModel = (new ServiceSalesEnquiryBOQ()).GetDesignBOQdbInfo(this.SalesEnquiryID);
                if (dbModel != null)
                {
                    MODEL = JsonConvert.DeserializeObject<SalesEnquiryDesignBOQViewModel>(dbModel.BOQ_DESIGN_OBJECT);
                    if (MODEL != null) // DRAW ALL SHEETS 
                    {
                        MODEL.BOQ_ID = dbModel.DESIGN_BOQ_ID;
                        MODEL.BOQ_NUMBER = dbModel.BOQ_NUMBER;
                        MODEL.ENQUIRY_ID = dbModel.ENQUIRY_ID;
                        headerBOQMenu.Values.Heading = MODEL.BOQ_NUMBER;
                        foreach (SalesEnquiryDesignBOQSheet sheet in MODEL.SHEETS)
                        {
                            KryptonPage pageBOQSheet = new KryptonPage() { Text = sheet.SheetName, Name = string.Format("page{0}", tabBOQSheets.Pages.Count + 1) };
                            ControlSalesEnquiryDesignBOQSheet _sheetControl = new ControlSalesEnquiryDesignBOQSheet(sheet);
                            pageBOQSheet.Controls.Add(_sheetControl);
                            _sheetControl.Dock = DockStyle.Fill;
                            tabBOQSheets.Pages.Add(pageBOQSheet);
                            _sheetControl.ParentTabPage = pageBOQSheet;
                            _sheetControl.PopulateBOQItemsGrid();
                            tabBOQSheets.SelectedPage = pageBOQSheet;
                            _sheetControl.Visible = true;
                            _sheetControl.ReadOnly = this.ReadOnly;
                            //_sheetControl.SetBOQItemsGridColumnSizes();
                            _sheetControl.SetBOQItemsGridColumnSizes();
                        }
                    }
                }
                else
                {
                    CreateDefaultBOQSheet();
                }

                foreach (KryptonPage page in tabBOQSheets.Pages)
                {
                    ControlSalesEnquiryDesignBOQSheet sheet = (ControlSalesEnquiryDesignBOQSheet) page.Controls[0];
                    sheet.SetBOQItemsGridColumnSizes();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::PopulateDesingBOQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void PopulateDesingBOQFromPreviousEnquiry(int prevEnquiryID)
        {
            MODEL = null;
            tabBOQSheets.Pages.Clear();
            try
            {
                MODEL = (new ServiceSalesEnquiryBOQ()).GetDesignBOQModelForSalesEnquiry(prevEnquiryID);
                if (MODEL != null) // DRAW ALL SHEETS 
                {
                    MODEL.BOQ_ID = 0;
                    MODEL.BOQ_NUMBER = (new ServiceSalesEnquiryBOQ()).GenerateDesignBOQNumber(SalesEnquiryID);
                    MODEL.ENQUIRY_ID = SalesEnquiryID;
                   
                    foreach (SalesEnquiryDesignBOQSheet sheet in MODEL.SHEETS)
                    {
                        KryptonPage pageBOQSheet = new KryptonPage() { Text = sheet.SheetName, Name = string.Format("page{0}", tabBOQSheets.Pages.Count + 1) };
                        ControlSalesEnquiryDesignBOQSheet _sheetControl = new ControlSalesEnquiryDesignBOQSheet(sheet);
                        pageBOQSheet.Controls.Add(_sheetControl);
                        _sheetControl.Dock = DockStyle.Fill;
                        tabBOQSheets.Pages.Add(pageBOQSheet);
                        _sheetControl.ParentTabPage = pageBOQSheet;
                        _sheetControl.PopulateBOQItemsGrid();
                        tabBOQSheets.SelectedPage = pageBOQSheet;
                        _sheetControl.Visible = true;
                        //_sheetControl.SetBOQItemsGridColumnSizes();
                        _sheetControl.SetBOQItemsGridColumnSizes();
                    }
                }

                foreach (KryptonPage page in tabBOQSheets.Pages)
                {
                    ControlSalesEnquiryDesignBOQSheet sheet = (ControlSalesEnquiryDesignBOQSheet)page.Controls[0];
                    sheet.SetBOQItemsGridColumnSizes();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::PopulateDesingBOQFromPreviousEnquiry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        public void PopulateDesignBOQForSalesEnquiry()
        {


        }
        private void CreateDefaultBOQSheet()
        {
            try
            {
                MODEL = new SalesEnquiryDesignBOQViewModel();
                ServiceSalesEnquiryBOQ serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
                MODEL.ENQUIRY_ID = this.SalesEnquiryID;
                SalesEnquiryDesignBOQSheet newSheet = new SalesEnquiryDesignBOQSheet();
                newSheet.SheetName = "Default".ToUpper();
                newSheet.SheetDescription = string.Empty;
                newSheet.BOQ_SERVICES = new BindingList<EnquiryBOQService>();
                newSheet.BOQ_ITEMS = new BindingList<EnquiryBOQItem>();
                if (newSheet.datatableBOQ == null)
                    newSheet.datatableBOQ = serviceDesignBOQ.GenerateBOQDataTableDefault();
                newSheet.datatableBOQ = serviceDesignBOQ.GenerateDesignBOQDataTableWithServices(newSheet.datatableBOQ, newSheet.BOQ_SERVICES, newSheet.BOQ_ITEMS);
                MODEL.SHEETS.Add(newSheet);
                KryptonPage pageBOQSheet = new KryptonPage() { Text = newSheet.SheetName, Name = string.Format("page{0}", tabBOQSheets.Pages.Count + 1) };
                ControlSalesEnquiryDesignBOQSheet _sheetControl = new ControlSalesEnquiryDesignBOQSheet(newSheet);
                pageBOQSheet.Controls.Add(_sheetControl);
                _sheetControl.ParentTabPage = pageBOQSheet;
                _sheetControl.Dock = DockStyle.Fill;
                tabBOQSheets.Pages.Add(pageBOQSheet);
                _sheetControl.PopulateBOQItemsGrid();
                tabBOQSheets.SelectedPage = pageBOQSheet;
                _sheetControl.Visible = true;
                _sheetControl.SetBOQItemsGridColumnSizes();
                if(!_ReadOnly) btnAddNewBOQSheet.Enabled = btnSaveBOQ.Enabled = ButtonEnabled.True;
                _sheetControl.ReadOnly = this.ReadOnly;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);

            }
        }
        private void btnCreateNewBOQ_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceSalesEnquiryBOQ serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
                frmAddEditBOQDesign frm = new frmAddEditBOQDesign();
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnCreateNewBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        
        private void PrepareBOQSheetsInTab()
        {
            try
            {
                tabBOQSheets.Pages.Clear();
                foreach (SalesEnquiryDesignBOQSheet sheetModel in MODEL.SHEETS)
                {
                    KryptonPage pageBOQSheet = new KryptonPage() { Text = sheetModel.SheetName, Name = string.Format("page{0}", tabBOQSheets.Pages.Count + 1) };
                    ControlSalesEnquiryDesignBOQSheet _sheetControl = new ControlSalesEnquiryDesignBOQSheet(sheetModel);
                    pageBOQSheet.Controls.Add(_sheetControl);
                    _sheetControl.Dock = DockStyle.Fill;
                    tabBOQSheets.Pages.Add(pageBOQSheet);
                    tabBOQSheets.SelectedPage = pageBOQSheet;
                    _sheetControl.PopulateBOQItemsGrid();
                    _sheetControl.Visible = true;
                    _sheetControl.SetBOQItemsGridColumnSizes();
                    _sheetControl.SetBOQItemsGridColumnSizes();
                    _sheetControl.Refresh();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::PrepareBOQSheetsInTab", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnAddNewBOQSheet_sachin_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceSalesEnquiryBOQ serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
                frmAddEditBOQDesign frm = new frmAddEditBOQDesign();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    SalesEnquiryDesignBOQSheet newSheet = new SalesEnquiryDesignBOQSheet();
                    newSheet.SheetName = frm.txtSheetName.Text;
                    newSheet.BOQ_SERVICES = frm.BOQ_SERVICES;
                    newSheet.BOQ_ITEMS = frm.BOQ_ITEMS;
                    if (newSheet.datatableBOQ == null)
                        newSheet.datatableBOQ = serviceDesignBOQ.GenerateBOQDataTableDefault();

                    newSheet.datatableBOQ = serviceDesignBOQ.GenerateDesignBOQDataTableWithServices(newSheet.datatableBOQ, newSheet.BOQ_SERVICES, newSheet.BOQ_ITEMS);
                    MODEL.SHEETS.Add(newSheet);

                    KryptonPage pageBOQSheet = new KryptonPage() { Text = newSheet.SheetName, Name = string.Format("page{0}", tabBOQSheets.Pages.Count + 1) };
                    ControlSalesEnquiryDesignBOQSheet _sheetControl = new ControlSalesEnquiryDesignBOQSheet(newSheet);
                    pageBOQSheet.Controls.Add(_sheetControl);
                    _sheetControl.Dock = DockStyle.Fill;
                    tabBOQSheets.Pages.Add(pageBOQSheet);
                    _sheetControl.PopulateBOQItemsGrid();
                    _sheetControl.SetBOQItemsGridColumnSizes();
                    tabBOQSheets.SelectedPage = pageBOQSheet;
                    _sheetControl.Visible = true;

                    //PopulateBOQItemsGrid();
                    btnAddNewBOQSheet.Enabled = btnSaveBOQ.Enabled = ButtonEnabled.True;


                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnAddNewBOQSheetClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
   }
        private void btnRemoveBOQSheet_Click(object sender, EventArgs e)
        {
            try
            {
                string sheetName = tabBOQSheets.SelectedPage.Text;
                string strMessage = string.Format("Are you Sure to Remove \n{0}\nfrom the Desing BOQ", sheetName);
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;

                SalesEnquiryDesignBOQSheet currSheet = MODEL.SHEETS.Where(x => x.SheetName == sheetName).FirstOrDefault();
                if (currSheet != null) MODEL.SHEETS.Remove(currSheet);
                KryptonPage currTabPage = tabBOQSheets.Pages.Where(x => x.Text == sheetName).FirstOrDefault();
                if (currTabPage != null) tabBOQSheets.Pages.Remove(currTabPage);
                MODEL = (new ServiceSalesEnquiryBOQ()).SaveDesignBOQ(MODEL, Program.CURR_USER.EmployeeID);
                PopulateDesingBOQ();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnRemoveBOQSheet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnSaveBOQ_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int IDX = tabBOQSheets.SelectedIndex;
                MODEL = (new ServiceSalesEnquiryBOQ()).SaveDesignBOQ(MODEL, Program.CURR_USER.EmployeeID);
                PopulateDesingBOQ();
                tabBOQSheets.SelectedPage = tabBOQSheets.Pages[IDX];
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnSaveBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnExcelPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strFileName = MODEL.BOQ_NUMBER.Replace("/", "").Replace("#", "").Replace("-", "");
                strFileName = string.Format("{0}{1}.xls",AppCommon.GetDefaultStorageFolderPath(), strFileName);
                (new ServiceExcelApp()).ExportDesignBOQBookToExcel(MODEL,  strFileName);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnExcelPreview_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void ControlSalesEnquiryDesignBOQ_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }
        private void btnDuplicateBOQ_Click(object sender, EventArgs e)
        {
            try
            {
                string strMessage = "Are you Sure to create a Fresh Copy from the BOQs in Past Enquiries";
                if (MessageBox.Show(strMessage, "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                frmGridMultiSelect frm = new frmGridMultiSelect(APP_ENTITIES.SALES_ENQUIRY);
                frm.SingleSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    PopulateDesingBOQFromPreviousEnquiry(frm.SelectedItems[0].ID);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesEnquiryDesignBOQ::btnDuplicateBOQ_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

       

    }
}
