using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;
namespace TasteFoodIt.Controllers
{
    public class ServicesChefController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult ChefList()
        {
            var values = context.Chefs.ToList();
            return View(values);    
        }
        [HttpGet]
        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialReservation(Reservation p)
        {
            var value = context.Reservations.Add(p);
              context.SaveChanges();
            return PartialView(value);
        }

            
        ////[HttpGet]
        ////public ActionResult Reservation()
        ////{
        ////    return View();
        ////}
        ////[HttpPost]
        ////public ActionResult Reservation(Chef p)
        ////{
        ////    var value = context.Chefs.Add(p);
        ////    context.SaveChanges();
        ////    return RedirectToAction("ChefList");
        ////}

    }
}