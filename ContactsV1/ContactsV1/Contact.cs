using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsV1
{
    public class Contact
    {
        public string FirstName;
        public string LastName;
        public string Company;
        public string Relationship;
        public DateTime BirthDate;

        public List<PhoneNumber> PhoneNumbers;
        public List<EmailAddress> EmailAddresses;
    }
}
