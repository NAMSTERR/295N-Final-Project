using Xunit;
using System;
using ShipmentTrackingSite.Models;
using ShipmentTrackingSite.Data;
using ShipmentTrackingSite.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ShipmentSiteTest
{
    public class HomeControllerTests
    {
        IOrderRepository repo = new FakeRepo();
        HomeController cont;
        Order order;

        public HomeControllerTests()
        {
            order = new Order();
            order.Carrier = "Fedex";
            order.Cost = 12.99m;
            order.OrderId = 55;
            order.DeliveryDate = DateTime.Parse("01/25/2023");
            order.Description = "Phone case";
            order.OrderedFrom = "Ebay";
            order.OrderPlacedDate = DateTime.Parse("12/20/2022");
            order.ShipmentFee = 5.99m;

            cont = new HomeController(null, repo);
        }

        [Fact]
        public void TestAdd()
        {
            var add = cont.Add(order);
            Assert.True(add.GetType() == typeof(RedirectToActionResult));
        }

        [Fact]
        public void TestIndex()
        {
            var index = cont.Index("UPS", "Macys");
            Assert.True(index.GetType() == typeof(ViewResult));
        }
    }
}