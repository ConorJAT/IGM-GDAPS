//Conor Race
//Oct 13th, 2021
//Purpose: Allows the user to create a custom list object 
//and manage a series of words for which they add.
using System;

namespace MyOwnList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Create your own Word List");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("List Size: ");

            Console.ForegroundColor = ConsoleColor.White;
            CustomList<string> myList = new CustomList<string>(int.Parse(Console.ReadLine()));
            string response = null;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nPease make a choice:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("   Type a word - Add the word to your list");
            Console.WriteLine("   \'Print\' - Print all words in your list");
            Console.WriteLine("   \'Count\' - Print how many words are in your list");
            Console.WriteLine("   \'Length\' - Print the total length of your list");
            Console.WriteLine("   \'Get\' - Retrieve an element at a particular index");
            Console.WriteLine("   \'Set\' - Replace an element at a particular index");
            Console.WriteLine("   \'Done\' - Close the program");
               
            while (response != "done")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nYour choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                response = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (response)
                {
                    case "print":
                        Console.WriteLine("List Elements: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 0; i < myList.GetLength; i++)
                        {
                            if (myList[i] == null) //Will not print any empty spaces (null values) in the list.
                            {
                                continue;
                            }
                            Console.WriteLine($"   {myList[i]}");
                        }
                        break;

                    case "count":
                        Console.WriteLine($"Your list has {myList.GetCount} elements in it");
                        break;

                    case "length":
                        Console.WriteLine($"Your list currently has a length of {myList.GetLength}");
                        break;

                    case "get":
                        Console.Write("Please enter an index value: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int getIndex = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        
                        while (getIndex > myList.GetLength - 1 || getIndex < 0) //Will print blank spaces for null values, but will prompt
                                                                                //user again if they enter an index that goes beyond the 
                                                                                //current list length.
                        {
                            Console.Write("Index out of bounds. Please enter new index: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            getIndex = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        Console.WriteLine($"Word at index {getIndex}: {myList[getIndex]}");
                        break;

                    case "set":
                        Console.Write("Please enter an index value: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        int setIndex = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;
                        
                        while (setIndex >= myList.GetCount || setIndex < 0) //Will not let the user set a word to a 'null' space nor let them
                                                                            //set a word at an index out of the list's current length.
                        {
                            Console.Write("No element present. Please enter new index: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            setIndex = int.Parse(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }

                        Console.Write("Please eneter a new word: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        myList[setIndex] = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Word successfully replaced");
                        break;

                    case "done":
                        Console.WriteLine("\nCya Later!");
                        break;

                    default:
                        myList.Add(response);
                        Console.WriteLine("Word added to the list");
                        break;
                }
            }
        }
    }
}
