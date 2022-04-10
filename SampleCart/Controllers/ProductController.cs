using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleCart.Domain.Models;
using SampleCart.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleCart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _productService.GetProducts();
            return products;
        }
    }
}
