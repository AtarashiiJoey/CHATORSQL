using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Softserve_Chat_SignalR.Models;

namespace Softserve_Chat_SignalR.Controllers
{
    public class tblReasonForChatsController : Controller
    {
        private Entities db = new Entities();

        // GET: tblReasonForChats
        public ActionResult Index()
        {
            return View(db.tblReasonForChats.ToList());
        }

        // GET: tblReasonForChats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReasonForChat tblReasonForChat = db.tblReasonForChats.Find(id);
            if (tblReasonForChat == null)
            {
                return HttpNotFound();
            }
            return View(tblReasonForChat);
        }

        // GET: tblReasonForChats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblReasonForChats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iReasonForChatID,dtAdded,iAddedBy,dtEdited,iEditedBy,strReason,bIsDeleted")] tblReasonForChat tblReasonForChat)
        {
            if (ModelState.IsValid)
            {
                // standard SU creation properties
                tblReasonForChat.iAddedBy = 0;
                tblReasonForChat.dtAdded = DateTime.Now;
                tblReasonForChat.iEditedBy = 0;
                tblReasonForChat.dtEdited = DateTime.Now;
                tblReasonForChat.bIsDeleted = false;

                db.tblReasonForChats.Add(tblReasonForChat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblReasonForChat);
        }

        // GET: tblReasonForChats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReasonForChat tblReasonForChat = db.tblReasonForChats.Find(id);
            if (tblReasonForChat == null)
            {
                return HttpNotFound();
            }
            return View(tblReasonForChat);
        }

        // POST: tblReasonForChats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iReasonForChatID,dtAdded,iAddedBy,dtEdited,iEditedBy,strReason,bIsDeleted")] tblReasonForChat tblReasonForChat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblReasonForChat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblReasonForChat);
        }

        // GET: tblReasonForChats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReasonForChat tblReasonForChat = db.tblReasonForChats.Find(id);
            if (tblReasonForChat == null)
            {
                return HttpNotFound();
            }
            return View(tblReasonForChat);
        }

        // POST: tblReasonForChats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblReasonForChat tblReasonForChat = db.tblReasonForChats.Find(id);
            db.tblReasonForChats.Remove(tblReasonForChat);
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
