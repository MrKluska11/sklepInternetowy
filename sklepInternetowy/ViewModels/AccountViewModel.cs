using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sklepInternetowy.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Musisz podać adres e-mail!") ]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage="Musisz podać hasło!")]
        [DataType(DataType.Password)]
        [Display(Name="Hasło")]
        public string Password { get; set; }

        [Display(Name="Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        [Display(Name="Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name="Potwierdź hasło")]
        [Compare("Password", ErrorMessage = "Musisz podać dwa takie same hasła!")]
        public string ConfirmPassword { get; set; }
    }
}