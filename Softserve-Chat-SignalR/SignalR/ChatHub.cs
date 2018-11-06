using System;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Softserve_Chat_SignalR.SignalR
{
    [HubName("chat")] 
    public class ChatHub : Hub
    {
        #region Chat Controls
        [HubMethodName("send")]
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }

        //[HubMethodName("log_out")]
        //public void Send(string name, string message) => Clients.All.addNewMessageToPage(name, message);

        #endregion

        #region Chat Helpers
// so these are essentially event links...
        [HubMethodName("getServerDateTime")]
        public DateTime GetServerDateTime() => DateTime.Now;
        #endregion

    }
}

