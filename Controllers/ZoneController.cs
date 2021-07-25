using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class ZoneController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.ZoneTable.Where(x => x.Zone_name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Zone zone = new Zone();
            zone.StatusSelect = db.StatusTable.ToList<Status>();
            zone.CountrySelect = db.CountryTable.ToList<Country>();
            return View(zone);
        }

        [HttpPost]
        public ActionResult Create(Zone zone)
        {
            db.ZoneTable.Add(zone);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Zone zone = db.ZoneTable.Find(id);
            if (zone == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            zone.StatusSelect = db.StatusTable.ToList<Status>();
            zone.CountrySelect = db.CountryTable.ToList<Country>();
            return View(zone);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Zone zone = db.ZoneTable.Find(id);
            UpdateModel(zone);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Zone zone = db.ZoneTable.Find(id);
            if (zone == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(zone);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Zone zone = db.ZoneTable.Find(id);
            db.ZoneTable.Remove(zone);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}