using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class TaxController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.TaxTable.Where(x => x.Tname.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Tax tax = new Tax();
            tax.StatusSelect = db.StatusTable.ToList<Status>();
            return View(tax);
        }

        [HttpPost]
        public ActionResult Create(Tax tax)
        {
            db.TaxTable.Add(tax);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Tax tax = db.TaxTable.Find(id);
            if (tax == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            tax.StatusSelect = db.StatusTable.ToList<Status>();
            return View(tax);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Tax tax = db.TaxTable.Find(id);
            UpdateModel(tax);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Tax tax = db.TaxTable.Find(id);
            if (tax == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(tax);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Tax tax = db.TaxTable.Find(id);
            db.TaxTable.Remove(tax);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}