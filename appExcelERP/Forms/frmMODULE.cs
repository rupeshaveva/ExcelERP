using appExcelERP.Controls.ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appExcelERP.Controls.InventoryItemControls;
using libERP.MODELS.COMMON;
using appExcelERP.Controls.CRM;
using appExcelERP.Controls.MASTERS;
using appExcelERP.Controls.PMC;
using appExcelERP.Controls.HR;
using appExcelERP.Controls.USER_INFO;

namespace appExcelERP.Forms
{
    public partial class frmMODULE : Form
    {
        public APP_MODULES currMODULE { get; set; }

        public pageADMINLanding pageADMIN { get; set; }
        public pageCRMLanding  pageCRM { get; set; }
        public pageMASTERS pageMASTER { get; set; }
        public pagePMC pagePMC { get; set; }
        public pageHRLanding pageHR { get; set; }
        public PageUserInfo pageMY_INFO { get; set; }

        public frmMODULE(APP_MODULES module)
        {
            InitializeComponent();
            currMODULE = module;
        }

        public void LoadModuleLandingPage()
        {
            try
            {
                switch (currMODULE)
                {
                    case APP_MODULES.ADMIN:
                        pageADMIN = new pageADMINLanding();
                        this.Controls.Add(pageADMIN);
                        pageADMIN.Dock = DockStyle.Fill;
                        break;
                    case APP_MODULES.CRM:
                        pageCRM = new pageCRMLanding();
                        this.Controls.Add(pageCRM);
                        pageCRM.Dock = DockStyle.Fill;
                        break;
                    case APP_MODULES.PMC:
                        pagePMC = new pagePMC();
                        this.Controls.Add(pagePMC);
                        pagePMC.Dock = DockStyle.Fill;
                        break;
                    case APP_MODULES.MASTERS:
                        pageMASTER = new pageMASTERS();
                        this.Controls.Add(pageMASTER);
                        pageMASTER.Dock = DockStyle.Fill;
                        break;
                    case APP_MODULES.HR:
                        pageHR = new pageHRLanding();
                        this.Controls.Add(pageHR);
                        pageHR.Dock = DockStyle.Fill;
                        break;
                    case APP_MODULES.USER_INFO:
                        pageMY_INFO = new PageUserInfo();
                        this.Controls.Add(pageMY_INFO);
                        pageMY_INFO.Dock = DockStyle.Fill;
                        break;

                }

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "frmMODULE::LoadModuleLandingPage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMODULE_Load(object sender, EventArgs e)
        {
            LoadModuleLandingPage();
        }
    }
}
