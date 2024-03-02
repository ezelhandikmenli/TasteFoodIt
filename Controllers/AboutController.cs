using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AboutController : Controller
    {
        TasteContext context = new TasteContext();
        [HttpGet]
        public ActionResult AboutList()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

    }
}