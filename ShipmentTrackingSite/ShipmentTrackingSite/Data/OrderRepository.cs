using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShipmentTrackingSite.Models;

namespace ShipmentTrackingSite.Data
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;
        public OrderRepository(ApplicationDbContext aDbC)
        {
            context = aDbC;
        }

        public IQueryable<Order> Orders
        {
            get
            {
                return context.Orders;
            }
        }

        //public Order AddOrder()
        //{
        //    throw new NotImplementedException();
        //}

        public Order AddToDb(Order addIt)
        {
            context.Orders.Add(addIt);
            context.SaveChanges();

            return addIt;
        }
    }
}

