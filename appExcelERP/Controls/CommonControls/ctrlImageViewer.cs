using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlImageViewer : UserControl
    {
        public string FileName { get; set; }

        public ctrlImageViewer()
        {
            InitializeComponent();
        }
        public ctrlImageViewer(string fileName)
        {
            InitializeComponent();
            this.FileName = fileName;
            pictBoxDocument.Load(this.FileName);
        }

        private void btnStretch_Click(object sender, EventArgs e)
        {
            pictBoxDocument.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void btnAutosize_Click(object sender, EventArgs e)
        {
            pictBoxDocument.SizeMode = PictureBoxSizeMode.AutoSize;
        }
         private void btnZoom_Click(object sender, EventArgs e)
        {
            pictBoxDocument.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
