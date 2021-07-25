using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class UserProductController : Controller
    {
        AdminContext db = new AdminContext();        
        public ActionResult Product(int ? id)
        {
            return View(db.ProductTable.Where(a => a.Category_id == id).ToList());
        }

        public ActionResult View(int? id)
        {
            return View(db.ProductTable.Where(a => a.Product_id == id).ToList());
        }

        [HttpPost]
        public ActionResult View(int id,int qty)
        {
            Product p = db.ProductTable.Where(a => a.Product_id == id).SingleOrDefault();
            if(Session["cart"] == null)
            {
                List<Cart> li = new List<Cart>();
                Cart c = new Cart();
                c.Proid = id;
                c.Pic = p.Image;
                c.Pname = p.Name;
                c.Price = Convert.ToInt32(p.Price);
                c.Qty = Convert.ToInt32(qty);
                c.Bill = c.Price * c.Qty;

                li.Add(c);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = 1;
            }
            else
            {
                List<Cart> li = (List<Cart>)Session["cart"];
                Cart c = new Cart();
                c.Proid = id;
                c.Pic = p.Image;
                c.Pname = p.Name;
                c.Price = Convert.ToInt32(p.Price);
                c.Qty = Convert.ToInt32(qty);
                c.Bill = c.Price * c.Qty;
               
                li.Add(c);
                Session["cart"] = li;
                ViewBag.cart = li.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;

            }
            return RedirectToAction("Home","Home");
        }

        public ActionResult Myorder()
        {
            return View((List<Cart>)Session["cart"]);
        }

        public ActionResult Remove(Cart cart)
        {
            List<Cart> li = (List<Cart>)Session["cart"];
            li.RemoveAll(item => item.Proid == cart.Proid);
            Session["cart"] = li;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "UserProduct");
        }

        public ActionResult Place(Order order)
        {            
            int amt = Convert.ToInt32(Session["amount"]);
            int cuid = Convert.ToInt32(Session["cid"]);
            order.Customer_id = cuid;
            order.Total = amt;

            db.OrderTable.Add(order);
            db.SaveChanges();
            Session["oid"] = order.Order_id;
            return RedirectToAction("CheckOut");
        }

        public ActionResult CheckOut()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(Payment payment)
        {
            int amt = Convert.ToInt32(Session["amount"]);
            int cuid = Convert.ToInt32(Session["cid"]);
            int orid = Convert.ToInt32(Session["oid"]);
            payment.Amount = amt;
            payment.Customer_id = cuid;
            payment.Order_id = orid;
            db.PaymentTable.Add(payment);
            db.SaveChanges();
            return RedirectToAction("Success");
        }

        public ActionResult Cancel()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cancel(CancelOrder corder)
        {
            int amt = Convert.ToInt32(Session["amount"]);
            int orid = Convert.ToInt32(Session["oid"]);
            corder.Total = amt;
            corder.Order_id = orid;
            db.CancelTable.Add(corder);
            db.SaveChanges();
            return RedirectToAction("Message");
        }

        public ActionResult Success()
        {
            Session.Abandon();
            return View();
        }

        public ActionResult Message()
        {
            Session.Abandon();
            return View();
        }
    }
}