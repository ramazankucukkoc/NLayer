using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<TEntity,TDto> where TEntity : class where TDto : class
    {
        Task<CustomResponseDto<TDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync();
        Task<CustomResponseDto< IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<CustomResponseDto<TDto>> AddAsync(TDto entity);
        Task<CustomResponseDto<IEnumerable<TDto>>>AddRangeAsync(IEnumerable<TDto> entities);
        Task UpdateAsync(TEntity entity);
        //Task<CustomResponseDto<NoContentDto>> UpdateAsync(TDto entity, int id);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id);
        //Task<CustomResponseDto<List<NoContentDto>>> UpdateAsync(TDto entity);
        //Task RemoveAsync(TEntity entity);
        Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<TDto> entities);


    }
}
