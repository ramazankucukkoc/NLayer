using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsersController : CustomBaseController
    {
     
        private readonly IUserService _userService;
        public UsersController( IUserService userService)
        {
         
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser(string name)
        {
            return ActionResultInstance(await _userService.GetUserByUserNameAsync(name));
        }
        //[HttpGet]
        //public async Task<IActionResult> GetEmail(LoginDto login)
        //{
        //    return ActionResultInstance(await _userService.GetUserByEmailAsync(login.Email));
        //}
    }
}
