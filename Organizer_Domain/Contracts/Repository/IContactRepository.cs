
using Organizer_Domain.EntityModel;
using System.Collections.Generic;

namespace Organizer_Domain.Contracts.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactRepository
    {
        Contact SaveContact(Contact contact);

        void DeleteContact(Contact contact);

        Contact GetContactById(int? contactId);

        List<Contact> GetAllContact(string userName);
    }
}
