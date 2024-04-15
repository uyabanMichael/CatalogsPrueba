using Catalogos.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalogos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CatalogContext _context;

        public Repository(CatalogContext context)
        {
            _context = context;
        }

        protected DbSet<T> EntitySet => _context.Set<T>();

        public async Task AddItem(T entity)
        {
            await EntitySet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }   

        public async Task RemoveItem(T entity)
        {
            EntitySet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> SelectByKey(object ValueKey)
        {
            return await EntitySet.FindAsync(ValueKey);
        }

        public async Task UpdateItem(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> SelectByValues(Expression<Func<T, bool>> expr)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expr);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
