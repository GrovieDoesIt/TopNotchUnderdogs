﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopNotchGlobal.Models
{
    public class Filters
    {
        //[MustBeLoggedIn] public class MyController
        //{
        //    public class MustBeLoggedInAttribute : AuthorizeAttribute
        //    {
        //        public override void OnAuthorization(AuthorizationContext filterContext)
        //        {
        //            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
        //            {
        //                base.OnAuthorization(filterContext);
        //            }
        //            else
        //            {
        //                string ReturnURL = filterContext.RequestContext.HttpContext.Request.Path.ToString();
        //                filterContext.Controller.TempData.Add("Message", $"You must be logged into any account to access this resource, you are not currently logged in");
        //                filterContext.Controller.TempData.Add("ReturnURL", ReturnURL);
        //                System.Web.Routing.RouteValueDictionary dict = new System.Web.Routing.RouteValueDictionary();
        //                dict.Add("Controller", "Home");
        //                dict.Add("Action", "Login");
        //                filterContext.Result = new RedirectToRouteResult(dict);
        //            }
        //        }
        //    }
        //}
    }
}