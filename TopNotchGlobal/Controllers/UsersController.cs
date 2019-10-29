using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;
using Logger_;

namespace TopNotchGlobal.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<UserBLL> infos = null;
            using (ContextBLL context = new ContextBLL())
            {
                infos = context.UsersGetAll(0, 100);
            }
            return View(infos);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            UserBLL it = null;
            using (ContextBLL context = new ContextBLL())
            {
                it = context.UserFindByID(id);
            }
            return View(it);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UserBLL collection)
        {
            try
            {
                using (ContextBLL context = new ContextBLL())
                {
                    context.UserCreate(collection.Email,collection.Hash,collection.Salt,collection.RoleID);
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

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            UserBLL info;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.UserFindByID(id);
                List<RoleBLL> items = context.RoleGetAll(0, 100);
                SelectList L = new SelectList(items, "RoleID", "RoleName");
                ViewBag.ListItems = L;
            }
            return View(info);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL collection)
        {
            try
            {
                // TODO: Add update logic here
                using(ContextBLL context = new ContextBLL())
                {
                    context.UserUpdateJust(id, collection.Email, collection.Hash, collection.Salt, collection.RoleID);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("NiceErrorMessage", ex);
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            UserBLL info;
            using (ContextBLL context = new ContextBLL())
            {
                info = context.UserFindByID(id);
            }
            return View(info);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserBLL collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContextBLL context = new ContextBLL())
                {
                    context.UserDelete(id);

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
