using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorAndOrderTracker.Models;
using System.Linq;


namespace VendorAndOrderTracker.Controllers
{
    public class OrderController : Controller
    {
      
        [HttpGet("/Vendor/{id}/Order/")]
        public ActionResult Index(int id)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            return View(vendor);
        }

        [HttpGet("/Vendor/{id}/Order/new")]
        public ActionResult New(int id)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            return View(vendor);
        }

        [HttpPost("/Vendor/{id}/Order/")]
        public ActionResult Create(string title, string description, double price, int id)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            new Order(title, description, price, vendor);
            return RedirectToAction("Index");
        }

        [HttpPost("/Vendor/{id}/Order/delete")]
        public ActionResult DestroyAll(int id)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            vendor.Orders = new List<Order>();
            return RedirectToAction("Index");
        }


        [HttpGet("/Vendor/{id}/Order/{num}")]
        public ActionResult Show(int id, int num)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            Order order = vendor.Orders.Find(x=>x.Id == num);
            return View(order);
        }

        [HttpGet("/Vendor/{id}/Order/{num}/edit")]
        public ActionResult Edit(int id, int num)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            Order order = vendor.Orders.Find(x=>x.Id == num);
            return View(order);
        }

        [HttpPost("/Vendor/{id}/Order/{num}/")]
        public ActionResult Update(string title, string description, double price, int id, int num)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            Order order = vendor.Orders.Find(x=>x.Id == num);

            order.Title = title;
            order.Description = description;
            order.Price = price;
            return RedirectToAction("Index");
        }

        [HttpPost("/Vendor/{id}/Order/{num}/delete")]
        public ActionResult Destroy(int id, int num)
        {
            Vendor vendor = Vendor.vendors.Find(x=>x.Id == id);
            vendor.Orders.Remove(vendor.Orders.Single(x=>x.Id == num));
            return RedirectToAction("Index");
        }    
    }
}