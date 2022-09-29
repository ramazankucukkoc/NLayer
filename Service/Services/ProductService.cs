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
    public class ProductService : Service<Product, ProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;

       
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> genericRepository,
            IProductRepository productRepository) : base(unitOfWork, genericRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productsDto=ObjectMapper.Mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success( 200,productsDto);

        }
    }
}
