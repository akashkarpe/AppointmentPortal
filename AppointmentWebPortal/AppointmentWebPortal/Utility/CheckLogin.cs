using AppointmentWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace AppointmentWebPortal.Utility
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = false)]
    public class CheckLogin : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            HttpContext context = HttpContext.Current;
            if (context.Session != null)
            {
                if (context.Session.IsNewSession)
                {
                    string cookieHeader = context.Request.Headers["Cookie"];
                    if ((null != cookieHeader) && (cookieHeader.IndexOf("formauth") >= 0))
                    {
                        SessionUtility sessionUtility = new SessionUtility();
                        if (sessionUtility.GetValueFromSession(Constants.LoginResponse) == null)
                        {
                            FormsAuthentication.SignOut();
                            var values = new RouteValueDictionary(new
                            {
                                action = "Index",
                                controller = "Home"
                            });
                            filterContext.Result = new RedirectToRouteResult(values);
                        }
                    }
                    
                }
            }

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}