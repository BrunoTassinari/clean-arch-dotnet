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
    public class CategoryRepository : IBaseRepository<Category>
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
            
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int? id)
        {
            Category category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return null;
            }

            return category;
        }

        public async Task<Category> Remove(Category entity)
        {
           _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Category> Update(Category entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
    }
}
