using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
	public class LoginDto
	{

		[Display(Name ="Email Adresiniz")]
		[Required(ErrorMessage ="Email alanı gereklidir.")]
		[EmailAddress]
		public string Email { get; set; }
		
		[Display(Name ="Şifre Alanı Gereklidir")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
		[DataType(DataType.Password)]
		[MinLength(4,ErrorMessage ="Şifreniz En Az 4 karakter olamlıdır")]
        public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
