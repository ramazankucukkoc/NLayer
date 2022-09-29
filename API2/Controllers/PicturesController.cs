using API2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult GetPictures()
        {
            var pictures = new List<Picture>()
            {
                new Picture{Id=1,Name="Doğa Resmi",Url="dogaresmi.jpg"},
                new Picture{Id=2,Name="Doğa Resmi",Url="dogaresmi.jpg"},
                new Picture{Id=3,Name="Doğa Resmi",Url="dogaresmi.jpg"},
                new Picture{Id=4,Name="Doğa Resmi",Url="dogaresmi.jpg"}
            };
            return Ok(pictures);
        }
    }
}
