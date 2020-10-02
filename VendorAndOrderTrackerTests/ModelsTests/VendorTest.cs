using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorAndOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorAndOrderTrackerTests.ModelsTests
{
  [TestClass]
  public class VendorTest : IDisposable
  {
    public void Dispose()
    {
      Vendor.vendors = new List<Vendor>();
      Vendor.CurrentID = 0;
    }
    [TestMethod]
    public void VendorConstructor_ConstructorCorrectlyCreatesObject_ReturnTrue()
    {
      Vendor vendor = new Vendor("Taco Bell", "A fine food establishment");
      Assert.AreEqual("Taco Bell", vendor.Name);
      Assert.AreEqual("A fine food establishment",vendor.Description);
      Assert.AreEqual(0,vendor.Id);
      Assert.AreEqual(1,Vendor.CurrentID);
      Assert.AreEqual(1,Vendor.vendors.Count);
    }

    [TestMethod]
    public void SearchOrders_EnsureThatSearchListIsCorrect_ReturnTrue()
    {
      Vendor vendor = new Vendor("Taco Bell", "A fine taco establishment");
      new Order("Taco","A crunchy treat with ground beef and lettuce",1.99,vendor);
      new Order("Burrito","A chewy treat with ground beef and red sauce",.99,vendor);
      Vendor vendor2 = new Vendor("Pizza Hut", "A fine pizza establishment");
      new Order("Hamburger Pizza", "A tempting ground beef pizza wonder.", 6.99,vendor2);
      
      Dictionary<Vendor,List<Order>> result = Vendor.SearchOrders("beef");
      Dictionary<Vendor,List<Order>> result2 = Vendor.SearchOrders("treat");

      Assert.AreEqual(2,result.Count);
      Assert.AreEqual(2, result[vendor].Count);
      Assert.AreEqual(1, result[vendor2].Count);

      Assert.AreEqual(1,result2.Count);
      Assert.AreEqual(2,result2[vendor].Count);
    }

  }
}
