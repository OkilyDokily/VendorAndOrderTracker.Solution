using Microsoft.AspNetCore.Mvc;
using VendorAndOrderTracker.Models;
namespace VendorAndOrderTracker.Controllers
{
    public class VendorController : Controller
    {
        [HttpGet("/Vendor")]
        public ActionResult Index()
        { 
            return View(Vendor.vendors);
        }

        [HttpGet("/Vendor/{id}")]
        public ActionResult Show(int id)
        {
            Vendor vendor = Vendor.vendors[id];
            return View(vendor);
        }

        [HttpGet("Vendor/new")]
        public ActionResult New()
        { 
            return View();
        }

        [HttpPost("Vendor/new")]
        public ActionResult Create(string name, string description)
        { 
            new Vendor(name, description);
            return RedirectToAction();
        }
    }
}