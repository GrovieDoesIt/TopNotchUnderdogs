using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using TopNotchGlobal.Models;
using Logger_;

namespace TopNotchGlobal.Controllers
{
    public class MultipleTablesController : Controller
    {
        // GET: MultipleTables
        public ActionResult Index()
        {
            OneView2Tables T = new OneView2Tables();


            return View(T);
        }
        [HttpPost]
        public ActionResult Index(OneView2Tables collection)
        {
           
            try
            {
                using (ContextBLL context = new ContextBLL())
                {
                    int ID = context.MixtapeCreate(collection.MixtapePath, collection.ArtistName, collection.Title, collection.NumberOfSongs, collection.Length);
                    int UserID = context.UserCreate(collection.Email, collection.Hash, collection.Salt, Constants.NonVerifiedUser);
                    context.RatingCreate(ID, UserID, collection.RatingScore);
                }
                return RedirectToRoute(new { Controller = "Users", Action = "Index" });
            }
            catch (Exception ex)
            {
                    Logger.Log(ex);
                    return View("Error", ex);
            }



         }

    }
}
