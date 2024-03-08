using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class AboutController : Controller
    {
        TasteContext db = new TasteContext();
        // GET: About
        public ActionResult AboutList()
        {
            var valus = db.Abouts.ToList();
            return View(valus);
        }
    }
}