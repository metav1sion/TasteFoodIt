using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

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

	        return PartialView();
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
	        return PartialView();
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
	        return PartialView();
        }
	}
}