using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorAndOrderTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorAndOrderTrackerTests.ModelsTests
{
    [TestClass]
    public class OrderTests : IDisposable
    {
        
        public void Dispose()
        {
             Vendor.vendors = new List<Vendor>();
             Vendor.CurrentID = 0;
    
        }

        [TestMethod]
        public void OrderConstructor_EnsureConstructorCreatesCorrectObjects_ReturnTrue()
        {
            Vendor vendor = new Vendor("Good Will","One mans's trash is another mans treasure.");
            Order order = new Order("Used book", "A cheap investment with a high return",.25,vendor);

            Assert.AreEqual("Used book", order.Title);
            Assert.AreEqual("A cheap investment with a high return",order.Description);
            Assert.AreEqual(.25,order.Price);
            Assert.AreEqual(true, order.Date != null);

            Assert.AreEqual(1, vendor.Orders.Count);
        }
    }
}