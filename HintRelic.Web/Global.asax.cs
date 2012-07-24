using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;
using HintRelic.Logging;
using System.IO;

namespace HintRelic.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private AppDomain _serviceAppDomain = null;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LogListener ll = new LogListener();
            SqlLogProcessor.Listen(ll);
            Debug.Listeners.Add(ll);

            Debug.WriteLine("Application_Start firing at " + DateTime.Now.ToString());

            //_url = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, string.Empty);

            //RegisterCacheEntry(new DataService());
            //RegisterCacheEntry(new PostService());

            //try
            //{
            //    Type t = typeof(Gamervine.Service.GamervineService);
            //    _serviceAppDomain = AppDomain.CreateDomain("GamervineService", null, Path.Combine(this.Context.Request.PhysicalApplicationPath, "bin"), string.Empty, false);
            //    _serviceAppDomain.CreateInstanceAndUnwrap(t.Assembly.FullName, t.FullName);
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("Exception occurred in Application_Start:" + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace);
            //}
        }
    }
}