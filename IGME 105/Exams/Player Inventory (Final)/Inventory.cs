// Conor Race
// Dec. 10th, 2021
// Purpose - Reads from a file and transfers data from those files to
// insert data into a dictionary. Also prints all elements from the dictionary
// and writes dictionary stats to a new file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Player_Inventory__Final_
{
    class Inventory
    {
        Dictionary<string, Item> myItems;
        const double maxWeight = 40;
        double currentWeight;


        /// <summary>
        /// Constructs an inventory using a dictionary object.
        /// </summary>
        public Inventory()
        {
            myItems = new Dictionary<string, Item>();
            currentWeight = 0;
        }


        /// <summary>
        /// Reads from a file using a StreamReader and transfers any data from the
        /// file into the dictionary object.
        /// </summary>
        /// <param name="filename"> Name of file to be read from. </param>
        public void ReadData(string filename)
        {
            try
            {
                StreamReader input = new StreamReader(filename);
                string line = null;
                while ((line = input.ReadLine()) != null)
                {
                    string[] itemType = line.Split(',');
                    string[] itemInfo = itemType[1].Split('|');
                    if (itemType[0] == "food")
                    {
                        if(AddItem(new Food(itemInfo[0], int.Parse(itemInfo[1]), double.Parse(itemInfo[2]))))
                        {
                            Console.WriteLine($"{itemInfo[0]} has been added.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough room in inventory for {itemInfo[0]}");
                        }
                    }

                    else if (itemType[0] == "weapon")
                    {
                        if(AddItem(new Weapon(itemInfo[0], int.Parse(itemInfo[1]), int.Parse(itemInfo[2]), double.Parse(itemInfo[3]))))
                        {
                            Console.WriteLine($"{itemInfo[0]} has been added.");
                        }
                        else
                        {
                            Console.WriteLine($"Not enough room in inventory for {itemInfo[0]}");
                        }
                    }
                }
                input.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("Problem reading data! Could not find file:\n" + err.Message);
            }
        }

        /// <summary>
        /// Writes current info regarding dictionary into a new file.
        /// </summary>
        /// <param name="filename"> Name of file to be written into. </param>
        public void WriteData(string filename)
        {
            try
            {
                StreamWriter output = new StreamWriter(filename);
                output.WriteLine("Current Number of Items: " + myItems.Count);
                output.WriteLine("Inventory Max Weight: " + maxWeight);
                output.WriteLine("Inventory Current Weight: " + currentWeight);
                output.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("Problem reading data! Could not find file:\n" + err.Message);
            }
        }


        /// <summary>
        /// Adds items accordingly to the dictionary object, if enough space exists.
        /// </summary>
        /// <param name="itemToAdd"> Item object to be added, if possible. </param>
        /// <returns> True, if item insertion was successful. False, otherwise. </returns>
        public bool AddItem(Item itemToAdd)
        {
            if (currentWeight == 40 || (currentWeight + itemToAdd.Weight) >= 40)
            {
                return false;
            }
            else
            {
                myItems.Add(itemToAdd.Name, itemToAdd);
                currentWeight += itemToAdd.Weight;
                return true;
            }
        }


        /// <summary>
        /// Checks the dictionary to see if an item is present within it.
        /// </summary>
        /// <param name="ItemName"> Name of item, which is used as the key. </param>
        /// <returns> Associated item if present, null if it is not present. </returns>
        public Item GetItem(string ItemName)
        {
            if (myItems.Count == 0)
            {
                Console.WriteLine("No items in your inventory.");
                return null;
            }
            else if (myItems.ContainsKey(ItemName))
            {
                Console.WriteLine($"Found {ItemName}");
                return myItems[ItemName];
            }
            else
            {
                Console.WriteLine($"Did not find {ItemName}");
                return null;
            }
        }


        /// <summary>
        /// Prints all items and their stats.
        /// </summary>
        public void PrintAllItems()
        {
            foreach (string key in myItems.Keys)
            {
                Console.WriteLine(myItems[key]);
            }
        }


        /// <summary>
        /// Only prints all weapons and their stats.
        /// </summary>
        public void PrintAllWeapons()
        {
            foreach (string key in myItems.Keys)
            {
                if (myItems[key] is Weapon)
                {
                    Console.WriteLine(myItems[key]);
                }
            }
        }
    }
}
