using System;

namespace DivisibleFour
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare all variables
            int inpNum = 0;

            Console.Write("Enter a number: ");
            try
            {
                inpNum = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException InpErr)
            {
                Console.WriteLine("Error: you must enter a number!", InpErr);
                return;
            }

            for (int number = 1; number <= inpNum; number++)
            {
                if (number % 4 == 0 && number % 5 != 0)
                {
                    Console.WriteLine("Number " + number + " is divisible by 4, but not divisible by 5");
                }
            }
        }
    }
}
