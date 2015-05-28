
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer_Domain.EntityModel
{
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<Notice> Notices { get; set; }
    }
}
