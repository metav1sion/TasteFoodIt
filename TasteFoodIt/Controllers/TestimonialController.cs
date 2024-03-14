using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        private TasteContext ctx = new TasteContext();
        public ActionResult TestimonialList()
        {
            var values = ctx.Testimonials.ToList();
            return View(values);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = ctx.Testimonials.Find(id);
            ctx.Testimonials.Remove(value);
            ctx.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = ctx.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial t)
        {
            var value = ctx.Testimonials.Find(t.TestimonialId);
            value.Description = t.Description;
            value.Title = t.Title;
            value.NameSurname = t.NameSurname;
            value.ImageUrl = t.ImageUrl;
            ctx.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial t)
        {
            var value = ctx.Testimonials.Add(t);
            ctx.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}