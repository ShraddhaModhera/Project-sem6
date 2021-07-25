using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class ServiceController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            //var result = db.ServiceTable.Select(s => s.S_title.Count().ToString());
            ViewBag.msg = db.ServiceTable.Count();
            return View(db.ServiceTable.Where(x => x.S_title.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Create()
        {
            Service service = new Service();
            service.StatusSelect = db.StatusTable.ToList<Status>();
            return View(service);
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Is_active")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.ServiceTable.Add(service);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View(service);
            }
            
        }

        public ActionResult Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Service service = db.ServiceTable.Find(id);
            if(service==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            service.StatusSelect = db.StatusTable.ToList<Status>();
            return View(service);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Service service = db.ServiceTable.Find(id);
            UpdateModel(service);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Service service = db.ServiceTable.Find(id);
            if (service == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(service);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Service service = db.ServiceTable.Find(id);
            db.ServiceTable.Remove(service);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}