using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Logic
{
    public class ComputerPlayer : IPlayer
    {
        static Random randomThrow = new Random();
        public ThrowStatus Throw()
        {
            int throwNumber = randomThrow.Next(1, 4);
            ThrowStatus computerPlayerThrow;

            switch (throwNumber)
            {
                case 1:
                    computerPlayerThrow = ThrowStatus.Rock;
                    break;

                case 2:
                    computerPlayerThrow = ThrowStatus.Paper;
                    break;

                case 3:
                default:
                    computerPlayerThrow = ThrowStatus.Scissors;
                    break;
            }
            return computerPlayerThrow;
        }
    }
}

