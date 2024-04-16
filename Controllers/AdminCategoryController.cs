using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminCategoryController : Controller
    {
     TasteContext context = new TasteContext();
        public ActionResult CategoryList()
        {
            ViewBag.name = "Kategori";
            var value = context.Categories.ToList();
            return View(value);
        }
        public ActionResult CategoryDelete(int id) {
            ViewBag.name = "Kategori";
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Categorylist");
        }
        [HttpGet]
        public ActionResult CategoryCreate() {
            ViewBag.name = "Kategori";
            return View();
        }
        [HttpPost]
        public ActionResult CategoryCreate( Category kategori) {
            ViewBag.name = "Kategori";
            context.Categories.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public  ActionResult UpdateCategory(int id)
        {
            ViewBag.name = "Kategori";
            var value = context.Categories.Find(id);
            return View(value); 
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList");
        }

    }
}