

using SampleCart.Data.Interface;
using SampleCart.Domain.Models;
using SampleCart.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCart.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.Get();
        }

        public async Task<Product> GetById(Guid Id)
        {
            var products =  new List<Product>(await _productRepository.Get());
            return (Product)products.Select(x => x.ProductID.Equals(Id));
        }
    }
}
