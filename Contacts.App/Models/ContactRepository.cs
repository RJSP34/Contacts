using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.App.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>
        {
            new Contact {ContactId = 1, Name = "John Doe", Email = "johndoe@example.com" },
            new Contact {ContactId = 2, Name = "Jane Doe", Email = "janedoe@example.com" },
            new Contact {ContactId = 3, Name = "John Smith", Email = "johnsmith@example.com" },
            new Contact {ContactId = 4, Name = "Jane Smith", Email = "janesmith@example.com" }
        };

        public static void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact != null)
            {
                return new Contact()
                {
                    ContactId = id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                };
            }

            return null;
        }

        public static void UpdateContact(int contactId, Models.Contact contact)
        {
            if (contactId != contact.ContactId)
            {
                return;
            }

            var contactToUpdate = _contacts.FirstOrDefault(c => c.ContactId == contactId);

            if (contactToUpdate != null)
            {
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }
        }

        public static void SaveContact(Models.Contact contact)
        {
            if (contact.ContactId == 0)
            {
                contact.ContactId = _contacts.Max(c => c.ContactId) + 1;
                _contacts.Add(contact);
            }
            else
            {
                UpdateContact(contact.ContactId, contact);
            }
        }

        public static void DeleteContact(int contactId)
        {
            var contactToDelete = _contacts.FirstOrDefault(c => c.ContactId == contactId);

            if (contactToDelete == null)
            {
                return;
            }
            else
            {
                _contacts.Remove(contactToDelete);
            }
        }

        public static List<Contact> SearchContact(string filter)
        {
            return _contacts.Where(c => c.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) || c.Email.Contains(filter, StringComparison.OrdinalIgnoreCase)
            || c.Phone.Contains(filter, StringComparison.OrdinalIgnoreCase) || c.Address.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
