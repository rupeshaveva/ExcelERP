//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace libERP
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_MP_COMMON_Notification
    {
        public int PK_NotificationID { get; set; }
        public string NotificationTitle { get; set; }
        public string NotificationBody { get; set; }
        public string URL { get; set; }
        public Nullable<int> FK_EMPLOYEEID { get; set; }
        public string NotificationType { get; set; }
        public Nullable<int> FK_NotificationType { get; set; }
        public Nullable<bool> ISAutoClose { get; set; }
        public Nullable<bool> IS_Popoup { get; set; }
        public Nullable<bool> IS_Count { get; set; }
        public Nullable<bool> IS_View { get; set; }
        public Nullable<System.DateTime> InsertDateTime { get; set; }
        public Nullable<bool> ISUrlInPopup { get; set; }
    
        public virtual TBL_MP_Master_Employee TBL_MP_Master_Employee { get; set; }
    }
}
