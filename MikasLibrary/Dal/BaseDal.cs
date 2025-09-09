using Microsoft.EntityFrameworkCore;
using MikasLibrary.Interfaces;
using MikasLibrary.Utils;

namespace MikasLibrary.Dal
{
    public abstract class BaseDal<T> : IBaseDal<T> where T : class
    {
        protected readonly LibraryDBContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseDal(LibraryDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
