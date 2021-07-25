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
    public class PageGroupController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.PageGroupTable.Where(x => x.Group_name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Create()
        {
            PageGroup pagegroup = new PageGroup();
            pagegroup.StatusSelect = db.StatusTable.ToList<Status>();
            return View(pagegroup);
        }

        [HttpPost]
        public ActionResult Create(PageGroup pagegroup)
        {
            db.PageGroupTable.Add(pagegroup);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            PageGroup pagegroup = db.PageGroupTable.Find(id);
            if (pagegroup == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            pagegroup.StatusSelect = db.StatusTable.ToList<Status>();
            return View(pagegroup);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            PageGroup pagegroup = db.PageGroupTable.Find(id);
            UpdateModel(pagegroup);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            PageGroup pagegroup = db.PageGroupTable.Find(id);
            if (pagegroup == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(pagegroup);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            PageGroup pagegroup = db.PageGroupTable.Find(id);
            db.PageGroupTable.Remove(pagegroup);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}