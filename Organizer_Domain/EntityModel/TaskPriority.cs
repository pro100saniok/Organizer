using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer_Domain.EntityModel
{
    public class TaskPriority
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskPriorityId { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayName("Назва")]
        public string Name { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }

    }
}
