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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        TasteContext context = new TasteContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["username"] = values.UserName;
                Session["id"] = values.AdminId;
                Session["surname"] = values.Surname;
                Session["name"] = values.Name;
                Session["email"] = values.Email;
                Session["tel"] = values.PhoneNumber;
                Session["password"] = values.Password;
                Session["img"] = values.ImageUrl;


                return RedirectToAction("Index", "AdminProfile");
            }
            return View();


        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Index", "Default"); 
        }

    }
}