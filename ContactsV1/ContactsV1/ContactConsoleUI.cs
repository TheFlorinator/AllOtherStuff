using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsV1
{
    public class ContactConsoleUI
    {
        private ContactList contactList = new ContactList();

        public void Start()
        {
            Greet();
            string choice = DisplayMenu();
            while (choice == "1" || choice == "2")
            {
                if (choice == "1")
                {
                    AddContact();
                }
                else
                {
                    DisplayAllContacts();
                }

                choice = DisplayMenu();
            }
            SayGoodbye();
        }

        private void DisplayAllContacts()
        {
            int ordinal = 1;
            foreach (Contact contact in contactList.GetAll())
            {
                Console.WriteLine("Contact #{0} ==================", ordinal);
                Console.WriteLine("First Name: {0}", contact.FirstName);
                ordinal++;
            }
        }

        private void AddContact()
        {
            Console.WriteLine("Adding a Contact============");
            Console.Write("Enter a First Name: ");
            Contact contact = new Contact();
            contact.FirstName = Console.ReadLine();

            contactList.Add(contact);
        }

        private void Greet()
        {
            Console.WriteLine("Welcome to Contacts V1!");
        }

        private void SayGoodbye()
        {
            Console.WriteLine("Goodbye!");
        }

        private string DisplayMenu()
        {
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Display All Contacts");
            Console.WriteLine("Any thing else quits...");
            return Console.ReadLine();
        }
    }
}
