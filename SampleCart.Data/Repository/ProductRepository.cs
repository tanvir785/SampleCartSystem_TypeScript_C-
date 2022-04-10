using SampleCart.Data.Interface;
using SampleCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleCart.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private const string sampleDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        public async Task<IEnumerable<Product>> Get()
        {
            var products = await SampleData();
            return products;
        }

        public async Task<IEnumerable<Product>> SampleData()
        {
            return new List<Product>()
            {
                new Product() { ProductID = Guid.NewGuid(), Title = "Sample Product 1", Description = sampleDescription, Price = 20.5m },
                new Product() { ProductID = Guid.NewGuid(), Title = "Sample Product 2", Description = sampleDescription, Price = 21.55m },
                new Product() { ProductID = Guid.NewGuid(), Title = "Sample Product 3", Description = sampleDescription, Price = 25 },
                new Product() { ProductID = Guid.NewGuid(), Title = "Sample Product 4", Description = sampleDescription, Price = 40.45m},
                new Product() { ProductID = Guid.NewGuid(), Title = "Sample Product 5", Description = sampleDescription, Price = 30 }
            };
        }

    }
}
