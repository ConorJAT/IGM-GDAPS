// Conor Race
// Nov. 17th, 2021
// Purpose: Creates a custom dictionary with a length of 5 and adds 6
// elements to it. Then, allows the user to play around with said
// dictionary, using its core functions.

using System;

namespace Custom_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "My Custom Dictionary";
            CustomDictionary<string, string> myDict = new CustomDictionary<string, string>(5);

            myDict.Add("Blue", "Sonic the Hedgehog");
            myDict.Add("Orange", "Tails the Fox");
            myDict.Add("Red", "Knuckles the Echidna");

            myDict["Black"] = "Shadow the Hedgehog";
            myDict["Moustache"] = "Dr.Eggman";
            myDict["Purple"] = "Espio the Chameleon";

            string userResponse = null;

            while (userResponse != "quit")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Custom Dictionary Menu: ---");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(">> Count\t>> Get\t\t>> Set");
                Console.WriteLine(">> Add\t\t>> Remove\t>> LoadFactor");
                Console.WriteLine(">> Clear\t>> Quit\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Your Choice: ");
                Console.ForegroundColor = ConsoleColor.White;
                userResponse = Console.ReadLine().ToLower();

                string userKey;
                string userValue;

                Console.ForegroundColor = ConsoleColor.Gray;
                switch (userResponse)
                {
                    case "count":
                        Console.WriteLine($"\nThis dictionary has {myDict.Count} elements in it");
                        break;


                    case "get":
                        Console.Write("\nEnter a key: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        userKey = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;

                        if (myDict.ContainsKey(userKey))
                        {
                            Console.WriteLine($"Value at key \'{userKey}\': {myDict[userKey]}");
                        }
                        else
                        {
                            Console.WriteLine("Key not found in dictionary");
                        }
                        break;


                    case "set":
                        int tempCount = myDict.Count;

                        Console.Write("\nEnter a key: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        userKey = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Enter a value: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        userValue = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        myDict[userKey] = userValue;

                        if (myDict.Count > tempCount)
                        {
                            Console.WriteLine($"The key \'{userKey}\' has been added");
                        }
                        else
                        {
                            Console.WriteLine($"The value was changed for the key \'{userKey}\'");
                        }
                        break;


                    case "add":
                        Console.Write("\nEnter a key: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        userKey = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Enter a value: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        userValue = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;

                        try
                        {
                            myDict.Add(userKey, userValue);
                            Console.WriteLine($"The key \'{userKey}\' has been added");
                        }
                        catch (Exception error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;


                    case "remove":
                        Console.Write("\nEnter a key: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        userKey = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;

                        if (myDict.Remove(userKey))
                        {
                            Console.WriteLine($"The key \'{userKey}\' has been removed");
                        }
                        else
                        {
                            Console.WriteLine($"The key \'{userKey}\' is not in the dictionary");
                        }
                        break;


                    case "loadfactor":
                        Console.WriteLine($"\nThis dictionary has a load factor of {myDict.LoadFactor}");
                        break;


                    case "clear":
                        myDict.Clear();
                        Console.WriteLine("\nThe dictionary has been cleared");
                        break;


                    case "quit":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\nHave a nice day!");
                        break;


                    default:
                        Console.WriteLine("\nInvalid choice. Please try again");
                        break;
                }
                Console.WriteLine("\n");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
