﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact { ContactId = 1, Name = "John Skeet", Email = "john@gmail.com" },
            new Contact { ContactId = 2, Name = "Dan Green", Email = "Dan@gmail.com" },
            new Contact { ContactId = 3, Name = "Peter Pan", Email = "Peter@gmail.com" },
            new Contact { ContactId = 4, Name = "Anna Heisenberg", Email = "Anna@gmail.com" },
            new Contact { ContactId = 5, Name = "Brok Inger", Email = "Brok@gmail.com" },
        };

        public static List<Contact> GetContacts() => _contacts;
        public static Contact GetContactById(int id)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == id);
            if(contact != null)
            {
                return new Contact
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

        public static void UpdateContact(int contactId, Contact contact)
        {
            if(contactId != contact.ContactId) { return; }

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }

        }


        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContact(string filterText)
        {
            var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if(contacts == null || contacts.Count <= 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else
            {
                return contacts;
            }

            if(contacts == null || contacts.Count <= 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else
            {
                return contacts;
            }

            if (contacts == null || contacts.Count <= 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else
            {
                return contacts;
            }

            return contacts;
        }
    }
}
