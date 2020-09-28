using System.Collections.Generic;
using System;

namespace VendorAndOrderTracker.Models
{
    public class Order
    {
        public string Title {get;set;}
        public string Description {get;set;}

        public double Price {get;set;}

        public DateTime Date {get;set;}

        public Order(string title,string description,double price,Vendor vendor)
        {
            Date = DateTime.Now;
            Title = title;
            Description = description;
            Price = price; 
            vendor.Orders.Add(this);
        }
    }
}