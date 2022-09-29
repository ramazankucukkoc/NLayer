using Microsoft.AspNetCore.Mvc;
using Service.Clients;

namespace IdentityMVCWEB.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryApiService _categoryApiService;
        private readonly ProductApiService _productApiService;

        public CategoriesController(CategoryApiService categoryApiService, ProductApiService productApiService)
        {
            _categoryApiService = categoryApiService;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryApiService.GetAllAsync());
        }
    }
}
