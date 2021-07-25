using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class RateController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching)
        {
            return View(db.RateTable.Where(x => x.Product.Name.Contains(searching) || searching == null).ToList());
        }

    }
}