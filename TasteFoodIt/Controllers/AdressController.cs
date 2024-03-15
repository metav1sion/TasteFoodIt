using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdressController : Controller
    {
        // GET: Adress
        private TasteContext ctx = new TasteContext();

        [Authorize]
        [HttpGet]
        public ActionResult Index(int id)
        {
            var values = ctx.Adresses.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(Adress a)
        {
            var value = ctx.Adresses.Find(a.AdressId);
            value.Description = a.Description;
            value.Email = a.Email;
            value.Phone = a.Phone;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}