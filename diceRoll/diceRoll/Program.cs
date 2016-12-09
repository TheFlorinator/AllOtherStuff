using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diceRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please come join me on this journey of adventure and wonder as we look at a dice roll 100 times");
            Random diceRoll = new Random();

            int[] rollList = new int[6];
            for (int i = 0; i <= 100; i++)
            {
                int randomRoll = diceRoll.Next(0,6);
                rollList[randomRoll]++;
            }
            Console.WriteLine("You rolled 1: {0} times", rollList[0]);
            Console.WriteLine("You rolled 2: {0} times", rollList[1]);
            Console.WriteLine("You rolled 3: {0} times", rollList[2]);
            Console.WriteLine("You rolled 4: {0} times", rollList[3]);
            Console.WriteLine("You rolled 5: {0} times", rollList[4]);
            Console.WriteLine("You rolled 6: {0} times", rollList[5]);
            Console.ReadLine();
        }
    }
}
