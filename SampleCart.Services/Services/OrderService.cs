using SampleCart.Domain.Models;
using SampleCart.Services.CustomException;
using SampleCart.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCart.Services.Services
{
    public class OrderService : IOrderService
    {
        public async Task SaveOrder(PlacedOrder placedOrder)
        {
            if (placedOrder?.Items == null)
            {
                throw new InvalidPlacedOrderException();
            }
            
            //Repository layer will call Save method -> Save
            //Not implemented -> API layer will return 200 OK response if no exception caught && user will be redirected to thank you page
        }

        public async Task<decimal> GetShippingCost(PlacedOrder placedOrder)
        {
            if (placedOrder?.Items == null)
            {
                throw new InvalidOrderException(placedOrder.OrderID.ToString());
            }

            return placedOrder.TotalPrice < 50 ? 10 : 20;
        }
    }
}
