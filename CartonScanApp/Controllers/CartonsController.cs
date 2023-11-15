using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CartonScanApp.Models;

namespace CartonScanApp.Controllers {
    public class CartonsController : Controller {
        private CartonScanDbContext db = new CartonScanDbContext();

        // GET: Cartons
        public ActionResult Index() {
            return View(db.Cartons.ToList());
        }

        // GET: Cartons/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carton carton = db.Cartons.Find(id);
            if (carton == null) {
                return HttpNotFound();
            }
            return View(carton);
        }

        // GET: Cartons/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Cartons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Location")] Carton carton) {
            if (ModelState.IsValid) {
                carton.Created = DateTime.Now;
                carton.Updated = DateTime.Now;
                db.Cartons.Add(carton);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carton);
        }

        // GET: Cartons/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carton carton = db.Cartons.Find(id);
            if (carton == null) {
                return HttpNotFound();
            }
            return View(carton);
        }

        // POST: Cartons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Location")] Carton carton) {
            if (ModelState.IsValid) {
                Carton existingCarton = db.Cartons.Find(carton.ID);
                if (existingCarton != null) {
                    existingCarton.ID = carton.ID;
                    existingCarton.Name = carton.Name;
                    existingCarton.Description = carton.Description;
                    existingCarton.Location = carton.Location;
                    existingCarton.Updated = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(carton);
        }

        // GET: Cartons/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carton carton = db.Cartons.Find(id);
            if (carton == null) {
                return HttpNotFound();
            }
            return View(carton);
        }

        // POST: Cartons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Carton carton = db.Cartons.Find(id);
            db.Cartons.Remove(carton);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
