using SampleCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleCart.Services.Interface
{
    public interface IOrderService
    {
        Task SaveOrder(PlacedOrder placedOrder);
        Task<decimal> GetShippingCost(PlacedOrder placedOrder);
    }
}
