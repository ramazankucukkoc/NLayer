using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Service.DtoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : Service<Category, CategoryDto>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IUnitOfWork unitOfWork, IGenericRepository<Category> genericRepository,ICategoryRepository categoryRepository)
            : base(unitOfWork, genericRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryDto>> GetSingleCategoryWiithProducts(int categoryId)
        {   var category=await _categoryRepository.GetSingleCategoryWithProducts(categoryId);
            var categoryDto=ObjectMapper.Mapper.Map<CategoryDto>(category);
            return CustomResponseDto<CategoryDto>.Success(200, categoryDto);
        }
    }
}
