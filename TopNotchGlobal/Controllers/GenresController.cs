using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Logger_;

namespace TopNotchGlobal.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres
        public ActionResult Index()
        {
            List<GenreBLL> info = null;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.GenresGetAll(0, 100);
            }
            return View(info);
        }

        // GET: Genres/Details/5
        public ActionResult Details(int id)
        {
            GenreBLL info = null;
            using(ContextBLL context = new ContextBLL())
            {
                info = context.GenreFindByID(id);
            }
            return View(info);
        }

        // GET: Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        [HttpPost]
        public ActionResult Create(GenreBLL collection)
        {
            try
            {   using (ContextBLL context = new ContextBLL())
                {
                    context.GenreCreate(collection.GenreName);
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

        // GET: Genres/Edit/5
        public ActionResult Edit(int id)
        {
            GenreBLL info;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.GenreFindByID(id);
            }
            return View(info);
        }

        // POST: Genres/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GenreBLL collection)
        {
            try
            { using(ContextBLL context = new ContextBLL())
                {
                    context.GenreUpdateJust(id, collection.GenreName);
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

        // GET: Genres/Delete/5
        public ActionResult Delete(int id)
        {
            GenreBLL info;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.GenreFindByID(id);
            }
            return View(info);
        }

        // POST: Genres/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GenreBLL collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContextBLL context = new ContextBLL())
                {
                    context.GenreDelete(id);

                }
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
