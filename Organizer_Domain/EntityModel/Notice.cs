
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Organizer_Domain.EntityModel
{
    /// <summary>
    ///     Сутнысть Нотатки.
    /// </summary>
    public sealed class Notice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoticeId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Текст")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [Display(Name = "Додано")]
        public DateTime DateAdded { get; set; }

       
        public string UserName { get; set; }

        public  ICollection<Tag> Tags { get; set; }
    }
}
