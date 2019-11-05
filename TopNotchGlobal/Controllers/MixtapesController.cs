using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Logger_;

namespace TopNotchGlobal.Controllers
{
    public class MixtapesController : Controller
    {
        // GET: Mixtapes
        public ActionResult Statistics()
        {
            List<MixtapeBLL> info = null;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.MixtapesGetAll(0, 100);
                MixtapeCalculator MC = new MixtapeCalculator();
               var RV= MC.MixtapeComputer(info);
                return View(RV);
            }
            
           
        }
        public ActionResult Index()
        {
            List<MixtapeBLL> info = null;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.MixtapesGetAll(0, 100);
            }
            return View(info);

        }

        public ActionResult ShowListeners(int id)
        {

            List<UserBLL> infos = new List<UserBLL>();
            using (ContextBLL context = new ContextBLL())
            {
                 infos = context.ListeningsGetAllUserListeningsByMixtapeID(0,100,id);
            }
            return View("..\\Users\\index",infos);
        }
        public ActionResult ViewRatings(int id)
        {

            List<UserBLL> infos = new List<UserBLL>();
            using (ContextBLL context = new ContextBLL())
            {
                infos = context.RatingsGetAllUsersRatingsByMixtapeID(0, 100, id);
            }
            return View("..\\Users\\index", infos);
        }
        // GET: Mixtapes/Details/5
        public ActionResult Details(int id)
        {

            MixtapeBLL info = null;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.MixtapeFindByID(id);
            }
            return View(info);
        }

        // GET: Mixtapes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mixtapes/Create
        [HttpPost]
        public ActionResult Create(MixtapeBLL collection)
        {
            try
            {   using(ContextBLL context = new ContextBLL())
                {
                    context.MixtapeCreate(collection.MixtapePath,collection.ArtistName, collection.Title, collection.NumberOfSongs, collection.Length);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }
        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, MixtapeBLL collection)
        {
            if (file != null && file.ContentLength> 0)
            {
                string MixtapeName = Path.GetFileNameWithoutExtension(file.FileName) + DateTime.Now.Ticks + Path.GetExtension(file.FileName);
                string MixtapePath = Path.Combine(Server.MapPath("~/Content/UploadedFiles"), MixtapeName);

                string WebOutput = Path.Combine("~/Content/UploadedFiles", MixtapeName);
                MixtapeBLL info = new MixtapeBLL();

                using (ContextBLL context = new ContextBLL())
                {
                    info.MixtapePath = WebOutput;
                    context.MixtapeCreate(info.MixtapePath,collection.ArtistName,collection.Title,collection.NumberOfSongs,collection.Length);

                }
                
                file.SaveAs(MixtapePath);
                


                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "You have not specified a file yet please go back and specify which file";
                    return View();
            }
        }

        // GET: Mixtapes/Edit/5
        public ActionResult Edit(int id)
        {
            MixtapeBLL info;
            using(ContextBLL context = new ContextBLL())
            {
                info = context.MixtapeFindByID(id);
            }
            return View(info);
        }

        // POST: Mixtapes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MixtapeBLL collection)
        {
            try
            { using(ContextBLL context = new ContextBLL())
                {
                    context.MixtapeUpdateJust(id,collection.MixtapePath, collection.ArtistName, collection.Title, collection.NumberOfSongs, collection.Length);
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Mixtapes/Delete/5
        public ActionResult Delete(int id)
        {
            MixtapeBLL info;
            using(ContextBLL context = new ContextBLL())
            {
                info = context.MixtapeFindByID(id);
            }
            return View(info);
        }

        // POST: Mixtapes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MixtapeBLL collection)
        {
            try
            {using (ContextBLL context = new ContextBLL())
                {
                    context.MixtapeDelete(id);
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }
    }
}
