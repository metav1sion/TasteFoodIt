using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        private TasteContext ctx = new TasteContext();
        public ActionResult SliderList()
        {
            var values = ctx.Sliders.ToList();
            return View(values);
        }

        public ActionResult DeleteSlider(int id)
        {
            ctx.Sliders.Remove(ctx.Sliders.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public ActionResult AddSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSlider(Slider s)
        {
            ctx.Sliders.Add(s);
            ctx.SaveChanges();
            return RedirectToAction("SliderList");
        }
        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var values = ctx.Sliders.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateSlider(Slider s)
        {
            var value = ctx.Sliders.Find(s.SliderID);
            value.SliderURL = s.SliderURL;
            value.SliderContent = s.SliderContent;
            ctx.SaveChanges();
            return RedirectToAction("SliderList");
        }
    }
}