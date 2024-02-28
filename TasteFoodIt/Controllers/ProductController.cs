using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ProductController : Controller
    {
        TasteContext ctx = new TasteContext();
        // GET: Product
        public ActionResult ProductList()
        {
            //TasteContext context = new TasteContext();
            var values = ctx.Products.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(HttpPostedFileBase file, Product p)
        {
            
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), fileName);
                file.SaveAs(path);

                p.ImageUrl = "/img/" + fileName;
            }

            ctx.Products.Add(p);
            ctx.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult DeleteProduct(int id)
        {
            ctx.Products.Remove(ctx.Products.FirstOrDefault(x=>x.ProductId == id));
            ctx.SaveChanges();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var value = ctx.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(HttpPostedFileBase file, Product p)
        {
            var value = ctx.Products.Find(p.ProductId);

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), fileName);
                file.SaveAs(path);

                p.ImageUrl = "/img/" + fileName;
            }

            value.ProductName = p.ProductName;
            value.ProductDescription = p.ProductDescription;
            value.ImageUrl = p.ImageUrl;
            value.IsActive = p.IsActive;
            value.ProductPrice = p.ProductPrice;
            ctx.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}