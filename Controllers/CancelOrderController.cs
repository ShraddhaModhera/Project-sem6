using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class CancelOrderController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(int? i)
        {
            return View(db.CancelTable.ToList().ToPagedList(i ?? 1, 3));
        }
    }
}