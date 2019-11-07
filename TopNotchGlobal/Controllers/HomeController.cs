using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopNotchGlobal.Models;
using Logger_;

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
        {try
            {


                using (ContextBLL context = new ContextBLL())
                {
                    UserBLL user = context.UserRoleFindByEmail(info.Email);
                    if (user == null)
                    {
                        info.Message = $"The Email '{info.Email }' does not exist in the database";
                        return View(info);
                    }
                    string actual = user.Hash;
                    string potential = info.Hash + user.Salt;
                    bool validateuser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual, potential);
                    string validationType = $"ClearText:({user.UserID})";
                    if (!validateuser)
                    {
                        potential = info.Hash + user.Salt;
                        try
                        {
                            validateuser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual, potential);
                            validationType = $"Hashed:({user.UserID})";
                        }
                        catch (Exception ex)
                        {
                            Logger.Log(ex);
                            validateuser = false;
                        }

                    }
                    if (validateuser)
                    {
                        Session["AuthEmail"] = user.Email;
                        Session["AuthRoleName"] = user.RoleName;
                        Session["AUTHType"] = validationType;
                        return Redirect(info.ReturnURL);
                    }
                    info.Message = "The Email/password was incorrect";
                    return View(info);

                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }

        }
            [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("AUTHEmail");
            Session.Remove("AUTHRoleName");
            return RedirectToAction("Index");
        }
        //Get
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel info)
        {   try
            {


                using (ContextBLL context = new ContextBLL())
                {
                    UserBLL user = context.UserFindByEmail(info.Email);
                    if (user != null)
                    {
                        info.Message = $"The EMail Address '{info.Email}' already exists in the database";
                        ModelState.Clear();
                        return View(info);
                    }
                    if (!ModelState.IsValid)
                    {
                        return View(info);
                    }
                    user = new UserBLL
                    {
                        Email = info.Email,
                        Salt = System.Web.Helpers.Crypto.
                        GenerateSalt(Constants.SaltSize)
                    };
                    user.Hash = System.Web.Helpers.Crypto.
                        HashPassword(info.Hash + user.Salt);
                    user.RoleID = 3;

                    context.UserCreate(user.Email, user.Hash, user.Salt, Constants.NonVerifiedUser);
                    Session["AUTHUsername"] = user.Email;
                    Session["AUTHRoles"] = user.RoleName;
                    Session["AUTHTYPE"] = "HASHED";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }



    }





}