using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Softserve_Chat_SignalR.Models;

namespace Softserve_Chat_SignalR.Controllers
{
    public class tblChatLogsController : Controller
    {
        private Entities db = new Entities();

        // GET: tblChatLogs
        public ActionResult Index()
        {
            var tblChatLogs = db.tblChatLogs.Include(t => t.tblReasonForChat).Include(t => t.tblStatus).Include(t => t.tblUser);
            return View(tblChatLogs.ToList());
        }

        // GET: tblChatLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChatLog tblChatLog = db.tblChatLogs.Find(id);
            if (tblChatLog == null)
            {
                return HttpNotFound();
            }
            return View(tblChatLog);
        }

        // GET: tblChatLogs/Create
        public ActionResult Create()
        {
            ViewBag.iReasonForChatID = new SelectList(db.tblReasonForChats, "iReasonForChatID", "strReason");
            ViewBag.iStatusID = new SelectList(db.tblStatuses, "iStatusID", "strStatus");
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName");
            return View();
        }

        // POST: tblChatLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iChatLogID,dtAdded,iAddedBy,dtEdited,iEditedBy,iUserID,strFirstName,strSurname,strEmailAddress,strContactNumber,dtEndOfChat,strRef,iReasonForChatID,iStatusID,bIsDeleted")] tblChatLog tblChatLog)
        {
            if (ModelState.IsValid)
            {
                // standard SU creation properties
                tblChatLog.iAddedBy = 0;
                tblChatLog.dtAdded = DateTime.Now;
                tblChatLog.iEditedBy = 0;
                tblChatLog.dtEdited = DateTime.Now;
                tblChatLog.bIsDeleted = false;
                tblChatLog.dtEndOfChat = DateTime.Now;
                tblChatLog.strRef = "to be added";

                db.tblChatLogs.Add(tblChatLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iReasonForChatID = new SelectList(db.tblReasonForChats, "iReasonForChatID", "strReason", tblChatLog.iReasonForChatID);
            ViewBag.iStatusID = new SelectList(db.tblStatuses, "iStatusID", "strStatus", tblChatLog.iStatusID);
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName", tblChatLog.iUserID);
            return View(tblChatLog);
        }

        // GET: tblChatLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChatLog tblChatLog = db.tblChatLogs.Find(id);
            if (tblChatLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.iReasonForChatID = new SelectList(db.tblReasonForChats, "iReasonForChatID", "strReason", tblChatLog.iReasonForChatID);
            ViewBag.iStatusID = new SelectList(db.tblStatuses, "iStatusID", "strStatus", tblChatLog.iStatusID);
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName", tblChatLog.iUserID);
            return View(tblChatLog);
        }

        // POST: tblChatLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iChatLogID,dtAdded,iAddedBy,dtEdited,iEditedBy,iUserID,strFirstName,strSurname,strEmailAddress,strContactNumber,dtEndOfChat,strRef,iReasonForChatID,iStatusID,bIsDeleted")] tblChatLog tblChatLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChatLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iReasonForChatID = new SelectList(db.tblReasonForChats, "iReasonForChatID", "strReason", tblChatLog.iReasonForChatID);
            ViewBag.iStatusID = new SelectList(db.tblStatuses, "iStatusID", "strStatus", tblChatLog.iStatusID);
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName", tblChatLog.iUserID);
            return View(tblChatLog);
        }

        // GET: tblChatLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChatLog tblChatLog = db.tblChatLogs.Find(id);
            if (tblChatLog == null)
            {
                return HttpNotFound();
            }
            return View(tblChatLog);
        }

        // POST: tblChatLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblChatLog tblChatLog = db.tblChatLogs.Find(id);
            db.tblChatLogs.Remove(tblChatLog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
