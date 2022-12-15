using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ShipmentTrackingSite.Models
{
    public class Order
    {
        //order.description
        //order.orderedFrom AKA amazon
        //order.carrier AKA Fedex
        //order.orderPlacedDate
        //order.expectedDel
        //order.cost
        //order.shipmentFee
        //orderID

        public int OrderId { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please enter where your order was placed at.")]
        public string? OrderedFrom { get; set; }

        [Required(ErrorMessage = "Please enter your carrier name.")]
        public string? Carrier { get; set; }

        [Required(ErrorMessage = "Please enter the date order was placed.")]
        public DateTime? OrderPlacedDate { get; set; }

        [Required(ErrorMessage = "Please enter a expected delivery date.")]
        public DateTime? DeliveryDate { get; set; }

        [Required(ErrorMessage = "Please enter the cost before any fees.")]
        public Decimal? Cost { get; set; }

        [Required(ErrorMessage = "Please enter the shipment fee.")]
        public Decimal? ShipmentFee { get; set; }

        //public bool? IsNullOrNot()
        //{
        //    if (Description == null || OrderedFrom == null
        //         || Carrier == null || OrderPlacedDate == null
        //         || DeliveryDate == null || Cost == null || ShipmentFee == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}


    }
}

