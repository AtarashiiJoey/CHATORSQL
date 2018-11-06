using System;
using System.ComponentModel.DataAnnotations;

namespace Softserve_Chat_SignalR.Models
{
    public class tblUserMetadata
    {
        [Display(Name = "User ID")]
        public int iUserID;

        [Display(Name = "Date added")]
        public System.DateTime dtAdded;

        [Display(Name = "Added by")]
        public int iAddedBy;

        [Display(Name = "Date edited")]
        public DateTime? dtEdited;

        [Display(Name = "Edited by")]
        public int? iEditedBy;

        [StringLength(50)]
        [Display(Name = "First Name")]
        public string strFirstName;

        [StringLength(50)]
        [Display(Name = "Surname")]
        public string strSurname;

        [StringLength(250)]
        [Display(Name = "Email")]
        public string strEmailAddress;

        [StringLength(50)]
        [Display(Name = "Password")]
        public string strPassword;

        [Display(Name = "Soft delete")]
        public int bIsDeleted;
    }

    public class tblReasonForChatMetadata
    {
        [Display(Name = "Reason for chat ID")]
        public int iReasonForChatID;

        [Display(Name = "Date added")]
        public System.DateTime dtAdded;

        [Display(Name = "Added by")]
        public int iAddedBy;

        [Display(Name = "Date edited")]
        public DateTime? dtEdited;

        [Display(Name = "Edited by")]
        public int? iEditedBy;

        [StringLength(50)]
        [Display(Name = "Reason")]
        public string strReason;

        [Display(Name = "Soft delete")]
        public bool bIsDeleted;
    }

    public class tblChatMessageMetadata
    {
        [Display(Name = "Chat message ID")]
        public int iChatMessageID;

        [Display(Name = "User ID")]
        public int iUserID;

        [Display(Name = "Chat log ID")]
        public int iChatLogID;

        [StringLength(2500)]
        [Display(Name = "Ticket reference")]
        public string strMessage;

        [Display(Name = "Soft delete")]
        public bool bIsDeleted;
    }

    public class tblChatLogMetadata
    {
        [Display(Name = "Chat log ID")]
        public int iChatLogID;

        [Display(Name = "Date added")]
        public System.DateTime dtAdded;

        [Display(Name = "Added by")]
        public int iAddedBy;

        [Display(Name = "Date edited")]
        public DateTime? dtEdited;

        [Display(Name = "Edited by")]
        public int? iEditedBy;

        [Display(Name = "User ID")]
        public int iUserID;

        [StringLength(50)]
        [Display(Name = "First Name")]
        public string strFirstName;

        [StringLength(50)]
        [Display(Name = "Surname")]
        public string strSurname;

        [StringLength(250)]
        [Display(Name = "Email")]
        public string strEmailAddress;

        [StringLength(50)]
        [Display(Name = "Contact number")]
        public string strContactNumber;
        
        [Display(Name = "End of chat")]
        public System.DateTime dtEndOfChat;

        [StringLength(50)]
        [Display(Name = "Ticket reference")]
        public string strRef;

        [Display(Name = "Reason for chat ID")]
        public int iReasonForChatID;
        
        [Display(Name = "Ticket Status ID")]
        public int iStatusID;

        [Display(Name = "Soft delete")]
        public int bIsDeleted;
    }

    public class tblStatusMetadata
    {
        [Display(Name = "Status ID")]
        public int iStatusID;

        [Display(Name = "Date added")]
        public System.DateTime dtAdded;

        [Display(Name = "Added by")]
        public int iAddedBy;

        [Display(Name = "Date edited")]
        public DateTime? dtEdited;

        [Display(Name = "Edited by")]
        public int? iEditedBy;

        [StringLength(50)]
        [Display(Name = "Status")]
        public string strStatus;

        [Display(Name = "Soft delete")]
        public bool bIsDeleted;
    }
}