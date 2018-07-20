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
    public class Animal_BreedController : Controller
    {
        private farmEntities db = new farmEntities();

        // GET: Animal_Breed
        public ActionResult Index()
        {
            return View(db.Animal_Breed.ToList());
        }

        // GET: Animal_Breed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_Breed animal_Breed = db.Animal_Breed.Find(id);
            if (animal_Breed == null)
            {
                return HttpNotFound();
            }
            return View(animal_Breed);
        }

        // GET: Animal_Breed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal_Breed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ShortName,FullName")] Animal_Breed animal_Breed)
        {
            if (ModelState.IsValid)
            {
                db.Animal_Breed.Add(animal_Breed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animal_Breed);
        }

        // GET: Animal_Breed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_Breed animal_Breed = db.Animal_Breed.Find(id);
            if (animal_Breed == null)
            {
                return HttpNotFound();
            }
            return View(animal_Breed);
        }

        // POST: Animal_Breed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ShortName,FullName")] Animal_Breed animal_Breed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal_Breed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animal_Breed);
        }

        // GET: Animal_Breed/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal_Breed animal_Breed = db.Animal_Breed.Find(id);
            if (animal_Breed == null)
            {
                return HttpNotFound();
            }
            return View(animal_Breed);
        }

        // POST: Animal_Breed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal_Breed animal_Breed = db.Animal_Breed.Find(id);
            db.Animal_Breed.Remove(animal_Breed);
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
