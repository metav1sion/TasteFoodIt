using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class DashboardController : Controller
    {
        private TasteContext db = new TasteContext(); 
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.v1 = db.Categories.Count();
            ViewBag.v2 = db.Products.Count();
            ViewBag.v3 = db.Chefs.Count();
            ViewBag.v4 = db.Reservations.Where(x=>x.ReservationStatus=="Aktif").Count();
            return View();
        }
    }
}