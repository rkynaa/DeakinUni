using System;

namespace GuessingNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare all variables
            int number;
            int inputNum;

            // Initiate the variables
            number = 0;
            inputNum = 0;

            while (true)
            {
                Console.Write("User 1, enter a number between 1 and 10: ");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException TakeErr)
                {
                    Console.WriteLine("Error: you must enter a number between 1 and 10!", TakeErr);
                    return;
                }
                if (number >= 1 && number <= 10) {
                    break;
                } else {
                    Console.WriteLine("Error: you must enter a number between 1 and 10.");
                }
            }

            // Set a 'while' loop block for the guessng so the program will not stop ask the user until the user gets the number
            while (true) {
                Console.Write("User 2, enter a number between 1 and 10: ");
                try
                {
                    inputNum = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException GuessErr)
                {
                    Console.WriteLine("Error: you must enter a number between 1 and 10!", GuessErr);
                    break;
                }
                if (inputNum >= 1 && inputNum <= 10) 
                {
                    if (inputNum == number) {
                        Console.WriteLine("You have guessed the number! Well done!");
                        break;
                    }
                    else {
                        Console.WriteLine("Error: you haven't guess the number correctly. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: you didn't enter a number between 1 and 10. Try again.");
                }
            }
        }
    }
}
