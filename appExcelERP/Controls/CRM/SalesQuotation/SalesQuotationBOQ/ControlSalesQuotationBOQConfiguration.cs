using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Models.UIModels;
using appExcelERP.Services;
using appExcelERP.Models;

namespace appExcelERP.Controls.CRM.SalesQuotationBOQ
{
    public partial class ControlSalesQuotationBOQConfiguration : UserControl
    {
        public SalesQuotationBOQConfigurationModel MODEL { get; set; }
        public ControlSalesQuotationBOQConfiguration()
        {
            InitializeComponent();
        }
        public ControlSalesQuotationBOQConfiguration(SalesQuotationBOQConfigurationModel configuration)
        {
            InitializeComponent();
            this.MODEL = configuration;

        }
        private void ControlSalesQuotationBOQConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                // populate material supply dropdowns
                PopulateMaterialAddOnChargesDropDowns();
                PopulateMaterialProfitMarginChargesDropDowns();
                PopulateMaterialDiscountChargesDropDowns();
                PopulateMaterialGSTChargesDropDowns();
                // populate installation and services dropdowns
                PopulateInstallationAddOnChargesDropDowns();
                PopulateInstallationProfitMarginChargesDropDowns();
                PopulateInstallationDiscountChargesDropDowns();
                PopulateInstallationGSTChargesDropDowns();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::ControlSalesQuotationBOQConfiguration_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void PopulateSalesQuotationBOQConfigurations()
        {
            try
            {
                if (this.MODEL == null) return;
                
                cboMaterialAddOnCharges.SelectedItem = ((List<SelectListItem>)cboMaterialAddOnCharges.DataSource).Where(x=>x.ID==(int)MODEL.MATERIAL_SUPPLY_ADD_ON_CHARGES).FirstOrDefault();
                cboMaterialProfitMargin.SelectedItem = ((List<SelectListItem>)cboMaterialProfitMargin.DataSource).Where(x => x.ID == (int)MODEL.MATERIAL_SUPPLY_PROFIT_MARGIN_CHARGES).FirstOrDefault();
                cboMaterialDiscounts.SelectedItem = ((List<SelectListItem>)cboMaterialDiscounts.DataSource).Where(x => x.ID == (int)MODEL.MATERIAL_SUPPLY_DISCOUNT_CHARGES).FirstOrDefault();
                cboMaterialGST.SelectedItem = ((List<SelectListItem>)cboMaterialGST.DataSource).Where(x => x.ID == (int)MODEL.MATERIAL_SUPPLY_GST_CHARGES).FirstOrDefault();


                cboInstallationAddOnCharges.SelectedItem = ((List<SelectListItem>)cboInstallationAddOnCharges.DataSource).Where(x => x.ID == (int)MODEL.INSTALLATION_ADD_ON_CHARGES).FirstOrDefault();
                cboInstallationProfitMargin.SelectedItem = ((List<SelectListItem>)cboInstallationProfitMargin.DataSource).Where(x => x.ID == (int)MODEL.INSTALLATION_PROFIT_MARGIN_CHARGES).FirstOrDefault();
                cboInstallationDiscount.SelectedItem = ((List<SelectListItem>)cboInstallationDiscount.DataSource).Where(x => x.ID == (int)MODEL.INSTALLATION_DISCOUNT_CHARGES).FirstOrDefault();
                cboInstallationGST.SelectedItem = ((List<SelectListItem>)cboInstallationGST.DataSource).Where(x => x.ID == (int)MODEL.INSTALLATION_GST_CHARGES).FirstOrDefault();
                


            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateSalesQuotationBOQConfigurations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        

        private void kryptonLabel5_Paint(object sender, PaintEventArgs e)
        {

        }
        
        #region     POPULATE DROPDOWNS MATERIAL SUPPLY
        private void PopulateMaterialAddOnChargesDropDowns()
        {
            try
            {
                cboMaterialAddOnCharges.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboMaterialAddOnCharges.DisplayMember = "Description";
                cboMaterialAddOnCharges.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateMaterialAddOnChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateMaterialProfitMarginChargesDropDowns()
        {
            try
            {
                cboMaterialProfitMargin.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboMaterialProfitMargin.DisplayMember = "Description";
                cboMaterialProfitMargin.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateMaterialProfitMarginChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateMaterialDiscountChargesDropDowns()
        {
            try
            {
                cboMaterialDiscounts.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboMaterialDiscounts.DisplayMember = "Description";
                cboMaterialDiscounts.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateMaterialDiscountChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateMaterialGSTChargesDropDowns()
        {
            try
            {
                cboMaterialGST.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboMaterialGST.DisplayMember = "Description";
                cboMaterialGST.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateMaterialGSTChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion
        #region     POPULATE DROPDOWNS INSTALLATIONS AND SERVICES
        private void PopulateInstallationAddOnChargesDropDowns()
        {
            try
            {
                cboInstallationAddOnCharges.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboInstallationAddOnCharges.DisplayMember = "Description";
                cboInstallationAddOnCharges.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateInstallationAddOnChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateInstallationProfitMarginChargesDropDowns()
        {
            try
            {
                cboInstallationProfitMargin.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboInstallationProfitMargin.DisplayMember = "Description";
                cboInstallationProfitMargin.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateInstallationProfitMarginChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateInstallationDiscountChargesDropDowns()
        {
            try
            {
                cboInstallationDiscount.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboInstallationDiscount.DisplayMember = "Description";
                cboInstallationDiscount.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateInstallationDiscountChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void PopulateInstallationGSTChargesDropDowns()
        {
            try
            {
                cboInstallationGST.DataSource = (new ServiceSalesQuotationBOQ()).GetSalesQuotationChargesApplicableTypesSelectListItems();
                cboInstallationGST.DisplayMember = "Description";
                cboInstallationGST.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::PopulateInstallationGSTChargesDropDowns", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            try
            {
                if (MODEL == null) MODEL = new SalesQuotationBOQConfigurationModel();
                MODEL.MATERIAL_SUPPLY_ADD_ON_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboMaterialAddOnCharges.SelectedItem).ID;
                MODEL.MATERIAL_SUPPLY_PROFIT_MARGIN_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboMaterialProfitMargin.SelectedItem).ID;
                MODEL.MATERIAL_SUPPLY_DISCOUNT_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboMaterialDiscounts.SelectedItem).ID;
                MODEL.MATERIAL_SUPPLY_GST_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboMaterialGST.SelectedItem).ID;

                MODEL.INSTALLATION_ADD_ON_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboInstallationAddOnCharges.SelectedItem).ID;
                MODEL.INSTALLATION_PROFIT_MARGIN_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboInstallationProfitMargin.SelectedItem).ID;
                MODEL.INSTALLATION_DISCOUNT_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboInstallationDiscount.SelectedItem).ID;
                MODEL.INSTALLATION_GST_CHARGES = (SALES_QUOTATION_BOQ_CHARGES_TYPE)((SelectListItem)cboInstallationGST.SelectedItem).ID;
                

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ControlSalesQuotationBOQConfiguration::btnSaveConfiguration_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
