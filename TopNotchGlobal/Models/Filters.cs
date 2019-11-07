using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TopNotchGlobal.Models
{
    public class Filters
    {
        
        public class MyController
        {
            [MustBeLoggedIn]
            public class MustBeLoggedInAttribute : AuthorizeAttribute
            {
                public override void OnAuthorization(AuthorizationContext filterContext)
                {
                    if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                    {
                        base.OnAuthorization(filterContext);
                    }
                    else
                    {
                        string ReturnURL = filterContext.RequestContext.HttpContext.Request.Path.ToString();
                        filterContext.Controller.TempData.Add("Message", $"You must be logged into any account to access this resource, you are not currently logged in");
                        filterContext.Controller.TempData.Add("ReturnURL", ReturnURL);
                        System.Web.Routing.RouteValueDictionary dict = new System.Web.Routing.RouteValueDictionary();
                        dict.Add("Controller", "Home");
                        dict.Add("Action", "Login");
                        filterContext.Result = new RedirectToRouteResult(dict);
                    }
                }
            }
        }
        [MustBeInRole]
        public class MustBeInRoleAttribute : AuthorizeAttribute
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                if (this.Roles.Split(',').Any(filterContext.HttpContext.User.IsInRole))
                {
                base.OnAuthorization(filterContext);

                }
            else
            {
                string ReturnURL = filterContext.RequestContext.HttpContext.Request.Path.ToString();
                filterContext.Controller.TempData.Add("Message",
                     $"you must be in at least one of the following roles to access this resource:  {Roles}");
                filterContext.Controller.TempData.Add("ReturnURL", ReturnURL);
                System.Web.Routing.RouteValueDictionary dict = new System.Web.Routing.RouteValueDictionary();
                    dict.Add("Controller","Home");
                dict.Add("Action","Login");  
                   filterContext.Result = new RedirectToRouteResult(dict);

            }

             }
         }
    }
}