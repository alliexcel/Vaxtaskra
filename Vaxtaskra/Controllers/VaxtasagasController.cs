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
    public class VaxtasagasController : Controller
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();

        // GET: Vaxtasagas
        public ActionResult Index()
        {
            List<Vaxtasaga> v_list = (from i in db.Vaxtasagas select i).ToList();

            List<vaxtasagas_full> vf = new List<vaxtasagas_full>();

            foreach ( var i in v_list)
            {
                vaxtasagas_full vsf = new vaxtasagas_full();
                vsf.VaxtafoturID = i.VaxtafoturID;
                vsf.VaxtarunaID = i.VaxtarunaID;
                vsf.Vextir_total = i.VextirTotal;
                Vaxtafotur v = (from a in db.Vaxtafoturs where a.VaxtafoturID == i.VaxtafoturID select a).FirstOrDefault();
                vsf.Vaxtafotur = v.Heiti;
                Vaxtaruna vr = (from b in db.Vaxtarunas where b.VaxtarunaID == i.VaxtarunaID select b).FirstOrDefault();
                vsf.Vaxtaruna =vr.Heiti;
                vsf.is_lending = !vr.Is_deposit;
                vsf.is_indexed = vr.Is_indexed;
                vsf.Vaxtafotur_interests = i.Vaxtafotur;
                vsf.Vaxtaruna_interests = i.Spread;
                vsf.DateChange = i.Date;
                vf.Add(vsf);
                
            }

            return View(vf);
        }
        public JsonResult json()
        {
            return Json(db.Vaxtasagas.ToList(), JsonRequestBehavior.AllowGet);
        }

       



    }
   
}
