using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopNotchGlobal.Models;

namespace TopNotchGlobal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome To TopNotchUnderdogs Let's Change The Music World Together";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us Directly";

            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            // displays empty login screen with predefined returnURL
            LoginModel m = new LoginModel();

            m.Message = TempData["Message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.Email = ("");
            m.Hash = ("");
                return View(m);
            

            
        }

        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            using (BusinessLogicLayer.ContextBLL context = new BusinessLogicLayer.ContextBLL())
            {
                BusinessLogicLayer.UserBLL user = context.UserRoleFindByEmail(info.Email);
                if(user == null)
                {
                    info.Message = $"The Email '{info.Email }' does not exist in the database";
                    return View(info);
                }
                string actual = user.Hash;
                string potential = info.Hash;
                bool validateuser = potential == actual;
                if(validateuser)
                {
                    Session["AuthEmail"] = user.Email;
                    Session["AuthRoleName"] = user.RoleName;
                    return Redirect(info.ReturnURL);
                }
                info.Message = "The password was incorrect";
                return View(info);
            }

    }
            [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("AUTHEmail");
            Session.Remove("AUTHRoleName");
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel info)
        {
            using (BusinessLogicLayer.ContextBLL context  = new BusinessLogicLayer.ContextBLL())
            {
                BusinessLogicLayer.UserBLL user = context.UserFindByEmail(info.Email);
                if (user != null)
                {
                    info.Message = $"The EMail Address '{info.Email}' already exists in the database";
                    ModelState.Clear();
                    return View(info);
                }
                user = new UserBLL
                {
                    Email = info.Email,
                    Salt = System.Web.Helpers.Crypto.
                    GenerateSalt(Constants.SaltSize)
                };
                user.Hash = System.Web.Helpers.Crypto.
                    HashPassword(info.Password + user.Salt);
                user.RoleID = 3;

                context.UserCreate(user.Email,user.Hash,user.Salt,Constants.NonVerifiedUser);
                Session["AUTHUsername"] = user.Email;
                Session["AUTHRoles"] = user.RoleName;
                Session["AUTHTYPE"] = "HASHED";
                return RedirectToAction("Index");
            }
        }



    }





}