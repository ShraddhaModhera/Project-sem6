using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class StockStatusController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.StockTable.Where(x => x.SS_name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            StockStatus stockStatus = new StockStatus();
            stockStatus.StatusSelect = db.StatusTable.ToList<Status>();
            return View(stockStatus);
        }

        [HttpPost]
        public ActionResult Create(StockStatus stockStatus)
        {
            db.StockTable.Add(stockStatus);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            StockStatus stockStatus = db.StockTable.Find(id);
            if (stockStatus == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            stockStatus.StatusSelect = db.StatusTable.ToList<Status>();
            return View(stockStatus);
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            StockStatus stockStatus = db.StockTable.Find(id);
            UpdateModel(stockStatus);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            StockStatus stockStatus = db.StockTable.Find(id);
            if (stockStatus == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(stockStatus);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            StockStatus stockStatus = db.StockTable.Find(id);
            db.StockTable.Remove(stockStatus);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}