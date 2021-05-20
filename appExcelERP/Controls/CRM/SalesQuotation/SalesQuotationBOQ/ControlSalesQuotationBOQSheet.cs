using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;

using appExcelERP.Controls.CRM.SalesQuotationBOQ;
using libERP.MODELS;
using libERP.SERVICES;
using libERP.MODELS.CRM;
using libERP.SERVICES.CRM;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.CRM
{

    public partial class ControlSalesQuotationBOQSheet : UserControl
    {
        // Declare an event 
        public event BOQSheetChangedEventHandler OnValueChanged;

        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                gridBOQItems.ReadOnly = _ReadOnly;
                if (_ReadOnly == true)
                {
                    btnAddParentItem.Enabled =
                    btnEditItem.Enabled =
                    btnRemoveItem.Enabled =
                    btnAddNewChildItem.Enabled =
                    btnClearAllBoqItems.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
                else
                {
                    btnAddParentItem.Enabled =
                    btnEditItem.Enabled =
                    btnRemoveItem.Enabled =
                    btnAddNewChildItem.Enabled =
                    btnClearAllBoqItems.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.True;
                }
            }
        }

        private bool ShowChildren = true;

        public int SelectedItemIndexID { get; set; }
        public int SelectedItemDBID { get; set; }
        public int SelectedParentItemIndexID { get; set; }
        public int SelectedAssemblyParentItemIndexID { get; set; }
        public int SelectedItemType { get; set; }
        public decimal SelectedDesingBOQ_SRNO { get; set; }

        public DataTable dataTableQuantityUsed = null;
        private ServiceSalesQuotationBOQ _BOQ_SERVICE = null;
        public SalesQuotationBOQSheet BOQ_SHEET_MODEL { get; set; }
        public SalesQuotationBOQViewModel BOQ_MODEL { get; set; }
        

        //public int SelectedParentItemID { get; set; }
        //public int SelectedChildItemID { get; set; }

        public bool SelectedItemIsAsseblyItem { get; set; }
        //private bool ShowChildren = true;

        public KryptonPage ParentTabPage { get; set; }


        #region BOT ITEM CHARGES INFO CONTROL
        private ControlSalesQuotationBOQItemCharges _ctrlChargesInfo = null;
        private void InitializeBOQItemChargesInfoControl()
        {
            _ctrlChargesInfo = new ControlSalesQuotationBOQItemCharges();
            _ctrlChargesInfo.OnValueChanged += _ctrlChargesInfo_OnValueChanged;
            splitContainerLeft.Panel2.Controls.Add(_ctrlChargesInfo);
            _ctrlChargesInfo.Dock = DockStyle.Fill;
        }
        private void _ctrlChargesInfo_OnValueChanged(object sender, BOQItemChargesChangedEventArgs e)
        {
            try
            {
                _BOQ_SERVICE.UpdateParentItemTotalForSheet(BOQ_SHEET_MODEL, e.ITEM_INDEX);
                _BOQ_SERVICE.UpdateSalesQuotationBOQSheetSummary(BOQ_SHEET_MODEL);
                if (_ctrlSheetSummaryInfo != null)
                {
                    _ctrlSheetSummaryInfo.MODEL = BOQ_SHEET_MODEL.SUMMARY;
                    _ctrlSheetSummaryInfo.PopulateSummaryInfoControl();
                }
                if (OnValueChanged != null)
                    OnValueChanged(this);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::_ctrlChargesInfo_OnValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private ControlSalesQuotationBOQSheetSummary _ctrlSheetSummaryInfo = null;
        private void InitializeBOQSheetSummaryInfoControl()
        {
            _ctrlSheetSummaryInfo = new ControlSalesQuotationBOQSheetSummary();
            splitContainerMain.Panel2.Controls.Add(_ctrlSheetSummaryInfo);
            _ctrlSheetSummaryInfo.Dock = DockStyle.Fill;
        }
        

        public ControlSalesQuotationBOQSheet()
        {
            InitializeComponent();
            InitializeBOQItemChargesInfoControl();
            InitializeBOQSheetSummaryInfoControl();
        }
        private void ControlSalesQuotationBOQSheet_Load(object sender, EventArgs e)
        {
            _BOQ_SERVICE = new ServiceSalesQuotationBOQ();
            _ctrlChargesInfo.Visible = true;
            _ctrlSheetSummaryInfo.Visible = true;
            splitContainerMain.SplitterDistance = (int)(this.Width * .8);
            splitContainerLeft.SplitterDistance = (int)(this.Width * .5);

            splitContainerMain.Panel2Collapsed = true;
            splitContainerLeft.Panel2Collapsed = true;
        }

        public ControlSalesQuotationBOQSheet(SalesQuotationBOQSheet Sheet)
        {
            InitializeComponent();
            this.BOQ_SHEET_MODEL = Sheet;
            InitializeBOQItemChargesInfoControl();
            InitializeBOQSheetSummaryInfoControl();
        }
        private void btnShowHideChildren_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
        }

       
        #region BOQ PARENT ITEMS
        public void PopulateBOQItemsGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                gridBOQItems.DataSource = null;
                gridBOQItems.Refresh();
                if (BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Count > 0)
                {
                    BOQ_SHEET_MODEL.datatableQuotationBOQ.DefaultView.Sort =string.Format("[{0}] ASC", _BOQ_SERVICE.COL_SERIAL_NO_SYS);
                }
                gridBOQItems.DataSource = BOQ_SHEET_MODEL.datatableQuotationBOQ;
                gridBOQItems.RowHeadersVisible = false;
                gridBOQItems.Refresh();
                _ctrlSheetSummaryInfo.MODEL = BOQ_SHEET_MODEL.SUMMARY;
                _ctrlSheetSummaryInfo.PopulateSummaryInfoControl();

                if (this._ReadOnly)
                {
                    btnAddParentItem.Enabled = btnEditItem.Enabled = btnRemoveItem.Enabled = btnAddNewChildItem.Enabled = btnClearAllBoqItems.Enabled = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                }
                else
                { 
                    if (gridBOQItems.Rows.Count == 0)
                        btnAddNewChildItem.Visible = btnRemoveItem.Visible = false;
                    else
                        btnAddNewChildItem.Visible = btnRemoveItem.Visible = true;
                }
                //SetBOQItemsGridColumnSettings();
                //SetBOQItemsGridColumnFormatting();
                //gridBOQItems.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::PopulateBOQItemsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        public void SetBOQItemsGridColumnSettings()
        {
            try
            {
                if (gridBOQItems.Columns.Count == 0) return;

                gridBOQItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // HIDE COLUMNS
                gridBOQItems.Columns[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_INDEX].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_PARENT_INDEX].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_IS_ASSEMBLY].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_IS_ASSEMBLY_CHILD].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_DESIGN].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_PARENT_ITEM_DB_ID].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_DB_ID].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_CODE].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_HSN_CODE].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SEARCH_TEXT].Visible =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_UOM_ID].Visible = false;
                // SET COLUMNS AS READONLY
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_SYS].ReadOnly =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].ReadOnly =
                gridBOQItems.Columns[_BOQ_SERVICE.COL_UOM_CODE].ReadOnly = true;



                int descriptionWidth = (int)(gridBOQItems.Width * .5);
                gridBOQItems.Columns[_BOQ_SERVICE.COL_TOTAL_QUANTITY].MinimumWidth = 60;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_TOTAL_QUANTITY].Width = 60;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].MinimumWidth = 100;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].Width = descriptionWidth;

                gridBOQItems.Columns[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].HeaderText = "Particulars of Item";
                gridBOQItems.Columns[_BOQ_SERVICE.COL_TOTAL_QUANTITY].HeaderText = "Total";


                gridBOQItems.Columns[_BOQ_SERVICE.COL_UOM_CODE].HeaderText = "UoM";
                gridBOQItems.Columns[_BOQ_SERVICE.COL_UOM_CODE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_SYS].HeaderText = "#";
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_SYS].MinimumWidth = 50;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_SYS].Width = 50;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_SYS].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_BOQ].HeaderText = "SRNO.";
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_BOQ].MinimumWidth = 50;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_BOQ].Width = 50;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_BOQ].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT].HeaderText = "SRNO.(Ref.)";
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT].MinimumWidth = 100;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT].Width = 50;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                Font F = this.Font;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_TOTAL_QUANTITY].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridBOQItems.Columns[_BOQ_SERVICE.COL_TOTAL_QUANTITY].DefaultCellStyle.Font = new Font(this.Font.FontFamily.Name, this.Font.Size, FontStyle.Bold);

                foreach (DataGridViewColumn col in gridBOQItems.Columns)
                {
                    EnquiryBOQService selItem = BOQ_SHEET_MODEL.BOQ_SERVICES.Where(x => x.Description == col.HeaderText).FirstOrDefault();
                    if (selItem != null)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                        //col.MinimumWidth = 30;
                        //col.Width = 31;
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::SetBOQItemsGridColumnSettings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetBOQItemsGridColumnFormatting()
        {
            try
            {
                
                foreach (DataGridViewRow row in gridBOQItems.Rows)
                {
                    BOQ_ITEM_TYPE mItemType = (BOQ_ITEM_TYPE)int.Parse(row.Cells[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE].Value.ToString());
                    if (mItemType == BOQ_ITEM_TYPE.PARENT_ITEM)
                    {
                       // row.DefaultCellStyle.Font = new Font(gridBOQItems.Font, FontStyle.Bold);
                    }
                    else
                    {
                        bool isAssemblyChild = (bool)row .Cells[_BOQ_SERVICE.COL_IS_ASSEMBLY_CHILD].Value;
                        if(isAssemblyChild)
                            row.Cells[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].Style.Padding = new Padding(40, 0, 0, 0);
                        else
                            row.Cells[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].Style.Padding = new Padding(20, 0, 0, 0);


                        //int parentIndex = int.Parse(row.Cells[_BOQ_SERVICE.COL_PARENT_INDEX].Value.ToString());
                        //int parentAssemblyIndex = int.Parse(row.Cells[_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX].Value.ToString());
                        //int parentIndex = int.Parse(row.Cells[_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX].Value.ToString()); 
                        //if(parentIndex!=0 && isAssemblyChild)
                        //    row.Cells[_BOQ_SERVICE.COL_SEARCH_TEXT].Style.Padding = new Padding(60, 0, 0, 0);
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::SetBOQItemsGridColumnFormatting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void gridBOQItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                SetBOQItemsGridColumnSettings();
                SetBOQItemsGridColumnFormatting();
                //Application.DoEvents();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::gridBOQItems_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridBOQItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            try
            {
                decimal totQty = 0;
                if (e.RowIndex >= 0)
                {
                    string strColName = gridBOQItems.Columns[e.ColumnIndex].Name;
                    EnquiryBOQService selService = BOQ_SHEET_MODEL.BOQ_SERVICES.Where(x => x.Description == strColName).FirstOrDefault();
                    //IF QUANTITY ENTERED IN SERVICES COLUMN THEN SUM ALL SERVICE QUANTITIES AND MAKE TOTAL QUANITYT
                    if (selService != null)
                    {
                        //UPDATE TOTAL QTY FOR THE SELECTED ROW
                        totQty = 0;
                        foreach (EnquiryBOQService item in BOQ_SHEET_MODEL.BOQ_SERVICES)
                        {
                            totQty += decimal.Parse(gridBOQItems.Rows[e.RowIndex].Cells[item.Description].Value.ToString());
                        }
                        gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_TOTAL_QUANTITY].Value = totQty;
                        if (totQty != 0)
                        {
                            //gridBOQItems.Rows[e.RowIndex].Cells["HasServices"].Value = true;
                            gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_TOTAL_QUANTITY].ReadOnly = true;
                        }
                        else
                        {
                            //gridBOQItems.Rows[e.RowIndex].Cells["HasServices"].Value = false;
                            gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_TOTAL_QUANTITY].ReadOnly = false;
                        }
                        //SelectedItemIsAsseblyItem = bool.Parse(gridBOQItems.Rows[e.RowIndex].Cells["IsAssembly"].Value.ToString());
                        //gridBOQItems.EditMode = DataGridViewEditMode.EditProgrammatically;
                        //IF THE ROW IS AN ASSEMBLY ITEM UPDATE QUANTITIES OF ALL ITS CHILD ITEMS
                        //if (SelectedItemIsAsseblyItem)
                        //{
                        //    foreach (DataGridViewRow childRow in gridBOQItems.Rows)
                        //    {
                        //        int parentID = int.Parse(childRow.Cells["ParentItemID"].Value.ToString());
                        //        if (parentID == SelectedItemID)
                        //        {
                        //            decimal defVal = decimal.Parse(childRow.Cells["DefaultQty"].Value.ToString());
                        //            childRow.Cells["TotalQty"].Value = totQty * defVal;
                        //        }
                        //    }
                        //}
                        //gridBOQItems.EditMode = DataGridViewEditMode.EditOnKeystroke;


                    }
                    else
                    {
                        //if (strColName == "TotalQty")
                        //{
                        //    SelectedItemIsAsseblyItem = bool.Parse(gridBOQItems.Rows[e.RowIndex].Cells["IsAssembly"].Value.ToString());
                        //    totQty = decimal.Parse(gridBOQItems.Rows[e.RowIndex].Cells["TotalQty"].Value.ToString());
                        //    //IF THE ROW IS AN ASSEMBLY ITEM UPDATE QUANTITIES OF ALL ITS CHILD ITEMS
                        //    if (SelectedItemIsAsseblyItem)
                        //    {
                        //        foreach (DataGridViewRow childRow in gridBOQItems.Rows)
                        //        {
                        //            int parentID = int.Parse(childRow.Cells["ParentItemID"].Value.ToString());
                        //            if (parentID == SelectedItemID)
                        //            {
                        //                decimal defVal = decimal.Parse(childRow.Cells["DefaultQty"].Value.ToString());
                        //                childRow.Cells["TotalQty"].Value = totQty * defVal;
                        //            }
                        //        }
                        //    }
                        //    //gridBOQItems.EditMode = DataGridViewEditMode.EditOnKeystroke;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::gridBOQItems_CellEndEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void gridBOQItems_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::gridBOQItems_CellLeave", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void gridBOQItems_Resize(object sender, EventArgs e)
        {
            SetBOQItemsGridColumnSettings();
        }
        private void gridBOQItems_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //btnViewItemInfo.Visible = true;
                this.SelectedItemIndexID = int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_ITEM_INDEX].Value.ToString());
                this.SelectedParentItemIndexID = int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_PARENT_INDEX].Value.ToString());
                this.SelectedAssemblyParentItemIndexID = int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX].Value.ToString());
                this.SelectedItemType =  int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE].Value.ToString());

                btnAddNewChildItem.Visible = (SelectedParentItemIndexID == 0) ? true : false;
                this.SelectedItemDBID= int.Parse(gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_ITEM_DB_ID].Value.ToString());
                gridItemSummary.DataSource = null;
                if (SelectedItemDBID != 0)
                {
                    SelectedDesingBOQ_SRNO = 0;
                    SelectedDesingBOQ_SRNO = decimal.Parse(gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_SERIAL_NO_DESIGN].Value.ToString());
                    PopulateSelectedItemQuantitySummaryGrid();
                }

                //_ctrlChargesInfo.CONFIGURATION_INFO = BOQ_MODEL.CONFIGURATION;
                BOQItemChargesModel chargeModel= BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == this.SelectedItemIndexID).FirstOrDefault();
                if (chargeModel != null)
                    _ctrlChargesInfo.ITEM_CHARGES_INFO = chargeModel;
                else
                    _ctrlChargesInfo.ITEM_CHARGES_INFO = new BOQItemChargesModel();
                _ctrlChargesInfo.ITEM_TYPE = (BOQ_ITEM_TYPE)this.SelectedItemType;
                _ctrlChargesInfo.ITEM_QUANTITY = decimal.Parse(gridBOQItems.Rows[e.RowIndex].Cells[_BOQ_SERVICE.COL_TOTAL_QUANTITY].Value.ToString());
                _ctrlChargesInfo.PopulateItemChargesControl();
                _ctrlChargesInfo.ReadOnly = this._ReadOnly;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::gridBOQItems_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridBOQItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strColName = gridBOQItems.Columns[e.ColumnIndex].Name;
                EnquiryBOQService item = BOQ_SHEET_MODEL.BOQ_SERVICES.Where(x => x.Description == strColName).FirstOrDefault();
                if(item==null) btnEditParentItem_Click(btnEditItem, null);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::gridBOQItems_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void PopulateSelectedItemQuantitySummaryGrid()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                gridItemSummary.DataSource = _BOQ_SERVICE.GetItemQuantitySummary(this.SelectedDesingBOQ_SRNO, this.BOQ_SHEET_MODEL);
                gridItemSummary.Refresh();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::PopulateSelectedItemQuantitySummaryGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearchBOQItemsGrid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string strFiler = string.Format("[{0}] LIKE '%{1}%'", _BOQ_SERVICE.COL_SEARCH_TEXT, txtSearchBOQItemsGrid.Text);
                (gridBOQItems.DataSource as DataTable).DefaultView.RowFilter = strFiler;
                gridBOQItems.Refresh();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::txtSearchBOQItemsGrid_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        #endregion

        private void btnAddParentItem_Click(object sender, EventArgs e)
        {
            try
            {
                // GET NEXT NEW SERIALNO
                int maxSerial = 0;
                string expr = string.Format("MAX([{0}])", _BOQ_SERVICE.COL_SERIAL_NO_SYS);
                if (BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Count > 0)
                    maxSerial = Convert.ToInt32(BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(expr, string.Empty));
                maxSerial++;
                frmAddEditBoqItem frm = new frmAddEditBoqItem();
                
                frm.SERIAL_NO_SYS = maxSerial;
                frm.SERIAL_NO_BOQ = String.Empty;
                frm.ITEM_DESCRIPTION = String.Empty;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // add a new row into BOQ datatable 
                    DataRow dtrow = BOQ_SHEET_MODEL.datatableQuotationBOQ.NewRow();
                    dtrow[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.PARENT_ITEM;
                    dtrow[_BOQ_SERVICE.COL_SEARCH_TEXT] = frm.ITEM_DESCRIPTION;
                    dtrow[_BOQ_SERVICE.COL_ITEM_INDEX] = GetNewItemIndex();
                    dtrow[_BOQ_SERVICE.COL_SERIAL_NO_SYS] = frm.SERIAL_NO_SYS;
                    dtrow[_BOQ_SERVICE.COL_SERIAL_NO_BOQ] = frm.SERIAL_NO_BOQ;
                    dtrow[_BOQ_SERVICE.COL_ITEM_DESCRIPTION] = frm.ITEM_DESCRIPTION;
                    dtrow[_BOQ_SERVICE.COL_PARENT_INDEX] = 0;
                    dtrow[_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX] = 0;
                    dtrow[_BOQ_SERVICE.COL_IS_ASSEMBLY] = false;
                    dtrow[_BOQ_SERVICE.COL_IS_ASSEMBLY_CHILD] = false;
                    dtrow[_BOQ_SERVICE.COL_ITEM_DB_ID] = 0;
                    dtrow[_BOQ_SERVICE.COL_UOM_ID] = frm.UOM_ID;
                    dtrow[_BOQ_SERVICE.COL_UOM_CODE] = frm.UOM_NAME;
                    dtrow[_BOQ_SERVICE.COL_TOTAL_QUANTITY] = 0;
                    dtrow[_BOQ_SERVICE.COL_ITEM_CODE] = "";
                    dtrow[_BOQ_SERVICE.COL_ITEM_HSN_CODE] = "";
                    dtrow[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT] = frm.SERIAL_NO_CLIENT;
                    //SET SERVICS COLUMNS QTY VALUE TO 0
                    foreach (EnquiryBOQService selService in BOQ_SHEET_MODEL.BOQ_SERVICES)
                    {
                        dtrow[selService.Description] = 0;
                    }
                    BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Add(dtrow);
                    // ADD CHARGE INFO OBJECT FOR STORING VARIOUS CHARGES APPLIED ON ITEM
                    BOQItemChargesModel chargesOnItem = new BOQItemChargesModel();
                    chargesOnItem.Index = int.Parse(dtrow[_BOQ_SERVICE.COL_ITEM_INDEX].ToString());
                    BOQ_SHEET_MODEL.ITEM_CHARGES.Add(chargesOnItem);
                    PopulateBOQItemsGrid();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::btnAddParentItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditParentItem_Click(object sender, EventArgs e)
        {
            try
            {
                // GET DATAROW TO BE EDITED
                string strExpr = string.Format("[{0}]={1}",_BOQ_SERVICE.COL_ITEM_INDEX, this.SelectedItemIndexID);
                DataRow[] rows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                if (rows.Count() > 0)
                {

                    DataRow selRow = rows[0];
                    frmAddEditBoqItem frm = new frmAddEditBoqItem();
                    frm.INDEX_ID = this.SelectedItemIndexID;
                    frm.SERIAL_NO_SYS =decimal.Parse(selRow[_BOQ_SERVICE.COL_SERIAL_NO_SYS].ToString());
                    frm.SERIAL_NO_BOQ = selRow[_BOQ_SERVICE.COL_SERIAL_NO_BOQ].ToString();
                    frm.SERIAL_NO_CLIENT = selRow[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT].ToString();
                    frm.ITEM_DESCRIPTION= selRow[_BOQ_SERVICE.COL_ITEM_DESCRIPTION].ToString();
                    frm.UOM_ID= int.Parse(selRow[_BOQ_SERVICE.COL_UOM_ID].ToString());
                    frm.UOM_NAME = selRow[_BOQ_SERVICE.COL_UOM_CODE].ToString();

                    //frm.ScatterData();
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        selRow[_BOQ_SERVICE.COL_SERIAL_NO_SYS]=frm.SERIAL_NO_SYS;
                        selRow[_BOQ_SERVICE.COL_SERIAL_NO_BOQ]=frm.SERIAL_NO_BOQ;
                        selRow[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT] = frm.SERIAL_NO_CLIENT;
                        selRow[_BOQ_SERVICE.COL_ITEM_DESCRIPTION]=frm.ITEM_DESCRIPTION;
                        selRow[_BOQ_SERVICE.COL_UOM_ID]=frm.UOM_ID;
                        selRow[_BOQ_SERVICE.COL_UOM_CODE]=frm.UOM_NAME;
                        BOQ_SHEET_MODEL.datatableQuotationBOQ.AcceptChanges();
                        PopulateBOQItemsGrid();
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::btnEditParentItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewChildItem_Click(object sender, EventArgs e)
        {
            ServiceSalesEnquiryBOQ serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
            try
            {
                frmAddBOQChildItem FRM = new frmAddBOQChildItem();
                FRM.DATATABLE_SOURCE= _BOQ_SERVICE.GenerateSelectChildItemDatatable(this.BOQ_SHEET_MODEL);
                if (FRM.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataRow dRow in FRM.DATATABLE_SOURCE.Rows)
                    {
                        bool isSelected = bool.Parse(dRow["Selected"].ToString());
                        if (isSelected)
                        {
                            string strExpr = string.Format("[{0}]={1} AND [{2}]='{3}'", _BOQ_SERVICE.COL_PARENT_INDEX, this.SelectedItemIndexID, _BOQ_SERVICE.COL_SERIAL_NO_DESIGN, dRow[serviceDesignBOQ.COL_SERIAL_NO_SYS]);
                            DataRow[] result = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                            if (result.Count() == 0)
                            {
                                // add a new row into BOQ datatable 
                                DataRow newRow = BOQ_SHEET_MODEL.datatableQuotationBOQ.NewRow();
                                newRow[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.PARENT_ITEM;
                                newRow[_BOQ_SERVICE.COL_SEARCH_TEXT] = dRow[serviceDesignBOQ.COL_ITEM_DESCRIPTION];
                                newRow[_BOQ_SERVICE.COL_ITEM_INDEX] = GetNewItemIndex();
                                newRow[_BOQ_SERVICE.COL_SERIAL_NO_SYS] = GetNewSerialNoForChildItem(this.SelectedItemIndexID);
                                newRow[_BOQ_SERVICE.COL_SERIAL_NO_DESIGN] = dRow[serviceDesignBOQ.COL_SERIAL_NO_SYS];
                                newRow[_BOQ_SERVICE.COL_ITEM_DESCRIPTION] = dRow[serviceDesignBOQ.COL_ITEM_DESCRIPTION];
                                newRow[_BOQ_SERVICE.COL_PARENT_INDEX] = this.SelectedItemIndexID;
                                newRow[_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX] = 0;
                                newRow[_BOQ_SERVICE.COL_IS_ASSEMBLY] = dRow[serviceDesignBOQ.COL_IS_ASSEMBLY];
                                newRow[_BOQ_SERVICE.COL_IS_ASSEMBLY_CHILD] = false;
                                newRow[_BOQ_SERVICE.COL_PARENT_ITEM_DB_ID] = 0;
                                
                                newRow[_BOQ_SERVICE.COL_ITEM_DB_ID] = dRow[serviceDesignBOQ.COL_ITEM_ID];
                                newRow[_BOQ_SERVICE.COL_UOM_ID] = dRow[serviceDesignBOQ.COL_UOM_ID];
                                newRow[_BOQ_SERVICE.COL_UOM_CODE] = dRow[serviceDesignBOQ.COL_UOM_NAME];
                                newRow[_BOQ_SERVICE.COL_TOTAL_QUANTITY] = 0;
                                newRow[_BOQ_SERVICE.COL_ITEM_CODE] = dRow[serviceDesignBOQ.COL_ITEM_CODE];
                                newRow[_BOQ_SERVICE.COL_ITEM_HSN_CODE] = "";
                                newRow[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT] = "";
                                //SET SERVICS COLUMNS QTY VALUE TO 0
                                foreach (EnquiryBOQService selService in BOQ_SHEET_MODEL.BOQ_SERVICES)
                                {
                                    newRow[selService.Description] = 0;
                                }
                                BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Add(newRow);
                                bool isAssembly = bool.Parse(dRow[serviceDesignBOQ.COL_IS_ASSEMBLY].ToString());
                                if (isAssembly)
                                {
                                    newRow[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.CHILD_ITEM_IS_ASSEMBLY;
                                    AddAssemblyChildItems(dRow, newRow);
                                }
                                else
                                    newRow[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.CHILD_ITEM;

                                // ADD CHARGE INFO OBJECT FOR STORING VARIOUS CHARGES APPLIED ON ITEM
                                BOQItemChargesModel chargesOnItem = new BOQItemChargesModel();
                                chargesOnItem.Index = int.Parse(newRow[_BOQ_SERVICE.COL_ITEM_INDEX].ToString());
                                BOQ_SHEET_MODEL.ITEM_CHARGES.Add(chargesOnItem);
                            }
                        }
                    }
                     
                    PopulateBOQItemsGrid();

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::btnAddNewChildItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }
        private void btnShowHideSummary_Click(object sender, EventArgs e)
        {
            splitContainerMain.Panel2Collapsed = !splitContainerMain.Panel2Collapsed;
        }
        private void btnShowHideCharges_Click(object sender, EventArgs e)
        {
            splitContainerLeft.Panel2Collapsed = !splitContainerLeft.Panel2Collapsed;
        }

        public void AddAssemblyChildItems(DataRow designBOQAssemblyParentRow, DataRow quoteBOQParentRow)
        {
            ServiceSalesEnquiryBOQ serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
            try
            {
                // GET ALL CHILD ITEMS FOR THE GIVEN ASSEMBLY ITEM
                
                string strFilter = string.Format("[ParentItemID]={0}", quoteBOQParentRow[_BOQ_SERVICE.COL_ITEM_DB_ID] );
                DataRow[] childRows = BOQ_SHEET_MODEL.datatableEnquiryBOQ.Select(strFilter);
                if (childRows.Count() > 0)
                {
                    foreach (DataRow dRow in childRows)
                    {
                        // add a new row into BOQ datatable 
                        DataRow newRow = BOQ_SHEET_MODEL.datatableQuotationBOQ.NewRow();
                        newRow[_BOQ_SERVICE.COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.CHILD_ITEM_OF_ASSEMBLY_ITEM;
                        newRow[_BOQ_SERVICE.COL_SEARCH_TEXT] = dRow[serviceDesignBOQ.COL_ITEM_DESCRIPTION];
                        newRow[_BOQ_SERVICE.COL_ITEM_INDEX] = GetNewItemIndex();
                        newRow[_BOQ_SERVICE.COL_SERIAL_NO_SYS] = GetNewSerialNoForAssemblyChildItem(quoteBOQParentRow);
                        newRow[_BOQ_SERVICE.COL_SERIAL_NO_DESIGN] = dRow[serviceDesignBOQ.COL_SERIAL_NO_SYS];
                        newRow[_BOQ_SERVICE.COL_ITEM_DESCRIPTION] = dRow[serviceDesignBOQ.COL_ITEM_DESCRIPTION];
                        newRow[_BOQ_SERVICE.COL_PARENT_INDEX] = this.SelectedItemIndexID;
                        newRow[_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX] = quoteBOQParentRow[_BOQ_SERVICE.COL_ITEM_INDEX];
                        newRow[_BOQ_SERVICE.COL_IS_ASSEMBLY] = false;
                        newRow[_BOQ_SERVICE.COL_IS_ASSEMBLY_CHILD] = true;
                        newRow[_BOQ_SERVICE.COL_PARENT_ITEM_DB_ID] = quoteBOQParentRow[_BOQ_SERVICE.COL_ITEM_DB_ID];
                        newRow[_BOQ_SERVICE.COL_ITEM_DB_ID] = dRow[serviceDesignBOQ.COL_ITEM_ID];
                        
                        newRow[_BOQ_SERVICE.COL_UOM_ID] = dRow[serviceDesignBOQ.COL_UOM_ID];
                        newRow[_BOQ_SERVICE.COL_UOM_CODE] = dRow[serviceDesignBOQ.COL_UOM_NAME];
                        newRow[_BOQ_SERVICE.COL_TOTAL_QUANTITY] = 0;
                        newRow[_BOQ_SERVICE.COL_ITEM_CODE] = dRow[serviceDesignBOQ.COL_ITEM_CODE]; ;
                        newRow[_BOQ_SERVICE.COL_ITEM_HSN_CODE] = "";
                        newRow[_BOQ_SERVICE.COL_SERIAL_NO_CLIENT] = "";
                        //SET SERVICS COLUMNS QTY VALUE TO 0
                        foreach (EnquiryBOQService selService in BOQ_SHEET_MODEL.BOQ_SERVICES)
                        {
                            newRow[selService.Description] = 0;
                        }
                        BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Add(newRow);
                        // ADD CHARGE INFO OBJECT FOR STORING VARIOUS CHARGES APPLIED ON ITEM
                        BOQItemChargesModel chargesOnItem = new BOQItemChargesModel();
                        chargesOnItem.Index = int.Parse(newRow[_BOQ_SERVICE.COL_ITEM_INDEX].ToString());
                        BOQ_SHEET_MODEL.ITEM_CHARGES.Add(chargesOnItem);
                    }
                    
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::AddAssemblyChildItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int GetNewItemIndex()
        {
            int newIndex = 0;
            try
            {
                string expr = string.Format("MAX([{0}])", _BOQ_SERVICE.COL_ITEM_INDEX);
                if(BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Count>0)
                    newIndex = int.Parse(BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(expr, "").ToString());
                newIndex++;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::GetNewItemIndex", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newIndex;
        }

        public decimal GetNewSerialNoForChildItem(decimal ParentIndex)
        {
            decimal parentSerial = 0;
            decimal newSerial = 0;

            try
            {
                //SELECT PARENT ROW FROM DATABALE
                string strExpr = string.Format("[{0}]={1}", _BOQ_SERVICE.COL_ITEM_INDEX, ParentIndex);

                DataRow[] rowParent = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                if (rowParent.Count() > 0)
                {
                    parentSerial= decimal.Parse(rowParent[0][_BOQ_SERVICE.COL_SERIAL_NO_SYS].ToString());
                    string strFilter = string.Format("[{0}]={1} And [{2}]=0", _BOQ_SERVICE.COL_PARENT_INDEX, ParentIndex, _BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX);
                    DataRow[] childRows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strFilter);
                    int numberOfRecords = childRows.Count()+1;
                    newSerial = decimal.Parse(string.Format("{0}.{1}", parentSerial, numberOfRecords.ToString().PadLeft(2,'0')));
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::GetNewSerialNoForChildItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newSerial;
        }
        public decimal GetNewSerialNoForAssemblyChildItem(DataRow AssemblyItemRow)
        {
            decimal parentSerial = 0;
            decimal newSerial = 0;
            int parentIndex = 0;
            try
            {
                parentIndex= int.Parse(AssemblyItemRow[_BOQ_SERVICE.COL_ITEM_INDEX].ToString());
                parentSerial = decimal.Parse(AssemblyItemRow[_BOQ_SERVICE.COL_SERIAL_NO_SYS].ToString());

                string strFilter = string.Format("[{0}]={1}", _BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX, parentIndex);
                DataRow[] childRows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strFilter);
                int numberOfRecords = childRows.Count() + 1;
                decimal suffixNo = decimal.Parse(string.Format("0.{0}", numberOfRecords.ToString().PadLeft(4, '0')));
                newSerial = parentSerial+ suffixNo;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::GetNewSerialNoForChildItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newSerial;
        }
        private void gridItemSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                ServiceSalesEnquiryBOQ serviceDESIGN_BOQ = new ServiceSalesEnquiryBOQ();
                gridItemSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridItemSummary.Columns[serviceDESIGN_BOQ.COL_DEFAULT_QTY].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_INDEX].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_SERIAL_NO_SYS].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_PARENT_ITEM_ID].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_HAS_SERVICES].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_IS_ASSEMBLY].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_ITEM_ID].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_ITEM_CODE].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_UOM_ID].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_UOM_NAME].Visible =
                    gridItemSummary.Columns[serviceDESIGN_BOQ.COL_ITEM_DESCRIPTION].Visible =
                    false;
                Font F = this.Font;
                gridItemSummary.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridItemSummary.RowsDefaultCellStyle.Font = new Font(this.Font.FontFamily.Name, this.Font.Size, FontStyle.Bold);


                gridItemSummary.Columns[serviceDESIGN_BOQ.COL_TOTAL_QTY].MinimumWidth = 80;
                gridItemSummary.Columns[serviceDESIGN_BOQ.COL_TOTAL_QTY].Width = 80;
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::gridItemSummary_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoveItem_Click(object sender, EventArgs e)
        {

            List<DataRow> rowsToDelete = new List<DataRow>();
            DataRow[] childRows = null;

            try
            {
                string strFilter = string.Format("[{0}]={1}", _BOQ_SERVICE.COL_ITEM_INDEX, this.SelectedItemIndexID);
                DataRow[] selRows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strFilter);
                if (selRows.Count() == 0) return;

                string strDescription = selRows[0][_BOQ_SERVICE.COL_ITEM_DESCRIPTION].ToString();
                string strMessage =string.Format("You are about to Remove Item\n{0}\n\nThe item will be removed along with its child items.", strDescription);
                if (MessageBox.Show(strMessage, "Sure to proceed", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    // FETCH SELECTED ITEM
                    strFilter = string.Format("[{0}]={1}", _BOQ_SERVICE.COL_ITEM_INDEX, this.SelectedItemIndexID);
                    selRows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strFilter);
                    if (selRows.Count() > 0)
                    {
                        rowsToDelete.Add(selRows[0]);
                    }
                    // FETCH ALL CHIDL ROWS FOR SELECTED ITEM
                    strFilter = string.Format("[{0}]={1} OR [{2}]={1}", _BOQ_SERVICE.COL_PARENT_INDEX, this.SelectedItemIndexID,_BOQ_SERVICE.COL_ASSEMBLY_PARENT_INDEX);
                    childRows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strFilter);
                    if (childRows.Count() > 0)
                    {
                        foreach (DataRow delRow in childRows)
                        {
                            rowsToDelete.Add(delRow);

                            // fetch fuerther childrens of each child
                            //strFilter = string.Format("[{0}]={1}", _BOQ_SERVICE.COL_PARENT_INDEX, delRow[_BOQ_SERVICE.COL_ITEM_INDEX].ToString());
                            //DataRow[] childs = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strFilter);
                            //if (childs.Count() > 0)
                            //{
                            //    foreach (DataRow row in childs)
                            //        rowsToDelete.Add(row);
                            //}

                        }

                    }

                    //FINALLY REMOVE ALL ITEM PERMANENTLY ALONG WITH ITS CHARGES INFO AND UPDATE DATATABLE
                    foreach (DataRow mRow in rowsToDelete)
                    {
                        int index= int.Parse(mRow[_BOQ_SERVICE.COL_ITEM_INDEX].ToString());
                        BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Remove(mRow);
                        BOQItemChargesModel charges = BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == index).FirstOrDefault();
                        if (charges != null)
                            BOQ_SHEET_MODEL.ITEM_CHARGES.Remove(charges);
                    }
                    BOQ_SHEET_MODEL.datatableQuotationBOQ.AcceptChanges();
                    PopulateBOQItemsGrid();
                    

                    //UPDATE ITEMS AND SUMMARY VALUES 
                    _BOQ_SERVICE.UpdateParentItemTotalForSheet(BOQ_SHEET_MODEL, this.SelectedItemIndexID);
                    _BOQ_SERVICE.UpdateSalesQuotationBOQSheetSummary(BOQ_SHEET_MODEL);
                    
                    //REFRESH BOTH THE CONTROLS 1.ITEM CHARGE INFO 2.SHEET SUMMARY
                    if (_ctrlSheetSummaryInfo != null)
                    {
                        _ctrlSheetSummaryInfo.MODEL = BOQ_SHEET_MODEL.SUMMARY;
                        _ctrlSheetSummaryInfo.PopulateSummaryInfoControl();
                    }
                    if (_ctrlChargesInfo != null)
                    {
                        _ctrlChargesInfo.ITEM_CHARGES_INFO = BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == this.SelectedItemIndexID).FirstOrDefault();
                        _ctrlChargesInfo.PopulateItemChargesControl();
                    }

                    this.Cursor = Cursors.WaitCursor;
                }


                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::btnRemoveItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnShowHideChildItems_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ShowChildren = !ShowChildren;
                foreach (DataGridViewRow row in gridBOQItems.Rows)
                {
                    int parent = int.Parse(row.Cells[_BOQ_SERVICE.COL_PARENT_INDEX].Value.ToString());
                    if (parent != 0) row.Visible = ShowChildren;
                }
                btnShowHideChildItems.Text = (ShowChildren == true) ? "Hide Child Items" : "Show Child Items";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQSheet::btnShowHideChildItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        
    }

}
