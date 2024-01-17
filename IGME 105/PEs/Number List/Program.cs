//Conor Race
//IGME.105.01
//A short program which allows a user to play with a list of
//numbers. The user can add and delete numbers at their own
//discretion.
using System;
using System.Collections.Generic;

namespace Number_List
{
    class Program
    {
        /// <summary>
        /// Accepts an integer list as a parameter and outputs all
        /// contents in that list all on one line,  neatly spaced.
        /// </summary>
        /// <param name="nums"> Accepts an integer list as a parameter. </param>
        public static void PrintAllNums(List<int> nums)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nPrinting numbers:\n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < nums.Count; i++)
            {
                if (i == nums.Count - 1)
                {
                    Console.WriteLine(nums[i]);
                }
                else
                {
                    Console.Write($"{nums[i]}, "); //Comma spacing for all nums EXCEPT the last one.
                }
            }
        }

        /// <summary>
        /// Accepts an integer list as a parameter and takes a number
        /// entered by the user and places it into the list, 
        /// specifically in order od smallest to greatest numbers.
        /// </summary>
        /// <param name="nums"> Accepts an integer list as a parameter. </param>
        public static void AddTheNum(List<int> nums)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nPlease enter a number you'd like to add: ");
            Console.ForegroundColor = ConsoleColor.White;
            int addNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Count; i++)
            {
                if (addNum <= nums[i]) //Checks if entered num is less than or equal to the current
                                       //num in the list. Once satisfied, the number is placed at this
                                       //location.
                {
                    nums.Insert(i, addNum);
                    break;
                }
            }

            if (addNum >= nums[nums.Count - 1])
            {
                nums.Add(addNum); //If the number entered is the new greatest number, then it's simply
                                  //added to the end. 
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Number successfully added!");
        }

        /// <summary>
        /// Accepts an integer list as a parameter and takes a number
        /// entered by the user and checks to see if that number is in
        /// the list. If so, that number is deleted from the list.
        /// </summary>
        /// <param name="nums"> Accepts an integer list as a parameter. </param>
        public static void RemoveTheNum(List<int> nums)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\nPlease enter a number you'd like to remove: ");
            Console.ForegroundColor = ConsoleColor.White;
            int deleteNum = int.Parse(Console.ReadLine());

            if (nums.Contains(deleteNum)) //Checks if entered num is in the list.
            {
                nums.Remove(deleteNum);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Number successfully removed!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Error! The number you entered does not exist in your list!");
            }
        }

        static void Main(string[] args)
        {
            Random newRand = new Random();
            List<int> numList = new List<int>();

            numList.Add(newRand.Next(0, 21));
            numList.Add(newRand.Next(21, 41));
            numList.Add(newRand.Next(41, 61));
            numList.Add(newRand.Next(61, 81));
            numList.Add(newRand.Next(81, 101));

            String userChoice = null;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to this Number List Manager!");
            while (userChoice != "quit")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nPlease select and option: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\"Print\" - Print Nums | \"Add\" - Add Num to List | \"Remove\" - Remove a Num");
                Console.WriteLine("\"Count\" - Count Nums in List | \"Quit\" - Close Program");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYour Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                userChoice = Console.ReadLine().ToLower();

                switch (userChoice) //Switch statement for all choices
                {
                    case "print":
                        PrintAllNums(numList);
                        break;

                    case "add":
                        AddTheNum(numList);
                        break;

                    case "remove":
                        RemoveTheNum(numList);
                        break;

                    case "count":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine($"\nYour list contains a total of {numList.Count} numbers.");
                        break;

                    case "quit":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nHave a nice day! :)");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\nInvalid choice! Please try again!");
                        break;
                }
            }
        }
    }
}
