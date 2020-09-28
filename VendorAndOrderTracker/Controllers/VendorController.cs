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