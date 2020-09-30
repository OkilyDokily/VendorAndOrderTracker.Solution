using System.Collections.Generic;

namespace VendorAndOrderTracker.Models
{
    public class Vendor
    {
        public static List<Vendor> vendors = new List<Vendor>();

       public string Name {get; set;}
       public string Description {get;set;}
       
       public List<Order> Orders {get;set;}
       public Vendor(string name, string description)
       {
           Orders = new List<Order>();
           Name = name;
           Description = description;
           vendors.Add(this);
       }

       public List<Order> SearchOrders(int query)
       {
           List<Order> orderResults = new List<Order>();
           Orders.ForEach((order) => 
           {
               if(order.Description.Contains(query))
               {
                   
               }
           });

           return orderResults;
       }

    }
}