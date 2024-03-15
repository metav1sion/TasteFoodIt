using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class AdminProfileController : Controller
    {
        // GET: AdminProfile

        TasteContext context = new TasteContext();

        [Authorize]
        public ActionResult Index(int id)
        {
            var value = context.Admins.Find(id);
            return View(value);
        }
    }
}