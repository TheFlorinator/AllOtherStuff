using System;
using RockPaperScissors.Logic;
using RockPaperScissors.GameLogic;

namespace RockPaperScissors.UI
{
    public class UIController
    {
        public void Welcome()
        {
            IPlayer playerOne = PlayerFactory.GetPlayer("Player one, would you like to be a human or computer?");
            IPlayer playerTwo = PlayerFactory.GetPlayer("Player two would you like to be a human or computer?");
            GameFlow gameFlow = new GameFlow(playerOne, playerTwo);

            Console.Title = "Rock Paper Scissors";
            Console.WriteLine("Let's play Rock Paper Scissors");

            bool continuePlaying;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Player One wins: {0}", gameFlow.PlayerOneWins);
                Console.WriteLine("Player Two wins: {0}", gameFlow.PlayerTwoWins);
                Console.WriteLine("No one wins, you both lose: {0}", gameFlow.NoOneWins);
                Console.WriteLine();

                GetOutcome(gameFlow);

                Console.WriteLine();

                Console.Write("Would you like to play again? (Y/N)");

                string playAgain = Console.ReadLine();
                continuePlaying = playAgain.ToUpper() == "Y";
                Console.Clear();
            } while (continuePlaying);

            Console.ReadKey();
            Console.WriteLine("Thank you for playing, Press any key to quit.");
            Console.ReadKey();
        }

        public void GetOutcome(GameFlow gameFlow)
        {
            Outcomes gameOutCome = gameFlow.GetGameOutcome();

            if (gameOutCome == Outcomes.Draw)
            {
                Console.WriteLine("No one wins, you tied");
            }
            else if (gameOutCome == Outcomes.PlayerOneWin)
            {
                Console.WriteLine("Player one wins");
            }
            else
            {
                Console.WriteLine("Player two wins");
            }
        }
    }
}
