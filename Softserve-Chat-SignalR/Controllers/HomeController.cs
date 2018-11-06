using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softserve_Chat_SignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Chat()
        {
            ViewBag.Title = "Chat Page";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Title = "Admin Page";

            return View();
        }
    }
}
