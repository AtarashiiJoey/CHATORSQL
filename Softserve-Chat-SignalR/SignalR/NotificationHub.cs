using Microsoft.AspNet.SignalR;
using Softserve_Chat_SignalR.SqlServerNotifier;
using System;

namespace Softserve_Chat_SignalR.Hubs
{
    public class ProductHub : Hub
    {
        internal NotifierEntity NotifierEntity { get; private set; }

        public void DispatchToClient()
        {
            Clients.All.broadcastMessage("Refresh");
        }

        public void Initialize(string value)
        {
            NotifierEntity = NotifierEntity.FromJson(value);
            if (NotifierEntity == null)
                return;
            Action<string> dispatcher = (t) => { DispatchToClient(); };
            PushSqlDependency.Instance(NotifierEntity, dispatcher);
        }
    }
}