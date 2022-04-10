using System;
using System.Collections.Generic;
using System.Text;

namespace SampleCart.Services.CustomException
{
    public class InvalidPlacedOrderException : ApplicationException
    {
        public InvalidPlacedOrderException() : base("Placed Order is invalid")
        {

        }
    }
    public class InvalidOrderException : ApplicationException
    {
        public InvalidOrderException(string order) : base($"Order {order} is invalid")
        {

        }
    }
}
