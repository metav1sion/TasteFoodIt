using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class ChefController : Controller
    {
        private TasteContext db = new TasteContext();

        // GET: Chef
        public ActionResult ChefList()
        {
            var values = db.Chefs.ToList();    
            return View(values);
        }
    }
}