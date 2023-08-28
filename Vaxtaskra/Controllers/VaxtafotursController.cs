using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Vaxtaskra.Models;

namespace Vaxtaskra.Controllers
{
    public class VaxtafotursController : Controller
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();

        // GET: Vaxtafoturs
        public ActionResult Index()
        {
            return View(db.Vaxtafoturs.ToList());
        }

        // GET: Vaxtafoturs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtafotur vaxtafotur = db.Vaxtafoturs.Find(id);
            if (vaxtafotur == null)
            {
                return HttpNotFound();
            }
            return View(vaxtafotur);
        }

        // GET: Vaxtafoturs/Create
        public ActionResult Create()
        {
         


            return View();
        }

        // POST: Vaxtafoturs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vaxtafotur_extra vaxtafoturobj)
        {
            
            vaxtafoturobj.vaxtafotur.is_active = true;
            

            if (ModelState.IsValid)
            {
                db.Vaxtafoturs.Add(vaxtafoturobj.vaxtafotur);
                db.SaveChanges();
                
            }

            Vaxtafotur_interests vi = new Vaxtafotur_interests();
            vi.Date = System.DateTime.Now;
            vi.Interest = Convert.ToDecimal(vaxtafoturobj.vextir.Replace(".",","));
            vi.Is_Current = 1;
            vi.VaxtafoturId = vaxtafoturobj.vaxtafotur.VaxtafoturID;

            if (ModelState.IsValid)
            {
                db.Vaxtafotur_interests.Add(vi);
                db.SaveChanges();
                
            }

            HomeController h = new HomeController();
            

            return RedirectToAction("index","Home",null);
        }

        // GET: Vaxtafoturs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtafotur_extra vaxtafotur = new Vaxtafotur_extra();
               vaxtafotur.vaxtafotur = db.Vaxtafoturs.Find(id);
            if (vaxtafotur == null)
            {
                return HttpNotFound();
            }

            vaxtafotur.vextir = (from i in db.Vaxtafotur_interests where i.VaxtafoturId == id && i.Is_Current == 1 select i).FirstOrDefault().Interest.ToString();
            return View(vaxtafotur);
        }

        // POST: Vaxtafoturs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vaxtafotur_extra vaxtafoturinn)
        {
            if (ModelState.IsValid)
            {
               
                List<Vaxtafotur_interests> current = (from i in db.Vaxtafotur_interests where i.VaxtafoturId == vaxtafoturinn.vaxtafotur.VaxtafoturID && i.Is_Current == 1 select i).ToList();
                foreach(var f in current)
                {
                    f.Interest = Convert.ToDecimal(vaxtafoturinn.vextir);
                    f.Is_Current = 1;
                    db.Entry(f).State = EntityState.Modified;
                    db.SaveChanges();
                }

                HomeController h = new HomeController();
                h.SaveCurrentInt();
                return RedirectToAction("Index","Home",null);
            }
            return View(vaxtafoturinn);
        }

        // GET: Vaxtafoturs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtafotur vaxtafotur = db.Vaxtafoturs.Find(id);
            if (vaxtafotur == null)
            {
                return HttpNotFound();
            }
            return View(vaxtafotur);
        }

        // POST: Vaxtafoturs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaxtafotur vaxtafotur = db.Vaxtafoturs.Find(id);
            db.Vaxtafoturs.Remove(vaxtafotur);
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
