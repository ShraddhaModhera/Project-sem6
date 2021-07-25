using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class LanguageController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.LangTable.Where(x => x.Lname.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Language language = new Language();
            language.StatusSelect = db.StatusTable.ToList<Status>();
            return View(language);
        }

        [HttpPost]
        public ActionResult Create(Language language)
        {
            db.LangTable.Add(language);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Language language = db.LangTable.Find(id);
            if (language == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            language.StatusSelect = db.StatusTable.ToList<Status>();
            return View(language);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Language language = db.LangTable.Find(id);
            UpdateModel(language);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Language language = db.LangTable.Find(id);
            if (language == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(language);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Language language = db.LangTable.Find(id);
            db.LangTable.Remove(language);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}