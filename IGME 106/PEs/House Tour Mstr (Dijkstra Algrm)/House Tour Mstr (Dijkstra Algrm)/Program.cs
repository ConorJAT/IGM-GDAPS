using System;

namespace House_Tour_Mstr__Dijkstra_Algrm_
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph myHouse = new Graph();

            Console.WriteLine("You will always start in the \"Billiards Room\":");
            Console.WriteLine("(Dijkstra's Algorithm has been completed!)");
            myHouse.ShortestPath("billiards room");

            string response = "hi";

            while (response != "quit")
            {
                Console.WriteLine("\n\nCurrently in the Billiards Room. Where would you like to go?");
                Console.WriteLine("(Or type \"quit\" to leave)");
                Console.Write(" > ");
                response = Console.ReadLine().ToLower();

                if (response == "quit")
                {
                    Console.WriteLine("\nHave a nice day! :)");
                    break;
                }

                Console.WriteLine("\nThe shortest path is:");
                myHouse.GetPath(response);
            }
        }
    }
}
