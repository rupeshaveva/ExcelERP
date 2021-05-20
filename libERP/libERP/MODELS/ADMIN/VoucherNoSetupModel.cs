using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.ADMIN
{
    public class VoucherNoSetupModel
    {
        public int ID { get; set; }
        public string PreviewVoucherNo { get; set; }
        public string Prefix { get; set; }
        public string NoSeperator { get; set; }
        public int NoPadding { get; set; }
        public string Suffix { get; set; }

        public bool NoContinued { get; set; }
        public int? StartingNo { get; set; }
        public int FormID { get; set; }
        public int YearID { get; set; }

    }
}
