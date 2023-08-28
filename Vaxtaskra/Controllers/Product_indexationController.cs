using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vaxtaskra.Models;

namespace Vaxtaskra.Controllers
{
    public class Product_indexationController : Controller
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();

        // GET: Product_indexation
        public ActionResult Index()
        {
            var product_indexation = db.Product_indexation.Include(p => p.Product);
            return View(product_indexation.ToList());
        }

        // GET: Product_indexation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_indexation product_indexation = db.Product_indexation.Find(id);
            if (product_indexation == null)
            {
                return HttpNotFound();
            }
            return View(product_indexation);
        }

        // GET: Product_indexation/Create
        public ActionResult Create(int Id)
        {
            List<Indexed> indexlist = new List<Indexed>();
            Indexed index1 = new Indexed();
            Indexed index2 = new Indexed();
            index1.IndexedType = "Verðtryggt";
            index2.IndexedType = "Óverðtryggt";
            indexlist.Add(index1);
            indexlist.Add(index2);
            
            var product = (from i in db.Products where i.ProductID == Id select i).FirstOrDefault();
            ViewBag.Product = product;
            ViewBag.Indexed = indexlist;

          

            ViewBag.prodlist = (from p in db.Product_indexation where p.ProductID == Id select p).ToList();
            
            return View();
        }

        // POST: Product_indexation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product_indexation_extra prodindvext)
        {
            
            
            if(prodindvext.verðtryggt == "Verðtryggt") { prodindvext.product_indexation.is_Indexed = true; }
            if (prodindvext.verðtryggt == "Óverðtryggt") { prodindvext.product_indexation.is_Indexed = false; }
            if (ModelState.IsValid)
            {
                db.Product_indexation.Add(prodindvext.product_indexation);
                db.SaveChanges();
                return RedirectToAction("Create",new {Id = prodindvext.product_indexation.ProductID });
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", prodindvext.product_indexation.ProductID);
            return View(prodindvext);
        }

        // GET: Product_indexation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_indexation product_indexation = db.Product_indexation.Find(id);
            if (product_indexation == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", product_indexation.ProductID);
            return View(product_indexation);
        }

        // POST: Product_indexation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductIndexationID,ProductID,is_Indexed,MAX_number_payments,MIN_number_payments")] Product_indexation product_indexation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_indexation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", product_indexation.ProductID);
            return View(product_indexation);
        }

        // GET: Product_indexation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_indexation product_indexation = db.Product_indexation.Find(id);
            if (product_indexation == null)
            {
                return HttpNotFound();
            }
            return View(product_indexation);
        }

        // POST: Product_indexation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_indexation product_indexation = db.Product_indexation.Find(id);
            db.Product_indexation.Remove(product_indexation);
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
