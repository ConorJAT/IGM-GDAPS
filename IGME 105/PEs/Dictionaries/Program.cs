// Conor Race
// Nov. 15th, 2021
// Purpose: Practices the use of dictionaries using Player objects.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<String, Player> myParty = new Dictionary<string, Player>();

            myParty.Add("sonic", new Player("Sonic", 40));
            myParty.Add("tails", new Player("Tails", 37));
            myParty.Add("knuckles", new Player("Knuckles", 36));
            myParty.Add("shadow", new Player("Shadow", 32));

            string userResponse = null;


            // PART #1 - DICTIONARY BASICS

            Console.WriteLine("--- Part 1: Using a Dictionary ---\n");
            while (userResponse != "quit" && userResponse != "done")
            {
                Console.Write("Please enter the name of a player or enter \"done\" or \"quit\": ");
                userResponse = Console.ReadLine().ToLower();

                if (myParty.ContainsKey(userResponse))
                {
                    Console.WriteLine(myParty[userResponse].ToString());
                }
                else if (userResponse == "done" || userResponse == "quit")
                {
                    Console.WriteLine("Cya Later, Aligator!");
                }
                else
                {
                    Console.WriteLine("Player not found! Please try again!");
                }

                Console.WriteLine("");
            }
            Console.WriteLine("");


            // PART #2 - PERFORMANCE SPEED

            Console.WriteLine("--- Part 2: Performance Testing ---\n");
            myParty.Clear();
            List<Player> mySlowParty = new List<Player>();
            Stopwatch timer = new Stopwatch();
            Random rng = new Random();

            for (int i = 0; i < 100000; i++)
            {
                Player addPlayer = new Player("P" + i, rng.Next(1001));
                myParty.Add(addPlayer.Name, addPlayer);
                mySlowParty.Add(addPlayer);
            }

            timer.Start();
            Player lastPlayer = myParty["P99999"];
            timer.Stop();
            Console.WriteLine("Dictionary Performance Time: " + timer.Elapsed.TotalMilliseconds);

            timer.Restart();
            for (int i = 0; i < mySlowParty.Count; i++)
            {
                if (mySlowParty[i].Name == "P99999")
                {
                    break;
                }
            }
            timer.Stop();
            Console.WriteLine("List Performance Time: " + timer.Elapsed.TotalMilliseconds);
        }
    }
}
