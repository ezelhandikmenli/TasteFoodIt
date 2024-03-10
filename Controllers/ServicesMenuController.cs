using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;
namespace TasteFoodIt.Controllers
{
    public class ServicesMenuController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult MenuList()
        {
            var value = context.Products.ToList();
            return View(value);
        }
    }
}