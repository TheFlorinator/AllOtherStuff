using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsV1
{
    public class ContactList
    {
        private List<Contact> contacts = new List<Contact>();

        public void Add(Contact contact)
        {          
            contacts.Add(contact);
        }

        public List<Contact> GetAll()
        {
            return contacts;
        }
    }
}
