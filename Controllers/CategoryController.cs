using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using EcommerceProject.Models;

namespace EcommerceProject.Controllers
{
    public class CategoryController : Controller
    {
        AdminContext db = new AdminContext();
        public ActionResult List(string searching,int? i)
        {
            return View(db.CategoryTable.Where(x => x.Name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1,3));
        }

        public ActionResult Create()
        {
            Category category = new Category();
            category.StatusSelect = db.StatusTable.ToList<Status>();
            return View(category);
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {           
            string filename = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
            string ex = Path.GetExtension(category.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmss") + ex;
            category.Image = "~/Pics/" + filename;
            filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
            category.ImageFile.SaveAs(filename);

            db.CategoryTable.Add(category);
            db.SaveChanges();           
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Category category = db.CategoryTable.Find(id);
            TempData["imgPath"] = category.Image;
            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            category.StatusSelect = db.StatusTable.ToList<Status>();
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category,HttpPostedFileBase ImageFile)
        {
            if(ImageFile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(category.ImageFile.FileName);
                string ex = Path.GetExtension(category.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmss") + ex;
                category.Image = "~/Pics/" + filename;
                filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
                category.ImageFile.SaveAs(filename);

                db.Entry(category).State = EntityState.Modified;
                string oldImgPath = Request.MapPath(TempData["imgPath"].ToString());
                if(System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
                db.SaveChanges();
                return RedirectToAction("List");

            }
            else
            {
                category.Image = TempData["imgPath"].ToString();
                db.Entry(category).State = EntityState.Modified;
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
            Category category = db.CategoryTable.Find(id);
            if (category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Category category = db.CategoryTable.Find(id);
            string curImgPath = Request.MapPath(category.Image);            
            db.CategoryTable.Remove(category);
            if (System.IO.File.Exists(curImgPath))
            {
                System.IO.File.Delete(curImgPath);
            }
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}