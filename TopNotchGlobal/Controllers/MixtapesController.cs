using System;
using System.Collections.Generic;
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
        public ActionResult Index()
        {
            List<MixtapeBLL> info = null;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.MixtapesGetAll(0, 100);
            }
            return View(info);
           
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
                    context.MixtapeCreate(collection.ArtistName, collection.Title, collection.NumberOfSongs, collection.Length);
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("NiceErrorMessage", ex);
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
                    context.MixtapeUpdateJust(id, collection.ArtistName, collection.Title, collection.NumberOfSongs, collection.Length);
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("NiceErrorMessage", ex);
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
                return View("NiceErrorMessage", ex);
            }
        }
    }
}
