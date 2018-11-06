using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Softserve_Chat_SignalR.SignalR
{
    [HubName("dbCall")]
    public class DataBaseHub : Hub
    {
    }
    
    public class MessageSender : Hub
    {
        public void DispatchToClient(IEnumerable<string> messages)
        {
            foreach (var message in messages)
                Clients.All.broadcastMessage(message);
        }
        public MessageSender()
        {
            Action<IEnumerable<string>> dispatcher = (messages) => { DispatchToClient(messages); };
            //We create a singleton instance of PushMessaging
            PushMessaging.GetInstance(dispatcher);
        }

    }
}