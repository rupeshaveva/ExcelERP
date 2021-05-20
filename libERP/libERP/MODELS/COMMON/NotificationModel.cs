using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.COMMON
{
    public class NotificationModel
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string FormattedDescription { get { return string.Format("{0}\n{1}", this.Title.ToUpper(), this.Description.ToUpper()); } }

    }
}
