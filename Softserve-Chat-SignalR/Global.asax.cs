using System.Configuration;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Softserve_Chat_SignalR
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //connection string of DB
        readonly string connString = @"Server=DEV-2018-OCT\SQLEXPRESS;Database=Softserve-Chat-DB;Integrated Security=SSPI";
        //readonly string connString = ConfigurationManager.ConnectionStrings["SignalRdbCon"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Start SqlDependency with application initialization
            SqlDependency.Start(connString);
        }
        protected void Application_End()
        {
            //Free the dependency
            SqlDependency.Stop(connString);
        }
    }
}
