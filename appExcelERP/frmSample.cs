using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;

namespace appExcelERP
{
    public partial class frmSample : Form
    {
       
        public frmSample()
        {
            InitializeComponent();
              

        }

        private void mesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("am clicked!!");
        }
    }
}
