using Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomValidation
{
	public class CustomUserValidator : IUserValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
		{
			List<IdentityError> errors = new List<IdentityError>();
			string[] Digits = new string[] {"0","1","2","3","4","5","6","7","8","9"};
			foreach (var item in Digits)
			{
				if (user.UserName[0].ToString()==item)
				{
					errors.Add(new IdentityError()
					{
						Code = "UserNameContainsFirstDigitContains",
						Description = "UserName ilk harfi sayısal karakter olamaz"
					});
				}

			}
			if (errors.Count()==null)
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
