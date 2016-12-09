using System;
using RockPaperScissors.Logic;

namespace RockPaperScissors.UI
{
    public class HumanPlayer : IPlayer
    {
        public ThrowStatus Throw()
        {
            Console.WriteLine("These are your options");
            Console.WriteLine("0) Rock");
            Console.WriteLine("1) Paper");
            Console.WriteLine("2) Scissors");
            Console.Write("Choose thy weapon: ");

            string playerOneInput = Console.ReadLine().ToUpper();
            ThrowStatus playerOneThrow;

            switch (playerOneInput)
            {
                case "R":
                    playerOneThrow = ThrowStatus.Rock;
                    break;

                case "P":
                    playerOneThrow = ThrowStatus.Paper;
                    break;

                default:
                    playerOneThrow = ThrowStatus.Scissors;
                    break;

            }
            return playerOneThrow;
        }
    }
}
