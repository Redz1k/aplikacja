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
    public class FieldsController : Controller
    {
        private farmEntities db = new farmEntities();

        // GET: Fields
        public ActionResult Index()
        {
            var fields = db.Fields.Include(f => f.Farmer);
            return View(fields.ToList());
        }

        // GET: Fields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        // GET: Fields/Create
        public ActionResult Create()
        {
            ViewBag.Id_Farmer = new SelectList(db.Farmers, "Id", "Id_User");
            return View();
        }

        // POST: Fields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,Id_Farmer")] Field field)
        {
            if (ModelState.IsValid)
            {
                db.Fields.Add(field);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Farmer = new SelectList(db.Farmers, "Id", "Id_User", field.Id_Farmer);
            return View(field);
        }

        // GET: Fields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Farmer = new SelectList(db.Farmers, "Id", "Id_User", field.Id_Farmer);
            return View(field);
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,Id_Farmer")] Field field)
        {
            if (ModelState.IsValid)
            {
                db.Entry(field).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Farmer = new SelectList(db.Farmers, "Id", "Id_User", field.Id_Farmer);
            return View(field);
        }

        // GET: Fields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Field field = db.Fields.Find(id);
            if (field == null)
            {
                return HttpNotFound();
            }
            return View(field);
        }

        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Field field = db.Fields.Find(id);
            db.Fields.Remove(field);
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
