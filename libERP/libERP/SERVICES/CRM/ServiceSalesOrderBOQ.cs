using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.CRM;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.MASTER;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.CRM
{
    public class ServiceSalesOrderBOQ : DefaultService
    {
        public string COL_BOQ_ITEM_TYPE = "BOQ_ITEM_TYPE";
        public string COL_ITEM_INDEX = "INDEX";
        public string COL_PARENT_INDEX = "PARENT_INDEX";
        public string COL_ASSEMBLY_PARENT_INDEX = "ASSEMBLY_PARENT_INDEX";
        public string COL_IS_ASSEMBLY = "IS_ASSEMBLY";
        public string COL_IS_ASSEMBLY_CHILD = "IS_ASSEMBLY_CHILD";
        public string COL_SERIAL_NO_SYS = "SERIAL_NO_SYS";
        public string COL_SERIAL_NO_BOQ = "SERIAL_NO_BOQ";
        public string COL_SERIAL_NO_DESIGN = "SERIAL_NO_DESIGN";
        public string COL_PARENT_ITEM_DB_ID = "PARENT_DATABASE_ID";
        public string COL_ITEM_DB_ID = "DATABASE_ID";
        public string COL_ITEM_CODE = "ITEM_CODE";
        public string COL_ITEM_HSN_CODE = "HSN_CODE";
        public string COL_SERIAL_NO_CLIENT = "SERIAL_NO_CLIENT";
        public string COL_ITEM_DESCRIPTION = "ITEM_DESCRIPTION";
        public string COL_SEARCH_TEXT = "SEARCH_TEXT";
        public string COL_UOM_ID = "ITEM_UOM_ID";
        public string COL_UOM_CODE = "ITEM_UOM_NAME";
        public string COL_TOTAL_QUANTITY = "TOTAL_QUANTITY";


        // COLUMNS FOR BOQ SUMMARY
        public string COL_BOQ_SUMMARY_SRNO = "SRNO";
        public string COL_BOQ_SUMMARY_SHEETNAME = "DESCRIPTION";
        public string COL_BOQ_SUMMARY_MATERIAL_TOTAL = "MATERIAL";
        public string COL_BOQ_SUMMARY_INSTALLATION_TOTAL = "INSTALLATION";
        public string COL_BOQ_SUMMARY_TOTAL = "TOTAL";
        
        public ServiceSalesOrderBOQ(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceSalesOrderBOQ()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public TBL_MP_CRM_SalesOrder_BOQ GetSalesOrderBOQdbInfo(int orderID)
        {
            TBL_MP_CRM_SalesOrder_BOQ model = null;
            try
            {
                model = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_BOQ where xx.ORDER_ID == orderID select xx).FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrderBOQ::GetSalesOrderBOQdbInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public SalesOrderBOQViewModel GetBOQViewModelForOrder(int orderID)
        {
            TBL_MP_CRM_SalesOrder_BOQ dbModel = null;
            SalesOrderBOQViewModel viewModel = null;
            try
            {
                dbModel = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_BOQ where xx.ORDER_ID == orderID select xx).FirstOrDefault();
                if (dbModel != null)
                {
                    string json = dbModel.BOQ_OBJECT;
                    viewModel = JsonConvert.DeserializeObject<SalesOrderBOQViewModel>(json);
                    foreach (SalesOrderBOQSheet sheet in viewModel.SHEETS)
                    {
                        sheet.ITEM_CHARGES = GetItemChargesCollectionForBOQSheet(viewModel.ORDER_ID, viewModel.BOQ_ID, sheet.SheetName);
                        if (sheet.datatableQuotationBOQ.Rows.Count == 0)
                        {
                            sheet.datatableQuotationBOQ = GenerateBOQDataTableDefault();
                            sheet.datatableQuotationBOQ = UpdateBOQDataTableWithServices(sheet.datatableQuotationBOQ, sheet.BOQ_SERVICES);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::GetViewModelForQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return viewModel;
        }
        public SalesOrderBOQViewModel GenerateDefaultBOQForSalesOrder(int orderID)
        {
            SalesOrderBOQViewModel viewModel = new SalesOrderBOQViewModel();
            try
            {
                TBL_MP_CRM_SalesOrder dbOrder = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == orderID).FirstOrDefault();
                if (dbOrder != null)
                {
                    viewModel.SHEETS = new List<SalesOrderBOQSheet>();
                    viewModel.SUMMARY = new SalesOrderBOQSummary();
                    viewModel.ORDER_ID = orderID;
                    viewModel.BOQ_NUMBER = string.Format("{0}-{1}", dbOrder.SalesOrderNo, "BOQ");
                    if (dbOrder.FK_QuotationID > 0)
                    {
                        SalesQuotationBOQViewModel quoteBOQ = (new ServiceSalesQuotationBOQ()).GetBOQViewModelForQuotation((int)dbOrder.FK_QuotationID);
                        if (quoteBOQ != null)
                        {
                            int i = 1;
                            foreach (SalesQuotationBOQSheet designSheet in quoteBOQ.SHEETS)
                            {
                                SalesOrderBOQSheet quoteSheet = new SalesOrderBOQSheet();
                                quoteSheet.SheetID = i++;
                                quoteSheet.BOQ_ITEMS = designSheet.BOQ_ITEMS;
                                quoteSheet.BOQ_SERVICES = designSheet.BOQ_SERVICES;
                                quoteSheet.datatableQuotationBOQ = designSheet.datatableQuotationBOQ;
                                quoteSheet.datatableOrderBOQ = GenerateBOQDataTableDefault();
                                quoteSheet.datatableOrderBOQ = UpdateBOQDataTableWithServices(quoteSheet.datatableQuotationBOQ, quoteSheet.BOQ_SERVICES);
                                quoteSheet.SheetName = designSheet.SheetName;
                                quoteSheet.ITEM_CHARGES = new List<BOQItemChargesModel>();
                                quoteSheet.SUMMARY = new SalesOrderBOQSheetSummary();
                                viewModel.SHEETS.Add(quoteSheet);
                            }

                            this.SaveBOQToDatabase(viewModel, (int)dbOrder.FK_BOQRepresentativeID);

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::GenerateDefaultBOQForSalesQuotation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return viewModel;
        }


        public System.Data.DataTable GenerateBOQDataTableDefault()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn() { ColumnName = COL_BOQ_ITEM_TYPE, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_INDEX, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_PARENT_INDEX, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ASSEMBLY_PARENT_INDEX, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_IS_ASSEMBLY, DataType = typeof(bool) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_IS_ASSEMBLY_CHILD, DataType = typeof(bool) });


                dt.Columns.Add(new DataColumn() { ColumnName = COL_SERIAL_NO_SYS, DataType = typeof(decimal) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_SERIAL_NO_BOQ, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_SERIAL_NO_DESIGN, DataType = typeof(decimal) });

                dt.Columns.Add(new DataColumn() { ColumnName = COL_PARENT_ITEM_DB_ID, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_DB_ID, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_CODE, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_HSN_CODE, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_SERIAL_NO_CLIENT, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_DESCRIPTION, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_SEARCH_TEXT, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_UOM_ID, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_UOM_CODE, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_TOTAL_QUANTITY, DataType = typeof(decimal) });

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::GenerateBOQDataTableDefault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public System.Data.DataTable UpdateBOQDataTableWithServices(System.Data.DataTable dt, BindingList<EnquiryBOQService> listServices)
        {
            try
            {
                // INSERT SERVICES COLUMN IN DATATABLE
                int stIndex = dt.Columns[COL_UOM_CODE].Ordinal;

                foreach (EnquiryBOQService item in listServices)
                {
                    if (!dt.Columns.Contains(item.Description))
                    {
                        stIndex++;
                        dt.Columns.Add(new DataColumn() { ColumnName = item.Description, DataType = typeof(decimal), DefaultValue = 0 });
                        dt.Columns[item.Description].SetOrdinal(stIndex);
                    }

                }
                dt.Columns[COL_TOTAL_QUANTITY].SetOrdinal(dt.Columns.Count - 1);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::UpdateBOQDataTableWithServices", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return dt;
        }

        public void UpdateSalesOrderBOQFromSalesQuotationBOQ(SalesOrderBOQViewModel MODEL)
        {
            decimal parentSerial = 0;
            decimal newSerial = 0;
            int parentIndex = 0;

            try
            {
                string strExpr = string.Empty;
                ServiceSalesOrderBOQ SERVICE_ORDER_BOQ = new ServiceSalesOrderBOQ();
                foreach (SalesOrderBOQSheet sheet in MODEL.SHEETS)
                {
                    int IndexNo = 1;
                    sheet.datatableQuotationBOQ.Rows.Clear();
                    sheet.ITEM_CHARGES = new List<BOQItemChargesModel>();
                    //INSERT ALL PARENT ITEMS FROM DESIGN INTO QUOTATION BOQ
                    strExpr = string.Format("[{0}]=0", SERVICE_ORDER_BOQ.COL_PARENT_ITEM_DB_ID);
                    DataRow[] result = sheet.datatableQuotationBOQ.Select(strExpr);
                    if (result.Count() > 0)
                    {
                        foreach (DataRow designRow in result)
                        {
                            #region add a new row into BOQ datatable 
                            DataRow newRow = sheet.datatableQuotationBOQ.NewRow();
                            newRow[COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.PARENT_ITEM;
                            newRow[COL_ITEM_INDEX] = sheet.datatableQuotationBOQ.Rows.Count + 1;
                            newRow[COL_SERIAL_NO_SYS] = decimal.Parse(IndexNo.ToString());
                            newRow[COL_SERIAL_NO_DESIGN] = designRow[SERVICE_ORDER_BOQ.COL_SERIAL_NO_SYS];
                            newRow[COL_ITEM_DESCRIPTION] = designRow[SERVICE_ORDER_BOQ.COL_ITEM_DESCRIPTION];
                            newRow[COL_SEARCH_TEXT] = designRow[SERVICE_ORDER_BOQ.COL_ITEM_DESCRIPTION];
                            newRow[COL_PARENT_INDEX] = 0;
                            newRow[COL_ASSEMBLY_PARENT_INDEX] = 0;
                            newRow[COL_IS_ASSEMBLY] = false;
                            newRow[COL_IS_ASSEMBLY_CHILD] = false;
                            newRow[COL_PARENT_ITEM_DB_ID] = designRow[SERVICE_ORDER_BOQ.COL_PARENT_ITEM_DB_ID];
                            newRow[COL_ITEM_DB_ID] = designRow[SERVICE_ORDER_BOQ.COL_ITEM_DB_ID];
                            newRow[COL_UOM_ID] = designRow[SERVICE_ORDER_BOQ.COL_UOM_ID];
                            newRow[COL_UOM_CODE] = designRow[SERVICE_ORDER_BOQ.COL_UOM_CODE];
                            newRow[COL_TOTAL_QUANTITY] = designRow[SERVICE_ORDER_BOQ.COL_TOTAL_QUANTITY];
                            newRow[COL_ITEM_CODE] = designRow[SERVICE_ORDER_BOQ.COL_ITEM_CODE];
                            newRow[COL_ITEM_HSN_CODE] = "";
                            newRow[COL_SERIAL_NO_CLIENT] = "";
                            //SET SERVICS COLUMNS QTY VALUE TO 0
                            foreach (EnquiryBOQService selService in sheet.BOQ_SERVICES)
                            {
                                newRow[selService.Description] = designRow[selService.Description];
                            }
                            // ADD CHARGE INFO OBJECT FOR STORING VARIOUS CHARGES APPLIED ON ITEM
                            BOQItemChargesModel chargesOnItem = new BOQItemChargesModel();
                            chargesOnItem.Index = int.Parse(newRow[COL_ITEM_INDEX].ToString());
                            chargesOnItem.TotalQuantity = decimal.Parse(newRow[COL_TOTAL_QUANTITY].ToString());
                            sheet.ITEM_CHARGES.Add(chargesOnItem);
                            sheet.datatableQuotationBOQ.Rows.Add(newRow);
                            #endregion
                            #region ADD CHILDRENS..IF ASSEMBLY ITEM
                            bool isAssembly = bool.Parse(designRow[SERVICE_ORDER_BOQ.COL_IS_ASSEMBLY].ToString());
                            if (isAssembly)
                            {
                                newRow[COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.PARENT_ITEM;
                                newRow[COL_IS_ASSEMBLY] = true;
                                parentSerial = decimal.Parse(newRow[COL_SERIAL_NO_SYS].ToString());
                                parentIndex = int.Parse(newRow[COL_ITEM_INDEX].ToString());
                                // GET ALL CHILDREN OF ASSEMBLY ITME FROM DESIGN BOQ DATATABLE
                                strExpr = string.Format("[{0}]={1}", SERVICE_ORDER_BOQ.COL_PARENT_ITEM_DB_ID, newRow[COL_ITEM_DB_ID]);
                                DataRow[] childRows = sheet.datatableQuotationBOQ.Select(strExpr);
                                int subIndex = 1;
                                if (childRows.Count() > 0)
                                {
                                    foreach (DataRow childRow in childRows)
                                    {
                                        #region add a new row into BOQ datatable 
                                        newSerial = decimal.Parse(string.Format("{0}.{1}", parentSerial, subIndex.ToString().PadLeft(2, '0')));

                                        newRow = sheet.datatableQuotationBOQ.NewRow();
                                        newRow[COL_BOQ_ITEM_TYPE] = (int)BOQ_ITEM_TYPE.CHILD_ITEM;
                                        newRow[COL_SEARCH_TEXT] = childRow[SERVICE_ORDER_BOQ.COL_ITEM_DESCRIPTION];
                                        newRow[COL_ITEM_INDEX] = sheet.datatableQuotationBOQ.Rows.Count + 1;
                                        newRow[COL_SERIAL_NO_SYS] = newSerial;
                                        newRow[COL_SERIAL_NO_DESIGN] = childRow[SERVICE_ORDER_BOQ.COL_SERIAL_NO_SYS];
                                        newRow[COL_ITEM_DESCRIPTION] = childRow[SERVICE_ORDER_BOQ.COL_ITEM_DESCRIPTION];
                                        newRow[COL_PARENT_INDEX] = parentIndex;
                                        newRow[COL_ASSEMBLY_PARENT_INDEX] = parentIndex;
                                        newRow[COL_IS_ASSEMBLY] = false;
                                        newRow[COL_IS_ASSEMBLY_CHILD] = true;
                                        newRow[COL_PARENT_ITEM_DB_ID] = childRow[SERVICE_ORDER_BOQ.COL_PARENT_ITEM_DB_ID];
                                        newRow[COL_ITEM_DB_ID] = childRow[SERVICE_ORDER_BOQ.COL_ITEM_DB_ID];
                                        newRow[COL_UOM_ID] = childRow[SERVICE_ORDER_BOQ.COL_UOM_ID];
                                        newRow[COL_UOM_CODE] = childRow[SERVICE_ORDER_BOQ.COL_UOM_CODE];
                                        newRow[COL_TOTAL_QUANTITY] = childRow[SERVICE_ORDER_BOQ.COL_TOTAL_QUANTITY];
                                        newRow[COL_ITEM_CODE] = childRow[SERVICE_ORDER_BOQ.COL_ITEM_CODE]; ;
                                        newRow[COL_ITEM_HSN_CODE] = "";
                                        newRow[COL_SERIAL_NO_CLIENT] = "";
                                        //SET SERVICS COLUMNS QTY VALUE TO 0
                                        foreach (EnquiryBOQService selService in sheet.BOQ_SERVICES)
                                        {
                                            newRow[selService.Description] = childRow[selService.Description];
                                        }
                                        // ADD CHARGE INFO OBJECT FOR STORING VARIOUS CHARGES APPLIED ON ITEM
                                        chargesOnItem = new BOQItemChargesModel();
                                        chargesOnItem.Index = int.Parse(newRow[COL_ITEM_INDEX].ToString());
                                        chargesOnItem.TotalQuantity = decimal.Parse(newRow[COL_TOTAL_QUANTITY].ToString());
                                        sheet.ITEM_CHARGES.Add(chargesOnItem);
                                        sheet.datatableQuotationBOQ.Rows.Add(newRow);
                                        #endregion
                                        subIndex++;
                                    }
                                }
                            }

                            #endregion

                            IndexNo++;
                        }
                    }
                    sheet.SUMMARY = new SalesOrderBOQSheetSummary() { SheetName = sheet.SheetName };
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::UpdateSalesQuotationBOQFromSalesEnquiryBOQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public System.Data.DataTable GenerateSelectChildItemDatatable(SalesOrderBOQSheet BOQ_SHEET_MODEL)
        {
            DataTable dtSelectChildItems = new DataTable();
            try
            {
                ServiceSalesQuotationBOQ serviceQUOTE_BOQ = new ServiceSalesQuotationBOQ();
                //CREATE COLUMNS IN NEW DATABASE
                dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = "Selected", DataType = typeof(bool) });
                foreach (DataColumn col in BOQ_SHEET_MODEL.datatableQuotationBOQ.Columns)
                {
                    EnquiryBOQService selService = BOQ_SHEET_MODEL.BOQ_SERVICES.Where(X => X.Description == col.ColumnName).FirstOrDefault();
                    if (selService == null)
                    {
                        if (col.ColumnName == serviceQUOTE_BOQ.COL_TOTAL_QUANTITY)
                        {
                            dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = typeof(string) });
                        }
                        else
                            dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = col.DataType });

                    }
                    else
                        dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = typeof(string) });
                }
                string strEXPR = string.Format("[{0}]=0", serviceQUOTE_BOQ.COL_PARENT_ITEM_DB_ID);
                foreach (DataRow rd in BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strEXPR))
                {
                    string strItemDescription = string.Empty;
                    int mItemDBID = int.Parse(rd[serviceQUOTE_BOQ.COL_ITEM_DB_ID].ToString());
                    TBL_MP_Master_Item dbItem = (new ServiceInventoryItems()).GetItemDBRecord(mItemDBID);
                    if (dbItem != null)
                    {
                        strItemDescription = string.Format("{0}\n{1}\nCode:{2} HSN:{3}", dbItem.Item_Name, dbItem.Long_Description, dbItem.ItemCode, dbItem.HSNCode);
                    }
                    DataRow dtrow = dtSelectChildItems.NewRow();
                    dtrow["Selected"] = false;
                    //dtrow[serviceQUOTE_BOQ.COL_DEFAULT] = rd[serviceQUOTE_BOQ.COL_DEFAULT_QTY];
                    dtrow[serviceQUOTE_BOQ.COL_SERIAL_NO_SYS] = rd[serviceQUOTE_BOQ.COL_SERIAL_NO_SYS];
                    dtrow[serviceQUOTE_BOQ.COL_PARENT_ITEM_DB_ID] = rd[serviceQUOTE_BOQ.COL_PARENT_ITEM_DB_ID];
                    //dtrow[serviceQUOTE_BOQ.COL_HAS_SERVICES] = rd[serviceQUOTE_BOQ.COL_HAS_SERVICES];
                    dtrow[serviceQUOTE_BOQ.COL_UOM_ID] = rd[serviceQUOTE_BOQ.COL_UOM_ID];
                    dtrow[serviceQUOTE_BOQ.COL_UOM_CODE] = rd[serviceQUOTE_BOQ.COL_UOM_CODE];
                    dtrow[serviceQUOTE_BOQ.COL_ITEM_DB_ID] = rd[serviceQUOTE_BOQ.COL_ITEM_DB_ID];
                    dtrow[serviceQUOTE_BOQ.COL_ITEM_CODE] = rd[serviceQUOTE_BOQ.COL_ITEM_CODE];
                    dtrow[serviceQUOTE_BOQ.COL_ITEM_DESCRIPTION] = strItemDescription;
                    dtrow[serviceQUOTE_BOQ.COL_IS_ASSEMBLY] = rd[serviceQUOTE_BOQ.COL_IS_ASSEMBLY];

                    //FIND TOTAL QUANITITY CONSUMED
                    string strExpr = string.Format("Sum({0})", COL_TOTAL_QUANTITY);
                    string strFilter = string.Format("[{0}]='{1}'", COL_SERIAL_NO_DESIGN, rd[serviceQUOTE_BOQ.COL_SERIAL_NO_SYS]);
                    var tot_qty = BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(strExpr, strFilter);
                    dtrow[serviceQUOTE_BOQ.COL_TOTAL_QUANTITY] = string.Format("{0}/{1}", tot_qty, rd[serviceQUOTE_BOQ.COL_TOTAL_QUANTITY].ToString());


                    foreach (EnquiryBOQService selService in BOQ_SHEET_MODEL.BOQ_SERVICES)
                    {
                        strExpr = string.Format("Sum([{0}])", selService.Description);
                        tot_qty = BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(strExpr, strFilter);
                        dtrow[selService.Description] = string.Format("{0}/{1}", tot_qty, rd[selService.Description].ToString());
                    }

                    dtSelectChildItems.Rows.Add(dtrow);

                    //lbl_TotaAmt.Text = MyDataTable.Compute("Sum(BalAmt)", "srno=1 or srno in(1,2)").ToString
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesQuotationBOQ::GenrateSelectChildItemDatatable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtSelectChildItems;
        }
        public System.Data.DataTable GenerateSelectedItemQuantitySummaryDatatable(int selectedItemIndex, SalesQuotationBOQSheet BOQ_SHEET_MODEL)
        {
            DataTable dtSelectChildItems = new DataTable();
            int itemDBID = 0;
            int itemParentDBID = 0;
            try
            {
                ServiceSalesEnquiryBOQ _serviceDesignBOQ = new ServiceSalesEnquiryBOQ();
                //get selected item from datatable
                string strExpr = string.Format("[{0}]={1}", COL_ITEM_INDEX, selectedItemIndex);
                DataRow[] selItemRows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                if (selItemRows.Count() > 0)
                {
                    DataRow itemRow = selItemRows[0];
                    itemDBID = int.Parse(itemRow[COL_ITEM_DB_ID].ToString());
                    itemParentDBID = int.Parse(itemRow[COL_PARENT_ITEM_DB_ID].ToString());
                }

                //CREATE COLUMNS IN NEW DATABASE
                dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = "Selected", DataType = typeof(bool) });
                foreach (DataColumn col in BOQ_SHEET_MODEL.datatableEnquiryBOQ.Columns)
                {
                    EnquiryBOQService selService = BOQ_SHEET_MODEL.BOQ_SERVICES.Where(X => X.Description == col.ColumnName).FirstOrDefault();
                    if (selService == null)
                    {
                        if (col.ColumnName == "TotalQty")
                        {
                            dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = typeof(string) });
                        }
                        else
                            dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = col.DataType });

                    }
                    else
                        dtSelectChildItems.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = typeof(string) });
                }
                // FETCH ROW FROM ENQUIRY BOQ
                strExpr = string.Format("[{0}]={1} AND [{2}]={3}", _serviceDesignBOQ.COL_PARENT_ITEM_ID, itemParentDBID, _serviceDesignBOQ.COL_ITEM_ID, itemDBID);
                DataRow[] designRows = BOQ_SHEET_MODEL.datatableEnquiryBOQ.Select(strExpr);
                if (designRows.Count() > 0)
                {
                    DataRow rd = designRows[0];
                    string strItemDescription = string.Empty;
                    int mItemDBID = int.Parse(rd["ItemID"].ToString());
                    TBL_MP_Master_Item dbItem = (new ServiceInventoryItems()).GetItemDBRecord(mItemDBID);
                    if (dbItem != null)
                    {
                        strItemDescription = string.Format("{0}\n{1}\nCode:{2} HSN:{3}", dbItem.Item_Name, dbItem.Long_Description, dbItem.ItemCode, dbItem.HSNCode);
                    }
                    DataRow dtrow = dtSelectChildItems.NewRow();
                    dtrow["Selected"] = false;
                    dtrow["DefaultQty"] = rd["DefaultQty"];
                    dtrow["Key"] = rd["Key"];
                    dtrow["ParentItemID"] = rd["ParentItemID"];
                    dtrow["HasServices"] = rd["HasServices"];
                    dtrow["UOMID"] = rd["UOMID"];
                    dtrow["UOMName"] = rd["UOMName"];
                    dtrow["ItemID"] = rd["ItemID"];
                    dtrow["ItemCode"] = rd["ItemCode"];
                    dtrow["ItemDescription"] = strItemDescription;
                    dtrow["IsAssembly"] = rd["IsAssembly"];

                    // FIND TOTAL QUANITITY CONSUMED
                    strExpr = string.Format("Sum({0})", COL_TOTAL_QUANTITY);
                    string strFilter = string.Format("[{0}]={1} AND [{2}]={3}", COL_PARENT_ITEM_DB_ID, itemParentDBID, COL_ITEM_DB_ID, mItemDBID);
                    var tot_qty = BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(strExpr, strFilter);
                    dtrow["TotalQty"] = string.Format("{0}/{1}", tot_qty, rd["TotalQty"].ToString());


                    foreach (EnquiryBOQService selService in BOQ_SHEET_MODEL.BOQ_SERVICES)
                    {
                        strExpr = string.Format("Sum([{0}])", selService.Description);
                        strFilter = string.Format("[{0}]={1} AND [{2}]={3}", COL_PARENT_ITEM_DB_ID, itemParentDBID, COL_ITEM_DB_ID, mItemDBID);
                        tot_qty = BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(strExpr, strFilter);
                        dtrow[selService.Description] = string.Format("{0}/{1}", tot_qty, rd[selService.Description].ToString());
                    }

                    dtSelectChildItems.Rows.Add(dtrow);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesQuotationBOQ::GenrateSelectChildItemDatatable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtSelectChildItems;
        }

        public System.Data.DataTable GenrateDesignBOQDatatableSummary(System.Data.DataTable dtSourceBOQ)
        {
            DataTable tblSummary = new DataTable();
            try
            {

                foreach (DataColumn col in dtSourceBOQ.Columns)
                {
                    tblSummary.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = col.DataType });
                }
                DataRow dr = tblSummary.NewRow();
                dr["ItemDescription"] = string.Format("Summary/Total: ({0}) items", dtSourceBOQ.Rows.Count);
                foreach (DataColumn col in dtSourceBOQ.Columns)
                {
                    if (col.DataType == typeof(int))
                    {
                        if (col.ColumnName != "ItemID" && col.ColumnName != "UOMID")
                        {
                            string strExpression = string.Format("SUM({0})", col.ColumnName);
                            string strFilter = string.Format(" {0} Is Not Null", col.ColumnName);
                            if (dtSourceBOQ.Compute(strExpression, strFilter) != DBNull.Value)
                            {
                                int sum = Convert.ToInt32(dtSourceBOQ.Compute(strExpression, strFilter));
                                dr[col.ColumnName] = sum;
                            }

                        }
                    }
                }

                tblSummary.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceDesignBOQ::GenrateDesignBOQDatatableSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return tblSummary;
        }

        public System.Data.DataTable UpdateRowTotalQuantity(System.Data.DataTable dtSourceBOQ, BindingList<MultiSelectListItem> services)
        {
            try
            {
                //UPDATE TOTAL QUANTITY FIELD FOR EACHROW IN DATATABLE
                foreach (DataRow row in dtSourceBOQ.Rows)
                {
                    int totQty = 0;
                    foreach (DataColumn col in dtSourceBOQ.Columns)
                    {
                        MultiSelectListItem selService = services.Where(x => x.Description == col.ColumnName).FirstOrDefault();
                        if (selService != null)
                        {
                            if (row.ItemArray[col.Ordinal] != DBNull.Value)
                                totQty += int.Parse(row[col.ColumnName].ToString());
                        }
                    }
                    if (totQty == 0)
                    {
                        row["HasServices"] = false;
                    }
                    else
                    {
                        row["HasServices"] = true;
                        row["TotalQty"] = totQty;
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceDesignBOQ::UpdateRowTotalQuantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtSourceBOQ;
        }

        public SalesOrderBOQViewModel SaveBOQToDatabase(SalesOrderBOQViewModel MODEL, int empID)
        {
            try
            {
                if (MODEL.BOQ_ID == 0)
                {
                    TBL_MP_CRM_SalesOrder_BOQ newBOQ = new TBL_MP_CRM_SalesOrder_BOQ();
                    newBOQ.ORDER_ID = MODEL.ORDER_ID;
                    newBOQ.BOQ_CREATED_BY = empID;
                    newBOQ.BOQ_CREATED_DATETIME = AppCommon.GetServerDateTime();
                    newBOQ.BOQ_NUMBER = this.GenerateBOQNumber(MODEL.ORDER_ID);
                    _dbContext.TBL_MP_CRM_SalesOrder_BOQ.Add(newBOQ);
                    _dbContext.SaveChanges();
                    MODEL.BOQ_ID = newBOQ.ORDER_BOQ_ID;
                }
                // REMOVE ITEMCHARGES INFO FROM THE BOQ_MODEL AND SAVE IT TO THE DATABASE
                if (UpdateSalesOrderItemChargesInDB(MODEL))
                {
                    foreach (SalesOrderBOQSheet sheet in MODEL.SHEETS)
                    {
                        sheet.ITEM_CHARGES = new List<BOQItemChargesModel>();
                        sheet.BOQ_ITEMS = new BindingList<EnquiryBOQItem>();
                    }
                    string output = JsonConvert.SerializeObject(MODEL);
                    TBL_MP_CRM_SalesOrder_BOQ dbBOQ = _dbContext.TBL_MP_CRM_SalesOrder_BOQ.Where(x => x.ORDER_BOQ_ID == MODEL.BOQ_ID).FirstOrDefault();
                    dbBOQ.BOQ_OBJECT = output;
                    _dbContext.SaveChanges();
                }
                // UPDATE BOQ SUMMARY AND QUOTATION MASTER TABLE WITH SUMMARY DATA
                UpdateSalesOrderBOQSummary(MODEL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesOrderBOQ::SaveBOQToDatabase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return MODEL;

        }
        public bool UpdateSalesOrderItemChargesInDB(SalesOrderBOQViewModel MODEL)
        {
            bool result = false;
            int orderID = 0;
            string sheetName = string.Empty;
            int itemIndexID = 0;
            int itemDBID = 0;
            try
            {
                TBL_MP_CRM_SalesOrder dbOrder = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == MODEL.ORDER_ID).FirstOrDefault();
                orderID = MODEL.ORDER_ID;
                foreach (SalesOrderBOQSheet sheet in MODEL.SHEETS)
                {
                    sheetName = sheet.SheetName;
                    foreach (BOQItemChargesModel itemCharges in sheet.ITEM_CHARGES)
                    {
                        itemIndexID = itemCharges.Index;
                        // GET ITEM DB ID FROM THE DATATABLE
                        itemDBID = 0;
                        string filter = string.Format("[{0}]={1}", COL_ITEM_INDEX, itemIndexID);
                        DataRow[] selRows = sheet.datatableOrderBOQ.Select(filter);
                        if (selRows.Count() > 0) itemDBID = int.Parse(selRows[0][COL_ITEM_DB_ID].ToString());


                        TBL_MP_CRM_SalesOrder_ItemCharges dbItem = (from xx in _dbContext.TBL_MP_CRM_SalesOrder_ItemCharges
                                                                        where xx.FK_OrderID == orderID && xx.SheetName == sheetName && xx.Item_IndexID == itemIndexID
                                                                        select xx).FirstOrDefault();

                        if (dbItem == null)
                        {
                            dbItem = new TBL_MP_CRM_SalesOrder_ItemCharges(); // CREATE OBJECT IF NOT EXISTING 
                        }

                        GatherItemChargesInfoInDbRecordFromModel(dbItem, itemCharges); // POPULATE OBJECT WITH CHARGES INFO
                        if (dbItem.PK_ItemChargesID == 0)
                        {
                            // ADD OTHER INFO TO THE OBJECT
                            dbItem.FK_OrderID = orderID;
                            dbItem.OrderDate = dbOrder.SalesOrderDate;
                            dbItem.FK_PartyID = dbOrder.FK_ClientID;
                            dbItem.FK_ORDER_BOQID = MODEL.BOQ_ID;
                            if (itemDBID > 0) dbItem.FK_ItemID = itemDBID;
                            dbItem.SheetName = sheetName;
                            // INSERT THE OBJECT IF NOT FOUND IN DATABASE
                            _dbContext.TBL_MP_CRM_SalesOrder_ItemCharges.Add(dbItem);
                        }
                        // INSERT OR UPDATE 
                        _dbContext.SaveChanges();
                    }
                }
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrderBOQ::UpdateSalesQuotationItemCharges", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public List<BOQItemChargesModel> GetItemChargesCollectionForBOQSheet(int QUOTATION_ID, int BOQ_ID, string SheetName)
        {
            List<BOQItemChargesModel> lst = new List<BOQItemChargesModel>();
            try
            {
                List<TBL_MP_CRM_SalesQuotation_ItemCharges> lstDB = (from xx in _dbContext.TBL_MP_CRM_SalesQuotation_ItemCharges
                                                                     where xx.FK_QuotationID == QUOTATION_ID && xx.SheetName == SheetName && xx.FK_QuoteBOQID == BOQ_ID
                                                                     select xx).ToList();
                foreach (TBL_MP_CRM_SalesQuotation_ItemCharges item in lstDB)
                {
                    BOQItemChargesModel model = new BOQItemChargesModel();
                    model.Index = item.Item_IndexID;
                    model.TotalQuantity = item.Item_Quantity;
                    #region MATERIAL SUPPLY CHARGES
                    model.MaterialBasicPrice = item.MaterialBasicPrice;
                    model.MaterialAddOnCharges.ItemChargeType = (ITEM_CHARGE_TYPE)item.MaterialAddOnChargesType;
                    model.MaterialAddOnCharges.ItemChargeValue = item.MaterialAddOnChargesValue;
                    model.MaterialAddOnChargesAmount = item.MaterialAddOnChargesAmount;
                    model.MaterialProfitMargin.ItemChargeType = (ITEM_CHARGE_TYPE)item.MaterialProfitMarginType;
                    model.MaterialProfitMargin.ItemChargeValue = item.MaterialProfitMarginValue;
                    model.MaterialProfitMarginAmount = item.MaterialProfitMarginAmount;
                    model.MaterialSellingCost = item.MaterialSellingCost;
                    model.MaterialDiscount.ItemChargeType = (ITEM_CHARGE_TYPE)item.MaterialDiscountType;
                    model.MaterialDiscount.ItemChargeValue = item.MaterialDiscountValue;
                    model.MaterialDiscountAmount = item.MaterialDiscountAmount;
                    model.MaterialGST.SGST_PERCENT = item.Material_SGST_Percent;
                    model.MaterialGST.SGST_AMOUNT = item.Material_SGST_Amount;
                    model.MaterialGST.CGST_PERCENT = item.Material_CGST_Percent;
                    model.MaterialGST.CGST_AMOUNT = item.Material_CGST_Amount;
                    model.MaterialGST.IGST_PERCENT = item.Material_IGST_Percent;
                    model.MaterialGST.IGST_AMOUNT = item.Material_IGST_Amount;
                    model.MaterialNetRate = item.MaterialNetRate;
                    model.MaterialSupplyAmount = item.MaterialSupplyAmount;
                    #endregion
                    #region INSTALLATION AND SERVICES CHARGES
                    model.InstallationRate.ItemChargeType = (ITEM_CHARGE_TYPE)item.InstallationRateType;
                    model.InstallationRate.ItemChargeValue = item.InstallationRateValue;
                    model.InstallationRateAmount = item.InstallationRateAmount;
                    model.InstallationAddOnCharges.ItemChargeType = (ITEM_CHARGE_TYPE)item.InstallationAddOnChargesType;
                    model.InstallationAddOnCharges.ItemChargeValue = item.InstallationAddOnChargesValue;
                    model.InstallationAddOnChargesAmount = item.InstallationAddOnChargesAmount;
                    model.InstallationProfitMargin.ItemChargeType = (ITEM_CHARGE_TYPE)item.InstallationProfitMarginType;
                    model.InstallationProfitMargin.ItemChargeValue = item.InstallationProfitMarginValue;
                    model.InstallationProfitMarginAmount = item.InstallationProfitMarginAmount;
                    model.InstallationSellingCost = item.InstallationSellingCost;
                    model.InstallationDiscount.ItemChargeType = (ITEM_CHARGE_TYPE)item.InstallationDiscountType;
                    model.InstallationDiscount.ItemChargeValue = item.InstallationDiscountValue;
                    model.InstallationDiscountAmount = item.InstallationDiscountAmount;
                    model.InstallationGST.SGST_PERCENT = item.Installation_SGST_Percent;
                    model.InstallationGST.SGST_AMOUNT = item.Installatiion_SGST_Amount;
                    model.InstallationGST.CGST_PERCENT = item.Installation_CGST_Percent;
                    model.InstallationGST.CGST_AMOUNT = item.Installation_CGST_Amount;
                    model.InstallationGST.IGST_PERCENT = item.Installation_IGST_Percent;
                    model.InstallationGST.IGST_AMOUNT = item.Installation_IGST_Amount;
                    model.InstallationNetRate = item.InstallationNetRate;
                    model.InstallationAmount = item.InstallationAmount;
                    #endregion
                    lst.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::GetItemChargesCollectionForBOQSheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }

        private void GatherItemChargesInfoInDbRecordFromModel(TBL_MP_CRM_SalesOrder_ItemCharges dbItem, BOQItemChargesModel itemCharges)
        {
            try
            {
                dbItem.Item_Quantity = itemCharges.TotalQuantity;
                dbItem.Item_IndexID = itemCharges.Index;
                dbItem.MaterialBasicPrice = itemCharges.MaterialBasicPrice;
                dbItem.MaterialAddOnChargesType = (int)itemCharges.MaterialAddOnCharges.ItemChargeType;
                dbItem.MaterialAddOnChargesValue = itemCharges.MaterialAddOnCharges.ItemChargeValue;
                dbItem.MaterialAddOnChargesAmount = itemCharges.MaterialAddOnChargesAmount;
                dbItem.MaterialProfitMarginType = (int)itemCharges.MaterialProfitMargin.ItemChargeType;
                dbItem.MaterialProfitMarginValue = itemCharges.MaterialProfitMargin.ItemChargeValue;
                dbItem.MaterialProfitMarginAmount = itemCharges.MaterialProfitMarginAmount;
                dbItem.MaterialSellingCost = itemCharges.MaterialSellingCost;
                dbItem.MaterialDiscountType = (int)itemCharges.MaterialDiscount.ItemChargeType;
                dbItem.MaterialDiscountValue = itemCharges.MaterialDiscount.ItemChargeValue;
                dbItem.MaterialDiscountAmount = itemCharges.MaterialDiscountAmount;
                dbItem.Material_SGST_Percent = itemCharges.MaterialGST.SGST_PERCENT;
                dbItem.Material_SGST_Amount = itemCharges.MaterialGST.SGST_AMOUNT;
                dbItem.Material_CGST_Percent = itemCharges.MaterialGST.CGST_PERCENT;
                dbItem.Material_CGST_Amount = itemCharges.MaterialGST.CGST_AMOUNT;
                dbItem.Material_IGST_Percent = itemCharges.MaterialGST.IGST_PERCENT;
                dbItem.Material_IGST_Amount = itemCharges.MaterialGST.IGST_AMOUNT;
                dbItem.Material_GST_Amount = itemCharges.MaterialGST.GST_TOTAL_AMOUNT;
                dbItem.MaterialNetRate = itemCharges.MaterialNetRate;
                dbItem.MaterialSupplyAmount = itemCharges.MaterialSupplyAmount;
                dbItem.InstallationRateType = (int)itemCharges.InstallationRate.ItemChargeType;
                dbItem.InstallationRateValue = itemCharges.InstallationRate.ItemChargeValue;
                dbItem.InstallationRateAmount = itemCharges.InstallationRateAmount;
                dbItem.InstallationAddOnChargesType = (int)itemCharges.InstallationAddOnCharges.ItemChargeType;
                dbItem.InstallationAddOnChargesValue = itemCharges.InstallationAddOnCharges.ItemChargeValue;
                dbItem.InstallationAddOnChargesAmount = itemCharges.MaterialAddOnChargesAmount;
                dbItem.InstallationProfitMarginType = (int)itemCharges.InstallationProfitMargin.ItemChargeType;
                dbItem.InstallationProfitMarginValue = itemCharges.InstallationProfitMargin.ItemChargeValue;
                dbItem.InstallationProfitMarginAmount = itemCharges.InstallationProfitMarginAmount;
                dbItem.InstallationSellingCost = itemCharges.InstallationSellingCost;
                dbItem.InstallationDiscountType = (int)itemCharges.InstallationDiscount.ItemChargeType;
                dbItem.InstallationDiscountValue = itemCharges.InstallationDiscount.ItemChargeValue;
                dbItem.InstallationDiscountAmount = itemCharges.InstallationDiscountAmount;
                dbItem.Installation_SGST_Percent = itemCharges.InstallationGST.SGST_PERCENT;
                dbItem.Installatiion_SGST_Amount = itemCharges.InstallationGST.SGST_AMOUNT;
                dbItem.Installation_CGST_Percent = itemCharges.InstallationGST.CGST_PERCENT;
                dbItem.Installation_CGST_Amount = itemCharges.InstallationGST.CGST_AMOUNT;
                dbItem.Installation_IGST_Percent = itemCharges.InstallationGST.IGST_PERCENT;
                dbItem.Installation_IGST_Amount = itemCharges.InstallationGST.IGST_AMOUNT;
                dbItem.Installation_GST_Amount = itemCharges.InstallationGST.GST_TOTAL_AMOUNT;
                dbItem.InstallationNetRate = itemCharges.InstallationNetRate;
                dbItem.InstallationAmount = itemCharges.InstallationAmount;

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::GatherItemChargesInfoInDbRecordFromModel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public string GenerateBOQNumber(int salesQuotationID)
        {
            string strNumber = string.Empty;

            TBL_MP_CRM_SalesQuotation enquiry = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(salesQuotationID);
            if (enquiry != null)
            {
                strNumber = enquiry.Quotation_No;
            }
            int cnt = _dbContext.TBL_MP_CRM_SalesQuotation_BOQ.Where(x => x.QUOTE_ID == salesQuotationID).Count();
            strNumber = string.Format("{0}-BOQ({1})", strNumber, (++cnt).ToString().PadLeft(3, '0'));
            return strNumber;
        }

        public SalesEnquiryDesignBOQViewModel GetDesignBOQModel(int boqID)
        {
            SalesEnquiryDesignBOQViewModel model = new SalesEnquiryDesignBOQViewModel();
            try
            {
                TBL_MP_CRM_SalesEnquiry_BOQ dbModel = _dbContext.TBL_MP_CRM_SalesEnquiry_BOQ.Where(x => x.DESIGN_BOQ_ID == boqID).FirstOrDefault();
                if (dbModel != null)
                {
                    string json = dbModel.BOQ_DESIGN_OBJECT;
                    model = JsonConvert.DeserializeObject<SalesEnquiryDesignBOQViewModel>(json);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceDesignBOQ::GetDesignBOQModel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public SalesEnquiryDesignBOQViewModel GetDesignBOQModelForSalesEnquiry(int enquiryID)
        {
            SalesEnquiryDesignBOQViewModel model = new SalesEnquiryDesignBOQViewModel();
            try
            {
                TBL_MP_CRM_SalesEnquiry_BOQ dbModel =
                    (from xx in _dbContext.TBL_MP_CRM_SalesEnquiry_BOQ where xx.ENQUIRY_ID == enquiryID select xx).FirstOrDefault();
                if (dbModel != null)
                {
                    string json = dbModel.BOQ_DESIGN_OBJECT;
                    model = JsonConvert.DeserializeObject<SalesEnquiryDesignBOQViewModel>(json);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceDesignBOQ::GetDesignBOQModel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public List<SelectListItem> GetSalesQuotationChargesApplicableTypesSelectListItems()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                items.Add(new SelectListItem() { ID = (int)SALES_QUOTATION_BOQ_CHARGES_TYPE.NONE, Description = "(NONE)" });
                items.Add(new SelectListItem() { ID = (int)SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_ENTIRE_BOQ, Description = "ON ENTIRE BOQ" });
                items.Add(new SelectListItem() { ID = (int)SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_ENTIRE_SHEET, Description = "ON ENTIRE SHEET" });
                items.Add(new SelectListItem() { ID = (int)SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_PARENT_ITEMS, Description = "ON PARENT ITEMS" });
                items.Add(new SelectListItem() { ID = (int)SALES_QUOTATION_BOQ_CHARGES_TYPE.ON_CHILD_ITEMS, Description = "ON CHILD ITEMS" });
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::GetSalesQuotationChargesApplicableTypesSelectListItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return items;
        }

        public void UpdateParentItemTotalForSheet(SalesOrderBOQSheet BOQ_SHEET_MODEL, int itemIndex)
        {
            bool processedAssemblyChildren = false;
            decimal totalChildCost = 0;
            decimal totalChildInstallationAmount = 0;
            int parentItemIndex = 0;
            try
            {
                if (BOQ_SHEET_MODEL.datatableQuotationBOQ == null) return;
                if (BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Count == 0) return;
                // UPDATE CHARGES ON ALL CHILDRENS WHICH ARE ASEMBLY ITEMS 
                string strExpr = string.Format("[{0}]<>0 AND [{1}]=TRUE", COL_PARENT_INDEX, COL_IS_ASSEMBLY);
                DataRow[] parentAssemblies = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                if (parentAssemblies.Count() > 0)
                {
                    foreach (DataRow assemblyRow in parentAssemblies)
                    {
                        parentItemIndex = int.Parse(assemblyRow[COL_ITEM_INDEX].ToString());
                        strExpr = string.Format("[{0}]={1}", COL_ASSEMBLY_PARENT_INDEX, parentItemIndex);
                        DataRow[] childItems = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                        totalChildCost = 0;
                        totalChildInstallationAmount = 0;
                        foreach (DataRow childRow in childItems)
                        {
                            BOQItemChargesModel model = BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == int.Parse(childRow[COL_ITEM_INDEX].ToString())).FirstOrDefault();
                            if (model != null)
                            {
                                totalChildCost += model.MaterialSupplyAmount;
                                totalChildInstallationAmount += model.InstallationAmount;
                            }
                        }
                        BOQItemChargesModel assemblyCharges = BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == parentItemIndex).FirstOrDefault();
                        if (assemblyCharges != null)
                        {
                            assemblyCharges.MaterialBasicPrice = totalChildCost / assemblyCharges.TotalQuantity;
                            if (totalChildInstallationAmount != 0)
                            {
                                assemblyCharges.InstallationRate.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                                assemblyCharges.InstallationRate.ItemChargeValue = totalChildInstallationAmount / assemblyCharges.TotalQuantity; ;
                            }
                            CalculateChargesOnBOQItem(assemblyCharges);
                        }
                    }
                    processedAssemblyChildren = true;
                }
                // GET ALL PARENT ITEMS IN QUOTATION BOQ
                strExpr = string.Format("[{0}]={1}", COL_BOQ_ITEM_TYPE, (int)BOQ_ITEM_TYPE.PARENT_ITEM);
                DataRow[] parentItems = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                foreach (DataRow parentRow in parentItems)
                {
                    parentItemIndex = int.Parse(parentRow[COL_ITEM_INDEX].ToString());
                    strExpr = string.Format("[{0}]={1}", COL_PARENT_INDEX, parentItemIndex);
                    if (processedAssemblyChildren) strExpr += string.Format(" AND [{0}]=0", COL_ASSEMBLY_PARENT_INDEX);
                    DataRow[] childItems = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                    if (childItems.Count() > 0)
                    {
                        totalChildCost = 0;
                        totalChildInstallationAmount = 0;
                        foreach (DataRow childRow in childItems)
                        {
                            BOQItemChargesModel model = BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == int.Parse(childRow[COL_ITEM_INDEX].ToString())).FirstOrDefault();
                            if (model != null)
                            {
                                totalChildCost += model.MaterialSupplyAmount;
                                totalChildInstallationAmount += model.InstallationAmount;
                            }
                        }
                        BOQItemChargesModel parentCharges = BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == parentItemIndex).FirstOrDefault();
                        if (parentCharges != null)
                        {
                            parentCharges.MaterialBasicPrice = totalChildCost / parentCharges.TotalQuantity;
                            if (totalChildInstallationAmount != 0)
                            {
                                parentCharges.InstallationRate.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                                parentCharges.InstallationRate.ItemChargeValue = totalChildInstallationAmount / parentCharges.TotalQuantity;
                            }
                            CalculateChargesOnBOQItem(parentCharges);
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::UpdateParentItemTotalForSheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CalculateChargesOnBOQItem(BOQItemChargesModel ITEM_CHARGES_INFO)
        {
            try
            {
                // GATHER ALL VALUES BACK INTO CONFIGURATION_INFO(SalesQuotationBOQItemChargesModel)
                decimal _Quantity = ITEM_CHARGES_INFO.TotalQuantity;
                decimal _BasePrice = ITEM_CHARGES_INFO.MaterialBasicPrice;

                #region MATERIAL SUPPLY CHARGES
                // MATERIAL ADD ON CHARGES
                if (ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    ITEM_CHARGES_INFO.MaterialAddOnChargesAmount = (_BasePrice * ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeValue) / 100;
                if (ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM)
                    ITEM_CHARGES_INFO.MaterialAddOnChargesAmount = ITEM_CHARGES_INFO.MaterialAddOnCharges.ItemChargeValue;

                // MATERIAL PROFIT MARGIN
                if (ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    ITEM_CHARGES_INFO.MaterialProfitMarginAmount = (_BasePrice * ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeValue) / 100;
                if (ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM)
                    ITEM_CHARGES_INFO.MaterialProfitMarginAmount = ITEM_CHARGES_INFO.MaterialProfitMargin.ItemChargeValue;

                int mMaterialSellingCost = (int)Math.Round(ITEM_CHARGES_INFO.MaterialBasicPrice + ITEM_CHARGES_INFO.MaterialAddOnChargesAmount + ITEM_CHARGES_INFO.MaterialProfitMarginAmount);      // x == 3
                ITEM_CHARGES_INFO.MaterialSellingCost = (decimal)mMaterialSellingCost;


                // MATERIAL DISCOUNT
                if (ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    ITEM_CHARGES_INFO.MaterialDiscountAmount = (ITEM_CHARGES_INFO.MaterialSellingCost * ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeValue) / 100;
                if (ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM)
                    ITEM_CHARGES_INFO.MaterialDiscountAmount = ITEM_CHARGES_INFO.MaterialDiscount.ItemChargeValue;


                // MATERIAL GST
                ITEM_CHARGES_INFO.MaterialGST.SGST_AMOUNT = ((ITEM_CHARGES_INFO.MaterialSellingCost - ITEM_CHARGES_INFO.MaterialDiscountAmount) * ITEM_CHARGES_INFO.MaterialGST.SGST_PERCENT) / 100;
                ITEM_CHARGES_INFO.MaterialGST.CGST_AMOUNT = ((ITEM_CHARGES_INFO.MaterialSellingCost - ITEM_CHARGES_INFO.MaterialDiscountAmount) * ITEM_CHARGES_INFO.MaterialGST.CGST_PERCENT) / 100;
                ITEM_CHARGES_INFO.MaterialGST.IGST_AMOUNT = ((ITEM_CHARGES_INFO.MaterialSellingCost - ITEM_CHARGES_INFO.MaterialDiscountAmount) * ITEM_CHARGES_INFO.MaterialGST.IGST_PERCENT) / 100;


                ITEM_CHARGES_INFO.MaterialNetRate = ITEM_CHARGES_INFO.MaterialSellingCost - ITEM_CHARGES_INFO.MaterialDiscountAmount + ITEM_CHARGES_INFO.MaterialGST.GST_TOTAL_AMOUNT;
                ITEM_CHARGES_INFO.MaterialSupplyAmount = ITEM_CHARGES_INFO.MaterialNetRate * ITEM_CHARGES_INFO.TotalQuantity;

                #endregion
                #region INSTALLATION & SERVICES
                // INSTALLATION CHARGES
                if (ITEM_CHARGES_INFO.InstallationRate.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    ITEM_CHARGES_INFO.InstallationRateAmount = (ITEM_CHARGES_INFO.MaterialSellingCost * ITEM_CHARGES_INFO.InstallationRate.ItemChargeValue) / 100;
                if (ITEM_CHARGES_INFO.InstallationRate.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM)
                    ITEM_CHARGES_INFO.InstallationRateAmount = ITEM_CHARGES_INFO.InstallationRate.ItemChargeValue;

                // Installation ADD ON CHARGES
                if (ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    ITEM_CHARGES_INFO.InstallationAddOnChargesAmount = (ITEM_CHARGES_INFO.InstallationRateAmount * ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeValue) / 100;
                if (ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM)
                    ITEM_CHARGES_INFO.InstallationAddOnChargesAmount = ITEM_CHARGES_INFO.InstallationAddOnCharges.ItemChargeValue;
                // Installation PROFIT MARGIN
                if (ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    ITEM_CHARGES_INFO.InstallationProfitMarginAmount = (ITEM_CHARGES_INFO.InstallationRateAmount * ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeValue) / 100;
                if (ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM)
                    ITEM_CHARGES_INFO.InstallationProfitMarginAmount = ITEM_CHARGES_INFO.InstallationProfitMargin.ItemChargeValue;

                ITEM_CHARGES_INFO.InstallationSellingCost = ITEM_CHARGES_INFO.InstallationRateAmount + ITEM_CHARGES_INFO.InstallationAddOnChargesAmount + ITEM_CHARGES_INFO.InstallationProfitMarginAmount;

                // Installation DISCOUNT
                if (ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    ITEM_CHARGES_INFO.InstallationDiscountAmount = (ITEM_CHARGES_INFO.InstallationSellingCost * ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeValue) / 100;
                if (ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM)
                    ITEM_CHARGES_INFO.InstallationDiscountAmount = ITEM_CHARGES_INFO.InstallationDiscount.ItemChargeValue;

                // Installation GST
                ITEM_CHARGES_INFO.InstallationGST.SGST_AMOUNT = ((ITEM_CHARGES_INFO.InstallationSellingCost - ITEM_CHARGES_INFO.InstallationDiscountAmount) * ITEM_CHARGES_INFO.InstallationGST.SGST_PERCENT) / 100;
                ITEM_CHARGES_INFO.InstallationGST.CGST_AMOUNT = ((ITEM_CHARGES_INFO.InstallationSellingCost - ITEM_CHARGES_INFO.InstallationDiscountAmount) * ITEM_CHARGES_INFO.InstallationGST.CGST_PERCENT) / 100;
                ITEM_CHARGES_INFO.InstallationGST.IGST_AMOUNT = ((ITEM_CHARGES_INFO.InstallationSellingCost - ITEM_CHARGES_INFO.InstallationDiscountAmount) * ITEM_CHARGES_INFO.InstallationGST.IGST_PERCENT) / 100;

                ITEM_CHARGES_INFO.InstallationNetRate = ITEM_CHARGES_INFO.InstallationSellingCost - ITEM_CHARGES_INFO.InstallationDiscountAmount + ITEM_CHARGES_INFO.InstallationGST.GST_TOTAL_AMOUNT;
                ITEM_CHARGES_INFO.InstallationAmount = ITEM_CHARGES_INFO.InstallationNetRate * ITEM_CHARGES_INFO.TotalQuantity;

                #endregion


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::CalculateChargesOnBOQItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void UpdateSalesQuotationBOQSheetSummary(SalesOrderBOQSheet BOQ_SHEET_MODEL)
        {
            // MATERIAL SUPPLY SUMMARY
            decimal _MaterialSupplyAmount = 0;

            decimal _MaterialSupplyAddOnChargesAmount = 0;
            decimal _MaterialSupplyProfitMarginAmount = 0;
            decimal _MaterialSupplyDiscountAmount = 0;

            decimal _MaterialSupplyCGSTAmount = 0;
            decimal _MaterialSupplySGSTAmount = 0;
            decimal _MaterialSupplyIGSTAmount = 0;

            //// INSTALLATION SUMMARY
            decimal _InstallationAmount = 0;
            decimal _InstallationDiscountAmount = 0;
            decimal _InstallationAddOnChargesAmount = 0;
            decimal _InstallationProfitMarginAmount = 0;

            decimal _InstallationCGSTAmount = 0;
            decimal _InstallationSGSTAmount = 0;
            decimal _InstallationIGSTAmount = 0;

            try
            {
                SalesOrderBOQSheetSummary objSummary = new SalesOrderBOQSheetSummary();
                if (BOQ_SHEET_MODEL.datatableQuotationBOQ == null) return;
                if (BOQ_SHEET_MODEL.datatableQuotationBOQ.Rows.Count == 0) return;
                // UPDATE CHARGES ON ALL CHILDRENS WHICH ARE ASEMBLY ITEMS 
                string strExpr = string.Format("[{0}]=0", COL_PARENT_INDEX);
                DataRow[] parentItems = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strExpr);
                int _itemIndex = 0;

                if (parentItems.Count() > 0)
                {
                    foreach (DataRow childRow in parentItems)
                    {
                        _itemIndex = int.Parse(childRow[COL_ITEM_INDEX].ToString());

                        BOQItemChargesModel objCharges = BOQ_SHEET_MODEL.ITEM_CHARGES.Where(x => x.Index == _itemIndex).FirstOrDefault();
                        if (objCharges != null)
                        {

                            _MaterialSupplyAmount += objCharges.MaterialSupplyAmount;
                            _MaterialSupplyAddOnChargesAmount += objCharges.MaterialAddOnChargesAmount;
                            _MaterialSupplyProfitMarginAmount += objCharges.MaterialProfitMarginAmount;
                            _MaterialSupplyDiscountAmount += objCharges.MaterialDiscountAmount;
                            _MaterialSupplyCGSTAmount += objCharges.MaterialGST.CGST_AMOUNT;
                            _MaterialSupplySGSTAmount += objCharges.MaterialGST.SGST_AMOUNT;
                            _MaterialSupplyIGSTAmount += objCharges.MaterialGST.IGST_AMOUNT;

                            _InstallationAmount += objCharges.InstallationAmount;
                            _InstallationDiscountAmount += objCharges.InstallationDiscountAmount;
                            _InstallationAddOnChargesAmount += objCharges.InstallationAddOnChargesAmount;
                            _InstallationProfitMarginAmount += objCharges.InstallationProfitMarginAmount;
                            _InstallationCGSTAmount += objCharges.InstallationGST.CGST_AMOUNT;
                            _InstallationSGSTAmount += objCharges.InstallationGST.SGST_AMOUNT;
                            _InstallationIGSTAmount += objCharges.InstallationGST.IGST_AMOUNT;

                        }

                    }



                    objSummary.MaterialSupplyAmount = _MaterialSupplyAmount;
                    objSummary.MaterialSupplyAddOnChargesAmount = _MaterialSupplyAddOnChargesAmount;
                    objSummary.MaterialSupplyProfitMarginAmount = _MaterialSupplyProfitMarginAmount;
                    objSummary.MaterialSupplyDiscountAmount = _MaterialSupplyDiscountAmount;
                    objSummary.MaterialSupplyCGSTAmount = _MaterialSupplyCGSTAmount;
                    objSummary.MaterialSupplySGSTAmount = _MaterialSupplySGSTAmount;
                    objSummary.MaterialSupplyIGSTAmount = _MaterialSupplyIGSTAmount;

                    objSummary.InstallationAmount = _InstallationAmount;
                    objSummary.InstallationAddOnChargesAmount = _InstallationAddOnChargesAmount;
                    objSummary.InstallationProfitMarginAmount = _InstallationProfitMarginAmount;
                    objSummary.InstallationDiscountAmount = _InstallationDiscountAmount;
                    objSummary.InstallationCGSTAmount = _InstallationCGSTAmount;
                    objSummary.InstallationSGSTAmount = _InstallationSGSTAmount;
                    objSummary.InstallationIGSTAmount = _InstallationIGSTAmount;


                    objSummary.NetAmountBeforeTax = _MaterialSupplyAmount + _InstallationAmount
                        - (_MaterialSupplyCGSTAmount + _MaterialSupplySGSTAmount + _MaterialSupplyIGSTAmount)
                        - (_InstallationCGSTAmount + _InstallationSGSTAmount + _InstallationIGSTAmount);
                    objSummary.GrossAmountAfterTax = _MaterialSupplyAmount + _InstallationAmount;


                }
                BOQ_SHEET_MODEL.SUMMARY = objSummary;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::UpdateSalesQuotationBOQSheetSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GenerateDefaultBOQSummaryDatatable()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn() { ColumnName = COL_BOQ_SUMMARY_SRNO, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_BOQ_SUMMARY_SHEETNAME, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_BOQ_SUMMARY_MATERIAL_TOTAL, DataType = typeof(double) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_BOQ_SUMMARY_INSTALLATION_TOTAL, DataType = typeof(double) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_BOQ_SUMMARY_TOTAL, DataType = typeof(double) });
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::GenerateDefaultBOQSummaryDatatable", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public void UpdateSalesOrderBOQSummary(SalesOrderBOQViewModel BOQ)
        {
            decimal mMaterialAmountForAllSheets = 0;
            decimal mInstallationAmountForAllSheets = 0;
            int idx = 1;
            try
            {
                #region CALCULATE QUOTATION SUMMARY
                BOQ.SUMMARY.datatableBOQSheets = this.GenerateDefaultBOQSummaryDatatable();
                foreach (SalesOrderBOQSheet sheet in BOQ.SHEETS)
                {
                    DataRow dtrow = BOQ.SUMMARY.datatableBOQSheets.NewRow();
                    dtrow[COL_BOQ_SUMMARY_SRNO] = idx++;
                    dtrow[COL_BOQ_SUMMARY_SHEETNAME] = sheet.SheetName;
                    dtrow[COL_BOQ_SUMMARY_MATERIAL_TOTAL] = sheet.SUMMARY.MaterialSupplyAmount;
                    dtrow[COL_BOQ_SUMMARY_INSTALLATION_TOTAL] = sheet.SUMMARY.InstallationAmount;
                    dtrow[COL_BOQ_SUMMARY_TOTAL] = sheet.SUMMARY.MaterialSupplyAmount + sheet.SUMMARY.InstallationAmount;
                    BOQ.SUMMARY.datatableBOQSheets.Rows.Add(dtrow);

                    mMaterialAmountForAllSheets += sheet.SUMMARY.MaterialSupplyAmount;
                    mInstallationAmountForAllSheets += sheet.SUMMARY.InstallationAmount;
                }

                BOQ.SUMMARY.MaterialAmountForAllSheets = mMaterialAmountForAllSheets;
                BOQ.SUMMARY.InstallationAmountForAllSheets = mInstallationAmountForAllSheets;

                // BOQ MATERIAL SUPPLY DISCOUNT CHARGES
                if (BOQ.SUMMARY.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    BOQ.SUMMARY.MaterialDiscountAmount = (BOQ.SUMMARY.MaterialAmountForAllSheets * BOQ.SUMMARY.MaterialDiscount.ItemChargeValue) / 100;
                else
                    BOQ.SUMMARY.MaterialDiscountAmount = BOQ.SUMMARY.MaterialDiscount.ItemChargeValue;
                //BOQ MATERIAL SUPPLY GST
                BOQ.SUMMARY.MaterialGST.CGST_AMOUNT = ((BOQ.SUMMARY.MaterialAmountForAllSheets - BOQ.SUMMARY.MaterialDiscountAmount) * BOQ.SUMMARY.MaterialGST.CGST_PERCENT) / 100;
                BOQ.SUMMARY.MaterialGST.SGST_AMOUNT = ((BOQ.SUMMARY.MaterialAmountForAllSheets - BOQ.SUMMARY.MaterialDiscountAmount) * BOQ.SUMMARY.MaterialGST.SGST_PERCENT) / 100;
                BOQ.SUMMARY.MaterialGST.IGST_AMOUNT = ((BOQ.SUMMARY.MaterialAmountForAllSheets - BOQ.SUMMARY.MaterialDiscountAmount) * BOQ.SUMMARY.MaterialGST.IGST_PERCENT) / 100;

                BOQ.SUMMARY.MaterialFinalAmount = BOQ.SUMMARY.MaterialAmountForAllSheets - BOQ.SUMMARY.MaterialDiscountAmount + BOQ.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT;

                // BOQ INSTALLATION/SERVICES DISCOUNT CHARGES
                if (BOQ.SUMMARY.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    BOQ.SUMMARY.InstallationDiscountAmount = (BOQ.SUMMARY.InstallationAmountForAllSheets * BOQ.SUMMARY.InstallationDiscount.ItemChargeValue) / 100;
                else
                    BOQ.SUMMARY.InstallationDiscountAmount = BOQ.SUMMARY.InstallationDiscount.ItemChargeValue;
                //BOQ INSTALLATION/SERVICES GST
                BOQ.SUMMARY.InstallationGST.CGST_AMOUNT = ((BOQ.SUMMARY.InstallationAmountForAllSheets - BOQ.SUMMARY.InstallationDiscountAmount) * BOQ.SUMMARY.InstallationGST.CGST_PERCENT) / 100;
                BOQ.SUMMARY.InstallationGST.SGST_AMOUNT = ((BOQ.SUMMARY.InstallationAmountForAllSheets - BOQ.SUMMARY.InstallationDiscountAmount) * BOQ.SUMMARY.InstallationGST.SGST_PERCENT) / 100;
                BOQ.SUMMARY.InstallationGST.IGST_AMOUNT = ((BOQ.SUMMARY.InstallationAmountForAllSheets - BOQ.SUMMARY.InstallationDiscountAmount) * BOQ.SUMMARY.InstallationGST.IGST_PERCENT) / 100;

                BOQ.SUMMARY.InstallationFinalAmount = BOQ.SUMMARY.InstallationAmountForAllSheets - BOQ.SUMMARY.InstallationDiscountAmount + BOQ.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT;

                #endregion
                #region UPDATE SALES QUOTATION TABLE WITH SUMMARY VALUES
                TBL_MP_CRM_SalesOrder recOrder = _dbContext.TBL_MP_CRM_SalesOrder.Where(x => x.PK_SalesOrderID == BOQ.ORDER_ID).FirstOrDefault();
                recOrder.MaterialSupplyTotalAmount = BOQ.SUMMARY.MaterialAmountForAllSheets;
                recOrder.MaterialSupplyDiscountType = (int)BOQ.SUMMARY.MaterialDiscount.ItemChargeType;
                recOrder.MaterialSupplyDiscountValue = BOQ.SUMMARY.MaterialDiscount.ItemChargeValue;
                recOrder.MaterialSupplyDiscountamount = BOQ.SUMMARY.MaterialDiscountAmount;
                recOrder.MaterialSupplySGSTPercent = BOQ.SUMMARY.MaterialGST.SGST_PERCENT;
                recOrder.MaterialSupplyCGSTPercent = BOQ.SUMMARY.MaterialGST.CGST_PERCENT;
                recOrder.MaterialSupplyIGSTPercent = BOQ.SUMMARY.MaterialGST.IGST_PERCENT;
                recOrder.MaterialSupplySGSTAmount = BOQ.SUMMARY.MaterialGST.SGST_AMOUNT;
                recOrder.MaterialSupplyCGSTAmount = BOQ.SUMMARY.MaterialGST.CGST_AMOUNT;
                recOrder.MaterialSupplyIGSTAmount = BOQ.SUMMARY.MaterialGST.IGST_AMOUNT;
                recOrder.MaterialSupplyFinalAmount = BOQ.SUMMARY.MaterialFinalAmount;
                recOrder.InstallationTotalAmount = BOQ.SUMMARY.InstallationAmountForAllSheets;
                recOrder.InstallationDiscountType = (int)BOQ.SUMMARY.InstallationDiscount.ItemChargeType;
                recOrder.InstallationDiscountValue = BOQ.SUMMARY.InstallationDiscount.ItemChargeValue;
                recOrder.InstallationDiscountAmount = BOQ.SUMMARY.InstallationDiscountAmount;
                recOrder.InstallationSGSTPercent = BOQ.SUMMARY.InstallationGST.SGST_PERCENT;
                recOrder.InstallationCGSTPercent = BOQ.SUMMARY.InstallationGST.CGST_PERCENT;
                recOrder.InstallationIGSTPercent = BOQ.SUMMARY.InstallationGST.IGST_PERCENT;
                recOrder.InstallationSGSTAmount = BOQ.SUMMARY.InstallationGST.SGST_AMOUNT;
                recOrder.InstallationCGSTAmount = BOQ.SUMMARY.InstallationGST.CGST_AMOUNT;
                recOrder.InstallationIGSTAmount = BOQ.SUMMARY.InstallationGST.IGST_AMOUNT;
                recOrder.InstallationFinalAmount = BOQ.SUMMARY.InstallationFinalAmount;
                recOrder.OrderFinalAmount = BOQ.SUMMARY.QuotationFinalAmount;
                _dbContext.SaveChanges();
                #endregion


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::UpdateSalesQuotationBOQSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetItemQuantitySummary(decimal DESIGN_BOQ_SRNO, SalesOrderBOQSheet BOQ_SHEET_MODEL)
        {
            DataTable dtQTY_SUMMARY = new DataTable();
            try
            {
                DataRow rowDESIGN_BOQ = null;
                string strEXPR = string.Empty;
                string strFILTER = string.Empty;
                ServiceSalesOrderBOQ serviceORDER_BOQ = new ServiceSalesOrderBOQ();
                //CREATE COLUMNS IN NEW DATATABLE
                foreach (DataColumn col in BOQ_SHEET_MODEL.datatableQuotationBOQ.Columns)
                {
                    EnquiryBOQService selService = BOQ_SHEET_MODEL.BOQ_SERVICES.Where(X => X.Description == col.ColumnName).FirstOrDefault();
                    if (selService == null)
                    {
                        if (col.ColumnName == serviceORDER_BOQ.COL_TOTAL_QUANTITY)
                        {
                            dtQTY_SUMMARY.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = typeof(string) });
                        }
                        else
                            dtQTY_SUMMARY.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = col.DataType });

                    }
                    else
                        dtQTY_SUMMARY.Columns.Add(new DataColumn() { ColumnName = col.ColumnName, DataType = typeof(string) });
                }
                //GET DESIGN BOQ ROW OF THE ITEM
                strEXPR = string.Format("[{0}]={1}", serviceORDER_BOQ.COL_SERIAL_NO_SYS, DESIGN_BOQ_SRNO);
                DataRow[] selItemRows = BOQ_SHEET_MODEL.datatableQuotationBOQ.Select(strEXPR);
                if (selItemRows.Count() > 0)
                {
                    rowDESIGN_BOQ = selItemRows[0];
                }

                DataRow dtrow = dtQTY_SUMMARY.NewRow();
                strFILTER = string.Format("[{0}]='{1}'", COL_SERIAL_NO_DESIGN, DESIGN_BOQ_SRNO);

                // FIND TOTAL QUANITITY CONSUMED
                strEXPR = string.Format("Sum([{0}])", COL_TOTAL_QUANTITY);
                var tot_qty = BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(strEXPR, strFILTER);
                dtrow[serviceORDER_BOQ.COL_TOTAL_QUANTITY] = string.Format("{0}/{1}", tot_qty, rowDESIGN_BOQ[serviceORDER_BOQ.COL_TOTAL_QUANTITY].ToString());
                // TOTAL ALL INCLUDED SERVICES
                foreach (EnquiryBOQService selService in BOQ_SHEET_MODEL.BOQ_SERVICES)
                {
                    strEXPR = string.Format("Sum([{0}])", selService.Description);
                    tot_qty = BOQ_SHEET_MODEL.datatableQuotationBOQ.Compute(strEXPR, strFILTER);
                    dtrow[selService.Description] = string.Format("{0}/{1}", tot_qty, rowDESIGN_BOQ[selService.Description].ToString());
                }
                dtQTY_SUMMARY.Rows.Add(dtrow);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrderBOQ::GetItemQuantitySummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtQTY_SUMMARY;
        }

        public SalesOrderBOQSummary GetOrderBOQSummaryForOrderID(int orderID)
        {
            SalesOrderBOQSummary model = new SalesOrderBOQSummary();
            try
            {
                TBL_MP_CRM_SalesOrder dbModel = (new ServiceSalesOrder()).GetSalesOrderDBInfoByID(orderID);
                if (dbModel != null)
                {
                    if (dbModel.MaterialSupplyTotalAmount != null)
                    {
                        model.MaterialAmountForAllSheets = (decimal)dbModel.MaterialSupplyTotalAmount;
                    }
                    else
                    {
                        model.MaterialAmountForAllSheets = 0;
                    }
                    if (dbModel.MaterialSupplyDiscountamount != null)
                    {
                        model.MaterialDiscount.ItemChargeType = (ITEM_CHARGE_TYPE)dbModel.MaterialSupplyDiscountType;
                        model.MaterialDiscount.ItemChargeValue = (decimal)dbModel.MaterialSupplyDiscountValue;
                        model.MaterialDiscountAmount = (decimal)dbModel.MaterialSupplyDiscountamount;
                    }
                    else
                    {
                        model.MaterialDiscount.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                        model.MaterialDiscount.ItemChargeValue = 0;
                        model.MaterialDiscountAmount = 0;
                    }
                    if (dbModel.MaterialSupplySGSTPercent != null)
                    {
                        model.MaterialGST.SGST_PERCENT = (decimal)dbModel.MaterialSupplySGSTPercent;
                    }
                    else
                    {
                        model.MaterialGST.SGST_PERCENT = 0;
                    }
                    if (dbModel.MaterialSupplyCGSTPercent != null)
                    {
                        model.MaterialGST.CGST_PERCENT = (decimal)dbModel.MaterialSupplyCGSTPercent;
                    }
                    else
                    {
                        model.MaterialGST.CGST_PERCENT = 0;
                    }
                    if (dbModel.MaterialSupplyIGSTPercent != null)
                    {
                        model.MaterialGST.IGST_PERCENT = (decimal)dbModel.MaterialSupplyIGSTPercent;
                    }
                    else
                    {
                        model.MaterialGST.IGST_PERCENT = 0;
                    }
                    if (dbModel.MaterialSupplySGSTAmount != null)
                    {
                        model.MaterialGST.SGST_AMOUNT = (decimal)dbModel.MaterialSupplySGSTAmount;
                    }
                    else
                    {
                        model.MaterialGST.SGST_AMOUNT = 0;
                    }
                    if (dbModel.MaterialSupplyCGSTAmount != null)
                    {
                        model.MaterialGST.CGST_AMOUNT = (decimal)dbModel.MaterialSupplyCGSTAmount;
                    }
                    else
                    {
                        model.MaterialGST.CGST_AMOUNT = 0;
                    }
                    if (dbModel.MaterialSupplyIGSTAmount != null)
                    {
                        model.MaterialGST.IGST_AMOUNT = (decimal)dbModel.MaterialSupplyIGSTAmount;
                    }
                    else
                    {
                        model.MaterialGST.IGST_AMOUNT = 0;
                    }
                    if (dbModel.MaterialSupplyFinalAmount != null)
                    {
                        model.MaterialFinalAmount = (decimal)dbModel.MaterialSupplyFinalAmount;
                    }
                    else
                    {
                        model.MaterialFinalAmount = 0;
                    }

                    if (dbModel.InstallationTotalAmount != null)
                    {
                        model.InstallationAmountForAllSheets = (decimal)dbModel.InstallationTotalAmount;
                    }
                    else
                    {
                        model.InstallationAmountForAllSheets = 0;
                    }
                    if (dbModel.InstallationDiscountAmount != null)
                    {
                        model.InstallationDiscount.ItemChargeType = (ITEM_CHARGE_TYPE)dbModel.InstallationDiscountType;
                        model.InstallationDiscount.ItemChargeValue = (decimal)dbModel.InstallationDiscountValue;
                        model.InstallationDiscountAmount = (decimal)dbModel.InstallationDiscountAmount;
                    }
                    else
                    {
                        model.InstallationDiscount.ItemChargeType = ITEM_CHARGE_TYPE.LUMPSUM;
                        model.InstallationDiscount.ItemChargeValue = 0;
                        model.InstallationDiscountAmount = 0;
                    }
                    if (dbModel.InstallationSGSTPercent != null)
                    {
                        model.InstallationGST.SGST_PERCENT = (decimal)dbModel.InstallationSGSTPercent;
                    }
                    else
                    {
                        model.InstallationGST.SGST_PERCENT = 0;
                    }
                    if (dbModel.InstallationCGSTPercent != null)
                    {
                        model.InstallationGST.CGST_PERCENT = (decimal)dbModel.InstallationCGSTPercent;
                    }
                    else
                    {
                        model.InstallationGST.CGST_PERCENT = 0;
                    }
                    if (dbModel.InstallationIGSTPercent != null)
                    {
                        model.InstallationGST.IGST_PERCENT = (decimal)dbModel.InstallationIGSTPercent;
                    }
                    else
                    {
                        model.InstallationGST.IGST_PERCENT = 0;
                    }
                    if (dbModel.InstallationSGSTAmount != null)
                    {
                        model.InstallationGST.SGST_AMOUNT = (decimal)dbModel.InstallationSGSTAmount;
                    }
                    else
                    {
                        model.InstallationGST.SGST_AMOUNT = 0;
                    }
                    if (dbModel.InstallationCGSTAmount != null)
                    {
                        model.InstallationGST.CGST_AMOUNT = (decimal)dbModel.InstallationCGSTAmount;
                    }
                    else
                    {
                        model.InstallationGST.CGST_AMOUNT = 0;
                    }
                    if (dbModel.InstallationIGSTAmount != null)
                    {
                        model.InstallationGST.IGST_AMOUNT = (decimal)dbModel.InstallationIGSTAmount;
                    }
                    else
                    {
                        model.InstallationGST.IGST_AMOUNT = 0;
                    }
                    if (dbModel.InstallationFinalAmount != null)
                    {
                        model.InstallationFinalAmount = (decimal)dbModel.InstallationFinalAmount;
                    }
                    else
                    {
                        model.InstallationFinalAmount = 0;
                    }




                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesOrderBOQ::GetOrderBOQSummaryForOrderID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
    }
}