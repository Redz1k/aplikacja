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
    public class FarmersController : Controller
    {
        private farmEntities db = new farmEntities();

        // GET: Farmers
        public ActionResult Index()
        {
            var farmers = db.Farmers.Include(f => f.AspNetUser);
            return View(farmers.ToList());
        }

        // GET: Farmers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // GET: Farmers/Create
        public ActionResult Create()
        {
            ViewBag.Id_User = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Farmers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_User,FirstName,LastName,Farm_Nr")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                db.Farmers.Add(farmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_User = new SelectList(db.AspNetUsers, "Id", "Email", farmer.Id_User);
            return View(farmer);
        }

        // GET: Farmers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_User = new SelectList(db.AspNetUsers, "Id", "Email", farmer.Id_User);
            return View(farmer);
        }

        // POST: Farmers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_User,FirstName,LastName,Farm_Nr")] Farmer farmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(farmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_User = new SelectList(db.AspNetUsers, "Id", "Email", farmer.Id_User);
            return View(farmer);
        }

        // GET: Farmers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Farmer farmer = db.Farmers.Find(id);
            if (farmer == null)
            {
                return HttpNotFound();
            }
            return View(farmer);
        }

        // POST: Farmers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Farmer farmer = db.Farmers.Find(id);
            db.Farmers.Remove(farmer);
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
