using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data
{
    public class PersonDataStore
    {
        private static PetDataStore petStore = new PetDataStore();
        private static List<Person> people = new List<Person>();

        static PersonDataStore()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "data.csv");
            using (var reader = new DelimitedDataReader(filePath, true, 0, 0, ','))
            {
                while (reader.Read())
                {
                    people.Add(GetPerson(reader));
                }
            }
        }

        public IEnumerable<Person> All()
        {
            return people;
        }

        public Person Save(Person p)
        {
            if (p.Id > 0)
            {
                Update(p);
            }
            else
            {
                Insert(p);
            }
            return p;
        }

        private void Insert(Person p)
        {
            p.Id = people != null && people.Count > 0
                ? people.Max(i => i.Id) + 1
                : 1;
            people.Add(p);
        }

        private void Update(Person p)
        {
            var existing = people.FirstOrDefault(i => i.Id == p.Id);
            if (existing != null)
            {
                existing.FirstName = p.FirstName;
                existing.LastName = p.LastName;
                existing.EmailAddress = p.EmailAddress;
                existing.Gender = p.Gender;
                existing.Country = p.Country;
                existing.Buzzwords = p.Buzzwords;
            }
        }

        private static Person GetPerson(DelimitedDataReader reader)
        {
            Gender gender;
            Enum.TryParse(reader["gender"], out gender);
            return new Person
            {
                Id = Convert.ToInt32(reader["id"]),
                FirstName = reader["first_name"],
                LastName = reader["last_name"],
                EmailAddress = reader["email"],
                Gender = gender,
                Country = reader["country"],
                Buzzwords = reader["buzzword"],
                Pets = petStore.GetRandom()
            };
        }
    }
}
