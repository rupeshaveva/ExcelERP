using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.COMMON
{
    public class AssociatedEmployeeModel
    {
        public bool Selected { get; set; }
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNumber { get; set; }

        public string ImagePath { get; set; }
        public string StringExpression { get { return string.Format("{0} {1} {2} {3}", this.Code, this.Name.ToUpper(), this.Designation.ToUpper(), this.Department.ToUpper()); } }


    }
}
