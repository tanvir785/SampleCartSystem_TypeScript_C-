using FluentAssertions;
using Moq;
using SampleCart.Data.Interface;
using SampleCart.Domain.Models;
using SampleCart.Services.Interface;
using SampleCart.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SampleCart.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private IProductService _productService;
        private IList<Product> _products;
        public ProductServiceTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();

            _products = new List<Product>();

            _products.Add(new Product() { ProductID = Guid.NewGuid() });
            _products.Add(new Product() { ProductID = Guid.NewGuid() });

            _mockProductRepository.Setup(x => x.Get()).ReturnsAsync(_products);
            _productService = new ProductService(_mockProductRepository.Object);
        }

        [Fact]
        public async Task AndMultipleProductsAreRetrieved()
        {
            var products = new List<Product>(await _productService.GetProducts());
            products.Count.Should().BeGreaterThan(1);
            products.Should().AllBeOfType<Product>();
            products.Should().OnlyHaveUniqueItems();
        }
    }
}
