using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomValidation
{
	public class CustomPasswordValidator : IPasswordValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
		{
			List<IdentityError> errors = new List<IdentityError>();
			if (password.ToLower().Contains(user.UserName.ToLower()))
			{
				if (!user.Email.Contains(user.UserName))
				{
					errors.Add(new IdentityError() { Code = "PasswordContainsUserName", Description = "Şifre alanı kullanıcı adı içermez" });

				}
				errors.Add(new IdentityError() { Code = "PasswordContainsUserName", Description = "Şifre Alanı Kullanıcı Adı içermez" });
			}
			if (password.ToLower().Contains("1234"))
			{
				errors.Add(new IdentityError() { Code = "PasswordContains1234", Description = "Şifre Alanı Ardışık Sayı içermez" });
			}
			if (password.ToLower().Contains(user.Email))
			{
				errors.Add(new IdentityError() { Code = "PasswordContainsEmail", Description = "Şifre Alanı Email adresini içermemmelidir" });
			}
			if (errors.Count()==0)
			{
				return Task.FromResult(IdentityResult.Success);
			}
			else
			{
				return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
			}
		}
	}
}
