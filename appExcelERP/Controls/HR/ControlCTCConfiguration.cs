using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using libERP.MODELS.COMMON;
using libERP.SERVICES.HR;
using appExcelERP.Forms.HR;
using libERP.MODELS.HR;
using libERP.SERVICES.COMMON;
using libERP.MODELS;
using libERP.SERVICES.MASTER;

namespace appExcelERP.Controls.HR
{
    public partial class ControlCTCConfiguration : UserControl
    {
        public EMPLOYMENT_TYPE employmentTYPE { get; set; }
        public DesignationwiseSalaryHeadModel salaryitem { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
       
        public BindingList<DesignationwiseSalaryHeadModel> _AllouncesList = null;
        public BindingList<DesignationwiseSalaryHeadModel> _FilteredAllouncesList = null;

        public BindingList<DesignationwiseSalaryHeadModel> _DeductionsList = null;
        public BindingList<DesignationwiseSalaryHeadModel> _FilteredDeductionsList = null;

        public ControlCTCConfiguration()
        {
            InitializeComponent();
        }
        public ControlCTCConfiguration(EMPLOYMENT_TYPE typeOfemployment)
        {
            InitializeComponent();
            this.employmentTYPE = typeOfemployment;
        }
        private void ControlCTCConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateDefaultAllouncesGrid();
                switch (this.employmentTYPE)
                {
                    case EMPLOYMENT_TYPE.PERMAMENT:
                        headerGroupHeader.ValuesPrimary.Heading = "Configure CTC for Permanent Employee";
                        break;
                    case EMPLOYMENT_TYPE.PROBATION:
                        headerGroupHeader.ValuesPrimary.Heading = "Configure CTC for Employee on Probation";
                        break;

                }
            }
            catch (Exception  ex )
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::ControlCTCConfiguration_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void PopulateAlluncesAndDeductionsSlaryHeadsGrid()
        {
            try
            {
                List<SelectListItem> lstDesignations = (new ServiceMASTERS()).GetAllDesignation();
                txtDesignationName.Text = string.Empty;
                if (this.DesignationID != 0)
                {
                    SelectListItem selDesignation = lstDesignations.Where(x => x.ID == this.DesignationID).FirstOrDefault();
                    if(selDesignation!=null) txtDesignationName.Text = selDesignation.Description.ToUpper();
                }
                txtEmploymentTypeName.Text = (employmentTYPE == EMPLOYMENT_TYPE.PERMAMENT) ? "PERMANENT" : "PROBATION";
                PopulateDefaultAllouncesGrid();
                PopulateDefaultDeductionGrid();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::PopulateAlluncesAndDeductionsSlaryHeadsGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region ALLOUNCES
        private void PopulateDefaultAllouncesGrid()
        {
            try
            {
                _AllouncesList = AppCommon.ConvertToBindingList< DesignationwiseSalaryHeadModel>((new ServiceDesignationWiseSalary()).GetAllAllouncesSalaryHeadsForDesignation(this.DesignationID, this.employmentTYPE));
                gridAllounces.DataSource = _AllouncesList;
                foreach (DataGridViewColumn col in gridAllounces.Columns)
                {
                    col.Visible = false;
                }
                gridAllounces.Columns["IsSelected"].Visible =
                gridAllounces.Columns["SalaryHeadName"].Visible =
                gridAllounces.Columns["ApplicableChargesAsString"].Visible =
                gridAllounces.Columns["SalaryHeadAmount"].Visible = true;
                gridAllounces.Columns["IsSelected"].Width = 40;
                gridAllounces.Columns["SalaryHeadName"].Width = (int)(gridAllounces.Width*.4);
                gridAllounces.Columns["SalaryHeadAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                gridAllounces.Columns["SalaryHeadAmount"].DefaultCellStyle.Format = "0.00";
                decimal totAllounceAmount = _AllouncesList.Sum(x => x.SalaryHeadAmount);
                txtTotalAllounces.Text = headerGroupAllounces.ValuesPrimary.Description = string.Format("{0:0.00}", totAllounceAmount);
                RefreshSummaryControls();


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::PopulateDefaultAllouncesGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridAllounces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int salaryHeadID = (int)gridAllounces.Rows[e.RowIndex].Cells["SalaryHeadID"].Value;
                // get the object from _AllouncesList collection for the selected SlaryHEadID
                DesignationwiseSalaryHeadModel model = _AllouncesList.Where(x => x.SalaryHeadID == salaryHeadID).FirstOrDefault();
                if (model != null) UpdateSalaryHeadInfo(model, SALARY_HEAD_TYPE.ALLOUNCE);
                PopulateDefaultAllouncesGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::gridAllounces_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //private void gridAllounces_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        this.DesignationID = (int)gridAllounces.Rows[e.RowIndex].Cells["ID"].Value;

        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = ex.Message;
        //        if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
        //        MessageBox.Show(errMessage, "ControlCTCConfiguration::gridAllounces_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void txtSearchAllounces_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _FilteredAllouncesList = new BindingList<DesignationwiseSalaryHeadModel>(_AllouncesList.Where(p => p.SearchString.Contains(txtSearchAllounces.Text.ToUpper())).ToList());
                gridAllounces.DataSource = _FilteredAllouncesList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::txtSearchAllounces_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region DEDUCTION
        private void PopulateDefaultDeductionGrid()
        {
            try
            {
                _DeductionsList = AppCommon.ConvertToBindingList<DesignationwiseSalaryHeadModel>((new ServiceDesignationWiseSalary()).GetAllDeductionsSalaryHeadsForDesignation(this.DesignationID, this.employmentTYPE));
                gridDeductions.DataSource = _DeductionsList;
                foreach (DataGridViewColumn col in gridDeductions.Columns)
                {
                    col.Visible = false;
                }
                gridDeductions.Columns["IsSelected"].Visible =
                gridDeductions.Columns["SalaryHeadName"].Visible =
                gridDeductions.Columns["ApplicableChargesAsString"].Visible =
                gridDeductions.Columns["SalaryHeadAmount"].Visible = true;
                gridDeductions.Columns["IsSelected"].Width = 40;
                gridDeductions.Columns["SalaryHeadName"].Width = (int)(gridDeductions.Width * .4);
                gridDeductions.Columns["SalaryHeadAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                decimal totdeductionAmount = _DeductionsList.Sum(x => x.SalaryHeadAmount);
                txtTotalDeductions.Text = headerGroupDeductions.ValuesPrimary.Description = string.Format("{0:0.00}", totdeductionAmount);
               RefreshSummaryControls();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::PopulateDefaultDeductionGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void gridDeductions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int salaryHeadID = (int)gridDeductions.Rows[e.RowIndex].Cells["SalaryHeadID"].Value;
                // get the object from _DeductionsList collection for the selected SlaryHEadID
                DesignationwiseSalaryHeadModel model = _DeductionsList.Where(x => x.SalaryHeadID == salaryHeadID).FirstOrDefault();
                if (model != null) UpdateSalaryHeadInfo(model, SALARY_HEAD_TYPE.DEDUCTION);
                PopulateDefaultDeductionGrid();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::gridDeductions_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void gridDeductions_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        this.DesignationID = (int)gridDeductions.Rows[e.RowIndex].Cells["ID"].Value;

        //    }
        //    catch (Exception ex)
        //    {
        //        string errMessage = ex.Message;
        //        if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
        //        MessageBox.Show(errMessage, "ControlCTCConfiguration::gridDeductions_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void txtSearchDeductions_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _FilteredDeductionsList = new BindingList<DesignationwiseSalaryHeadModel>(_DeductionsList.Where(p => p.SearchString.Contains(txtSearchDeductions.Text.ToUpper())).ToList());
                gridDeductions.DataSource = _FilteredDeductionsList;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::txtSearchDeductions_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private DesignationwiseSalaryHeadModel GetBasicSalaryHeadModel()
        {
            DesignationwiseSalaryHeadModel BasicSalary = null;
            try
            {
                //GET BASIC SALARY HEAD INFO
                int basicSalaryHeadID = Program.LIST_DEFAULTS.Where(x => x.ID == (int)APP_DEFAULT_VALUES.BasicSalaryHeadID).FirstOrDefault().DEFAULT_VALUE;
                BasicSalary = _AllouncesList.Where(X => X.SalaryHeadID == basicSalaryHeadID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::GetBasicSalaryHeadModel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return BasicSalary;
        }
        private void UpdateSalaryHeadInfo(DesignationwiseSalaryHeadModel model, SALARY_HEAD_TYPE headType)
        {
            DesignationwiseSalaryHeadModel prevModel = null;
            try
            {
                frmAddEditDesignationwiseSalaryHeadValue frm = new frmAddEditDesignationwiseSalaryHeadValue(model);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    switch (headType)
                    {
                        case SALARY_HEAD_TYPE.ALLOUNCE:
                            prevModel = _AllouncesList.Where(x => x.SalaryHeadID == frm.MODEL.SalaryHeadID).FirstOrDefault();
                            break;
                        case SALARY_HEAD_TYPE.DEDUCTION:
                            prevModel = _DeductionsList.Where(x => x.SalaryHeadID == frm.MODEL.SalaryHeadID).FirstOrDefault();
                            break;
                    }
                    
                    if (prevModel.ApplicableChargesType == ITEM_CHARGE_TYPE.PERCENTAGE)
                    {
                        DesignationwiseSalaryHeadModel basic = this.GetBasicSalaryHeadModel();
                        if (basic != null) prevModel.SalaryHeadAmount = (basic.SalaryHeadAmount * prevModel.ApplicableChargesValue) / 100;
                    }
                    if (prevModel.ApplicableChargesType == ITEM_CHARGE_TYPE.LUMPSUM)
                        prevModel.SalaryHeadAmount = prevModel.ApplicableChargesValue;

                    (new ServiceDesignationWiseSalary()).UpdateDesignationwiseSalaryHead(prevModel);
                   

                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::UpdateSalaryHeadInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshSummaryControls()
        {
            decimal totAllounceAmount = 0;
            decimal totDeductionAmount = 0;
            decimal monthlySalaryAmount = 0;
            try
            {
                if(_AllouncesList!=null)  totAllounceAmount = _AllouncesList.Sum(x => x.SalaryHeadAmount);
                if(_DeductionsList!=null) totDeductionAmount = _DeductionsList.Sum(x => x.SalaryHeadAmount);
                monthlySalaryAmount = totAllounceAmount - totDeductionAmount;

                txtTotalAllounces.Text = headerGroupAllounces.ValuesPrimary.Description = string.Format("{0:0.00}", totAllounceAmount);
                txtTotalDeductions.Text = headerGroupDeductions.ValuesPrimary.Description = string.Format("{0:0.00}", totDeductionAmount);
                txtMonthlySalary.Text = string.Format("{0:0.00}", monthlySalaryAmount);
                txtYearlyCTC.Text = string.Format("{0:0.00}", monthlySalaryAmount * 12);

            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlCTCConfiguration::RefreshSummaryControls", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void kryptonLabel3_Paint(object sender, PaintEventArgs e)
        {

        }

      

        
    }
}
