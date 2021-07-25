using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class RoleController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.RoleTable.Where(x => x.Role_name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Role role = new Role();
            role.StatusSelect = db.StatusTable.ToList<Status>();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(Role role)
        {
            db.RoleTable.Add(role);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Role role = db.RoleTable.Find(id);
            if (role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            role.StatusSelect = db.StatusTable.ToList<Status>();
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Role role = db.RoleTable.Find(id);
            UpdateModel(role);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Role role = db.RoleTable.Find(id);
            if (role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(role);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Role role = db.RoleTable.Find(id);
            db.RoleTable.Remove(role);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}