using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartialViewApplSol.App_Start
{
    public class log4netHelper
    {
        private static readonly ILog log4Net = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public log4netHelper()
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated)
                MDC.Set("user", HttpContext.Current.User.Identity.Name);
        }
        public static void LogMessage(string message)
        {
            log4Net.Info(message);
        }

        public static void LogError(string message, Exception ex)
        {
            log4Net.Error(message, ex);
        }
    }
}