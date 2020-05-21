using System;

namespace SwitchStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and initiate all variables
            int number = 0;

            // Asking the user for a number between 1 and 9
            Console.WriteLine("Enter the number (as integers):");

            // State a try-catch block in order to catch FormatException if the input is not a number
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException numberExc)
            {
                // If the try-catch block catch the exception,
                // the program generates an error message and will end the program immediately
                Console.WriteLine("Error: you must enter a number! (an integer)", numberExc);
                return;
            }

            // Set a switch-case conditions to filter out the entry number
            // If the entered number is between 1 and 9, the program will print a desired message
            // However, if the number is not between 1 and 9, the program will print an error message
            switch (number)
            {
                case 1:
                    Console.WriteLine("ONE");
                    break;
                case 2:
                    Console.WriteLine("TWO");
                    break;
                case 3:
                    Console.WriteLine("THREE");
                    break;
                case 4:
                    Console.WriteLine("FOUR");
                    break;
                case 5:
                    Console.WriteLine("FIVE");
                    break;
                case 6:
                    Console.WriteLine("SIX");
                    break;
                case 7:
                    Console.WriteLine("SEVEN");
                    break;
                case 8:
                    Console.WriteLine("EIGHT");
                    break;
                case 9:
                    Console.WriteLine("NINE");
                    break;
                default:
                    Console.WriteLine("Error: you must enter a number between 1 and 9!");
                    break;
            }
        }
    }
}
