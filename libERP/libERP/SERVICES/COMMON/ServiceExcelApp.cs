using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using Microsoft.Office.Interop.Excel;

using System.Drawing;
using System.ComponentModel;
using libERP.MODELS.CRM;
using libERP.SERVICES.CRM;
using libERP.MODELS;
using libERP.SERVICES.ADMIN;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using libERP.MODELS.HR;
using GemBox.Spreadsheet;

namespace libERP.SERVICES.COMMON
{
    public class ServiceExcelApp
    {
       
        public Microsoft.Office.Interop.Excel.Application excelApp { get; set; }
        public Microsoft.Office.Interop.Excel.Workbook xlWorkBook { get; set; }
        public Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet { get; set; }

        public ServiceExcelApp()
        {
            excelApp = new Microsoft.Office.Interop.Excel.Application();
        }

        public void ExportDesignBOQBookToExcel(SalesEnquiryDesignBOQViewModel designModel, string fileNameWithPath)
        {
            ServiceSalesEnquiryBOQ serviceBOQ = new ServiceSalesEnquiryBOQ();
            try
            {
                int currRow = 1;
                int currCol = 1;
                int servicesCount = 0;
                int totalColumns = 0;
                int tableRowStartIndex = 0;
                Range excelCellrange = null;

                const int COL_SRNO = 1;
                const int COL_ITEM_CODE = 2;
                const int COL_ITEM_DESCRIPTION = 3;
                const int COL_UOM = 4;
                try

                {
                    if (excelApp == null)
                    {
                        MessageBox.Show("Excel is not properly installed!!");
                        return;
                    }
                    excelApp.DisplayAlerts = false;
                    object misValue = System.Reflection.Missing.Value;
                    xlWorkBook = excelApp.Workbooks.Add(misValue);

                    Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                  //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
                 //   ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
                    //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();

                    TBL_MP_CRM_SalesEnquiry EnquiryDBInfo = (new ServiceSalesEnquiry()).GetEnquiryMasterDBInfo(designModel.ENQUIRY_ID);
                    CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                    foreach (SalesEnquiryDesignBOQSheet boqSheet in designModel.SHEETS)
                    {
                        xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                        xlWorkSheet.Name = boqSheet.SheetName;
                        servicesCount = boqSheet.BOQ_SERVICES.Count();
                        totalColumns = COL_UOM + servicesCount + 1;
                        int asciVal = ((int)'D')+ servicesCount;
                        char character = (char)asciVal;
                        string lastColAlphName = character.ToString();
                        //FIRST ROW- HEADER HAVING COMPANY NAME
                        currRow = 1;
                        currCol = 1;
                        
                        if(compDBInfo!=null)
                        {
                            // COMPANY INFO
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow , totalColumns]];
                            //excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("{0}{1}", lastColAlphName));
                            excelCellrange.Value2 = compDBInfo.Company_name;
                            excelCellrange.Merge(misValue);
                            excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelCellrange.Font.FontStyle = "Calibri";
                            excelCellrange.Style.Font.Size = 20;
                            excelCellrange.Style.Font.Bold = true;
                            excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            currRow++;
                            excelCellrange = null;
                            //COMPANY ADDRESS
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                            excelCellrange.Value2 = compDBInfo.Address.ToString();
                            excelCellrange.Merge(misValue);
                            excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelCellrange.Cells.Font.FontStyle = "Arial";
                            excelCellrange.Cells.Font.Size = 12;
                            excelCellrange.Cells.Font.Bold = false;
                            excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                            currRow++;
                            excelCellrange = null;
                            //COMPANY ISO INFO
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                            excelCellrange.Value2 = "AN ISO 9001 : 2008 CERTIFIED COMPANY";
                            excelCellrange.Merge(misValue);
                            excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelCellrange.Font.FontStyle = "Calibri";
                            excelCellrange.Cells.Font.Size = 10;
                            excelCellrange.Cells.Font.Bold = false;
                            excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                            currRow++;

                            //COMPANY GST INFO
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                            excelCellrange.Value2 = "GST NO: "+ compDBInfo.GST_NO.ToString();
                            excelCellrange.Merge(misValue);
                            excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelCellrange.Font.FontStyle = "Calibri";
                            excelCellrange.Cells.Font.Size = 10;
                            excelCellrange.Cells.Font.Bold = false;
                            excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                            currRow++;


                        }

                        //SHEET TITLE ROW #DESIGNBOQ#
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                        excelCellrange.Value2 = "DESIGN BOQ  (" + boqSheet.SheetName+")";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        excelCellrange.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 14;
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        excelCellrange.Interior.Color = XlRgbColor.rgbBlack;

                        currRow++;

                        #region SALES ENQUIRY INFO
                        excelCellrange = null;
                        // DISPLAY PROJECT NAME
                        excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("B{0}",currRow));
                        excelCellrange.Value2 = "PROJECT" ;
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_ITEM_DESCRIPTION], xlWorkSheet.Cells[currRow, totalColumns]];
                        excelCellrange.Value2 = EnquiryDBInfo.Project_Name;
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;

                        //// DISPLAY TITLE DESIGN BOQ
                        //excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_UOM], xlWorkSheet.Cells[currRow+2, totalColumns]];
                        //excelCellrange.Value2 = "DESIGN BOQ";
                        //excelCellrange.Merge(misValue);
                        //excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        //excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        //excelCellrange.Font.FontStyle = "Calibri";
                        //excelCellrange.Style.Font.Size = 18;
                        //excelCellrange.Style.Font.Bold = true;
                        //excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                        //excelCellrange.Interior.Color = XlRgbColor.rgbLightBlue;

                        currRow++;
                        // DISPLAY SALES ENQUIRY NO AND DATE
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("B{0}", currRow));
                        excelCellrange.Value2 = "SALES ENQUIRY";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_ITEM_DESCRIPTION], xlWorkSheet.Cells[currRow, totalColumns]];
                        excelCellrange.Value2 = String.Format("{0} DT. {1}", EnquiryDBInfo.SalesEnquiry_No, EnquiryDBInfo.SalesEnquiry_Date.ToString("dd MMM yyyy"));
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;

                        currRow++;
                        // DISPLAY CLIENT INFO.
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("B{0}", currRow));
                        excelCellrange.Value2 = "CLIENT";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_ITEM_DESCRIPTION], xlWorkSheet.Cells[currRow, totalColumns]];
                        excelCellrange.Value2 = EnquiryDBInfo.Tbl_MP_Master_Party.PartyName;
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;
                        currRow++;

                        #endregion
                        #region TABLE COLUMN HEADER
                        //CREATE COLUMN HEADER FOR BOQ ITEMS
                        tableRowStartIndex = currRow;
                        // SRNO COLUMN HEADER
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("A{0}", currRow + 1));
                        excelCellrange.Value2 = "SR.";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;
                        xlWorkSheet.Columns[1].ColumnWidth = 5;

                        // ITEM CODE COLUMN HEADER
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.get_Range(string.Format("B{0}", currRow), string.Format("B{0}", currRow + 1));
                        excelCellrange.Value2 = "CODE";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                        xlWorkSheet.Columns[2].ColumnWidth = 13;

                        // ITEM PARTICULARS COLUMN HEADER
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.get_Range(string.Format("C{0}", currRow), string.Format("C{0}", currRow + 1));
                        excelCellrange.Value2 = "PARTICULARS";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                        xlWorkSheet.Columns[3].ColumnWidth = 47;

                        // UOM COLUMN HEADER
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.get_Range(string.Format("D{0}", currRow), string.Format("D{0}", currRow + 1));
                        excelCellrange.Value2 = "UNIT";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;
                        xlWorkSheet.Columns[4].ColumnWidth = 5;
                        // SERVICES COLUMN HEADERS
                        if(boqSheet.BOQ_SERVICES.Count>0)
                        { 
                            // SERVICES COLUMN HEADER
                            excelCellrange = null;
                            excelCellrange = xlWorkSheet.get_Range(string.Format("E{0}", currRow), string.Format("{0}{1}", lastColAlphName, currRow));
                            excelCellrange.Value2 = "SERVICES";
                            excelCellrange.Merge(misValue);
                            excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                            excelCellrange.Cells.Font.FontStyle = "Calibri";
                            excelCellrange.Cells.Font.Size = 11;
                            excelCellrange.Cells.Font.Bold = true;


                            //ADD SERVICE COLUMNS TO THE SHEET
                            currCol = COL_UOM + 1;
                            foreach (EnquiryBOQService service in boqSheet.BOQ_SERVICES)
                            {
                                xlWorkSheet.Columns[currCol].ColumnWidth = 4.8;
                                xlWorkSheet.Cells[currRow + 1, currCol] = service.Description;
                                currCol++;
                            }
                        }

                        // TOTAL COLUMN HEADER
                        excelCellrange = null;
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, totalColumns], xlWorkSheet.Cells[currRow + 1, totalColumns]];
                        excelCellrange.Value2 = "TOTAL";
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                        excelCellrange.Cells.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = true;
                        xlWorkSheet.Columns[totalColumns].ColumnWidth = 5.8;

                        #endregion  

                        currRow+=2;
                        tableRowStartIndex = currRow;
                        int srNO = 1;
                        int srNO_SUFFIX = 1;
                        // ADD BOQ ITEMS TO THE SHEET
                        if (boqSheet.datatableBOQ.Rows.Count > 0)
                        {
                             
                            DataView dv = boqSheet.datatableBOQ.DefaultView;
                            dv.Sort = string.Format("[{0}] ASC", serviceBOQ.COL_SERIAL_NO_SYS);
                            boqSheet.datatableBOQ = dv.ToTable();
                            //boqSheet.datatableBOQ.DefaultView.Sort = "Key ASC";
                            for(int i=0; i<boqSheet.datatableBOQ.Rows.Count;i++)
                            {
                                DataRow dtRow = boqSheet.datatableBOQ.Rows[i];
                                
                                xlWorkSheet.Cells[currRow, COL_SRNO] = srNO.ToString();
                                excelCellrange = null;
                                excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("A{0}", currRow));
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                                xlWorkSheet.Cells[currRow, COL_SRNO] = dtRow[serviceBOQ.COL_SERIAL_NO_SYS].ToString();
                                xlWorkSheet.Cells[currRow, COL_ITEM_CODE] = dtRow["ItemCode"].ToString();
                                xlWorkSheet.Cells[currRow, COL_ITEM_DESCRIPTION] = dtRow["ItemDescription"].ToString();
                                xlWorkSheet.Cells[currRow, COL_UOM] = dtRow["UOMName"].ToString();
                                xlWorkSheet.Cells[currRow, totalColumns] = dtRow["TotalQty"].ToString();
                                currCol = COL_UOM + 1;
                                foreach (EnquiryBOQService service in boqSheet.BOQ_SERVICES)
                                {
                                    xlWorkSheet.Cells[currRow, currCol++] = dtRow[service.Description].ToString();
                                }

                                //SET CELL STYPLE OF ITEM PARTICULARS
                                excelCellrange = null;
                                excelCellrange = xlWorkSheet.get_Range(string.Format("C{0}", currRow), string.Format("C{0}", currRow));
                                excelCellrange.WrapText = true;
                                excelCellrange.Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                excelCellrange.Style.Font.Size = 10;
                                excelCellrange.Style.Font.Bold = false;

                                if ((bool)dtRow["IsAssembly"])
                                {
                                    srNO_SUFFIX = 1;
                                    srNO--;
                                    // CHANGE BACKGROUND COLOR OF ASSEMBLY ITEM
                                    excelCellrange = null;
                                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                                    excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;
                                }


                                // INDENT CHILD ITEM PARTICULARS
                                if (dtRow["ParentItemID"].ToString() != "0")
                                {
                                    excelCellrange.IndentLevel = 3;
                                    xlWorkSheet.Cells[currRow, COL_SRNO] = string.Format("{0} ({1})", srNO, srNO_SUFFIX++);
                                    if(i< boqSheet.datatableBOQ.Rows.Count-1)
                                        if(boqSheet.datatableBOQ.Rows[i + 1]["ParentItemID"].ToString()=="0")
                                            srNO++;
                                }
                                else
                                    srNO++;

                                currRow++;
                            }
                        }

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                        excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                        currRow+=2;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                        excelCellrange.Value2 =string.Format("Website: {0},Email: {1},Tel.No: {2},Fax No: {3}",compDBInfo.WebAdd, compDBInfo.Email, compDBInfo.PhoneNo, compDBInfo.FaxNo);
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.Cells.Font.Size = 12;
                        excelCellrange.Cells.Font.Bold = false;
                        excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        //


                    }

                   // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();

                    xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    excelApp.Quit();

                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(excelApp);

                    MessageBox.Show("You can find the file " + fileNameWithPath, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                catch (Exception exHandle)
                {
                    string errMessage = exHandle.Message;
                    if (exHandle.InnerException != null) errMessage += string.Format("\n{0}", exHandle.InnerException.Message);
                    MessageBox.Show(errMessage, "ServiceExcelApp::ExportDesignBOQBookToExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    foreach (Process process in Process.GetProcessesByName("Excel"))
                        process.Kill();
                }

                //if (this.excelApp == null) excelApp = new Microsoft.Office.Interop.Excel.Application();
                //string workbookPath = fileNameWithPath;
                //Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath,0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",true, false, 0, true, false, false);
                //Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                //excelApp.Visible = true;
                //excelApp.DisplayAlerts = false;
                //foreach (SalesEnquiryDesignBOQSheet boqSheet in designModel.SHEETS)
                //{
                //    currRow = currCol = 1;
                //    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkbook.Worksheets.Add(System.Reflection.Missing.Value, excelWorkbook.Worksheets[excelWorkbook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                //    worksheet.Name = boqSheet.SheetName;
                //    System.Data.DataTable dt = boqSheet.datatableBOQ;
                //    //header row
                //    foreach (DataColumn col in dt.Columns)
                //    {
                //        worksheet.Cells[currRow, col.Ordinal + 1] = col.ColumnName;
                //    }
                //    // now we resize the columns

                //    Range excelCellrange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[dt.Rows.Count, dt.Columns.Count]];
                //    excelCellrange.EntireColumn.AutoFit();

                //}
                //excelApp.DisplayAlerts = false;
                //excelApp.Visible = true;
                //excelApp.ActiveWorkbook.PrintPreview();
                //excelApp.Quit();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceExcelApp::ExportDesignBOQBookToExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region SALES QUOTATION BOOK PRINTING
        public bool ExportSalesQuotationBOQToEXCEL(int quotationID, SalesQuotationBOQViewModel boqMODEL, SalesQuotationBOQExportConfigurationModel settings, string fileNameWithPath)
        {
            bool result = false;
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;
            int totalColumns = 0;
            int tableRowStartIndex = 0;
            Range excelCellrange = null;
            const int SUMMARY_COL_SRNO = 1;
            const int SUMMARY_COL_DESCIPTION = 2;
            const int SUMMARY_COL_MATERIAL = 3;
            const int SUMMARY_COL_INSTALLATION = 4;
            const int SUMMARY_COL_TOTAL = 5;
            decimal mTotalValue = 0;
            string _FontStyleName = "Cambria";

            string SPECIAL_NOTES = string.Empty;

            try
            {
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return false;
                }
                excelApp.DisplayAlerts = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excelApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
               // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
              //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();

                TBL_MP_CRM_SalesQuotation quotationDBInfo = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(quotationID);

                SPECIAL_NOTES = quotationDBInfo.SpecialNotes;
                CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                // CREATE SUMMARY SHEET TO BE FOLLOWED BY ALL BOQ-ITEMS SHEET
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkSheet.Name = "SUMMARY";
                currRow = 1;
                currCol = 1;

                xlWorkSheet.Columns[SUMMARY_COL_SRNO].ColumnWidth = 10;
                xlWorkSheet.Columns[SUMMARY_COL_DESCIPTION].ColumnWidth = 40;
                xlWorkSheet.Columns[SUMMARY_COL_MATERIAL].ColumnWidth = 25;
                xlWorkSheet.Columns[SUMMARY_COL_INSTALLATION].ColumnWidth = 25;
                xlWorkSheet.Columns[SUMMARY_COL_TOTAL].ColumnWidth = 25;

                #region FIRST ROW : TO,                    QUOTE NO.  XXXX-XXXX/XXXX
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = "TO,";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "QUOTE NO.";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = quotationDBInfo.Quotation_No;
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                #endregion
                currRow++;
                #region SECOND ROW : CLIENT,                    DATE.  DD MMM YYYY
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = quotationDBInfo.Tbl_MP_Master_Party.PartyName.ToUpper();
                excelCellrange.Merge(misValue);
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 13;
                excelCellrange.Cells.Font.Bold = true;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "DATE";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = quotationDBInfo.Quotation_Date.ToString("dd MMM yyyy");
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                #endregion
                currRow++;
                #region THIRD ROW : CLIENT ADRESS,                    REFERENCE.  -----------
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow + 3, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = quotationDBInfo.Tbl_MP_Master_Party.Tbl_MP_Master_PartyContact_Detail.FirstOrDefault().Address;
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;



                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "REFERENCE";
                excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                TBL_MP_Master_Employee emp = (new ServiceEmployee()).GetEmployeeDbRecordByID(quotationDBInfo.FK_RepresentativeID);
                if (emp != null) excelCellrange.Value2 = emp.EmployeeName;
                excelCellrange.Merge(misValue);
                #endregion  
                currRow++;
                #region THIRD ROW : ADRESS LINE CONTINUED                VALIDITY : XX DAYS
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "VALIDITY";
                excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0} days", quotationDBInfo.Quotation_ValidDays);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //excelCellrange.Merge(misValue);
                #endregion
                currRow++;
                #region FOURHT ROW : ADRESS LINE CONTINUED                PROJECT : PROJECT NAME
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "PROJECT";
                excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow + 1, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = quotationDBInfo.Project_Name;
                excelCellrange.Merge(misValue);
                #endregion

                currRow += 2;
                #region CLIENT GST NUMBER
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = string.Format("GST NO: {0}", quotationDBInfo.Tbl_MP_Master_Party.GSTNO);
                excelCellrange.Merge(misValue);
                #endregion
                currRow += 1;
                #region CLIENT CONTACT NAME
                BindingList<SelectListItem> contacts = (new ServiceSalesQuotation()).GetAllContactsForSalesQuotation(quotationID);
                string strContactName = string.Empty;
                foreach (SelectListItem itm in contacts)
                {
                    strContactName += itm.Description;
                }
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = (new ServiceSalesQuotation()).GetContactNamesForSalesQuotation(quotationID);
                excelCellrange.Merge(misValue);
                #endregion
                currRow += 1;
                tableRowStartIndex = currRow;
                #region TITLE TEXT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = "SUMMARY";
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 14;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;
                #endregion
                currRow++;
                #region TABLE HEADER SRNO DESCRIPTION SUPPLY INSTALLATION TOTAL
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO]];
                excelCellrange.Value2 = "SR.";
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "DESCRIPTION";
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = "SUPPLY";
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "INSTALLATION";
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = "TOTAL";
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                #endregion
                currRow++;

                #region TABLE - SUMMARY OF ALL BOQ SHEETS
                ServiceSalesQuotationBOQ _SERVICE = new ServiceSalesQuotationBOQ();
                foreach (DataRow boqRow in boqMODEL.SUMMARY.datatableBOQSheets.Rows)
                {

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                    excelCellrange.Value2 = boqRow[_SERVICE.COL_BOQ_SUMMARY_SRNO].ToString();
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                    excelCellrange.Value2 = boqRow[_SERVICE.COL_BOQ_SUMMARY_SHEETNAME].ToString();
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    mTotalValue = 0;
                    // MATERIAL SUPPLY 
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                    excelCellrange.NumberFormat = "#,##0.00";
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        mTotalValue += decimal.Parse(boqRow[_SERVICE.COL_BOQ_SUMMARY_MATERIAL_TOTAL].ToString());
                        excelCellrange.Value2 = String.Format("{0:0.00}", boqRow[_SERVICE.COL_BOQ_SUMMARY_MATERIAL_TOTAL]);
                    }
                    else
                        excelCellrange.Value2 = "-";

                    //INSTALLATION TOTAL
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 4]];
                    excelCellrange.NumberFormat = "#,##0.00";
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    if (settings.IncludeInstallationCharges)
                    {
                        mTotalValue += decimal.Parse(boqRow[_SERVICE.COL_BOQ_SUMMARY_INSTALLATION_TOTAL].ToString());
                        excelCellrange.Value2 = String.Format("{0:0.00}", boqRow[_SERVICE.COL_BOQ_SUMMARY_INSTALLATION_TOTAL]);
                    }
                    else
                        excelCellrange.Value2 = "-";

                    //excelCellrange.Cells.Font.Bold = true;
                    //excelCellrange.Merge(misValue);

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 5]];
                    excelCellrange.Value2 = String.Format("{0:0.00}", mTotalValue);
                    excelCellrange.NumberFormat = "#,##0.00";
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    //excelCellrange.Cells.Font.Bold = true;
                    //excelCellrange.Merge(misValue);
                    currRow++;

                }
                #endregion
                currRow++;
                #region SUMMARY TABLE FOOTER ROW - TOTAL

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "TOTAL";
                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.MaterialAmountForAllSheets.ToString());
                    excelCellrange.Value2 = string.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialAmountForAllSheets);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.InstallationAmountForAllSheets.ToString());
                    excelCellrange.Value2 = string.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationAmountForAllSheets);
                }
                else
                    excelCellrange.Value2 = "-";

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion
                currRow++;
                #region SUMMARY TABLE FOOTER ROW - DISCOUNT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "DISCOUNT";

                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.MaterialDiscountAmount;
                    excelCellrange.Value2 = string.Format("(@{0}{1}) {2:0.00}",
                    boqMODEL.SUMMARY.MaterialDiscount.ItemChargeValue,
                    (boqMODEL.SUMMARY.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ? "%" : "",
                    boqMODEL.SUMMARY.MaterialDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.InstallationDiscountAmount;
                    excelCellrange.Value2 = string.Format("(@{0}{1}) {2:0.00}",
                    boqMODEL.SUMMARY.InstallationDiscount.ItemChargeValue,
                    (boqMODEL.SUMMARY.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ? "%" : "",
                    boqMODEL.SUMMARY.InstallationDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion
                currRow++;
                #region ROW- AFTER DISCOUNT AMOUNTS 
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "TOTAL AFTER DISCOUNT";
                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.MaterialAmountForAllSheets - boqMODEL.SUMMARY.MaterialDiscountAmount;
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialAmountForAllSheets - boqMODEL.SUMMARY.MaterialDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.InstallationAmountForAllSheets - boqMODEL.SUMMARY.InstallationDiscountAmount;
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationAmountForAllSheets - boqMODEL.SUMMARY.InstallationDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion
                currRow++;
                #region ROW- GST AMOUNTS 
                // DISPLAY DISCOUNT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "GST";
                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);

                if (boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT != 0 || boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT != 0)
                {
                    string strGST = string.Empty;
                    currRow++;
                    strGST = string.Empty;
                    if (boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT != 0 && settings.IncludeMaterialSupplyCharges)
                    {
                        if (boqMODEL.SUMMARY.MaterialGST.CGST_AMOUNT != 0) strGST += string.Format("CGST:{0}% ", boqMODEL.SUMMARY.MaterialGST.CGST_PERCENT);
                        if (boqMODEL.SUMMARY.MaterialGST.SGST_AMOUNT != 0) strGST += string.Format("SGST:{0}% ", boqMODEL.SUMMARY.MaterialGST.SGST_PERCENT);
                        if (boqMODEL.SUMMARY.MaterialGST.IGST_AMOUNT != 0) strGST += string.Format("IGST:{0}% ", boqMODEL.SUMMARY.MaterialGST.IGST_PERCENT);
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                        excelCellrange.Value2 = string.Format("[ {0}] ", strGST);
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    }
                    strGST = string.Empty;
                    if (boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT != 0 && settings.IncludeInstallationCharges)
                    {
                        if (boqMODEL.SUMMARY.InstallationGST.CGST_AMOUNT != 0) strGST += string.Format("CGST:{0}% ", boqMODEL.SUMMARY.InstallationGST.CGST_PERCENT);
                        if (boqMODEL.SUMMARY.InstallationGST.SGST_AMOUNT != 0) strGST += string.Format("SGST:{0}% ", boqMODEL.SUMMARY.InstallationGST.SGST_PERCENT);
                        if (boqMODEL.SUMMARY.InstallationGST.IGST_AMOUNT != 0) strGST += string.Format("IGST:{0}% ", boqMODEL.SUMMARY.InstallationGST.IGST_PERCENT);
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                        excelCellrange.Value2 = string.Format("[ {0} ]", strGST);
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    }
                }
                #endregion
                currRow++;
                #region ROW- GRAND TOTAL INCLUDING GST
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "GRAND TOTAL";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                mTotalValue = 0;
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.MaterialFinalAmount.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialFinalAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.InstallationFinalAmount.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationFinalAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, 1], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                currRow++;
                xlWorkSheet.Rows.RowHeight = 20;
                excelApp.ActiveWindow.Zoom = 90;

                AddSalesQuotationBOQWorkSheets(boqMODEL, settings, xlWorkBook);

                // ADD TERMS & CONDITION SHEET
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkSheet.Name = " T&C ";
                xlWorkSheet.Activate();
                excelApp.ActiveWindow.Zoom = 90;
                List<SelectListItem> lstTNC = (new ServiceSalesQuotation()).GetAllTermsAndConditionForQuotation(quotationID);
                currCol = 1;
                currRow = 1;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 2]];
                excelCellrange.Value2 = "Terms and Conditions";
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Font.Size = 20;
                xlWorkSheet.Rows[currRow].RowHeight = 30;
                currRow += 2;

                // ADD SPECIAL NOTE  
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = "SPECIAL NOTE:";
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.ColumnWidth = 130;
                currRow++;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = SPECIAL_NOTES;
                excelCellrange.ColumnWidth = 130;
                excelCellrange.Cells.WrapText = true;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignJustify;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
                currRow++;
                currRow++;
                int numberIndex = 1;
                string prevTNCType = string.Empty;
                foreach (SelectListItem tncItem in lstTNC)
                {


                    if (prevTNCType != tncItem.Code)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                        excelCellrange.Value2 = numberIndex;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                        excelCellrange.Value2 = tncItem.Code;
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange.ColumnWidth = 130;
                        currRow++;
                        prevTNCType = tncItem.Code;
                        numberIndex++;
                    }

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = tncItem.Description;
                    excelCellrange.ColumnWidth = 130;
                    excelCellrange.Cells.WrapText = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignJustify;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
                    currRow++;
                }

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;


              // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();

                excelApp.ActiveWindow.Zoom = 90;
                xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                string strMessage = string.Format("Exported Sales Quotation BOQ [{0}]\nFile Name: ", quotationDBInfo.Quotation_No, fileNameWithPath);
                MessageBox.Show(strMessage, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::ExportSalesQuotationBOQToEXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
            return result;
        }
        private void AddSalesQuotationBOQWorkSheets(SalesQuotationBOQViewModel boqMODEL, SalesQuotationBOQExportConfigurationModel settings, Workbook xlWorkBook)
        {
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;

            int totalColumns = 0;
            int materialColumnsCount = 7;
            int installationColumnsCount = 7;

            int COL_MATERIAL_START_INDEX = 0;
            int COL_INSTALLATION_START_INDEX = 0;


            Range excelCellrange = null;

            const int COL_SRNO_SYS = 1;
            const int COL_SRNO_BOQ = 2;
            const int COL_HSN_CODE = 3;
            const int COL_ITEM_CODE = 4;
            const int COL_DESCIPTION = 5;
            const int COL_UNIT = 6;


            string _FontStyleName = "Cambria";
            object misValue = System.Reflection.Missing.Value;
            ServiceSalesQuotationBOQ BOQ_SERVICE = new ServiceSalesQuotationBOQ();
            try
            {
                foreach (SalesQuotationBOQSheet boqSheet in boqMODEL.SHEETS)
                {
                    DataView dv = boqSheet.datatableQuotationBOQ.DefaultView;
                    dv.Sort = string.Format("[{0}] ASC", BOQ_SERVICE.COL_SERIAL_NO_SYS);
                    boqSheet.datatableQuotationBOQ = dv.ToTable();

                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    xlWorkSheet.Name = boqSheet.SheetName;
                    xlWorkSheet.Activate();
                    excelApp.ActiveWindow.Zoom = 90;
                    xlWorkSheet.Application.ActiveWindow.SplitColumn = COL_UNIT;
                    xlWorkSheet.Application.ActiveWindow.SplitRow = 4;
                    xlWorkSheet.Application.ActiveWindow.FreezePanes = true;

                    servicesCount = boqSheet.BOQ_SERVICES.Count();
                    totalColumns = COL_UNIT + servicesCount + 1 + materialColumnsCount + 1 + installationColumnsCount + 1;
                    int asciVal = ((int)'F') + servicesCount;
                    char character = (char)asciVal;
                    string lastColAlphName = character.ToString();
                    //FIRST ROW- HEADER HAVING COMPANY NAME
                    currRow = 1;
                    currCol = 1;

                    xlWorkSheet.Columns.ColumnWidth = 25;
                    #region TABLE HEADER COLUMNS
                    //SHEET TITLE ROW - SHEET NAME 
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow + 1, totalColumns]];
                    excelCellrange.Value2 = boqSheet.SheetName;
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 14;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                    //excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;
                    xlWorkSheet.Rows[1].RowHeight = 35;
                    currRow += 2;

                    //SYS SR NO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_SYS], xlWorkSheet.Cells[currRow + 1, COL_SRNO_SYS]];
                    excelCellrange.Value2 = String.Format("BOQ\nSR.NO.");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 6;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //BOQ SR NO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_BOQ], xlWorkSheet.Cells[currRow + 1, COL_SRNO_BOQ]];
                    excelCellrange.Value2 = String.Format("#");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 4;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //HSN CODE OF ITEM
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_HSN_CODE], xlWorkSheet.Cells[currRow + 1, COL_HSN_CODE]];
                    excelCellrange.Value2 = String.Format("HSN\nCODE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //ITEM CODE 
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_ITEM_CODE], xlWorkSheet.Cells[currRow + 1, COL_ITEM_CODE]];
                    excelCellrange.Value2 = String.Format("ITEM\nCODE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //ITEM PARTICULARS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_DESCIPTION], xlWorkSheet.Cells[currRow + 1, COL_DESCIPTION]];
                    excelCellrange.Value2 = String.Format("PARTICULARS");
                    excelCellrange.ColumnWidth = 60;
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    //ITEM PARTICULARS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_UNIT], xlWorkSheet.Cells[currRow + 1, COL_UNIT]];
                    excelCellrange.Value2 = String.Format("UNIT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 6;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;

                    #region ADD SERVICES COLUMNS

                    int serviceColIndex = COL_UNIT + 1;
                    if (servicesCount > 0)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_UNIT + 1], xlWorkSheet.Cells[currRow, COL_UNIT + servicesCount + 1]];
                        excelCellrange.Value2 = String.Format("SERVICES");
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                        excelCellrange.Cells.Font.Bold = true;

                        foreach (EnquiryBOQService ITEM in boqSheet.BOQ_SERVICES)
                        {
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, serviceColIndex], xlWorkSheet.Cells[currRow + 1, serviceColIndex]];
                            excelCellrange.Value2 = ITEM.Description;
                            excelCellrange.ColumnWidth = 5;
                            excelCellrange.Cells.Font.Bold = true;
                            serviceColIndex++;
                        }

                    }

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, serviceColIndex], xlWorkSheet.Cells[currRow + 1, serviceColIndex]];
                    excelCellrange.Value2 = String.Format("TOTAL\nQTY");
                    excelCellrange.ColumnWidth = 6;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    serviceColIndex++;

                    #endregion

                    COL_MATERIAL_START_INDEX = serviceColIndex;
                    #region MATERIAL SUPPLY COLUMNS
                    //MERGE CELLS CAPTION :- MATERIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + materialColumnsCount - 1]];
                    excelCellrange.Value2 = String.Format("MATERIAL SUPPLY");
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    excelCellrange.Cells.Font.Bold = true;

                    // PRICE PER UNIT (SELLING COST)
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX]];
                    excelCellrange.Value2 = String.Format("UNIT\nPRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // PRICE (SELLING COST x QTY )
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 1], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 1]];
                    excelCellrange.Value2 = String.Format("PRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // DISCOUNT
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 2], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 2]];
                    excelCellrange.Value2 = String.Format("DISCOUNT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // SGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 3], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 3]];
                    excelCellrange.Value2 = String.Format("SGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // CGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 4]];
                    excelCellrange.Value2 = String.Format("CGST");
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.Cells.Font.Bold = true;
                    // IGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 5], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 5]];
                    excelCellrange.Value2 = String.Format("IGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // NET RATE OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 6], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 6]];
                    excelCellrange.Value2 = String.Format("NET\nRATE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // TOTAL AMOUNT OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 7]];
                    excelCellrange.Value2 = String.Format("TOTAL\nSUPPLY\nAMOUNT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.Interior.Color = XlRgbColor.rgbAqua;
                    #endregion

                    // FORMAT VALUES IN MATERIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 6]];
                    excelCellrange.Interior.Color = XlRgbColor.rgbBurlyWood;
                    COL_INSTALLATION_START_INDEX = COL_MATERIAL_START_INDEX + materialColumnsCount + 1;
                    #region INSTALLATION SERVICES COLUMNS
                    //MERGE CELLS CAPTION :- INSTALLATION AND SERVICES
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + installationColumnsCount - 1]];
                    excelCellrange.Value2 = String.Format("INSTALLATION AND SERVICES");
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    // PRICE PER UNIT (SELLING COST)
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX]];
                    excelCellrange.Value2 = String.Format("UNIT\nPRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;

                    // PRICE (SELLING COST x QTY )
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 1], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 1]];
                    excelCellrange.Value2 = String.Format("PRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // DISCOUNT
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 2], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 2]];
                    excelCellrange.Value2 = String.Format("DISCOUNT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // SGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 3], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 3]];
                    excelCellrange.Value2 = String.Format("SGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // CGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 4]];
                    excelCellrange.Value2 = String.Format("CGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // IGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 5], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 5]];
                    excelCellrange.Value2 = String.Format("IGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // NET RATE OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 6], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 6]];
                    excelCellrange.Value2 = String.Format("NET\nRATE");
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // TOTAL AMOUNT OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 7]];
                    excelCellrange.Value2 = String.Format("TOTAL\nINSTALLATION\nAMOUNT");
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.Interior.Color = XlRgbColor.rgbAqua;

                    #endregion
                    // FORMAT VALUES IN MATERIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 6]];
                    excelCellrange.Interior.Color = XlRgbColor.rgbLightGray;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_SYS], xlWorkSheet.Cells[currRow + 1, totalColumns]];
                    excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    #endregion
                    currRow += 2;

                    foreach (DataRow row in boqSheet.datatableQuotationBOQ.Rows)
                    {
                        // EXCLUDE CHILD ITEM IS NOT REQUIRED
                        if (settings.ExportParentItemsOnly && int.Parse(row[BOQ_SERVICE.COL_PARENT_INDEX].ToString()) != 0)
                            continue;
                        // SYS SR NO
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_SYS], xlWorkSheet.Cells[currRow, COL_SRNO_SYS]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_SERIAL_NO_SYS].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // BOQ SR NO
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_BOQ], xlWorkSheet.Cells[currRow, COL_SRNO_BOQ]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_SERIAL_NO_BOQ].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // HSN CODE
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_HSN_CODE], xlWorkSheet.Cells[currRow, COL_HSN_CODE]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_ITEM_HSN_CODE].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // ITEM CODE
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_ITEM_CODE], xlWorkSheet.Cells[currRow, COL_ITEM_CODE]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_ITEM_CODE].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // ITEM DESCRIPTION
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_DESCIPTION], xlWorkSheet.Cells[currRow, COL_DESCIPTION]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_ITEM_DESCRIPTION].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // UOM DESCRIPTION
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_UNIT], xlWorkSheet.Cells[currRow, COL_UNIT]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_UOM_CODE].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        serviceColIndex = COL_UNIT + 1;
                        // ADD SERVICE QUANTITIES
                        foreach (EnquiryBOQService serviceItem in boqSheet.BOQ_SERVICES)
                        {
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, serviceColIndex], xlWorkSheet.Cells[currRow, serviceColIndex]];
                            excelCellrange.Value2 = row[serviceItem.Description].ToString();
                            excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                            serviceColIndex++;
                        }
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, serviceColIndex], xlWorkSheet.Cells[currRow, serviceColIndex]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_TOTAL_QUANTITY].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        BOQItemChargesModel itmCharges = boqSheet.ITEM_CHARGES.Where(x => x.Index == int.Parse(row[BOQ_SERVICE.COL_ITEM_INDEX].ToString())).FirstOrDefault();
                        string strEXPR = string.Empty;

                        if (itmCharges != null)
                        {
                            if (settings.IncludeMaterialSupplyCharges)
                            {
                                #region MATERIAL SUPPLY COLUMNS
                                // SELLING PRICE PER UNIT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX]];
                                excelCellrange.Value2 = itmCharges.MaterialSellingCost;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // PRICE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 1], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 1]];
                                excelCellrange.Value2 = itmCharges.MaterialSellingCost * itmCharges.TotalQuantity;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // DISCOUNT ON MATERIAL
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 2], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 2]];
                                strEXPR = string.Empty;
                                if (itmCharges.MaterialDiscount.ItemChargeValue > 0)
                                {
                                    strEXPR = (itmCharges.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ?
                                    string.Format("{1:0.00}\n({0:0.00}%) ", itmCharges.MaterialDiscount.ItemChargeValue, itmCharges.MaterialDiscountAmount) :
                                    string.Format("{0:0.00}", itmCharges.MaterialDiscount.ItemChargeValue);
                                }
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // SGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 3], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 3]];
                                strEXPR = (itmCharges.MaterialGST.SGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00}%)", itmCharges.MaterialGST.SGST_PERCENT, itmCharges.MaterialGST.SGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // CGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4]];
                                strEXPR = (itmCharges.MaterialGST.CGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00}%)", itmCharges.MaterialGST.CGST_PERCENT, itmCharges.MaterialGST.CGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // IGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 5], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 5]];
                                strEXPR = (itmCharges.MaterialGST.IGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00}%)", itmCharges.MaterialGST.IGST_PERCENT, itmCharges.MaterialGST.IGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // NET RATE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                                excelCellrange.Value2 = itmCharges.MaterialNetRate;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // TOTAL MATERIAL SUPPLY AMOUNT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                                excelCellrange.Value2 = itmCharges.MaterialSupplyAmount;
                                excelCellrange.Cells.Font.Bold = true;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                excelCellrange.Interior.Color = XlRgbColor.rgbAqua;
                                // FORMAT ALL COLUMNS OF MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                                excelCellrange.Interior.Color = XlRgbColor.rgbDarkKhaki;
                                #endregion
                            }
                            if (settings.IncludeInstallationCharges)
                            {
                                #region INSTALLATION AND SERVICES COLUMN
                                // SELLING PRICE PER UNIT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX]];
                                strEXPR = string.Empty;
                                if (itmCharges.InstallationSellingCost > 0)
                                    strEXPR = (itmCharges.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ?
                                    string.Format("{1:0.00}\n({0:0.00}%)", itmCharges.InstallationDiscount.ItemChargeValue, itmCharges.InstallationDiscountAmount) :
                                    string.Format("{0:0.00}", itmCharges.InstallationDiscount.ItemChargeValue);
                                excelCellrange.Value2 = itmCharges.InstallationSellingCost;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // PRICE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 1], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 1]];
                                excelCellrange.Value2 = itmCharges.InstallationSellingCost * itmCharges.TotalQuantity;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // DISCOUNT ON MATERIAL
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 2], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 2]];
                                strEXPR = string.Empty;
                                if (itmCharges.InstallationDiscount.ItemChargeValue > 0)
                                {
                                    strEXPR = (itmCharges.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ?
                                    string.Format("\n{1:0.00}\n({0:0.00}%)", itmCharges.InstallationDiscount.ItemChargeValue, itmCharges.InstallationDiscountAmount) :
                                    string.Format("{0:0.00}", itmCharges.InstallationDiscount.ItemChargeValue);
                                }
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // SGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 3], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 3]];
                                strEXPR = (itmCharges.InstallationGST.SGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00})", itmCharges.InstallationGST.SGST_PERCENT, itmCharges.InstallationGST.SGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // CGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4]];
                                strEXPR = (itmCharges.InstallationGST.CGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00})", itmCharges.InstallationGST.CGST_PERCENT, itmCharges.InstallationGST.CGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // IGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 5], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 5]];
                                strEXPR = (itmCharges.InstallationGST.IGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00})", itmCharges.InstallationGST.IGST_PERCENT, itmCharges.InstallationGST.IGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // NET RATE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                                excelCellrange.Value2 = itmCharges.InstallationNetRate;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // TOTAL MATERIAL SUPPLY AMOUNT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                                excelCellrange.Value2 = itmCharges.InstallationAmount;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                excelCellrange.Cells.Font.Bold = true;
                                excelCellrange.Interior.Color = XlRgbColor.rgbAqua;
                                // FORMAT ALL COLUMNS OF MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                                excelCellrange.Interior.Color = XlRgbColor.rgbKhaki;
                                #endregion
                            }
                        }

                        currRow++;
                    }

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, COL_SRNO_SYS], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region NET AMOUNT MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "NET AMOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyAmount
                            - boqSheet.SUMMARY.MaterialSupplyDiscountAmount
                            - boqSheet.SUMMARY.MaterialSupplySGSTAmount
                            - boqSheet.SUMMARY.MaterialSupplyCGSTAmount
                            - boqSheet.SUMMARY.MaterialSupplyIGSTAmount;

                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region NET AMOUNT INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "NET AMOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationAmount - boqSheet.SUMMARY.InstallationDiscountAmount - boqSheet.SUMMARY.InstallationSGSTAmount - boqSheet.SUMMARY.InstallationCGSTAmount - boqSheet.SUMMARY.InstallationIGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;

                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region DISCOUNT ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL DISCOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyDiscountAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region DISCOUNT ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL DISCOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationDiscountAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }

                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL SGST ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL SGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplySGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL SGST ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL SGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationSGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;

                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL CGST ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL CGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyCGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL CGST ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL CGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationCGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL IGST ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL IGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyIGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL IGST ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL IGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationIGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL OF MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "GROSS TOTAL";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL OF INSTLAATION SERVICES
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "GROSS TOTAL";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    xlWorkSheet.get_Range("A:A", misValue).EntireColumn.Hidden = true;

                    if (!settings.IncludeMaterialSupplyCharges)
                    {
                        for (int I = COL_MATERIAL_START_INDEX; I <= COL_MATERIAL_START_INDEX + 7; I++)
                        {
                            string colChar = AppCommon.EXCELColumnIndexToColumnLetter(I);
                            xlWorkSheet.get_Range(string.Format("{0}:{0}", colChar), misValue).EntireColumn.Hidden = true;
                        }
                    }
                    if (!settings.IncludeInstallationCharges)
                    {
                        for (int I = COL_INSTALLATION_START_INDEX; I <= COL_INSTALLATION_START_INDEX + 7; I++)
                        {
                            string colChar = AppCommon.EXCELColumnIndexToColumnLetter(I);
                            xlWorkSheet.get_Range(string.Format("{0}:{0}", colChar), misValue).EntireColumn.Hidden = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::AddSalesQuotationWorkSheets", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region SALES ORDER BOOK PRINTING
        public bool ExportSalesOrderBOQToEXCEL(int orderID, SalesOrderBOQViewModel boqMODEL, SalesQuotationBOQExportConfigurationModel settings, string fileNameWithPath)
        {
            bool result = false;
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;
            int totalColumns = 0;
            int tableRowStartIndex = 0;
            Range excelCellrange = null;
            const int SUMMARY_COL_SRNO = 1;
            const int SUMMARY_COL_DESCIPTION = 2;
            const int SUMMARY_COL_MATERIAL = 3;
            const int SUMMARY_COL_INSTALLATION = 4;
            const int SUMMARY_COL_TOTAL = 5;
            decimal mTotalValue = 0;
            string _FontStyleName = "Cambria";

            string SPECIAL_NOTES = string.Empty;

            try
            {
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return false;
                }
                excelApp.DisplayAlerts = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excelApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
             //   ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
             //   ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();

                TBL_MP_CRM_SalesOrder orderDBInfo = (new ServiceSalesOrder()).GetSalesOrderDBInfoByID(orderID);

                SPECIAL_NOTES = ""; // orderDBInfo.SpecialNotes;
                CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                // CREATE SUMMARY SHEET TO BE FOLLOWED BY ALL BOQ-ITEMS SHEET
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkSheet.Name = "SUMMARY";
                currRow = 1;
                currCol = 1;

                xlWorkSheet.Columns[SUMMARY_COL_SRNO].ColumnWidth = 10;
                xlWorkSheet.Columns[SUMMARY_COL_DESCIPTION].ColumnWidth = 40;
                xlWorkSheet.Columns[SUMMARY_COL_MATERIAL].ColumnWidth = 25;
                xlWorkSheet.Columns[SUMMARY_COL_INSTALLATION].ColumnWidth = 25;
                xlWorkSheet.Columns[SUMMARY_COL_TOTAL].ColumnWidth = 25;

                #region FIRST ROW : TO,                    QUOTE NO.  XXXX-XXXX/XXXX
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = "TO,";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "QUOTE NO.";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = orderDBInfo.SalesOrderNo;
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                #endregion
                currRow++;
                #region SECOND ROW : CLIENT,                    DATE.  DD MMM YYYY
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = orderDBInfo.Tbl_MP_Master_Party.PartyName.ToUpper();
                excelCellrange.Merge(misValue);
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 13;
                excelCellrange.Cells.Font.Bold = true;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "DATE";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = orderDBInfo.SalesOrderDate.ToString("dd MMM yyyy");
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                //excelCellrange.Cells.Font.Bold = true;

                #endregion
                currRow++;
                #region THIRD ROW : CLIENT ADRESS,                    REFERENCE.  -----------
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow + 3, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = orderDBInfo.Tbl_MP_Master_Party.Tbl_MP_Master_PartyContact_Detail.FirstOrDefault().Address;
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;



                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "REFERENCE";
                excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                TBL_MP_Master_Employee emp = (new ServiceEmployee()).GetEmployeeDbRecordByID((int)orderDBInfo.FK_BOQRepresentativeID);
                if (emp != null) excelCellrange.Value2 = emp.EmployeeName;
                excelCellrange.Merge(misValue);
                #endregion  
                currRow++;
                #region THIRD ROW : ADRESS LINE CONTINUED                VALIDITY : XX DAYS
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "VALIDITY";
                excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                //excelCellrange.Value2 = string.Format("{0} days", orderDBInfo.Quotation_ValidDays);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //excelCellrange.Merge(misValue);
                #endregion
                currRow++;
                #region FOURHT ROW : ADRESS LINE CONTINUED                PROJECT : PROJECT NAME
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "PROJECT";
                excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow + 1, SUMMARY_COL_TOTAL]];
                //excelCellrange.Value2 = orderDBInfo.Project_Name;
                excelCellrange.Merge(misValue);
                #endregion

                currRow += 2;
                #region CLIENT GST NUMBER
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = string.Format("GST NO: {0}", orderDBInfo.Tbl_MP_Master_Party.GSTNO);
                excelCellrange.Merge(misValue);
                #endregion
                currRow += 1;
                #region CLIENT CONTACT NAME
                BindingList<SelectListItem> contacts = (new ServiceSalesQuotation()).GetAllContactsForSalesQuotation(orderID);
                string strContactName = string.Empty;
                foreach (SelectListItem itm in contacts)
                {
                    strContactName += itm.Description;
                }
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = (new ServiceSalesQuotation()).GetContactNamesForSalesQuotation(orderID);
                excelCellrange.Merge(misValue);
                #endregion
                currRow += 1;
                tableRowStartIndex = currRow;
                #region TITLE TEXT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = "SUMMARY";
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 14;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;
                #endregion
                currRow++;
                #region TABLE HEADER SRNO DESCRIPTION SUPPLY INSTALLATION TOTAL
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO]];
                excelCellrange.Value2 = "SR.";
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "DESCRIPTION";
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                excelCellrange.Value2 = "SUPPLY";
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                excelCellrange.Value2 = "INSTALLATION";
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = "TOTAL";
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Merge(misValue);
                #endregion
                currRow++;

                #region TABLE - SUMMARY OF ALL BOQ SHEETS
                ServiceSalesOrderBOQ _SERVICE = new ServiceSalesOrderBOQ();
                foreach (DataRow boqRow in boqMODEL.SUMMARY.datatableBOQSheets.Rows)
                {

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                    excelCellrange.Value2 = boqRow[_SERVICE.COL_BOQ_SUMMARY_SRNO].ToString();
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                    excelCellrange.Value2 = boqRow[_SERVICE.COL_BOQ_SUMMARY_SHEETNAME].ToString();
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    mTotalValue = 0;
                    // MATERIAL SUPPLY 
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                    excelCellrange.NumberFormat = "#,##0.00";
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        mTotalValue += decimal.Parse(boqRow[_SERVICE.COL_BOQ_SUMMARY_MATERIAL_TOTAL].ToString());
                        excelCellrange.Value2 = String.Format("{0:0.00}", boqRow[_SERVICE.COL_BOQ_SUMMARY_MATERIAL_TOTAL]);
                    }
                    else
                        excelCellrange.Value2 = "-";

                    //INSTALLATION TOTAL
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 4]];
                    excelCellrange.NumberFormat = "#,##0.00";
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    if (settings.IncludeInstallationCharges)
                    {
                        mTotalValue += decimal.Parse(boqRow[_SERVICE.COL_BOQ_SUMMARY_INSTALLATION_TOTAL].ToString());
                        excelCellrange.Value2 = String.Format("{0:0.00}", boqRow[_SERVICE.COL_BOQ_SUMMARY_INSTALLATION_TOTAL]);
                    }
                    else
                        excelCellrange.Value2 = "-";

                    //excelCellrange.Cells.Font.Bold = true;
                    //excelCellrange.Merge(misValue);

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 5]];
                    excelCellrange.Value2 = String.Format("{0:0.00}", mTotalValue);
                    excelCellrange.NumberFormat = "#,##0.00";
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    //excelCellrange.Cells.Font.Bold = true;
                    //excelCellrange.Merge(misValue);
                    currRow++;

                }
                #endregion
                currRow++;
                #region SUMMARY TABLE FOOTER ROW - TOTAL

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "TOTAL";
                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.MaterialAmountForAllSheets.ToString());
                    excelCellrange.Value2 = string.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialAmountForAllSheets);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.InstallationAmountForAllSheets.ToString());
                    excelCellrange.Value2 = string.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationAmountForAllSheets);
                }
                else
                    excelCellrange.Value2 = "-";

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion
                currRow++;
                #region SUMMARY TABLE FOOTER ROW - DISCOUNT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "DISCOUNT";

                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.MaterialDiscountAmount;
                    excelCellrange.Value2 = string.Format("(@{0}{1}) {2:0.00}",
                    boqMODEL.SUMMARY.MaterialDiscount.ItemChargeValue,
                    (boqMODEL.SUMMARY.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ? "%" : "",
                    boqMODEL.SUMMARY.MaterialDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.InstallationDiscountAmount;
                    excelCellrange.Value2 = string.Format("(@{0}{1}) {2:0.00}",
                    boqMODEL.SUMMARY.InstallationDiscount.ItemChargeValue,
                    (boqMODEL.SUMMARY.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ? "%" : "",
                    boqMODEL.SUMMARY.InstallationDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion
                currRow++;
                #region ROW- AFTER DISCOUNT AMOUNTS 
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "TOTAL AFTER DISCOUNT";
                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.MaterialAmountForAllSheets - boqMODEL.SUMMARY.MaterialDiscountAmount;
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialAmountForAllSheets - boqMODEL.SUMMARY.MaterialDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += boqMODEL.SUMMARY.InstallationAmountForAllSheets - boqMODEL.SUMMARY.InstallationDiscountAmount;
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationAmountForAllSheets - boqMODEL.SUMMARY.InstallationDiscountAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion
                currRow++;
                #region ROW- GST AMOUNTS 
                // DISPLAY DISCOUNT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "GST";
                mTotalValue = 0;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);

                if (boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT != 0 || boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT != 0)
                {
                    string strGST = string.Empty;
                    currRow++;
                    strGST = string.Empty;
                    if (boqMODEL.SUMMARY.MaterialGST.GST_TOTAL_AMOUNT != 0 && settings.IncludeMaterialSupplyCharges)
                    {
                        if (boqMODEL.SUMMARY.MaterialGST.CGST_AMOUNT != 0) strGST += string.Format("CGST:{0}% ", boqMODEL.SUMMARY.MaterialGST.CGST_PERCENT);
                        if (boqMODEL.SUMMARY.MaterialGST.SGST_AMOUNT != 0) strGST += string.Format("SGST:{0}% ", boqMODEL.SUMMARY.MaterialGST.SGST_PERCENT);
                        if (boqMODEL.SUMMARY.MaterialGST.IGST_AMOUNT != 0) strGST += string.Format("IGST:{0}% ", boqMODEL.SUMMARY.MaterialGST.IGST_PERCENT);
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                        excelCellrange.Value2 = string.Format("[ {0}] ", strGST);
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    }
                    strGST = string.Empty;
                    if (boqMODEL.SUMMARY.InstallationGST.GST_TOTAL_AMOUNT != 0 && settings.IncludeInstallationCharges)
                    {
                        if (boqMODEL.SUMMARY.InstallationGST.CGST_AMOUNT != 0) strGST += string.Format("CGST:{0}% ", boqMODEL.SUMMARY.InstallationGST.CGST_PERCENT);
                        if (boqMODEL.SUMMARY.InstallationGST.SGST_AMOUNT != 0) strGST += string.Format("SGST:{0}% ", boqMODEL.SUMMARY.InstallationGST.SGST_PERCENT);
                        if (boqMODEL.SUMMARY.InstallationGST.IGST_AMOUNT != 0) strGST += string.Format("IGST:{0}% ", boqMODEL.SUMMARY.InstallationGST.IGST_PERCENT);
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                        excelCellrange.Value2 = string.Format("[ {0} ]", strGST);
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    }
                }
                #endregion
                currRow++;
                #region ROW- GRAND TOTAL INCLUDING GST
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION], xlWorkSheet.Cells[currRow, SUMMARY_COL_DESCIPTION]];
                excelCellrange.Value2 = "GRAND TOTAL";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_MATERIAL]];
                mTotalValue = 0;
                if (settings.IncludeMaterialSupplyCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.MaterialFinalAmount.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.MaterialFinalAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION], xlWorkSheet.Cells[currRow, SUMMARY_COL_INSTALLATION]];
                if (settings.IncludeInstallationCharges)
                {
                    mTotalValue += decimal.Parse(boqMODEL.SUMMARY.InstallationFinalAmount.ToString());
                    excelCellrange.Value2 = String.Format("{0:0.00}", boqMODEL.SUMMARY.InstallationFinalAmount);
                }
                else
                    excelCellrange.Value2 = "-";
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Value2 = string.Format("{0:0.00}", mTotalValue);
                #endregion

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, SUMMARY_COL_MATERIAL], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, SUMMARY_COL_SRNO], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, 1], xlWorkSheet.Cells[currRow, SUMMARY_COL_TOTAL]];
                excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                currRow++;
                xlWorkSheet.Rows.RowHeight = 20;
                excelApp.ActiveWindow.Zoom = 90;

                AddSalesOrderBOQWorkSheets(boqMODEL, settings, xlWorkBook);

                #region ADD TERMS & CONDITION SHEET
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkSheet.Name = " T&C ";
                xlWorkSheet.Activate();
                excelApp.ActiveWindow.Zoom = 90;
                List<SelectListItem> lstTNC = (new ServiceSalesQuotation()).GetAllTermsAndConditionForQuotation(orderID);
                currCol = 1;
                currRow = 1;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 2]];
                excelCellrange.Value2 = "Terms and Conditions";
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Font.Size = 20;
                xlWorkSheet.Rows[currRow].RowHeight = 30;
                currRow += 2;


                // ADD SPECIAL NOTE  
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = "SPECIAL NOTE:";
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.ColumnWidth = 130;
                currRow++;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = SPECIAL_NOTES;
                excelCellrange.ColumnWidth = 130;
                excelCellrange.Cells.WrapText = true;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignJustify;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
                currRow++;
                currRow++;
                int numberIndex = 1;
                string prevTNCType = string.Empty;
                foreach (SelectListItem tncItem in lstTNC)
                {


                    if (prevTNCType != tncItem.Code)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                        excelCellrange.Value2 = numberIndex;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                        excelCellrange.Value2 = tncItem.Code;
                        excelCellrange.Cells.Font.Bold = true;
                        excelCellrange.ColumnWidth = 130;
                        currRow++;
                        prevTNCType = tncItem.Code;
                        numberIndex++;
                    }

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = tncItem.Description;
                    excelCellrange.ColumnWidth = 130;
                    excelCellrange.Cells.WrapText = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignJustify;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignJustify;
                    currRow++;
                }
                #endregion

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;


              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();

                excelApp.ActiveWindow.Zoom = 90;
                xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                string strMessage = string.Format("Exported Sales Quotation BOQ [{0}]\nFile Name: ", orderDBInfo.SalesOrderNo, fileNameWithPath);
                MessageBox.Show(strMessage, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::ExportSalesQuotationBOQToEXCEL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
            return result;
        }
        private void AddSalesOrderBOQWorkSheets(SalesOrderBOQViewModel boqMODEL, SalesQuotationBOQExportConfigurationModel settings, Workbook xlWorkBook)
        {
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;

            int totalColumns = 0;
            int materialColumnsCount = 7;
            int installationColumnsCount = 7;

            int COL_MATERIAL_START_INDEX = 0;
            int COL_INSTALLATION_START_INDEX = 0;


            Range excelCellrange = null;

            const int COL_SRNO_SYS = 1;
            const int COL_SRNO_BOQ = 2;
            const int COL_HSN_CODE = 3;
            const int COL_ITEM_CODE = 4;
            const int COL_DESCIPTION = 5;
            const int COL_UNIT = 6;


            string _FontStyleName = "Cambria";
            object misValue = System.Reflection.Missing.Value;
            ServiceSalesQuotationBOQ BOQ_SERVICE = new ServiceSalesQuotationBOQ();
            try
            {
                foreach (SalesOrderBOQSheet boqSheet in boqMODEL.SHEETS)
                {
                    DataView dv = boqSheet.datatableQuotationBOQ.DefaultView;
                    dv.Sort = string.Format("[{0}] ASC", BOQ_SERVICE.COL_SERIAL_NO_SYS);
                    boqSheet.datatableQuotationBOQ = dv.ToTable();

                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                    xlWorkSheet.Name = boqSheet.SheetName;
                    xlWorkSheet.Activate();
                    excelApp.ActiveWindow.Zoom = 90;
                    xlWorkSheet.Application.ActiveWindow.SplitColumn = COL_UNIT;
                    xlWorkSheet.Application.ActiveWindow.SplitRow = 4;
                    xlWorkSheet.Application.ActiveWindow.FreezePanes = true;

                    servicesCount = boqSheet.BOQ_SERVICES.Count();
                    totalColumns = COL_UNIT + servicesCount + 1 + materialColumnsCount + 1 + installationColumnsCount + 1;
                    int asciVal = ((int)'F') + servicesCount;
                    char character = (char)asciVal;
                    string lastColAlphName = character.ToString();
                    //FIRST ROW- HEADER HAVING COMPANY NAME
                    currRow = 1;
                    currCol = 1;

                    xlWorkSheet.Columns.ColumnWidth = 25;
                    #region TABLE HEADER COLUMNS
                    //SHEET TITLE ROW - SHEET NAME 
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow + 1, totalColumns]];
                    excelCellrange.Value2 = boqSheet.SheetName;
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 14;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkBlue);
                    //excelCellrange.Interior.Color = XlRgbColor.rgbLightSteelBlue;
                    xlWorkSheet.Rows[1].RowHeight = 35;
                    currRow += 2;

                    //SYS SR NO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_SYS], xlWorkSheet.Cells[currRow + 1, COL_SRNO_SYS]];
                    excelCellrange.Value2 = String.Format("BOQ\nSR.NO.");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 6;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //BOQ SR NO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_BOQ], xlWorkSheet.Cells[currRow + 1, COL_SRNO_BOQ]];
                    excelCellrange.Value2 = String.Format("#");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 4;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //HSN CODE OF ITEM
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_HSN_CODE], xlWorkSheet.Cells[currRow + 1, COL_HSN_CODE]];
                    excelCellrange.Value2 = String.Format("HSN\nCODE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //ITEM CODE 
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_ITEM_CODE], xlWorkSheet.Cells[currRow + 1, COL_ITEM_CODE]];
                    excelCellrange.Value2 = String.Format("ITEM\nCODE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    //ITEM PARTICULARS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_DESCIPTION], xlWorkSheet.Cells[currRow + 1, COL_DESCIPTION]];
                    excelCellrange.Value2 = String.Format("PARTICULARS");
                    excelCellrange.ColumnWidth = 60;
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    //ITEM PARTICULARS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_UNIT], xlWorkSheet.Cells[currRow + 1, COL_UNIT]];
                    excelCellrange.Value2 = String.Format("UNIT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 6;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;

                    #region ADD SERVICES COLUMNS

                    int serviceColIndex = COL_UNIT + 1;
                    if (servicesCount > 0)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_UNIT + 1], xlWorkSheet.Cells[currRow, COL_UNIT + servicesCount + 1]];
                        excelCellrange.Value2 = String.Format("SERVICES");
                        excelCellrange.Merge(misValue);
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                        excelCellrange.Cells.Font.Bold = true;

                        foreach (EnquiryBOQService ITEM in boqSheet.BOQ_SERVICES)
                        {
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, serviceColIndex], xlWorkSheet.Cells[currRow + 1, serviceColIndex]];
                            excelCellrange.Value2 = ITEM.Description;
                            excelCellrange.ColumnWidth = 5;
                            excelCellrange.Cells.Font.Bold = true;
                            serviceColIndex++;
                        }

                    }

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, serviceColIndex], xlWorkSheet.Cells[currRow + 1, serviceColIndex]];
                    excelCellrange.Value2 = String.Format("TOTAL\nQTY");
                    excelCellrange.ColumnWidth = 6;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    serviceColIndex++;

                    #endregion

                    COL_MATERIAL_START_INDEX = serviceColIndex;
                    #region MATERIAL SUPPLY COLUMNS
                    //MERGE CELLS CAPTION :- MATERIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + materialColumnsCount - 1]];
                    excelCellrange.Value2 = String.Format("MATERIAL SUPPLY");
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    excelCellrange.Cells.Font.Bold = true;

                    // PRICE PER UNIT (SELLING COST)
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX]];
                    excelCellrange.Value2 = String.Format("UNIT\nPRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // PRICE (SELLING COST x QTY )
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 1], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 1]];
                    excelCellrange.Value2 = String.Format("PRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // DISCOUNT
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 2], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 2]];
                    excelCellrange.Value2 = String.Format("DISCOUNT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // SGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 3], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 3]];
                    excelCellrange.Value2 = String.Format("SGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // CGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 4]];
                    excelCellrange.Value2 = String.Format("CGST");
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.Cells.Font.Bold = true;
                    // IGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 5], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 5]];
                    excelCellrange.Value2 = String.Format("IGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // NET RATE OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 6], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 6]];
                    excelCellrange.Value2 = String.Format("NET\nRATE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.Cells.Font.Bold = true;
                    // TOTAL AMOUNT OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 7]];
                    excelCellrange.Value2 = String.Format("TOTAL\nSUPPLY\nAMOUNT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.Interior.Color = XlRgbColor.rgbAqua;
                    #endregion

                    // FORMAT VALUES IN MATERIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_MATERIAL_START_INDEX + 6]];
                    excelCellrange.Interior.Color = XlRgbColor.rgbBurlyWood;
                    COL_INSTALLATION_START_INDEX = COL_MATERIAL_START_INDEX + materialColumnsCount + 1;
                    #region INSTALLATION SERVICES COLUMNS
                    //MERGE CELLS CAPTION :- INSTALLATION AND SERVICES
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + installationColumnsCount - 1]];
                    excelCellrange.Value2 = String.Format("INSTALLATION AND SERVICES");
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    // PRICE PER UNIT (SELLING COST)
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX]];
                    excelCellrange.Value2 = String.Format("UNIT\nPRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;

                    // PRICE (SELLING COST x QTY )
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 1], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 1]];
                    excelCellrange.Value2 = String.Format("PRICE");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // DISCOUNT
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 2], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 2]];
                    excelCellrange.Value2 = String.Format("DISCOUNT");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 10;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // SGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 3], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 3]];
                    excelCellrange.Value2 = String.Format("SGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // CGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 4]];
                    excelCellrange.Value2 = String.Format("CGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // IGST
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 5], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 5]];
                    excelCellrange.Value2 = String.Format("IGST");
                    excelCellrange.Merge(misValue);
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // NET RATE OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 6], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 6]];
                    excelCellrange.Value2 = String.Format("NET\nRATE");
                    excelCellrange.ColumnWidth = 8;
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    // TOTAL AMOUNT OF MARETIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 7]];
                    excelCellrange.Value2 = String.Format("TOTAL\nINSTALLATION\nAMOUNT");
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    excelCellrange.ColumnWidth = 13;
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = true;
                    excelCellrange.Interior.Color = XlRgbColor.rgbAqua;

                    #endregion
                    // FORMAT VALUES IN MATERIAL SUPPLY
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow + 1, COL_INSTALLATION_START_INDEX + 6]];
                    excelCellrange.Interior.Color = XlRgbColor.rgbLightGray;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_SYS], xlWorkSheet.Cells[currRow + 1, totalColumns]];
                    excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    #endregion
                    currRow += 2;

                    foreach (DataRow row in boqSheet.datatableQuotationBOQ.Rows)
                    {
                        // EXCLUDE CHILD ITEM IS NOT REQUIRED
                        if (settings.ExportParentItemsOnly && int.Parse(row[BOQ_SERVICE.COL_PARENT_INDEX].ToString()) != 0)
                            continue;
                        // SYS SR NO
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_SYS], xlWorkSheet.Cells[currRow, COL_SRNO_SYS]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_SERIAL_NO_SYS].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // BOQ SR NO
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_SRNO_BOQ], xlWorkSheet.Cells[currRow, COL_SRNO_BOQ]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_SERIAL_NO_BOQ].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // HSN CODE
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_HSN_CODE], xlWorkSheet.Cells[currRow, COL_HSN_CODE]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_ITEM_HSN_CODE].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // ITEM CODE
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_ITEM_CODE], xlWorkSheet.Cells[currRow, COL_ITEM_CODE]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_ITEM_CODE].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // ITEM DESCRIPTION
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_DESCIPTION], xlWorkSheet.Cells[currRow, COL_DESCIPTION]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_ITEM_DESCRIPTION].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        // UOM DESCRIPTION
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_UNIT], xlWorkSheet.Cells[currRow, COL_UNIT]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_UOM_CODE].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                        serviceColIndex = COL_UNIT + 1;
                        // ADD SERVICE QUANTITIES
                        foreach (EnquiryBOQService serviceItem in boqSheet.BOQ_SERVICES)
                        {
                            excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, serviceColIndex], xlWorkSheet.Cells[currRow, serviceColIndex]];
                            excelCellrange.Value2 = row[serviceItem.Description].ToString();
                            excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                            serviceColIndex++;
                        }
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, serviceColIndex], xlWorkSheet.Cells[currRow, serviceColIndex]];
                        excelCellrange.Value2 = row[BOQ_SERVICE.COL_TOTAL_QUANTITY].ToString();
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                        BOQItemChargesModel itmCharges = boqSheet.ITEM_CHARGES.Where(x => x.Index == int.Parse(row[BOQ_SERVICE.COL_ITEM_INDEX].ToString())).FirstOrDefault();
                        string strEXPR = string.Empty;

                        if (itmCharges != null)
                        {
                            if (settings.IncludeMaterialSupplyCharges)
                            {
                                #region MATERIAL SUPPLY COLUMNS
                                // SELLING PRICE PER UNIT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX]];
                                excelCellrange.Value2 = itmCharges.MaterialSellingCost;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // PRICE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 1], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 1]];
                                excelCellrange.Value2 = itmCharges.MaterialSellingCost * itmCharges.TotalQuantity;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // DISCOUNT ON MATERIAL
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 2], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 2]];
                                strEXPR = string.Empty;
                                if (itmCharges.MaterialDiscount.ItemChargeValue > 0)
                                {
                                    strEXPR = (itmCharges.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ?
                                    string.Format("{1:0.00}\n({0:0.00}%) ", itmCharges.MaterialDiscount.ItemChargeValue, itmCharges.MaterialDiscountAmount) :
                                    string.Format("{0:0.00}", itmCharges.MaterialDiscount.ItemChargeValue);
                                }
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // SGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 3], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 3]];
                                strEXPR = (itmCharges.MaterialGST.SGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00}%)", itmCharges.MaterialGST.SGST_PERCENT, itmCharges.MaterialGST.SGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // CGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4]];
                                strEXPR = (itmCharges.MaterialGST.CGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00}%)", itmCharges.MaterialGST.CGST_PERCENT, itmCharges.MaterialGST.CGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // IGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 5], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 5]];
                                strEXPR = (itmCharges.MaterialGST.IGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00}%)", itmCharges.MaterialGST.IGST_PERCENT, itmCharges.MaterialGST.IGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // NET RATE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                                excelCellrange.Value2 = itmCharges.MaterialNetRate;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // TOTAL MATERIAL SUPPLY AMOUNT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                                excelCellrange.Value2 = itmCharges.MaterialSupplyAmount;
                                excelCellrange.Cells.Font.Bold = true;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                excelCellrange.Interior.Color = XlRgbColor.rgbAqua;
                                // FORMAT ALL COLUMNS OF MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                                excelCellrange.Interior.Color = XlRgbColor.rgbDarkKhaki;
                                #endregion
                            }
                            if (settings.IncludeInstallationCharges)
                            {
                                #region INSTALLATION AND SERVICES COLUMN
                                // SELLING PRICE PER UNIT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX]];
                                strEXPR = string.Empty;
                                if (itmCharges.InstallationSellingCost > 0)
                                    strEXPR = (itmCharges.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ?
                                    string.Format("{1:0.00}\n({0:0.00}%)", itmCharges.InstallationDiscount.ItemChargeValue, itmCharges.InstallationDiscountAmount) :
                                    string.Format("{0:0.00}", itmCharges.InstallationDiscount.ItemChargeValue);
                                excelCellrange.Value2 = itmCharges.InstallationSellingCost;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // PRICE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 1], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 1]];
                                excelCellrange.Value2 = itmCharges.InstallationSellingCost * itmCharges.TotalQuantity;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // DISCOUNT ON MATERIAL
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 2], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 2]];
                                strEXPR = string.Empty;
                                if (itmCharges.InstallationDiscount.ItemChargeValue > 0)
                                {
                                    strEXPR = (itmCharges.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) ?
                                    string.Format("\n{1:0.00}\n({0:0.00}%)", itmCharges.InstallationDiscount.ItemChargeValue, itmCharges.InstallationDiscountAmount) :
                                    string.Format("{0:0.00}", itmCharges.InstallationDiscount.ItemChargeValue);
                                }
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // SGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 3], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 3]];
                                strEXPR = (itmCharges.InstallationGST.SGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00})", itmCharges.InstallationGST.SGST_PERCENT, itmCharges.InstallationGST.SGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // CGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4]];
                                strEXPR = (itmCharges.InstallationGST.CGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00})", itmCharges.InstallationGST.CGST_PERCENT, itmCharges.InstallationGST.CGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // IGST ON MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 5], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 5]];
                                strEXPR = (itmCharges.InstallationGST.IGST_AMOUNT > 0) ?
                                    string.Format("{1:0.00}\n(@{0:0.00})", itmCharges.InstallationGST.IGST_PERCENT, itmCharges.InstallationGST.IGST_AMOUNT) :
                                    "";
                                excelCellrange.Value2 = strEXPR;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // NET RATE
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                                excelCellrange.Value2 = itmCharges.InstallationNetRate;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                // TOTAL MATERIAL SUPPLY AMOUNT
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                                excelCellrange.Value2 = itmCharges.InstallationAmount;
                                excelCellrange.NumberFormat = "#,##0.00";
                                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                                excelCellrange.Cells.Font.Bold = true;
                                excelCellrange.Interior.Color = XlRgbColor.rgbAqua;
                                // FORMAT ALL COLUMNS OF MATERIAL SUPPLY
                                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                                excelCellrange.Interior.Color = XlRgbColor.rgbKhaki;
                                #endregion
                            }
                        }

                        currRow++;
                    }

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, COL_SRNO_SYS], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region NET AMOUNT MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "NET AMOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyAmount
                            - boqSheet.SUMMARY.MaterialSupplyDiscountAmount
                            - boqSheet.SUMMARY.MaterialSupplySGSTAmount
                            - boqSheet.SUMMARY.MaterialSupplyCGSTAmount
                            - boqSheet.SUMMARY.MaterialSupplyIGSTAmount;

                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region NET AMOUNT INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "NET AMOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationAmount - boqSheet.SUMMARY.InstallationDiscountAmount - boqSheet.SUMMARY.InstallationSGSTAmount - boqSheet.SUMMARY.InstallationCGSTAmount - boqSheet.SUMMARY.InstallationIGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;

                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region DISCOUNT ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL DISCOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyDiscountAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region DISCOUNT ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL DISCOUNT";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationDiscountAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }

                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL SGST ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL SGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplySGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL SGST ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL SGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationSGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;

                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL CGST ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL CGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyCGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL CGST ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL CGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationCGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL IGST ON MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL IGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyIGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL IGST ON INSTALLATIONS 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "TOTAL IGST";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationIGSTAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    currRow++;
                    if (settings.IncludeMaterialSupplyCharges)
                    {
                        #region TOTAL OF MATERIAL SUPPLY 
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 6]];
                        excelCellrange.Value2 = "GROSS TOTAL";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_MATERIAL_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.MaterialSupplyAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    if (settings.IncludeInstallationCharges)
                    {
                        #region TOTAL OF INSTLAATION SERVICES
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 4], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 6]];
                        excelCellrange.Value2 = "GROSS TOTAL";
                        excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                        excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                        excelCellrange.Merge(misValue);
                        excelCellrange.Cells.Font.Bold = true;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7], xlWorkSheet.Cells[currRow, COL_INSTALLATION_START_INDEX + 7]];
                        excelCellrange.Value2 = boqSheet.SUMMARY.InstallationAmount;
                        excelCellrange.NumberFormat = "#,##0.00";
                        excelCellrange.Cells.Font.Bold = true;
                        #endregion
                    }
                    xlWorkSheet.get_Range("A:A", misValue).EntireColumn.Hidden = true;

                    if (!settings.IncludeMaterialSupplyCharges)
                    {
                        for (int I = COL_MATERIAL_START_INDEX; I <= COL_MATERIAL_START_INDEX + 7; I++)
                        {
                            string colChar = AppCommon.EXCELColumnIndexToColumnLetter(I);
                            xlWorkSheet.get_Range(string.Format("{0}:{0}", colChar), misValue).EntireColumn.Hidden = true;
                        }
                    }
                    if (!settings.IncludeInstallationCharges)
                    {
                        for (int I = COL_INSTALLATION_START_INDEX; I <= COL_INSTALLATION_START_INDEX + 7; I++)
                        {
                            string colChar = AppCommon.EXCELColumnIndexToColumnLetter(I);
                            xlWorkSheet.get_Range(string.Format("{0}:{0}", colChar), misValue).EntireColumn.Hidden = true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceSalesQuotationBOQ::AddSalesQuotationWorkSheets", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region MONTHLY PAYSLIPS REGISTER 
        public bool ExportMonthlyPayrollDataToExcel(System.Data.DataTable dtPayroll, string fileNameWithPath, DateTime dtmonth)
        {
            bool result = false;
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;
            int totalColumns = dtPayroll.Columns.Count;
            
            int tableRowStartIndex = 0;
            Range excelCellrange = null;

            const int EXCEL_COL_SR_NO = 1;
            const int EXCEL_COL_EMP_NAME = 2;
            const int EXCEL_COL_TOT_DAYS = 3 ;
            const int EXCEL_COL_PRESENT_DAYS = 4;
            const int EXCEL_COL_ABSENT_DAYS = 5;
            const int EXCEL_COL_PAID_DAYS =6;
            const int EXCEL_COL_PAID_HOLIDAYS = 7;
            const int EXCEL_COL_WEEKLY_OFF =8;
            const int EXCEL_COL_LEAVES = 9;
            const int EXCEL_COL_TOT_EARNINGS = 10;
            const int EXCEL_COL_TOT_DEDUCTIONS = 11;
            const int EXCEL_COL_GROSS_SALARY =12;
            const int EXCEL_COL_NET_SALARY = 13;
            





            decimal mTotalValue = 0;
            string _FontStyleName = "Cambria";

            string SPECIAL_NOTES = string.Empty;

            try
            {
                ServicePayRoll _payrollService = new ServicePayRoll();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return false;
                }
                excelApp.DisplayAlerts = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excelApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
               // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
               // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                
                SPECIAL_NOTES = ""; // orderDBInfo.SpecialNotes;
                // CREATE SUMMARY SHEET TO BE FOLLOWED BY ALL BOQ-ITEMS SHEET
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkSheet.Name = "Monthly Report - Payroll";
                currRow = 1;
                currCol = 1;

                CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                if (compDBInfo != null)
                {
                    // COMPANY INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, EXCEL_COL_SR_NO], xlWorkSheet.Cells[currRow, totalColumns]];
                    //excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("{0}{1}", lastColAlphName));
                    excelCellrange.Value2 = compDBInfo.Company_name;
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = "Calibri";
                    excelCellrange.Style.Font.Size = 20;
                    excelCellrange.Style.Font.Bold = true;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ADDRESS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = compDBInfo.Address.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Cells.Font.FontStyle = "Arial";
                    excelCellrange.Cells.Font.Size = 12;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ISO INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "AN ISO 9001 : 2008 CERTIFIED COMPANY";
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = "Calibri";
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    currRow++;

                    //COMPANY GST INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "GST NO: " + compDBInfo.GST_NO.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = "Calibri";
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    currRow++;


                }
                currRow++;
                //SHEET TITLE ROW #DESIGNBOQ#
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("MONTHLY REPORT PAYROLL - ({0})", dtmonth.ToString("MMMM yyyy").ToUpper());
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.Font.FontStyle = "Calibri";
                excelCellrange.Cells.Font.Size = 14;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                excelCellrange.Interior.Color = XlRgbColor.rgbBlack;

                currRow++;
                
                for (int i = 0; i < dtPayroll.Columns.Count;i++)
                {
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, i+1], xlWorkSheet.Cells[currRow, i+1]];
                    excelCellrange.Value2 = dtPayroll.Columns[i].ColumnName;
                    excelCellrange.Font.FontStyle = "Calibri";
                    excelCellrange.Cells.Font.Size = 11;
                    excelCellrange.Cells.Font.Bold = true;
                 //   excelCellrange.Orientation = 90;
                    xlWorkSheet.Columns[i+1].ColumnWidth = 4.5;
                    xlWorkSheet.Columns[4].ColumnWidth =15;
                    
                }
                   
                currRow++;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                
                foreach (DataRow dRow in dtPayroll.Rows)
                {
                    for (int i = 0; i < dtPayroll.Columns.Count; i++)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, i+1], xlWorkSheet.Cells[currRow, i+1]];
                        excelCellrange.Value2 = dRow[i].ToString(); ;
                        excelCellrange.Font.FontStyle = "Calibri";
                        excelCellrange.Cells.Font.Size = 11;
                        excelCellrange.Cells.Font.Bold = false;
                    }
                    currRow++;
                }

                #region CREATE REPORT FOOTER
                //excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                //excelCellrange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                currRow++;
                //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("Company WebSite:{0},Email:{1},Tel No:{2},FAX No:{3}", compDBInfo.WebAdd.ToString(), compDBInfo.Email.ToString(), compDBInfo.PhoneNo.ToString(), compDBInfo.FaxNo.ToString());
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                // excelCellrange.Interior.Color = XlRgbColor.rgbWhite;
                excelCellrange.RowHeight = 16;

                currRow++;
                #endregion

                excelApp.ActiveWindow.Zoom = 90;
                xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                
                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                string strMessage = string.Format("Exported Monthly Payroll Report to Excel File Name: {0}", fileNameWithPath);
                MessageBox.Show(strMessage, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceExcelApp::ExportMonthlyPayrollDataToExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
            return result;
        }
        #endregion

        #region EXPORT ADVANCE REQUEST REGISTER
        public bool ExportAdvancedRequstRegister(BindingList<AdvanceRequestModel> _AdvanceRequestList, string fileNameWithPath)
        {
            bool result = false;
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;
            int totalColumns = 7;
            int tableRowStartIndex = 7;
            Range excelCellrange = null;

            const int ADVANCED_COL_SRNO = 1;
            const int ADVANCED_COL_REQUEST_NO = 2;
            const int ADVANCED_COL_DATEREQUEST = 3;
            const int ADVANCED_COL_NAMEOFEMPLOYEE = 4;
            const int ADVANCED_COL_AMOUNTREQUEST = 5;
            const int ADVANCED_COL_STATUS = 6;
            const int ADVANCED_COL_NAMEOFAPPROVER = 7;
            const int ADVANCED_COL_DATAAPPROVED = 8;
            const int ADVANCED_COL_AMOUNTAPPROVED = 9;
            const int ADVANCED_COL_REMARKSAPPROVAL = 10;



            decimal mTotalValue = 0;
            string _FontStyleName = "Cambria";
            try
            {
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return false;
                }
                excelApp.DisplayAlerts = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excelApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
                //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
                // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                xlWorkSheet.Name = string.Format("ADVANED REQUEST REGISTER");
                xlWorkSheet.Columns[ADVANCED_COL_SRNO].ColumnWidth = 1.5;
                xlWorkSheet.Columns[ADVANCED_COL_REQUEST_NO].ColumnWidth = 9.7;
                xlWorkSheet.Columns[ADVANCED_COL_DATEREQUEST].ColumnWidth = 4.4;
                xlWorkSheet.Columns[ADVANCED_COL_NAMEOFEMPLOYEE].ColumnWidth = 18.4;
                xlWorkSheet.Columns[ADVANCED_COL_AMOUNTREQUEST].ColumnWidth = 5.3;
                xlWorkSheet.Columns[ADVANCED_COL_STATUS].ColumnWidth = 4.6;
                xlWorkSheet.Columns[ADVANCED_COL_NAMEOFAPPROVER].ColumnWidth = 17;
                xlWorkSheet.Columns[ADVANCED_COL_DATAAPPROVED].ColumnWidth = 4.5;
                xlWorkSheet.Columns[ADVANCED_COL_AMOUNTAPPROVED].ColumnWidth = 7;
                xlWorkSheet.Columns[ADVANCED_COL_REMARKSAPPROVAL].ColumnWidth = 11;

                currRow = 1;
                currCol = 1;

                CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                if (compDBInfo != null)
                {
                    // COMPANY INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    //excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("{0}{1}", lastColAlphName));
                    excelCellrange.Value2 = compDBInfo.Company_name;
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Style.Font.Size = 20;
                    excelCellrange.Style.Font.Bold = true;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    excelCellrange.RowHeight = 27;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ADDRESS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = compDBInfo.Address.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 12;
                    excelCellrange.Cells.Font.Bold = false;
                    //   excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 18;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ISO INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "AN ISO 9001 : 2008 CERTIFIED COMPANY";
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                    //  excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 18;
                    currRow++;

                    //COMPANY GST INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "GST NO: " + compDBInfo.GST_NO.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                    // excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 18;

                }
                currRow++;
                #region TITLE TEXT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("ADVANCED REQUEST REGISTER");
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 14;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                //excelCellrange.Interior.Color = XlRgbColor.rgbBlack;
                excelCellrange.RowHeight = 30;
                #endregion

                currRow++;

                #region CREATE REPORT HEADER AND TABLE HEADERS
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ADVANCED_COL_SRNO]];
                excelCellrange.Value2 = string.Format("SR.");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, ADVANCED_COL_REQUEST_NO]];
                excelCellrange.Value2 = string.Format("REQUEST NO.");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, ADVANCED_COL_DATEREQUEST]];
                excelCellrange.Value2 = string.Format("REQUEST \n DATE");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, ADVANCED_COL_NAMEOFEMPLOYEE]];
                excelCellrange.Value2 = string.Format("NAME OF EMPLOYEE");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, ADVANCED_COL_AMOUNTREQUEST]];
                excelCellrange.Value2 = string.Format("REQAUESTED\n AMOUNT");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ADVANCED_COL_STATUS]];
                excelCellrange.Value2 = string.Format("APPROVAL \nSTATUS");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, ADVANCED_COL_NAMEOFAPPROVER]];
                excelCellrange.Value2 = string.Format("NAME OF APPROVER");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, ADVANCED_COL_DATAAPPROVED]];
                excelCellrange.Value2 = string.Format("APPROVED \nDATE");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 9], xlWorkSheet.Cells[currRow, ADVANCED_COL_AMOUNTAPPROVED]];
                excelCellrange.Value2 = string.Format("APPROVED \nAMOUNT");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 10], xlWorkSheet.Cells[currRow, ADVANCED_COL_REMARKSAPPROVAL]];
                excelCellrange.Value2 = string.Format("APPROVAL REMARKS");
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

               

                #endregion

                currRow++;

                int stIndex = 1;
                foreach (AdvanceRequestModel item in _AdvanceRequestList)
                {
                    //creating rows
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ADVANCED_COL_SRNO]];
                    excelCellrange.Value2 = stIndex++;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, ADVANCED_COL_REQUEST_NO]];
                    excelCellrange.Value2 = item.AdvanceRequestNo;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, ADVANCED_COL_DATEREQUEST]];
                    excelCellrange.Value2 = item.RequestDate.ToString("dd MMM yyyy");

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, ADVANCED_COL_NAMEOFEMPLOYEE]];
                    excelCellrange.Value2 = item.EmployeeName;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, ADVANCED_COL_AMOUNTREQUEST]];
                    excelCellrange.Value2 = item.RequestedAmount;

                    if(item.ApprovalStatus == 1112)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ADVANCED_COL_STATUS]];
                        excelCellrange.Value2 = string.Format("Rejected");
                    }
                    if (item.ApprovalStatus == 1113)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ADVANCED_COL_STATUS]];
                        excelCellrange.Value2 = string.Format("Pending");
                    }
                    if (item.ApprovalStatus == 1111)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ADVANCED_COL_STATUS]];
                        excelCellrange.Value2 = string.Format("Approved");
                    }

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, ADVANCED_COL_NAMEOFAPPROVER]];
                    excelCellrange.Value2 = item.ApproverName;


                    if (item.ApprovalDate != null)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, ADVANCED_COL_DATAAPPROVED]];
                        excelCellrange.Value2 = item.ApprovalDate.Value.ToString("dd MMM yyyy");
                    }
                    else
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, ADVANCED_COL_DATAAPPROVED]];
                        excelCellrange.Value2 = string.Format("--");
                    }


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 9], xlWorkSheet.Cells[currRow, ADVANCED_COL_AMOUNTAPPROVED]];
                    excelCellrange.Value2 = item.ApprovedAmount;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 10], xlWorkSheet.Cells[currRow, ADVANCED_COL_REMARKSAPPROVAL]];
                    excelCellrange.Value2 = item.RemarksApproved;

                    currRow++;
                }
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, 1], xlWorkSheet.Cells[currRow, ADVANCED_COL_REMARKSAPPROVAL]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                currRow++;

                #region CREATE REPORT FOOTER


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("Company WebSite:{0},Email:{1},Tel No:{2},FAX No:{3}", compDBInfo.WebAdd.ToString(), compDBInfo.Email.ToString(), compDBInfo.PhoneNo.ToString(), compDBInfo.FaxNo.ToString());
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                // excelCellrange.Interior.Color = XlRgbColor.rgbWhite;
                excelCellrange.RowHeight = 16;

                currRow++;
                #endregion
                // xlWorkSheet.Activate();
                //xlWorkSheet.Application.ActiveWindow.SplitRow = 6;
                // xlWorkSheet.Application.ActiveWindow.FreezePanes = true;

                //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                excelApp.ActiveWindow.Zoom = 90;
                xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                string strMessage = string.Format("Exported Monthly Attendance Report to Excel\nFile Name:\n{0}", fileNameWithPath);
                MessageBox.Show(strMessage, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceExcelApp::ExportAttendanceDatatoExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
            return result;

        }

        #endregion


        #region ATTENDANCE PRINTING
        public bool ExportAttendanceDatatoExcel(BindingList<AttendanceGridViewModel>  _AttendanceList, string fileNameWithPath, DateTime fromDate, DateTime ToDate)
        {
            bool result = false;
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;
            int totalColumns = 10;
            int tableRowStartIndex = 7;
            Range excelCellrange = null;

            const int ATTENDANCE_COL_SRNO = 1;
            const int ATTENDANCE_COL_DATE = 2;
            const int ATTENDANCE_COL_EMPLOYEE = 3;
            const int ATTENDANCE_COL_INTIME = 4;
            const int ATTENDANCE_COL_OUTTIME = 5;
            const int ATTENDANCE_COL_DURATION = 6;
            const int ATTENDANCE_COL_REMARKS = 7;
            const int ATTENDANCE_COL_PROJECTNAME = 8;
            const int ATTENDANCE_COL_PREPAREDBY = 9;
            const int ATTENDANCE_COL_WAREHOUSE = 10;
            //const int ATTENDANCE_COL_CREATEDATETIME = 11;



            decimal mTotalValue = 0;
            string _FontStyleName = "Cambria";
            try
            {
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return false;
                }
                excelApp.DisplayAlerts = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excelApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
                //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
               // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                xlWorkSheet.Name = string.Format("Attendance {0}-{1} {2}", fromDate.ToString("dd"),ToDate.ToString("dd"),fromDate.ToString("MMM yyyy").ToUpper());
                xlWorkSheet.Columns[ATTENDANCE_COL_SRNO].ColumnWidth = 1.5;
                xlWorkSheet.Columns[ATTENDANCE_COL_DATE].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_COL_EMPLOYEE].ColumnWidth = 18;
                xlWorkSheet.Columns[ATTENDANCE_COL_INTIME].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_COL_OUTTIME].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_COL_DURATION].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_COL_REMARKS].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_COL_PROJECTNAME].ColumnWidth = 12;
                xlWorkSheet.Columns[ATTENDANCE_COL_PREPAREDBY].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_COL_WAREHOUSE].ColumnWidth = 3;
               // xlWorkSheet.Columns[ATTENDANCE_COL_CREATEDATETIME].ColumnWidth = 6;

                currRow = 1;
                currCol = 1;

                CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                if (compDBInfo != null)
                {
                    // COMPANY INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    //excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("{0}{1}", lastColAlphName));
                    excelCellrange.Value2 = compDBInfo.Company_name;
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Style.Font.Size = 20;
                    excelCellrange.Style.Font.Bold = true;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    excelCellrange.RowHeight = 27;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ADDRESS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = compDBInfo.Address.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 12;
                    excelCellrange.Cells.Font.Bold = false;
                 //   excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 18;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ISO INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "AN ISO 9001 : 2008 CERTIFIED COMPANY";
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                  //  excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 18;
                    currRow++;

                    //COMPANY GST INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "GST NO: " + compDBInfo.GST_NO.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                   // excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 18;
                  
                }
                currRow++;
                #region TITLE TEXT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 =  string.Format("ATTENDANCE SHEET FROM {0} - {1}", fromDate.Date.ToString("dd MMM yy"), ToDate.Date.ToString("dd MMM yy"));
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 14;
                excelCellrange.Cells.Font.Bold = true;
                //excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                //excelCellrange.Interior.Color = XlRgbColor.rgbBlack;
                excelCellrange.RowHeight = 30;
                #endregion

                currRow++;

                #region CREATE REPORT HEADER AND TABLE HEADERS
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_SRNO]];
                excelCellrange.Value2 = string.Format("SR.");
              
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_DATE]];
                excelCellrange.Value2 = string.Format("DATE");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_EMPLOYEE]];
                excelCellrange.Value2 = string.Format("EMPLOYEE");
               
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_INTIME]];
                excelCellrange.Value2 = string.Format("IN TIME");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_OUTTIME]];
                excelCellrange.Value2 = string.Format("OUT TIME");
               
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_DURATION]];
                excelCellrange.Value2 = string.Format("DURATION");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_REMARKS]];
                excelCellrange.Value2 = string.Format("REMARKS");

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_PROJECTNAME]];
                excelCellrange.Value2 = string.Format("PROJECT NAME");

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 9], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_PREPAREDBY]];
                excelCellrange.Value2 = string.Format("PREPARED BY");

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 10], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_WAREHOUSE]];
                excelCellrange.Value2 = string.Format("WH");

                //excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 11], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_CREATEDATETIME]];
                //excelCellrange.Value2 = string.Format("CREATE DATETIME");


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_WAREHOUSE]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                #endregion

                currRow++;

                int stIndex = 1;
                foreach (AttendanceGridViewModel item in _AttendanceList)
                {
                    //creating rows
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_SRNO]];
                    excelCellrange.Value2 = stIndex++;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_DATE]];
                    excelCellrange.Value2 = item.AttendDate.ToString("dd MMM yy");

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_EMPLOYEE]];
                    excelCellrange.Value2 = item.EmployeeDescription;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_INTIME]];
                    excelCellrange.Value2 = item.AttendInTime.ToString("hh:mm tt");

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_OUTTIME]];
                    excelCellrange.Value2 = item.AttendOutTime.ToString("hh:mm tt");

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_DURATION]];
                    excelCellrange.Value2 = item.Duration;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_REMARKS]];
                    excelCellrange.Value2 = item.AttendanceRemarks;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_PROJECTNAME]];
                    excelCellrange.Value2 = item.ProjectName;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 9], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_PREPAREDBY]];
                    excelCellrange.Value2 = item.PreparedBy;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 10], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_WAREHOUSE]];
                    excelCellrange.Value2 = item.AtWarehouse;

                    //excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 11], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_CREATEDATETIME]];
                    //excelCellrange.Value2 = item.CreatedDateTime;

                    currRow++;
                }
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_COL_WAREHOUSE]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                currRow++;

                #region CREATE REPORT FOOTER
               

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("Company WebSite:{0},Email:{1},Tel No:{2},FAX No:{3}", compDBInfo.WebAdd.ToString(), compDBInfo.Email.ToString(), compDBInfo.PhoneNo.ToString(), compDBInfo.FaxNo.ToString());
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.Font.FontStyle =_FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                // excelCellrange.Interior.Color = XlRgbColor.rgbWhite;
                excelCellrange.RowHeight = 16;

                currRow++;
                #endregion
               // xlWorkSheet.Activate();
                //xlWorkSheet.Application.ActiveWindow.SplitRow = 6;
               // xlWorkSheet.Application.ActiveWindow.FreezePanes = true;

                //((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                excelApp.ActiveWindow.Zoom = 90;
                xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                string strMessage = string.Format("Exported Monthly Attendance Report to Excel\nFile Name:\n{0}", fileNameWithPath);
                MessageBox.Show(strMessage, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceExcelApp::ExportAttendanceDatatoExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
            return result;

        }
        #endregion

        #region ATTENDANCE SUMMARY PRINTING
        public bool ExportAttendanceSummaryDataToExcel(BindingList<MonthlyAttendanceSummaryModel> _SummaryList,DateTime dtMonth, string fileNameWithPath)
        {
            bool result = false;
            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;
            int totalColumns = 15;
            int tableRowStartIndex = 0;
            Range excelCellrange = null;

            const int ATTENDANCE_SUMMARY_COL_SRNO = 1;
            const int ATTENDANCE_SUMMARY_COL_EMPLOYEENAME = 2;
            const int ATTENDANCE_SUMMARY_COL_DAYSINMONTH = 3;
            const int ATTENDANCE_SUMMARY_COL_OFFDAYS = 4;
            const int ATTENDANCE_SUMMARY_COL_PAIDDAYS = 5;
            const int ATTENDANCE_SUMMARY_COL_PRESENT = 6;
            const int ATTENDANCE_SUMMARY_COL_ABSENT = 7;
            const int ATTENDANCE_SUMMARY_COL_OUTDOOR = 8;
            const int ATTENDANCE_SUMMARY_COL_PLS = 9;
            const int ATTENDANCE_SUMMARY_COL_CLS = 10;
            const int ATTENDANCE_SUMMARY_COL_SLS = 11;
            const int ATTENDANCE_SUMMARY_COL_COMPOFF = 12;
            const int ATTENDANCE_SUMMARY_COL_LATECOMMING = 13;
            const int ATTENDANCE_SUMMARY_COL_EARLYLEAVING = 14;
            const int ATTENDANCE_SUMMARY_COL_SANDWICHLEAVE =15;



            decimal mTotalValue = 0;
            string _FontStyleName = "Cambria";
            try
            {
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return false;
                }
                excelApp.DisplayAlerts = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excelApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();


                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);

                xlWorkSheet.Name =string.Format("Attendance {0}", dtMonth.ToString("MMM yyyy"));
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_SRNO].ColumnWidth =1.5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_EMPLOYEENAME].ColumnWidth = 18;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_DAYSINMONTH].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_OFFDAYS].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_PAIDDAYS].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_PRESENT].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_ABSENT].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_OUTDOOR].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_PLS].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_CLS].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_SLS].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_COMPOFF].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_LATECOMMING].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_EARLYLEAVING].ColumnWidth = 5;
                xlWorkSheet.Columns[ATTENDANCE_SUMMARY_COL_SANDWICHLEAVE].ColumnWidth = 5;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                


                currRow = 1;
                currCol = 1;

                CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                if (compDBInfo != null)
                {
                    // COMPANY INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    //excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("{0}{1}", lastColAlphName));
                    excelCellrange.Value2 = compDBInfo.Company_name;
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Style.Font.Size = 20;
                    excelCellrange.Style.Font.Bold = true;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    excelCellrange.RowHeight = 27;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ADDRESS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = compDBInfo.Address.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 12;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.RowHeight = 18;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ISO INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "AN ISO 9001 : 2008 CERTIFIED COMPANY";
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.RowHeight = 18;
                    currRow++;

                    //COMPANY GST INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "GST NO: " + compDBInfo.GST_NO.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 10;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.RowHeight = 18;
                }

                currRow++;
                #region TITLE TEXT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 =string.Format("ATTENDANCE SUMMARY {0}", dtMonth.ToString("MMMM yyyy").ToUpper());
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 14;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.RowHeight = 30;
                #endregion

                currRow++;

                #region CREATE REPORT HEADER AND TABLE HEADERS
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SRNO]];
                excelCellrange.Value2 = "SR.";

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_EMPLOYEENAME]];
                excelCellrange.Value2 = string.Format("EMPLOYEE\nNAME");

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_DAYSINMONTH]];
                excelCellrange.Value2 = string.Format("DAYS IN\nMONTH");
                //excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_OFFDAYS]];
                excelCellrange.Value2 = string.Format("OFF DAYS.");
                //excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_PAIDDAYS]];
                excelCellrange.Value2 = string.Format("PAID DAYS");
               //excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_PRESENT]];
                excelCellrange.Value2 = string.Format("PRESENT");
              
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_ABSENT]];
                excelCellrange.Value2 = string.Format("ABSENT");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_OUTDOOR]];
                excelCellrange.Value2 = string.Format("OUTDOOR");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 9], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_PLS]];
                excelCellrange.Value2 = string.Format("PLs");
              
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 10], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_CLS]];
                excelCellrange.Value2 = string.Format("CLs");
              
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 11], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SLS]];
                excelCellrange.Value2 = string.Format("SLs");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 12], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_COMPOFF]];
                excelCellrange.Value2 = string.Format("Comp\nOff");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 13], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_LATECOMMING]];
                excelCellrange.Value2 = string.Format("LATE\nCOMING");
              
                //excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 14], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_EARLYLEAVING]];
                excelCellrange.Value2 = string.Format("EARLY\nLEAVING");
               
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 15], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SANDWICHLEAVE]];
                excelCellrange.Value2 = string.Format("SANDWICH\nLEAVE");

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SANDWICHLEAVE]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                #endregion
                currRow++;

                int stIndex = 1;
                foreach (MonthlyAttendanceSummaryModel item in _SummaryList)
                {
                    #region creating rows
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SRNO]];
                    excelCellrange.Value2 = stIndex++;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_EMPLOYEENAME]];
                    excelCellrange.Value2 = item.EmployeeName;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_DAYSINMONTH]];
                    excelCellrange.Value2 =item.TotalDays;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_OFFDAYS]];
                    excelCellrange.Value2 =item.NonWorkingDays;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_PAIDDAYS]];
                    excelCellrange.Value2 =item.PaidDays;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_PRESENT]];
                    excelCellrange.Value2 =item.Present;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_ABSENT]];
                    excelCellrange.Value2 = item.Absent;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_OUTDOOR]];
                    excelCellrange.Value2 =item.Outdoor;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 9], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_PLS]];
                    excelCellrange.Value2 =item.PLs;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 10], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_CLS]];
                    excelCellrange.Value2 = item.CLs;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 11], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SLS]];
                    excelCellrange.Value2 = item.SLs;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 12], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_COMPOFF]];
                    excelCellrange.Value2 = item.CompOffs;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 13], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_LATECOMMING]];
                    excelCellrange.Value2 = item.LateComings;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 14], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_EARLYLEAVING]];
                    excelCellrange.Value2 =item.EarlyGoings;

                    

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 15], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SANDWICHLEAVE]];
                    excelCellrange.Value2 = item.SandwichLeaves;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, ATTENDANCE_SUMMARY_COL_SANDWICHLEAVE]];
                    excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 11;
                    excelCellrange.Cells.Font.Bold = false;
                    //excelCellrange.Merge(misValue);
                    
                  
                    #endregion
                    currRow++;
                }
                currRow++;

                #region CREATE REPORT FOOTER


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("Company WebSite:{0},Email:{1},Tel No:{2},FAX No:{3}", compDBInfo.WebAdd.ToString(), compDBInfo.Email.ToString(), compDBInfo.PhoneNo.ToString(), compDBInfo.FaxNo.ToString());
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 12;
                excelCellrange.Cells.Font.Bold =false;
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                excelCellrange.RowHeight = 16;
                // excelCellrange.Interior.Color = XlRgbColor.rgbWhite;

                currRow++;
                #endregion

                //xlWorkSheet.Activate();
               // xlWorkSheet.Application.ActiveWindow.SplitRow = 6;
               // xlWorkSheet.Application.ActiveWindow.FreezePanes = true;

              //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                excelApp.ActiveWindow.Zoom = 90;
                xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                string strMessage = string.Format("Exported Monthly Payroll Report to Excel\nFile Name:\n{0}", fileNameWithPath);
                MessageBox.Show(strMessage, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

            catch (Exception ex)
            {


                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceExcelApp::ExportAttendanceSummaryDataToExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
            return result;
        }
        #endregion

        #region EMPLOYEE PAYSLIP PRINTING
        public bool ExportEmployeePayslipDataToExcel(EmployeePayslipModel _Payslip, string fileNameWithPath, DateTime dtmonth, int finyearID)
        {
            bool result = false;

            int currRow = 1;
            int currCol = 1;
            int servicesCount = 0;
            int totalColumns = 8;

            int tableRowStartIndex = 14;
            Range excelCellrange = null;

            const int EMPLOYEE_PAYSLIP_ALL_SR_NO = 1;
            const int EMPLOYEE_PAYSLIP_ALLOWANCE = 2;
            const int EMPLOYEE_PAYSLIP_ALL_AMOUNT = 3;
            const int EMPLOYEE_PAYSLIP_SPACE = 4;
            const int EMPLOYEE_PAYSLIP_DED_SR_NO = 5;
            const int EMPLOYEE_PAYSLIP_DEDUCTIONS = 6;
            const int EMPLOYEE_PAYSLIP_DED_AMOUNT = 7;
            const int EMPLOYEE_PAYSLIP_DED_SPACE = 8;


            decimal mTotalValue = 0;
            string _FontStyleName = "Cambria";

            string SPECIAL_NOTES = string.Empty;

            try
            {
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return false;
                }
                excelApp.DisplayAlerts = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = excelApp.Workbooks.Add(misValue);
                Worksheet xlWorkSheetToRemove = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[3]).Delete();
                //  ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[2]).Delete();
                // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.Add(System.Reflection.Missing.Value, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count], System.Reflection.Missing.Value, System.Reflection.Missing.Value);
                xlWorkSheet.Name = string.Format("Payslip {0}", dtmonth.ToString("MMMyyyy").ToUpper());
                //xlWorkSheet.Name = string.Format("mY pAYSLIP {0}-{1} {2}", fromDate.ToString("dd"), ToDate.ToString("dd"), fromDate.ToString("MMM yyyy").ToUpper());

                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_ALL_SR_NO].ColumnWidth = 14;
                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_ALLOWANCE].ColumnWidth = 19.6;
                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_ALL_AMOUNT].ColumnWidth = 6.8;
                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_SPACE].ColumnWidth = 1;
                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_DED_SR_NO].ColumnWidth = 13;
                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_DEDUCTIONS].ColumnWidth = 5.3;
                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_DED_AMOUNT].ColumnWidth = 4.1;
                xlWorkSheet.Columns[EMPLOYEE_PAYSLIP_DED_SPACE].ColumnWidth = 5;

                currRow = 1;
                currCol = 1;

                CompanyMaster compDBInfo = (new ServiceCompanyInfo()).GetCompanyDbInfo();
                if (compDBInfo != null)
                {
                    // COMPANY LOGO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, totalColumns]];
                    // COMPANY INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, totalColumns]];
                    // excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currCol, 1], xlWorkSheet.Cells[currCol, 4]];
                    //excelCellrange = xlWorkSheet.get_Range(string.Format("A{0}", currRow), string.Format("{0}{1}", lastColAlphName));
                    excelCellrange.Value2 = compDBInfo.Company_name;
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Style.Font.Size = 14;
                    excelCellrange.Style.Font.Bold = true;
                    excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    excelCellrange.RowHeight = 20;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ADDRESS
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = compDBInfo.Address.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;
                    //   excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 14;
                    currRow++;
                    excelCellrange = null;
                    //COMPANY ISO INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "AN ISO 9001 : 2008 CERTIFIED COMPANY";
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 7;
                    excelCellrange.Cells.Font.Bold = false;
                    //  excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 14;
                    currRow++;

                    //COMPANY GST INFO
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, totalColumns]];
                    excelCellrange.Value2 = "GST NO: " + compDBInfo.GST_NO.ToString();
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    excelCellrange.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 7;
                    excelCellrange.Cells.Font.Bold = false;
                    // excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);
                    excelCellrange.RowHeight = 14;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[4, 1]];
                    excelCellrange.Merge(misValue);
                    // xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    // xlWorkSheet.Shapes.AddPicture("C:\\csharp-xl-picture.JPG", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 300, 45);
                    // xlWorkSheet.Cells[4, 1] = xlWorkSheet.Shapes.AddPicture("c:\\users\\administrator\\downloads\\erp source\appexcelerp\\resources\\excellogo.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 75, 75, 350, 50);

                    //string picPath = @"C:\Users\Administrator\Downloads\erp source\appExcelERP\Resources\Excellogo.jpeg";
                    //ExcelPicture picture = xlWorkSheet.Add(1, 1, picPath);
                    // excelCellrange.Cells..AddPicture("C:\\pic.JPG", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 300, 45); //C:\\csharp-xl-picture.JPG
                    // xlWorkSheet.SetBackgroundPicture(picPath);
                    // Excel.Range oRange = (Excel.Range)xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[4, 1]];
                    //string _stlogo = "c:\\users\\administrator\\downloads\\erp source\appexcelerp\\resources\\excellogo.jpg";
                    //Image oImage = Image.FromFile(_stlogo);
                    //System.Windows.Forms.Clipboard.SetDataObject(oImage, true);
                    //xlWorkSheet.Paste(oRange, _stlogo);
                }
                currRow++;
                #region TITLE TEXT
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("PAYSLIP {0}", dtmonth.ToString("MMMM yyyy").ToUpper()); ;
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 11;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.RowHeight = 15;
                #endregion

                currRow++;
                #region employee info header
                vEmployee emp = new ServiceEmployee().GetEmployeeViewRecordByID(_Payslip.EmployeeID);

                EmployeeGeneralInfoModel DOJ = new ServiceEmployee().GetEmployeeGeneralInfo(_Payslip.EmployeeID);
                EmployeeAdditionalInfoModel aadhar = new ServiceEmployee().GetEmployeeAdditonalAndMedicalInfo(_Payslip.EmployeeID);
                EmployeeBankInfoModel bank = new ServiceEmployee().GetEmployeeBankInfo(_Payslip.EmployeeID);

                LeaveBalanceModel pl = new ServiceLeaveApplication().GetLeaveBalanceModelOfEmployeeForYear(_Payslip.EmployeeID, finyearID, 8353);
                LeaveBalanceModel cl = new ServiceLeaveApplication().GetLeaveBalanceModelOfEmployeeForYear(_Payslip.EmployeeID, finyearID, 8354);
                LeaveBalanceModel sl = new ServiceLeaveApplication().GetLeaveBalanceModelOfEmployeeForYear(_Payslip.EmployeeID, finyearID, 8355);
                LeaveBalanceModel coff = new ServiceLeaveApplication().GetLeaveBalanceModelOfEmployeeForYear(_Payslip.EmployeeID, finyearID, 8356);


                if (emp != null)
                {
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                    excelCellrange.Value2 = string.Format("EMPLOYEE NAME:");
                    excelCellrange.Cells.Font.Bold = true;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = string.Format("{0}", emp.EmployeeName);
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;



                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                    excelCellrange.Value2 = string.Format("BANK NAME:");
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 5]];
                    excelCellrange.Value2 = string.Format("{0}", bank.BankInfo.Description);
                    excelCellrange.RowHeight = 13;
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, 6]];
                    excelCellrange.Value2 = "LEAVE TYPE";
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom
                        ;
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, 7]];
                    excelCellrange.Value2 = string.Format("AVAILED");
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                    excelCellrange.Value2 = string.Format("BALANCE");
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 8]];
                    excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;
                    //   excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                    excelCellrange.RowHeight = 14;

                    currRow++;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                    excelCellrange.Value2 = string.Format("DESIGNATION:-");
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = string.Format("{0}", emp.DesignationDesc);
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                    excelCellrange.Value2 = string.Format("ACCOUNT NO:");
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 5]];
                    excelCellrange.Value2 = string.Format("{0}", bank.AccountNo);
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.NumberFormat = "00";
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, 6]];
                    excelCellrange.Value2 = string.Format("PL:");
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, 7]];
                    excelCellrange.Value2 = string.Format("{0}", pl.Taken);
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                    excelCellrange.Value2 = string.Format("{0}", pl.Balance);
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;
                    currRow++;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = string.Format("DEPARTMENT:");
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = string.Format("{0}", emp.DepartmentName);
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                    excelCellrange.Value2 = string.Format("PF NO:");
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 5]];
                    excelCellrange.Value2 = string.Format("{0}", bank.PFNumber);
                    excelCellrange.Merge(misValue);
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, 6]];
                    excelCellrange.Value2 = string.Format("SL:");
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, 7]];
                    excelCellrange.Value2 = string.Format("{0}", sl.Taken);
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                    excelCellrange.Value2 = string.Format("{0}", sl.Balance);
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 8]];
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Bold = false;
                    currRow++;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                    excelCellrange.Value2 = string.Format("DATE OF JOINING:-");
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = string.Format("{0}", DOJ.DateOfJoining);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                    excelCellrange.Value2 = string.Format("ESIC NO:");
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 5]];
                    excelCellrange.Value2 = string.Format("{0}", bank.ESICNumber);
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, 6]];
                    excelCellrange.Value2 = string.Format("CL:");
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, 7]];
                    excelCellrange.Value2 = string.Format("{0}", cl.Taken);
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                    excelCellrange.Value2 = string.Format("{0}", cl.Balance);
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Bold = false;
                    currRow++;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                    excelCellrange.Value2 = string.Format("AADHAR NO:");
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.Cells.Font.Bold = false;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                    excelCellrange.Value2 = string.Format("{0}", aadhar.AADHAR_NO);
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                    excelCellrange.Value2 = string.Format("UAN NO:");
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;


                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 5]];
                    excelCellrange.Value2 = string.Format("{0}", bank.UANNumber);
                    excelCellrange.Merge(misValue);
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.NumberFormat = "00";
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 6], xlWorkSheet.Cells[currRow, 6]];
                    excelCellrange.Value2 = string.Format("COMP OFF:");
                    excelCellrange.Cells.Font.Bold = false;
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, 7]];
                    excelCellrange.Value2 = string.Format("{0}", coff.Taken);
                    excelCellrange.Cells.Font.Size = 9;

                    excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                    excelCellrange.Value2 = string.Format("{0}", coff.Balance);
                    excelCellrange.Cells.Font.Size = 9;
                    excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;


                    // excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[6, 1], xlWorkSheet.Cells[9, totalColumns]];
                    excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                    //excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    excelCellrange.RowHeight = 14;
                    excelCellrange.Cells.Font.Bold = false;
                }


                #endregion
                currRow++;
                #region TABLE HEADER OF TOTAL DAYS & PAID
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 1]];
                excelCellrange.Value2 = "TOTAL DAYS ";
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = _Payslip.TotalDays.ToString();
                excelCellrange.Cells.Font.Size = 9;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, 3]];
                excelCellrange.Value2 = "PAID  DAYS ";
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 5]];
                excelCellrange.Value2 = _Payslip.PaidDays.ToString();
                excelCellrange.Merge(misValue);
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;



                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 5]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                // excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                #endregion
                currRow++;
                #region TABLE HEADER OF ALLOUNCES & DEDUCTION
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                excelCellrange.Value2 = "ALLOWANCES";
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Value2 = "DEDUCTIONS";
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                #endregion
                currRow++;
                #region CREATE REPORT HEADER AND TABLE HEADERS
                //excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_SR_NO]];
                //excelCellrange.Value2 = "SR.";
                //excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom ;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = string.Format("DESCRIPTION");

                excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                excelCellrange.Value2 = string.Format("AMOUNT");
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                excelCellrange.Merge(misValue);

                //excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_DED_SR_NO]];
                //excelCellrange.Value2 = string.Format("SR.");
                //excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                //excelCellrange.Merge(misValue);

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 7]];
                excelCellrange.Value2 = string.Format("DESCRIPTION");

                excelCellrange.Merge(misValue);
                excelCellrange.RowHeight = 14;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Value2 = string.Format("AMOUNT");
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                excelCellrange.RowHeight = 14;
                excelCellrange.Merge(misValue);



                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                excelCellrange.RowHeight = 14;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 4]];
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlLineStyleNone;

                #endregion
                currRow++;

                #region ALLOWNACES
                currRow = tableRowStartIndex;
                int allownaceIndex = 1;
                foreach (EmployeePayslipItemModel allownace in _Payslip.MonthlyAllounces)
                {
                    if (allownace.IsApplied)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_SR_NO], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_SR_NO]];
                        excelCellrange.Value2 = allownaceIndex++;
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_SR_NO], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALLOWANCE]];
                        excelCellrange.Value2 = allownace.SalaryHeadName;
                        excelCellrange.Merge(misValue);
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                        excelCellrange.Value2 = string.Format("{0:0.00}", allownace.SalaryHeadAmount);
                        excelCellrange.NumberFormat = "0.00";
                        excelCellrange.Merge(misValue);
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                        excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                        excelCellrange.Cells.Font.Size = 9;
                        excelCellrange.Cells.Font.Bold = false;
                        excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                        excelCellrange.RowHeight = 14;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 4]];
                        excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlLineStyleNone;
                        currRow++;
                    }
                }

                #endregion
                #region DEDUCTIONS
                currRow = tableRowStartIndex;
                int deductionIndex = 1;
                foreach (EmployeePayslipItemModel deduction in _Payslip.MonthlyDeducations)
                {
                    if (deduction.IsApplied)
                    {
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_DED_SR_NO], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_DED_SR_NO]];
                        excelCellrange.Value2 = deductionIndex++;
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 7]];
                        excelCellrange.Value2 = deduction.SalaryHeadName;
                        excelCellrange.Merge(misValue);
                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                        excelCellrange.Value2 = string.Format("{0:0.00}", deduction.SalaryHeadAmount);
                        excelCellrange.NumberFormat = "0.00";
                        excelCellrange.Merge(misValue);

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 8]];
                        excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                        excelCellrange.Cells.Font.Size = 9;
                        excelCellrange.Cells.Font.Bold = false;
                        excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                        excelCellrange.RowHeight = 14;

                        excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 4]];
                        excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlLineStyleNone;
                        currRow++;
                    }
                }
                #endregion

                currRow = tableRowStartIndex + ((allownaceIndex > deductionIndex) ? allownaceIndex : deductionIndex);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, 1], xlWorkSheet.Cells[currRow - 1, 3]];
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[tableRowStartIndex, 5], xlWorkSheet.Cells[currRow - 1, 8]];
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;

                // currRow++;
                currRow--;


                #region TABLE HEADER OF TOTAL ALLOWANCES & DEDUCTION
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALLOWANCE]];
                excelCellrange.Value2 = "TOTAL ALLOWANCES ";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.RowHeight = 14;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.StandardAllouncesAmount + _Payslip.AdditionalAllouncesAmount);
                excelCellrange.NumberFormat = "0.00";


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 7]];
                excelCellrange.Value2 = "TOTAL DEDUCTIONS ";

                excelCellrange.Merge(misValue);
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.StandardDeducationAmount + _Payslip.AdditionalDeducationAmount);
                excelCellrange.NumberFormat = "0.00";



                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;



                #endregion

                currRow++;

                #region TABLE HEADER OF TOTAL GROSS SALARY & NET SALARY
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALLOWANCE]];
                excelCellrange.Value2 = "GROSS SALARY";
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                excelCellrange.RowHeight = 14;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.GrossSalaryAmount);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 7], xlWorkSheet.Cells[currRow, 7]];
                excelCellrange.Value2 = "NET SALARY ";
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.RowHeight = 14;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.NetSalaryAmount.ToString());
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.RowHeight = 14;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 2], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_DED_AMOUNT]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;

                currRow++;
                #endregion

                #region CTC Summary
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("CTC SUMMARY");
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.RowHeight = 16;
                #endregion
                currRow++;

                #region CTC value
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = "PF EMPLOYER ";
                excelCellrange.Merge(misValue);
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.PFEMPLOYER);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 7]];
                excelCellrange.Value2 = "GRATUITY";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.GRATUITY);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;
                currRow++;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = "ESIC EMPLOYER ";
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Merge(misValue);
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.ESICEMPLOYER);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 7]];
                excelCellrange.Value2 = "MEDICAL INSURANCE";
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.MEDICALINSURANCE);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;
                currRow++;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 2]];
                excelCellrange.Value2 = "BONUS ";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.RowHeight = 14;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 3], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_ALL_AMOUNT]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.BONUS);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 5], xlWorkSheet.Cells[currRow, 7]];
                excelCellrange.Value2 = "ACCIDENT INSURANCE";
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 8], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.ACCIDENTINSURANCE);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.RowHeight = 14;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Cells.Font.Size = 9;
                currRow++;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, EMPLOYEE_PAYSLIP_DED_AMOUNT]];
                excelCellrange.Cells.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                #endregion
                //currRow++;

                #region COST TO COMPANY
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 3]];
                excelCellrange.Value2 = string.Format("COST TO COMPANY");
                excelCellrange.Merge(misValue);
                excelCellrange.Cells.Font.Bold = false;

                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 4], xlWorkSheet.Cells[currRow, 8]];
                // excelCellrange.Value2 = string.Format("{0:0.00}", _Payslip.costToCompany);
                excelCellrange.NumberFormat = "0.00";
                excelCellrange.Merge(misValue);


                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, 8]];
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                excelCellrange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = true;
                excelCellrange.RowHeight = 14;
                #endregion

                currRow++;
                // currRow++;
                #region CREATE REPORT FOOTER
                excelCellrange = xlWorkSheet.Range[xlWorkSheet.Cells[currRow, 1], xlWorkSheet.Cells[currRow, totalColumns]];
                excelCellrange.Value2 = string.Format("Company WebSite:{0},Email:{1},Tel No:{2},FAX No:{3}", compDBInfo.WebAdd.ToString(), compDBInfo.Email.ToString(), compDBInfo.PhoneNo.ToString(), compDBInfo.FaxNo.ToString());
                excelCellrange.Merge(misValue);
                excelCellrange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                excelCellrange.Font.FontStyle = _FontStyleName;
                excelCellrange.Cells.Font.Size = 9;
                excelCellrange.Cells.Font.Bold = false;
                excelCellrange.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                // excelCellrange.Interior.Color = XlRgbColor.rgbWhite;
                excelCellrange.RowHeight = 13;

                currRow++;
                #endregion
                //xlWorkSheet.Activate();
                //xlWorkSheet.Application.ActiveWindow.SplitRow = 6;
                //xlWorkSheet.Application.ActiveWindow.FreezePanes = true;

                // ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[1]).Delete();
                excelApp.ActiveWindow.Zoom = 90;
                xlWorkBook.SaveAs(fileNameWithPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                excelApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(excelApp);

                //string strMessage = string.Format("Exported Monthly Attendance Report to Excel\nFile Name:\n{0}", fileNameWithPath);
                //MessageBox.Show(strMessage, "Created Excel File ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //convert excel to pdf
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

                var workbook = ExcelFile.Load(fileNameWithPath);

                // In order to achieve the conversion of a loaded Excel file to PDF,
                // or to some other Excel format,
                // we just need to save an ExcelFile object to desired output file format.
                string filename = string.Format("{0}Payslip{1}", emp.EmployeeName, dtmonth.ToString("MMMyyyy").ToUpper());
                using (FolderBrowserDialog dlg = new FolderBrowserDialog())
                {
                    dlg.Description = "Select a folder";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //MessageBox.Show("You selected: " + dlg.SelectedPath);
                        string path = string.Format("{0}\\{1}.pdf", dlg.SelectedPath,filename);
                        workbook.Save(path);
                        filename = string.Empty;
                        filename = path;
                        string strMessage = string.Format("Exported Employee Payslip to PDF File Name:\n{0}", filename);
                        MessageBox.Show(strMessage, "Created PDF File ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //string path = string.Format("C:\\Users\\{0}.pdf", filename);
                //workbook.Save(path);
                
                

                //delete the created sheet
                //workbook.Worksheets.Remove(filename);
            }

            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceExcelApp::ExportEmployeePayslipDataToExcel", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                foreach (Process process in Process.GetProcessesByName("Excel"))
                    process.Kill();
            }
            return result;
        }

        #endregion





    }
}

