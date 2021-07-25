using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class VariantController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.VariantTable.Where(x => x.V_name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Variant variant = new Variant();
            variant.StatusSelect = db.StatusTable.ToList<Status>();
            return View(variant);
        }

        [HttpPost]
        public ActionResult Create(Variant variant)
        {
            db.VariantTable.Add(variant);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Variant variant = db.VariantTable.Find(id);
            if (variant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            variant.StatusSelect = db.StatusTable.ToList<Status>();
            return View(variant);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Variant variant = db.VariantTable.Find(id);
            UpdateModel(variant);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Variant variant = db.VariantTable.Find(id);
            if (variant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(variant);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Variant variant = db.VariantTable.Find(id);
            db.VariantTable.Remove(variant);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}