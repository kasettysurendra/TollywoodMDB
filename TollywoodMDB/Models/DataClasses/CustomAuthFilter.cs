using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace TollywoodMDB.Models
{
    public class CustomAuthFilter: AuthorizeAttribute
    {
        public new string Roles { get; set; }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.User.Identity.Name;
            if (!string.IsNullOrEmpty(user))
            {
                TollywoodMDBcontext objContext = new TollywoodMDBcontext();
                var login = objContext.Logins.Where(l => l.EmailId == user).First();
                if (login.Role.Contains("Admin"))
                {

                }
            }
            else
            {
                //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                //      { "action", "Error" },
                //    { "Controller","UnAuthorised"} });

                throw new HttpException(404,"Un Authorised to access the page..Please contact system adminstrator");
            }

        }
       
    }
}