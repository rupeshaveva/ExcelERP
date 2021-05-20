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
using libERP.SERVICES;
using appExcelERP.Controls.CommonControls;
using libERP;
using libERP.SERVICES.CRM;
using libERP.SERVICES.HR;
using libERP.SERVICES.COMMON;
using libERP.MODELS.CRM;
using libERP.MODELS.COMMON;

namespace appExcelERP.Controls.CRM
{
    public partial class ControlSalesQuotaionGeneralDetails : UserControl
    {
        public int SelectedQuotationID { get; set; }
        //private int SALES_QUOTATION_FORM_ID = 14;
        private bool _ReadOnly = false;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
            }
        }
        public ControlSalesQuotaionGeneralDetails()
        {
            InitializeComponent();
        }
        
        public void PoulateSalesQuotationMasterInfo()
        {
            try
            {
                TBL_MP_CRM_SalesQuotation dbModel = (new ServiceSalesQuotation()).GetSalesQuotationMasterDBInfo(this.SelectedQuotationID);
                if (dbModel != null)
                {
                    txtSalesQuotationNo.Text = dbModel.Quotation_No;
                    txtSalesQuotationDate.Text = dbModel.Quotation_Date.ToString("dd MMM yyyy");
                    txtSalesEnquiryNo.Text = dbModel.TBL_MP_CRM_SalesEnquiry.SalesEnquiry_No;
                    txtSalesEnquiryDate.Text = dbModel.TBL_MP_CRM_SalesEnquiry.SalesEnquiry_Date.ToString("dd MMM yyyy");
                    txtClientName.Text = dbModel.Tbl_MP_Master_Party.PartyName;
                    txtRemarks.Text = dbModel.Remarks;

                    // GETTING SALES QUOTATION STATUS
                    SelectListItem selStatus = (new ServiceSalesQuotation()).GetAllActiveQuotationStatusesList().Where(x => x.ID == dbModel.FK_Userlist_Quotation_Status_ID).FirstOrDefault();
                    if (selStatus != null)
                        lblQuotationStatus.Text = String.Format("STATUS : {0}", selStatus.Description);


                    ServiceEmployee _empService = new ServiceEmployee();
                    TBL_MP_Master_Employee obj = _empService.GetEmployeeDbRecordByID(dbModel.FK_RepresentativeID);
                    if (obj != null)
                    {
                        txtSalesRepresentativeName.Text = obj.EmployeeName;
                        lblSalesRepresentativeCode.Text =string.Format("Code: {0}", obj.EmployeeCode);
                    }
                    obj = _empService.GetEmployeeDbRecordByID(dbModel.FK_BOQRepresentativeID);
                    if (obj != null)
                    {
                        txtBOQRepresentativeName.Text = obj.EmployeeName;
                        lblBoqRepresentativeCode.Text = string.Format("Code: {0}", obj.EmployeeCode);
                    }
                    headerBottom.Values.Heading= string.Format("Created: {0} dt. {1}", ServiceEmployee.GetEmployeeNameByID(dbModel.FK_PreparedBy), dbModel.CreatedDatetime);
                    if (dbModel.LastModifiedBy != null)
                        headerBottom.Values.Description = string.Format("Modified: {0} dt. {1}", ServiceEmployee.GetEmployeeNameByID((int)dbModel.LastModifiedBy), dbModel.LastModifiedDate);
                    else
                        headerBottom.Values.Description = string.Empty;

                    lblQuotationApprovalInfo.Text = "Unapproved Quotation";
                    lblQuotationApprovalInfo.StateCommon.Back.Color1 = (dbModel.FK_ApprovedBy==null) ? Color.Red : Color.Green;
                    WhosWhoModel premission = Program.CONTROL_ACCESS.ListControlAccess.Where(x => x.FormID == DB_FORM_IDs.SALES_QUOTATION).FirstOrDefault();
                    if (premission != null)
                    {
                        if (premission.CanApprove)
                            if (dbModel.FK_ApprovedBy == null)
                                btnApprove.Visible = true;
                            else
                            {
                                lblQuotationApprovalInfo.Text = string.Format("Approved: {0}", ServiceEmployee.GetEmployeeNameByID((int)dbModel.FK_ApprovedBy));
                                btnApprove.Visible = false;
                            }
                        else
                            btnApprove.Visible = false;
                    }
                }

                ServiceSalesQuotationBOQ _service = new ServiceSalesQuotationBOQ();
                SalesQuotationBOQSummary model = _service.GetQuotationBOQSummaryForQuotationID(this.SelectedQuotationID);
                if (model != null)
                {
                    PopulateBOQSummary(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotaionGeneralDetails::PoulateSalesQuotationMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void PopulateBOQSummary(SalesQuotationBOQSummary SUMMARY)
        {
            try
            {
                if (SUMMARY == null) return;
                headerGroupMaterialSupply.ValuesPrimary.Heading = string.Format("{0:0.00}", SUMMARY.MaterialAmountForAllSheets);
                headerGroupInstallation.ValuesPrimary.Heading = string.Format("{0:0.00}", SUMMARY.InstallationAmountForAllSheets);

                // MATERIAL SUPPLY DISCOUNT
                txtMaterialDiscountValue.Text = string.Format("{0:0.00}", SUMMARY.MaterialDiscount.ItemChargeValue);
                headerGroupMaterialDiscount.ValuesPrimary.Description = string.Format("{0:0.00}", SUMMARY.MaterialDiscountAmount);
                if (SUMMARY.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) rbtnMaterialDiscountPercent.Checked = true;
                if (SUMMARY.MaterialDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM) rbtnMaterialDiscountLumsum.Checked = true;

                // MATERIAL SUPPLY GST
                txtMaterialCGSTPercent.Text = string.Format("{0:0.00}", SUMMARY.MaterialGST.CGST_PERCENT);
                txtMaterialSGSTPercent.Text = string.Format("{0:0.00}", SUMMARY.MaterialGST.SGST_PERCENT);
                txtMaterialIGSTPercent.Text = string.Format("{0:0.00}", SUMMARY.MaterialGST.IGST_PERCENT);
                headerGroupMaterialGST.ValuesPrimary.Description = string.Format("{0:0.00}", SUMMARY.MaterialGST.GST_TOTAL_AMOUNT);
                headerGroupMaterialGST.ValuesSecondary.Heading = string.Format("SGST: {0:0.00}   CGST: {1:0.00}   IGST: {2:0.00}", SUMMARY.MaterialGST.SGST_AMOUNT, SUMMARY.MaterialGST.CGST_AMOUNT, SUMMARY.MaterialGST.IGST_AMOUNT);

                headerGroupMaterialSupply.ValuesSecondary.Description = string.Format("{0:0.00}", SUMMARY.MaterialFinalAmount);

                // INSTALLATION DISCOUNT
                txtInstallationDiscountValue.Text = string.Format("{0:0.00}", SUMMARY.InstallationDiscount.ItemChargeValue);
                headerGroupInstallationDiscount.ValuesPrimary.Description = string.Format("{0:0.00}", SUMMARY.InstallationDiscountAmount);
                if (SUMMARY.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.PERCENTAGE) rbtnInstallationDiscountPercent.Checked = true;
                if (SUMMARY.InstallationDiscount.ItemChargeType == ITEM_CHARGE_TYPE.LUMPSUM) rbtnInstallationDiscountLumsum.Checked = true;

                // INSTALLATION GST
                txtInstallationCGSTPercent.Text = string.Format("{0:0.00}", SUMMARY.InstallationGST.CGST_PERCENT);
                txtInstallationSGSTPercent.Text = string.Format("{0:0.00}", SUMMARY.InstallationGST.SGST_PERCENT);
                txtInstallationIGSTPercent.Text = string.Format("{0:0.00}", SUMMARY.InstallationGST.IGST_PERCENT);
                headerGroupInstallationGST.ValuesPrimary.Description = string.Format("{0:0.00}", SUMMARY.InstallationGST.GST_TOTAL_AMOUNT);
                headerGroupInstallationGST.ValuesSecondary.Heading = string.Format("SGST: {0:0.00}   CGST: {1:0.00}   IGST: {2:0.00}", SUMMARY.InstallationGST.SGST_AMOUNT, SUMMARY.InstallationGST.CGST_AMOUNT, SUMMARY.InstallationGST.IGST_AMOUNT);

                headerGroupInstallation.ValuesSecondary.Description = string.Format("{0:0.00}", SUMMARY.InstallationFinalAmount);

                headerSummaryMain.ValuesSecondary.Heading = string.Format("{0:0.00}", SUMMARY.QuotationFinalAmount);
         
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotaionGeneralDetails::PopulateBOQSummary", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ctrlSalesQuotaionGeneralDetails_Load(object sender, EventArgs e)
        {
           
        }
        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = (new ServiceSalesQuotation()).ApproveQuotation(this.SelectedQuotationID,Program.CURR_USER.EmployeeID);
                PoulateSalesQuotationMasterInfo();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotaionGeneralDetails::btnApprove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
