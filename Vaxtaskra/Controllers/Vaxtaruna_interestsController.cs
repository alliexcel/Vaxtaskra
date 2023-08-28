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
    public class Vaxtaruna_interestsController : Controller
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();

        // GET: Vaxtaruna_interests
        public ActionResult Index()
        {
            var vaxtaruna_interests = db.Vaxtaruna_interests.Include(v => v.Vaxtaruna);
            return View(vaxtaruna_interests.ToList());
        }

        // GET: Vaxtaruna_interests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtaruna_interests vaxtaruna_interests = db.Vaxtaruna_interests.Find(id);
            if (vaxtaruna_interests == null)
            {
                return HttpNotFound();
            }
            return View(vaxtaruna_interests);
        }

        // GET: Vaxtaruna_interests/Create
        [HttpGet]
        public ActionResult Create(Vaxtaruna vaxtarunamodel)
        {

            Vaxtaruna_interests vi = new Vaxtaruna_interests();
            vi.VaxtarunaID = vaxtarunamodel.VaxtarunaID;
            vi.Vaxtaruna = vaxtarunamodel;
            vi.Date = System.DateTime.Now;
            vi.is_current = 1;

            Vaxtaruna_all va = new Vaxtaruna_all();
            va.VaxtarunaInterests = vi;

            return View(va);
        }

        // POST: Vaxtaruna_interests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vaxtaruna_all vaxtaruna_interestsmodel)
        { 

            Vaxtaruna_interests vi = new Vaxtaruna_interests();
            vi.VaxtarunaID = vaxtaruna_interestsmodel.VaxtarunaInterests.VaxtarunaID;
            
            vi.Date = System.DateTime.Now;
            vi.is_current = 1;
            vi.Spread = Convert.ToDecimal(vaxtaruna_interestsmodel.SpreadString.Replace(".", ","));

            if (ModelState.IsValid)
            {
                db.Vaxtaruna_interests.Add(vi);
                db.SaveChanges();
                
            }

            HomeController h = new HomeController();
            h.SaveCurrentInt();
          
            return RedirectToAction("Index","Home",null);
        }

        // GET: Vaxtaruna_interests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtaruna_interests vaxtaruna_interests = db.Vaxtaruna_interests.Find(id);
            if (vaxtaruna_interests == null)
            {
                return HttpNotFound();
            }
            ViewBag.VaxtarunaID = new SelectList(db.Vaxtarunas, "VaxtarunaID", "Heiti", vaxtaruna_interests.VaxtarunaID);
            return View(vaxtaruna_interests);
        }

        // POST: Vaxtaruna_interests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Vaxtaruna_InterestsID,Spread,Date,VaxtarunaID")] Vaxtaruna_interests vaxtaruna_interests)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaxtaruna_interests).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VaxtarunaID = new SelectList(db.Vaxtarunas, "VaxtarunaID", "Heiti", vaxtaruna_interests.VaxtarunaID);
            return View(vaxtaruna_interests);
        }

        // GET: Vaxtaruna_interests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtaruna_interests vaxtaruna_interests = db.Vaxtaruna_interests.Find(id);
            if (vaxtaruna_interests == null)
            {
                return HttpNotFound();
            }
            return View(vaxtaruna_interests);
        }

        // POST: Vaxtaruna_interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaxtaruna_interests vaxtaruna_interests = db.Vaxtaruna_interests.Find(id);
            db.Vaxtaruna_interests.Remove(vaxtaruna_interests);
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
