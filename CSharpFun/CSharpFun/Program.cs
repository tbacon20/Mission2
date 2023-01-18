using System;

namespace CSharpFun
{
    class Program
    {
        public static void Main(string[] args)
        {
            // This will initialize the number of sides on each dice and the highest roll possible.
            // If a user were to hypothetically want to roll dice with more than 6 sides,
            // they could change the values here and run the program.
            int diceOne = 6;
            int diceTwo = 6;
            int maxCount = diceOne + diceTwo;

            // Start the game!
            int numRolls = StartGame();

            // Roll the dice!!
            int[] rollCounts = RollDice(diceOne, diceTwo, maxCount, numRolls);

            // End the game and print the results
            EndGame(numRolls, maxCount, rollCounts);
        }

        // This will create an array for the number that is rolled 
        static int[] RollDice(int diceOne, int diceTwo, int maxCount, int numRolls)
        {
            // Initialize a "jagged" array to keep track of each count
            int[] rollCount = new int[maxCount];

            // Roll once for each requested roll
            Random rnd = new Random();
            for (int i = 0; i < numRolls; i++)
            {
                // Calculate the total between the two rolls
                int roll = rnd.Next(1, diceOne + 1) + rnd.Next(1, diceTwo + 1);

                // When the number is rolled, add it to that number's roll count
                rollCount[roll-2]++;

                // For debugging purposes, you can see each roll by running the following line
                // Console.WriteLine(roll);
            }

            return rollCount;
        }

        // This is the method for starting the game and getting the number of rolls.
        static public int StartGame()
        {
            int numRolls;
            // Welcome the user and request a number of dice
            Console.WriteLine("Welcome to the dice throwing simulator!\n");
            Console.WriteLine("How many dice rolls would you like to simulate?");
            numRolls = Convert.ToInt32(Console.ReadLine());

            return numRolls;
        }

        // End the game
        static public void EndGame(int numRolls, int maxCount, int[] rollCounts)
        {
            // Print results
            Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1 % of the total number of rolls.");
            Console.WriteLine("Total number of rolls = " + numRolls + ".\n");

            for (int i = 0; i < maxCount - 1; i++)
            {
                // Initialize the print for the number being counted
                Console.Write((i + 2) + ": ");
                int numRolled = rollCounts[i];

                // Calculate the roll percentage
                double countRollPercent = ((double)rollCounts[i] / numRolls) * 100;

                // Print an "*" for each percentage represented by the number
                int rollPercent = Convert.ToInt32(Math.Round(countRollPercent));
                for (int j = 0; j < rollPercent; j++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }
}