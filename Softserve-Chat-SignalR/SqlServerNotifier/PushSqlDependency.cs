using System;
using System.Data.SqlClient;

namespace Softserve_Chat_SignalR.SqlServerNotifier
{
    public class PushSqlDependency
    {
        static PushSqlDependency instance = null;
        readonly SqlDependencyRegister sqlDependencyNotifier;
        readonly Action<string> dispatcher;

        public static PushSqlDependency Instance(NotifierEntity notifierEntity, Action<string> dispatcher)
        {
            return instance ?? (instance = new PushSqlDependency(notifierEntity, dispatcher));
        }

        private PushSqlDependency(NotifierEntity notifierEntity, Action<string> dispatcher)
        {
            this.dispatcher = dispatcher;
            sqlDependencyNotifier = new SqlDependencyRegister(notifierEntity);
            sqlDependencyNotifier.SqlNotification += OnSqlDependencyNotifierResultChanged;
        }

        internal void OnSqlDependencyNotifierResultChanged(object sender, SqlNotificationEventArgs e)
        {
            dispatcher("Refresh");
        }
    }
}