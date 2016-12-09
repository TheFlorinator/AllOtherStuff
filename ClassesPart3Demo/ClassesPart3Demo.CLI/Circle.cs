using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesPart3Demo.CLI
{
    class Circle : TwoDShape
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * (_radius);
        }

        public new string Getname()
        {
            return "Circle";
        }

    }
}
