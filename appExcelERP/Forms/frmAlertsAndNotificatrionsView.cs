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
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES;
using libERP.SERVICES.COMMON;

namespace appExcelERP.Forms
{
    public partial class frmAlertsAndNotificatrionsView : KryptonForm
    {
        public List<NotificationModel> notificationItems = null;
        public frmAlertsAndNotificatrionsView()
        {
            InitializeComponent();
        }

        private void frmAlertsAndNotificatrionsView_Load(object sender, EventArgs e)
        {
            PopulateAllNotificationsForCurrentUser();
        }

        public void PopulateAllNotificationsForCurrentUser()
        {
            notificationItems = (new ServiceNotification()).GetAllAssociationNotifications(Program.CURR_USER.EmployeeID);
            gridNotifications.DataSource = notificationItems;
            gridNotifications.Columns["ID"].Visible = gridNotifications.Columns["Key"].Visible = gridNotifications.Columns["Title"].Visible = gridNotifications.Columns["Description"].Visible = false;
            gridNotifications.Columns["FormattedDescription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void txtSearchNotification_TextChanged(object sender, EventArgs e)
        {
            gridNotifications.DataSource = new BindingList<NotificationModel>(notificationItems.Where(p => p.FormattedDescription.Contains(txtSearchNotification.Text.ToUpper())).ToList()); ;
        }
    }
}
