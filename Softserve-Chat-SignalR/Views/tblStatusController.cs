using System;
using Softserve_Chat_SignalR.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Softserve_Chat_SignalR.Views
{
    public class tblStatusController : Controller
    {
        private Entities db = new Entities();

        // GET: tblStatus
        public ActionResult Index()
        {
            return View(db.tblStatuses.ToList());
        }

        // GET: tblStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatuses.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // GET: tblStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iStatusID,dtAdded,iAddedBy,dtEdited,iEditedBy,strStatus,bIsDeleted")] tblStatus tblStatus)
        {
            if (ModelState.IsValid)
            {
                // standard SU creation properties
                tblStatus.iAddedBy = 0;
                tblStatus.dtAdded = DateTime.Now;
                tblStatus.iEditedBy = 0;
                tblStatus.dtEdited = DateTime.Now;
                tblStatus.bIsDeleted = false;

                db.tblStatuses.Add(tblStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblStatus);
        }

        // GET: tblStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatuses.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // POST: tblStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iStatusID,dtAdded,iAddedBy,dtEdited,iEditedBy,strStatus,bIsDeleted")] tblStatus tblStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblStatus);
        }

        // GET: tblStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStatus tblStatus = db.tblStatuses.Find(id);
            if (tblStatus == null)
            {
                return HttpNotFound();
            }
            return View(tblStatus);
        }

        // POST: tblStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStatus tblStatus = db.tblStatuses.Find(id);
            db.tblStatuses.Remove(tblStatus);
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
