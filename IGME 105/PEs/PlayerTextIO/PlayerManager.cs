// Conor Race
// Nov. 29th, 2021
// Purpose: Allows for the use of a PlayerManager object, which is
// capable of writing and reading data into/from a local .txt file.

using System;
using System.IO;
using System.Collections.Generic;

namespace PlayerTextIO
{
    class PlayerManager
    {
        Random rng = new Random();
        List<Player> myPlayers;

        /// <summary>
        /// Constructor; Initializes the list which is used in every player manager object. No required list length.
        /// </summary>
        public PlayerManager()
        {
            myPlayers = new List<Player>();
        }

        /// <summary>
        /// Adds a player object to the end of the player manager list. Numeric stats are randomized.
        /// </summary>
        /// <param name="name"> The name of the new player. </param>
        public void CreatePlayer(string name)
        {
            myPlayers.Add(new Player(name, rng.Next(10, 41), rng.Next(10, 41)));
        }

        /// <summary>
        /// Prints all names in the player manager list, if any.
        /// </summary>
        public void Print()
        {
            if (myPlayers.Count == 0)
            {
                Console.WriteLine("    No players found in list! Try loading from save file?");
            }
            else
            {
                for (int i = 0; i < myPlayers.Count; i++)
                {
                    Console.WriteLine("    " + myPlayers[i]);
                }
            }
        }

        /// <summary>
        /// Takes all player data in the player manager list and writes the data into a .txt file for storage. If file
        /// does not exist, a new one is created. Will not save if no data is present in the list.
        /// </summary>
        public void Save()
        {
            if (myPlayers.Count == 0)
            {
                Console.WriteLine("\n    No player data found!\n");
            }
            else
            {
                StreamWriter saveData = new StreamWriter("player.txt");

                for (int i = 0; i < myPlayers.Count; i++)
                {
                    saveData.WriteLine($"{myPlayers[i].Name},{myPlayers[i].Intel},{myPlayers[i].Strength}");
                }

                Console.WriteLine("\n    Saved player data to file \'player.txt\'\n");
                saveData.Close();
            }
        }

        /// <summary>
        /// Translates data from the player.txt file and adds player objects accordingly into a new player manager list.
        /// If the file does not exist, the list is NOT cleared and an error message is printed without crashing.
        /// </summary>
        public void Load()
        {
            try
            {
                StreamReader loadData = new StreamReader("player.txt");
                Console.WriteLine("\n    Loading data from \'player.txt\'...");
                myPlayers.Clear();
                string line = null;
                
                while ((line = loadData.ReadLine()) != null)
                {
                    string[] newPlayer = line.Split(',');
                    Console.WriteLine($"    Adding {newPlayer[0]} to the list");
                    myPlayers.Add(new Player(newPlayer[0], int.Parse(newPlayer[1]), int.Parse(newPlayer[2])));
                }

                Console.WriteLine("    All data from file loaded. Players successfully created\n");
                loadData.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("\n    Error Reading File: " + err.Message + "\n");
            }
        }
    }
}
