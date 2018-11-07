using System.Web.Mvc;
using Softserve_Chat_SignalR.Models;
using Softserve_Chat_SignalR.SignalR;
using Softserve_Chat_SignalR.SqlServerNotifier;

namespace Softserve_Chat_SignalR.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ViewBag.iChatLogID = new SelectList(db.tblChatLogs, "iChatLogID", "strFirstName");
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "iChatMessageID,iUserID,iChatLogID,strMessage,bIsDeleted")] tblChatMessages tblChatMessages)
        {
            if (ModelState.IsValid)
            {
                db.tblChatMessages.Add(tblChatMessages);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.iChatLogID = new SelectList(db.tblChatLogs, "iChatLogID", "strFirstName", tblChatMessages.iChatLogID);
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName", tblChatMessages.iUserID);
            return View(tblChatMessages);
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
