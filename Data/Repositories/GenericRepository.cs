using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class GenericRepository<T>
        : IRepository<T> where T : class
    {
        private readonly TranslationWebServiceContext _context;

        public GenericRepository(TranslationWebServiceContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            return (await _context.AddAsync(entity)).Entity;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetAsync(string key)
        {
            return  await _context.FindAsync<T>(key);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }


    }
}
