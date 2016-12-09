using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace TryLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetPeople()
                .Where(i => i.Country.StartsWith("P"));

            Debug.WriteLine("I'm debugging!");


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        static IEnumerable<int> GetIntsForever()
        {
            int start = 0;
            while(true)
            {
                yield return start++;
            }
        }

        static IEnumerable<Person> GetPeople()
        {
            var dataStore = new PersonDataStore();
            return dataStore.All();
        }
    }
}
