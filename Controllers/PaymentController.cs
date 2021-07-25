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
    public class PaymentController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List()
        {
            //return View(db.PaymentTable.ToList().ToPagedList(i ?? 1, 3));
            return View(db.PaymentTable.ToList());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Payment payment = db.PaymentTable.Find(id);
            if (payment == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(payment);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Payment payment = db.PaymentTable.Find(id);
            db.PaymentTable.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}