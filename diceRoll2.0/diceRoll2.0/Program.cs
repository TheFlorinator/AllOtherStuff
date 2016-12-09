using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diceRoll2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please come join me on this journey of adventure and wonder as we look at a dice roll 100 times");
            Random diceRollOne = new Random();
            Random diceRollTwo = new Random();

            Dictionary<int, int> rollList = new Dictionary<int, int>();
            for (int i = 0; i <= 11; i++)
            {
                int rollLoop = rollList.Add[1, 0];
                rollLoop++;
            }
            for (int i = 0; i <= 100; i++)
            {
                int randomRollOne = diceRollOne.Next(1, 7);
                int randomRollTwo = diceRollTwo.Next(1, 7);

                int rollTotal = randomRollOne + randomRollTwo;
                if ()
                {

                }

                Console.WriteLine(randomRollOne + randomRollTwo);

            }
            Console.ReadKey();

        }
    }
}
