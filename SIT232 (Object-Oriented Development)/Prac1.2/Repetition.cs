using System;

namespace Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            double average;
            int upperbound = 100;
            int number = 1;

            // for (int number = 0; number < upperbound; number++)
            // {
            //     sum += number;
            // }

            // while (number <= upperbound) {
            //     sum += number;
            //     Console.WriteLine("Current number : " + number + " the sum is : " + sum);
            //     number++;
            // }

            do 
            {
                sum += number;
                Console.WriteLine("Current number : " + number + " the sum is : " + sum);
                number++;
            } while (number <= 100);

            // Compute the average as a double - remember that int divided by int produces an int
            // Print the sum and the average and check that your results are correct

            Console.WriteLine("The sum is " + sum);

            average = (Double)sum/upperbound;
            Console.WriteLine("The average is " + average);
        }
    }
}
