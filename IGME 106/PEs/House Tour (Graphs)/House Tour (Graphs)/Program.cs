// Conor Race
// April 6th, 2022
// IGME.06.07

using System;
using System.Collections.Generic;

namespace House_Tour__Graphs_
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph myHouse = new Graph();
            string current = "main hall";

            // Prints all rooms and their info:
            Console.WriteLine("All Availible Rooms:");
            myHouse.ListAllVerticies();

            // Loops while user is in the house:
            while (current != "exit")
            {
                // Loops through all rooms until finds matching one:
                for (int i = 0; i < myHouse.Rooms.Count; i++)
                {
                    if (current == myHouse.Rooms[i].Room.ToLower())
                    {
                        // Get the list of all adjacent rooms in this current room:
                        List<Vertex> adjacent = myHouse.GetAdjacentList(current);

                        Console.WriteLine("\n\nYou are currently in the " + myHouse.Rooms[i]);

                        // If the user has exited, let them know and break out of the loop:
                        if (current == "exit")
                        {
                            Console.WriteLine("   Successfully left the house.");
                            break;
                        }

                        // If not at the exit, print all adjacent rooms:
                        Console.Write("   Rooms nearby: ");
                        for (int j = 0; j < adjacent.Count; j++)
                        {
                            Console.Write(adjacent[j].Room + "   ");
                        }

                        // Collect user input:
                        Console.WriteLine("");
                        Console.Write("   Where would you like to go?: ");
                        string newRoom = Console.ReadLine().ToLower();

                        // If the input connects to the current room, change the current room:
                        if (myHouse.IsConnected(current, newRoom))
                        {
                            current = newRoom;
                        }

                        // If not, keep the user in the same room, and alert of non-adjacency:
                        else
                        {
                            Console.WriteLine("   Sorry, but that is not an adjacent room.");
                        }
                    }
                }
            }
        }
    }
}
