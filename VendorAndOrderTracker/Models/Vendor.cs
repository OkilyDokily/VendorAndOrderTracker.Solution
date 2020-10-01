using System.Collections.Generic;
using System.Linq;
namespace VendorAndOrderTracker.Models
{
    public class Vendor
    {
        public static List<Vendor> vendors = new List<Vendor>();
        public static int CurrentID{get;set;}
       public string Name {get; set;}
       public string Description {get;set;}
       public int Id {get;set;}
       
       public List<Order> Orders {get;set;}
       public Vendor(string name, string description)
       {   
           Id = CurrentID;
           Orders = new List<Order>();
           Name = name;
           Description = description;
           vendors.Add(this);
           CurrentID++;
       }


       public static Dictionary<Vendor,List<Order>> SearchOrders(string query)
       {
           
           var matches = new Dictionary<Vendor,List<Order>>();
           vendors.ForEach((vendor) => 
           {
               Dictionary<Order,int> d = new Dictionary<Order,int>(); 
               vendor.Orders.ForEach((order) =>{
                   if(order.Description.Contains(query))
                   {

                       try
                       {
                        var match = matches[vendor];
                        matches[vendor].Add(order);
                       }
                       catch
                       {
                        matches[vendor] = new List<Order>();
                        matches[vendor].Add(order);
                       } 
                   }
               });  
           });

           return matches;
       }

    }
}