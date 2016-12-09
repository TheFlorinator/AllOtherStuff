using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesPart3Demo.CLI
{
    public class Octagon : TwoDShape
    {
        private double _sideLength;

        public Octagon(double sideLength)
        {
            _sideLength = sideLength;
        }

        public override double GetArea()
        {
            return 2 * (1 + Math.Sqrt(2)) * _sideLength * _sideLength;
        }

        public override string Getname()
        {
            return "Octagon";
        }
    }
}
