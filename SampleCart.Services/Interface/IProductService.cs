using SampleCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleCart.Services.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
