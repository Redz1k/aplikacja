using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aplikacja.Models;

namespace aplikacja.Controllers
{
    [Authorize]
    [RequireHttps]
    public class Field_HistoryController : Controller
    {
        private farmEntities db = new farmEntities();

        // GET: Field_History
        public ActionResult Index()
        {
            var field_History = db.Field_History.Include(f => f.Field);
            return View(field_History.ToList());
        }

        // GET: Field_History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field_History field_History = db.Field_History.Find(id);
            if (field_History == null)
            {
                return HttpNotFound();
            }
            return View(field_History);
        }

        // GET: Field_History/Create
        public ActionResult Create()
        {
            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type");
            return View();
        }

        // POST: Field_History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Field,Date,Type,Description")] Field_History field_History)
        {
            if (ModelState.IsValid)
            {
                db.Field_History.Add(field_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type", field_History.Id_Field);
            return View(field_History);
        }

        // GET: Field_History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field_History field_History = db.Field_History.Find(id);
            if (field_History == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type", field_History.Id_Field);
            return View(field_History);
        }

        // POST: Field_History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Field,Date,Type,Description")] Field_History field_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(field_History).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type", field_History.Id_Field);
            return View(field_History);
        }

        // GET: Field_History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field_History field_History = db.Field_History.Find(id);
            if (field_History == null)
            {
                return HttpNotFound();
            }
            return View(field_History);
        }

        // POST: Field_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Field_History field_History = db.Field_History.Find(id);
            db.Field_History.Remove(field_History);
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
