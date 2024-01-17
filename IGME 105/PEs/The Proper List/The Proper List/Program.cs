//Conor Race
//Oct. 25th, 2021
//Purpose: Testing using try/catch blocks via exceptions
//passed from an object class.

using System;
using System.Collections.Generic;

namespace The_Proper_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ProperCustomList<string> myNames;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to this Exception Tester program!\n");
            try // Tests for whether or not a list can be created via a neg. integer.
            {
                myNames = new ProperCustomList<string>(-5);
            }
            catch (Exception error) // Catches exception and uses it without crashing.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ForegroundColor = ConsoleColor.Gray;
                myNames = new ProperCustomList<string>();
            }

            myNames.Add("Sonic");
            myNames.Add("Tails");
            myNames.Add("Shadow");
            myNames.Add("Rouge");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPrinting names:");
            Console.ForegroundColor = ConsoleColor.Gray;

            try // Tests for whether or not each element can be printed.
            {
                Console.WriteLine(myNames[1]);
                Console.WriteLine(myNames[4]);
                Console.WriteLine(myNames[-3]);
            }
            catch (Exception error) // Catches exception and uses it without crashing.
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message + " Ending code in \'try\'...");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nDone!");
        }
    }
}
