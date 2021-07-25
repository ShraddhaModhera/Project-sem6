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
    public class BrandController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.BrandTable.Where(x => x.Name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 3));
        }

        public ActionResult Create()
        {
            Brand brand = new Brand();
            brand.StatusSelect = db.StatusTable.ToList<Status>();
            return View(brand);
        }

        [HttpPost]
        public ActionResult Create(Brand brand)
        {
            string filename = Path.GetFileNameWithoutExtension(brand.ImageFile.FileName);
            string ex = Path.GetExtension(brand.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmss") + ex;
            brand.Image = "~/Pics/" + filename;
            filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
            brand.ImageFile.SaveAs(filename);

            db.BrandTable.Add(brand);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Brand brand = db.BrandTable.Find(id);
            TempData["imgPath"] = brand.Image;
            if (brand == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            brand.StatusSelect = db.StatusTable.ToList<Status>();
            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(Brand brand, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(brand.ImageFile.FileName);
                string ex = Path.GetExtension(brand.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmss") + ex;
                brand.Image = "~/Pics/" + filename;
                filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
                brand.ImageFile.SaveAs(filename);

                db.Entry(brand).State = EntityState.Modified;
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
                brand.Image = TempData["imgPath"].ToString();
                db.Entry(brand).State = EntityState.Modified;
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
            Brand brand = db.BrandTable.Find(id);
            if (brand == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(brand);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Brand brand = db.BrandTable.Find(id);
            string curImgPath = Request.MapPath(brand.Image);
            db.BrandTable.Remove(brand);
            if (System.IO.File.Exists(curImgPath))
            {
                System.IO.File.Delete(curImgPath);
            }
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}