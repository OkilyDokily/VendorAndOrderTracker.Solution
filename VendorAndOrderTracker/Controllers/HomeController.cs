using Microsoft.AspNetCore.Mvc;

namespace VendorAndOrderTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

          public ActionResult Search()
        {
            return View();
        }
    }
}