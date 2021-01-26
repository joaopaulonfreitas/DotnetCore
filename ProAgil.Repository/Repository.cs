using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.Repository
{

    
    //public class Repository<T> : IRepository<T> where T : class
    public class Repository<T> : IRepository<T> where T: class
    {

         #region Get Context

        public readonly ProAgilContext _context;

        public Repository(ProAgilContext context)
        {
            _context = context;
            // Removendo Trackeamento para não travar EF
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #endregion

        public void Add(T entity)
        {
             _context.Add(entity);
        }

        public void Update(T entity)
        {
             _context.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Update(entity);
        }
        
        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }
      
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}