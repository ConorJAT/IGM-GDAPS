//Conor Race
//IGME.105.01 - Sep 27, 2021
//Exam 1 Practical
//Purpose: Program emulates a dice rolling game between two players.

using System;
using System.Collections.Generic;

namespace Dice
{
    class Program
    {   
        /// <summary>
        /// Creates a new int array and fills the array with random numbers
        /// based on the range which is provided via the parameter "sides."
        /// </summary>
        /// <param name="numDice"> Serves as defining length for array. </param>
        /// <param name="sides"> Serves as the range of random numbers produced. </param>
        /// <returns> Returns an int array filled with random int values. </returns>
        public static int[] GenerateDiceRolls(int numDice, int sides)
        {
            Random diceRoll = new Random();

            int[] diceScores = new int[numDice]; //numDice = The length of every array.
            for (int i = 0; i < diceScores.Length; i++)
            {
                diceScores[i] = diceRoll.Next(1, sides + 1); //+1 due to exclusivity of the outer bound.
            }

            return diceScores; //Returns array filled with random ints.

        }

        /// <summary>
        /// Gives a report on all the scores the players rolled, tells the user
        /// the lowest score is dropped, and adds all scores EXCLUDING the
        /// lowest score.
        /// </summary>
        /// <param name="playerName"> Player's name. </param>
        /// <param name="rolls"> Int array holding random ints created via method above. </param>
        /// <returns> Rturns the added sum of scores in "rolls" EXCEPT the lowest score. </returns>
        public static int SumDiceDropLowest(string playerName, int[] rolls)
        {
            int lowNumIndex = 0;
            int lowNum = rolls[0];
            int sum = 0;
            Console.Write($"\n   {playerName} rolled: ");
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] < lowNum) //Checks for lowest score.
                {
                    lowNum = rolls[i];
                    lowNumIndex = i;
                }
                Console.Write($"{rolls[i]} ");
            }
            Console.Write($"(Dropping Lowest Score: {lowNum})");

            for (int i = 0; i < rolls.Length; i++) //Adds all scores but...
            {
                if (i == lowNumIndex) //Skips when it reaches the lowest score.
                {
                    continue;
                }
                sum += rolls[i];
            }

            return sum; //Returns added sum.
        }

        static void Main(string[] args)
        {
            int playerOneScore = 0;
            int playerTwoScore = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Let's Roll Some Dice!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Player 1 Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            string player1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Player 2 Name: ");
            Console.ForegroundColor = ConsoleColor.White;
            string player2 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("How Many Rounds: ");
            Console.ForegroundColor = ConsoleColor.White;
            int rounds = int.Parse(Console.ReadLine());

            for (int i = 1; i <= rounds; i++) //Keeps track of how many rounds there are via user input.
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n\nRound {i}:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Number of Dice to Roll: ");
                Console.ForegroundColor = ConsoleColor.White;
                int dice = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Number of Sides per Dice: ");
                Console.ForegroundColor = ConsoleColor.White;
                int side = int.Parse(Console.ReadLine());

                int[] playerOneNums = GenerateDiceRolls(dice, side); //New int arrays created every round.
                int[] playerTwoNums = GenerateDiceRolls(dice, side);

                Console.ForegroundColor = ConsoleColor.Gray;
                playerOneScore += SumDiceDropLowest(player1, playerOneNums);
                Console.WriteLine($"\n   {player1}'s Current Score: {playerOneScore}");
                playerTwoScore += SumDiceDropLowest(player2, playerTwoNums);
                Console.WriteLine($"\n   {player2}'s Current Score: {playerTwoScore}");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nEnd of Game:");
            Console.ForegroundColor = ConsoleColor.White;
            if (playerOneScore > playerTwoScore)
            {
                Console.WriteLine($"{player1} Wins!");
            }

            else if (playerOneScore < playerTwoScore)
            {
                Console.WriteLine($"{player2} Wins!");
            }
            else
            {
                Console.WriteLine("It's a Tie! Both Players Win!"); //Acounts for ties, if any.
            }
        }
    }
}
