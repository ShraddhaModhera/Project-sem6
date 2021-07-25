using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class CouponController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.CouponTable.Where(x => x.Name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Coupon coupon = new Coupon();
            coupon.StatusSelect = db.StatusTable.ToList<Status>();
            coupon.ProductSelect = db.ProductTable.ToList<Product>();
            return View(coupon);
        }

        [HttpPost]
        public ActionResult Create(Coupon coupon)
        {
            db.CouponTable.Add(coupon);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Coupon coupon = db.CouponTable.Find(id);
            if (coupon == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            coupon.StatusSelect = db.StatusTable.ToList<Status>();
            coupon.ProductSelect = db.ProductTable.ToList<Product>();
            return View(coupon);
        }

        [HttpPost]
        public ActionResult Edit(Coupon coupon)
        {            
            db.Entry(coupon).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Coupon coupon = db.CouponTable.Find(id);
            if (coupon == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(coupon);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Coupon coupon = db.CouponTable.Find(id);
            db.CouponTable.Remove(coupon);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}