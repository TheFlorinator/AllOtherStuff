using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesPart3Demo.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle cirlce = new Circle(10);
            Octagon octagon = new Octagon(4);
            Console.WriteLine("Circle name: " + cirlce.GetName());
            Console.WriteLine("Octagon name: " + octagon.GetName());
            Console.ReadKey();



        }
    }
}
