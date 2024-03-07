using System;
using System.Collections.Generic;
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
        public ActionResult AddChef(Chef c)
        {
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
        public ActionResult UpdateChef(Chef c)
        {
            db.Chefs.Add(c);
            db.SaveChanges();
            return RedirectToAction("ChefList");
        }

        public ActionResult DeleteChef(int id)
        {
            var chef = db.Chefs.FirstOrDefault(x=>x.ChefId == id);
            db.Chefs.Remove(chef);
            return RedirectToAction("ChefList");
        }

    }
}