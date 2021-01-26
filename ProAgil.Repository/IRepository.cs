using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProAgil.Repository
{

    //public interface IRepository<T>
    public interface IRepository<T>
    {       
        
        // GERAL        
        IQueryable<T> Get();
        Task<T> GetById(Expression<Func<T, bool>> predicate);        
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveChangeAsync();
        
        // void Add<T>(T entity) where T : class;    
        // void Update<T>(T entity) where T : class;    
        // void Delete<T>(T entity) where T : class;   

    }
}