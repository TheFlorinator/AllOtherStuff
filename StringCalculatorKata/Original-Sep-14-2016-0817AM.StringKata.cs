using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Example
{
    public static class StringKata
    {
        /// <summary>
        /// The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            else
            {
                string[] numbers = input.Split(',');
                if (numbers.Length == 1)
                {
                    return double.Parse(input);
                }
                else
                {
                    double nums = 0;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        nums += double.Parse(numbers[i]);
                    }
                    return nums;
                }
            }
        }
    }
}
