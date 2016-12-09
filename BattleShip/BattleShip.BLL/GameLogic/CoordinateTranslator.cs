using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.BLL
{
    public class CoordinateTranslator
    {
        public static int LetterTranslator(string input)
        {
            string letterCheck = input.Substring(0, 1);
            int letterToNumber = 0;
            switch (letterCheck)
            {
                case "a":
                    letterToNumber = 1;
                    break;
                case "b":
                    letterToNumber = 2;
                    break;
                case "c":
                    letterToNumber = 3;
                    break;
                case "d":
                    letterToNumber = 4;
                    break;
                case "e":
                    letterToNumber = 5;
                    break;
                case "f":
                    letterToNumber = 6;
                    break;
                case "g":
                    letterToNumber = 7;
                    break;
                case "h":
                    letterToNumber = 8;
                    break;
                case "i":
                    letterToNumber = 9;
                    break;
                case "j":
                    letterToNumber = 10;
                    break;
                default:
                    letterToNumber = -1;
                    break;
            }
            return letterToNumber;
        }

        public static int NumberTranslator(string input)
        {
            int forRealNumber = 0;
            string removeNumber = input.Remove(0, 1);
            bool realNumber = Int32.TryParse(removeNumber, out forRealNumber);
            if (realNumber == false)
            {
                return -1;
            }
            return forRealNumber;
        }

        public static bool CoordinateLengthValidation(string userInput)
        {
            int coordinateLength = userInput.Length;

            if (coordinateLength > 1 && coordinateLength < 4)
            {
                return true;
            }
            return false;
        }

        public static bool CheckForCoorLetter(string userCoordinate)
        {
            string firstLetter = userCoordinate.Substring(0, 1);

            if ((firstLetter == "a" || firstLetter == "b" || firstLetter == "c" || firstLetter == "d" || firstLetter == "e" ||
                firstLetter == "f" || firstLetter == "g" || firstLetter == "h" || firstLetter == "i" || firstLetter == "j"))
            {
                return true;
            }
            return false;
        }

        public static bool NumberCheck(string userCoordinate)
        {
            int numberInput;
            string numberChecker = userCoordinate.Remove(0, 1);
            bool actualNumbers = Int32.TryParse(numberChecker, out numberInput);

            if (numberInput <= 10 && numberInput >= 1)
            {
                return true;
            }
            return false;
        }

        public static Coordinate Translate(string input)
        {
            return new Coordinate(LetterTranslator(input), NumberTranslator(input));
        }
    }
}
