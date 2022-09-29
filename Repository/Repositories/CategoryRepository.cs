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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Category> _categories;
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
            _categories = appDbContext.Categories;
        }

        public async Task<Category> GetSingleCategoryWithProducts(int categoryId)
        {
            return await _categories.Include(x => x.Products).Where(y => y.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
