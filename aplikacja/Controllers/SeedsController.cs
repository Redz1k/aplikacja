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
    public class SeedsController : Controller
    {
        private farmEntities db = new farmEntities();

        // GET: Seeds
        public ActionResult Index()
        {
            return View(db.Seeds.ToList());
        }

        // GET: Seeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seed seed = db.Seeds.Find(id);
            if (seed == null)
            {
                return HttpNotFound();
            }
            return View(seed);
        }

        // GET: Seeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Seed seed)
        {
            if (ModelState.IsValid)
            {
                db.Seeds.Add(seed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seed);
        }

        // GET: Seeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seed seed = db.Seeds.Find(id);
            if (seed == null)
            {
                return HttpNotFound();
            }
            return View(seed);
        }

        // POST: Seeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Seed seed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seed);
        }

        // GET: Seeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seed seed = db.Seeds.Find(id);
            if (seed == null)
            {
                return HttpNotFound();
            }
            return View(seed);
        }

        // POST: Seeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seed seed = db.Seeds.Find(id);
            db.Seeds.Remove(seed);
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
