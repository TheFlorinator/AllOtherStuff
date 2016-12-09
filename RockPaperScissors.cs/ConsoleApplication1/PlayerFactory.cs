using RockPaperScissors.Logic;
using System;


namespace RockPaperScissors.UI
{
    public class PlayerFactory
    {

        public static IPlayer GetPlayer(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine();
            if (userInput.Contains("hum"))
            {
                return new HumanPlayer();
            }
            else if (userInput.Contains("comp"))
            {
                return new ComputerPlayer();
            }
            Console.WriteLine("Fine I shall choose!");
            return new ComputerPlayer();
        }
    }
}
