using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class OrderStatusController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.OrderStatusTable.Where(x => x.O_name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            OrderStatus orderStatus = new OrderStatus();
            orderStatus.StatusSelect = db.StatusTable.ToList<Status>();
            return View(orderStatus);
        }

        [HttpPost]
        public ActionResult Create(OrderStatus orderStatus)
        {
            db.OrderStatusTable.Add(orderStatus);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            OrderStatus orderStatus = db.OrderStatusTable.Find(id);
            if (orderStatus == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            orderStatus.StatusSelect = db.StatusTable.ToList<Status>();
            return View(orderStatus);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            OrderStatus orderStatus = db.OrderStatusTable.Find(id);
            UpdateModel(orderStatus);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            OrderStatus orderStatus = db.OrderStatusTable.Find(id);
            if (orderStatus == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(orderStatus);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            OrderStatus orderStatus = db.OrderStatusTable.Find(id);
            db.OrderStatusTable.Remove(orderStatus);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}