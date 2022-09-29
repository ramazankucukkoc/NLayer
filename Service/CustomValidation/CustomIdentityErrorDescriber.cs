using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.CustomValidation
{
	public class CustomIdentityErrorDescriber:IdentityErrorDescriber
	{
		public override IdentityError InvalidUserName(string userName)
		{
			return new IdentityError()
			{
				Code = "InvalidUserName",
				Description = $"{userName} geçersiz kullanıcı adıdır."
			};
		}
		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError() { Code = "DuplicateUserName", Description = $"Bu {userName} Kullanıcı Adı Zaten Mevcuttur." };
		}
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError() { Code = "DuplicateEmail", Description = $"Bu{email} zaten mevcuttur " };
		}
		public override IdentityError InvalidEmail(string email)
		{
			return new IdentityError() { Code = "InvalidEmail", Description = $"Geçersiz{email}'dir." };
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError() { Code = "PasswordTooShort", Description = $"Şifreniz en az {length} karakter olamlıdır." };
		}


	}
}
