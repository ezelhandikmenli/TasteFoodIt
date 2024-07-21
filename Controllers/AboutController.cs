using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            string PageName = "About";
            TempData["Page"] = PageName;
            return View();
        }
        public PartialViewResult PartialAboutStatistic()
        {
            ViewBag.YemekSayisi = context.Products.Count();
            ViewBag.ChefSayisi = context.Chefs.Count();
            ViewBag.KategoriSayisi = context.Categories.Count();
            ViewBag.ReferansSayisi = context.Testimonials.Count();
            return PartialView();


        }
        [HttpGet]
        public ActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

    }
}