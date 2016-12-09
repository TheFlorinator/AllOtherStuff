using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rock Paper Scissors";
            Console.WriteLine("Let's play Rock Paper Scissors");

            bool continuePlaying;

            do
            {
                Console.WriteLine("These are your options");
                Console.WriteLine("0) Rock");
                Console.WriteLine("1) Paper");
                Console.WriteLine("2) Scissors");
                string playerOneInput = Console.ReadLine();

                Random randomThrow = new Random();
                int throwing = randomThrow.Next(0, 3);


                if (playerOneInput.Contains("rock") && throwing == 0)
                {
                    Console.WriteLine("You have Tied!");
                }
                else if (playerOneInput.Contains("rock") && throwing == 1)
                {
                    Console.WriteLine("You have lost");
                }
                else if (playerOneInput.Contains("rock") && throwing == 2)
                {
                    Console.WriteLine("You have won!");
                }


                    Console.Write("Would you like to play again? (Y/N)");
                string playAgain = Console.ReadLine();
                continuePlaying = playAgain.ToUpper() == "Y";
                if (continuePlaying)
                {
                    
                }
                

            } while (continuePlaying);

            Console.ReadKey();
            Console.WriteLine("Thank you for playing, Press any key to quit.");
            Console.ReadKey();

        }

        //public string Name()
        //{
        //    string userName = Console.ReadLine();
        //    return userName;
        //}

        //public string Throw()
        //{

        //}
    }
}

