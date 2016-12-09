using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Format
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.ParseExact("12122016", "MMddyyyy", CultureInfo.InvariantCulture);
            Console.ReadKey();
        }
    }
}
