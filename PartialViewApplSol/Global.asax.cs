using PartialViewApplSol.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PartialViewApplSol
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Log.Message(System.Diagnostics.TraceEventType.Information, "Application Started");
        }
        protected void Application_Stop()
        {
            Log.Message(System.Diagnostics.TraceEventType.Information, "Application Stopped");
        }
    }
}
