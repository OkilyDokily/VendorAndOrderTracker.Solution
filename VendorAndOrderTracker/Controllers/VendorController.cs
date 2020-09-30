using Microsoft.AspNetCore.Mvc;
using VendorAndOrderTracker.Models;
using System.Collections.Generic;
using System;

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

        [HttpGet("/Vendor/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Vendor vendor = Vendor.vendors[id];
            return View(vendor);
        }

        [HttpPost("/Vendor/{id}/update")]
        public ActionResult Update(string name, string description,int id)
        {
            Vendor vendor = Vendor.vendors[id];
            vendor.Name =name;
            vendor.Description = description;
            return RedirectToAction("Index");
        }

        [HttpPost("/Vendor/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Vendor.vendors.RemoveAt(id);
            return RedirectToAction("Index");
        }

        
        [HttpPost("/Vendor/delete")]
        public ActionResult DeleteAll(int id)
        {
            Vendor.vendors = new List<Vendor>();
            return RedirectToAction("Index");
        }

        [HttpGet("/Vendor/new")]
        public ActionResult New()
        { 
            return View();
        }

        [HttpPost("/Vendor/new")]
        public ActionResult Create(string name, string description)
        { 
            new Vendor(name, description);
            return RedirectToAction("Index");
        }
    }
}