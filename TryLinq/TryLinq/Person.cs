using System.Collections.Generic;

namespace TryLinq
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public string Country { get; set; }
        public string Buzzwords { get; set; }
        public List<Pet> Pets { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}]", 
                Id, FirstName, LastName, EmailAddress, Gender, Country, Buzzwords, string.Join(", ", Pets));
        }
    }
}
