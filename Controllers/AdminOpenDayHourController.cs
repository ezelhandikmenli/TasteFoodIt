using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminOpenDayHourController : Controller
    {
        TasteContext context = new TasteContext();
      
        public ActionResult OpenDayHourList()
        {
            ViewBag.name = "Açık Saatler";
            var value = context.OpenDayHours.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateOpenDayHour()
        {
            List<string> Days = context.OpenDayHours.Select(x => x.DayName).ToList();

            List<SelectListItem> allDays = new List<SelectListItem>()
            {
                new SelectListItem {Text="Pazartesi",Value="Pazartesi"},
                new SelectListItem {Text="Salı",Value="Salı"},
                new SelectListItem {Text="Çarşamba",Value="Çarşamba"},
                new SelectListItem {Text="Perşembe",Value="Perşembe"},
                new SelectListItem {Text="Cuma",Value="Cuma"},
                new SelectListItem {Text="Cumartesi",Value="Cumartesi"},
                new SelectListItem {Text="Pazar",Value="Pazar"}
            };

            foreach (var item in Days)
            {
                var itemRemove = allDays.FirstOrDefault(x => x.Text == item);
                if (itemRemove != null) 
                {
                    allDays.Remove(itemRemove);
                }
            }
            ViewBag.AllDays = allDays;
            ViewBag.name = "Açık Saatler";
            return View();
        }
        [HttpPost]
        public ActionResult CreateOpenDayHour(OpenDayHour openDayHour)
        {
            context.OpenDayHours.Add(openDayHour);
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }

        [HttpGet]
        public ActionResult UpdateOpenDayHour(int id)
        {
            ViewBag.name = "Açık Saatler";
            var value = context.OpenDayHours.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateOpenDayHour(OpenDayHour openDayHour)
        {
            var value = context.OpenDayHours.Find(openDayHour.OpenDayHourId);
            value.DayName = openDayHour.DayName;
            value.OpenHourRange = openDayHour.OpenHourRange;
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }

        public ActionResult DeleteOpenDayHour(int id)
        {
            var value = context.OpenDayHours.Find(id);
            context.OpenDayHours.Remove(value);
            context.SaveChanges();
            return RedirectToAction("OpenDayHourList");
        }
    }
}