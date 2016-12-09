using RockPaperScissorsV2.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsV2.CLI
{
    public class ComputerPlayer : IPlayer
    {
        static Random random = new Random();

        public Weapon GetWeapon()
        {
            throw new NotImplementedException();
        }
    }
}
