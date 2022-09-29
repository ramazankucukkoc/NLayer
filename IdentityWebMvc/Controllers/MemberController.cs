using IdentityWebMvc.Enums;
using IdentityWebMvc.Models;
using IdentityWebMvc.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IdentityWebMvc.Controllers
{   
    // Bir controller uzerine  [Authorize] attiriubute eklersen sadece üyeler girer.

    [Authorize] 
    public class MemberController : BaseController
    {
        public MemberController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager, signInManager)
        {
        }

        public IActionResult Index()
        {
            AppUser user = CurrentUser;
            UserViewModel userViewModel = user.Adapt<UserViewModel>();
            return View(userViewModel);

        }
        public IActionResult UserEdit()
        {
            AppUser user =CurrentUser;


            UserViewModel userViewModel =user.Adapt<UserViewModel>();

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));

            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult>UserEdit(UserViewModel userViewModel,IFormFile userPicture)
        {
            ModelState.Remove("Password");
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));

            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;
                if (userPicture!=null && userPicture.Length>0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(userPicture.FileName);
                    
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture", fileName);
                    
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await userPicture.CopyToAsync(stream);
                        user.Picture="/Picture/"+fileName;
                    }
                }
                user.UserName=userViewModel.UserName;
                user.Email = userViewModel.Email;
                user.PhoneNumber=userViewModel.PhoneNumber;
                user.City = userViewModel.City;
                user.BirthDay = userViewModel.BirthDay;
                user.Gender = (int)userViewModel.Gender;

                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.UpdateSecurityStampAsync(user);
                    await signInManager.SignOutAsync();
                    await signInManager.SignInAsync(user, true);

                    ViewBag.success = "true";
                }
                else
                {
                  AddModelError(result);
                }
            }
            return View(userViewModel);//Kullanıcı girmiş oldugu degerler yanlış ise textboxların içindeki degerler boş olmasın diye.
        }
        public IActionResult PasswordChange()
        {
            return View();
        }       
        [HttpPost]
        public IActionResult PasswordChange(PasswordChangeViewModel passwordChangeViewModel)
        {
            if (ModelState.IsValid)
            {
                AppUser user = CurrentUser;

                    bool exist = userManager.CheckPasswordAsync(user, passwordChangeViewModel.PaaswordOld).Result;
                    if (exist)
                    {
                        IdentityResult result = userManager.ChangePasswordAsync(user, passwordChangeViewModel.PaaswordOld,
                            passwordChangeViewModel.PasswordNew).Result;
                        if (result.Succeeded)
                        {
                        userManager.UpdateSecurityStampAsync(user);//Bunu yazmak zorundayız çünkü eski şifreyle 
                        //sayfalarda dolaşmamısı için yazdık.Şifre değiştirdikden sonra yazıyoruz.
                        signInManager.SignOutAsync();
                        signInManager.SignOutAsync();
                        signInManager.PasswordSignInAsync(user,passwordChangeViewModel.PasswordNew,true,false);

                            ViewBag.success = "true";
                        }
                        else
                        {
                        AddModelError(result);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Eski şifreniz yanlış");
                    }                
            }
            return View(passwordChangeViewModel);
        }
        public void LogOut()
        {
            signInManager.SignOutAsync();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
