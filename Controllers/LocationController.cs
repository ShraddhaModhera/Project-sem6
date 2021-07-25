using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class LocationController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.LocationTable.Where(x => x.Lname.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Location location = new Location();
            location.StatusSelect = db.StatusTable.ToList<Status>();
            return View(location);
        }

        [HttpPost]
        public ActionResult Create(Location location)
        {
            db.LocationTable.Add(location);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Location location = db.LocationTable.Find(id);
            if (location == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            location.StatusSelect = db.StatusTable.ToList<Status>();
            return View(location);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Location location = db.LocationTable.Find(id);
            UpdateModel(location);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Location location = db.LocationTable.Find(id);
            if (location == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(location);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Location location = db.LocationTable.Find(id);
            db.LocationTable.Remove(location);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}