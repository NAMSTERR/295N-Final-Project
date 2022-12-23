using System;
using ShipmentTrackingSite.Data;
using ShipmentTrackingSite.Models;

namespace ShipmentSiteTest
{
    public class FakeRepo : IOrderRepository
    {
        private List<Order> orders = new List<Order>();

        public IQueryable<Order> Orders { get { return orders.AsQueryable(); } }

        public Order AddToDb(Order addIt)
        {
            addIt.OrderId = orders.Count;
            orders.Add(addIt);
            return addIt;
        }
    }
}

