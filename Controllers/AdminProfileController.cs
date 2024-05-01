using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminProfileController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: AdminProfile
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.name = "Profil";
            ViewBag.v = Session["name"];

            var value = context.Admins.Find(Session["id"]);
            return View(value);

        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var value = context.Admins.Find(admin.AdminId);
            value.UserName = admin.UserName;
            value.Name = admin.Name;
            value.Password = admin.Password;
            value.Email = admin.Email;
            value.PhoneNumber = admin.PhoneNumber;
            value.Password = admin.Password;
            if (admin.ImageUrl != null)
            {
                value.ImageUrl = "/Templates/ruang-admin/img/" + admin.ImageUrl;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "AdminProfile");

        }
    }
}