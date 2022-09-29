using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Clients;

namespace IdentityMVCWEB.Controllers
{
    //[Authorize]
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductsController(ProductApiService productApiService, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task< IActionResult> Index()
        {
            return View(await _productApiService.GetProductsWithCategoryAsync());
        }
        public async Task<IActionResult> Save()
        {
            var categoriesDto=await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto newProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.SaveAsync(newProductDto);
                return RedirectToAction(nameof(Index));

            }
            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories=new SelectList(categoriesDto,"Id","Name");
            return View();
        }
        //[ServiceFilter(typeof(NotFoundFilter<Product,ProductDto>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);
            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            //Bu kısımda ModelState.IsValid gerekli doğrulamalardan geçtiği takdirde(boş geçilemez, doğru format vb.)
            //true olacak ve içerisinde yazacağımız işlemleri yapacak.
            //Doğrulama olmadığı takdirde aynı sayfa ekrana tekrar yazdırılacak. İşlem burada sona eriyor.
            //Böylelikle modele entegre bir validation oluşturmuş oluyorum.
            if (ModelState.IsValid)
            {
                await _productApiService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }
            var categoriesDto = await _categoryApiService.GetAllAsync();
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View(productDto);
        }
        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
            //("Index")=nameof(Index)
        }
    }
}
