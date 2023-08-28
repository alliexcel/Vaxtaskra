using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vaxtaskra.Models;

namespace Vaxtaskra.App_Start
{
    public class SetDb
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();
        // GET: SetDb
        public void SetDbData()
        {
            try
            {
                List<Vextir_greidast> vg = (from i in db.Vextir_greidast select i).ToList();
            }
            catch
            {
                Vextir_greidast vg = new Vextir_greidast();
                vg.Vextir_greiddir = "Mánaðarlega";
              
                    db.Vextir_greidast.Add(vg);
                    db.SaveChanges();

                
                Vextir_greidast vg2 = new Vextir_greidast();
                vg2.Vextir_greiddir = "Árlega";
              
                    db.Vextir_greidast.Add(vg2);
                    db.SaveChanges();

                
            }
        }
    }
}