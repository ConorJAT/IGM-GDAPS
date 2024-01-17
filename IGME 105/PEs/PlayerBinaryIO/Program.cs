// Conor Race
// Nov. 29th, 2021
// Purpose: Creates a PlayerManager object and allows the user to
// add player data to the list, while also saving and loading player
// data from a local .data file.

using System;

namespace PlayerBinaryIO
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerManager players = new PlayerManager();
            string response = null;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-- Player Manager Program --\n");


            while (response != "quit")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please make a selection:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("> Create   > Print   > Load   > Save   > Info   > Quit");
                Console.Write("Your choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                response = Console.ReadLine().ToLower();
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (response)
                {
                    case "create":

                        Console.Write("\n    Enter the name of new player: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string name = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        players.CreatePlayer(name);
                        Console.WriteLine($"    Added {name} to the list\n");
                        break;


                    case "print":
                        Console.WriteLine("");
                        players.Print();
                        Console.WriteLine("");
                        break;


                    case "load":
                        players.Load();
                        break;


                    case "save":
                        players.Save();
                        break;


                    case "info":
                        players.Info();
                        break;


                    case "quit":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n    Have a nice day!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;


                    default:
                        Console.WriteLine("\n    Invalid option. Please try again\n");
                        break;
                }
            }
        }
    }
}
