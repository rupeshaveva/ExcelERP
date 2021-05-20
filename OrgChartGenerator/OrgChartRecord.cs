using System;
using System.Collections.Generic;
using System.Text;

namespace OrgChartGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class OrgChartRecord : IDisposable
    {
        
        /// <summary>
        /// Top Left Corner of the specific employee
        /// </summary>
        private System.Drawing.Rectangle Pos;
        /// <summary>
        /// The data of the employee
        /// </summary>
        private OrgData.OrgDetailsRow EmployeeRecord;
        private int _EmployeeCount = 0;

        public int EmployeeCount
        {
            get { return _EmployeeCount; }
            set { _EmployeeCount = value; }
        }
        
        public OrgChartRecord()
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// The Top Left Corener of the employee Box
        /// </summary>
        public System.Drawing.Rectangle  EmployeePos
        {
            get
            {
                return Pos ;
            }
            set
            {
                Pos = value;
            }
            
        }

        /// <summary>
        /// The record with all employee data
        /// </summary>
        public OrgData.OrgDetailsRow EmployeeData
        {
            get
            {
                return EmployeeRecord;
            }
            set
            {
                EmployeeRecord = value;  
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
