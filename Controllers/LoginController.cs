using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;
namespace TasteFoodIt.Controllers
{
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, true);
                Session["UserName"] = values.UserName;
                Session["adminId"] = values.AdminId;
                Session["name"] = values.Name;
                Session["surname"] = values.Surname;
                Session["imageUrl"] = values.ImageUrl;
                return RedirectToAction("ProfileDetail", "Profile");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}