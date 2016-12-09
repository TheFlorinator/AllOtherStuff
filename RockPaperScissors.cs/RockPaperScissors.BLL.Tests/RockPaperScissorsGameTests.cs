using RockPaperScissors.Logic;
using RockPaperScissors.GenericPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RockPaperScissors.GameLogic;

namespace RockPaperScissors.BLL.Tests
{
    [TestFixture]
    public class RockPaperScissorsGameTests
    {
        [Test]
        public void RockAlwaysBeatsScissors()
        {
            IPlayer playerOne = new RockPlayer();
            IPlayer playerTwo = new ScissorsPlayer();

            GameFlow game = new GameFlow(playerOne, playerTwo);
            Outcomes result = game.GetGameOutcome();

            Assert.AreEqual(Outcomes.PlayerOneWin, result);
        }

        [Test]
        public void ScissorsAlwaysBeatsPaper()
        {
            IPlayer playerOne = new PaperPlayer();
            IPlayer playerTwo = new ScissorsPlayer();

            GameFlow game = new GameFlow(playerOne, playerTwo);
            Outcomes result = game.GetGameOutcome();

            Assert.AreEqual(Outcomes.PlayerTwoWin, result);
        }

        [Test]
        public void PaperAlwaysBeatsRock()
        {
            IPlayer playerOne = new RockPlayer();
            IPlayer playerTwo = new PaperPlayer();

            GameFlow game = new GameFlow(playerOne, playerTwo);
            Outcomes result = game.GetGameOutcome();

            Assert.AreEqual(Outcomes.PlayerTwoWin, result);
        }

        [Test]
        public void PaperAlwaysTiesPaper()
        {
            IPlayer playerOne = new PaperPlayer();
            IPlayer playerTwo = new PaperPlayer();

            GameFlow game = new GameFlow(playerOne, playerTwo);
            Outcomes result = game.GetGameOutcome();

            Assert.AreEqual(Outcomes.Draw, result);
        }

        [Test]
        public void RockAlwaysTiesRock()
        {
            IPlayer playerOne = new RockPlayer();
            IPlayer playerTwo = new RockPlayer();

            GameFlow game = new GameFlow(playerOne, playerTwo);
            Outcomes result = game.GetGameOutcome();

            Assert.AreEqual(Outcomes.Draw, result);
        }

        [Test]
        public void ScissorsAlwaysTiesScissors()
        {
            IPlayer playerOne = new ScissorsPlayer();
            IPlayer playerTwo = new ScissorsPlayer();

            GameFlow game = new GameFlow(playerOne, playerTwo);
            Outcomes result = game.GetGameOutcome();

            Assert.AreEqual(Outcomes.Draw, result);
        }
    }
}
