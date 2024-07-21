using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            var value = context.Sliders.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbarInfo()
        {
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(x => x.Email).FirstOrDefault();
            ViewBag.description = context.Addresses.Select(x => x.Description).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbarInfoSocialMedia()
        {
            var value = context.SocialMedias.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialSlider()
        {
             var values = context.Sliders.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.image = context.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialMenu()
        {
            var values = context.Products.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var value = context.Testimonials.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialChef()
        {
            var value =context.Chefs.ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
      
        public PartialViewResult PartialSocialMedia()
        {
            var values = context.SocialMedias.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialOpenDayHour()
        {
            var values = context.OpenDayHours.ToList(); 
            return PartialView(values);
        }
        public PartialViewResult PartialReservationNow()
        {
            return PartialView();
        }
        public PartialViewResult PartialInfo()
        {
            return PartialView();
        }

    }
}