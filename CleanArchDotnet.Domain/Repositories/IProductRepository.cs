using CleanArchDotnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchDotnet.Domain.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
       Task<Product> GetByCategoryAsync(int id);
    }
}