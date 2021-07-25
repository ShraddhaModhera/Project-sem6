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
    public class CustomerController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {                        
            return View(db.CustomerTable.Where(x => x.First_name.Contains(searching) || searching == null).ToList());
        }

        public ActionResult Create()
        {
            Customer customer = new Customer();
            customer.StatusSelect = db.StatusTable.ToList<Status>();
            customer.CGroupSelect = db.CGroupTable.ToList<CustomerGroup>();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer , string Mail)
        {
            if(Mail == "true")
            {
                customer.Mail_status = true;
            }
            else
            {
                customer.Mail_status = false;
            }            
            db.CustomerTable.Add(customer);
            db.SaveChanges();            
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Customer customer = db.CustomerTable.Find(id);
            if (customer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            customer.StatusSelect = db.StatusTable.ToList<Status>();
            customer.CGroupSelect = db.CGroupTable.ToList<CustomerGroup>();
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(int id , string Mail)
        {
            Customer customer = db.CustomerTable.Find(id);
            if (Mail == "true")
            {
                customer.Mail_status = true;
            }
            else
            {
                customer.Mail_status = false;
            }
            UpdateModel(customer);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Customer customer = db.CustomerTable.Find(id);
            if (customer == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Customer customer = db.CustomerTable.Find(id);
            db.CustomerTable.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}