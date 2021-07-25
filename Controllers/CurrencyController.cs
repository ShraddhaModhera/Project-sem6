using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class CurrencyController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.CurrencyTable.Where(x => x.Ctitle.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Currency currency = new Currency();
            currency.StatusSelect = db.StatusTable.ToList<Status>();
            return View(currency);
        }

        [HttpPost]
        public ActionResult Create(Currency currency)
        {
            db.CurrencyTable.Add(currency);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Currency currency = db.CurrencyTable.Find(id);
            if (currency == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            currency.StatusSelect = db.StatusTable.ToList<Status>();
            return View(currency);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Currency currency = db.CurrencyTable.Find(id);
            UpdateModel(currency);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Currency currency = db.CurrencyTable.Find(id);
            if (currency == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(currency);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Currency currency = db.CurrencyTable.Find(id);
            db.CurrencyTable.Remove(currency);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}