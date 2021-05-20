
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using libERP;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using libERP.MODELS;
using libERP.SERVICES.MASTER;
using libERP.MODELS.CRM;

namespace libERP.SERVICES.CRM
{
    public class ServiceSalesEnquiryBOQ: DefaultService
    {
        public string COL_DEFAULT_QTY = "DefaultQty";
        public string COL_INDEX = "Index";
        public string COL_SERIAL_NO_SYS = "SERIAL_NO_SYS";
        public string COL_PARENT_ITEM_ID = "ParentItemID";
        public string COL_IS_ASSEMBLY = "IsAssembly";
        public string COL_HAS_SERVICES = "HasServices";
        public string COL_ITEM_ID = "ItemID";
        public string COL_ITEM_CODE = "ItemCode";
        public string COL_HSN_CODE = "HSN";
        public string COL_ITEM_DESCRIPTION = "ItemDescription";
        public string COL_UOM_ID = "UOMID";
        public string COL_UOM_NAME = "UOMName";
        public string COL_TOTAL_QTY = "TotalQty";


        public ServiceSalesEnquiryBOQ(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceSalesEnquiryBOQ()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<TBL_MP_CRM_SalesEnquiry_BOQ> GetAllDesignBOQs( int SelectedID)
        {

            List<TBL_MP_CRM_SalesEnquiry_BOQ> lst = null;
            try
            {
                lst = new List<TBL_MP_CRM_SalesEnquiry_BOQ>();
                lst = _dbContext.TBL_MP_CRM_SalesEnquiry_BOQ.Where(x => x.ENQUIRY_ID == SelectedID).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiryBOQ::GetAllDesignBOQs");

            }
            return lst;

        }
        public TBL_MP_CRM_SalesEnquiry_BOQ GetDesignBOQdbInfo( int SelectedID)
        {
            TBL_MP_CRM_SalesEnquiry_BOQ model = null;
            try
            {
                model = (from xx in _dbContext.TBL_MP_CRM_SalesEnquiry_BOQ where  xx.ENQUIRY_ID == SelectedID select xx).FirstOrDefault(); 

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiryBOQ::GetDesignBOQdbInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

        public System.Data.DataTable GenerateBOQDataTableDefault()
        {
            DataTable dt = new DataTable();
            try
            {
                dt.Columns.Add(new DataColumn() { ColumnName = COL_DEFAULT_QTY, DataType = typeof(decimal), DefaultValue = 0 });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_INDEX, DataType = typeof(int), DefaultValue = 0 });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_SERIAL_NO_SYS, DataType = typeof(decimal) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_PARENT_ITEM_ID, DataType = typeof(int), DefaultValue = 0 });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_IS_ASSEMBLY, DataType = typeof(bool), DefaultValue = false });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_HAS_SERVICES, DataType = typeof(bool),DefaultValue=false });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_ID, DataType = typeof(int)});
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_CODE, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_HSN_CODE, DataType = typeof(string),DefaultValue=string.Empty });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_ITEM_DESCRIPTION, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_UOM_ID, DataType = typeof(int) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_UOM_NAME, DataType = typeof(string) });
                dt.Columns.Add(new DataColumn() { ColumnName = COL_TOTAL_QTY, DataType = typeof(decimal), DefaultValue = 0});
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesEnquiryBOQ::GenerateBOQDataTableDefault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }
        public System.Data.DataTable GenerateDesignBOQDataTableWithServices(System.Data.DataTable dt, BindingList<EnquiryBOQService> listServices, BindingList<EnquiryBOQItem> listItems)
        {
            try
            {
                // INSERT SERVICES COLUMN IN DATATABLE
                int stIndex = dt.Columns[COL_UOM_NAME].Ordinal;
                string strExpr = string.Empty;
                foreach (EnquiryBOQService item in listServices)
                {
                    stIndex++;
                    if (!dt.Columns.Contains(item.Description))
                    {
                        dt.Columns.Add(new DataColumn() { ColumnName = item.Description, DataType = typeof(decimal), DefaultValue=0});
                        dt.Columns[item.Description].SetOrdinal(stIndex);
                    }
                    
                }
                dt.Columns[COL_TOTAL_QTY].SetOrdinal(dt.Columns.Count-1);

                // INSERT ITEMS ROW IN DATATABLE
                foreach (EnquiryBOQItem item in listItems)
                {
                    strExpr = string.Format("[{0}]=0 AND [{1}]={2}", COL_PARENT_ITEM_ID, COL_ITEM_ID,item.ID);
                    DataRow[] result = dt.Select(strExpr);
                    if (result.Count() == 0)
                    {
                        TBL_MP_Master_Item dbItem=(new ServiceInventoryItems()).GetItemDBRecord(item.ID);
                        if(dbItem!=null)
                        {
                            int newIndex = 0;
                            if(dt.Rows.Count>0) newIndex = int.Parse(dt.AsEnumerable().Max(row => row[COL_INDEX]).ToString());
                            newIndex++;
                            string str = string.Format("MAX([{0}])", COL_SERIAL_NO_SYS);
                            decimal newSerial = 0;
                            if (dt.Rows.Count > 0) newSerial =decimal.Parse((dt.Compute(str, string.Empty)).ToString()); 
                            newSerial++;

                            DataRow dtrow = dt.NewRow();
                            dtrow[COL_DEFAULT_QTY] = 0;
                            dtrow[COL_INDEX] = newIndex;
                            dtrow[COL_SERIAL_NO_SYS] = (int)newSerial;
                            dtrow[COL_PARENT_ITEM_ID] = 0;
                            dtrow[COL_HAS_SERVICES] = false;
                            dtrow[COL_ITEM_ID] = item.ID;
                            dtrow[COL_ITEM_CODE] = dbItem.ItemCode;
                            dtrow[COL_HSN_CODE] = dbItem.HSNCode;
                            dtrow[COL_ITEM_DESCRIPTION] =string.Format("{0}\n{1}",dbItem.Item_Name, dbItem.Long_Description);
                            dtrow[COL_IS_ASSEMBLY] =dbItem.IsAssembly;

                            //SET UOM ID & NAME
                            if (dbItem.Fk_UserList_BaseUOM_ID != null)
                            {
                                List<SelectListItem> UOMs = (new ServiceMASTERS()).GetAllUOMs();
                                SelectListItem selUOM = UOMs.Where(x => x.ID == dbItem.Fk_UserList_BaseUOM_ID).FirstOrDefault();
                                if (selUOM != null)
                                {
                                    dtrow[COL_UOM_ID] = selUOM.ID;
                                    dtrow[COL_UOM_NAME] = selUOM.Description;
                                }
                            }
                            //SET SERCVICS COLUMNS QTY VALUE TO 0
                            foreach (EnquiryBOQService selService in listServices)
                            {
                                dtrow[selService.Description] = 0;
                            }
                            dtrow[COL_TOTAL_QTY] = 0;
                            dt.Rows.Add(dtrow);
                        }
                    }
                }
                
                // REMOVE COLUMNS NOT FOUND IN SERVICES LIST
                string colsToRemove = string.Empty;
                stIndex = (dt.Columns[COL_UOM_NAME].Ordinal);
                stIndex++;
                for(int i= stIndex; i < dt.Columns.Count;i++ )
                {
                    string colName = dt.Columns[i].ColumnName;
                    if(colName!=COL_TOTAL_QTY)
                    {
                        EnquiryBOQService found = listServices.Where(x => x.Description == colName).FirstOrDefault();
                        if (found == null)
                        {
                            colsToRemove+=colName+ DefaultStringSeperator;
                        }
                    }
                }
                if (colsToRemove.EndsWith(DefaultStringSeperator.ToString()))
                {
                    colsToRemove= colsToRemove.TrimEnd(DefaultStringSeperator);
                }
                if (colsToRemove != string.Empty)
                {
                    string[] arrCols = colsToRemove.Split(DefaultStringSeperator);
                    foreach (string s in arrCols)
                    {
                        dt.Columns.Remove(s);
                    }
                }


                //// REMOVE ROWS NOT FOUND IN ITEMS LIST
                //string rowsToRemove = string.Empty;
                //foreach (DataRow dr in dt.Rows)
                //{
                //    int itemID = int.Parse(dr[COL_ITEM_ID].ToString());
                //    EnquiryBOQItem found = listItems.Where(x => x.ID == itemID).FirstOrDefault();
                //    if (found == null)
                //    {
                //        rowsToRemove += itemID.ToString() + DefaultStringSeperator;
                //    }
                //}
                //if (rowsToRemove.EndsWith(DefaultStringSeperator.ToString()))
                //{
                //    rowsToRemove = rowsToRemove.TrimEnd(DefaultStringSeperator);
                //}
                //if (rowsToRemove != string.Empty)
                //{
                //    string[] arrRows = rowsToRemove.Split(DefaultStringSeperator);
                //    foreach (string s in arrRows)
                //    {
                //        strExpr = string.Format("[{0}]=0 AND [{1}]={2}", COL_PARENT_ITEM_ID, COL_ITEM_ID, s);
                //        DataRow delRow = dt.Select(strExpr).FirstOrDefault();
                //        if (delRow != null)
                //        {
                //            if ((bool)delRow[COL_IS_ASSEMBLY] == true)
                //            {
                //                strExpr = string.Format("[{0}]={1}", COL_PARENT_ITEM_ID, s);
                //                DataRow[] childRows= dt.Select(strExpr);
                //                for(int i=0;i<= childRows.GetUpperBound(0);i++)
                //                    dt.Rows.Remove(childRows[i]);
                //            }
                //            dt.Rows.Remove(delRow);
                //            dt.AcceptChanges();
                //        }

                //    }
                //}
                ////dt.Columns["TotalQty"].SetOrdinal(stIndex++);
                ////dt.Columns["UnitPrice"].SetOrdinal(stIndex++);
                ////dt.Columns["TotalPrice"].SetOrdinal(stIndex++);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiryBOQ::GenerateBOQDataTableWithServices", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return dt;
        }

        public System.Data.DataTable GenrateDesignBOQDatatableSummary(System.Data.DataTable dtSourceBOQ)
        {
            DataTable tblSummary = new DataTable();
            try
            {
                
                foreach (DataColumn col in dtSourceBOQ.Columns)
                {
                    tblSummary.Columns.Add(new DataColumn() { ColumnName= col.ColumnName, DataType= col.DataType });
                }
                DataRow dr = tblSummary.NewRow();
                dr[COL_ITEM_DESCRIPTION] = string.Format("Summary/Total: ({0}) items", dtSourceBOQ.Rows.Count);
                foreach (DataColumn col in dtSourceBOQ.Columns)
                {
                    if (col.DataType == typeof(int))
                    {
                        if (col.ColumnName != COL_ITEM_ID && col.ColumnName != COL_UOM_ID)
                        {
                            string strExpression = string.Format("SUM({0})", col.ColumnName);
                            string strFilter = string.Format(" {0} Is Not Null", col.ColumnName);
                            if(dtSourceBOQ.Compute(strExpression, strFilter)!=DBNull.Value)
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
                MessageBox.Show(ex.Message, "ServiceSalesEnquiryBOQ::GenrateDesignBOQDatatableSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            if(row.ItemArray[col.Ordinal]!=DBNull.Value)
                                totQty += int.Parse(row[col.ColumnName].ToString());
                        }
                    }
                    if (totQty == 0)
                    {
                        row[COL_HAS_SERVICES] = false;
                    }
                    else
                    {
                        row[COL_HAS_SERVICES] = true;
                        row[COL_TOTAL_QTY] = totQty;
                    }
                        
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiryBOQ::UpdateRowTotalQuantity", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dtSourceBOQ;
        }

        public SalesEnquiryDesignBOQViewModel SaveDesignBOQ(SalesEnquiryDesignBOQViewModel MODEL, int empID)
        {
            try
            {
                if (MODEL.BOQ_ID == 0)
                {
                    TBL_MP_CRM_SalesEnquiry_BOQ newBOQ = new TBL_MP_CRM_SalesEnquiry_BOQ();
                    newBOQ.ENQUIRY_ID = MODEL.ENQUIRY_ID;
                    newBOQ.BOQ_DESIGN_OBJECT_CREATED_BY = empID;
                    newBOQ.BOQ_DESIGN_OBJECT_CREATED_DATE = AppCommon.GetServerDateTime();
                    newBOQ.BOQ_NUMBER = this.GenerateDesignBOQNumber(MODEL.ENQUIRY_ID);
                    _dbContext.TBL_MP_CRM_SalesEnquiry_BOQ.Add(newBOQ);
                    _dbContext.SaveChanges();
                    MODEL.BOQ_ID = newBOQ.DESIGN_BOQ_ID;
                }
                // REINSTANCIATE BOQ ITEMS COLLECTION
                foreach (SalesEnquiryDesignBOQSheet sheet in MODEL.SHEETS)
                {
                    sheet.BOQ_ITEMS = new BindingList<EnquiryBOQItem>();
                }

                string output = JsonConvert.SerializeObject(MODEL);
                TBL_MP_CRM_SalesEnquiry_BOQ editBOQ = _dbContext.TBL_MP_CRM_SalesEnquiry_BOQ.Where(x=>x.DESIGN_BOQ_ID==MODEL.BOQ_ID).FirstOrDefault();
                editBOQ.BOQ_DESIGN_OBJECT = output;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiryBOQ::SaveDesignBOQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return MODEL;

        }

        public string GenerateDesignBOQNumber(int salesEnquiryID)
        {
            string strNumber = string.Empty;

            TBL_MP_CRM_SalesEnquiry enquiry = (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(salesEnquiryID);
            if (enquiry != null)
            {
                strNumber = enquiry.SalesEnquiry_No;
            }
            int cnt=_dbContext.TBL_MP_CRM_SalesEnquiry_BOQ.Where(x => x.ENQUIRY_ID == salesEnquiryID).Count();
            strNumber = string.Format("{0}#D{1}", strNumber, (++cnt).ToString().PadLeft(3, '0'));
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
                    model=JsonConvert.DeserializeObject<SalesEnquiryDesignBOQViewModel>(json);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceSalesEnquiryBOQ::GetDesignBOQModel", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "ServiceSalesEnquiryBOQ::GetDesignBOQModel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }

    }

}
