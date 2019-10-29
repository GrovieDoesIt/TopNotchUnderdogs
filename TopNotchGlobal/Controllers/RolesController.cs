    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Logger_;

namespace TopNotchGlobal.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            List<RoleBLL> infos = null;
            using (ContextBLL context = new ContextBLL())
            {
                infos = context.RoleGetAll(0, 100);
            }
            return View(infos);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        { RoleBLL it = null;
            using (ContextBLL context = new ContextBLL())
            {
                it = context.RoleFindByID(id);
            }
            return View(it);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            ////RoleBLL info;
            ////using(ContextBLL context = new ContextBLL())
            //{
            //    info = context.RoleCreate(RoleName);
            //}
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(RoleBLL collection)
        {
            try
            {
                
                using(ContextBLL context = new ContextBLL())
                {
                     context.RoleCreate(collection.RoleName);
                }
            //TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("NiceErrorMessage", ex);
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            RoleBLL info;
            using(ContextBLL context = new ContextBLL())
            {
                info = context.RoleFindByID(id);
                
            }
            return View(info);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleBLL collection)
        {
            try
            {
                // TODO: Add update logic here
                using (ContextBLL context = new ContextBLL())
                {
                    context.RoleUpdateJust(id, collection.RoleName);

                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("NiceErrorMessage", ex);
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            RoleBLL info;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.RoleFindByID(id);
            }
            return View(info);
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RoleBLL collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContextBLL context = new ContextBLL())
                {
                    context.RoleDelete(id);

                }
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
