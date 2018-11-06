//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Softserve_Chat_SignalR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            this.tblChatLogs = new HashSet<tblChatLog>();
            this.tblChatMessages = new HashSet<tblChatMessage>();
        }
    
        public int iUserID { get; set; }
        public System.DateTime dtAdded { get; set; }
        public int iAddedBy { get; set; }
        public Nullable<System.DateTime> dtEdited { get; set; }
        public Nullable<int> iEditedBy { get; set; }
        public string strFirstName { get; set; }
        public string strSurname { get; set; }
        public string strEmailAddress { get; set; }
        public string strPassword { get; set; }
        public bool bIsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChatLog> tblChatLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChatMessage> tblChatMessages { get; set; }
    }
}
