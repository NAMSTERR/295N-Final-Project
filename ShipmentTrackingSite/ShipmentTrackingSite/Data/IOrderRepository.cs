using System;
using ShipmentTrackingSite.Models;

namespace ShipmentTrackingSite.Data
{
    public interface IOrderRepository
    {
        //public Review GetReviewById(int id);
        //public int StoreReview(Review model);

        public Order AddOrder();

        public Order AddToDb(Order addIt);
    }
}

