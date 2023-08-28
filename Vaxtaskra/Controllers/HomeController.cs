using System;
using System.Collections.Generic;
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

    public class HomeController : Controller
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            List<Vaxtarunur_list> vl_list = new List<Vaxtarunur_list>();
            List<Vaxtaruna> vr = new List<Vaxtaruna>();
        
         
            vr = (from i in db.Vaxtarunas select i).ToList();

           

            foreach (var i in vr)
            {
                Vaxtarunur_list vl = new Vaxtarunur_list();
                vl.Vaxtafotur_ID = i.VaxtafoturID;
                vl.Vaxtaruna_ID = i.VaxtarunaID;
                vl.Vaxtaruna_heiti = i.Heiti;

                
                Vaxtafotur vf = (from v in db.Vaxtafoturs where v.VaxtafoturID == i.VaxtafoturID && v.is_active == true select v).FirstOrDefault();     
                vl.Vaxtafotur_heiti = vf.Heiti;
                vl.is_indexed = i.Is_indexed;
                vl.is_deposit = i.Is_deposit;
                vl.vextir_greidast = (from mt in db.Vextir_greidast where i.Vextir_greidastID == mt.Vextir_greidastID select mt).FirstOrDefault().Vextir_greiddir;
                vl.Vaxtafotur_interest = (from vi in db.Vaxtafotur_interests where vi.VaxtafoturId == i.VaxtafoturID && vi.Is_Current == 1 select vi).FirstOrDefault().Interest;
                
               
                try
                {
                    Vaxtaruna_interests vi = (from vs in db.Vaxtaruna_interests where vs.VaxtarunaID == i.VaxtarunaID && vs.is_current == 1 select vs).FirstOrDefault();
                    vl.Spread = vi.Spread;
                    vl.Vaxtaruna_interestsID = vi.Vaxtaruna_InterestsID;
                    vl.interests_total = vl.Vaxtafotur_interest + vl.Spread;

                    vl.amount_from = Convert.ToDecimal(i.Amount_from);
                    vl.amount_to = Convert.ToDecimal(i.Amount_to);
                    vl.is_fixed = i.Is_fixed;
                    vl.Months_Tied = Convert.ToInt32(i.Months_tied);

                    vl_list.Add(vl);
                }
                catch {
                   
                }
           
                
               


               
            }


            return View(vl_list);
        }


        [HttpPost]
        public ActionResult Index([Bind(Include = "selectLending,selectDeposit,selectFixed,selectIndexed, selectNonIndexed")] Vaxtarunur_list vaxtarunulisti)
        {
            
            List<Vaxtarunur_list> vl_list = new List<Vaxtarunur_list>();
            List<Vaxtaruna> vr = new List<Vaxtaruna>();

            if(vaxtarunulisti.selectLending == true || vaxtarunulisti.is_deposit == false)
            {
                vr = (from i in db.Vaxtarunas where i.Is_deposit == false select i).ToList();
            }
            
            
            if(vaxtarunulisti.selectDeposit ==true || vaxtarunulisti.is_deposit == true)
            {
                vr = (from i in db.Vaxtarunas where i.Is_deposit == true select i).ToList();
            }
            
            if(vaxtarunulisti.selectLending == vaxtarunulisti.selectDeposit)
            {
            vr = (from i in db.Vaxtarunas select i).ToList();
            }

            if (vaxtarunulisti.selectIndexed == true && vaxtarunulisti.selectNonIndexed == false)
            {
                vr = (from i in vr where i.Is_indexed == true select i).ToList();
            }
            if (vaxtarunulisti.selectIndexed == false && vaxtarunulisti.selectNonIndexed == true)
            {
                vr = (from i in vr where i.Is_indexed == false select i).ToList();
            }

            if (vaxtarunulisti.selectFixed)
            {
                vr = (from i in vr where i.Is_fixed == true select i).ToList();
            }

            
            foreach (var i in vr)
            {

                Vaxtarunur_list vl = new Vaxtarunur_list();
                try
                {
                    vl.Spread = (from vs in db.Vaxtaruna_interests where vs.VaxtarunaID == i.VaxtarunaID && vs.is_current == 1 select vs).FirstOrDefault().Spread;
                }
                catch
                {
                    
                    continue;
                    
                }
                vl.Vaxtafotur_ID = i.VaxtafoturID;
                vl.Vaxtaruna_ID = i.VaxtarunaID;
                vl.Vaxtaruna_heiti = i.Heiti;

                Vaxtafotur vf = (from v in db.Vaxtafoturs where v.VaxtafoturID == i.VaxtafoturID select v).FirstOrDefault();
                vl.Vaxtafotur_heiti = vf.Heiti;
                vl.is_indexed = i.Is_indexed;
                vl.is_deposit = i.Is_deposit;
                vl.vextir_greidast = (from mt in db.Vextir_greidast where i.Vextir_greidastID == mt.Vextir_greidastID select mt).FirstOrDefault().Vextir_greiddir;
                vl.Vaxtafotur_interest = (from vi in db.Vaxtafotur_interests where vi.VaxtafoturId == i.VaxtafoturID && vi.Is_Current == 1 select vi).FirstOrDefault().Interest;
                vl.interests_total = vl.Vaxtafotur_interest + vl.Spread;
                vl.amount_from = Convert.ToDecimal(i.Amount_from);
                vl.amount_to = Convert.ToDecimal(i.Amount_to);
                vl.is_fixed = i.Is_fixed;
                vl.Months_Tied = Convert.ToInt32(i.Months_tied);

                vl_list.Add(vl);
            }


            return View(vl_list);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaxtaruna_interests vi = db.Vaxtaruna_interests.Find(id);
            if (vi == null)
            {
                return HttpNotFound();
            }

            vi.Vaxtaruna = (from i in db.Vaxtarunas where i.VaxtarunaID == vi.VaxtarunaID select i).FirstOrDefault();
            return View(vi);

        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Vaxtaruna_interests> vi = (from i in db.Vaxtaruna_interests where i.Vaxtaruna_InterestsID == id select i).ToList();
          
            foreach(var i in vi)
            {
                i.is_current = 0;
                db.Entry(i).State = EntityState.Modified;
                db.SaveChanges();
            }
            


   

            return RedirectToAction("index");
        }








        public ActionResult Edit(int VaxtarunaID)
        {
            Vaxtaruna_all va = new Vaxtaruna_all();

            va.Vaxtaruna = (from i in db.Vaxtarunas where i.VaxtarunaID == VaxtarunaID select i).FirstOrDefault();
            va.VaxtarunaInterests = (from i in db.Vaxtaruna_interests where i.VaxtarunaID == VaxtarunaID && i.is_current == 1 select i).FirstOrDefault();
            va.Vaxtafotur = (from i in db.Vaxtafoturs where i.VaxtafoturID == va.Vaxtaruna.VaxtafoturID select i).FirstOrDefault();
            va.Vaxtafotur_interests = (from i in db.Vaxtafotur_interests where i.VaxtafoturId == va.Vaxtafotur.VaxtafoturID && i.Is_Current == 1 select i).FirstOrDefault();
            ViewBag.VextirGreidast = (from i in db.Vextir_greidast select i).ToList();

            return View(va);
        }

        [HttpPost]
        public ActionResult Edit(Vaxtaruna_all va)
        {
            Vaxtaruna_interests vi = (from i in db.Vaxtaruna_interests where i.Vaxtaruna_InterestsID == va.VaxtarunaInterests.Vaxtaruna_InterestsID && i.is_current == 1 select i).FirstOrDefault();
            
            Vaxtaruna vr = (from i in db.Vaxtarunas where i.VaxtarunaID == va.VaxtarunaInterests.VaxtarunaID select i).FirstOrDefault();
            vr.Vextir_greidastID = va.Vaxtaruna.Vextir_greidastID;

            Vaxtaruna_interests vi_new = new Vaxtaruna_interests();
            vi_new.Spread = Convert.ToDecimal(va.SpreadString.Replace(".",","));
            vi_new.is_current = 1;
            vi_new.Date = System.DateTime.Today;
            vi_new.VaxtarunaID = va.VaxtarunaInterests.VaxtarunaID;


            vi.is_current = 0;

            if (ModelState.IsValid)
            {
                db.Vaxtaruna_interests.Add(vi_new);
                db.SaveChanges();        
            }


            if (ModelState.IsValid)
            {
                db.Entry(vi).State = EntityState.Modified;
                db.SaveChanges();           
            }

            if (ModelState.IsValid)
            {
                db.Entry(vr).State = EntityState.Modified;
                db.SaveChanges();     
            }

            SaveCurrentInt();

            return RedirectToAction("Index");
        }

        public void SaveCurrentInt()
        {
                //insert
                List<Vaxtaruna_interests> vi = (from i in db.Vaxtaruna_interests where i.is_current == 1 select i).ToList();
            List<Vaxtasaga> vaxtasaga = (from vaxts in db.Vaxtasagas where DbFunctions.TruncateTime(vaxts.Date) == DbFunctions.TruncateTime(System.DateTime.Now) select vaxts).ToList();

            foreach (var vxts in vaxtasaga)
            {
                db.Vaxtasagas.Remove(vxts);
                db.SaveChanges();
            }

            foreach (var i in vi)
                {
                    Vaxtasaga vs2 = new Vaxtasaga();
                    vs2.Date = System.DateTime.Now;
                    vs2.Spread = i.Spread;
                    vs2.VaxtarunaID = i.VaxtarunaID;
                    vs2.VaxtafoturID = i.Vaxtaruna.VaxtafoturID;
                    vs2.Vaxtafotur = (from v in db.Vaxtafotur_interests where v.VaxtafoturId == i.Vaxtaruna.VaxtafoturID && v.Is_Current ==1 select v).FirstOrDefault().Interest;
                    vs2.VextirTotal = vs2.Spread + vs2.Vaxtafotur;


                    if (ModelState.IsValid)
                    {
                        db.Vaxtasagas.Add(vs2);
                        db.SaveChanges();
                    }

                }
        }

        [HttpGet]
        public ActionResult EditFoot(int VaxtafoturID)
        {
            Vaxtafotur_interests vi = (from i in db.Vaxtafotur_interests where i.VaxtafoturId == VaxtafoturID && i.Is_Current == 1 select i).FirstOrDefault();
            ViewBag.Affected = (from i in db.Vaxtarunas where i.VaxtafoturID == VaxtafoturID select i).ToList();
            
            
            return View(vi);
        }
        public ActionResult Contact()
        {
            @ViewBag.Message = "Your contact page.";

            return View();
        }





    }
}