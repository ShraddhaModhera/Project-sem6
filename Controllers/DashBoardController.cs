using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class DashBoardController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List()
        {
            return View(db.ProductTable.OrderByDescending(d => d.Product_id).Take(4).ToList());
        }

    }
}