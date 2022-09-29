using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _appDbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {

            return await _dbSet.FindAsync(id);


            //var entity = await _dbSet.FindAsync(id);
            //if (entity != null)
            //{
            //    _appDbContext.Entry(entity).State = EntityState.Detached;
            //    return null;
            //}
            //return entity;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            //_appDbContext.Entry(entity).State = EntityState.Modified;
             _dbSet.Update(entity);
          
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
         {
             return _dbSet.Where(expression);
        }
    }
}
