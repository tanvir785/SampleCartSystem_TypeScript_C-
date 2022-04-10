using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleCart.Domain.Models;
using SampleCart.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleCart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("SaveOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] PlacedOrder order)
        {
            await _orderService.SaveOrder(order);
            return Ok();
        }

        [HttpPut]
        [Route("CalculateShippingCost")]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<decimal> CalculateShippingCost([FromBody] PlacedOrder placedOrder)
        {
            var shippingCost = await _orderService.GetShippingCost(placedOrder);
            return shippingCost;
        }
    }
}
