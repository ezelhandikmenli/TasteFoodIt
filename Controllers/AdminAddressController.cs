using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminAddressController : Controller
    {
        TasteContext context = new TasteContext();
        public ActionResult AddressList()
        {
            ViewBag.Name = "Address";
            var values = context.Addresses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAddress() {
            ViewBag.name = "Adres";
           return View();   
        }
        [HttpPost]
        public ActionResult CreateAddress( Address address)
        {
            ViewBag.name = "Address";
            context.Addresses.Add(address);
            context.SaveChanges();
            return RedirectToAction("AddressList");

        }
        public ActionResult DeleteAddress(int id)
        {
            ViewBag.name = " Address";
            var value = context.Addresses.Find(id);
            context.Addresses.Remove(value);
            return RedirectToAction("AddressList");

        }
        [HttpGet]
        public ActionResult UpdateAddress(int id) {
            ViewBag.name = "Address";
            var value = context.Addresses.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAddress(Address adres)
        {
            var value = context.Addresses.Find(adres);
            value.Email = adres.Email;  
            value.Phone = adres.Phone;
            value.Description = adres.Description;
            context.SaveChanges();
            return RedirectToAction("AddressList");
        }
    }
}