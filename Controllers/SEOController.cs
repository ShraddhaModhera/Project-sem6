using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class SEOController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List()
        {
            List<Setting> setting = db.SettingTable.ToList();
            return View(setting.Find(p => p.Settings_id == 1));
        }
    }
}