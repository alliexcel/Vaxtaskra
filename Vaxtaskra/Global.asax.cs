using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vaxtaskra.App_Start;
using Vaxtaskra.Models;
using static Vaxtaskra.RouteConfig;

namespace Vaxtaskra
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private VaxtaDbEntities db = new VaxtaDbEntities();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetDb db = new SetDb();
            db.SetDbData();

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("is-IS");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("is-IS");
            
           

        }
    }
}
