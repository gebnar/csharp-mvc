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
    public class ItemsController : Controller {
        private CartonScanDbContext db = new CartonScanDbContext();

        // GET: Items
        public ActionResult Index() {
            var itemsWithCartons = db.Items.Include(i => i.Carton).ToList();
            return View(itemsWithCartons);
        }


        // GET: Items/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null) {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create() {
            ViewBag.CartonList = db.Cartons.Select(c => new SelectListItem {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Barcode,CartonId")] Item item) {
            if (ModelState.IsValid) {
                item.Created = DateTime.Now;
                item.Updated = DateTime.Now;
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CartonList = db.Cartons.Select(c => new SelectListItem {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList();
            return View(item);
        }

        //// GET: Items/Edit/5
        //public ActionResult Edit(int? id) {
        //    if (id == null) {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = db.Items.Find(id);
        //    if (item == null) {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CartonList = db.Cartons.Select(c => new SelectListItem {
        //        Value = c.ID.ToString(),
        //        Text = c.Name
        //    }).ToList();
        //    return View(item);
        //}

        //// POST: Items/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Barcode,CartonId")] Item item) {
        //    if (ModelState.IsValid) {
        //        Item existingItem = db.Items.Find(item.ID);
        //        if (existingItem != null) {
        //            existingItem.Barcode = item.Barcode;
        //            existingItem.CartonId = item.CartonId;
        //            existingItem.Updated = DateTime.Now;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }

        //    // Repopulate CartonList if returning to the view
        //    ViewBag.CartonList = db.Cartons.Select(c => new SelectListItem {
        //        Value = c.ID.ToString(),
        //        Text = c.Name
        //    }).ToList();
        //    return View(item);
        //}

        // GET: Items/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null) {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
