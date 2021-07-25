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
    public class PageController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.PageTable.Where(x => x.Title.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Create()
        {
            Page page = new Page();
            page.StatusSelect = db.StatusTable.ToList<Status>();
            page.GroupSelect = db.PageGroupTable.ToList<PageGroup>();
            return View(page);
        }

        [HttpPost]
        public ActionResult Create(Page page)
        {
            db.PageTable.Add(page);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Page page = db.PageTable.Find(id);
            if (page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            page.StatusSelect = db.StatusTable.ToList<Status>();
            page.GroupSelect = db.PageGroupTable.ToList<PageGroup>();
            return View(page);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            Page page = db.PageTable.Find(id);
            UpdateModel(page);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Page page = db.PageTable.Find(id);
            if (page == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(page);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Page page = db.PageTable.Find(id);
            db.PageTable.Remove(page);
            db.SaveChanges();
            return RedirectToAction("List");
        }



    }
}