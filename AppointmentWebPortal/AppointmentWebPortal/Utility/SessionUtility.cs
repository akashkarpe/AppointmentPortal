using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppointmentWeb.Utility
{
    public class SessionUtility
    {

        public object GetValueFromSession(string code)
        {
            return HttpContext.Current.Session[code];
        }

        public bool SetSessionValue(string code, object value)
        {
            HttpContext.Current.Session[code] = value;
            return true;
        }
    }
}