using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;


namespace TasteFoodIt.Controllers
{
    public class DashboardController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            ViewBag.v1 = context.Categories.Count();
            ViewBag.v2 = context.Products.Count();
            ViewBag.v3 = context.Chefs.Count();
            ViewBag.v4 = context.Reservations.Where(x => x.ReservationStatus == "Aktif").Count();
            return View();
        }
       public PartialViewResult js()
        {
            return PartialView();
        }
        public PartialViewResult Chart()
        {
            var value = context.Products.ToList();
            return PartialView(value);
        }
        public PartialViewResult ProgressBar() {
            ViewBag.mesaj = context.Contacts.Count();
            ViewBag.musteri = context.Testimonials.Count();
            ViewBag.social = context.SocialMedias.Count();
            ViewBag.productprice = Convert.ToInt32(context.Products.Max(x => x.Price));
            return PartialView();
        }
        public PartialViewResult Rezervasyon()
        {
            var value = context.Reservations.Take(5).ToList();
            return PartialView(value);

        }
        public PartialViewResult Mesajlar() { 
          var value = context.Contacts.Take(5).ToList();
            return PartialView(value);  
        }

    }
}