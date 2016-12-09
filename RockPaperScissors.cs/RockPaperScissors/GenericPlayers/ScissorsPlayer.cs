using RockPaperScissors.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.GenericPlayers
{
    public class ScissorsPlayer : IPlayer
    {
        public ThrowStatus Throw()
        {
            return ThrowStatus.Scissors;
        }
    }
}
