using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git
{
    class Program
    {
        static void Main(string[] args)
        {
            EchoX(14);
        }

        static void DoX()
        {
            Console.WriteLine("boom");
        }

        public static int EchoX(int x)
        {
            return x;

        }

        public static void DoY()
        {

        }
    }
}
