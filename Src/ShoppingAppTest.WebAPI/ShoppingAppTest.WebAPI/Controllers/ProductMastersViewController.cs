using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingAppTest.WebAPI.Models;

namespace ShoppingAppTest.WebAPI.Controllers
{
    public class ProductMastersViewController : Controller
    {
        private ShoppingAppTestEntities db = new ShoppingAppTestEntities();

        // GET: ProductMastersView
        public ActionResult Index()
        {
            return View(db.ProductMasters.ToList());
        }
        // GET: ProductMastersView/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // GET: ProductMastersView/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductMastersView/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductTitle,ProductDescription,ProductDescription2,Price,Discount,Images,Quantity")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.ProductMasters.Add(productMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productMaster);
        }

        // GET: ProductMastersView/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // POST: ProductMastersView/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductTitle,ProductDescription,ProductDescription2,Price,Discount,Images,Quantity")] ProductMaster productMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productMaster);
        }

        // GET: ProductMastersView/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductMaster productMaster = db.ProductMasters.Find(id);
            if (productMaster == null)
            {
                return HttpNotFound();
            }
            return View(productMaster);
        }

        // POST: ProductMastersView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ProductMaster productMaster = db.ProductMasters.Find(id);
            db.ProductMasters.Remove(productMaster);
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
