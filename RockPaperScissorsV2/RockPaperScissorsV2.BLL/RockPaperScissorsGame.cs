using System;

namespace RockPaperScissorsV2.BLL
{
    public class RockPaperScissorsGame
    {
        private IPlayer _player1;
        private IPlayer _player2;

        public RockPaperScissorsGame(IPlayer player1, IPlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        public Outcome Play()
        {
            throw new NotImplementedException();
        }
    }
}
