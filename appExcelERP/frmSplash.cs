using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP
{
    public partial class frmSplash : Form
    {

        string loadingText =string.Format("Connecting Database Server ...........");
        int loadIndex = 0;
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            lblTitle.Text = loadingText.Substring(0, loadIndex++);
            if (loadIndex > loadingText.Length - 1)
            {
                loadIndex = 1;
            }
            //lblTitle.Visible = !lblTitle.Visible;
        }
    }
}
