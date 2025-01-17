// See https://aka.ms/new-console-template for more information

// if stating "using System", don't need to state ex)System.Console.WriteLine()
// if not, need to state ex)System.Console.WriteLine()
using System;

namespace Assignment2
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            // Variable to store the number of dice rolls entered by the user.
            int rolls;
            
            // Prompt the user for the number of dice rolls to simulate.
            Console.WriteLine("Welcome to the dice throwing simulator!\n How many dice rolls would you like to simulate? ");
            
            // Read the user's input, convert it to an integer, and store it in the rolls variable.
            rolls = int.Parse(Console.ReadLine());

            // Create an instance of the RollingDice class.
            // not static = might want to create multiple instances of RollingDice, each maintaining its own state or behaving independently
            RollingDice rd = new RollingDice();
            // Call the RollDice method and store the result.
            int[] results = rd.RollDice(rolls);
            
            // Display the header for the dice rolling simulation results.
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS\n Each \"*\" represents 1% of the total number of rolls.\n Total number of rolls = " + rolls.ToString() + ".");

            // Loop through the possible sums of two dice (2 through 12, 2 is the smallest sum of two dice).
            for (int i = 2; i < 13; i++) // i <= 12
            {
                // Calculate the percentage of rolls that resulted in the current sum (i).
                double percentage = (results[i] / (double)rolls) * 100; //one of the number in the calculation needs to be converted to double just in case the result is integer
                
                // Calculate the number of asterisks to display for the current sum.
                // The percentage is rounded to the nearest whole number, and the result is cast to an integer.
                int asterisks = (int)Math.Round(percentage);
                
                // Display the sum and the corresponding asterisks.
                Console.WriteLine($"{i}: {new string('*', asterisks)}");
            }
            
            // Display a closing message.
            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }

    internal class RollingDice
    {
        // Static Random instance shared by all instances of the RollingDice class.
        // private = only accessible within the RollingDice class
        // static = all calls to rnd.Next() will use the same instance of the random number generator, avoiding to generate the same sequence of random numbers 
        private static Random rnd = new Random();
        
        // Method to simulate rolling dice a specified number of times.
        // Not void because it returns int[]    
        //It belongs to an instance of the non-static class and can access instance-specific data
        internal int[] RollDice(int rolls)
        {
            // Array to store the count of each sum (2 through 12).
            // Index 0 and 1 are unused because the smallest sum of two dice is 2.
            int[] results = new int[13];

            // Simulate rolling the dice the specified number of times.
            for (int i = 0; i < rolls; i++)
            {
                // Generate random numbers for two dice (each between 1 and 6).
                int dice1 = rnd.Next(1, 7);
                int dice2 = rnd.Next(1, 7);
                
                // Calculate the sum of the two dice.
                int sum = dice1 + dice2;
                
                // Increment the count for the calculated sum.
                results[sum]++;
            }

            // Return the array containing the counts of each sum.
            return results;
        }
    }
}


// Another way to print *
//int asteriskCount = 5;
//string asterisks = "";
//for (int i = 0; i < asteriskCount; i++)
//{
//    asterisks += "*";
//}
//Console.WriteLine(asterisks); // Output: *****


