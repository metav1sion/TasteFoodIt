using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class NotificationController : Controller
    {
        private TasteContext ctx = new TasteContext();
        [Authorize]
        public ActionResult NotificationList()
        {
            var values = ctx.Notifications.ToList();
            return View(values);
        }
        public ActionResult NotificationIsReadChangeToTrue(int id)
        {
            var values = ctx.Notifications.Find(id);
            values.IsRead = true;
            ctx.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        public ActionResult NotificationIsReadChangeToFalse(int id)
        {
            var values = ctx.Notifications.Find(id);
            values.IsRead = false;
            ctx.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}