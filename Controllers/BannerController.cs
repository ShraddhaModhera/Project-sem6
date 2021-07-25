using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class BannerController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.BannerTable.Where(x => x.B_title.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Create()
        {
            Banner banner = new Banner();
            banner.StatusSelect = db.StatusTable.ToList<Status>();
            return View(banner);
        }

        [HttpPost]
        public ActionResult Create(Banner banner)
        {
            string filename = Path.GetFileNameWithoutExtension(banner.ImageFile.FileName);
            string ex = Path.GetExtension(banner.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmss") + ex;
            banner.Image = "~/Pics/" + filename;
            filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
            banner.ImageFile.SaveAs(filename);

            db.BannerTable.Add(banner);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Banner banner = db.BannerTable.Find(id);
            TempData["imgPath"] = banner.Image;
            if (banner == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            banner.StatusSelect = db.StatusTable.ToList<Status>();
            return View(banner);
        }

        [HttpPost]
        public ActionResult Edit(Banner banner, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(banner.ImageFile.FileName);
                string ex = Path.GetExtension(banner.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmss") + ex;
                banner.Image = "~/Pics/" + filename;
                filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
                banner.ImageFile.SaveAs(filename);

                db.Entry(banner).State = EntityState.Modified;
                string oldImgPath = Request.MapPath(TempData["imgPath"].ToString());
                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
                db.SaveChanges();
                return RedirectToAction("List");

            }
            else
            {
                banner.Image = TempData["imgPath"].ToString();
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Banner banner = db.BannerTable.Find(id);
            if (banner == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(banner);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Banner banner = db.BannerTable.Find(id);
            string curImgPath = Request.MapPath(banner.Image);
            db.BannerTable.Remove(banner);
            if (System.IO.File.Exists(curImgPath))
            {
                System.IO.File.Delete(curImgPath);
            }
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}