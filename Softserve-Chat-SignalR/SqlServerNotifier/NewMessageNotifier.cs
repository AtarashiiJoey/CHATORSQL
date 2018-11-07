using System.Data;
using System.Data.SqlClient;

namespace Softserve_Chat_SignalR.SqlServerNotifier
{
    #region Delegate
    public delegate void ResultChangedEventHandler(object sender, SqlNotificationEventArgs e);
    #endregion

    public class NewMessageNotifier
    {
        #region Fields
        public event ResultChangedEventHandler NewMessage;

        readonly string _connString;
        readonly string _selectQuery;
        #endregion

        internal NewMessageNotifier(string connString, string selectQuery)
        {
            _connString = connString;
            _selectQuery = selectQuery;
            RegisterForNotifications();
        }

        private void RegisterForNotifications()
        {

            using (var connection = new SqlConnection(_connString))
            {
                using (var command = new SqlCommand(_selectQuery, connection))
                {
                    command.Notification = null;
                    var dependency = new SqlDependency(command);
                    dependency.OnChange += dependency_OnChange;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    SqlDependency.Start(_connString);
                    var reader = command.ExecuteReader();
                }
            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            var dependency = (SqlDependency)sender;
            dependency.OnChange -= dependency_OnChange;
            NewMessage?.Invoke(sender, e);
            //subscribe again to notifier
            RegisterForNotifications();
        }
    }
}