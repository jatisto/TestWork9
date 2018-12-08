using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWork9.Models.AccountViewModels
{
    public class LoginViewModel
    {


        [Required]
        [Display(Name = "Баланс")]
        public string Balance { get; set; }

        [Required]
        [Display(Name = "Личный идентификационный 6 значный код")]
        public string Code { get; set; }

        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Remember")]
        public bool RememberMe { get; set; }
    }
}
