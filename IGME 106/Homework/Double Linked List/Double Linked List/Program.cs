// Conor Race
// March 22nd, 2022 - HW #4
// IGME.106.07

using System;

namespace Double_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkList<string> myList = new CustomLinkList<string>();
            string response = null;
            string toAdd;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to your Custom Linked List!");
            
            while (response != "quit")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\nPlease make a selection:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("[clear]\t\tClears your list");
                Console.WriteLine("[count]\t\tNumber of items in list");
                Console.WriteLine("[get]\t\tRetrieve data at specific index");
                Console.WriteLine("[insert]\tInsert data at specific index");
                Console.WriteLine("[print]\t\tPrints all data in list");
                Console.WriteLine("[remove]\tRemove data at specific index");
                Console.WriteLine("[reverse]\tPrint all data, in reverse");
                Console.WriteLine("[set]\t\tReplaces data at specific index");
                Console.WriteLine("[quit]\t\tClose the program");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nType anything: ");
                Console.ForegroundColor = ConsoleColor.White;
                toAdd = Console.ReadLine();
                response = toAdd.ToLower();

                Console.ForegroundColor = ConsoleColor.Gray;
                switch (response)
                {
                    case "clear":
                        myList.Clear();
                        Console.WriteLine("Your list has been cleared");
                        break;
                        

                    case "count":
                        Console.WriteLine($"Your list contains {myList.Count} pieces of data");
                        break;


                    case "get":
                        int index;
                        Console.Write("Enter an index to retrieve from: ");

                        try
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            index = int.Parse(Console.ReadLine());
                        }
                        catch (Exception err)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Error! Entered value is not an int");
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;

                        try
                        {
                            Console.WriteLine($"Data at index {index} contains: {myList[index]}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                        }

                        break;


                    case "insert":
                        int index2;
                        Console.Write("Enter data to insert: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        toAdd = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Enter index to insert to: ");

                        try
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            index2 = int.Parse(Console.ReadLine());
                        }
                        catch (Exception err)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Error! Entered value is not an int");
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;

                        try
                        {
                            myList.Insert(toAdd, index2);
                            Console.WriteLine($"\"{toAdd}\" has been added to index {index2}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                        }

                        break;


                    case "print":
                        if (myList.Count == 0)
                        {
                            Console.WriteLine("Your list contains no data");
                        }
                        else
                        {
                            Console.WriteLine("Your list contains the following: ");
                            myList.PrintForward();
                        }
                        
                        break;


                    case "remove":
                        int index3;
                        Console.Write("Enter index to remove from: ");

                        try
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            index3 = int.Parse(Console.ReadLine());
                        }
                        catch (Exception err)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Error! Entered value is not an int");
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;

                        try
                        {
                            Console.WriteLine($"\"{myList.RemoveAt(index3)}\" has been removed from index {index3}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                        }

                        break;


                    case "reverse":
                        if (myList.Count == 0)
                        {
                            Console.WriteLine("Your list contains no data");
                        }
                        else
                        {
                            Console.WriteLine("Your list contains the following (in reverse): ");
                            myList.PrintReverse();
                        }

                        break;


                    case "set":
                        int index4;
                        Console.Write("Enter replacement data: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        toAdd = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("Enter index to replace to: ");

                        try
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            index4 = int.Parse(Console.ReadLine());
                        }
                        catch (Exception err)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.WriteLine("Error! Entered value is not an int");
                            break;
                        }

                        Console.ForegroundColor = ConsoleColor.Gray;

                        try
                        {
                            myList[index4] = toAdd;
                            Console.WriteLine($"\"{toAdd}\" has replaced data at index {index4}");
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                        }

                        break;


                    case "quit":
                        Console.WriteLine("Thank you for participating!");
                        break;


                    default:
                        myList.Add(toAdd);
                        Console.WriteLine($"\"{toAdd}\" has been added to your list");
                        break;
                }
            }
        }
    }
}
