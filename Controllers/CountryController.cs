using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;
using PagedList;
using PagedList.Mvc;

namespace EcommerceProject.Controllers
{
    public class CountryController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.CountryTable.Where(x => x.Country_name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Create()
        {
            Country country = new Country();
            country.StatusSelect = db.StatusTable.ToList<Status>();
            return View(country);
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            db.CountryTable.Add(country);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Country country = db.CountryTable.Find(id);
            if (country == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            country.StatusSelect = db.StatusTable.ToList<Status>();
            return View(country);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Country country = db.CountryTable.Find(id);
            UpdateModel(country);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Country country = db.CountryTable.Find(id);
            if (country == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(country);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Country country = db.CountryTable.Find(id);
            db.CountryTable.Remove(country);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}