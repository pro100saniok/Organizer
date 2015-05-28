
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer_Domain.EntityModel
{
    /// <summary>
    ///     Сутність Контакти.
    /// </summary>
    public sealed class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactId { get; set; }

        [Display(Name = "Прізвище")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Країна")]
        public string Country { get; set; }

        [Display(Name = "Місто")]
        public string City { get; set; }

        [Display(Name = "Вулиця")]
        public string Street { get; set; }

        [Display(Name = "Будинок")]
        public string House { get; set; }

        [Display(Name = "Квартира")]
        public string Apartment { get; set; }

        public string UserName { get; set; }
    }
}
