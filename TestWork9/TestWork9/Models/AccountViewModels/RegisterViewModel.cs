using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWork9.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        static Random generator = new Random();
        private static double _balance = 1000;

        [Required]
        [Display(Name = "Личный идентификационный 6 значный код")]
        public string Code = generator.Next(0, 1000000).ToString("D6");

        [Required]
        [Display(Name = "На вашем счету")]
        public double Balance = _balance;


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
