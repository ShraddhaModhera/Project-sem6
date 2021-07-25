using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class Email_TemplateController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.EmailTable.Where(x => x.Title.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Email email = new Email();
            email.StatusSelect = db.StatusTable.ToList<Status>();
            return View(email);
        }

        [HttpPost]
        public ActionResult Create(Email email)
        {
            db.EmailTable.Add(email);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Email email = db.EmailTable.Find(id);
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            email.StatusSelect = db.StatusTable.ToList<Status>();
            return View(email);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Email email = db.EmailTable.Find(id);
            UpdateModel(email);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Email email = db.EmailTable.Find(id);
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(email);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Email email = db.EmailTable.Find(id);
            db.EmailTable.Remove(email);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}