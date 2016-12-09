using System;
using System.Collections.Generic;

namespace TryLinq
{
    public class PersonDataStore
    {
        private PetDataStore petStore = new PetDataStore();

        public IEnumerable<Person> All()
        {
            using (var reader = new DelimitedDataReader("data.csv", true, 0, 0, ','))
            {
                while (reader.Read())
                {
                    yield return GetPerson(reader);
                }
            }
        }

        private Person GetPerson(DelimitedDataReader reader)
        {
            return new Person
            {
                Id = Convert.ToInt32(reader["id"]),
                FirstName = reader["first_name"],
                LastName = reader["last_name"],
                EmailAddress = reader["email"],
                Gender = (Gender)Enum.Parse(typeof(Gender), reader["gender"]),
                Country = reader["country"],
                Buzzwords = reader["buzzword"],
                Pets = petStore.GetRandom()
            };
        }
    }
}
