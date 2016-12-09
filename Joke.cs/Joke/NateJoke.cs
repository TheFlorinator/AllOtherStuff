using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke
{
    class NateJoke : IJoke
    {
        public string TellPunchLine()
        {
            string jokePunch = "The third one ducks";
            return jokePunch;
        }

        public string TellSetup()
        {
            string jokeSetup = "Two guys walk into a bar...";
            return jokeSetup;
        }
    }
}
