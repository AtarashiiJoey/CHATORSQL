using System.Data.SqlClient;

namespace Softserve_Chat_SignalR.SqlServerNotifier
{
    public delegate void SqlNotificationEventHandler(object sender, SqlNotificationEventArgs e);
}