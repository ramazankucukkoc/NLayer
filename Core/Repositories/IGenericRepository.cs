using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        Task<TEntity> GetByIdAsync(int id);

         Task<IEnumerable<TEntity>> GetAllAsync();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        //Task AddRangeAsync(IEnumerable<TEntity> entities);
       // TEntity Update(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);



    }
}
