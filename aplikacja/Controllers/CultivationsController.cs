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
    public class CultivationsController : Controller
    {

        private farmEntities db = new farmEntities();

        // GET: Cultivations
        public ActionResult Index()
        {
            var cultivations = db.Cultivations.Include(c => c.Field);
            return View(cultivations.ToList());
        }

        // GET: Cultivations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cultivation cultivation = db.Cultivations.Find(id);
            if (cultivation == null)
            {
                return HttpNotFound();
            }
            return View(cultivation);
        }

        // GET: Cultivations/Create
        public ActionResult Create()
        {
            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type");
            return View();
        }

        // POST: Cultivations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Field,State,What")] Cultivation cultivation)
        {
            if (ModelState.IsValid)
            {
                db.Cultivations.Add(cultivation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type", cultivation.Id_Field);
            return View(cultivation);
        }

        // GET: Cultivations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cultivation cultivation = db.Cultivations.Find(id);
            if (cultivation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type", cultivation.Id_Field);
            return View(cultivation);
        }

        // POST: Cultivations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Field,State,What")] Cultivation cultivation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cultivation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Field = new SelectList(db.Fields, "Id", "Type", cultivation.Id_Field);
            return View(cultivation);
        }

        // GET: Cultivations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cultivation cultivation = db.Cultivations.Find(id);
            if (cultivation == null)
            {
                return HttpNotFound();
            }
            return View(cultivation);
        }

        // POST: Cultivations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cultivation cultivation = db.Cultivations.Find(id);
            db.Cultivations.Remove(cultivation);
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
