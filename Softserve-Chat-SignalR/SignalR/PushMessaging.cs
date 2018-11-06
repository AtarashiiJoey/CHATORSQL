using Softserve_Chat_SignalR.Models;
using Softserve_Chat_SignalR.SqlServerNotifier;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Softserve_Chat_SignalR.SignalR
{
    public class PushMessaging
    {
        static PushMessaging _instance = null;
        NewMessageNotifier _newMessageNotifier;
        readonly Action<IEnumerable<string>> _dispatcher;
        readonly string _connString;
        readonly string _selectQuery;

        public static PushMessaging GetInstance(Action<IEnumerable<string>> dispatcher)
        {
            if (_instance == null)
                _instance = new PushMessaging(dispatcher);

            return _instance;
        }
        private PushMessaging(Action<IEnumerable<string>> dispatcher)
        {
            _dispatcher = dispatcher;
            _connString = @"Server=.\SQLEXPRESS;Database=Softserve-Chat-DB;Integrated Security=SSPI";
            //_connString = ConfigurationManager.ConnectionStrings["SignalRdbCon"].ConnectionString;
            _selectQuery = @"SELECT [iChatMessageID],[iUserID],[strMessage],[bIsDeleted] FROM [dbo].[tblChatMessages]";
            _newMessageNotifier = new NewMessageNotifier(_connString, _selectQuery);
            _newMessageNotifier.NewMessage += NewMessageRecieved;
        }

        internal void NewMessageRecieved(object sender, SqlNotificationEventArgs e)
        {
            var newMessages = FetchMessagesFromDb();
            _dispatcher(newMessages.Select(lm => lm.strMessage));
            using (var db = new Entities())
            {
                //Mark all dispatched messages as sent
                newMessages.ToList().ForEach(lm => { db.tblChatMessages.Attach(lm); lm.bIsDeleted = false; });
                db.SaveChanges();
            }
        }

        private static IEnumerable<tblChatMessages> FetchMessagesFromDb()
        {
            using (var db = new Entities())
            {
                return db.tblChatMessages.Where(lm => lm.bIsDeleted == false).ToList();
            }
        }

    }
}