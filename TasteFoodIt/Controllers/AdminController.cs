using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private TasteContext context = new TasteContext();
        
        [Authorize]
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
        public ActionResult AddAdmin(Admin a)
        {
            context.Admins.Add(a);
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = context.Admins.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin a)
        {
            var value = context.Admins.Find(a.AdminId);
            value.Username = a.Username;
            value.Password = a.Password;
            value.ImgURL = a.ImgURL;
            value.NameSurname = a.NameSurname;
            context.SaveChanges();
            return RedirectToAction("AdminList");
        }
    }
}