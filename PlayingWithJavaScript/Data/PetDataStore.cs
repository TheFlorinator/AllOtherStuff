using System;
using System.Collections.Generic;
using System.IO;

namespace Data
{
    public class PetDataStore
    {
        private Random random = new Random();       

        private static PetType[] petTypes = new PetType[]
        {
            PetType.Dog,
            PetType.Cat,
            PetType.GuineaPig,
            PetType.Hamster,
            PetType. Parrot,
            PetType.Gecko,
            PetType.Monkey
        };

        private static string[] names;

        static PetDataStore()
        {
            var namePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin", "names.csv");
            names = File.ReadAllLines(namePath);

        }

        public List<Pet> GetRandom()
        {
            int chance = random.Next(100);
            int number = 0;
            if (chance > 40 && chance < 70)
            {
                number = 1;
            }
            else if (chance > 70 && chance <= 90)
            {
                number = 2;
            }
            else if (chance > 90)
            {
                number = 3;
            }

            var result = new List<Pet>();
            while (number > 0)
            {
                Pet p = new Pet
                {
                    PetType = petTypes[random.Next(petTypes.Length)],
                    Name = names[random.Next(names.Length)]
                };
                result.Add(p);

                number--;
            }
            return result;
        }
    }
}
