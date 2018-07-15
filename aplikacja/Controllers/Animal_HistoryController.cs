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
    [RequireHttps]
    [Authorize]
    public class Animal_HistoryController : Controller
    {
        private farmEntities db = new farmEntities();

        // GET: Animal_History
        public ActionResult Index()
        {
            var animal_History = db.Animal_History.Include(a => a.Animal);
            return View(animal_History.ToList());
        }

        // GET: Animal_History/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_History animal_History = db.Animal_History.Find(id);
            if (animal_History == null)
            {
                return HttpNotFound();
            }
            return View(animal_History);
        }

        // GET: Animal_History/Create
        public ActionResult Create()
        {
            ViewBag.Id_Animal = new SelectList(db.Animals, "Id", "Nr_Animal");
            return View();
        }

        // POST: Animal_History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Animal,Date,Type,Description")] Animal_History animal_History)
        {
            if (ModelState.IsValid)
            {
                db.Animal_History.Add(animal_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Animal = new SelectList(db.Animals, "Id", "Nr_Animal", animal_History.Id_Animal);
            return View(animal_History);
        }

        // GET: Animal_History/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_History animal_History = db.Animal_History.Find(id);
            if (animal_History == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Animal = new SelectList(db.Animals, "Id", "Nr_Animal", animal_History.Id_Animal);
            return View(animal_History);
        }

        // POST: Animal_History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Animal,Date,Type,Description")] Animal_History animal_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal_History).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Animal = new SelectList(db.Animals, "Id", "Nr_Animal", animal_History.Id_Animal);
            return View(animal_History);
        }

        // GET: Animal_History/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_History animal_History = db.Animal_History.Find(id);
            if (animal_History == null)
            {
                return HttpNotFound();
            }
            return View(animal_History);
        }

        // POST: Animal_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal_History animal_History = db.Animal_History.Find(id);
            db.Animal_History.Remove(animal_History);
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
