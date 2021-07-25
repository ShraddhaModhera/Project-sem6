using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using EcommerceProject.Models;
using System.Net;

namespace EcommerceProject.Controllers
{
    public class OrderController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(int? i)
        {
            return View(db.OrderTable.ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Order order = db.OrderTable.Find(id);
            if (order == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(order);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Order order = db.OrderTable.Find(id);
            db.OrderTable.Remove(order);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}