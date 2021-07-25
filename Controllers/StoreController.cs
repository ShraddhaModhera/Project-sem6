using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class StoreController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List()
        {
            List<Setting> setting = db.SettingTable.ToList();
            return View(setting.Find(p => p.Settings_id == 1));
        }

        public ActionResult Create()
        {
            Setting setting = new Setting();
            setting.StatusSelect = db.StatusTable.ToList<Status>();
            setting.ZoneSelect = db.ZoneTable.ToList<Zone>();
            setting.CountriesSelect = db.CountryTable.ToList<Country>();
            setting.LangSelect = db.LangTable.ToList<Language>();
            setting.CurSelect = db.CurrencyTable.ToList<Currency>();
            setting.OStatusSelect = db.OrderStatusTable.ToList<OrderStatus>();
            return View(setting);
        }

        [HttpPost]
        public ActionResult Create(Setting setting)
        {
            string filename = Path.GetFileNameWithoutExtension(setting.ImageFile.FileName);
            string ex = Path.GetExtension(setting.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmss") + ex;
            setting.Store_logo = "~/Pics/" + filename;
            filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
            setting.ImageFile.SaveAs(filename);

            db.SettingTable.Add(setting);
            db.SaveChanges();
            return RedirectToAction("Create");          
        }

    }
}