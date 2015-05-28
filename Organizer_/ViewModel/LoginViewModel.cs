
using System.ComponentModel.DataAnnotations;

namespace Organizer_.ViewModel
{
    /// <summary>
    ///     Модель для представлення входу на сайт.
    /// </summary>
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "E-mail: ")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Пароль: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}