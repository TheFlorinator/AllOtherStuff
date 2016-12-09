using System;

namespace GuessingGame.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to guessing game!");

            Random randomNumberGenerator = new Random();

            // Set the number to guess between 1 and 20, inclusive.
            int numberToGuess = randomNumberGenerator.Next(1, 21);

            //TODO: Write the rest of the game here.

            do
            {
                // Prompt the user for input
                Console.WriteLine("Please guess a number between 1 and 20!");

                //TODO: Get the user's input.
                string userInput = Console.ReadLine();
                int userNumber = int.Parse(userInput);

                //TODO: Is the input the same as the number to guess?
                if (userNumber == numberToGuess)
                {
                    // if so, congratulate the player
                    Console.WriteLine("Congratulations! You guessed the number!");
                    break;
                }
                else if (userNumber > numberToGuess)
                {
                    // if not, check to see if the guess is higher than the number to guess
                    //    if so, ask the player to guess a lower number
                    Console.WriteLine("Your guess is too high! Please guess again!");
                }
                else
                {
                    //    else, ask the player to guess a higher number
                    Console.WriteLine("Your guess is too low! Please guess again!");
                }
            } while (true);
            
            Console.WriteLine("Thank you for playing!");
            Console.ReadKey();
        }
    }
}
