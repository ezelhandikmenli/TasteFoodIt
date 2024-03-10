using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;
namespace TasteFoodIt.Controllers
{
    public class ServicesMenuController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult MenuList()
        {
            var value = context.Products.ToList();
            return View(value);
        }
        [HttpGet]
        public PartialViewResult ReservationMenu()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ReservationMenu(Reservation p)
        {
            var value = context.Reservations.Add(p);
            return PartialView(value);
        }
    }
}