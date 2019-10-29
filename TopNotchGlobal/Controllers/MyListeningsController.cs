using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TopNotchGlobal.Controllers
{
    public class MyListeningsController : Controller
    {
        // GET: MyListenings
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyListenings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyListenings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyListenings/Create
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

        // GET: MyListenings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyListenings/Edit/5
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

        // GET: MyListenings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyListenings/Delete/5
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
