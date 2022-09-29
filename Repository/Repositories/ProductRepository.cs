using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Product> _products;  
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
            _products = appDbContext.Products;
        }

        public async Task<List<Product>> GetProductsWithCategory()
        {
        
            return await _products.Include(x => x.Category).ToListAsync();
        }
    }
}
