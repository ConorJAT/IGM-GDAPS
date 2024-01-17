// Conor Race
// Nov. 29th, 2021
// Purpose: Allows for the use of a PlayerManager object, which is
// capable of writing and reading data into/from a local .data file.

using System;
using System.IO;
using System.Collections.Generic;

namespace PlayerBinaryIO
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
        /// Takes all player data in the player manager list and writes the data into a .data file for storage. If file
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
                Stream outStream = File.Open("player.data", FileMode.Create);
                BinaryWriter saveData = new BinaryWriter(outStream);
                saveData.Write(myPlayers.Count);
                for (int i = 0; i < myPlayers.Count; i++)
                {
                    saveData.Write(myPlayers[i].Name);
                    saveData.Write(myPlayers[i].Intel);
                    saveData.Write(myPlayers[i].Strength);
                }
                Console.WriteLine("\n    Saved player data to file \'player.data\'\n");
                saveData.Close();
                
            }
        }

        /// <summary>
        /// Translates data from the player.data file and adds player objects accordingly into a new player manager list.
        /// If the file does not exist, the list is NOT cleared and an error message is printed without crashing.
        /// </summary>
        public void Load()
        {
            
            try
            {
                Stream inStream = File.OpenRead("player.data");
                BinaryReader loadData = new BinaryReader(inStream);
                Console.WriteLine("\n    Loading data from \'player.data\'...");
                myPlayers.Clear();
                int playerCount = loadData.ReadInt32();
                for (int i = 0; i < playerCount; i++)
                {
                    string playerName = loadData.ReadString();
                    Console.WriteLine($"    Adding {playerName} to the list");
                    myPlayers.Add(new Player(playerName, loadData.ReadInt32(), loadData.ReadInt32()));
                }
                Console.WriteLine("    All data from file loaded. Players successfully created\n");
                loadData.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("\n    Error Reading File: " + err.Message + "\n");
            }
        }

        /// <summary>
        /// Prints the time and dats of when player.data file was created and when it was last modified.
        /// </summary>
        public void Info()
        {
            try
            {
                Stream inStream = File.OpenRead("player.data");
                Console.WriteLine("\n    Date of File Creation: " + File.GetCreationTime("player.data"));
                Console.WriteLine("    Date of Last File Modification: " + File.GetLastWriteTime("player.data") + "\n");
                inStream.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("\n    Error Reading File: " + err.Message);
                Console.WriteLine("    Please save any data in order to create file\n");
            }
        }
    }
}
