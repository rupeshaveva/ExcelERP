using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace appExcelERP.Forms
{
    public partial class frmInput : KryptonForm
    {
        public string HeaderTitle { get { return kryptonHeaderGroup1.ValuesPrimary.Heading; } set { kryptonHeaderGroup1.ValuesPrimary.Heading = value; } }

        public frmInput()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtInput_Validating(object sender, CancelEventArgs e)
        {
            if (txtInput.Text.Trim() == string.Empty)
            {
                errorProvider1.SetError(txtInput, "Can't be left Blank");
                e.Cancel = true;
            }
        }

        private void frmInput_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
