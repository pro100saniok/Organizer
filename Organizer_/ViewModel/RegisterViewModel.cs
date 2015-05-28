
using System.ComponentModel.DataAnnotations;

namespace Organizer_.ViewModel
{
    /// <summary>
    ///     Модель для представлення регістрації на сайті.
    /// </summary>
    public class RegisterViewModel
    {
         [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Введіть правильний Email")]
        public string Name { get; set; }

         [Required(ErrorMessage = "*")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "{0} має бути не менше {2} символів.", MinimumLength = 6)]
        public string Password { get; set; }

         [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторіть пароль")]
        [Compare("Password", ErrorMessage = "Пароль і підтвердження пароля не збігаються.")]
        public string ConfirmPassword { get; set; }
    }
}