using Microsoft.AspNetCore.Mvc;
using VendorAndOrderTracker.Models;


namespace VendorAndOrderTracker.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/Vendor/{id}/index")]
        public ActionResult Index(int id)
        {
            Vendor vendor = Vendor.vendors[id];
            return View(vendor);
        }


        [HttpGet("/Vendor/{id}/Order/new")]
        public ActionResult New(int id)
        {
            //Vendor vendor = Vendor.vendors[id];
            return View(id);
        }

        [HttpPost("/Vendor/{id}/Order/new")]
        public ActionResult Create(string title, string description, double price, int id)
        {
            Vendor vendor = Vendor.vendors[id];
            new Order(title, description, price, vendor);
            return RedirectToAction("Index");
        }

        
    }
}