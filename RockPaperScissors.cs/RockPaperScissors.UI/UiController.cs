using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Logic;

namespace RockPaperScissors
{
    class UiController
    {
        public void Welcome()
        {
            Iplayer 
            Console.Title = "Rock Paper Scissors";
            Console.WriteLine("Let's play Rock Paper Scissors");

            bool continuePlaying;
            int winCounter = 0;
            int tieCounter = 0;
            int lossCounter = 0;
            do
            {

                Console.WriteLine("You have won {0}", winCounter);
                Console.WriteLine("You have tied {0}", tieCounter);
                Console.WriteLine("You have lost {0}", lossCounter);
                Console.WriteLine();
                Console.WriteLine("These are your options");
                Console.WriteLine("0) Rock");
                Console.WriteLine("1) Paper");
                Console.WriteLine("2) Scissors");
                Console.Write("Choose thy weapon: ");
                string playerOneInput = Console.ReadLine().ToUpper();

                if (playerOneWeapon == playerTwoWeapon)
                {
                    outcome = Outcome.Draw;
                    tieCounter++;

                }
                else if (playerOneInput.Contains("rock") && playerTwoInput == 1 || playerOneInput.Contains("paper") && playerTwoInput == 2 || playerOneInput.Contains("scissors") && playerTwoInput == 0)
                {
                    Console.WriteLine("You have lost");
                    lossCounter++;

                }
                else if (playerOneInput.Contains("rock") && playerTwoInput == 2 || playerOneInput.Contains("paper") && playerTwoInput == 0 || playerOneInput.Contains("scirrors") && playerTwoInput == 1)
                {
                    Console.WriteLine("You have won!");
                    winCounter++;

                }
                Console.WriteLine("The computer chose {0}", playerTwoInput);
                Console.ReadKey();
                Console.Clear();


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
    }
}
