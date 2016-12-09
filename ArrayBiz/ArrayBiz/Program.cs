using System;

namespace ArrayBiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please give me thy word to reverse:");
            
            char[] userInput = Console.ReadLine().ToCharArray();
            Array.Reverse(userInput);

            Console.WriteLine();
               
            foreach (char character in userInput)
            {
                Console.Write(character);
            }
            
            Console.ReadKey();

        }
    }
}
