using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        private TasteContext ctx = new TasteContext();
        public ActionResult ReservationList()
        {
            var values = ctx.Reservations.ToList();
            return View(values);
        }

        public ActionResult ReservationStatus(string status, int id)
        {
            var values = ctx.Reservations.Find(id);
            values.ReservationStatus = status;
            ctx.SaveChanges();
            return RedirectToAction("ReservationList");
        }

        public ActionResult DeleteReservation(int id)
        {
            var values = ctx.Reservations.Find(id);
            ctx.Reservations.Remove(values);
            ctx.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}