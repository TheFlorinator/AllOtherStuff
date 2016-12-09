using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joke
{
    class Program
    {
        static void Main(string[] args)
        {
            NateJoke joke = new NateJoke();           
            JokeTeller jokeBiz = new JokeTeller(joke);
            jokeBiz.TellJoke();
        }
    }
}
