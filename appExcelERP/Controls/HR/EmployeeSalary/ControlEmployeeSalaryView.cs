using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Controls.HR.Attendance;
using libERP.SERVICES.HR;
using libERP.MODELS.HR;
using libERP;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Controls.HR.EmployeeSalary
{
    public partial class ControlEmployeeSalaryView : UserControl
    {
        public int EmployeeID { get; set; }
        public DateTime SalaryMonth { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public EmployeePayslipModel _Payslip { get; set; }

        public EmployeePayslipItemModel SelectedAllounce { get; set; }
        public EmployeePayslipItemModel SelectedDeduction { get; set; }

        public void SetReadOnly()
        {
            try
            {
                btnAddAllounces.Enabled = btnAddDeduction.Enabled = btnAutoGeneratePayslip.Enabled = btnDeleteAllounces.Enabled =
              btnEditAllounces.Enabled=btnEditDeduction.Enabled=btnSavePayslip.Enabled=  btnDeleteDeduction.Enabled =ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;
                txtPFEmployer.Enabled = txtESICEmployer.Enabled = txtGratuity.Enabled = txtBonus.Enabled =
             txtMedicalInsurance.Enabled = txtAccidentInsurance.Enabled =
             txtBasicSalaryPerDay.Enabled = txtBasicSalaryFullMonth.Enabled = txtBasicSalaryToProcess.Enabled = false;

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private int TotalDays = 0;
        private int PaidDays = 0;
               
        private ControlEmployeeAttendanceSummary _attendanceSummaryControl = null;

        public ControlEmployeeSalaryView()
        {
            InitializeComponent();
        }
        private void ControlEmployeeSalaryView_Load(object sender, EventArgs e)
        {
            try
            {
                splitContainerSalaryHeads.SplitterDistance = (int)(this.Width * .50);
                _attendanceSummaryControl = new ControlEmployeeAttendanceSummary();
                panelAttendanceSummary.Controls.Clear();
                panelAttendanceSummary.Controls.Add(_attendanceSummaryControl);
                _attendanceSummaryControl.Dock = DockStyle.Fill;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::ControlEmployeeSalaryView_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GeneratePaySlip()
        {
            try
            {
                _attendanceSummaryControl.EmployeeID = this.EmployeeID;
                _attendanceSummaryControl.AttendanceMonth = this.SalaryMonth;
                if (EmployeeID == 8)
                {
                    string s = "STOP";
                }
                _attendanceSummaryControl.PrepareCalendarSummary();
                _Payslip = (new ServiceEmployee()).GetEmployeePayslipModel(this.EmployeeID, this.SalaryMonth);
                if (_Payslip != null)
                {
                    #region CTC PROPERTIES
                    txtPFEmployer.Text = string.Format("{0:0.00}", _Payslip.PFEMPLOYER);
                    txtESICEmployer.Text = string.Format("{0:0.00}", _Payslip.ESICEMPLOYER);
                    txtBonus.Text = string.Format("{0:0.00}", _Payslip.BONUS);
                    txtGratuity.Text = string.Format("{0:0.00}", _Payslip.GRATUITY);
                    txtMedicalInsurance.Text = string.Format("{0:0.00}", _Payslip.MEDICALINSURANCE);
                    txtAccidentInsurance.Text = string.Format("{0:0.00}", _Payslip.ACCIDENTINSURANCE);
                    #endregion

                    lblBasicSalaryFullMonth.Text = string.Format("Basic Salary ({0} days)", _Payslip.TotalDays);
                    lblBasicSalaryToProcess.Text = string.Format("Basic Salary ({0} days)", _Payslip.PaidDays);
                    txtBasicSalaryFullMonth.Text = string.Format("{0:0.00}", _Payslip.BasicSalaryDefault);
                    txtBasicSalaryPerDay.Text = string.Format("{0:0.00}", _Payslip.BasicSalaryPerDay);
                    txtBasicSalaryToProcess.Text = string.Format("{0:0.00}", _Payslip.BasicSalaryApplied);

                    lblStandardAllounceTotal.Text = string.Format("{0:0.00}", _Payslip.StandardAllouncesAmount);
                    lblAdditionalAllouncesTotal.Text = string.Format("{0:0.00}", _Payslip.AdditionalAllouncesAmount);

                    lblStandardDeductionTotal.Text = string.Format("{0:0.00}", _Payslip.StandardDeducationAmount);
                    lblAdditionalDeductionstotal.Text = string.Format("{0:0.00}", _Payslip.AdditionalDeducationAmount);

                    lblGrossSalary.Text = string.Format("{0:0.00}", _Payslip.GrossSalaryAmount);
                    lblNetSalary.Text = string.Format("{0:0.00}", _Payslip.NetSalaryAmount);

                    gridAllounces.DataSource = _Payslip.MonthlyAllounces;
                    gridDeductions.DataSource = _Payslip.MonthlyDeducations;
                }

                btnSavePayslip.Visible = btnAutoGeneratePayslip.Visible = true;
                btnAddAllounces.Visible = btnEditAllounces.Visible = btnDeleteAllounces.Visible = true;
                btnAddDeduction.Visible = btnEditDeduction.Visible = btnDeleteDeduction.Visible = true;

                TBL_MP_HR_PayslipMaster dbRec = (new ServicePayRoll()).GetPaySlipRecordbyID(_Payslip.PayslipID);
                if (dbRec != null)
                {
                    if (dbRec.IsApproved)
                    {
                        btnSavePayslip.Visible = btnAutoGeneratePayslip.Visible = false;
                        btnAddAllounces.Visible = btnEditAllounces.Visible = btnDeleteAllounces.Visible = false;
                        btnAddDeduction.Visible = btnEditDeduction.Visible = btnDeleteDeduction.Visible = false;
                    }
                }
                


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::GeneratePaySlip", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void panelBasicSalary_Paint(object sender, PaintEventArgs e)
        {

        }
         private void UpdateTotals()
        {
            try
            {
                #region CTC PROPERTIES

                #endregion

                lblStandardAllounceTotal.Text = string.Format("{0:0.00}", _Payslip.StandardAllouncesAmount);
                lblAdditionalAllouncesTotal.Text = string.Format("{0:0.00}", _Payslip.AdditionalAllouncesAmount);

                lblStandardDeductionTotal.Text = string.Format("{0:0.00}", _Payslip.StandardDeducationAmount);
                lblAdditionalDeductionstotal.Text = string.Format("{0:0.00}", _Payslip.AdditionalDeducationAmount);

                lblGrossSalary.Text = string.Format("{0:0.00}", _Payslip.GrossSalaryAmount);
                lblNetSalary.Text = string.Format("{0:0.00}", _Payslip.NetSalaryAmount);

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::UpdateTotals", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region Allounces Salary View
        private void gridAllounces_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridAllounces.Columns["SalaryHeadID"].Visible = false;
                gridAllounces.Columns["IsStandard"].Visible = false;
                gridAllounces.Columns["IsApplied"].Width = 70;
                gridAllounces.Columns["ChargesType"].Visible = false;
                gridAllounces.Columns["HeadForCalculation"].Visible = false;
                gridAllounces.Columns["SalaryHeadCaption"].Visible = true;
                gridAllounces.Columns["SalaryHeadValue"].Visible = false;
                gridAllounces.Columns["SalaryHeadAmount"].Visible = true;
                gridAllounces.Columns["SalaryHeadName"].Width = 190;

                gridAllounces.Columns["SalaryHeadCaption"].DefaultCellStyle.Format = "0.00";
                gridAllounces.Columns["SalaryHeadCaption"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridAllounces.Columns["SalaryHeadCaption"].Width = 140;
                gridAllounces.Columns["SalaryHeadAmount"].DefaultCellStyle.Format = "0.00";
                gridAllounces.Columns["SalaryHeadAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                UpdateTotals();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::gridAllounces_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddAllounces_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeePayslipItemModel newItem = new EmployeePayslipItemModel();
                newItem.IsStandard = false;
                frmAddEditPayrollItem frm = new frmAddEditPayrollItem(newItem);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (newItem.IsApplied)
                    {
                        if (newItem.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM)
                            newItem.SalaryHeadAmount = newItem.SalaryHeadValue;
                        if (newItem.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE)
                        {
                            if(newItem.HeadForCalculation== libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                newItem.SalaryHeadAmount = (_Payslip.BasicSalaryApplied *newItem.SalaryHeadValue)/100;
                            if (newItem.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                newItem.SalaryHeadAmount = (_Payslip.GrossSalaryAmount * newItem.SalaryHeadValue) / 100;
                        }
                    }
                    _Payslip.MonthlyAllounces.Add(newItem);
                    gridAllounces.DataSource = null;
                    gridAllounces.DataSource = _Payslip.MonthlyAllounces;
                    gridAllounces.Refresh();

                    (new ServicePayRoll()).RecalculateEmployeeSalaryHeads(_Payslip);
                    UpdateTotals();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnAddAllounces_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridAllounces_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedAllounce = _Payslip.MonthlyAllounces[e.RowIndex];
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::gridAllounces_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditAllounces_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditPayrollItem frm = new frmAddEditPayrollItem(this.SelectedAllounce);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (this.SelectedAllounce.IsApplied)
                    {
                        if (SelectedAllounce.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM)
                            SelectedAllounce.SalaryHeadAmount = SelectedAllounce.SalaryHeadValue;
                        if (SelectedAllounce.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE)
                        {
                            if(SelectedAllounce.HeadForCalculation== libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                SelectedAllounce.SalaryHeadAmount = (_Payslip.BasicSalaryApplied * SelectedAllounce.SalaryHeadValue) / 100;
                            if (SelectedAllounce.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                SelectedAllounce.SalaryHeadAmount = (_Payslip.GrossSalaryAmount * SelectedAllounce.SalaryHeadValue) / 100;
                            

                        }
                    }
                    gridAllounces.DataSource = null;
                    gridAllounces.DataSource = _Payslip.MonthlyAllounces;
                    gridAllounces.Refresh();
                    (new ServicePayRoll()).RecalculateEmployeeSalaryHeads(_Payslip);
                    UpdateTotals();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnEditAllounces_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteAllounces_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.SelectedAllounce.IsStandard)
                {
                    string strMessage = string.Format("Are you sure to Delete\n{0}\nfrom the Payslip", this.SelectedAllounce.SalaryHeadName.ToUpper());
                    if (MessageBox.Show(strMessage, "Sure to Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Payslip.MonthlyAllounces.Remove(this.SelectedAllounce);
                        this.SelectedAllounce = null;
                        gridAllounces.DataSource = null;
                        gridAllounces.DataSource = _Payslip.MonthlyAllounces;
                        (new ServicePayRoll()).RecalculateEmployeeSalaryHeads(_Payslip);
                        UpdateTotals();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot Delete predefined Salary Heads", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnDeleteAllounces_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

        }
        #endregion

        #region Deductions Salary View
        private void gridDeductions_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.SelectedDeduction = _Payslip.MonthlyDeducations[e.RowIndex];
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::gridDeductions_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void gridDeductions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                gridDeductions.Columns["SalaryHeadID"].Visible = false;
                gridDeductions.Columns["IsStandard"].Visible = false;
                gridDeductions.Columns["IsApplied"].Width = 70;
                gridDeductions.Columns["ChargesType"].Visible = false;
                gridDeductions.Columns["HeadForCalculation"].Visible = false;
                gridDeductions.Columns["SalaryHeadCaption"].Visible = true;
                gridDeductions.Columns["SalaryHeadValue"].Visible = false;
                gridDeductions.Columns["SalaryHeadAmount"].Visible = true;
                gridDeductions.Columns["SalaryHeadName"].Width = 190;

                gridDeductions.Columns["SalaryHeadCaption"].DefaultCellStyle.Format = "0.00";
                gridDeductions.Columns["SalaryHeadCaption"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridAllounces.Columns["SalaryHeadCaption"].Width = 140;
                gridDeductions.Columns["SalaryHeadAmount"].DefaultCellStyle.Format = "0.00";
                gridDeductions.Columns["SalaryHeadAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                UpdateTotals();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::gridDeductions_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnAddDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeePayslipItemModel newItem = new EmployeePayslipItemModel();
                newItem.IsStandard = false;
                frmAddEditPayrollItem frm = new frmAddEditPayrollItem(newItem);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (newItem.IsApplied)
                    {
                        if (newItem.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM)
                            newItem.SalaryHeadAmount = newItem.SalaryHeadValue;
                        if (newItem.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE)
                        {
                            if(newItem.HeadForCalculation== libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                newItem.SalaryHeadAmount = (_Payslip.BasicSalaryApplied * newItem.SalaryHeadValue) / 100;
                            if (newItem.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                newItem.SalaryHeadAmount = (_Payslip.GrossSalaryAmount * newItem.SalaryHeadValue) / 100;
                            if (newItem.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            {
                                int basicSalaryHeadID = Program.LIST_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                                decimal basicAmount = _Payslip.MonthlyAllounces.Where(x => x.SalaryHeadID == basicSalaryHeadID).FirstOrDefault().SalaryHeadAmount;

                                int daSalaryHeadID = Program.LIST_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.daSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                                decimal daAmount = _Payslip.MonthlyAllounces.Where(x => x.SalaryHeadID == daSalaryHeadID).FirstOrDefault().SalaryHeadAmount;


                                newItem.SalaryHeadAmount = ((basicAmount + daAmount) * newItem.SalaryHeadValue) / 100;
                            }

                        }
                    }
                    _Payslip.MonthlyDeducations.Add(newItem);
                    gridDeductions.DataSource = null;
                    gridDeductions.DataSource = _Payslip.MonthlyDeducations;
                    gridDeductions.Refresh();
                    (new ServicePayRoll()).RecalculateEmployeeSalaryHeads(_Payslip);
                    UpdateTotals();
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnAddDeduction_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnEditDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddEditPayrollItem frm = new frmAddEditPayrollItem(this.SelectedDeduction);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (this.SelectedDeduction.IsApplied)
                    {
                        if (SelectedDeduction.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.LUMPSUM)
                            SelectedDeduction.SalaryHeadAmount = SelectedDeduction.SalaryHeadValue;
                        if (SelectedDeduction.ChargesType == libERP.MODELS.COMMON.ITEM_CHARGE_TYPE.PERCENTAGE)
                        {
                            if(SelectedDeduction.HeadForCalculation== libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                                SelectedDeduction.SalaryHeadAmount = (_Payslip.BasicSalaryApplied * SelectedDeduction.SalaryHeadValue) / 100;
                            if (SelectedDeduction.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                                SelectedDeduction.SalaryHeadAmount = (_Payslip.GrossSalaryAmount * SelectedDeduction.SalaryHeadValue) / 100;
                            if (SelectedDeduction.HeadForCalculation == libERP.MODELS.COMMON.SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            {
                                int basicSalaryHeadID = Program.LIST_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID ).FirstOrDefault().DEFAULT_VALUE;
                                decimal basicAmount = _Payslip.MonthlyAllounces.Where(x => x.SalaryHeadID == basicSalaryHeadID).FirstOrDefault().SalaryHeadAmount;

                                int daSalaryHeadID = Program.LIST_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.daSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                                decimal daAmount = _Payslip.MonthlyAllounces.Where(x => x.SalaryHeadID == daSalaryHeadID).FirstOrDefault().SalaryHeadAmount;


                                SelectedDeduction.SalaryHeadAmount = ((basicAmount + daAmount) * SelectedDeduction.SalaryHeadValue) / 100;
                            }

                        }
                    }
                    gridDeductions.DataSource = null;
                    gridDeductions.DataSource = _Payslip.MonthlyDeducations;
                    gridDeductions.Refresh();
                    (new ServicePayRoll()).RecalculateEmployeeSalaryHeads(_Payslip);
                    UpdateTotals();
                }
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnEditDeduction_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeleteDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.SelectedDeduction.IsStandard)
                {
                    string strMessage = string.Format("Are you sure to Delete\n{0}\nfrom the Payslip", this.SelectedDeduction.SalaryHeadName.ToUpper());
                    if (MessageBox.Show(strMessage, "Sure to Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _Payslip.MonthlyDeducations.Remove(this.SelectedDeduction);
                        this.SelectedDeduction = null;
                        gridDeductions.DataSource = null;
                        gridDeductions.DataSource = _Payslip.MonthlyDeducations;
                        (new ServicePayRoll()).RecalculateEmployeeSalaryHeads(_Payslip);
                        UpdateTotals();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot Delete predefined Salary Heads", "Caution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnDeleteDeduction_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void btnSavePayslip_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _Payslip.PFEMPLOYER = decimal.Parse(txtPFEmployer.Text);
                _Payslip.ESICEMPLOYER = decimal.Parse(txtESICEmployer.Text);
                _Payslip.BONUS = decimal.Parse(txtBonus.Text);
                _Payslip.GRATUITY = decimal.Parse(txtGratuity.Text);
                _Payslip.MEDICALINSURANCE = decimal.Parse(txtMedicalInsurance.Text);
                _Payslip.ACCIDENTINSURANCE = decimal.Parse(txtAccidentInsurance.Text);
                if ((new ServiceEmployee()).SaveEmployeePayslip(_Payslip))
                {
                    string strMessage = string.Format("Payslip of {0} for {1}\nsaved to the database.", _Payslip.EmployeeName, _Payslip.SalaryMonth);
                    MessageBox.Show(strMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnSavePayslip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            this.Cursor = Cursors.Default;
        }
        private void btnAutoGeneratePayslip_Click(object sender, EventArgs e)
        {
            try
            {
                _Payslip = (new ServiceEmployee()).GenerateNewPayslip(this.EmployeeID, this.SalaryMonth);
                if (_Payslip != null)
                {
                    lblBasicSalaryFullMonth.Text = string.Format("Basic Salary ({0} days)", _Payslip.TotalDays);
                    lblBasicSalaryToProcess.Text = string.Format("Basic Salary ({0} days)", _Payslip.PaidDays);
                    txtBasicSalaryFullMonth.Text = string.Format("{0:0.00}", _Payslip.BasicSalaryDefault);
                    txtBasicSalaryPerDay.Text = string.Format("{0:0.00}", _Payslip.BasicSalaryPerDay);
                    txtBasicSalaryToProcess.Text = string.Format("{0:0.00}", _Payslip.BasicSalaryApplied);

                    gridAllounces.DataSource = _Payslip.MonthlyAllounces;
                    gridDeductions.DataSource = _Payslip.MonthlyDeducations;
                    UpdateTotals();
                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnAutoGeneratePayslip_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string fName = string.Format("{0}Payslip{1}.xls", AppCommon.GetDefaultStorageFolderPathForPayslip(), SalaryMonth.ToString("MMMyyyy").ToUpper());
                (new ServiceExcelApp()).ExportEmployeePayslipDataToExcel(_Payslip, fName, SalaryMonth,Program.CURR_USER.FinYearID);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeSalaryView::btnExportToExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
