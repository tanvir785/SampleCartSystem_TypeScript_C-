using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCart.Domain.Models
{
    public class Order
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
