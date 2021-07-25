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
    public class LeadController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.LeadTable.Where(x => x.L_name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

    }
}