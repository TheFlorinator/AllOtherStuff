using BattleShip.BLL.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleShip.BLL.GameLogic
{
    public class UserMaintainer
    {
        private User userOne;
        private User userTwo;
        private int currentPlayer = 0;

        public UserMaintainer(string userNameOne, string userNameTwo)
        {
            userOne = new User(userNameOne);
            userTwo = new User(userNameTwo);
        }

        public Board CurrentBoard
        {
            get
            {
                return CurrentPlayer.MainGameBoard;
            }
        }

        public User CurrentPlayer
        {
            get
            {
                switch (currentPlayer)
                {
                    case 0:
                        return userOne;
                    case 1:
                        return userTwo;
                    default:
                        return userOne;
                }
            }
        }

        public User OtherPlayer
        {
            get
            {
                switch (currentPlayer)
                {
                    case 0:
                        return userTwo;
                    case 1:
                        return userOne;
                    default:
                        return userTwo;
                }
            }
        }

        public void ToggleUserName()
        {
            currentPlayer = currentPlayer == 0 ? 1 : 0;
        }
    }
}
