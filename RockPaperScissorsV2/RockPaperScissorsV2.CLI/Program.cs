using RockPaperScissorsV2.BLL;
using System;

namespace RockPaperScissorsV2.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Rock Paper Scissors";
            Console.WriteLine("Let's play ROCK PAPER SCISSORS!");

            bool continuePlaying;

            do
            {
                IPlayer player1 = PlayerFactory.GetPlayer1();
                IPlayer player2 = PlayerFactory.GetPlayer2();

                Weapon player1Weapon = player1.GetWeapon();
                Weapon player2Weapon = player2.GetWeapon();

                Outcome outcome;

                if(player1Weapon == player2Weapon)
                {
                    outcome = Outcome.Draw;
                }
                else if(player1Weapon == Weapon.Rock && player2Weapon == Weapon.Scissors
                    || player1Weapon == Weapon.Scissors && player2Weapon == Weapon.Paper
                    || player1Weapon == Weapon.Paper && player2Weapon == Weapon.Rock)
                {
                    outcome = Outcome.Player1Wins;
                }
                else
                {
                    outcome = Outcome.Player2Wins;
                }

                switch (outcome)
                {
                    case Outcome.Player1Wins:
                        Console.WriteLine("Player 1 wins!");
                        break;
                    case Outcome.Player2Wins:
                        Console.WriteLine("Player 2 wins!");
                        break;
                    case Outcome.Draw:
                        Console.WriteLine("It's a draw!");
                        break;
                    default:
                        break;
                }

                Console.Write("Would you like to play again? (Y/N): ");
                string playAgain = Console.ReadLine();

                continuePlaying = playAgain.ToUpper() == "Y";
            } while (continuePlaying);

            Console.WriteLine("Thank you for playing. Please press any key to quit.");
            Console.ReadKey();
        }
    }
}
