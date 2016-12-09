using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dateAndTimeBiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter thy date");
            string dayInput = Console.ReadLine();
            DateTime dayNumber = DateTime.Parse(dayInput);
            

            Console.WriteLine("How many other Wednesday's out would you like to see?");
            string wedInput = Console.ReadLine();
            int wedNumber = Int32.Parse(wedInput);

            int wednesdayPrinted = 0;

            while (wednesdayPrinted < wedNumber)
            {

                if (dayNumber.DayOfWeek == DayOfWeek.Wednesday)
                {
                    wednesdayPrinted += 1;
                    Console.WriteLine(dayNumber);
                }
                dayNumber = dayNumber.AddDays(1);
            }

            Console.ReadKey();



        }
    }
}
