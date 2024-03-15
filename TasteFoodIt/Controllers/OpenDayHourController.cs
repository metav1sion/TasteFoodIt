using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class OpenDayHourController : Controller
    {
        // GET: OpenDayHour
        private TasteContext ctx = new TasteContext();
        [Authorize]
        public ActionResult OpenDayHourList()
        {
            var values = ctx.OpenDayHours.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateOpenDayHour(int id)
        {
            var values = ctx.OpenDayHours.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateOpenDayHour(OpenDayHour o)
        {
            var values = ctx.OpenDayHours.Find(o.OpenDayHourId);
            values.OpenHourRange = o.OpenHourRange;
            ctx.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }
    }
}