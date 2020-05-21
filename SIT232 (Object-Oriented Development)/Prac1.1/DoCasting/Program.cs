using System;

namespace DoCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare and initiate the 'sum' and 'count' variables
            int sum = 0;
            int count = 0;
            
            // Initate the 'sum' and 'count' variables at 17 and 5 respectively
            sum = 17;
            count = 5;

            // Declare the 'intAverage' variable
            int intAverage;

            // Calculate the 'intAverage' by dividing the 'sum' variable with the 'count' variable
            intAverage = sum/count;

            Console.WriteLine("The value for intAverage is " + intAverage);

            // Declare the 'doubleAverage' variable
            double doubleAverage;

            // Calculate the 'doubleAverage' by dividing the 'sum' variable with the 'count' variable
            // the calculation mus be casted into double data type
            doubleAverage = (double)sum/count;

            Console.WriteLine("The value for doubleAverage is " + doubleAverage);
        }
    }
}
