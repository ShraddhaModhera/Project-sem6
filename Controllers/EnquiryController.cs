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
    public class EnquiryController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.EnquiryTable.Where(x => x.Name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Enquiry enquiry = db.EnquiryTable.Find(id);
            if (enquiry == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(enquiry);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Enquiry enquiry = db.EnquiryTable.Find(id);
            db.EnquiryTable.Remove(enquiry);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}