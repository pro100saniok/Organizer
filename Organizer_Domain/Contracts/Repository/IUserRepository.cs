
using Organizer_Domain.EntityModel;

namespace Organizer_Domain.Contracts.Repository
{
    /// <summary>
    ///   
    /// </summary>
    public interface IUserRepository
    {
        bool CheckIfEmailExistInDb(string email);

        User SaveUser(User newUser);

        User GetUserByEmailAndPassword(string email, string password);
    }
}
