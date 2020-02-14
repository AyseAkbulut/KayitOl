using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonelKayit.Models
{
    public class LoginControl     : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Session["name"] != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Home/Login");
                return false;
            }
        }
}
}