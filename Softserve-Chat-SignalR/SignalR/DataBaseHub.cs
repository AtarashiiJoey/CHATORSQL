using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;

namespace Softserve_Chat_SignalR.SignalR
{
    public class MessageSender : Hub
    {
        public void DispatchToClient(IEnumerable<string> messages)
        {
            Clients.All.ClearMessage();
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