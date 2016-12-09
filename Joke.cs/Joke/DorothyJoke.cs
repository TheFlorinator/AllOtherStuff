using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke
{
    class DorothyJoke : IJoke
    {
        public string TellPunchLine()
        {
            string jokePunch = "Tooth hurt-y";
            return jokePunch;
        }

        public string TellSetup()
        {
            string jokeSetup = "What time did the man go to the dentist?";
            return jokeSetup;
        }
    }
}
