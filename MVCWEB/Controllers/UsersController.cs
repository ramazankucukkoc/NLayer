using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Clients;

namespace IdentityMVCWEB.Controllers
{

    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserApiService _userApiService;

        public UsersController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, UserApiService userApiService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _userApiService = userApiService;
        }

        public  IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Member");
            }
           ;
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
