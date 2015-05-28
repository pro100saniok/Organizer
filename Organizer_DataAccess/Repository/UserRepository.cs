
using System.Linq;
using Organizer_DataAccess.Context;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;

namespace Organizer_DataAccess.Repository
{
    /// <summary>
    ///     Реалізація неуніверсальних методів для сутності User.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        public bool CheckIfEmailExistInDb(string email)
        {
            using (var context = new OrganizerContext())
            {
                return context.Users.Any(c => c.Email.Equals(email));
            }
        }

        public User SaveUser(User user)
        {
            using (var context = new OrganizerContext())
            {
                if (user.UserId == 0)
                {
                    context.Users.Add(user);
                }
                else
                {
                    User oldCustomer = context.Users.FirstOrDefault(c => c.UserId == user.UserId);
                    if (oldCustomer != null)
                    {
                        oldCustomer.Email = user.Email;
                        oldCustomer.Password = user.Password;
                    }
                }
                context.SaveChanges();
                return user;
            }
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (var context = new OrganizerContext())
            {
                var customer = context.Users.FirstOrDefault(c => c.Email.Equals(email) && c.Password.Equals(password));
                if (customer != null)
                {
                    return customer;
                }
                return null;
            }
        }


    }
}
