using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : CustomBaseController
    {

        //private readonly IUserService _userService;

        //public HomeController(IUserService userService)
        //{
        //    _userService = userService;
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        //{
           
        //    return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetUser()
        //{
        //    return ActionResultInstance(await _userService.GetUserByNameAsync(HttpContext.User.Identity.Name));
        //}
    }
}
