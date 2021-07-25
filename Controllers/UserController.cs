using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class UserController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.UserTable.Where(x => x.Username.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            User user = new User();
            user.StatusSelect = db.StatusTable.ToList<Status>();
            user.RoleSelect = db.RoleTable.ToList<Role>();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            db.UserTable.Add(user);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            User user = db.UserTable.Find(id);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            user.StatusSelect = db.StatusTable.ToList<Status>();
            user.RoleSelect = db.RoleTable.ToList<Role>();
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            User user = db.UserTable.Find(id);
            UpdateModel(user);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            User user = db.UserTable.Find(id);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            User user = db.UserTable.Find(id);
            db.UserTable.Remove(user);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}