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
        [Authorize]
        public ActionResult Index()
        {
            
            var count = 0;
            ViewBag.v1 = db.Categories.Count();
            ViewBag.v2 = db.Products.Count();
            ViewBag.v3 = db.Chefs.Count();
            ViewBag.v4 = db.Reservations.Where(x=>x.ReservationStatus=="true").Count();
            ViewBag.v5 = db.Reservations.Where(x=>x.ReservationStatus=="false").Count();
            ViewBag.v6 = db.Reservations.Where(x=>x.ReservationStatus=="pending").Count();
            ViewBag.v7 = db.Testimonials.Count();
            var values = db.Reservations.ToList();
            foreach (var item in values)
            {
                count = count + item.GuestCount + 1;
            }
            ViewBag.v8 = count; //müşteriler
            var val = db.Reservations.ToList();


            return View(val);
        }
    }
}