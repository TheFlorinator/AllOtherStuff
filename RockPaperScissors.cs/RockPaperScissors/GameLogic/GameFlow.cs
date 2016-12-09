using RockPaperScissors.Logic;


namespace RockPaperScissors.GameLogic
{
    public class GameFlow
    {
        public int PlayerOneWins { get; private set; }
        public int PlayerTwoWins { get; private set; }
        public int NoOneWins { get; private set; }
        private IPlayer playerOne;
        private IPlayer playerTwo;

        public GameFlow(IPlayer playerOne, IPlayer playerTwo)
        {
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
        }

        public Outcomes GetGameOutcome()
        {
            Outcomes theOutCome;
            ThrowStatus playerOneThrow = playerOne.Throw();
            ThrowStatus playerTwoThrow = playerTwo.Throw();

            if (playerOneThrow == playerTwoThrow)
            {
                theOutCome = Outcomes.Draw;
                NoOneWins++;
            }
            else if (playerOneThrow == ThrowStatus.Rock && playerTwoThrow == ThrowStatus.Scissors
                    || playerOneThrow == ThrowStatus.Paper && playerTwoThrow == ThrowStatus.Rock
                    || playerOneThrow == ThrowStatus.Scissors && playerTwoThrow == ThrowStatus.Paper)
            {
                theOutCome = Outcomes.PlayerOneWin;
                PlayerOneWins++;
            }
            else
            {
                theOutCome = Outcomes.PlayerTwoWin;
                PlayerTwoWins++;
            }
            return theOutCome;
        }
    }
}
