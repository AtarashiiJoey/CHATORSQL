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
    public class tblChatMessagesController : Controller
    {
        private Entities db = new Entities();

        // GET: tblChatMessages
        public ActionResult Index()
        {
            var tblChatMessages = db.tblChatMessages.Include(t => t.tblChatLog).Include(t => t.tblUser);
            return View(tblChatMessages.ToList());
        }

        // GET: tblChatMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChatMessages tblChatMessages = db.tblChatMessages.Find(id);
            if (tblChatMessages == null)
            {
                return HttpNotFound();
            }
            return View(tblChatMessages);
        }

        // GET: tblChatMessages/Create
        public ActionResult Create()
        {
            ViewBag.iChatLogID = new SelectList(db.tblChatLogs, "iChatLogID", "strFirstName");
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName");
            return View();
        }

        // POST: tblChatMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iChatMessageID,iUserID,iChatLogID,strMessage,bIsDeleted")] tblChatMessages tblChatMessages)
        {
            if (ModelState.IsValid)
            {
                db.tblChatMessages.Add(tblChatMessages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.iChatLogID = new SelectList(db.tblChatLogs, "iChatLogID", "strFirstName", tblChatMessages.iChatLogID);
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName", tblChatMessages.iUserID);
            return View(tblChatMessages);
        }

        // GET: tblChatMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChatMessages tblChatMessages = db.tblChatMessages.Find(id);
            if (tblChatMessages == null)
            {
                return HttpNotFound();
            }
            ViewBag.iChatLogID = new SelectList(db.tblChatLogs, "iChatLogID", "strFirstName", tblChatMessages.iChatLogID);
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName", tblChatMessages.iUserID);
            return View(tblChatMessages);
        }

        // POST: tblChatMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iChatMessageID,iUserID,iChatLogID,strMessage,bIsDeleted")] tblChatMessages tblChatMessages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblChatMessages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.iChatLogID = new SelectList(db.tblChatLogs, "iChatLogID", "strFirstName", tblChatMessages.iChatLogID);
            ViewBag.iUserID = new SelectList(db.tblUsers, "iUserID", "strFirstName", tblChatMessages.iUserID);
            return View(tblChatMessages);
        }

        // GET: tblChatMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblChatMessages tblChatMessages = db.tblChatMessages.Find(id);
            if (tblChatMessages == null)
            {
                return HttpNotFound();
            }
            return View(tblChatMessages);
        }

        // POST: tblChatMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblChatMessages tblChatMessages = db.tblChatMessages.Find(id);
            db.tblChatMessages.Remove(tblChatMessages);
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
