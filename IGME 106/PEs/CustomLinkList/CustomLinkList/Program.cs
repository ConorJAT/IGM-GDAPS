// Conor Race
// IGME.106.07
// March 14th, 2022

using System;

namespace CustomLinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomLinkList<string> myList = new CustomLinkList<string>();

            Console.WriteLine("  ---- Link List Inventory Tracker ----\n");
            Console.WriteLine("  Link List Created. Please add 5 items to your inventory:");

            for (int i = 1; i < 6; i++)
            {
                Console.Write($"  - Item #{i}: ");
                myList.Add(Console.ReadLine());
            }

            Console.WriteLine($"\n  Your list has {myList.Count} items. These items include: ");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"  - {myList.GetData(i)}");
            }

            try
            {
                Console.WriteLine("\n  Removing item at index 101...");
                Console.WriteLine($"  Removed {myList.RemoveAt(101)}");
            }
            catch (Exception err)
            {
                Console.WriteLine("  " + err.Message);
            }

            Console.WriteLine("\n  Removing item at index 4...");
            Console.WriteLine($"  Removed {myList.RemoveAt(4)}");

            Console.WriteLine("\n  Removing item at index 0...");
            Console.WriteLine($"  Removed {myList.RemoveAt(0)}");

            Console.WriteLine("\n  Removing item at index 1...");
            Console.WriteLine($"  Removed {myList.RemoveAt(1)}");

            Console.WriteLine($"\n  Your list has {myList.Count} items. These items include: ");

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine($"  - {myList.GetData(i)}");
            }
        }
    }
}
