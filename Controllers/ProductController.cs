using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceProject.Models;
using PagedList.Mvc;
using PagedList;

namespace EcommerceProject.Controllers
{
    public class ProductController : Controller
    {
        AdminContext db = new AdminContext();        
        public ActionResult List(string searching,int? i)
        {            
            return View(db.ProductTable.Where(x => x.Name.Contains(searching) || searching == null).ToList().ToPagedList(i ?? 1, 5));            
        }

        public ActionResult Create()
        {
            Product product = new Product();
            product.StatusSelect = db.StatusTable.ToList<Status>();
            product.StockSelect = db.StockTable.ToList<StockStatus>();
            product.ManuSelect = db.ManuTable.ToList<Manufacturer>();
            product.VarSelect = db.VariantTable.ToList<Variant>();
            product.ShipSelect = db.ShipTable.ToList<Shipping>();
            product.CatSelect = db.CategoryTable.ToList<Category>();
            return View(product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {            
            string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string ex = Path.GetExtension(product.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmss") + ex;
            product.Image = "~/Pics/" + filename;
            filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
            product.ImageFile.SaveAs(filename);

            db.ProductTable.Add(product);
            db.SaveChanges();            
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Service ID is Required");
            }
            Product product = db.ProductTable.Find(id);
            TempData["imgPath"] = product.Image;
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Service not found");
            }
            product.StatusSelect = db.StatusTable.ToList<Status>();
            product.StockSelect = db.StockTable.ToList<StockStatus>();
            product.ManuSelect = db.ManuTable.ToList<Manufacturer>();
            product.VarSelect = db.VariantTable.ToList<Variant>();
            product.ShipSelect = db.ShipTable.ToList<Shipping>();
            product.CatSelect = db.CategoryTable.ToList<Category>();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string ex = Path.GetExtension(product.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmss") + ex;
                product.Image = "~/Pics/" + filename;
                filename = Path.Combine(Server.MapPath("~/Pics/"), filename);
                product.ImageFile.SaveAs(filename);

                db.Entry(product).State = EntityState.Modified;
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
                product.Image = TempData["imgPath"].ToString();
                db.Entry(product).State = EntityState.Modified;
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
            Product product = db.ProductTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Services not found");
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product product = db.ProductTable.Find(id);
            string curImgPath = Request.MapPath(product.Image);
            db.ProductTable.Remove(product);
            if (System.IO.File.Exists(curImgPath))
            {
                System.IO.File.Delete(curImgPath);
            }
            db.SaveChanges();
            return RedirectToAction("List");
        }



    }
}