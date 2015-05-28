
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer_Domain.EntityModel
{
    /// <summary>
    ///     Сутність Завдання.
    /// </summary>
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Текст")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Початок")]
        [DataType(DataType.Date)]
        
       [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Закінчення")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateEnd { get; set; }

        public int? TaskPriorityId { get; set; }

        public virtual TaskPriority Priority { get; set; }

        public string UserName { get; set; }
    }
}
