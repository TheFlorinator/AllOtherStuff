using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke
{
    public class JokeTeller
    {
        IJoke joke;
        public JokeTeller(IJoke jokes)
        {
            this.joke = jokes;
        }
        public void TellJoke()
        {
            Console.WriteLine(joke.TellSetup());
            Console.WriteLine("Wait for it.... ");
            Console.ReadKey();
            Console.WriteLine(joke.TellPunchLine());
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
