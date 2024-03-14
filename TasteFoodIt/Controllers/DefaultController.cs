using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class DefaultController : Controller
    {
	    private TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
	        return PartialView();
        }
        public PartialViewResult PartialScript()
        {
	        return PartialView();
        }
        public PartialViewResult PartialNavbarInfo()
        {
	        ViewBag.phone = context.Adresses.Select(x => x.Phone).FirstOrDefault();
	        ViewBag.email = context.Adresses.Select(x => x.Email).FirstOrDefault();
	        ViewBag.description = context.Adresses.Select(x => x.Description).FirstOrDefault();

	        return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
	        return PartialView();
        }
        public PartialViewResult PartialSlider()
        {
            var values = context.Sliders.ToList();
	        return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Abouts.Select(x=>x.Title).FirstOrDefault();
            ViewBag.description = context.Abouts.Select(x=>x.Description).FirstOrDefault();
            ViewBag.url = context.Abouts.Select(x=>x.ImgUrl).FirstOrDefault();
	        return PartialView();
        }
        public PartialViewResult PartialMenu()
        {
	        var values = context.Products.ToList();
	        return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var value = context.Testimonials.ToList();
	        return PartialView(value);
        }
        public PartialViewResult PartialChef()
        {
            var values = context.Chefs.ToList();
	        return PartialView(values);
        }

        public PartialViewResult PartialDescription()
        {
	        return PartialView();
        }

        public PartialViewResult PartialSlogan()
        {
	        return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            var values = context.OpenDayHours.ToList();
	        return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialReservation(Reservation P)
        {
            P.ReservationStatus = "false";
            P.GuestCount = (byte)P.GuestCount;
            context.Reservations.Add(P);
            Notification val = new Notification();
            val.Date = DateTime.Now;
            val.Description = P.Name + " isimli müşteri" + P.ReservationDate.ToString("MMMM, dd, yyyy") + " " + P.ReservationTime + " tarihine rezevasyon yapmıştır.";
            context.Notifications.Add(val);
            context.SaveChanges();
            return PartialView("PartialReservation");
        }
    }
}