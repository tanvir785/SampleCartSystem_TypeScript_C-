using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SampleCart.Domain.Models
{
    public class PlacedOrder
    {
        [JsonIgnore]
        public Guid OrderID { get; set; } = Guid.NewGuid();
        public IEnumerable<Order> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingCost { get;set; }
    }
}
