using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private TasteContext context = new TasteContext();
        public ActionResult AdminList()
        {
            var values = context.Admins.ToList();
            return View(values);
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = context.Admins.Find(id);
            context.Admins.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin()
        {
            return View();
        }
    }
}