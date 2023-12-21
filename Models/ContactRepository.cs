using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact { Name = "John", Email = "john@asdfa.com" },
            new Contact { Name = "Dan", Email = "Dan@asdfa.com" },
            new Contact { Name = "Peter", Email = "Peter@asdfa.com" },
            new Contact { Name = "Anna", Email = "Anna@asdfa.com" },
            new Contact { Name = "Bro", Email = "Bro@asdfa.com" },

        };

        public static List<Contact> GetContacts() => _contacts;
        public static Contact GetContactById(int id)
        {
            return _contacts.FirstOrDefault(x => x.ContactId == id);
        }
    }
}
