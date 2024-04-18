using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminTestimonialController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult TestimonialList()
        {
            ViewBag.name = "Referanslar";
            var value = context.Testimonials.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial referans) {
            referans.ImageUrl = "/Templates/tasteit-master/images/" + referans.ImageUrl;
            context.Testimonials.Add(referans);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            context.Testimonials.Remove(values);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");

        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var values = context.Testimonials.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial( Testimonial referans)
        {
            var value = context.Testimonials.Find(referans.TestimonialId);
            value.NameSurname = referans.NameSurname;
            value.Title = referans.Title;
            if (referans.ImageUrl != null)
            {
                value.ImageUrl = "/Templates/tasteit-master/images/" + referans.ImageUrl;
            }
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}