using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TasteFoodIt.Controllers
{
    public class ServicesLayoutController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialServicesDetail()
        {
            ViewBag.Page = TempData["Page"];
            return PartialView();
        }
    }
}