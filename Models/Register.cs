using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltTab.Models
{
	public class Register
	{
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }
		[Required]
		[DisplayName("Soyadınız")]
		public string Surname { get; set; }
		[Required]
		[DisplayName("Kullanıcı Adınız")]
		public string Username { get; set; }
		[Required]
		[DisplayName("Mail Adresiniz")]
		[EmailAddress(ErrorMessage = "Geçersiz email adresi : example@mail.com")]
		public string Email { get; set; }
		[Required]
		[DisplayName("Şifreniz")]
		public string Password { get; set; }
		[Required]
		[DisplayName("Şifreyi Doğrulayın")]
		[Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor!!!")]
		public string Confirmpassword { get; set; }
    }
}