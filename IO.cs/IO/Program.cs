using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    class Program
    {
        const string HOME_PATH = @"C:\Users\Apprentice";
        const string ALICE_PATH = "new-alice.txt";

        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("alice-in-wonderland.txt");
            string[] nonBlankLines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();
            File.WriteAllLines("new-alice.txt", nonBlankLines);
            Console.WriteLine(lines);
            Console.ReadKey();
        }
    }
}
