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
    public class CustomerGroupController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.CGroupTable.Where(x => x.Group_name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Create()
        {
            CustomerGroup Cgroup = new CustomerGroup();
            Cgroup.StatusSelect = db.StatusTable.ToList<Status>();
            return View(Cgroup);
        }

        [HttpPost]
        public ActionResult Create(CustomerGroup Cgroup)
        {
            db.CGroupTable.Add(Cgroup);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            CustomerGroup Cgroup = db.CGroupTable.Find(id);
            if (Cgroup == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            Cgroup.StatusSelect = db.StatusTable.ToList<Status>();
            return View(Cgroup);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            CustomerGroup Cgroup = db.CGroupTable.Find(id);
            UpdateModel(Cgroup);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            CustomerGroup Cgroup = db.CGroupTable.Find(id);
            if (Cgroup == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(Cgroup);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CustomerGroup Cgroup = db.CGroupTable.Find(id);
            db.CGroupTable.Remove(Cgroup);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}