using RockPaperScissors.Logic;

namespace RockPaperScissors.GenericPlayers
{
    public class RockPlayer : IPlayer
    {
        public ThrowStatus Throw()
        {
            return ThrowStatus.Rock;
        }
    }
}
