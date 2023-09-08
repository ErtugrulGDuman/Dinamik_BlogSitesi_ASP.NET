using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AltTab.Models
{
	public class PasswordChange
	{
        [Required]
        [DisplayName("Mevcut Şifreniz")]
        public string OldPassword { get; set; }
		[Required]
		[StringLength(100,MinimumLength =5,ErrorMessage ="Şifreniz en az 5 karakter olmalı")]
		[DisplayName("Yeni Şifreniz")]
		public string NewPassword { get; set; }
		[Required]
		[DisplayName("Yeni Şifreyi Doğrula")]
		[Compare("NewPassword",ErrorMessage ="Şifreler Eşleşmiyor!!!")]
		public string ConfirmNewPassword { get; set; }
    }
}