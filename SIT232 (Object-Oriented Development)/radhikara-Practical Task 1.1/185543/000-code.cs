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
            
            // This is for Q3 and Q4
            // It is commented in order to NOT make any conflicts.

            // // Q3
            // // Part 1 Solution
            // int number = 50;
            // if (number == 50) {
            //     Console.WriteLine("Number is 50");
            // }
            
            // // Part 2 Solution
            // // int number = 60;
            // if (number >= 50 && number <= 100) {
            //     Console.WriteLine("Number is more than or equal to 50 and less than or equal to 100");
            // }

            // // Part 3 Solution
            // // public class Score {
            // //     public static void main(String[] args) {
            // //         double score = 40;
            // //         if (score > 40) {
            // //             Console.WriteLine("You passed the exam!");
            // //         } else {
            // //             Console.WriteLine("You failed the exam!");
            // //         }
            // //     }
            // // }

            // // Part 4 Solution
            // // int number = 3;
            // switch (number)
            // {
            //     case 1: 
            //         Console.WriteLine("The number is 1");
            //         break;
            //     case 2: 
            //         Console.WriteLine("The number is 2");
            //         break;
            //     default:
            //         Console.WriteLine("The number is not 1 or 2");
            //         break;
            // }
            // // Part 5 Solution
            // switch (n) {
            //     case 1:
            //         Console.WriteLine ("A");
            //         break;
            //     case 2:
            //         Console.WriteLine ("B");
            //         break;
            //     default:
            //         Console.WriteLine ("C");
            //         break;
            // }

            // // Q4
            // // Part 1 Solution
            // int height = 13;
            // if ( height <= 12 )
            //     Console.WriteLine("Low bridge: ");
            //     Console.WriteLine ("proceed with caution.");
            // // It will print 'proceed with caution'
            
            // // Part 2 Solution
            // int sum = 21;
            // if ( sum != 20 )
            //     Console.WriteLine ("You win ");
            // else
            //     Console.WriteLine ("You lose ");
            //     Console.WriteLine ("the prize.");
            // /*
            // it will print:
            //     You win
            //     the prize.
            // */

            // // Part 3 Solution
            // int sum = 7;
            // if ( sum > 20 ) {
            //     Console.WriteLine ("You win ");
            // } else {
            //     Console.WriteLine ("You lose ");
            // }
            // Console.WriteLine ("the prize.");
            // /*
            // it will print:
            //     You lose
            //     the prize.
            // */
        }
    }
}
