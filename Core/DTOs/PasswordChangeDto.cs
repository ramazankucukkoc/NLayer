using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.DTOs
{
    public class PasswordChangeDto
    {
        [Display(Name = "Eski Şifreniz")]
        [Required(ErrorMessage = "Eski Şifreniz Gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifeniz en az 4 karekterli olamk zorundadır.")]
        public string PaaswordOld { get; set; }

        [Display(Name = "Yeni Şifreniz")]
        [Required(ErrorMessage = "Yeni Şifreniz Gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Yeni en az 4 karekterli olamk zorundadır.")]
        public string PasswordNew { get; set; }

        [Display(Name = "Onay Yeni Şifreniz")]
        [Required(ErrorMessage = "Onay Yeni Şifreniz Gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifreniz en az 4 karekterli olamk zorundadır.")]
        [Compare("PasswordNew", ErrorMessage = "Yeni Şifreniz ve onay şifreniz birbirinden farklıdır.")]
        public string PasswordConfirm { get; set; }
    }
}
