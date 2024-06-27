using CleanArchDotnet.Domain.Entities;
using CleanArchDotnet.Domain.Repositories;
using CleanArchDotnet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchDotnet.Infra.Data.Implementations
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByCategoryAsync(int id)
        {
            Product product = await _context.Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.CategoryId == id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product> GetById(int? id)
        {
            Product product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product> Remove(Product entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> Update(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
