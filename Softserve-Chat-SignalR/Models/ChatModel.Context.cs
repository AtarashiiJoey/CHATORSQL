﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblChatLog> tblChatLogs { get; set; }
        public virtual DbSet<tblChatMessages> tblChatMessages { get; set; }
        public virtual DbSet<tblReasonForChat> tblReasonForChats { get; set; }
        public virtual DbSet<tblStatus> tblStatuses { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}
