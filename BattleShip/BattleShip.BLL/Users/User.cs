using BattleShip.BLL.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL.Users
{
    public class User
    {
        private string _playerName;

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
        }

        public Board MainGameBoard { get; set; }

        public User()
        {
            MainGameBoard = new Board();
        }

        public User(string userName) : this()
        {
            _playerName = userName;
        }
    }
}
