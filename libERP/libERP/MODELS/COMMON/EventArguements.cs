using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.COMMON
{
    public class EventArguementModel : EventArgs
    {
        public string Message { get; set; }
        public int ID { get; set; }
        public int ProgressPercent { get; set; }
    }

    public class ProgressEventArguementModel : EventArgs
    {
        public int Percentage { get; set; }
        public string Message { get; set; }
        public int ID { get; set; }
        public bool HasError { get; set; }
    }

    public class eventArgThreadProgressModel
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public List<SelectListItem> List { get; set; }
        public string Key { get; set; }
    }
}
