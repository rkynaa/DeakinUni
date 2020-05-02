using System;

namespace Microwave
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and initiate all variables
            int n_items = 0;
            double s_heating_time = 0;
            double heating_time = 0;

            // Asking the user for how many number of items that are going to be heated
            Console.WriteLine("Enter the number of items that are going to be heated:");

            // State a try-catch block in order to catch FormatException if the entry is not a number
            try
            {
                n_items = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException itemExc)
            {
                // If the try-catch block catch the exception,
                // the program generates an error message and will end the program immediately
                Console.WriteLine("Error: you must enter a number! (an integer)", itemExc);
                return;
            }
            
            // Asking the user for how many number of items that are going to be heated
            Console.WriteLine("Enter the number as a single-item heating time:");

            // State a try-catch block in order to catch FormatException if the entry is not a number
            try
            {
                s_heating_time = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException timeExc)
            {
                // If the try-catch block catch the exception,
                // the program generates an error message and will end the program immediately
                Console.WriteLine("Error: you must enter a number!", timeExc);
                return;
            }

            // Set a switch-case conditions to filter out the entry number
            // If the entered number is between 1 and 9, the program will print a desired message
            // However, if the number is not between 1 and 9, the program will print an error message
            switch (n_items)
            {
                case 1:
                    heating_time = s_heating_time;
                    break;
                case 2:
                    heating_time = s_heating_time + (s_heating_time/2);
                    break;
                case 3:
                    heating_time = s_heating_time * 2;
                    break;
                default:
                    Console.WriteLine("Error: heating more than 3 item is not recommended");
                    break;
            }

            Console.WriteLine("It is recommended to heat the item(s) in " + heating_time + " minutes");
        }
    }
}
