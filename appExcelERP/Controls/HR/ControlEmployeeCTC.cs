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
using libERP.SERVICES.MASTER;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using libERP.MODELS.COMMON;
using appExcelERP.Forms.HR;

namespace appExcelERP.Controls.HR
{
    public partial class ControlEmployeeCTC : UserControl
    {
        
        public int SelectedEmployeeID { get; set; }
        public EmployeeSalaryHeadModel salaryitem { get; set; }
        public EmployeeSalaryHeadModel SelectedModel { get; set; }
        // public EMPLOYMENT_TYPE employmentTYPE { get; set; }

        BindingList<EmployeeSalaryHeadModel> _AllounceList = null;
        BindingList<EmployeeSalaryHeadModel> _filteredAllounceList = null;

        BindingList<EmployeeSalaryHeadModel> _DeductionList = null;
        BindingList<EmployeeSalaryHeadModel> _filteredDeductionList = null;

        public bool ShowingAllAllounces  { get; set; }
        public bool ShowingAllDeductions { get; set; }

        public ControlEmployeeCTC()
        {
            InitializeComponent();
        }
        public ControlEmployeeCTC(int empid)
        {
            InitializeComponent();
            this.SelectedEmployeeID = empid;
        }

        public void SetReadOnly()
        {
            try
            {
                btnUpdateAllounces.Enabled = btnUpdateDeduction.Enabled  = ComponentFactory.Krypton.Toolkit.ButtonEnabled.False;


            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeGeneralInfo::SetReadOnly", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ControlEmployeeCTC_Load(object sender, EventArgs e)
        {
            try
            {
               PopulateDefaultAllouncesGrid();
               PopulateDefaultDeductionGrid();
                ShowingAllAllounces = true;
                ShowingAllDeductions = true;
                btnCollapseAllounces_Click(this.btnCollapseAllounces, null);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::ControlEmployeeCTC_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
       public void PopulateAllouncesAndDeductionCTCGrid()
        {
            try
            {
                PopulateDefaultAllouncesGrid();
                PopulateDefaultDeductionGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::PopulateAllouncesAndDeductionCTCGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region ALLOUNCES
        //private void gridAllounces_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        this.SelectedEmployeeID = (int)gridAllounces.Rows[e.RowIndex].Cells["ID"].Value;

        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = ex.Message;
        //        if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
        //        MessageBox.Show(errMessage, "ControlEmployeeCTC::gridLastEmployerInfo_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public void PopulateDefaultAllouncesGrid()
        {
            try
            {

                _AllounceList = AppCommon.ConvertToBindingList<EmployeeSalaryHeadModel>((new ServiceEmployee()).GetAllAllouncesSalaryHeadsForEmployee(this.SelectedEmployeeID));
                gridAllounces.DataSource = _AllounceList;
                txtTotalAllounce.Text = string.Format("{0:0.00}", _AllounceList.Sum(x => x.SalaryHeadAmount));
                RefreshSummaryControls();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::PopulateDefaultAllouncesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridAllounces_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewColumn col in gridAllounces.Columns)
                {
                    col.Visible = false;
                }
                gridAllounces.Columns["IsSelected"].Visible =
                gridAllounces.Columns["SalaryHeadName"].Visible =
                gridAllounces.Columns["ApplicableChargesAsString"].Visible =
                gridAllounces.Columns["SalaryHeadAmount"].Visible = true;
                gridAllounces.Columns["IsSelected"].Width = 60;
                gridAllounces.Columns["SalaryHeadName"].Width = (int)(gridAllounces.Width * .5);
                gridAllounces.Columns["SalaryHeadAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridAllounces.Columns["SalaryHeadAmount"].DefaultCellStyle.Format = "0.00";
                gridAllounces.Columns["ApplicableChargesAsString"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridAllounces.Columns["ApplicableChargesAsString"].DefaultCellStyle.Format = "0.00";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::gridAllounces_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void gridAllounces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int salaryHeadID = (int)gridAllounces.Rows[e.RowIndex].Cells["SalaryHeadID"].Value;
                EmployeeSalaryHeadModel model = _AllounceList.Where(x => x.SalaryHeadID == salaryHeadID).FirstOrDefault();
                if (model != null) UpdateEmployeeCTCInfo(model, SALARY_HEAD_TYPE.ALLOUNCE);
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::gridAllounces_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnUpdateAllounces_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                foreach (EmployeeSalaryHeadModel item in _AllounceList)
                {
                    (new ServiceEmployee()).UpdateEmployeewiseSalaryHead(item);
                    result = true;
                }

                if (result)
                    MessageBox.Show("CTC Allounce Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {


                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::btnUpdateAllounces_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCollapseAllounces_Click(object sender, EventArgs e)
        {
            try
            {
                ShowingAllAllounces = !ShowingAllAllounces;
                foreach (DataGridViewRow mRow in gridAllounces.Rows)
                {
                    if ((bool)mRow.Cells["IsSelected"].Value == false)
                    {
                        mRow.Visible = !ShowingAllAllounces;
                    }
                }
                gridAllounces.Refresh();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::btnCollapseAllounces_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DEDUCTION
        //private void gridDeductions_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        this.SelectedEmployeeID = (int)gridDeductions.Rows[e.RowIndex].Cells["ID"].Value;

        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = ex.Message;
        //        if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
        //        MessageBox.Show(errMessage, "ControlEmployeeCTC::gridDeductions_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public void PopulateDefaultDeductionGrid()
        {
            try
            {
                _DeductionList = AppCommon.ConvertToBindingList<EmployeeSalaryHeadModel>((new ServiceEmployee()).GetAllDeductionsSalaryHeadsForEmployee(this.SelectedEmployeeID));
                gridDeductions.DataSource = _DeductionList;
                foreach (DataGridViewColumn col in gridDeductions.Columns)
                {
                    col.Visible = false;
                }
                gridDeductions.Columns["IsSelected"].Visible =
                gridDeductions.Columns["SalaryHeadName"].Visible =
                gridDeductions.Columns["ApplicableChargesAsString"].Visible =
                gridDeductions.Columns["SalaryHeadAmount"].Visible = true;
                gridDeductions.Columns["IsSelected"].Width = 80;
                gridDeductions.Columns["SalaryHeadName"].Width = (int)(gridDeductions.Width * .4);
                gridDeductions.Columns["SalaryHeadAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                decimal totdeductionAmount = _DeductionList.Sum(x => x.SalaryHeadAmount);
               // txtTotalDeduction.Text = headerGroupDeduction.ValuesPrimary.Description = string.Format("{0:0.00}", totdeductionAmount);
                txtTotalDeduction.Text = totdeductionAmount.ToString();
               RefreshSummaryControls();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::PopulateDefaultDeductionGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridDeductions_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewColumn col in gridDeductions.Columns)
                {
                    col.Visible = false;
                }
                gridDeductions.Columns["IsSelected"].Visible =
                gridDeductions.Columns["SalaryHeadName"].Visible =
                gridDeductions.Columns["ApplicableChargesAsString"].Visible =
                gridDeductions.Columns["SalaryHeadAmount"].Visible = true;
                gridDeductions.Columns["IsSelected"].Width = 60;
                gridDeductions.Columns["SalaryHeadName"].Width = (int)(gridDeductions.Width * .5);
                gridDeductions.Columns["SalaryHeadAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridDeductions.Columns["SalaryHeadAmount"].DefaultCellStyle.Format = "0.00";
                gridDeductions.Columns["ApplicableChargesAsString"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridDeductions.Columns["ApplicableChargesAsString"].DefaultCellStyle.Format = "0.00";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::gridDeductions_DataBindingComplete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void gridDeductions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int salaryHeadID = (int)gridDeductions.Rows[e.RowIndex].Cells["SalaryHeadID"].Value;
                // get the object from _DeductionsList collection for the selected SlaryHEadID
                EmployeeSalaryHeadModel model = _DeductionList.Where(x => x.SalaryHeadID == salaryHeadID).FirstOrDefault();
                if (model != null) UpdateEmployeeCTCInfo(model, SALARY_HEAD_TYPE.DEDUCTION);
               // PopulateDefaultDeductionGrid();
             
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::gridDeductions_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         private void btnUpdateDeduction_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                foreach (EmployeeSalaryHeadModel item in _DeductionList)
                {
                    (new ServiceEmployee()).UpdateEmployeewiseSalaryHead(item);
                    result = true;
                }
                if (result)
                    MessageBox.Show("CTC Deduction Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::btnUpdateDeduction_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCollapseDeductions_Click(object sender, EventArgs e)
        {
            try
            {
                ShowingAllDeductions = !ShowingAllDeductions;
                foreach (DataGridViewRow mRow in gridDeductions.Rows)
                {
                    if ((bool)mRow.Cells["IsSelected"].Value == false)
                    {
                        mRow.Visible = !ShowingAllDeductions;
                    }
                }
                gridDeductions.Refresh();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::btnCollapseDeductions_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private EmployeeSalaryHeadModel GetEmployeeBasicSalaryHeadModel()
        {
            EmployeeSalaryHeadModel BasicSalary = null;
            try
            {
                //get basic salary head info
                int basicSalaryHeadID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                BasicSalary = _AllounceList.Where(X => X.SalaryHeadID == basicSalaryHeadID).FirstOrDefault();
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::GetEmployeeBasicSalaryHeadModel", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            return BasicSalary;
        }
        private void UpdateEmployeeCTCInfo(EmployeeSalaryHeadModel model, SALARY_HEAD_TYPE headType)
        {
            EmployeeSalaryHeadModel prevModel = null;
            try
            {
                frmAddEditEmployeeWiseSalaryHeadValue frm = new frmAddEditEmployeeWiseSalaryHeadValue(model);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    switch (headType)
                    {
                        case SALARY_HEAD_TYPE.ALLOUNCE:
                            prevModel = _AllounceList.Where(x => x.SalaryHeadID == frm.MODEL.SalaryHeadID).FirstOrDefault();
                            break;
                        case SALARY_HEAD_TYPE.DEDUCTION:
                            prevModel =_DeductionList.Where(x => x.SalaryHeadID == frm.MODEL.SalaryHeadID).FirstOrDefault();
                            break;
                    }

                    if (model.IsSelected)
                    {
                        if (prevModel.ApplicableChargesType == ITEM_CHARGE_TYPE.PERCENTAGE)
                        {
                            if (prevModel.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC)
                            {
                                EmployeeSalaryHeadModel basic = this.GetEmployeeBasicSalaryHeadModel();
                                if (basic != null) prevModel.SalaryHeadAmount = (basic.SalaryHeadAmount * prevModel.ApplicableChargesValue) / 100;
                            }
                            if (prevModel.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_GROSS)
                            {
                                decimal gross = decimal.Parse(txtTotalAllounce.Text.Trim());
                                prevModel.SalaryHeadAmount = (gross * prevModel.ApplicableChargesValue) / 100;
                            }
                            if (prevModel.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA)
                            {
                                int basicSalaryHeadID = Program.LIST_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                                decimal basicAmount = _AllounceList.Where(x => x.SalaryHeadID == basicSalaryHeadID).FirstOrDefault().SalaryHeadAmount; 

                                int daSalaryHeadID = Program.LIST_DEFAULTS.Where(X => X.ID == (int)APP_DEFAULT_VALUES.daSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                                decimal daAmount = _AllounceList.Where(x => x.SalaryHeadID == daSalaryHeadID).FirstOrDefault().SalaryHeadAmount;
                                                             

                                prevModel.SalaryHeadAmount = ((basicAmount + daAmount) * model.ApplicableChargesValue) / 100;
                            }

                        }
                        if (prevModel.ApplicableChargesType == ITEM_CHARGE_TYPE.LUMPSUM)
                            prevModel.SalaryHeadAmount = prevModel.ApplicableChargesValue;
                    }
                    else
                    {
                        model.ApplicableChargesType = ITEM_CHARGE_TYPE.NONE;
                        model.ApplicableChargesValue = 0;
                        model.SalaryHeadAmount = 0;
                    }

                    gridAllounces.DataSource = _AllounceList;
                    gridDeductions.DataSource = _DeductionList;
                    gridAllounces.Refresh();
                    gridDeductions.Refresh();
                    RefreshSummaryControls();

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::UpdateEmployeeCTCInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }
        private void RefreshSummaryControls()
        {
            decimal totAllounceAmount = 0;
            decimal totDeductionAmount = 0;
            decimal monthlySalaryAmount = 0;
            try
            {
                if (_AllounceList != null) totAllounceAmount = _AllounceList.Sum(x => x.SalaryHeadAmount);
                if (_DeductionList != null) totDeductionAmount = _DeductionList.Sum(x => x.SalaryHeadAmount);
                monthlySalaryAmount = totAllounceAmount - totDeductionAmount;

                txtTotalAllounce.Text = headerGroupAllounces.ValuesSecondary.Description = string.Format("{0:0.00}", totAllounceAmount);
                txtTotalDeduction.Text = headerGroupDeduction.ValuesSecondary.Description = string.Format("{0:0.00}", totDeductionAmount);
                txtMonthlySalary.Text = string.Format("{0:0.00}", monthlySalaryAmount);
                txtYearlyCTC.Text = string.Format("{0:0.00}", monthlySalaryAmount * 12);

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlEmployeeCTC::RefreshSummaryControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}