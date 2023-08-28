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
    public class ProductInterestsController : Controller
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();

        // GET: ProductInterests
        public ActionResult Index()
        {
            var productInterests = db.ProductInterests.Include(p => p.Product_indexation).Include(p => p.Vaxtaruna_interests);
            return View(productInterests.ToList());
        }

        // GET: ProductInterests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInterest productInterest = db.ProductInterests.Find(id);
            if (productInterest == null)
            {
                return HttpNotFound();
            }
            return View(productInterest);
        }

        // GET: ProductInterests/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Product_indexationID = (from i in db.Product_indexation where i.ProductIndexationID == id select i).FirstOrDefault();
            List<Vaxtaruna_interests> vi = (from i in db.Vaxtaruna_interests where i.is_current == 1 select i).ToList();
            List<Vaxtaruna_interest_extra> vielist = new List<Vaxtaruna_interest_extra>();
            foreach (var i in vi)
            {
                Vaxtaruna_interest_extra vie = new Vaxtaruna_interest_extra();
                vie.vaxtaruna_int = i;
                vie.Runuheiti = i.Vaxtaruna.Heiti;
                vie.Vaxtaruna_interestID = i.Vaxtaruna_InterestsID;
                vielist.Add(vie);
            }

            ViewBag.Vaxtarunulist = new SelectList(vielist, "Vaxtaruna_interestID", "RunuHeiti");


            return View();
        }

        // POST: ProductInterests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductInterestsID,Product_indexationID,VaxtaRunaIntID")] ProductInterest productInterest)
        {
            if (ModelState.IsValid)
            {
                db.ProductInterests.Add(productInterest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_indexationID = new SelectList(db.Product_indexation, "ProductIndexationID", "ProductIndexationID", productInterest.Product_indexationID);
            ViewBag.VaxtaRunaIntID = new SelectList(db.Vaxtaruna_interests, "Vaxtaruna_InterestsID", "Vaxtaruna_InterestsID", productInterest.VaxtaRunaIntID);
            return View(productInterest);
        }

        // GET: ProductInterests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInterest productInterest = db.ProductInterests.Find(id);
            if (productInterest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_indexationID = new SelectList(db.Product_indexation, "ProductIndexationID", "ProductIndexationID", productInterest.Product_indexationID);
            ViewBag.VaxtaRunaIntID = new SelectList(db.Vaxtaruna_interests, "Vaxtaruna_InterestsID", "Vaxtaruna_InterestsID", productInterest.VaxtaRunaIntID);
            return View(productInterest);
        }

        // POST: ProductInterests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductInterestsID,Product_indexationID,VaxtaRunaIntID")] ProductInterest productInterest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productInterest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_indexationID = new SelectList(db.Product_indexation, "ProductIndexationID", "ProductIndexationID", productInterest.Product_indexationID);
            ViewBag.VaxtaRunaIntID = new SelectList(db.Vaxtaruna_interests, "Vaxtaruna_InterestsID", "Vaxtaruna_InterestsID", productInterest.VaxtaRunaIntID);
            return View(productInterest);
        }

        // GET: ProductInterests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInterest productInterest = db.ProductInterests.Find(id);
            if (productInterest == null)
            {
                return HttpNotFound();
            }
            return View(productInterest);
        }

        // POST: ProductInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductInterest productInterest = db.ProductInterests.Find(id);
            db.ProductInterests.Remove(productInterest);
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
