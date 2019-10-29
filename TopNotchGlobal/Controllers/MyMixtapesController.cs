using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace TopNotchGlobal.Controllers
{
    public class MyMixtapesController : Controller
    {
        // GET: MyMixtapes
        public ActionResult Index()
        {
            List<ListeningBLL> infos = null;
            using (ContextBLL context = new ContextBLL())
            {
                infos = context.ListeningsGetAllMixtapeListeningsByUserID(0, 100, 2);
            }
            return View(infos);
        }

        // GET: MyMixtapes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyMixtapes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyMixtapes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyMixtapes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyMixtapes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyMixtapes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyMixtapes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
