//Conor Race
//IGME.105.01
//Purpose: Allows a user to create an array of names
//and perform a variety of tasks with said array.
using System;

namespace Arrays
{
    class Program
    {
        /// <summary>
        /// Prints the lsit of options the user can choose from and
        /// gets the choice of the user via an int.
        /// </summary>
        /// <returns> Returns the choice of the user as an int. </returns>
        public static int PrintMenuAndGetChoice()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPlease make a selection:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1. Print All Names\t2. Search a Name\t3. Replace a Name\t4. Find Duplicates\t5. Close Program\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Your Choice: ");
            Console.ForegroundColor = ConsoleColor.White;
            return int.Parse(Console.ReadLine());
        }
        
        /// <summary>
        /// Takes a String array as a parameter and uses a for loop
        /// to print any and all Strings in the array.
        /// </summary>
        /// <returns> Returns nothing (void). </returns>
        public static void PrintAllNames(String[] names)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPrint All Names:");

            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
            return;
        }

        /// <summary>
        /// Takes a String array as a paremeter and prompts the use for
        /// a name. Then, checks to see if the name is in the array. 
        /// Statements vary whether a name was found or not.
        /// </summary>
        /// <return> Returns nothing (void). </return>
        public static void FindTheName(String[] names)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nFind a Name:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please enter a name you'd like to find: ");
            Console.ForegroundColor = ConsoleColor.White;
            String nameFind = Console.ReadLine();

            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] == nameFind)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"The name \"{nameFind}\" exists in this array!");
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"The name \"{nameFind}\" does not exist in this array!");
            return;
        }

        /// <summary>
        /// Takes a String array as a parameter and prompts user for index
        /// of the array. While loop is used to keep asking the user until a
        /// valid index integer is entered. Afterwards, the user enters a
        /// name. The new name replaces the old name at the selected index.
        /// </summary>
        /// <returns> Returns a new copy of String array with changes. </returns>
        public static String[] SwapTheName(String[] names)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nReplace a Name:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please enter the index where you'd like to replace a name: ");
            Console.ForegroundColor = ConsoleColor.White;
            int swapNameIndex = int.Parse(Console.ReadLine());

            while ((swapNameIndex >= names.Length) || (swapNameIndex < 0))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Invalid Index! Try again: ");
                Console.ForegroundColor = ConsoleColor.White;
                swapNameIndex = int.Parse(Console.ReadLine());
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Please enter in a new name you'd like to replace the old: ");
            Console.ForegroundColor = ConsoleColor.White;
            String newName = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"The name \"{names[swapNameIndex]}\" was swapped with \"{newName}\" at index {swapNameIndex}");
            names[swapNameIndex] = newName;
            return names;
        }

        /// <summary>
        /// Takes a String array as a parameter and checks to see if there
        /// are any duplicate names in the array. A nested for loop is
        /// used as a checker to compare names to see if they match or not.
        /// </summary>
        /// <returns> Returns nothing (void). <returns>
        public static void FindTheDuplicate(String[] names)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nFind Duplicate Names:");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < names.Length - 1; i++)
            {
                for (int j = i + 1; j < names.Length; j++)
                {
                    if (names[i] == names[j])
                    {
                        Console.WriteLine($"The name \"{names[i]}\" exists more than once in this array!");
                    }
                }
            }
            return;
        }
        
        static void Main(string[] args)
        {
            String[] namesList;
            int userChoice = 0;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Hello! Welcome to this Character Name Manager!");
            Console.Write("How many character names would you like to add: ");
            Console.ForegroundColor = ConsoleColor.White;
            int nameListLength = int.Parse(Console.ReadLine());
            namesList = new String[nameListLength];

            
            for (int i = 0; i < nameListLength; i++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"Enter Name {i + 1}: ");
                Console.ForegroundColor = ConsoleColor.White;
                namesList[i] = Console.ReadLine();
            }

            while (userChoice != 5)
            {
                userChoice = PrintMenuAndGetChoice();

                switch (userChoice)
                {
                    case 1:
                        PrintAllNames(namesList);
                        break;

                    case 2:
                        FindTheName(namesList);
                        break;

                    case 3:
                        namesList = SwapTheName(namesList);
                        break;

                    case 4:
                        FindTheDuplicate(namesList);
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("\n\nHave a nice day! :)");
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
