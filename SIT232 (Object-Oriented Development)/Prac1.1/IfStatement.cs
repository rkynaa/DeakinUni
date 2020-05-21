using System;

namespace IfStatement
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

            // Set an if-else conditions to filter out the entry number
            // If the entered number is between 1 and 9, the program will print a desired message
            // However, if the number is not between 1 and 9, the program will print an error message
            if (number == 1) 
            {
                Console.WriteLine("ONE");
            }
            else if (number == 2) 
            {
                Console.WriteLine("TWO");
            }
            else if (number == 3) 
            {
                Console.WriteLine("THREE");
            }
            else if (number == 4) 
            {
                Console.WriteLine("FOUR");
            }
            else if (number == 5) 
            {
                Console.WriteLine("FIVE");
            }
            else if (number == 6) 
            {
                Console.WriteLine("SIX");
            }
            else if (number == 7) 
            {
                Console.WriteLine("SEVEN");
            }
            else if (number == 8) 
            {
                Console.WriteLine("EIGHT");
            }
            else if (number == 9) 
            {
                Console.WriteLine("NINE");
            }
            else 
            {
                Console.WriteLine("Error: you must enter a number between 1 and 9!");
            }
        }
    }
}
