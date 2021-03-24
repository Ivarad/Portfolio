using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flexnetcoresite.Models
{
    public class User
    {
        [Required(ErrorMessage = "Не указан электронный адрес")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Длина строки должна быть от 8 до 30 символов")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 30 символов")]
        public string Login { get; set; }
    }
}
