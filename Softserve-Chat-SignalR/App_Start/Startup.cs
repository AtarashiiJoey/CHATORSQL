using Microsoft.Owin;
using Owin;
using Softserve_Chat_SignalR;

[assembly: OwinStartup(typeof(Startup))]
namespace Softserve_Chat_SignalR
{
    public class Startup
    {
        public void Configuration(IAppBuilder app) => app.MapSignalR();
    }
}