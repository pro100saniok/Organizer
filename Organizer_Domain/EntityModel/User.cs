
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer_Domain.EntityModel
{
    /// <summary>
    ///     Сутність User.
    /// </summary>
    public sealed class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
