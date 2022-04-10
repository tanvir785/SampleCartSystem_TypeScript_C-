using FluentAssertions;
using Moq;
using SampleCart.Domain.Models;
using SampleCart.Services.Interface;
using SampleCart.Services.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SampleCart.Tests
{
    public class OrderServiceTests
    {

        private PlacedOrder _sourcePlacedOrder;

        public OrderServiceTests()
        {
            _sourcePlacedOrder = new PlacedOrder
            {
                Items = new[]
    {
                    new Order
                    {
                        ProductID = Guid.NewGuid(),
                        Quantity = 100,
                    }
                },
                ShippingCost = 0,
                TotalPrice = 51
            };
        }

        [Fact]
        public async Task AndShippingCostIsHigherForTotalPriceMoreThanFifty()
        {
            var _orderService = new OrderService();

            var shippingCost = await _orderService.GetShippingCost(_sourcePlacedOrder);
            shippingCost.Should().Be(20);
        }

        [Fact]
        public async Task AndShippingCostIsLowerForTotalPriceLessThanFifty()
        {
            _sourcePlacedOrder.TotalPrice = 49;

            var _orderService = new OrderService();

            var shippingCost = await _orderService.GetShippingCost(_sourcePlacedOrder);
            shippingCost.Should().Be(10);
        }
    }
}
