using Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Clients;

namespace IdentityMVCWEB.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserApiService _userApiService;

        public UsersController(UserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public  IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateUserSave()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserSave(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                await _userApiService.CreateUserAsync(userDto);
                return RedirectToAction("LogIn","Home");
            }    

            return View();
        }

    }
}
