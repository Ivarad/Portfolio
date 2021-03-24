using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace flexnetcoresite.Models
{
    public class Users
    {
        [Key]
        public int ID_User { get; set; }

        [Required (ErrorMessage = "Поле почты не должно быть пустым")]
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Email адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле пароля не должно быть пустым")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Длина строки должна быть от 8 до 30 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле логина не должно быть пустым")]
        [Display(Name = "Логин")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 30 символов")]
        public string Login { get; set; }

    }
}
