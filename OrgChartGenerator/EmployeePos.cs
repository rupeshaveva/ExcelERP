using System;
using System.Collections.Generic;
using System.Text;

namespace OrgChartGenerator
{
    public class EmployeePos
    {
        public EmployeePos()
        {
            //throw new System.NotImplementedException();
        }
        private string _EmployeeID;

        public string EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        private System.Drawing.RectangleF _EmployeePosition;

        public System.Drawing.RectangleF EmployeePosition
        {
            get { return _EmployeePosition; }
            set { _EmployeePosition = value; }
        }
        
        
    }
}
