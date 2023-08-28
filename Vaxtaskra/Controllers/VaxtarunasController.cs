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
    public class VaxtarunasController : Controller
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();

        // GET: Vaxtarunas
        public ActionResult Index()
        {
            var vaxtarunas = db.Vaxtarunas.Include(v => v.Vextir_greidast).Include(v => v.Vaxtafotur);
            return View(vaxtarunas.ToList());
        }

        // GET: Vaxtarunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtaruna vaxtaruna = db.Vaxtarunas.Find(id);
            if (vaxtaruna == null)
            {
                return HttpNotFound();
            }
            return View(vaxtaruna);
        }

        // GET: Vaxtarunas/Create
        public ActionResult Create()
        {
           
            ViewBag.Vextir = (from i in db.Vextir_greidast select i).ToList();

            ViewBag.VaxtafoturID = (from vf in db.Vaxtafoturs where vf.is_active == true select vf ).ToList();
            return View();
        }

        // POST: Vaxtarunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vaxtaruna_all vaxtarunaobj)
        {
            if (ModelState.IsValid)
            {
                db.Vaxtarunas.Add(vaxtarunaobj.Vaxtaruna);
                db.SaveChanges();
                
            }       
           
            return RedirectToAction("Create","Vaxtaruna_interests",vaxtarunaobj.Vaxtaruna);
        }

        // GET: Vaxtarunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtaruna vaxtaruna = db.Vaxtarunas.Find(id);
            if (vaxtaruna == null)
            {
                return HttpNotFound();
            }
            ViewBag.Vextir_greidastID = new SelectList(db.Vextir_greidast, "Vextir_greidastID", "Vextir_greiddir", vaxtaruna.Vextir_greidastID);
            ViewBag.VaxtafoturID = new SelectList(db.Vaxtafoturs, "VaxtafoturID", "Heiti", vaxtaruna.VaxtafoturID);
            return View(vaxtaruna);
        }

        // POST: Vaxtarunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VaxtarunaID,Heiti,Vextir_greidastID,Is_deposit,Is_fixed,Is_indexed,VaxtafoturID,Amount_from,Amount_to,Months_tied,is_Corp")] Vaxtaruna vaxtaruna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaxtaruna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Vextir_greidastID = new SelectList(db.Vextir_greidast, "Vextir_greidastID", "Vextir_greiddir", vaxtaruna.Vextir_greidastID);
            ViewBag.VaxtafoturID = new SelectList(db.Vaxtafoturs, "VaxtafoturID", "Heiti", vaxtaruna.VaxtafoturID);
            return View(vaxtaruna);
        }

        // GET: Vaxtarunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtaruna vaxtaruna = db.Vaxtarunas.Find(id);
            if (vaxtaruna == null)
            {
                return HttpNotFound();
            }
            return View(vaxtaruna);
        }

        // POST: Vaxtarunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaxtaruna vaxtaruna = db.Vaxtarunas.Find(id);
            db.Vaxtarunas.Remove(vaxtaruna);
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
