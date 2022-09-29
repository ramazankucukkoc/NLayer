using Core.DTOs;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Service.DtoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto>where TEntity:class where TDto : class
    {   
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _genericRepository;

        public Service(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<CustomResponseDto<TDto>> AddAsync(TDto entity)
        {
         var newEntity=ObjectMapper.Mapper.Map<TEntity>(entity);
         await _genericRepository.AddAsync(newEntity);
         await _unitOfWork.CommitAsync();
         var newDto =ObjectMapper.Mapper.Map<TDto>(newEntity);
            return CustomResponseDto<TDto>.Success(200, newDto);
        }

        public Task<CustomResponseDto<IEnumerable<TDto>>> AddRangeAsync(IEnumerable<TDto> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _genericRepository.AnyAsync(expression);
        }

        public async Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var products = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());
            return CustomResponseDto<IEnumerable<TDto>>.Success( 200, products);
        }

        public async Task<CustomResponseDto<TDto>> GetByIdAsync(int id)
        {
            var product=await _genericRepository.GetByIdAsync(id);
            if (product==null)
            {
                return CustomResponseDto<TDto>.Fail(404, "Id Not Found");
            }
            return CustomResponseDto<TDto>.Success(200,ObjectMapper.Mapper.Map<TDto>(product));

        }
     


        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Id Not Found Ramo");
            }
            _genericRepository.Remove(isExistEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public Task<CustomResponseDto<NoContentDto>> RemoveRangeAsync(IEnumerable<TDto> entities)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _genericRepository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        //public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(TDto entity,int id)
        //{
        //    var isExistEntity = await _genericRepository.GetByIdAsync(id);
        //    if (isExistEntity == null)
        //    {
        //        return CustomResponseDto<NoContentDto>.Fail(404, "Id Not Found Ramazan");
        //    }
        //    var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
        //    _genericRepository.Update(updateEntity);
        //    await _unitOfWork.CommitAsync();
        //    return CustomResponseDto<NoContentDto>.Success(204);

        //}
        public async Task<CustomResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> expression)
        {
            var list=_genericRepository.Where(expression);
            return CustomResponseDto<IEnumerable<TDto>>.Success(200,ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()));
        }
    }
}
