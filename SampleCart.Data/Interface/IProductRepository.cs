using SampleCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleCart.Data.Interface
{
    public interface IProductRepository 
    {
        Task<IEnumerable<Product>> Get();
    }
}
