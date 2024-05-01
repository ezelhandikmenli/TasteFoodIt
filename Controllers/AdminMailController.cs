using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminMailController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult MailList()
        {
            ViewBag.name = "Gelen Mailler";
            var values = context.Mails.ToList();
            return View(values);
        }
        [HttpPost]
        public JsonResult CreateMail(Mail mail)
        {
            mail.Status = false;
            context.Mails.Add(mail);
            context.SaveChanges();
            return Json(mail, JsonRequestBehavior.AllowGet);
        }
    }
}