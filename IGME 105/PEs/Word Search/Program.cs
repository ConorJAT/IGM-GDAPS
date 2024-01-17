//Conor Race
//IGME.105.01
//Purpose: Creates a randomized word search and then checks if
//words entered by the user are in the word grid. Works horizontally
//AND verically.
using System;

namespace Word_Search
{
    class Program
    {
        /// <summary>
        /// Accepts a 2D array holding characters as a parameter and outputs all
        /// elements from the array into a formatted print.
        /// </summary>
        /// <param name="grid"> Accepts a char 2D array as a parameter. </param>
        public static void DisplayWordGrid(char[,] grid)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < grid.GetLength(0); i++) //Nest for loop help to output all elements in 2D array.
            {
                Console.Write("\t");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Accepts a 2D array and a String. Checks to see if the array holds an
        /// arrangement of characters that matches the entered string horizontally
        /// only. Checks for "empty" strings, edge overflow cases, and if the string
        /// is too long.
        /// </summary>
        /// <param name="grid"> Accepts a char 2D array as a parameter. </param>
        /// <param name="word"> Accepts a String as a parameter. </param>
        /// <returns> Returns true if the string exists horizontally in the word search. False, otherwise. </returns>
        public static Boolean SearchForWordHorz(char[,] grid, String word)
        {
            if (word.Length < 1) //Tests for empty strings.
            {
                return false;
            }
            else if (word.Length > grid.GetLength(1)) //Tests if the string is too long horizontally.
            {
                return false;
            }

            Boolean isPresent = false;

            for (int i = 0; i < grid.GetLength(0); i++) //Nest for loops check for every letter in the grid.
            {
                for (int j = 0; j < grid.GetLength(1); j++) 
                {
                    if (grid[i,j] == word[0])
                    {
                        isPresent = true;
                        if (word.Length > (grid.GetLength(1) - j)) //Tests for edge overflow cases.
                        {
                            isPresent = false;
                            continue;
                        }
                        
                        for (int k = 0; k < word.Length; k++) //If a letter matches the first letter of the string, for
                                                              //loop is used to check every letter of string.
                        {
                            if (word[k] != grid[i, j + k]) //Once one letter fails to match, the loop is broken and method continues.
                            {
                                isPresent = false;
                                break;
                            }

                        }
                        
                        if (isPresent)
                        {
                            return isPresent;
                        }
                    }
                }
            }
            return isPresent;
        }

        /// <summary>
        /// Accepts a 2D array and a String. Checks to see if the array holds an
        /// arrangement of characters that matches the entered string vertically
        /// only. Checks for "empty" strings, edge overflow cases, and if the string
        /// is too long.
        /// </summary>
        /// <param name="grid"> Accepts a char 2D array as a parameter. </param>
        /// <param name="word"> Accepts a String as a parameter.</param>
        /// <returns> Returns true if the string exists vertically in the word search. False, otherwise. 
        /// Only occurs if the word cannot be found horizontally. </returns>
        public static Boolean SearchForWordVert(char[,] grid, String word)
        {
            if (word.Length < 1) //Tests for empty strings.
            {
                return false;
            }
            else if (word.Length > grid.GetLength(0)) //Tests if the string is too long horizontally.
            {
                return false;
            }

            Boolean isPresent = false;

            for (int j = 0; j < grid.GetLength(1); j++) //Nest for loops check for every letter in the grid.
            {
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    if (grid[i, j] == word[0])
                    {
                        isPresent = true;
                        if (word.Length > (grid.GetLength(0) - i)) //Tests for edge overflow cases.
                        {
                            isPresent = false;
                            continue;
                        }

                        for (int k = 0; k < word.Length; k++) //If a letter matches the first letter of the string, for
                                                              //loop is used to check every letter of string.
                        {
                            if (word[k] != grid[i + k, j]) //Once one letter fails to match, the loop is broken and method continues.
                            {
                                isPresent = false;
                                break;
                            }

                        }

                        if (isPresent)
                        {
                            return isPresent;
                        }
                    }
                }
            }
            return isPresent;
        }

        static void Main(string[] args)
        {
            Random newRand = new Random();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to the Word Search Program!\n");

            Console.Write("Enter column quantity for Word Search (3 - 20): ");
            Console.ForegroundColor = ConsoleColor.White;
            int userColumn = int.Parse(Console.ReadLine());

            while (userColumn > 20 || userColumn < 3) //Loop used until user enters valid column count.
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Invalid Response! Please try again!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter column quantity for Word Search (3 - 20): ");
                Console.ForegroundColor = ConsoleColor.White;
                userColumn = int.Parse(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nNow enter row quantity for Word Search (3 - 20): ");
            Console.ForegroundColor = ConsoleColor.White;
            int userRow = int.Parse(Console.ReadLine());

            while (userRow > 20 || userRow < 3) //Loop used until user enters valid row count.
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Invalid Response! Please try again!");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Now enter row quantity for Word Search (3 - 20): ");
                Console.ForegroundColor = ConsoleColor.White;
                userRow = int.Parse(Console.ReadLine());
            }

            char[,] wordGrid = new char[userRow, userColumn];
            
            for (int i = 0; i < wordGrid.GetLength(0); i++)
            {
                for (int j = 0; j < wordGrid.GetLength(1); j++)
                {
                    wordGrid[i, j] = (char)newRand.Next(97,123); //Random assignment of characters via Random object.
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\nDisplaying your new {userColumn}x{userRow} Word Search:\n");
            DisplayWordGrid(wordGrid);

            String userChoice = null;
            while (userChoice != "quit")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\n\nPlease enter in a choice:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\"Display\" - Display Word Grid | Enter Word - Search a Word | \"Quit\" - Close Game");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYour Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                userChoice = Console.ReadLine().ToLower();

                switch (userChoice) //Switch statement used to check for user's choice
                {
                    case "display":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nDisplaying Word Grid:\n");
                        DisplayWordGrid(wordGrid);
                        break;

                    case "quit":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nThanks for playing! :)");
                        break;
 
                    default:
                        if (SearchForWordHorz(wordGrid, userChoice))
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"\nThe word \"{userChoice}\" appears horizontally in the Word Search!");
                        }
                        else if (SearchForWordVert(wordGrid, userChoice))
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"\nThe word \"{userChoice}\" appears vertically in the Word Search!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine($"\nThe word \"{userChoice}\" does not appear in the Word Search!");
                        }
                        break;
                }
            }
        }
    }
}
