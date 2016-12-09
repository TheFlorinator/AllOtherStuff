using RockPaperScissors.Logic;

namespace RockPaperScissors.GenericPlayers
{
    public class PaperPlayer : IPlayer
    {
        public ThrowStatus Throw()
        {
            return ThrowStatus.Paper;
        }
    }
}
