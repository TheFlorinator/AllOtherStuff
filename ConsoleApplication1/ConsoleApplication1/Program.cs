using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number:");
            var input = Console.ReadLine();
            var answer = Decipherizor(input);
            Console.Write("The answer is:");
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        public static int Decipherizor(string probs)
        {
            var numbers = new List<int>();
            var number = 0;
            var sum = 0;
            var numberList = new List<int>();
            string [] brokenPeiceOfMyHeart = probs.Split(' ');

            for (int i = 0; i < brokenPeiceOfMyHeart.Length; i++)
            {
                var didWork = int.TryParse(brokenPeiceOfMyHeart[i], out number);
                if (didWork == false)
                {
                    var firstNumber = numbers[i - 2];
                    var secondNumber = numbers[i - 1];
                    if (brokenPeiceOfMyHeart[i].Contains("+"))
                    {
                        sum = firstNumber + secondNumber;
                        return sum;
                    }
                    else
                    {
                        sum = firstNumber * secondNumber;
                        return sum;
                    }
                }
                numbers.Add(number);
            }
            
            return 0;
        }
    }
}
