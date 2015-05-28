
using System.Data.Entity;
using Organizer_Domain.EntityModel;

namespace Organizer_DataAccess.Context
{
    /// <summary>
    ///     Контекст даних OrganizerContext для взаємодії з базою даних
    /// </summary>
    public class OrganizerContext : DbContext
    {
        public OrganizerContext() :
            base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Notice> Notices { get; set; }

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskPriority> TaskPriorities { get; set; }

        public DbSet<Tag> Tags { get; set; }
 
    }
}
