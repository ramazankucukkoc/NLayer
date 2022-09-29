using API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    //[action] sayesinde metotun ismiyle çalışacagız demektir.
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Authorize(Policy = "ReadProduct")]
        // /api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            var productList = new List<Product>()
            {
                new Product { Id=1,Name="Kalem",Price=100,Stock=500},
                new Product { Id=2,Name="Silgi",Price=100,Stock=500},
                new Product { Id=3,Name="Defter",Price=100,Stock=500},
                new Product { Id=4,Name="Kitap",Price=100,Stock=500},
                new Product { Id=5,Name="Bant",Price=100,Stock=500},

            };
            return Ok(productList);
        }
        [Authorize(Policy = "UpdateOrCreate")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"id'si {id} olan product güncellenmiştir");
        }
        public IActionResult CreateProduct(Product product)
        {
            return Ok(product);
        }

    }
}
