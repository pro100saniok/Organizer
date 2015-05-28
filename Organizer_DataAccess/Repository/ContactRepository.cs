
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Organizer_DataAccess.Context;
using Organizer_Domain.Contracts.Repository;
using Organizer_Domain.EntityModel;

namespace Organizer_DataAccess.Repository
{
    public class ContactRepository : IContactRepository
    {
        public Contact SaveContact(Contact contact)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    if (contact.ContactId == 0)
                    {
                        context.Contacts.Add(contact);
                    }
                    else
                    {
                        Contact oldcontact = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
                        if (oldcontact != null)
                        {
                            oldcontact.Email = contact.Email;
                            oldcontact.Name = contact.Name;
                            oldcontact.LastName = contact.LastName;
                            oldcontact.MiddleName = contact.MiddleName;
                            oldcontact.Phone = contact.Phone;
                            oldcontact.Country = contact.Country;
                            oldcontact.City = contact.City;
                            oldcontact.House = contact.House;
                            oldcontact.Apartment = contact.Apartment;
                            oldcontact.Street = contact.Street;
                            oldcontact.UserName = contact.UserName;
                        }
                    }
                    context.SaveChanges();
                    return contact;
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new Exception(ex.InnerException.Message, ex);
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public void DeleteContact(Contact contact)
        {
            using (var context = new OrganizerContext())
            {
                try
                {
                    var entry = context.Entry(contact);
                    if (entry.State == EntityState.Detached)
                    {
                        context.Contacts.Attach(contact);
                    }
                    context.Contacts.Remove(contact);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                        throw new Exception(ex.InnerException.Message, ex);
                    throw new Exception(ex.Message, ex);
                }
            }
        }

        public Contact GetContactById(int? contactId)
        {
            using (var context = new OrganizerContext())
            {
                return context.Contacts.FirstOrDefault(c => c.ContactId == contactId);
            }
        }

        public List<Contact> GetAllContact(string userName)
        {
            using (var context = new OrganizerContext())
            {
                return context.Contacts.Where(contact => contact.UserName == userName).ToList();
            }
        }
    }
}
