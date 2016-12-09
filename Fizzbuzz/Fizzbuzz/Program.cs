using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int countTo100 = 1; countTo100 <= 100; countTo100++)
            {
                bool fizz = countTo100 % 3 == 0;
                bool buzz = countTo100 % 5 == 0;
                if (fizz && buzz)
                    Console.WriteLine(countTo100 + " Fizzbuzz");
                else if (buzz)
                    Console.WriteLine(countTo100 + " Buzz");
                else if (fizz)
                    Console.WriteLine(countTo100 + " Fizz");
                else
                    Console.WriteLine(countTo100);
            }
            Console.ReadKey();
        }
    }
}
