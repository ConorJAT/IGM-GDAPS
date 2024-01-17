using System;

namespace Player_Inventory__Final_
{
    class Program
    {
        static void Main(string[] args)
        {
			//**********************************************************
			// Copy/paste this file's contents directly into your
			// final exam practical's Main() method
			//
			// README
			// Do not 
			// add to,
			// remove,
			// or change 
			// any of 
			// the code 
			// below!
			//
			// Your code should work with the Main method as it is written.
			//
			// If you are unable to implement methods in Inventory, you may
			//   COMMENT OUT code below so that your project compiles. 
			//**********************************************************

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Create the inventory
			Inventory myPack = new Inventory();

			// Try to read data with a non-existant file
			// Will cause exception. Should see exception stack trace in console.
			Console.WriteLine("-----------------------------------\n");
			myPack.ReadData("../../../fileDoesntExist.txt");

			// Read data with a good file
			// This will read in all data to fill dictionary with Food and Weapons
			Console.WriteLine("\n-----------------------------------\n");
			myPack.ReadData("../../../InventoryItems.txt");

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Display all items in inventory
			Console.WriteLine("\n-----------------------------------\n");
			Console.WriteLine("Here are all items in your pack:");
			myPack.PrintAllItems();

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Display all weapons in inventory
			Console.WriteLine("\n-----------------------------------\n");
			Console.WriteLine("Here are all weapons in your pack:");
			myPack.PrintAllWeapons();

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Search for a specific item and use it
			// Should fail because "pie" is not in dictionary
			Console.WriteLine("\n-----------------------------------\n");
			Item pie = myPack.GetItem("pie");
			if (pie != null)
			{
				pie.Use();
			}

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Search for a specific item and use it
			// Should be successful
			Console.WriteLine("\n-----------------------------------\n");
			pie = myPack.GetItem("Beef Pot Pie");
			if (pie != null)
			{
				pie.Use();
			}

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Get an apple and eat it until it's been fully eaten
			// Should be successful
			Console.WriteLine("\n-----------------------------------\n");
			Item apple = myPack.GetItem("Apple");
			while (apple != null && apple.Use())
			{
				Console.WriteLine(apple);
				Console.WriteLine("~~~~~");
			}

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Get a specific weapon and use it until it can't be used anymore
			// Should fail because "sWord OF hittiNG" is not in dictionary
			Console.WriteLine("\n-----------------------------------\n");
			Item weapon = myPack.GetItem("sWord OF hittiNG");
			while (weapon != null && weapon.Use())
			{
				Console.WriteLine(weapon);
				Console.WriteLine("~~~~~");
			}

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Get a specific weapon and use it until it can't be used anymore
			// Should be successful
			Console.WriteLine("\n-----------------------------------\n");
			weapon = myPack.GetItem("Sword of Hitting");
			while (weapon != null && weapon.Use())
			{
				Console.WriteLine(weapon);
				Console.WriteLine("~~~~~");
			}

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Repairs the sword
			// Should be successful
			Console.WriteLine("\n-----------------------------------\n");
			weapon = myPack.GetItem("Sword of Hitting");
			if (weapon != null)
			{
				((Weapon)weapon).Repair();
				Console.WriteLine(weapon);
			}

			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// Write final stats to file
			Console.WriteLine("\n-----------------------------------\n");
			Console.Write("Writing final stats to file...");
			myPack.WriteData("../../../InventoryStats.txt");
			Console.WriteLine("done!");
		}
    }
}
