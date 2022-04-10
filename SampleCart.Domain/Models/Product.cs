using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCart.Domain.Models
{
    public class Product
    {
        public Guid ProductID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
