using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using DocumentServices.Modules.Readers.MsgReader;
using MsgReader;
namespace appExcelERP.Controls.CommonControls
{
    public partial class ctrlOutlookViewer : UserControl
    {
        public string FileName { get; set; }

        public ctrlOutlookViewer()
        {
            InitializeComponent();
        }
        public void ViewOutlookMessage(string fName)
        {
            FileName = fName;
            string tempFolder = GetTemporaryFolder();
            try
            {
                var msgReader = new Reader();
                var files = msgReader.ExtractToFolder(FileName, tempFolder, false);
                var error = msgReader.GetErrorMessage();
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);
                if (!string.IsNullOrEmpty(files[0]))
                    webBrowser1.Navigate(files[0]);
            }
            catch (Exception ex)
            {
                if (tempFolder != null && Directory.Exists(tempFolder))
                    Directory.Delete(tempFolder, true);
                MessageBox.Show(ex.Message);
            }
            
            

        }
        private string GetTemporaryFolder()
        {
            try
            {
                 var tempDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDirectory);
            return tempDirectory;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

    }
}
