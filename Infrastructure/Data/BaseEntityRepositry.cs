using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BaseEntityRepositry<T> : IBaseEntityRepositry<T> where T : BaseEntity
    {
        private readonly StoreContext _context;
        public BaseEntityRepositry(StoreContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplaySpecification(specification).CountAsync();  
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetEntityWithSpecificatioons(ISpecification<T> specification)
        {
            return await ApplaySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplaySpecification(specification).ToListAsync();
        }
        private IQueryable<T> ApplaySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.getQuery(_context.Set<T>().AsQueryable(), specification);
        }
  
    }
}
