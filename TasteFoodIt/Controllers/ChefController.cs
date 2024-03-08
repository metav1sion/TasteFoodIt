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
    public class ChefController : Controller
    {
        private TasteContext db = new TasteContext();

        // GET: Chef
        public ActionResult ChefList()
        {
            var values = db.Chefs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddChef(Chef c, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), fileName);
                file.SaveAs(path);

                c.ImageUrl = "/img/" + fileName;
            }
            db.Chefs.Add(c);
            db.SaveChanges();
            return RedirectToAction("ChefList");
        }

        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var values = db.Chefs.FirstOrDefault(x => x.ChefId == id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateChef(Chef c, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/img"), fileName);
                file.SaveAs(path);

                c.ImageUrl = "/img/" + fileName;
            }

            var value = db.Chefs.FirstOrDefault(x=>x.ChefId == c.ChefId);
            value.Title = c.Title;
            value.Description = c.Description;
            value.ImageUrl = c.ImageUrl;
            value.NameSurname = c.NameSurname;
            db.SaveChanges();
            return RedirectToAction("ChefList");
        }

        public ActionResult DeleteChef(int id)
        {
            var chef = db.Chefs.FirstOrDefault(x=>x.ChefId == id);
            db.Chefs.Remove(chef);
            db.SaveChanges();
            return RedirectToAction("ChefList");
        }

    }
}